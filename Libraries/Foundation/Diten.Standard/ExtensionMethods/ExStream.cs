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

using System.IO;

#endregion

namespace Diten
{
	public static class ExStream
	{
		/// <summary>
		///    Convert an stream to bytes array.
		/// </summary>
		/// <param name="stream">Source stream.</param>
		/// <returns>A bytes array.</returns>
		public static byte[] ToBytes(this Stream stream)
		{
			var holder = new byte[stream.Length];

			stream.Read(holder,
			            0,
			            (int) stream.Length);

			return holder;
		}
	}
}