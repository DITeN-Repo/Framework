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
// Creation Date: 2019/08/16 12:20 AM

#region Used Directives

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

#endregion

namespace Diten.Net
{
	/// <summary>
	///    A component which provides network route tracing functionality similar to tracert.exe
	/// </summary>
	public class Tracert
	{
		private static byte[] _buffer;

		public Tracert(string hostNameOrAddress)
		{
			HostNameOrAddress = hostNameOrAddress;
			TimeOut = 5000; //Default timeout of Ping
			_ping = new Ping();
			_ping.PingCompleted += Ping_OnPingCompleted;
		}

		private static byte[] Buffer
		{
			get
			{
				if (_buffer != null) return _buffer;
				_buffer = new byte[32];
				for (var i = 0;
				     i < Buffer.Length;
				     i++) _buffer[i] = 0x65;

				return _buffer;
			}
		}

		/// <summary>
		///    The host name or address of the destination node
		/// </summary>
		public string HostNameOrAddress {get;}

		/// <summary>
		///    Indicates whether the route tracing is complete
		/// </summary>
		public bool IsDone
		{
			get => _isDone;
			private set
			{
				_isDone = value;

				if (value && OnDone != null)
					OnDone(this,
					       EventArgs.Empty);

				if (_isDone) Dispose();
			}
		}

		public int MaxHops {get; set;} = 30;

		/// <summary>
		///    The list of nodes in the route
		/// </summary>
		public TracertNode[] Nodes
		{
			get
			{
				lock (_nodes) { return _nodes.ToArray(); }
			}
		}

		/// <summary>
		///    The maximum amount of time to wait for the Ping request to an intermediate node
		/// </summary>
		public int TimeOut {get; set;}

		private IPAddress _destination;
		private bool _isDone;
		private List<TracertNode> _nodes;
		private PingOptions _options;
		private Ping _ping;

		public void Dispose()
		{
			lock (this)
			{
				if (_ping == null) return;
				_ping.Dispose();
				_ping = null;
			}
		}

		/// <summary>
		///    Fires when route tracing is done
		/// </summary>
		public event EventHandler OnDone;

		/// <summary>
		///    Fires when a node is found in the route
		/// </summary>
		public event EventHandler<RouteNodeFoundEventArgs> OnRouteNodeFound;

		private void Ping_OnPingCompleted(object sender,
		                                  PingCompletedEventArgs e)
		{
			ProcessNode(e.Reply.Address,
			            e.Reply.Status);

			_options.Ttl += 1;

			if (IsDone) return;

			lock (this)
				//The expectation was that SendAsync will throw an exception
			{
				if (_ping == null)
					ProcessNode(_destination,
					            IPStatus.Unknown);
				else
					_ping.SendAsync(_destination,
					                TimeOut,
					                Buffer,
					                _options,
					                null);
			}
		}

		protected void ProcessNode(IPAddress address,
		                           IPStatus status)
		{
			long roundTripTime = 0;

			if (status == IPStatus.TtlExpired ||
			    status == IPStatus.Success)
			{
				var pingIntermediate = new Ping();

				try
				{
					//Compute roundtrip time to the address by pinging it
					var reply = pingIntermediate.Send(address,
					                                  TimeOut);

					if (reply != null)
					{
						roundTripTime = reply.RoundtripTime;
						status = reply.Status;
					}
				}
				finally { pingIntermediate.Dispose(); }
			}

			var node = new TracertNode(address,
			                           roundTripTime,
			                           status);

			lock (_nodes) { _nodes.Add(node); }

			OnRouteNodeFound?.Invoke(this,
			                         new RouteNodeFoundEventArgs(node,
			                                                     IsDone));

			IsDone = address.Equals(_destination);

			lock (_nodes)
			{
				if (!IsDone &&
				    _nodes.Count >= MaxHops - 1)
					ProcessNode(_destination,
					            IPStatus.Success);
			}
		}

		/// <summary>
		///    Starts the route tracing process. The HostNameOrAddress field should already be set
		/// </summary>
		public void Trace()
		{
			//if (_ping != null)
			//    throw new InvalidOperationException("This object is already in use");
			//ToDo: Check The code.
			_nodes = new List<TracertNode>();
			_destination = System.Net.Dns.GetHostEntry(HostNameOrAddress).AddressList[0];

			if (IPAddress.IsLoopback(_destination))
			{
				ProcessNode(_destination,
				            IPStatus.Success);
			}
			else
			{
				_options = new PingOptions(1,
				                           true);

				lock (_ping)
				{
					_ping.SendAsync(_destination,
					                TimeOut,
					                Buffer,
					                _options);
				}
			}

			var gg =
				"This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an authoritative server.";
		}
	}
}