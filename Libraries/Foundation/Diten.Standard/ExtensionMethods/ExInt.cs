#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Numeric;
using System;
using System.Net;

#endregion

namespace Diten
{
	public static class ExInt
	{
		/// <summary>
		///    Converting integer address into IP address.
		/// </summary>
		/// <param name="value">An <see cref="int" />
		///    <para>value</para>
		///    that must be converted.
		/// </param>
		/// <returns>IP address.</returns>
		public static IPAddress ToIpAddress(this int value)
		{
			return new IPAddress(ToBytes(value));
		}


		/// <summary>
		///    Converting <see cref="int" /> into <see cref="byte" /> <see cref="Array" />.
		/// </summary>
		/// <param name="value">An <see cref="int" />
		///    <para>value</para>
		///    that must be converted.
		/// </param>
		/// <returns>An <see cref="Array" /> of <see cref="byte" /></returns>
		public static byte[] ToBytes(this int value)
		{
			return BitConverter.GetBytes(value);
		}

		/// <summary>
		///    Convert to vigesimal (base 26, A-Z).
		/// </summary>
		/// <param name="value">Integer value.</param>
		/// <returns>A string that contains a vigesimal string.</returns>
		public static string ToVigesimal(this int value)
		{
			return ToString(value, Vigesimal.Characters.ToArray());
		}

		/// <summary>
		///    Convert to vigesimal (base 26, A-Z).
		/// </summary>
		/// <param name="value">Integer value.</param>
		/// <returns>A string that contains a vigesimal string.</returns>
		public static string ToDuosexagesimal(this int value)
		{
			return ToString(value, Duosexagesimal.Characters.ToArray());
		}


		/// <summary>
		///    Converting integer into hexadecimal.
		/// </summary>
		/// <param name="value">Integer number.</param>
		/// <returns>A hexadecimal number.</returns>
		public static string ToHexadecimal(this int value)
		{
			return value.ToString("X");
		}


		/// <summary>
		///    Convert to sexagesimal (base 64, A-Z, a-z, 0-9).
		/// </summary>
		/// <param name="value">Integer value.</param>
		/// <returns>A string that contains a sexagesimal string.</returns>
		public static string ToSexagesimal(this int value)
		{
			return ToString(value);
		}

		/// <summary>
		///    Convert an <see cref="int" /> to <see cref="string" />.
		/// </summary>
		/// <param name="value"><see cref="int" /> value.</param>
		/// <param name="baseChars">Characters that must be used in conversion.</param>
		/// <returns>A <see cref="string" /> that represented by <see cref="int" />
		///    <para>value</para>
		///    .
		/// </returns>
		public static string ToString(this int value, char[] baseChars)
		{
			var result = string.Empty;
			var baseCharsLength = baseChars.Length;

			do
			{
				result=baseChars[value%baseCharsLength]+result;
				value/=baseCharsLength;
			} while(value>0);

			return result;
		}

		/// <summary>
		///    Convert an <see cref="int" /> to <see cref="string" />.
		/// </summary>
		/// <param name="value"><see cref="int" /> value.</param>
		/// <returns>A <see cref="string" /> that represented by <see cref="int" />
		///    <para>value</para>
		///    .
		/// </returns>
		public static string ToString(this int value)
		{
			return ToString(value, Duosexagesimal.Characters.ToArray());
		}

		/// <summary>
		///    Convert an integer to string.
		///    An optimized method using an array as buffer instead of
		///    string concatenation. This is faster for return values having
		///    a length > 1.
		/// </summary>
		/// <param name="value">Integer value.</param>
		/// <param name="baseChars">Characters that must be used in conversion.</param>
		/// <returns>A string that contains a integer string.</returns>
		public static string ToStringFast(this int value, char[] baseChars)
		{
			// 32 is the worst cast buffer size for base 2 and int.MaxValue
			var i = 32;
			var buffer = new char[i];
			var targetBase = baseChars.Length;

			do
			{
				buffer[--i]=baseChars[value%targetBase];
				value/=targetBase;
			} while(value>0);

			var result = new char[32-i];
			Array.Copy(buffer, i, result, 0, 32-i);

			return new string(result);
		}
	}
}