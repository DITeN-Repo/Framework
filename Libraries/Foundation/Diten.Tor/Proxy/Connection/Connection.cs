#region Using Directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

#endregion

namespace Diten.Tor.Proxy
{
	/// <summary>
	///     A class containing a reference to a connection proxy client.
	/// </summary>
	internal sealed class Connection : IDisposable
	{
		private readonly Client client;
		private readonly ConnectionDisposedCallback disposedCallback;

		private volatile bool disposed;

		/// <summary>
		///     Initializes a new instance of the <see cref="Connection" /> class.
		/// </summary>
		/// <param name="client">The client hosting the proxy .</param>
		/// <param name="socket">The socket belonging to the connection.</param>
		/// <param name="disposeCallback">A callback method raised when the connection is disposed.</param>
		public Connection(Client client, Socket socket, ConnectionDisposedCallback disposeCallback)
		{
			this.client = client;
			disposed = false;
			disposedCallback = disposeCallback;
			Headers = null;
			Host = null;
			HTTP = "HTTP/1.1";
			Method = null;
			Port = 80;
			Post = null;
			Socket = socket;

			GetHeaderData();
		}

		/// <summary>
		///     Gets the header block which was dispatched with the original socket request.
		/// </summary>
		/// <returns>A <see cref="System.String" /> containing the header data.</returns>
		public string GetHeader()
		{
			var header = new StringBuilder();

			header.Append(Method);
			header.Append("\r\n");

			foreach (var value in Headers)
			{
				if (value.Key.StartsWith("proxy", StringComparison.CurrentCultureIgnoreCase))
					continue;

				header.AppendFormat("{0}: {1}\r\n", value.Key, value.Value);
			}

			return header.Append("\r\n").ToString();
		}

		/// <summary>
		///     Process the connection request by reading the header information from the HTTP request, and connecting to the tor
		///     server
		///     and dispatching the request to the relevant host.
		/// </summary>
		private void GetHeaderData()
		{
			try
			{
				var builder = new StringBuilder();

				using (var reader = new StreamReader(new NetworkStream(Socket, false)))
				{
					for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
					{
						builder.Append(line);
						builder.Append("\r\n");

						if (line.Trim().Length == 0)
							break;
					}
				}

				using (var reader = new StringReader(builder.ToString()))
				{
					Method = reader.ReadLine();

					if (Method == null)
						throw new InvalidOperationException("The proxy connection did not supply a valid HTTP header");

					Headers = new Dictionary<string, string>();

					for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
					{
						var trimmed = line.Trim();

						if (trimmed.Length == 0)
							break;

						var parts = trimmed.Split(new[] {':'}, 2);

						if (parts.Length == 1)
							continue;

						Headers[parts[0].Trim()] = parts[1].Trim();
					}

					if (Method.StartsWith("POST", StringComparison.CurrentCultureIgnoreCase))
					{
						if (!Headers.ContainsKey("Content-Length"))
							throw new InvalidOperationException(
								"The proxy connection is a POST method but contains no content length");

						var contentLength = long.Parse(Headers["Content-Length"]);

						using (var memory = new MemoryStream())
						{
							long read = 0;
							var buffer = new byte[512];

							while (contentLength > read)
							{
								var received = Socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);

								if (received <= 0)
									throw new InvalidOperationException(
										"The proxy connection was terminated while reading POST data");

								memory.Write(buffer, 0, received);
								read += received;
							}

							Post = memory.ToArray();
						}
					}

					if (Method.StartsWith("CONNECT", StringComparison.CurrentCultureIgnoreCase))
					{
						var connectTargets = Method.Split(' ');

						if (connectTargets.Length < 3)
							throw new InvalidOperationException(
								"The proxy connection supplied a CONNECT command with insufficient parameters");

						HTTP = connectTargets[2];

						var connectTarget = connectTargets[1];
						var connectParams = connectTarget.Split(':');

						if (connectParams.Length == 2)
						{
							Host = connectParams[0];
							Port = int.Parse(connectParams[1]);
						}
						else
						{
							Host = connectParams[0];
							Port = 443;
						}
					}
					else
					{
						if (!Headers.ContainsKey("Host"))
							throw new InvalidOperationException(
								"The proxy connection did not supply a connection host");

						var connectTarget = Headers["Host"];
						var connectParams = connectTarget.Split(':');

						if (connectParams.Length == 1)
						{
							Host = connectParams[0];
						}
						else
						{
							Host = connectParams[0];
							Port = int.Parse(connectParams[1]);
						}
					}
				}
			}
			catch (Exception exception)
			{
				throw new TorException("The proxy connection failed to process", exception);
			}
		}

		/// <summary>
		///     Writes a buffer of data to the connected client socket.
		/// </summary>
		/// <param name="data">The data to send to the client socket.</param>
		public void Write(string data)
		{
			Write(Encoding.ASCII.GetBytes(data));
		}

		/// <summary>
		///     Writes a buffer of data to the connected client socket.
		/// </summary>
		/// <param name="data">The data to send to the client socket.</param>
		/// <param name="parameters">An optional list of parameters to format into the data.</param>
		public void Write(string data, params object[] parameters)
		{
			data = string.Format(data, parameters);
			Write(Encoding.ASCII.GetBytes(data));
		}

		/// <summary>
		///     Writes a buffer of data to the connected client socket.
		/// </summary>
		/// <param name="buffer">The data to send to the client socket.</param>
		public void Write(byte[] buffer)
		{
			Socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
		}

		#region Properties

		/// <summary>
		///     Gets the header values provided with the request.
		/// </summary>
		public Dictionary<string, string> Headers { get; private set; }

		/// <summary>
		///     Gets the target host of the HTTP request.
		/// </summary>
		public string Host { get; private set; }

		/// <summary>
		///     Gets the HTTP version sent with the request.
		/// </summary>
		public string HTTP { get; private set; }

		/// <summary>
		///     Gets the method requested for the HTTP request (GET, POST, PUT, DELETE, CONNECT).
		/// </summary>
		public string Method { get; private set; }

		/// <summary>
		///     Gets the target port number of the HTTP request.
		/// </summary>
		public int Port { get; private set; }

		/// <summary>
		///     Gets the POST data.
		/// </summary>
		public byte[] Post { get; private set; }

		/// <summary>
		///     Gets the socket connected to the proxy client.
		/// </summary>
		public Socket Socket { get; private set; }

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
				if (Socket != null)
				{
					try
					{
						Socket.Shutdown(SocketShutdown.Both);
					}
					catch
					{
					}

					Socket.Dispose();
					Socket = null;
				}

				disposed = true;

				if (disposedCallback != null)
					disposedCallback(this);
			}
		}

		#endregion
	}

	/// <summary>
	///     A delegate event handler representing a method raised when a connection is disposed.
	/// </summary>
	/// <param name="connection">The connection which was disposed.</param>
	internal delegate void ConnectionDisposedCallback(Connection connection);
}