using System;
using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace Diten.Windows.Applications.Tools.Official.Bookmarks
{
	public static class Extensions
	{
		public static System.String ToClosedTag(this string value) => $@"</{value}>";
		public static System.String ToOpenTag(this string value) => $@"<{value}>";

		public static System.String Repeat(this string value,
		                            int count = 10)
		{
			var outPut = string.Empty;

			for (var i = 0;
			     i <= count;
			     i++) outPut += value;

			return outPut;
		}

		public static long ToLong(this DateTime value) => long.Parse(value.ToString("yyyyMMddHHmmss"));

		public static bool IsNullString(this string value) => string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);

		public static System.String ReplaceWithEmpty(this string value,
		                                      string param) =>
			value.Replace(param,
			              string.Empty);

		public static System.String Save(this string value,
		                          string path)
		{
			File.WriteAllText(path,
			                  value,
			                  Encoding.UTF8);

			return $@"{path}";
		}

		public static System.String GetAttrValue(this HtmlNode value,
		                                  string attribute)
		{
			try { return value.Attributes[attribute].Value; }
			catch (Exception) { return string.Empty; }
		}
	}
}