#region DITeN Registration Info

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
		public static string ToString(this byte[] value)
		{
			return Encoding.UTF8.GetString(value, 0, value.Length);
		}
	}
}