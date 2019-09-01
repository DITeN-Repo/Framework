#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

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

			stream.Read(holder, 0, (int)stream.Length);

			return holder;
		}
	}
}