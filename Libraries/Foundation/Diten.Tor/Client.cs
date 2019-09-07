#region Using Directives

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Diten.Tor.Config;
using Diten.Tor.Controller;
using Diten.Tor.Helpers;
using Diten.Tor.IO;

#endregion

namespace Diten.Tor
{
	/// <inheritdoc cref="MarshalByRefObject" />
	/// <summary>
	///     A class linked to a running tor application process, and provides methods and properties for interacting with the
	///     tor service.
	/// </summary>
	public sealed class Client : MarshalByRefObject, IDisposable
	{
		private readonly ClientCreateParams createParams;
		private readonly ClientRemoteParams remoteParams;
		private readonly object synchronize;

		private volatile bool disposed;
		private Process process;

		/// <inheritdoc />
		/// <summary>
		///     Initializes a new instance of the <see cref="T:Diten.Tor.Client" /> class.
		/// </summary>
		/// <param name="createParams">The parameters used when creating the client.</param>
		private Client(ClientCreateParams createParams)
		{
			this.createParams = createParams;
			disposed = false;
			process = null;
			remoteParams = null;
			synchronize = new object();

			Start();
		}

		/// <inheritdoc />
		/// <summary>
		///     Initializes a new instance of the <see cref="T:Diten.Tor.Client" /> class.
		/// </summary>
		/// <param name="remoteParams">The parameters used when connecting to the client.</param>
		private Client(ClientRemoteParams remoteParams)
		{
			createParams = null;
			disposed = false;
			process = null;
			this.remoteParams = remoteParams;
			synchronize = new object();

			Start();
		}

		/// <summary>
		///     Finalizes an instance of the <see cref="Client" /> class.
		/// </summary>
		~Client()
		{
			Dispose(false);
		}

		#region Events

		/// <summary>
		///     Occurs when the client has been shutdown, either from manual shutdown or by forcible means.
		/// </summary>
		public event EventHandler Shutdown;

		#endregion

		#region System.Diagnostics.Process

		/// <summary>
		///     Called when the process has exited.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void OnHandleProcessExited(object sender, EventArgs e)
		{
			Stop(true);
		}

		#endregion

		/// <summary>
		///     Creates a new <see cref="Client" /> object instance and attempts to launch the tor application executable.
		/// </summary>
		/// <param name="createParams">The parameters used when creating the client.</param>
		/// <returns>A <see cref="Client" /> object instance.</returns>
		public static Client Create(ClientCreateParams createParams)
		{
			if (createParams == null)
				throw new ArgumentNullException("createParams");

			return new Client(createParams);
		}

		/// <summary>
		///     Creates a new <see cref="Client" /> object instance configured to connect to a remotely hosted tor application
		///     executable.
		/// </summary>
		/// <param name="remoteParams">The parameters used when connecting to the client.</param>
		/// <returns>A <see cref="Client" /> object instance.</returns>
		public static Client CreateForRemote(ClientRemoteParams remoteParams)
		{
			if (remoteParams == null)
				throw new ArgumentNullException("remoteParams");

			return new Client(remoteParams);
		}

		/// <summary>
		///     Gets the address hosting the tor application.
		/// </summary>
		/// <returns>A <see cref="System.String" /> containing the host address.</returns>
		internal string GetClientAddress()
		{
			if (IsRemote)
				return remoteParams.Address;
			return "127.0.0.1";
		}

		/// <summary>
		///     Gets the configurations from the tor application by dispatching the <c>getconf</c> command.
		/// </summary>
		private void GetClientConfigurations()
		{
			var configurations =
				ReflectionHelper.GetEnumeratorAttributes<ConfigurationNames, ConfigurationAssocAttribute, string>(
					attr => attr.Name);
			var command = new GetConfCommand(configurations);
			var response = command.Dispatch(this);

			if (!response.Success)
				throw new TorException(
					"The client failed to retrieve configuration values from the tor application (check your control port and password)");

			foreach (var value in response.Values)
			{
				var key = value.Key;
				var val = value.Value;

				Configuration.SetValueDirect(key, val);
			}

			var version = Status.Version;
			var empty = new Version();

			if (empty >= version || version >= MinimumSupportedVersion) return;
			Dispose();
			throw new TorException("This version of tor is not supported, please use version " +
			                       MinimumSupportedVersion + " or higher");
		}

		/// <summary>
		///     Gets the control password to use in the control connection of the hosted tor application, based on
		///     the parameters supplied.
		/// </summary>
		/// <returns>A <see cref="System.String" /> containing the control port password.</returns>
		internal string GetControlPassword()
		{
			if (IsRemote)
				return remoteParams.ControlPassword ?? "";
			return createParams.ControlPassword ?? "";
		}

		/// <summary>
		///     Gets the control port of the hosted tor application based on the parameters supplied.
		/// </summary>
		/// <returns>A <see cref="System.Int32" /> containing the control port number.</returns>
		internal int GetControlPort()
		{
			return IsRemote ? remoteParams.ControlPort : createParams.ControlPort;
		}

		/// <summary>
		///     Gets a <see cref="System.IO.Stream" /> for the running client. This method will establish a connection to the
		///     specified
		///     host address and port number, and function as an intermediary for communications.
		/// </summary>
		/// <returns>
		///     A <see cref="System.IO.Stream" /> object instance connected to the specified host address and port through the
		///     tor network.
		/// </returns>
		public System.IO.Stream GetStream(string host, int port)
		{
			return new Socks5Stream(this, host, port);
		}

		/// <summary>
		///     Starts the tor application executable using the provided creation parameters.
		/// </summary>
		private void Start()
		{
			if (createParams != null)
				createParams.ValidateParameters();
			else
				remoteParams.ValidateParameters();

			if (createParams != null)
				lock (synchronize)
				{
					if (process != null && !process.HasExited)
						return;

					var psi = new ProcessStartInfo(createParams.Path)
					{
						Arguments = createParams.ToString(),
						CreateNoWindow = true,
						UseShellExecute = false,
						WindowStyle = ProcessWindowStyle.Hidden,
						WorkingDirectory = Path.GetDirectoryName(createParams.Path) ??
						                   throw new InvalidOperationException()
					};

					try
					{
						process = new Process {EnableRaisingEvents = true};
						process.Exited += OnHandleProcessExited;
						process.StartInfo = psi;

						if (!process.Start())
						{
							process.Dispose();
							process = null;

							throw new TorException("The tor application process failed to launch");
						}
					}
					catch (Exception exception)
					{
						throw new TorException("The tor application process failed to launch", exception);
					}
				}

			Thread.Sleep(500);

			lock (synchronize)
			{
				Configuration = new Configuration.Configuration(this);
				Controller = new Control(this);
				Logging = new Logging.Logging(this);
				Proxy = new Proxy.Proxy(this);
				Status = new Status.Status(this);

				Events = new Events.Events(this);
				Events.Start(delegate
				{
					Configuration.Start();
					Status.Start();

					GetClientConfigurations();
				});
			}
		}

		/// <summary>
		///     Shuts down the tor application process and releases the associated components of the class.
		/// </summary>
		/// <param name="exited">A value indicating whether the shutdown is being performed after the process has exited.</param>
		private void Stop(bool exited)
		{
			if (disposed && !exited)
				return;

			lock (synchronize)
			{
				if (!IsRemote && process != null)
				{
					if (exited)
					{
						process.Dispose();
						process = null;
					}
					else
					{
						var command = new SignalHaltCommand();
						var response = command.Dispatch(this);

						if (response.Success)
							return;

						process.Kill();
						process.Dispose();
						process = null;
					}
				}

				if (Proxy != null)
				{
					Proxy.Dispose();
					Proxy = null;
				}

				if (Events != null)
				{
					Events.Dispose();
					Events = null;
				}

				Configuration = null;
				Controller = null;
				Logging = null;
				Status = null;

				Shutdown?.Invoke(this, EventArgs.Empty);
			}
		}

		#region Properties

		/// <summary>
		///     Gets an object containing configuration values associated with the tor application.
		/// </summary>
		public Configuration.Configuration Configuration { get; private set; }

		/// <summary>
		///     Gets an object which can be used for performing control operations against the tor application.
		/// </summary>
		public Control Controller { get; private set; }

		/// <summary>
		///     Gets a value indicating whether the client is configured to a remote tor application.
		/// </summary>
		public bool IsRemote => remoteParams != null;

		/// <summary>
		///     Gets a value indicating whether the tor application is still running for this client.
		/// </summary>
		public bool IsRunning
		{
			get
			{
				if (IsRemote) return true;
				lock (synchronize)
				{
					return process != null && !process.HasExited;
				}
			}
		}

		/// <summary>
		///     Gets an object which can be used to receive log messages from the tor client.
		/// </summary>
		public Logging.Logging Logging { get; private set; }

		/// <summary>
		///     Gets an object which manages the hosted HTTP proxy and can be used to create an <see cref="IWebProxy" /> object
		///     instance.
		/// </summary>
		public Proxy.Proxy Proxy { get; private set; }

		/// <summary>
		///     Gets an object which provides methods and properties for determining the status of the tor network service.
		/// </summary>
		public Status.Status Status { get; private set; }

		/// <summary>
		///     Gets an object which can be used to monitor for events within the tor service.
		/// </summary>
		internal Events.Events Events { get; private set; }

		/// <summary>
		///     Gets the minimum supported tor version number. The version number is checked after being launched or connected, and
		///     will raise an
		///     exception if the minimum version number is not satisfied.
		/// </summary>
		public static Version MinimumSupportedVersion { get; } = new Version(0, 2, 0, 9);

		#endregion

		#region System.IDisposable

		/// <summary>
		///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		///     Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">
		///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
		///     unmanaged resources.
		/// </param>
		private void Dispose(bool disposing)
		{
			if (disposed)
				return;

			Stop(false);
			disposed = true;
		}

		#endregion
	}
}