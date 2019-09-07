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
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diten.Parameters;

#endregion

namespace Diten.Text
{
	public static class Tools
	{
		/// <summary>
		/// </summary>
		public enum AlphabetTypes
		{
			VerySimple,
			Simple,
			Medium,
			Hard,
			VeryHard,
			Hex
		}

		/// <summary>
		///    Get random text.
		/// </summary>
		/// <param name="alphabetsType">Type of alphabets that used for random text generation.</param>
		/// <param name="length">Length of the generated text.</param>
		/// <returns>A random text.</returns>
		public static string GetRandomText(AlphabetTypes alphabetsType = AlphabetTypes.Medium,
			int length = 5)
		{
			var randomText = new StringBuilder();
			var random = new Random();

			string alphabets;

			switch (alphabetsType)
			{
				case AlphabetTypes.VerySimple:
					alphabets = Constants.KeyboardCharacters01.ToString();
					break;
				case AlphabetTypes.Simple:
					alphabets = Constants.KeyboardCharacters02.ToString();
					break;
				case AlphabetTypes.Medium:
					alphabets = Constants.KeyboardCharacters03.ToString();
					break;
				case AlphabetTypes.Hard:
					alphabets = Constants.KeyboardCharacters04.ToString();
					break;
				case AlphabetTypes.VeryHard:
					alphabets = Constants.Default.InjectionCharactersGroup03;
					break;
				case AlphabetTypes.Hex:
					alphabets = Constants.Default.HexCharacters;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(alphabetsType), alphabetsType, null);
			}

			for (var j = 1; j <= length; j++)
				randomText.Append(alphabets[random.Next(alphabets.Length)]);

			return randomText.ToString();
		}

		/// <summary>
		/// </summary>
		/// <param name="title"></param>
		/// <param name="body"></param>
		/// <param name="indent"></param>
		/// <param name="isMultiLine"></param>
		/// <returns></returns>
		public static string DesignMessage(string title, string body, int indent = 0, bool isMultiLine = false) =>
			$"{title}: {(isMultiLine ? Environment.NewLine : string.Empty)}{Repeat(" ", 50 - title.Length) + body.IsNull("-")}"
				.Indent(indent) +
			Environment.NewLine;


		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string Repeat(string text, int length = 10) => string.Concat(Enumerable.Repeat(text, length));

		/// <summary>
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string Repeat(IEnumerable<char> ch, int length = 10)
		{
			return Repeat(ch.Aggregate(string.Empty, (current, c) => current + c), length);
		}

		/// <summary>
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string Repeat(char ch, int length = 10) => Repeat(ch.ToString(), length);

		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="maxlength"></param>
		/// <returns></returns>
		public static string SetTemplate(string text, int maxlength = 150) =>
			SetTemplate(text, ".".ToCharArray()[0], maxlength);

		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="template"></param>
		/// <param name="maxlength"></param>
		/// <returns></returns>
		public static string SetTemplate(string text, char template, int maxlength = 150)
		{
			return maxlength < text.Length
				? text
				: $@"{text}{Repeat(new[] {template}, maxlength).Substring(text.Length, maxlength - text.Length)}";
		}

		/// <summary>
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static List<string> SplitByUpper(string source)
		{
			//BeforeRecordInsertedEventArgs
			var _return = new List<string>();
			var tmp = string.Empty;
			var count = 0;

			foreach (var ch in source.ToCharArray())
			{
				if (ch >= 65 && ch <= 90)
					if (count != 0)
					{
						_return.Add(tmp);
						count = 0;
						tmp = string.Empty;
					}

				tmp += ch;

				count++;
			}

			_return.Add(tmp);

			return _return;
		}
	}
}