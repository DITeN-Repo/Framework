#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:07 AM

#endregion

#region Used Directives

using Diten.Net.NetworkInformation;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

#endregion

namespace Diten.Sockets
{
	/// <inheritdoc />
	// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
	public class Synchronous:Socket
	{
		// ReSharper disable once UnusedMember.Local
		private int[] _officialPorts =
		{
			0,
			1,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			25,
			26,
			37,
			38,
			39,
			40,
			42,
			43,
			49,
			50,
			51,
			52,
			53,
			54,
			56,
			57,
			58,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			77,
			79,
			80,
			81,
			87,
			88,
			90,
			100,
			101,
			102,
			104,
			105,
			107,
			108,
			109,
			110,
			111,
			113,
			113,
			114,
			115,
			117,
			118,
			119,
			123,
			126,
			135,
			135,
			137,
			138,
			139,
			143,
			152,
			153,
			156,
			158,
			161,
			162,
			170,
			177,
			179,
			194,
			199,
			201,
			209,
			210,
			213,
			218,
			220,
			259,
			262,
			264,
			280,
			308,
			311,
			318,
			319,
			320,
			350,
			351,
			356,
			366,
			369,
			370,
			371,
			383,
			384,
			387,
			389,
			399,
			401,
			427,
			433,
			434,
			443,
			444,
			445,
			464,
			465,
			475,
			497,
			500,
			502,
			504,
			510,
			512,
			513,
			514,
			515,
			517,
			518,
			520,
			520,
			521,
			524,
			525,
			530,
			532,
			533,
			540,
			542,
			543,
			544,
			546,
			547,
			548,
			550,
			554,
			556,
			560,
			561,
			563,
			585,
			587,
			591,
			593,
			601,
			604,
			623,
			631,
			635,
			636,
			639,
			641,
			643,
			646,
			647,
			648,
			651,
			653,
			654,
			655,
			657,
			660,
			666,
			674,
			688,
			690,
			691,
			694,
			695,
			698,
			700,
			701,
			702,
			706,
			711,
			712,
			749,
			750,
			753,
			753,
			754,
			754,
			800,
			830,
			831,
			832,
			833,
			847,
			848,
			853,
			860,
			861,
			862,
			873,
			953,
			954,
			955,
			956, 957, 958, 959, 960, 961, 962, 963, 964, 965, 966, 967, 968, 969, 970, 971, 972, 973, 974, 975, 976,
			977, 978, 979, 980, 981, 982, 983, 984, 985, 986, 987, 988,
			989,
			990,
			991,
			992,
			993,
			994,
			995,
			1023,
			6445,
			6513,
			6514,
			6515,
			6566,
			6600,
			6601,
			6602,
			6619,
			6622,
			6653,
			6665, 6666, 6667, 6668, 6669,
			6679,
			6697,
			6888,
			6969,
			7023,
			7262,
			7272,
			7400,
			7401,
			7402,
			7473,
			7474,
			7478,
			7542,
			7547,
			7624,
			7631,
			7687,
			8008,
			8074,
			8080,
			8118,
			8123,
			8140,
			8194,
			8243,
			8280,
			8880,
			8883,
			9001,
			9006,
			9080,
			9100,
			9101,
			9102,
			9103,
			9119,
			9306,
			9312,
			9389,
			9418,
			9535,
			9536,
			9695,
			9800,
			9899,
			10000,
			10010,
			10050,
			10051,
			10110,
			10212,
			10933,
			11001,
			11060,
			11061,
			11112,
			11371,
			12222,
			12223,
			13075,
			13720,
			13721,
			13724,
			13782,
			13783,
			13785,
			13786,
			15345,
			16482,
			17500,
			18104,
			19283,
			19315,
			19812,
			19813,
			19814,
			19999,
			20000,
			24465,
			24554,
			25000,
			25001,
			25003,
			25005,
			25007,
			25010,
			26000,
			27000, 27001, 27002, 27003, 27004, 27005, 27006, 27007, 27008, 27009,
			31457,
			32400,
			33434,
			35357,
			40000,
			44818,
			47001,
			47808,
			49151
		};

		public Synchronous(IPAddress serverIp,
			int port,
			Condition condition) : base(AddressFamily.InterNetwork,
			SocketType.Stream,
			ProtocolType.Tcp)
		{
			Response=new Byte();

			var iPEndPoint = new IPEndPoint(serverIp, port);

			switch(condition)
			{
				case Condition.Send:
					Connect(iPEndPoint);

					break;
				case Condition.Receive:
					Bind(iPEndPoint);
					Listen(10);

					break;
				default:

					throw new ArgumentOutOfRangeException(nameof(condition), condition, null);
			}
		}

		public Synchronous(string serverUrl,
			int port,
			Condition condition) : this(
			Tools.Ping(serverUrl).Address, port, condition)
		{
		}

		public Byte Response { get; }

		public new void Dispose()
		{
			Release();
			base.Dispose();
		}

		public void Listen()
		{
			// Start listening for connections.  
			while(true)
			{
				var handler = Accept();

				while(true)
				{
					var bytes = new byte[1024];
					var bytesRec = handler.Receive(bytes);

					Response.Append(bytes);

					if(Encoding.ASCII.GetString(bytes, 0, bytesRec)
							 .IndexOf(Char.ReservedChars.EndOfMedium.ToChar().ToString(), StringComparison.Ordinal)<=
						 -1)
						continue;

					break;
				}

				OnReceiveDone(new ReceiveDoneEventArgs(Response));

				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}

			// ReSharper disable once FunctionNeverReturns
		}

		/// <summary>
		///    On receive-done event handler.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnReceiveDone(ReceiveDoneEventArgs e)
		{
			var handler = ReceiveDone;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///    ReceiveDone event handler.
		/// </summary>
		public event EventHandler<ReceiveDoneEventArgs> ReceiveDone;

		public bool Release()
		{
			try
			{
				Shutdown(SocketShutdown.Both);
				Close();

				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		public new void Send(byte[] buffer)
		{
			// Sending length of buffer
			var holder = new Byte(buffer);
			holder.Append(Char.ReservedChars.EndOfMedium.ToChar().ToString());
			base.Send(holder.Value);
		}

		public class ReceiveDoneEventArgs
		{
			public ReceiveDoneEventArgs(Byte response)
			{
				Response=response;
			}

			public Byte Response { get; set; }
		}
	}
}