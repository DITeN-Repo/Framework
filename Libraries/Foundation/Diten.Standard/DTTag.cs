#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:35 PM

#endregion

#region Using Directives

#endregion

namespace Diten
{
	public class DTTag:String
	{
		public DTTag(string value)
		{
			Value=value;
		}

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
		private string ToTag()
		{
			return Value.ToSafe().ToCamel().Replace(Char.ReservedChars.Space.ToChar().ToString(), string.Empty);
		}
	}
}