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
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System.Text;

#endregion

namespace Diten
{
	public static class ExByteArray
	{
		/// <summary>
		///    Converting byte array into string.
		/// </summary>
		/// <param name="value">Data for conversion.</param>
		/// <returns>A string.</returns>
		public static string ToString(this byte[] value) => Encoding.UTF8.GetString(value, 0, value.Length);
	}
}