#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

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
		public static byte[] ToBytes(this double data)
		{
			return BitConverter.GetBytes(data);
		}
	}
}