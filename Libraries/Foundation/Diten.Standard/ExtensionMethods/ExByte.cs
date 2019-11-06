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

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Diten
{
	public static class ExByte
	{
		///// <summary>
		///// Converting a <see cref="byte"/> into <see cref="bool"/>s (bits).
		///// </summary>
		///// <param name="value">A <see cref="byte"/> that represent source of <see cref="bool"/>s (bits).</param>
		///// <returns>An <see cref="System.Array"/> of <see cref="bool"/>s (bits).</returns>
		//public static bool[] ToBits(this byte value)
		//{
		//	var holder = (int) value;
		//	var baseChars = new[] {true, false};
		//	var result = new List<bool>();
		//	var baseCharsLength = baseChars.Length;

		//	do
		//	{
		//		result.Add(baseChars[value % baseCharsLength]);
		//		holder /= baseCharsLength;
		//	} while (holder > 0);

		//	return result.ToArray();
		//}

		/// <summary>
		///    Converting a <see cref="byte" /> into <see cref="bool" />s (bits).
		/// </summary>
		/// <param name="value">A <see cref="byte" /> that represent source of <see cref="bool" />s (bits).</param>
		/// <returns>An <see cref="System.Array" /> of <see cref="bool" />s (bits).</returns>
		public static BitArray ToBitArray(this byte value) { return new BitArray(value); }

		/// <summary>
		///    Converting an <see cref="IEnumerable{T}" /> of <see cref="byte" /> into <see cref="List{T}" /> of
		///    <see cref="bool" />s (bits).
		/// </summary>
		/// <param name="value">
		///    An <see cref="IEnumerable{T}" /> of <see cref="byte" /> that represent source <see cref="bool" />s
		///    bits.
		/// </param>
		/// <returns>An <see cref="System.Array" /> of <see cref="bool" />s bits.</returns>
		public static BitArray ToBits(this IEnumerable<byte> value) { return new BitArray(value.ToBytes()); }
	}
}