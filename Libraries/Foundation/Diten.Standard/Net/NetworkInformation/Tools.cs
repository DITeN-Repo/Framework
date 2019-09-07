#region DITeN Registration Info

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

#endregion

#region Used Directives

using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Diten.Collections.Generic;
using NetworkInterface = Diten.Management.Hardware.NetworkInterface;

#endregion

namespace Diten.Net.NetworkInformation
{
	public class Tools
	{
		public static List<NetworkInterface> GetNetworkInterfaces() => new NetworkInterface().Touch();

		public static System.Collections.Generic.List<int> GetOccupiedPorts()
		{
			return IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections()
				.Select(tcpi => tcpi.LocalEndPoint.Port).ToList();
		}

		public static PingReply Ping(string destination) =>
			new Ping().Send(destination, 120, Encoding.ASCII.GetBytes(Text.Tools.Repeat("a", 32)),
				new PingOptions {DontFragment = true});
	}
}