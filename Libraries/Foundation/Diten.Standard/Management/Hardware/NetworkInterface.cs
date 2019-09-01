#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using Diten.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

#endregion

namespace Diten.Management.Hardware
{
	public class NetworkInterface:Hardware<NetworkInterface>
	{
		public List<GatewayIPAddressInformation> DefaultGateways { get; set; }
		public List<IPAddress> DnsAddresses { get; set; }
		public System.Net.NetworkInformation.NetworkInterface Interface { get; set; }
		public List<IPAddressInformation> IpAddresses { get; set; }
		public string Name { get; set; }

		public new List<NetworkInterface> Touch()
		{
			var _return = new List<NetworkInterface>();

			_return.AddRange(System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
				.ToList()
				.Select(networkInterface => new NetworkInterface
				{
					DefaultGateways=
						new List<GatewayIPAddressInformation>()
							.Cast(networkInterface
								.GetIPProperties().GatewayAddresses
								.ToList()),
					DnsAddresses=
						new List<IPAddress>().Cast(networkInterface
							.GetIPProperties()
							.DnsAddresses
							.ToList()),
					IpAddresses=
						new List<IPAddressInformation>()
							.Cast(networkInterface
								.GetIPProperties().AnycastAddresses
								.ToList()),
					Interface=networkInterface,
					Name=networkInterface.Name
				}));

			return _return;
		}
	}
}