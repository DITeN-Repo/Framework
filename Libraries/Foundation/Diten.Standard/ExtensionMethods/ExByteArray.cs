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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Diten.Security.Cryptography;

#endregion

namespace Diten
{
	public static class ExByteArray
	{
		/// <summary>
		///    Append bytes in <see cref="IEnumerable{T}" /> into current byte array.
		/// </summary>
		/// <param name="value">Current byte array.</param>
		/// <param name="buffer">Bytes that must be appended into current byte array.</param>
		/// <returns>A byte array.</returns>
		public static byte[] Append(this byte[] value,
		                            IEnumerable<byte> buffer)
		{
			foreach (var b in buffer) value.Append(b);

			return value;
		}

		public static string ToBase64Text(this byte[] value)
		{
			using (var memoryStream = new MemoryStream(value)) { return Base64Text.Encrypt(memoryStream); }
		}

		/// <summary>
		///    Converting into <see cref="Byte" />
		/// </summary>
		/// <param name="value">The <see cref="byte" /> array that must be converted.</param>
		/// <returns>A <see cref="Byte" />.</returns>
		public static Byte ToByte(this byte[] value) { return new Byte(value); }

		/// <summary>
		///    Converting a byte array into hexadecimal.
		/// </summary>
		/// <param name="value">Integer number.</param>
		/// <returns>A hexadecimal number.</returns>
		public static string ToHex(this IEnumerable<byte> value)
		{
			return value.Aggregate(string.Empty,
			                       (current,
			                        b) => current +
			                              BitConverter.ToInt32(b.ToBytes(),
			                                                   0)
			                                          .ToHexadecimal());
		}

		/// <inheritdoc cref="BitConverter.ToInt16" />
		public static short ToInt16(this byte[] value)
		{
			return BitConverter.ToInt16(value,
			                            0);
		}

		/// <inheritdoc cref="BitConverter.ToInt32" />
		public static int ToInt32(this byte[] value)
		{
			return BitConverter.ToInt32(value,
			                            0);
		}

		/// <inheritdoc cref="BitConverter.ToInt64" />
		public static long ToInt64(this byte[] value)
		{
			return BitConverter.ToInt64(value,
			                            0);
		}

		/// <summary>
		///    Converting byte array into string.
		/// </summary>
		/// <param name="value">Data for conversion.</param>
		/// <returns>A string.</returns>
		public static string ToString(this byte[] value)
		{
			return Encoding.UTF8.GetString(value,
			                               0,
			                               value.Length);
		}
	}
}