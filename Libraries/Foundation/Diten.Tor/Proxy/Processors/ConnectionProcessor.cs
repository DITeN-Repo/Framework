#region Using Directives

using System;
using System.Net.Sockets;
using System.Text;
using Diten.Tor.Net;

#endregion

namespace Diten.Tor.Proxy
{
	/// <summary>
	///     A class containing the methods and logic needed for routing a HTTP request through a specified SOCKS5 proxy.
	/// </summary>
	internal sealed class ConnectionProcessor : IDisposable
	{
		private readonly Client client;
		private readonly Connection connection;

		private readonly byte[] connectionBuffer;
		private readonly byte[] destinationBuffer;
		private readonly ConnectionProcessorDisposedCallback disposedCallback;
		private readonly object synchronize;
		private ForwardSocket destinationSocket;
		private volatile bool disposed;

		/// <summary>
		///     Initializes a new instance of the <see cref="ConnectionProcessor" /> class.
		/// </summary>
		/// <param name="client">The client hosting the proxy connection.</param>
		/// <param name="connection">The connection associated with the connected client.</param>
		public ConnectionProcessor(Client client, Connection connection,
			ConnectionProcessorDisposedCallback disposedCallback)
		{
			this.client = client;
			this.connection = connection;
			connectionBuffer = new byte[2048];
			destinationBuffer = new byte[2048];
			destinationSocket = null;
			disposed = false;
			this.disposedCallback = disposedCallback;
			synchronize = new object();
		}

		/// <summary>
		///     Starts the process of routing the request by parsing the request information of the client and
		///     creating a destination socket as required.
		/// </summary>
		public void Start()
		{
			if (disposed)
				throw new ObjectDisposedException("this");

			lock (synchronize)
			{
				if (destinationSocket != null)
					return;

				destinationSocket = new ForwardSocket(client);
				destinationSocket.ProxyAddress = client.GetClientAddress();
				destinationSocket.ProxyPort = client.Configuration.SocksPort;

				string proxyConnection;

				if (connection.Headers.TryGetValue("Proxy-Connection", out proxyConnection) &&
				    proxyConnection.Equals("keep-alive", StringComparison.CurrentCultureIgnoreCase))
					destinationSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);

				destinationSocket.BeginConnect(connection.Host, connection.Port, OnSocketConnected, null);
			}
		}

		/// <summary>
		///     Starts the process of routing buffers between the connected client and destination socket.
		/// </summary>
		private void ExchangeBuffers()
		{
			try
			{
				connection.Socket.BeginReceive(connectionBuffer, 0, connectionBuffer.Length, SocketFlags.None,
					OnConnectionSocketReceive, connection.Socket);
				destinationSocket.BeginReceive(destinationBuffer, 0, destinationBuffer.Length, SocketFlags.None,
					OnDestinationSocketReceive, destinationSocket);
			}
			catch (Exception exception)
			{
				throw new TorException(
					"The connection processor could not begin exchanging data between the connection client and destination sockets",
					exception);
			}
		}

		/// <summary>
		///     Shuts down the connection processor by terminating the proxy connection.
		/// </summary>
		public void Shutdown()
		{
			lock (synchronize)
			{
				if (destinationSocket != null)
				{
					try
					{
						destinationSocket.Shutdown(SocketShutdown.Both);
					}
					catch
					{
					}

					destinationSocket.Dispose();
					destinationSocket = null;
				}
			}
		}

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
				Shutdown();
				disposed = true;

				if (disposedCallback != null)
					disposedCallback(this);
			}
		}

		#endregion

		#region System.Net.Sockets.Socket

		/// <summary>
		///     Called when the connected client socket has dispatched data.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnConnectionSocketReceive(IAsyncResult ar)
		{
			try
			{
				if (connection != null && connection.Socket != null)
				{
					var received = connection.Socket.EndReceive(ar);

					if (received > 0)
					{
						if (destinationSocket != null)
							destinationSocket.BeginSend(connectionBuffer, 0, received, SocketFlags.None,
								OnDestinationSocketSent, destinationSocket);

						return;
					}
				}
			}
			catch
			{
			}

			Dispose();
		}

		/// <summary>
		///     Called when the connection client socket has completed sending data.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnConnectionSocketSent(IAsyncResult ar)
		{
			try
			{
				if (connection != null && connection.Socket != null)
				{
					var dispatched = connection.Socket.EndSend(ar);

					if (dispatched > 0)
					{
						if (destinationSocket != null)
							destinationSocket.BeginReceive(destinationBuffer, 0, destinationBuffer.Length,
								SocketFlags.None, OnDestinationSocketReceive, destinationSocket);

						return;
					}
				}
			}
			catch
			{
			}

			Dispose();
		}

		/// <summary>
		///     Called when the forwarding socket has connected to the proxy connection.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnSocketConnected(IAsyncResult result)
		{
			try
			{
				destinationSocket.EndConnect(result);

				if (connection.Method.StartsWith("CONNECT", StringComparison.CurrentCultureIgnoreCase))
				{
					connection.Write("{0} 200 Connection established\r\nProxy-Agent: Tor Socks5 Proxy\r\n\r\n",
						connection.HTTP);
				}
				else
				{
					var header = connection.GetHeader();

					destinationSocket.Send(Encoding.ASCII.GetBytes(header));

					if (connection.Post != null)
						destinationSocket.Send(connection.Post);
				}

				ExchangeBuffers();
			}
			catch (Exception exception)
			{
				throw new TorException("The connection processor failed to finalize instructions", exception);
			}
		}

		/// <summary>
		///     Called when the destination socket has dispatched data.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnDestinationSocketReceive(IAsyncResult result)
		{
			try
			{
				if (destinationSocket != null)
				{
					var received = destinationSocket.EndReceive(result);

					if (received > 0)
					{
						if (connection != null && connection.Socket != null)
							connection.Socket.BeginSend(destinationBuffer, 0, received, SocketFlags.None,
								OnConnectionSocketSent, connection.Socket);

						return;
					}
				}
			}
			catch
			{
			}

			Dispose();
		}

		/// <summary>
		///     Called when the destination socket has completed sending data.
		/// </summary>
		/// <param name="ar">The asynchronous result object for the asynchronous method.</param>
		private void OnDestinationSocketSent(IAsyncResult ar)
		{
			try
			{
				if (destinationSocket != null)
				{
					var dispatched = destinationSocket.EndSend(ar);

					if (dispatched > 0)
					{
						if (connection != null && connection.Socket != null)
							connection.Socket.BeginReceive(connectionBuffer, 0, connectionBuffer.Length,
								SocketFlags.None, OnConnectionSocketReceive, connection.Socket);

						return;
					}
				}
			}
			catch
			{
			}

			Dispose();
		}

		#endregion
	}

	/// <summary>
	///     A delegate event handler representing a method raised when a connection processor is disposed.
	/// </summary>
	/// <param name="processor">The connection processor which was disposed.</param>
	internal delegate void ConnectionProcessorDisposedCallback(ConnectionProcessor processor);
}