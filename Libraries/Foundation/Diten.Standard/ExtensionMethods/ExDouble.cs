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
// Creation Date: 2019/08/15 4:42 PM

#region Used Directives

using System;

#endregion

namespace Diten
{
	public static class ExDouble
	{
		/// <summary>
		///    Converting double into byte array.
		/// </summary>
		/// <param name="data">Data for conversion.</param>
		/// <returns>A byte array.</returns>
		public static byte[] ToBytes(this double data) { return BitConverter.GetBytes(data); }
	}
}