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
// Creation Date: 2019/08/15 4:35 PM

#region Used Directives

using Diten.Security.Cryptography;

#endregion

namespace Diten
{
	/// <inheritdoc />
	public class DTTag: String
	{
		public DTTag(System.String value)
		{
			Value =
				SHA1.Encrypt(
				             $@"{Char.ReservedChars.ShiftIn.ToChar().ToString()}{value}{Char.ReservedChars.ShiftOut.ToChar().ToString()}")
				    .ToHex();
		}

		/// <summary>
		///    Get end tag.
		/// </summary>
		/// <returns>An end tag</returns>
		public System.String EndTag => $"</{Value}>";

		/// <summary>
		///    Get start tag.
		/// </summary>
		/// <returns>A start tag.</returns>
		public System.String StartTag => $"<{Value}>";

		/// <summary>
		///    Get closed tag.
		/// </summary>
		public System.String Tag => $"<{Value} />";

		/// <summary>
		///    Converting value into tag.
		/// </summary>
		/// <returns>A tag the is generated from uppercase letters of the words in the string</returns>
		private string ToTag()
		{
			return Value.ToSafe()
			            .ToCamel()
			            .Replace(Char.ReservedChars.Space.ToChar().ToString(),
			                     string.Empty);
		}
	}
}