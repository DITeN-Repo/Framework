﻿#region Using Directives

using System.Collections.Generic;

#endregion

namespace Diten.Tor.Helpers
{
	/// <summary>
	///     A class containing methods to assist with string-based parsing.
	/// </summary>
	internal static class StringHelper
	{
		/// <summary>
		///     Gets all blocks from a <see cref="System.String" /> where the delimiter is not included within quotations.
		/// </summary>
		/// <param name="data">The <see cref="System.String" /> to retrieve the blocks from.</param>
		/// <param name="delimiter">The delimiter to search for.</param>
		/// <returns>A <see cref="System.String" /> array containing the blocks.</returns>
		public static string[] GetAll(string data, char delimiter)
		{
			if (data == null)
				return null;

			var index = 0;
			string part = null;
			var blocks = new List<string>();

			while ((part = GetNext(data, index, delimiter)) != null)
			{
				blocks.Add(part);
				index += part.Length + 1;
			}

			return blocks.ToArray();
		}

		/// <summary>
		///     Gets the next block from a <see cref="System.String" /> where the delimiter is not included within quotations.
		/// </summary>
		/// <param name="data">The <see cref="System.String" /> to retrieve the block from.</param>
		/// <param name="start">The start index within the string.</param>
		/// <param name="delimiter">The delimiter to search for.</param>
		/// <returns>A <see cref="System.String" /> containing the block data.</returns>
		public static string GetNext(string data, int start, char delimiter)
		{
			if (data == null)
				return null;
			if (data.Length <= start)
				return null;

			var index = start;
			var length = data.Length;
			var escaped = false;

			while (index < length)
			{
				var c = data[index++];

				if (c == '"')
				{
					escaped = !escaped;
					continue;
				}

				if (c == delimiter && !escaped)
				{
					index--;
					break;
				}
			}

			return data.Substring(start, index - start);
		}
	}
}