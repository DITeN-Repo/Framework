#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class which provides monitoring for events occuring within the tor service.
	/// </summary>
	public sealed class Events : IDisposable
	{
		private const string EOL = "\r\n";
		private static readonly Dictionary<Event, Type> dispatchers;
		private readonly byte[] buffer;

		private readonly Client client;
		private readonly Dictionary<Event, int> events;
		private readonly object synchronize;

		private StringBuilder backlog;
		private Action connectCallback;
		private volatile bool disposed;
		private volatile bool enabled;
		private StringBuilder multiLine;
		private Socket socket;

		/// <summary>
		///     Initializes the <see cref="Events" /> class.
		/// </summary>
		static Events()
		{
			dispatchers = new Dictionary<Event, Type>();

			var values = Enum.GetValues(typeof(Event)) as Event[];

			foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t =>
				t.Namespace == "Diten.Tor.Events" && typeof(Dispatcher).IsAssignableFrom(t)))
			{
				var attribute = Attribute.GetCustomAttribute(type, typeof(EventAssocAttribute)) as EventAssocAttribute;

				if (attribute == null)
					continue;

				if (values == null) continue;
				foreach (var value in values)
					if ((attribute.Event & value) == value)
						dispatchers[value] = type;
			}
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="Events" /> class.
		/// </summary>
		/// <param name="client">The client for which this object instance belongs.</param>
		internal Events(Client client)
		{
			backlog = new StringBuilder();
			buffer = new byte[256];
			connectCallback = null;
			this.client = client;
			disposed = false;
			enabled = true;
			events = new Dictionary<Event, int>();
			multiLine = null;
			socket = null;
			synchronize = new object();
		}

		private event BandwidthEventHandler bandwidthChangedHandlers;
		private event CircuitEventHandler circuitChangedHandlers;
		private event ConfigurationChangedEventHandler configurationChangedHandlers;
		private event LogEventHandler debugReceivedHandlers;
		private event LogEventHandler errorReceivedHandlers;
		private event LogEventHandler infoReceivedHandlers;
		private event LogEventHandler noticeReceivedHandlers;
		private event ORConnectionEventHandler orConnectionChangedHandlers;
		private event StreamEventHandler streamChangedHandlers;
		private event LogEventHandler warnReceivedHandlers;

		/// <summary>
		///     Adds an event to the list of monitored events.
		/// </summary>
		/// <param name="evt">The event which should be monitored for.</param>
		private void AddEvent(Event evt)
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				events.TryGetValue(evt, out var counter);
				events[evt] = ++counter;

				if (enabled && counter == 1)
					SetEvents();
			}
		}

		/// <summary>
		///     Dispatches an event by parsing the content of the line and raising the relevant event.
		/// </summary>
		/// <param name="line">The line received from the control connection.</param>
		private void Dispatch(string line)
		{
			if (line == null)
				throw new ArgumentNullException("line");

			var trimmed = line.Trim();

			if (trimmed.Length < 3)
				return;

			string[] parts;

			if (trimmed.Length > 3 && trimmed[3] == '-')
			{
				var intermediate = trimmed.Split(new[] {'-'}, 2); // [650, EVENT....]

				if (intermediate.Length < 2)
					return;

				var status = intermediate[0].Trim();
				var content = intermediate[1].Trim();

				var data = content.Split(new[] {EOL}, 2, StringSplitOptions.None); // [EVENT, ...]

				if (data.Length < 2)
					return;

				parts = new[] {status, data[0], data[1]};
			}
			else
			{
				parts = trimmed.Split(new[] {' '}, 3);
			}

			if (parts.Length < 2)
				return;

			if (parts[0].Equals("650"))
			{
				var evt = ReflectionHelper.GetEnumerator<Event, DescriptionAttribute>(attr =>
					parts[1].Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));

				if (evt == Event.Unknown)
					return;

				Type type;

				if (!dispatchers.TryGetValue(evt, out type))
					return;

				if (!(Activator.CreateInstance(type) is Dispatcher dispatcher)) return;
				dispatcher.Client = client;
				dispatcher.CurrentEvent = evt;
				dispatcher.Events = this;

				dispatcher.Dispatch(parts[2]);
			}
		}

		/// <summary>
		///     Removes an event from the list of monitored events.
		/// </summary>
		/// <param name="evt">The event which should be removed.</param>
		private void RemoveEvent(Event evt)
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				if (!events.ContainsKey(evt))
					return;

				events.TryGetValue(evt, out var counter);
				counter--;

				if (counter == 0)
				{
					events.Remove(evt);
					SetEvents();
				}
				else
				{
					events[evt] = counter;
				}
			}
		}

		/// <summary>
		///     Signals to the control connection to begin monitoring for interested events.
		/// </summary>
		private void SetEvents()
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				if (socket == null || !socket.Connected || !enabled)
					return;

				var builder = new StringBuilder("SETEVENTS");

				foreach (var interested in events)
				{
					var name = ReflectionHelper.GetDescription(interested.Key);

					builder.Append(' ');
					builder.Append(name);
				}

				var command = builder.Append("\r\n").ToString();
				var bufferHolder = Encoding.ASCII.GetBytes(command);

				socket.BeginSend(bufferHolder, 0, bufferHolder.Length, SocketFlags.None, OnSocketSendEvents, null);
			}
		}

		/// <summary>
		///     Sets the current response data received from the control port, which is event information.
		/// </summary>
		/// <param name="response">The response received from the control port.</param>
		private void SetEventResponse(string response)
		{
			if (response == null)
				throw new ArgumentNullException("response");
			if (response.Length == 0)
				return;

			if (backlog.Length > 0)
				response = new StringBuilder(backlog.Length + response.Length).Append(backlog).Append(response)
					.ToString();

			var index = 0;
			var length = response.Length;
			var dispatch = new List<string>();

			if (response.Contains(EOL))
				for (var next = response.IndexOf(EOL, StringComparison.Ordinal);
					0 <= next;
					next = response.IndexOf(EOL, next, StringComparison.Ordinal))
				{
					var line = response.Substring(index, next - index);
					next += EOL.Length;
					index = next;

					if (line.Length == 0)
					{
						if (index == length)
							break;

						continue;
					}

					if (line.StartsWith("250"))
						continue;

					if (3 < line.Length && line[3] == '-')
					{
						if (multiLine == null)
							multiLine = new StringBuilder();

						multiLine.AppendLine(line);
						continue;
					}

					if (multiLine != null)
					{
						dispatch.Add(multiLine.ToString());
						multiLine = null;
					}
					else
					{
						dispatch.Add(line);
					}

					if (index == length)
						break;
				}

			if (backlog.Length > 0 && index == length)
				backlog = new StringBuilder();

			if (index < length)
				backlog = new StringBuilder(response.Substring(index));

			if (dispatch.Count > 0)
				foreach (var line in dispatch)
					Dispatch(line);
		}

		/// <summary>
		///     Starts the process of monitoring for events by launching a control connection.
		/// </summary>
		/// <param name="callback">A method raised when the connection has completed.</param>
		internal void Start(Action callback)
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				if (socket != null || !enabled)
					return;

				connectCallback = callback;

				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
				socket.BeginConnect(client.GetClientAddress(), client.GetControlPort(), OnSocketConnect, null);
			}
		}

		/// <summary>
		///     Shuts down the listener socket and releases all resources associated with it.
		/// </summary>
		internal void Shutdown()
		{
			lock (synchronize)
			{
				if (socket != null)
				{
					try
					{
						socket.Shutdown(SocketShutdown.Both);
					}
					catch
					{
						// ignored
					}

					socket.Dispose();
					socket = null;
				}
			}
		}

		#region Events

		/// <summary>
		///     Occurs when the bandwidth download and upload values change within the tor service.
		/// </summary>
		public event BandwidthEventHandler BandwidthChanged
		{
			add
			{
				bandwidthChangedHandlers += value;
				AddEvent(Event.Bandwidth);
			}
			remove
			{
				bandwidthChangedHandlers += value;
				RemoveEvent(Event.Bandwidth);
			}
		}

		/// <summary>
		///     Occurs when a circuit has changed within the tor service.
		/// </summary>
		public event CircuitEventHandler CircuitChanged
		{
			add
			{
				circuitChangedHandlers += value;
				AddEvent(Event.Circuits);
			}
			remove
			{
				circuitChangedHandlers -= value;
				RemoveEvent(Event.Circuits);
			}
		}

		/// <summary>
		///     Occurs when configurations have changed within the tor service.
		/// </summary>
		public event ConfigurationChangedEventHandler ConfigurationChanged
		{
			add
			{
				configurationChangedHandlers += value;
				AddEvent(Event.ConfigChanged);
			}
			remove
			{
				configurationChangedHandlers -= value;
				RemoveEvent(Event.ConfigChanged);
			}
		}

		/// <summary>
		///     Occurs when a debug log message is received.
		/// </summary>
		public event LogEventHandler DebugReceived
		{
			add
			{
				debugReceivedHandlers += value;
				AddEvent(Event.LogDebug);
			}
			remove
			{
				debugReceivedHandlers -= value;
				RemoveEvent(Event.LogDebug);
			}
		}

		/// <summary>
		///     Occurs when an error log message is received.
		/// </summary>
		public event LogEventHandler ErrorReceived
		{
			add
			{
				errorReceivedHandlers += value;
				AddEvent(Event.LogError);
			}
			remove
			{
				errorReceivedHandlers -= value;
				RemoveEvent(Event.LogError);
			}
		}

		/// <summary>
		///     Occurs when an information log message is received.
		/// </summary>
		public event LogEventHandler InfoReceived
		{
			add
			{
				infoReceivedHandlers += value;
				AddEvent(Event.LogInfo);
			}
			remove
			{
				infoReceivedHandlers -= value;
				RemoveEvent(Event.LogInfo);
			}
		}

		/// <summary>
		///     Occurs when a notice log message is received.
		/// </summary>
		public event LogEventHandler NoticeReceived
		{
			add
			{
				noticeReceivedHandlers += value;
				AddEvent(Event.LogNotice);
			}
			remove
			{
				noticeReceivedHandlers -= value;
				RemoveEvent(Event.LogNotice);
			}
		}

		/// <summary>
		///     Occurs when an OR connection has changed within the tor service.
		/// </summary>
		public event ORConnectionEventHandler ORConnectionChanged
		{
			add
			{
				orConnectionChangedHandlers += value;
				AddEvent(Event.ORConnections);
			}
			remove
			{
				orConnectionChangedHandlers -= value;
				RemoveEvent(Event.ORConnections);
			}
		}

		/// <summary>
		///     Occurs when a stream has changed within the tor service.
		/// </summary>
		public event StreamEventHandler StreamChanged
		{
			add
			{
				streamChangedHandlers += value;
				AddEvent(Event.Streams);
			}
			remove
			{
				streamChangedHandlers -= value;
				RemoveEvent(Event.Streams);
			}
		}

		/// <summary>
		///     Occurs when a warning log message is received.
		/// </summary>
		public event LogEventHandler WarnReceived
		{
			add
			{
				warnReceivedHandlers += value;
				AddEvent(Event.LogWarn);
			}
			remove
			{
				warnReceivedHandlers -= value;
				RemoveEvent(Event.LogWarn);
			}
		}

		#endregion

		#region Events Invoke

		/// <summary>
		///     Raises the <see cref="E:BandwidthChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="BandwidthEventArgs" /> instance containing the event data.</param>
		internal void OnBandwidthChanged(BandwidthEventArgs e)
		{
			bandwidthChangedHandlers?.Invoke(client, e);
		}

		/// <summary>
		///     Raises the <see cref="E:CircuitChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="CircuitEventArgs" /> instance containing the event data.</param>
		internal void OnCircuitChanged(CircuitEventArgs e)
		{
			circuitChangedHandlers?.Invoke(client, e);
		}

		/// <summary>
		///     Raises the <see cref="E:ConfigurationChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="ConfigurationChangedEventArgs" /> instance containing the event data.</param>
		internal void OnConfigurationChanged(ConfigurationChangedEventArgs e)
		{
			configurationChangedHandlers?.Invoke(client, e);
		}

		/// <summary>
		///     Raises the <see cref="E:LogReceived" /> event.
		/// </summary>
		/// <param name="e">The <see cref="LogEventArgs" /> instance containing the event data.</param>
		/// <param name="evt">The event which was processed.</param>
		internal void OnLogReceived(LogEventArgs e, Event evt)
		{
			switch (evt)
			{
				case Event.LogDebug:
					debugReceivedHandlers?.Invoke(client, e);
					break;

				case Event.LogError:
					errorReceivedHandlers?.Invoke(client, e);
					break;

				case Event.LogInfo:
					infoReceivedHandlers?.Invoke(client, e);
					break;

				case Event.LogNotice:
					noticeReceivedHandlers?.Invoke(client, e);
					break;

				case Event.LogWarn:
					warnReceivedHandlers?.Invoke(client, e);
					break;
			}
		}

		/// <summary>
		///     Raises the <see cref="E:ORConnectionChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="ORConnectionEventArgs" /> instance containing the event data.</param>
		internal void OnORConnectionChanged(ORConnectionEventArgs e)
		{
			orConnectionChangedHandlers?.Invoke(client, e);
		}

		/// <summary>
		///     Raises the <see cref="E:StreamChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="StreamEventArgs" /> instance containing the event data.</param>
		internal void OnStreamChanged(StreamEventArgs e)
		{
			streamChangedHandlers?.Invoke(client, e);
		}

		#endregion

		#region System.IDisposable

		/// <inheritdoc />
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

			if (!disposing) return;
			Shutdown();
			disposed = true;
		}

		#endregion

		#region System.Net.Sockets.Socket

		/// <summary>
		///     Called when the socket connects to the control port.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketConnect(IAsyncResult ar)
		{
			try
			{
				socket.EndConnect(ar);

				var authenticate = $"authenticate \"{client.GetControlPassword()}\"{EOL}";
				var authenticateBuffer = Encoding.ASCII.GetBytes(authenticate);

				socket.BeginSend(authenticateBuffer, 0, authenticateBuffer.Length, SocketFlags.None,
					OnSocketSendAuthenticate, null);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     Called when the socket receives a response to the authentication command.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketReceiveAuthenticate(IAsyncResult ar)
		{
			try
			{
				var received = socket.EndReceive(ar);

				if (received <= 0)
					return;

				var response = Encoding.ASCII.GetString(buffer, 0, received);

				if (response.Length < 3 || !response.Substring(0, 3).Equals("250"))
					throw new TorException("The events manager failed to authenticate with the control connection");

				connectCallback?.Invoke();

				SetEvents();
				socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnSocketReceive, null);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     Called when the socket receives data from the control port.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketReceive(IAsyncResult ar)
		{
			try
			{
				var received = socket.EndReceive(ar);

				if (received <= 0)
					return;

				var response = Encoding.ASCII.GetString(buffer, 0, received);
				SetEventResponse(response);

				socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnSocketReceive, null);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     Called when the socket has completed sending the authentication command.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketSendAuthenticate(IAsyncResult ar)
		{
			try
			{
				socket.EndSend(ar);
				socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnSocketReceiveAuthenticate, null);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     Called when the socket completes sending a list of interested events.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketSendEvents(IAsyncResult ar)
		{
			try
			{
				socket.EndSend(ar);
			}
			catch
			{
				// ignored
			}
		}

		#endregion
	}
}