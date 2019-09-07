#region Using Directives

using System;
using System.Net;

#endregion

namespace Diten.Tor.Proxy
{
	/// <summary>
	///     A class which implements the <see cref="IWebProxy" /> interface to provide routing of HTTP requests.
	/// </summary>
	public sealed class Socks5Proxy : IWebProxy
	{
		private readonly Client client;

		/// <summary>
		///     Initializes a new instance of the <see cref="Socks5Proxy" /> class.
		/// </summary>
		/// <param name="client">The client for which this object instance belongs.</param>
		internal Socks5Proxy(Client client)
		{
			this.client = client;
		}

		#region Properties

		/// <summary>
		///     The credentials to submit to the proxy server for authentication.
		/// </summary>
		public ICredentials Credentials { get; set; }

		#endregion

		/// <summary>
		///     Returns the URI of a proxy.
		/// </summary>
		/// <param name="destination">A <see cref="T:System.Uri" /> that specifies the requested Internet resource.</param>
		/// <returns>
		///     A <see cref="T:System.Uri" /> instance that contains the URI of the proxy used to contact
		///     <paramref name="destination" />.
		/// </returns>
		public Uri GetProxy(Uri destination)
		{
			return new Uri($"http://127.0.0.1:{client.Proxy.Port}");
		}

		/// <summary>
		///     Indicates that the proxy should not be used for the specified host.
		/// </summary>
		/// <param name="host">The <see cref="T:System.Uri" /> of the host to check for proxy use.</param>
		/// <returns>
		///     true if the proxy server should not be used for <paramref name="host" />; otherwise, false.
		/// </returns>
		public bool IsBypassed(Uri host)
		{
			return client.Proxy.IsRunning;
		}
	}
}