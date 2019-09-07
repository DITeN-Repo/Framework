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
// Creation Date: 2019/08/16 12:55 AM

#endregion

#region Used Directives

using System.Windows;
using Diten.Text;

#endregion

namespace Diten
{
	public static class ExString
	{
		/// <summary>
		///    Get text separator dash line.
		/// </summary>
		/// <param name="value">The message that must be write in the center of the separator.</param>
		/// <returns>
		///    An string with
		///    <para>length</para>
		///    repeat of character '-' (Dash).
		/// </returns>
		internal static string ToSeparator(this string value)
		{
			var length = SystemParameters.FullPrimaryScreenWidth / 10 - value.Length - 75 - 6;

			if (!(length <= 0))
			{
				if (length % 2 > 0)
					length++;
			}
			else
			{
				length = 0;
			}

			length /= 2;

			var stringValue = Tools.Repeat("-", (int) length);

			return $"{stringValue}[[{value.ToUpper()}]]{stringValue}{Environment.NewLine}";
		}
	}
}