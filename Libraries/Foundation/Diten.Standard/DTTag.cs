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
// Creation Date: 2019/08/15 4:35 PM

#endregion

#region Used Directives

using Diten.Security.Cryptography;

#endregion

namespace Diten
{
	/// <inheritdoc />
	public class DTTag : String
	{
		public DTTag(string value) => Value =
			SHA1.Encrypt(
				$@"{Char.ReservedChars.ShiftIn.ToChar().ToString()}{value}{UniqueSignature}{Char.ReservedChars.ShiftOut.ToChar().ToString()}");

		/// <summary>
		///    Get start tag.
		/// </summary>
		/// <returns>A start tag.</returns>
		public string StartTag => $"<{Value}>";

		/// <summary>
		///    Get closed tag.
		/// </summary>
		public string Tag => $"<{Value} />";

		/// <summary>
		///    Get end tag.
		/// </summary>
		/// <returns>An end tag</returns>
		public string EndTag => $"</{Value}>";

		/// <summary>
		///    Converting value into tag.
		/// </summary>
		/// <returns>A tag the is generated from uppercase letters of the words in the string</returns>
		private string ToTag() =>
			Value.ToSafe().ToCamel().Replace(Char.ReservedChars.Space.ToChar().ToString(), string.Empty);
	}
}