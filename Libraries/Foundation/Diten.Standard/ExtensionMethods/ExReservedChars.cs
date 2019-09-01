#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten
{
	public static class ExReservedChars
	{
		/// <summary>
		///    Converting <see cref="Char.ReservedChars" />
		///    <para>value</para>
		///    in to extended ascii character.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into extended ascii character.</param>
		/// <returns>An extended ascii character.</returns>
		public static char ToChar(this Char.ReservedChars value)
		{
			return (char)value;
		}

		/// <summary>
		///    Converting <see cref="Char.ReservedChars" />
		///    <para>value</para>
		///    in to extended ascii characters array.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into ascii character array.</param>
		/// <returns>An extended ascii character array.</returns>
		public static char[] ToCharArray(this Char.ReservedChars value)
		{
			return new[] { (char)value };
		}

		/// <summary>
		///    Converting <see cref="Char.ReservedChars" />
		///    <para>value</para>
		///    in to <see cref="string" />.
		/// </summary>
		/// <param name="value">A <see cref="Char.ReservedChars" /> that must be converted into <see cref="string" />.</param>
		/// <returns>An <see cref="string" />.</returns>
		public static string ToString(this Char.ReservedChars value)
		{
			switch(value)
			{
				case Char.ReservedChars.Null:
					return value.GetName();
				case Char.ReservedChars.StartOfHeader:
					break;
				case Char.ReservedChars.StartOfText:
					break;
				case Char.ReservedChars.EndOfText:
					break;
				case Char.ReservedChars.EndOfTrans:
					break;
				case Char.ReservedChars.Inquiry:
					break;
				case Char.ReservedChars.Acknowledgement:
					break;
				case Char.ReservedChars.Bell:
					break;
				case Char.ReservedChars.Backspace:
					break;
				case Char.ReservedChars.HorizontalTab:
					break;
				case Char.ReservedChars.LineFeed:
					break;
				case Char.ReservedChars.VerticalTab:
					break;
				case Char.ReservedChars.FormFeed:
					break;
				case Char.ReservedChars.CarriageReturn:
					break;
				case Char.ReservedChars.ShiftOut:
					break;
				case Char.ReservedChars.ShiftIn:
					break;
				case Char.ReservedChars.DataLinkEscape:
					break;
				case Char.ReservedChars.DeviceControl1:
					break;
				case Char.ReservedChars.DeviceControl2:
					break;
				case Char.ReservedChars.DeviceControl3:
					break;
				case Char.ReservedChars.DeviceControl4:
					break;
				case Char.ReservedChars.NegativeAcknowledge:
					break;
				case Char.ReservedChars.SynchronousIdle:
					break;
				case Char.ReservedChars.EndOfTransactionBlock:
					break;
				case Char.ReservedChars.Cancel:
					break;
				case Char.ReservedChars.EndOfMedium:
					break;
				case Char.ReservedChars.Substitute:
					break;
				case Char.ReservedChars.Escape:
					break;
				case Char.ReservedChars.FileSeparator:
					break;
				case Char.ReservedChars.GroupSeparator:
					break;
				case Char.ReservedChars.RecordSeparator:
					break;
				case Char.ReservedChars.UnitSeparator:
					break;
				case Char.ReservedChars.Delete:
					break;
				case Char.ReservedChars.Dash:
					break;
				case Char.ReservedChars.Multiplication:
					break;
				case Char.ReservedChars.EmptySet:
					break;
				case Char.ReservedChars.Pound:
					break;
				case Char.ReservedChars.Cent:
					break;
				case Char.ReservedChars.Yen:
					break;
				case Char.ReservedChars.DoubleQuotes:
					break;
				case Char.ReservedChars.Number:
					break;
				case Char.ReservedChars.Percent:
					break;
				case Char.ReservedChars.Ampersand:
					break;
				case Char.ReservedChars.QuestionMark:
					break;
				case Char.ReservedChars.Equals:
					break;
				case Char.ReservedChars.Semicolon:
					break;
				case Char.ReservedChars.Colon:
					break;
				case Char.ReservedChars.Space:
					break;
				case Char.ReservedChars.CopyrightSymbol:
					break;
				case Char.ReservedChars.DegreeSymbol:
					break;
				case Char.ReservedChars.Apostrophe:
					break;
				case Char.ReservedChars.Micron:
					break;
				case Char.ReservedChars.RegisteredTrademarkSymbol:
					break;
				case Char.ReservedChars.FunctionSign:
					break;
				case Char.ReservedChars.PlusMinusSign:
					break;
				case Char.ReservedChars.NonBreakingSpace:
					break;
				case Char.ReservedChars.Dot:
					break;
				case Char.ReservedChars.Slash:
					break;
				case Char.ReservedChars.LessThan:
					break;
				case Char.ReservedChars.GreaterThan:
					break;
				case Char.ReservedChars.At:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(value), value, null);
			}

			return ((char)value).ToString();
		}
	}
}