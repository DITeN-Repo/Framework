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

using System.IO;

#endregion

namespace Diten
{
	public static class ExUnmanagedMemoryStream
	{
		/// <summary>
		///    Converting <see cref="UnmanagedMemoryStream" /> into <see cref="MemoryStream" />.
		/// </summary>
		/// <param name="value">An <see cref="UnmanagedMemoryStream" />.</param>
		/// <returns>A <see cref="MemoryStream" />.</returns>
		public static MemoryStream ToMemoryStream(this UnmanagedMemoryStream value)
		{
			var holder = new MemoryStream((int) value.Length);
			var buffer1 = new byte[value.Length];
			var buffer2 = new byte[value.Length];

			value.Read(buffer1, 0, (int) value.Length);

			for (var i = 0; i <= buffer1.Length - 1; i++)
				buffer2[i] = buffer1[i];

			holder.Write(buffer2, 0, (int) value.Length);

			return holder;
		}
	}
}