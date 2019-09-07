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

using System.Web;
using Microsoft.AspNetCore.Html;

#endregion

namespace Diten
{
	public static class ExChar
	{
		/// <summary>
		///    Converting
		///    <para><see cref="char" /> value</para>
		///    in to ascii <see cref="int" /> code.
		/// </summary>
		/// <param name="value">A <see cref="char" /> that must be converted into <see cref="int" /> ascii code.</param>
		/// <returns>
		///    An ascii <see cref="int" /> code of the
		///    <para><see cref="char" /> value</para>
		///    .
		/// </returns>
		public static int ToInt(this char value) => value;

		/// <summary>
		///    Converting
		///    <para><see cref="char" /> value</para>
		///    in to ascii <see cref="short" /> <see cref="short" />code.
		/// </summary>
		/// <param name="value">A <see cref="char" /> that must be converted into <see cref="short" /> ascii code.</param>
		/// <returns>
		///    An ascii <see cref="short" /> code of the
		///    <para><see cref="char" /> value</para>
		///    .
		/// </returns>
		public static short ToShort(this char value) => (short) value;

		/// <summary>
		///    Converting <see cref="char" /> into <see cref="HtmlString" />.
		/// </summary>
		/// <param name="value">A <see cref="char" /> that must be converted into <see cref="HtmlString" />.</param>
		/// <returns>A <see cref="string" /> that represent <see cref="HtmlString" />.</returns>
		public static string ToHtmlEncode(this char value) => HttpUtility.HtmlEncode(value);

		/// <summary>
		///    Converting <see cref="char" />
		///    <para>value</para>
		///    in to extended ascii characters array.
		/// </summary>
		/// <param name="value">A <see cref="char" /> that must be converted into ascii character array.</param>
		/// <returns>An extended ascii character array.</returns>
		public static char[] ToCharArray(this char value) => new[] {value};
	}
}