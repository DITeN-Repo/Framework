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
// Creation Date: 2019/08/15 8:37 PM

#region Used Directives

using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Diten.Collections.Generic;

#endregion

namespace Diten.Management.Hardware
{
	public class NetworkInterface: Hardware<NetworkInterface>
	{
		/// <summary>
		///    Get or Set Default gateways.
		/// </summary>
		public List<GatewayIPAddressInformation> DefaultGateways {get; set;}

		/// <summary>
		///    Get or Set DNS Addresses.
		/// </summary>
		public List<IPAddress> DnsAddresses {get; set;}

		/// <summary>
		///    Get or Set Interfaces.
		/// </summary>
		public System.Net.NetworkInformation.NetworkInterface Interface {get; set;}

		/// <summary>
		///    Get or Set Ip addresses
		/// </summary>
		public List<IPAddressInformation> IpAddresses {get; set;}

		/// <summary>
		///    Get or Set Name of the network interface.
		/// </summary>
		public new string Name {get; set;}

		/// <summary>
		///    Touching network interface for loading properties values.
		/// </summary>
		/// <returns>A list of available network adapters.</returns>
		public new static List<NetworkInterface> Touch()
		{
			return new List<NetworkInterface>().AddRange(System.Net.NetworkInformation.NetworkInterface
			                                                   .GetAllNetworkInterfaces()
			                                                   .ToList()
			                                                   .Select(networkInterface => new NetworkInterface
			                                                   {
				                                                   DefaultGateways =
					                                                   new List<GatewayIPAddressInformation>()
						                                                   .Cast(networkInterface
						                                                         .GetIPProperties()
						                                                         .GatewayAddresses
						                                                         .ToList()),
				                                                   DnsAddresses =
					                                                   new List<IPAddress>().Cast(networkInterface
					                                                                              .GetIPProperties()
					                                                                              .DnsAddresses
					                                                                              .ToList()),
				                                                   IpAddresses =
					                                                   new List<IPAddressInformation>()
						                                                   .Cast(networkInterface
						                                                         .GetIPProperties()
						                                                         .AnycastAddresses
						                                                         .ToList()),
				                                                   Interface = networkInterface,
				                                                   Name = networkInterface.Name
			                                                   }));
		}
	}
}