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
		/// </summary>
		/// <param name="title"></param>
		/// <param name="body"></param>
		/// <param name="indent"></param>
		/// <param name="isMultiLine"></param>
		/// <returns></returns>
		public static System.String DesignMessage(System.String title,
		                                   string body,
		                                   int indent = 0,
		                                   bool isMultiLine = false)
		{
			return $"{title}: {(isMultiLine ? Environment.NewLine : string.Empty)}{Repeat(" ", 50 - title.Length) + body.IsNull("-")}"
				       .Indent(indent) +
			       Environment.NewLine;
		}

		/// <summary>
		///    Get random text.
		/// </summary>
		/// <param name="alphabetsType">Type of alphabets that used for random text generation.</param>
		/// <param name="length">Length of the generated text.</param>
		/// <returns>A random text.</returns>
		public static System.String GetRandomText(AlphabetTypes alphabetsType = AlphabetTypes.Medium,
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
					throw new ArgumentOutOfRangeException(nameof(alphabetsType),
					                                      alphabetsType,
					                                      null);
			}

			for (var j = 1;
			     j <= length;
			     j++) randomText.Append(alphabets[random.Next(alphabets.Length)]);

			return randomText.ToString();
		}

		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static System.String Repeat(System.String text,
		                            int length = 10)
		{
			return string.Concat(Enumerable.Repeat(text,
			                                       length));
		}

		/// <summary>
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static System.String Repeat(IEnumerable<char> ch,
		                            int length = 10)
		{
			return Repeat(ch.Aggregate(System.String.Empty,
			                           (current,
			                            c) => current + c),
			              length);
		}

		/// <summary>
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static System.String Repeat(char ch,
		                            int length = 10)
		{
			return Repeat(ch.ToString(),
			              length);
		}

		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="maxlength"></param>
		/// <returns></returns>
		public static System.String SetTemplate(System.String text,
		                                 int maxlength = 150)
		{
			return SetTemplate(text,
			                   ".".ToCharArray()[0],
			                   maxlength);
		}

		/// <summary>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="template"></param>
		/// <param name="maxlength"></param>
		/// <returns></returns>
		public static System.String SetTemplate(System.String text,
		                                 char template,
		                                 int maxlength = 150)
		{
			return maxlength < text.Length
				       ? text
				       : $@"{
						       text
					       }{
						       Repeat(new[] {template},
						              maxlength)
							       .Substring(text.Length,
							                  maxlength - text.Length)
					       }";
		}

		/// <summary>
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static List<System.String> SplitByUpper(System.String source)
		{
			//BeforeRecordInsertedEventArgs
			var _return = new List<System.String>();
			var tmp = string.Empty;
			var count = 0;

			foreach (var ch in source.ToCharArray())
			{
				if (ch >= 65 &&
				    ch <= 90)
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