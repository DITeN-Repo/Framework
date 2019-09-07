#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

#endregion

namespace Diten.Tor.Proxy
{
	/// <summary>
	///     A class containing the logic for the hosted HTTP proxy, which listens for connections to delegate to the tor
	///     network.
	/// </summary>
	[DebuggerStepThrough]
	public sealed class Proxy : MarshalByRefObject, IDisposable
	{
		private readonly Client client;

		private readonly List<Connection> connections;
		private readonly List<ConnectionProcessor> processors;
		private readonly object synchronize;
		private volatile bool disposed;
		private int port;
		private Socket socket;
		private volatile bool suppressDispose;
		private Socks5Proxy webProxy;

		/// <summary>
		///     Initializes a new instance of the <see cref="Proxy" /> class.
		/// </summary>
		/// <param name="client">The client for which this object instance belongs.</param>
		internal Proxy(Client client)
		{
			this.client = client;
			connections = new List<Connection>();
			webProxy = null;
			port = 8182;
			processors = new List<ConnectionProcessor>();
			socket = null;
			suppressDispose = false;
			synchronize = new object();

			Start();
		}

		/// <summary>
		///     Finalizes an instance of the <see cref="Proxy" /> class.
		/// </summary>
		~Proxy()
		{
			Dispose(false);
		}

		#region Tor.Net.ForwardSocket

		/// <summary>
		///     Called when the internal listener socket accepts a TCP connection.
		/// </summary>
		/// <param name="ar">The asynchronous result object for this callback.</param>
		private void OnSocketAccept(IAsyncResult ar)
		{
			try
			{
				var accepted = socket.EndAccept(ar);

				if (client != null)
				{
					var connection = new Connection(client, accepted, OnConnectionDisposed);

					lock (synchronize)
					{
						connections.Add(connection);
					}

					var processor = new ConnectionProcessor(client, connection, OnConnectionProcessorDisposed);

					lock (synchronize)
					{
						processors.Add(processor);
					}

					processor.Start();
				}
			}
			catch
			{
			}

			try
			{
				if (socket != null)
					socket.BeginAccept(OnSocketAccept, socket);
			}
			catch
			{
			}
		}

		#endregion

		#region Tor.Proxy.Connection

		/// <summary>
		///     Called when a connection has been disposed.
		/// </summary>
		/// <param name="connection">The connection which was disposed.</param>
		private void OnConnectionDisposed(Connection connection)
		{
			if (connection == null || suppressDispose)
				return;

			lock (synchronize)
			{
				connections.Remove(connection);
			}
		}

		#endregion

		#region Tor.Proxy.ConnectionProcessor

		/// <summary>
		///     Called when a connection processor has been disposed.
		/// </summary>
		/// <param name="processor">The connection processor which was disposed.</param>
		private void OnConnectionProcessorDisposed(ConnectionProcessor processor)
		{
			if (processor == null || suppressDispose)
				return;

			lock (synchronize)
			{
				processors.Remove(processor);
			}
		}

		#endregion

		/// <summary>
		///     Starts the proxy by creating a TCP listener on the specified proxy port number.
		/// </summary>
		private void Start()
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				if (socket != null)
					return;

				try
				{
					socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
					socket.Listen(25);

					socket.BeginAccept(OnSocketAccept, socket);

					webProxy = new Socks5Proxy(client);
				}
				catch
				{
					if (socket != null)
					{
						socket.Dispose();
						socket = null;
					}
				}
			}
		}

		/// <summary>
		///     Shuts down the TCP listener, releasing any resources associated with it.
		/// </summary>
		private void Shutdown()
		{
			lock (synchronize)
			{
				if (socket == null)
					return;

				try
				{
					socket.Shutdown(SocketShutdown.Both);
				}
				catch
				{
				}

				socket.Dispose();
				socket = null;

				webProxy = null;
			}
		}

		#region Properties

		/// <summary>
		///     Gets the address of the proxy which can be used for manually creating <see cref="WebProxy" /> objects.
		/// </summary>
		public string Address => $"http://127.0.0.1:{port}";

		/// <summary>
		///     Gets a value indicating whether the proxy socket is bound to the listen port.
		/// </summary>
		public bool IsRunning
		{
			get
			{
				lock (synchronize)
				{
					return socket != null && socket.IsBound;
				}
			}
		}

		/// <summary>
		///     Gets or sets the port number which the client will listen on for HTTP proxy connections. This value defaults to
		///     8182, but can be
		///     changed depending on firewall restrictions. The port number must be available in order to host the HTTP proxy.
		/// </summary>
		public int Port
		{
			get => port;
			set
			{
				if (port != value)
				{
					port = value;
					Shutdown();
					Start();
				}
			}
		}

		/// <summary>
		///     Gets an <see cref="IWebProxy" /> which can be used in HTTP requests. This will be <c>null</c> if the proxy could
		///     not be hosted
		///     on the specified port number.
		/// </summary>
		public IWebProxy WebProxy
		{
			get
			{
				if (disposed)
					throw new ObjectDisposedException("this");

				lock (synchronize)
				{
					return webProxy;
				}
			}
		}

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

			if (disposing)
			{
				lock (synchronize)
				{
					suppressDispose = true;

					foreach (var processor in processors)
						processor.Dispose();

					foreach (var connection in connections)
						connection.Dispose();

					connections.Clear();
					processors.Clear();
				}

				Shutdown();
				disposed = true;
			}
		}

		#endregion
	}
}