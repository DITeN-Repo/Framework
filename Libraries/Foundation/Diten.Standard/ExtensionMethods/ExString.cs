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

// ReSharper disable UnusedMember.Global

#region Used Directives

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Diten.Attributes;
using Diten.Diagnostics;
using Diten.Numeric;
using Diten.Parameters;
using Diten.Security.Cryptography;
using Diten.Text;
using JetBrains.Annotations;
using EN = Diten.Environment;

#endregion

namespace Diten
{
	/// <summary>
	///    String extension methods class.
	/// </summary>
	/// <inheritdoc cref="http://help.diten.net/?Cat=Framework&Type=Diten_String" />
	public static class ExString
	{
		/// <summary>
		///    Compress current <see cref="string" />.
		/// </summary>
		/// <param name="value">Current <see cref="string" /> that will be compressed in <see cref="GZipStream" />.</param>
		/// <returns>A compressed <see cref="string" /> as an array of <see cref="byte" /></returns>
		public static byte[] Compress(this string value)
		{
			using (var gZipStream = new GZipStream(new MemoryStream(value.ToBytes()),
			                                       CompressionMode.Compress)) { return gZipStream.BaseStream.ToBytes(); }
		}

		/// <summary>
		///    Formatting parameterized string.
		/// </summary>
		/// <param name="value">Current string that in stack.</param>
		/// <param name="parameters">Values that must be inserted as parameter holders.</param>
		/// <returns>A formatted <see cref="string" /> with parameters.</returns>
		public static string Format(this string value,
		                            params object[] parameters)
		{
			return string.Format(value,
			                     parameters);
		}

		/// <summary>
		///    Get abbreviation of the <see cref="string" /> by converting it to the camel text style.
		/// </summary>
		/// <param name="value">A <see cref="string" /> that must be abbreviated.</param>
		/// <returns>
		///    Abbreviation of
		///    <para><see cref="string" />value</para>
		/// </returns>
		public static string GetAbbreviation(this string value)
		{
			return value.ToSafe()
			            .ToCharArray()
			            .Where(character => Char.UppercaseLetters.ToList().Any(c => c.Ascii == character))
			            .Aggregate(string.Empty,
			                       (current,
			                        character) => current + character);
		}

		/// <summary>
		///    Get first unsafe character in string
		///    <para>value</para>
		///    from <see cref="Diten.Char.UnsafeChars" />.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>
		///    A nullable <see cref="char" /> if there is no <see cref="Diten.Char.UnsafeChars" />
		///    in
		///    <see cref="Diten.String" />.
		/// </returns>
		public static (char Ascii, string Character, string Description) GetFirstUnsafeChar(this string value)
		{
			var holder00 = ToUnsafe(Regex.Match(value,
			                                    "[&]+[\\w]+[;]")
			                             .Value);

			return Char.AsciiCharacters.FirstOrDefault(c => c.Character.Equals(holder00));
		}

		public static string Indent(this string value,
		                            int indent = 1)
		{
			return $"{Tools.Repeat(Char.ReservedChars.HorizontalTab.ToChar(), indent)}{value}";
		}

		/// <summary>
		///    Check that string is null or not.
		///    This function check that string IsNullOrEmpty and IsNullOrWhiteSpace. If both functions return true
		///    <para>value</para>
		///    this
		///    function return true.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>True if string is null.</returns>
		public static bool IsNull(this string value) { return string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value); }

		/// <summary>
		///    Check that string is null or not.
		///    This function check that string IsNullOrEmpty and IsNullOrWhiteSpace. If both functions return true
		///    <para>value</para>
		///    this
		///    function return returnMessage and
		///    <para>value</para>
		///    of the string if not.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <param name="returnMessage">
		///    The message that must be returned if the
		///    <para>value</para>
		///    is null.
		/// </param>
		/// <returns>
		///    Return
		///    <para>returnMessage</para>
		///    if
		///    <para>value</para>
		///    is null and the
		///    <para>value</para>
		///    of the string if not.
		/// </returns>
		[CanBeNull]
		public static string IsNull(this string value,
		                            [CanBeNull] string returnMessage)
		{
			return IsNull(value) ? returnMessage : value;
		}

		/// <summary>
		///    Check that string is null or not.
		///    This function check that string IsNullOrEmpty and IsNullOrWhiteSpace. If both functions return true
		///    <para>value</para>
		///    this
		///    function return true.
		/// </summary>
		/// <param name="value">An <see cref="String" />value.</param>
		/// <returns>True if string is null.</returns>
		public static bool IsNull(this String value) { return IsNull(value.Value); }

		/// <summary>
		///    Check that string contains <see cref="Diten.Char.UnsafeChars" /> or not.
		/// </summary>
		/// <param name="value">String to check</param>
		/// <returns>True if there is no <see cref="Diten.Char.UnsafeChars" /></returns>
		public static bool IsSafe(this string value) { return GetFirstUnsafeChar(value).Character.IsNull(); }

		/// <summary>
		///    Removing an <see cref="IEnumerable{T}" /> of <see cref="char" />from current <see cref="string" />.
		/// </summary>
		/// <param name="value">Current <see cref="string" /> value.</param>
		/// <param name="chars">
		///    An <see cref="IEnumerable{T}" /> of <see cref="char" />s that must be removed from current
		///    <see cref="string" />.
		/// </param>
		/// <returns>
		///    A <see cref="string" /> without
		///    <para><see cref="IEnumerable{T}" /> of <see cref="char" /> contained <see cref="char" />s</para>
		/// </returns>
		public static string Remove(this string value,
		                            IEnumerable<char> chars)
		{
			return chars.Aggregate(string.Empty,
			                       (result,
			                        current) => value.Replace(current.ToString(),
			                                                  string.Empty));
		}

		/// <summary>
		///    Saving string into repository.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		public static void Save(this string value) { new String(value).Save(); }

		public static string SingleOutOn(this string value,
		                                 char character)
		{
			return new System.Func<string, char, string>((s,
			                                              c) =>
			                                             {
				                                             var doubleC = Tools.Repeat(c,
				                                                                        2);

				                                             while (value.Contains(c))
					                                             value = value.Replace(doubleC,
					                                                                   c.ToString());

				                                             return value;
			                                             }
			                                            ).Invoke(value,
			                                                     character);
		}

		/// <summary>
		///    Converting separated value string into string array.
		/// </summary>
		/// <param name="data">Separated value string.</param>
		/// <returns>An array of separated values.</returns>
		public static IEnumerable<string> ToArray(this string data)
		{
			return data.Split(Char.ReservedChars.Space.ToCharArray(),
			                  StringSplitOptions.RemoveEmptyEntries);
		}

		/// <summary>
		///    Converting value into Base64Text encryption.
		/// </summary>
		/// <param name="value">The current entity that must be converted into Base64Text encryption.</param>
		/// <returns>A Base64Text hashed string.</returns>
		public static string ToBase64Text(this string value) { return Base64Text.Encrypt(value); }

		/// <summary>
		///    Converting string into byte array.
		/// </summary>
		/// <param name="value">String for conversion.</param>
		/// <returns>A byte array.</returns>
		public static byte[] ToBytes(this string value) { return Encoding.ASCII.GetBytes(value); }

		/// <summary>
		///    Converting data to camel style.
		/// </summary>
		/// <param name="data">Data to convert</param>
		/// <returns>A camel style converted string.</returns>
		public static string ToCamel(this string data)
		{
			var output = string.Empty;

			foreach (
				var word in
				UrlEncode(data)
					.Replace("[",
					         string.Empty)
					.Replace("]",
					         string.Empty)
					.ToLower()
					.Split("_".ToCharArray(),
					       StringSplitOptions.RemoveEmptyEntries))
				output = $@"{
						word.Substring(0,
						               1)
						    .ToUpper() +
						word.Substring(1,
						               word.Length - 1)
						    .ToPrefix()
					}";

			return output.Substring(0,
			                        output.Length - 2)
			             .Replace("_",
			                      " ");
		}

		public static string ToClosedTag(this string value,
		                                 bool abbreviationTag = true)
		{
			return $@"{
					Char.ReservedChars.LessThan
				}{
					(abbreviationTag ? value.GetAbbreviation() : value.ToSafe())
				}{
					Char.ReservedChars.Slash
				}{
					Char.ReservedChars.GreaterThan
				}";
		}

		/// <summary>
		///    Converting a key and value separated <see cref="string" /> into a <see cref="Dictionary{TKey,TValue}" /> of key and
		///    value.
		/// </summary>
		/// <param name="value">Key and value separated <see cref="string" />.</param>
		/// <returns>A <see cref="Dictionary{TKey,TValue}" /> of key and value.</returns>
		public static Dictionary<string, string> ToDictionary(this string value)
		{
			return ToArray(value)
			       .Select(_string => _string.Split(EN.TextValuingSeparator.ToCharArray(),
			                                        StringSplitOptions.RemoveEmptyEntries))
			       .Where(word => !word[0].Equals(string.Empty))
			       .ToDictionary(word => word[0],
			                     word => word[1]);
		}

		public static string ToFirstUpper(this string value)
		{
			return $"{value.First().ToString().ToUpper()}{value.Substring(1, value.Length - 1).ToLower()}";
		}

		/// <summary>
		///    Converting <see cref="string" /> data into hex <see cref="string" />.
		/// </summary>
		/// <param name="data">Data for conversion.</param>
		/// <returns>Converted data.</returns>
		public static string ToHexadecimal(this string data)
		{
			return data.Aggregate(string.Empty,
			                      (result,
			                       current) => result + $"{System.Convert.ToInt32(current):X}");
		}

		/// <summary>
		///    Convert an <see cref="string" /> to <see cref="int" />.
		/// </summary>
		/// <param name="value"><see cref="string" /> value.</param>
		/// <param name="baseChars">Characters that must be used in conversion.</param>
		/// <returns>
		///    A <see cref="int" /> that represented by <see cref="string" />
		///    <para>value</para>
		///    .
		/// </returns>
		public static int ToInt(this string value,
		                        char[] baseChars)
		{
			var baseCharsLength = baseChars.Length;
			var result = baseCharsLength;
			var index = 0;

			while (true)
			{
				result++;

				if (result * baseCharsLength % result > 0)
				{
					index++;

					if (index > value.Length) throw new AmbiguousMatchException("Ambiguous match on converting value.");
				}
				else { break; }
			}

			return result * baseCharsLength;
		}

		/// <summary>
		///    Convert an <see cref="string" /> to <see cref="int" />.
		/// </summary>
		/// <param name="value"><see cref="string" /> value.</param>
		/// <returns>
		///    A <see cref="int" /> that represented by <see cref="string" />
		///    <para>value</para>
		///    .
		/// </returns>
		public static int ToInt(this string value)
		{
			return ToInt(value,
			             Duosexagesimal.Characters.ToArray());
		}

		public static string ToOpenTag(this string value,
		                               string innerText,
		                               bool abbreviationTag = true)
		{
			return new Func<string, string, bool, string>((v,
			                                               it,
			                                               ab) =>
			                                              {
				                                              var closingTag = ToClosedTag(v,
				                                                                           ab);
				                                              var openingTag = closingTag.Replace(Char.ReservedChars.Slash.ToString(),
				                                                                                  string.Empty);

				                                              return $@"{openingTag}{it}{closingTag}";
			                                              }).Invoke(value,
			                                                        innerText,
			                                                        abbreviationTag);
		}

		/// <summary>
		///    Converting string to standard suffix byt adding '_' at the end of the string.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>An <see cref="string" /> that is converted to standard prefix.</returns>
		public static string ToPrefix(this string value) { return $"{value.ToProtected()}_"; }

		/// <summary>
		///    Converting string to standard protected string.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>An <see cref="string" /> that safe and protected.</returns>
		public static string ToProtected(this string value) { return value.ToProtectedString(); }

		/// <summary>
		///    Converting an string to standard protected string by replacing all <see cref="Char.UnsafeChars" /> characters with
		///    <see cref="Char.ReservedChars.Underline" />.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>An <see cref="string" /> that is safe and protected.</returns>
		public static string ToProtectedString(this string value)
		{
			return Char.UnsafeChars.ToList()
			           .Aggregate(string.Empty,
			                      (r,
			                       c) => value.Replace(c.Ascii,
			                                           Char.ReservedChars.Underline.ToChar()));
		}

		/// <summary>
		///    Converting current <see cref="string" /> into safe string.
		/// </summary>
		/// <returns>Represent a safe <see cref="string" />.</returns>
		public static string ToSafe(this string value) { return HttpUtility.UrlEncode(value); }

		/// <summary>
		///    Convert from hex string into string.
		/// </summary>
		/// <param name="value">A hex string.</param>
		/// <returns>Converted data</returns>
		public static string ToString([MustUrlHex] this string value)
		{
			var param = new StackTrace().GetFrame(0).GetMethod().GetParameters()[0];

			if ((MustUrlHex) Attribute.GetCustomAttribute(param,
			                                              typeof(MustUrlHex)) !=
			    null)
				return value.Split('%')
				            .Aggregate(string.Empty,
				                       (current,
				                        hex) => current +
				                                char.ConvertFromUtf32(System.Convert.ToInt32(hex,
				                                                                             16)));

			throw new ArgumentException(Exceptions.Default.Diten_ExtensionMethods_ExString_ToString_Hexadecimal);
		}

		/// <summary>
		///    Converting string to standard suffix byt adding '_' at the beginning of the string.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>An <see cref="string" /> that is converted to standard suffix.</returns>
		public static string ToSuffix(this string value) { return $"_{value.ToProtected()}"; }

		/// <summary>
		///    Converting current <see cref="string" /> into safe string.
		/// </summary>
		/// <returns>Represent a safe <see cref="string" />.</returns>
		public static string ToUnsafe(this string value) { return HttpUtility.UrlDecode(value); }

		/// <summary>
		///    Get encrypted URL.
		/// </summary>
		/// <param name="value">URL of page.</param>
		/// <param name="parameter">Encrypted parameter.</param>
		/// <param name="doPost">Send parameters by post method.</param>
		/// <returns>Encrypted URL.</returns>
		public static string ToUrl(this string value,
		                           string parameter,
		                           bool doPost = false)
		{
			var output = string.Empty;

			if (!parameter.Equals(string.Empty))
				if ($@"{value}?{parameter}".Length > SystemParams.Default.MaxUrlLength || doPost)
				{
					StreamWriter streamWriter = null;

					var httpHttpWebRequest = WebRequest.CreateHttp(value);

					httpHttpWebRequest.Method = "POST";
					httpHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
					httpHttpWebRequest.ContentLength = parameter.Length;

					try
					{
						streamWriter = new StreamWriter(httpHttpWebRequest.GetRequestStream());
						streamWriter.Write(parameter);
					}
					finally { streamWriter?.Close(); }
				}
				else { output = $@"{value}?{parameter}"; }
			else output = value;

			return output;
		}

		/// <summary>
		///    Converting current <see cref="string" /> into an array of <see cref="byte" />s.
		/// </summary>
		/// <returns>An array of <see cref="byte" />s.</returns>
		public static byte[] ToUTF8BytesBytes(this string value) { return Encoding.UTF8.GetBytes(value); }

		/// <summary>
		///    Converting a <see cref="string" /> into <see cref="Diten.Collections.Generic.List{T}" /> of
		///    <see cref="Diten.Word" />
		/// </summary>
		/// <param name="value"></param>
		/// <returns>A <see cref="Diten.Collections.Generic.List{T}" /> of <see cref="Diten.Word" />.</returns>
		public static Collections.Generic.List<Word> ToWords(this string value)
		{
			var result = new Collections.Generic.List<Word>();

			Collections.Generic.List<Word> RecursiveToWords(IEnumerable<Word> words)
			{
				var result00 = new Collections.Generic.List<Word>();

				foreach (var word in words)
				{
					var unsafeChar = word.Value.GetFirstUnsafeChar().Character;

					if (!unsafeChar.IsNull())
						result00.AddRange(
						                  RecursiveToWords(word.Value.Split(unsafeChar.ToCharArray()).Select(str => new Word(str))));
					else result00.Add(word);
				}

				return result00;
			}

			result.AddRange(RecursiveToWords(value
			                                 .Split(Char.ReservedChars.Space.ToCharArray(),
			                                        StringSplitOptions.RemoveEmptyEntries)
			                                 .Select(s => new Word(s))));

			return result;
		}

		/// <summary>
		///    Translating from current culture into destination culture,
		/// </summary>
		/// <param name="data">Data for translation.</param>
		/// <param name="cultureName">Translation culture name.</param>
		/// <returns>Translated data</returns>
		public static string Translate(this string data,
		                               string cultureName)
		{
			#if DEBUG
			return $@"{data} - {DateTime.Now.Millisecond}";
			#else
			return $@"{data}";
			#endif
			//ToDo: Check commented code
			//ToDo: The code must be controlled for logical mistakes.
			//todo: This part is based on ADO and must be changed
			//try
			//{
			//    if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
			//        return string.Empty;

			//    var dataRows =
			//        ApplicationDictionary.Select(
			//            $@"SourceText='{data}' AND SourceCultureID='{SystemCultureId}' AND TranslationCultureID='{
			//                    CultureId
			//                }'");

			//    string output;

			//    if (dataRows.Length == 0)
			//    {
			//        output = Translation.Translate(data, Diten.Constants.Default.SystemCultureName,
			//            cultureName);

			//        UpdateApplicationDictionary();

			//        return output.Equals(string.Empty) || string.IsNullOrEmpty(output) ||
			//               string.IsNullOrWhiteSpace(output)
			//            ? data.Replace("^", "<br />")
			//            : output.Replace("^", "<br />");
			//    }

			//    output = dataRows[0]["TranslatedText"].ToString();

			//    return output.Equals(string.Empty) || string.IsNullOrEmpty(output) ||
			//           string.IsNullOrWhiteSpace(output)
			//        ? data
			//        : output;
			//}
			//catch (Exception)
			//{
			//    return data;
			//}
		}

		/// <inheritdoc cref="HttpUtility.UrlDecode(string)" />
		public static string UrlDecode(this string value) { return value; }

		/// <inheritdoc cref="HttpUtility.UrlEncode(string)" />
		public static string UrlEncode(this string data) { return HttpUtility.UrlEncode(data); }
	}
}