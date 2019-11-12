// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:07 AM

#region Used Directives

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Diten.Net.NetworkInformation;

#endregion

namespace Diten.Sockets
{
	public class Asynchronous: Socket
	{
		internal class StateObject
		{
			public const int BufferSize = 1024;

			public StateObject() { Buffer = new byte[BufferSize]; }

			public byte[] Buffer {get; set;}

			public Socket WorkSocket {get; set;}
		}

		public Asynchronous(IPAddress serverIp,
		                    int port,
		                    Condition condition): base(AddressFamily.InterNetwork,
		                                               SocketType.Stream,
		                                               ProtocolType.Tcp)
		{
			Response = new Byte();
			_allDone = new ManualResetEvent(false);
			_connectDone = new ManualResetEvent(false);
			_sendDone = new ManualResetEvent(false);
			_receiveDone = new ManualResetEvent(false);

			var iPEndPoint = new IPEndPoint(serverIp,
			                                port);

			switch (condition)
			{
				case Condition.Send:
					BeginConnect(iPEndPoint,
					             ConnectCallback,
					             this);

					break;
				case Condition.Receive:
					Bind(iPEndPoint);
					Listen(100);

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(condition),
					                                      condition,
					                                      null);
			}
		}

		public Asynchronous(System.String serverUrl,
		                    int port,
		                    Condition condition): this(
		                                               Tools.Ping(serverUrl).Address,
		                                               port,
		                                               condition) {}

		// ReSharper disable once MemberCanBePrivate.Global
		public Byte Response {get;}

		public Boolean Sleep {get; set;} = false;
		public Boolean StopListening {get; set;} = false;
		private readonly ManualResetEvent _allDone;
		private readonly ManualResetEvent _connectDone;
		private readonly ManualResetEvent _receiveDone;
		private readonly ManualResetEvent _sendDone;

		private void AcceptCallback(IAsyncResult ar)
		{
			var handler = ((Socket) ar.AsyncState).EndAccept(ar);
			var state = new StateObject {WorkSocket = handler};

			handler.BeginReceive(state.Buffer,
			                     0,
			                     StateObject.BufferSize,
			                     0,
			                     ReadCallback,
			                     state);
		}

		private void ConnectCallback(IAsyncResult ar)
		{
			((Socket) ar.AsyncState).EndConnect(ar);
			_connectDone.Set();
		}

		public new void Dispose()
		{
			Release();
			base.Dispose();
		}

		public void Listen()
		{
			while (!StopListening)
				while (!Sleep)
				{
					_allDone.Reset();
					BeginAccept(AcceptCallback,
					            this);
					_allDone.WaitOne();
				}
		}

		private void ReadCallback(IAsyncResult ar)
		{
			var state = (StateObject) ar.AsyncState;
			var handler = state.WorkSocket;
			var bytesRead = handler.EndReceive(ar);

			if (bytesRead > 0) Response.Append(state.Buffer);

			if (!Encoding.ASCII.GetString(Response.Value).Contains(Char.ReservedChars.EndOfMedium.ToChar().ToString()))
				handler.BeginReceive(state.Buffer,
				                     0,
				                     StateObject.BufferSize,
				                     0,
				                     ReadCallback,
				                     state);

			Response.RemoveEOF();
		}

		public void Receive()
		{
			var state = new StateObject {WorkSocket = this};
			BeginReceive(state.Buffer,
			             0,
			             StateObject.BufferSize,
			             0,
			             ReceiveCallback,
			             state);
		}

		private void ReceiveCallback(IAsyncResult ar)
		{
			var state = (StateObject) ar.AsyncState;
			var client = state.WorkSocket;
			var bytesRead = client.EndReceive(ar);

			if (bytesRead > 0)
			{
				Response.Append(state.Buffer);
				client.BeginReceive(state.Buffer,
				                    0,
				                    StateObject.BufferSize,
				                    0,
				                    ReceiveCallback,
				                    state);
			}
			else { _receiveDone.Set(); }
		}

		public Boolean Release()
		{
			try
			{
				Shutdown(SocketShutdown.Both);
				Close();

				return true;
			}
			catch (Exception) { return false; }
		}

		public new void Send(byte[] buffer)
		{
			var holder = new Byte(buffer);
			holder.Append(Char.ReservedChars.EndOfMedium.ToChar().ToString());
			BeginSend(holder.Value,
			          0,
			          holder.Value.Length,
			          SocketFlags.None,
			          SendCallback,
			          this);
		}

		private void SendCallback(IAsyncResult ar)
		{
			((Socket) ar.AsyncState).EndSend(ar);
			_sendDone.Set();
		}
	}
}