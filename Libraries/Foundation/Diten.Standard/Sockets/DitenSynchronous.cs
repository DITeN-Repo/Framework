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

namespace Diten.Sockets
{
	public class DitenSynchronous
	{
		// ReSharper disable once EmptyConstructor
		public DitenSynchronous()
		{
			//todo: Check for error. Must be checked because servers list must be synchronized dynamically.
			//ReceiveSocket = new Synchronous(Constants.Diten.ServicesServer,
			//	Constants.Default.ClientTalkingServicePort, Condition.Receive);
			//SendSocket = new Synchronous(Constants.Diten.ServicesServer,
			//	Constants.Default.ClientListeningServicePort, Condition.Send);
		}

		private Synchronous ReceiveSocket {get;}
		private Synchronous SendSocket {get;}

		public void Dispose()
		{
			SendSocket.Dispose();
			ReceiveSocket.Dispose();
		}

		public Byte Receive()
		{
			var _return = new Byte();
			var buffer = new byte[1024];

			while (true)
			{
				if (ReceiveSocket.Receive(buffer) == 0) continue;

				_return.Append(buffer);

				if (!_return.HasEOF()) continue;

				return _return;
			}
		}

		public void Release()
		{
			ReceiveSocket.Release();
			SendSocket.Release();
		}

		public void Send(Byte data) { SendSocket.Send(data.Value); }
	}
}