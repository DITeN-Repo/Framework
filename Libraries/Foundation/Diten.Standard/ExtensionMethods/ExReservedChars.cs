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

#endregion

namespace Diten
{
	public static class ExReservedChars
	{
		/// <summary>
		///    Converting <see cref="Char.ReservedChars" /> value in to extended ascii character.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into extended ascii character.</param>
		/// <returns>An extended ascii character.</returns>
		public static char ToChar(this Char.ReservedChars value) { return (char) value; }

		/// <summary>
		///    Converting <see cref="Char.ReservedChars" /> value in to extended ascii characters array.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into ascii character array.</param>
		/// <returns>An extended ascii character array.</returns>
		public static char[] ToCharArray(this Char.ReservedChars value) { return new[] {(char) value}; }

		/// <summary>
		///    Converting <see cref="Char.ReservedChars" /> value in to <see cref="string" />.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into <see cref="string" />.</param>
		/// <returns>An <see cref="string" />.</returns>
		public static string ToCharString(this Char.ReservedChars value) { return value.ToChar().ToString(); }
	}
}