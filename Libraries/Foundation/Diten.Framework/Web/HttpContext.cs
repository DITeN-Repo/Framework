﻿#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:51 AM

#endregion

#region Used Directives

using System.Web;
using Diten.Parameters;

#endregion

namespace Diten.Web
{
	public static class HttpContext
	{
		public static System.Web.HttpContext Current => System.Web.HttpContext.Current;

		public static HttpApplicationState Application => Current.Application;

		/// <summary>
		///    Get client local IP address.
		/// </summary>
		/// <returns>Client local IP address.</returns>
		public static string GetIpAddress()
		{
			var ipAddress = Current.Request.ServerVariables[Constants.Default.ServerVariables000];

			if (string.IsNullOrEmpty(ipAddress))
				return Current.Request.ServerVariables[Constants.Default.ServerVariables001];

			var addresses = ipAddress.Split(',');

			return addresses.Length != 0
				? addresses[0]
				: Current.Request.ServerVariables[Constants.Default.ServerVariables001];
		}
	}
}