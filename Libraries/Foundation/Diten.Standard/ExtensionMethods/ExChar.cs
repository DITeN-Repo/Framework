#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System.Web;

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
		public static int ToInt(this char value)
		{
			return value;
		}

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
		public static short ToShort(this char value)
		{
			return (short)value;
		}

		/// <summary>
		///    Converting <see cref="char" /> into <see cref="HtmlString" />.
		/// </summary>
		/// <param name="value">A <see cref="char" /> that must be converted into <see cref="HtmlString" />.</param>
		/// <returns>A <see cref="string" /> that represent <see cref="HtmlString" />.</returns>
		public static string ToHtmlEncode(this char value)
		{
			return HttpUtility.HtmlEncode(value);
		}
	}
}