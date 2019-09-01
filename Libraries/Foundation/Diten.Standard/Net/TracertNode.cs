#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:20 AM

#endregion

#region Used Directives

using System.Net;
using System.Net.NetworkInformation;

#endregion

namespace Diten.Net
{
	/// <summary>
	///    Contains data about a node encountered using Tracert
	/// </summary>
	public class TracertNode
	{
		/// <summary>
		///    Constructs a new object from the IPAddress of the node and the round trip time taken
		/// </summary>
		/// <param name="address">Address to trace.</param>
		/// <param name="roundTripTime">Round trip time.</param>
		/// <param name="status">IP Status.</param>
		internal TracertNode(IPAddress address,
			long roundTripTime,
			IPStatus status)
		{
			Address=address;
			RoundTripTime=roundTripTime;
			Status=status;
		}

		/// <summary>
		///    The IPAddress of the node
		/// </summary>
		public IPAddress Address { get; }

		/// <summary>
		///    The time taken to go to the node and come back to the originating node in milliseconds.
		/// </summary>
		public long RoundTripTime { get; }

		/// <summary>
		///    The IPStatus of request send to the node
		/// </summary>
		public IPStatus Status { get; }
	}
}