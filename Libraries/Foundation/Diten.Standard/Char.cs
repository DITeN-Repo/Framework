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

using System.Collections.Generic;
using System.Linq;
using Diten.Numeric;

#endregion

namespace Diten
{
	public static class Char
	{
		/// <summary>
		///    Reserved characters.
		/// </summary>
		public enum ReservedChars
		{
			/// <summary>
			///    Null character.
			/// </summary>
			Null = 0,

			/// <summary>
			///    Backslash character.
			/// </summary>
			Backslash = 99,

			/// <summary>
			///    Start of Header.
			/// </summary>
			StartOfHeader = 1,

			/// <summary>
			///    Start of Text.
			/// </summary>
			StartOfText = 2,

			/// <summary>
			///    End of Text, hearts card suit
			/// </summary>
			EndOfText = 3,

			/// <summary>
			///    End of Transmission, diamonds card suit
			/// </summary>
			EndOfTrans = 4,

			/// <summary>
			///    Inquiry, clubs card suit
			/// </summary>
			Inquiry = 5,

			/// <summary>
			///    Acknowledgement, spade card suit
			/// </summary>
			Acknowledgement = 6,

			/// <summary>
			///    Bell.
			/// </summary>
			Bell = 7,

			/// <summary>
			///    Backspace.
			/// </summary>
			Backspace = 8,

			/// <summary>
			///    Horizontal Tab.
			/// </summary>
			HorizontalTab = 9,

			/// <summary>
			///    Line feed.
			/// </summary>
			LineFeed = 10,

			/// <summary>
			///    Vertical Tab, male symbol, symbol for Mars.
			/// </summary>
			VerticalTab = 11,

			/// <summary>
			///    Form feed, female symbol, symbol for Venus.
			/// </summary>
			FormFeed = 12,

			/// <summary>
			///    Carriage return.
			/// </summary>
			CarriageReturn = 13,

			/// <summary>
			///    Shift Out.
			/// </summary>
			ShiftOut = 14,

			/// <summary>
			///    Shift In.
			/// </summary>
			ShiftIn = 15,

			/// <summary>
			///    Data link escape.
			/// </summary>
			DataLinkEscape = 16,

			/// <summary>
			///    Device control 1.
			/// </summary>
			DeviceControl1 = 17,

			/// <summary>
			///    Device control 2.
			/// </summary>
			DeviceControl2 = 18,

			/// <summary>
			///    Device control 3.
			/// </summary>
			DeviceControl3 = 19,

			/// <summary>
			///    Device control 4.
			/// </summary>
			DeviceControl4 = 20,

			/// <summary>
			///    NAK Negative-acknowledge
			/// </summary>
			NegativeAcknowledge = 21,

			/// <summary>
			///    Synchronous idle.
			/// </summary>
			SynchronousIdle = 22,

			/// <summary>
			///    End of transaction block.
			/// </summary>
			EndOfTransactionBlock = 23,

			/// <summary>
			///    Cancel.
			/// </summary>
			Cancel = 24,

			/// <summary>
			///    End of medium.
			/// </summary>
			EndOfMedium = 25,

			/// <summary>
			///    Substitute.
			/// </summary>
			Substitute = 26,

			/// <summary>
			///    Escape.
			/// </summary>
			Escape = 27,

			/// <summary>
			///    File separator.
			/// </summary>
			FileSeparator = 28,

			/// Group separator.
			GroupSeparator = 29,

			/// Record separator.
			RecordSeparator = 30,

			/// Unit separator.
			UnitSeparator = 31,

			/// Delete.
			Delete = 127,

			/// <summary>
			///    Dot, full stop
			/// </summary>
			Dot = 46,

			/// <summary>
			///    Dash, Hyphen or minus sign
			/// </summary>
			Dash = 45,

			/// <summary>
			///    Underline, underscore, under-strike, under-bar or low line
			/// </summary>
			Underline = 45,

			/// <summary>
			///    Multiplication sign.
			/// </summary>
			Multiplication = 158,

			/// <summary>
			///    Uppercase slashed zero or empty set.
			/// </summary>
			EmptySet = 157,

			/// <summary>
			///    Pound sign; symbol for the pound sterling.
			/// </summary>
			Pound = 156,

			/// <summary>
			///    Cent symbol.
			/// </summary>
			Cent = 189,

			/// <summary>
			///    YEN and YUAN sign.
			/// </summary>
			Yen = 190,

			/// <summary>
			///    Double quotes or Quotation mark or Speech marks.
			/// </summary>
			DoubleQuotes = 34,

			/// <summary>
			///    Number sign.
			/// </summary>
			Number = 35,

			/// <summary>
			///    Percent sign.
			/// </summary>
			Percent = 37,

			/// <summary>
			///    Ampersand.
			/// </summary>
			Ampersand = 38,

			/// <summary>
			///    Colon (:).
			/// </summary>
			Colon = 58,

			/// <summary>
			///    Slash, forward slash, fraction bar or division slash
			/// </summary>
			Slash = 47,

			/// <summary>
			///    Semicolon.
			/// </summary>
			Semicolon = 59,

			/// <summary>
			///    Less-than sign.
			/// </summary>
			LessThan = 60,

			/// <summary>
			///    Equals sign.
			/// </summary>
			Equals = 61,

			/// <summary>
			///    Greater-than sign or Inequality.
			/// </summary>
			GreaterThan = 62,

			/// <summary>
			///    Question mark.
			/// </summary>
			QuestionMark = 63,

			/// <summary>
			///    At sign.
			/// </summary>
			At = 64,

			/// Space character.
			Space = 32,

			/// Copyright symbol.
			CopyrightSymbol = 184,

			/// Degree symbol.
			DegreeSymbol = 248,

			/// Apostrophe.
			Apostrophe = 39,

			/// Micron.
			Micron = 230,

			/// Get registered trademark symbol.
			RegisteredTrademarkSymbol = 169,

			/// Function sign.
			FunctionSign = 159,

			/// Plus-minus.
			PlusMinusSign = 241,

			/// Multiplication symbol.
			MultiplicationSign = 158,

			/// Non-breaking space.
			NonBreakingSpace = 255
		}

		/// <summary>
		///    Get all ascii characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> AsciiCharacters
		{
			get
			{
				var holder = new List<(char Ascii, string Character, string Description)>();

				holder.AddRange(ControlChars);
				holder.AddRange(PrintableChars);
				holder.AddRange(ExtendedChars);

				return holder.OrderBy(c => c.Ascii.ToInt());

				//todo: Check commented code
				//return Resources.AsciiTable.Split(ReservedChars.LineFeed.ToChar()).Aggregate(
				//	new List<(char Ascii, string Character, string Description)>(),
				//	(result, current) =>
				//	{
				//		var holder = current.Split(',');
				//		var tmp = int.Parse(holder[0]);
				//		var desc = holder[1].Replace("\"\"", "\"").Trim('"');
				//		result.Add(((char) tmp, ((char)tmp).ToString(), desc));
				//		return result.OrderBy(c => c.Ascii.ToInt()).ToList();
				//	}); //holder.OrderBy(c=>c.Ascii.ToInt());
			}
		}

		/// <summary>
		///    Get commercial trade symbols.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> CommercialTradeSymbols =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(36) &&
				                      v.Ascii.ToInt().Equals(156) &&
				                      v.Ascii.ToInt().Equals(190) &&
				                      v.Ascii.ToInt().Equals(189) &&
				                      v.Ascii.ToInt().Equals(207) &&
				                      v.Ascii.ToInt().Equals(169) &&
				                      v.Ascii.ToInt().Equals(184) &&
				                      v.Ascii.ToInt().Equals(166) &&
				                      v.Ascii.ToInt().Equals(167) &&
				                      v.Ascii.ToInt().Equals(248));

		/// <summary>
		///    Get control characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> ControlChars =>
			new List<(char Ascii, string Character, string Description)>
			{
				((char) 0, "NULL", "Null character"),
				((char) 1, "SOH", "Start of Header"),
				((char) 2, "STX", "Start of Text"),
				((char) 3, "ETX", "End of Text"),
				((char) 4, "EOT", "End of Transmission"),
				((char) 5, "ENQ", "Inquiry"),
				((char) 6, "ACK", "Acknowledgement"),
				((char) 7, "BEL", "Bell"),
				((char) 8, "BS", "Backspace"),
				((char) 9, "HT", "Horizontal Tab"),
				((char) 10, "LF", "Line feed"),
				((char) 11, "VT", "Vertical Tab"),
				((char) 12, "FF", "Form feed"),
				((char) 13, "CR", "Carriage return"),
				((char) 14, "SO", "Shift Out"),
				((char) 15, "SI", "Shift In"),
				((char) 16, "DLE", "Data link escape"),
				((char) 17, "DC1", "Device control 1"),
				((char) 18, "DC2", "Device control 2"),
				((char) 19, "DC3", "Device control 3"),
				((char) 20, "DC4", "Device control 4"),
				((char) 21, "NAK", "Negative acknowledgement"),
				((char) 22, "SYN", "Synchronous idle"),
				((char) 23, "ETB", "End of transmission block"),
				((char) 24, "CAN", "Cancel"),
				((char) 25, "EM", "End of medium"),
				((char) 26, "SUB", "Substitute"),
				((char) 27, "ESC", "Escape"),
				((char) 28, "FS", "File separator"),
				((char) 29, "GS", "Group separator"),
				((char) 30, "RS", "Record separator"),
				((char) 31, "US", "Unit separator"),
				((char) 127, "DEL", "Delete")
			};

		/// <summary>
		///    Get decimal numbers.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> DecimalNumbers
		{
			get
			{
				var holder00 = Duosexagesimal.Characters.Where(c => c >= 48 && c <= 57).ToList();

				return PrintableChars.Where(printableChar => holder00.Contains(printableChar.Ascii)).ToList();
			}
		}

		/// <summary>
		///    Get extended characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> ExtendedChars =>
			new Collections.Generic.List<(char Ascii, string Character, string Description)>
			{
				((char) 128, "Ç", "Majuscule C-cedilla"),
				((char) 129, "ü", "letter\"u\" with umlaut or diaeresis ;\"u-umlaut\""),
				((char) 130, "é", "letter\"e\" with acute accent or\"e-acute\""),
				((char) 131, "â", "letter\"a\" with circumflex accent or\"a-circumflex\""),
				((char) 132, "ä", "letter\"a\" with umlaut or diaeresis ;\"a-umlaut\""),
				((char) 133, "à", "letter\"a\" with grave accent"),
				((char) 134, "å", "letter\"a\" with a ring"),
				((char) 135, "ç", "Minuscule c-cedilla"),
				((char) 136, "ê", "letter\"e\" with circumflex accent or\"e-circumflex\""),
				((char) 137, "ë", "letter\"e\" with umlaut or diaeresis ;\"e-umlaut\""),
				((char) 138, "è", "letter\"e\" with grave accent"),
				((char) 139, "ï", "letter\"i\" with umlaut or diaeresis ;\"i-umlaut\""),
				((char) 140, "î", "letter\"i\" with circumflex accent or\"i-circumflex\""),
				((char) 141, "ì", "letter\"i\" with grave accent"),
				((char) 142, "Ä", "letter\"A\" with umlaut or diaeresis ;\"A-umlaut\""),
				((char) 143, "Å", "letter\"A\" with a ring"),
				((char) 144, "É", "Capital letter\"E\" with acute accent or\"E-acute\""),
				((char) 145, "æ", "Latin diphthong\"ae\""),
				((char) 146, "Æ", "Latin diphthong\"AE\""),
				((char) 147, "ô", "letter\"o\" with circumflex accent or\"o-circumflex\""),
				((char) 148, "ö", "letter\"o\" with umlaut or diaeresis ;\"o-umlaut\""),
				((char) 149, "ò", "letter\"o\" with grave accent"),
				((char) 150, "û", "letter\"u\" with circumflex accent or\"u-circumflex\""),
				((char) 151, "ù", "letter\"u\" with grave accent"),
				((char) 152, "ÿ", "letter\"y\" with diaeresis"),
				((char) 153, "Ö", "letter\"O\" with umlaut or diaeresis ;\"O-umlaut\""),
				((char) 154, "Ü", "letter\"U\" with umlaut or diaeresis ;\"U-umlaut\""),
				((char) 155, "ø", "slashed zero or empty set"),
				((char) 156, "£", "Pound sign ; symbol for the pound sterling"),
				((char) 157, "Ø", "slashed zero or empty set"),
				((char) 158, "×", "multiplication sign"),
				((char) 159, "ƒ", "function sign ; f with hook sign ; florin sign"),
				((char) 160, "á", "letter\"a\" with acute accent or\"a-acute\""),
				((char) 161, "í", "letter\"i\" with acute accent or\"i-acute\""),
				((char) 162, "ó", "letter\"o\" with acute accent or\"o-acute\""),
				((char) 163, "ú", "letter\"u\" with acute accent or\"u-acute\""),
				((char) 164, "ñ", "letter\"n\" with tilde ; enye"),
				((char) 165, "Ñ", "letter\"N\" with tilde ; enye"),
				((char) 166, "ª", "feminine ordinal indicator"),
				((char) 167, "º", "masculine ordinal indicator"),
				((char) 168, "¿", "Inverted question marks"),
				((char) 169, "®", "Registered trademark symbol"),
				((char) 170, "¬", "Logical negation symbol"),
				((char) 171, "½", "One half"),
				((char) 172, "¼", "Quarter or one fourth"),
				((char) 173, "¡", "Inverted exclamation marks"),
				((char) 174, "«", "Guillemots or angle quotes"),
				((char) 175, "»", "Guillemots or angle quotes"),
				((char) 176, "░,", "Progress 1"),
				((char) 177, "▒,", "Progress 2"),
				((char) 178, "▓,", "Progress 3"),
				((char) 179, "│", "Box drawing character"),
				((char) 180, "┤", "Box drawing character"),
				((char) 181, "Á", "Capital letter\"A\" with acute accent or\"A-acute\""),
				((char) 182, "Â", "letter\"A\" with circumflex accent or\"A-circumflex\""),
				((char) 183, "À", "letter\"A\" with grave accent"),
				((char) 184, "©", "Copyright symbol"),
				((char) 185, "╣", "Box drawing character"),
				((char) 186, "║", "Box drawing character"),
				((char) 187, "╗", "Box drawing character"),
				((char) 188, "╝", "Box drawing character"),
				((char) 189, "¢", "Cent symbol"),
				((char) 190, "¥", "YEN and YUAN sign"),
				((char) 191, "┐", "Box drawing character"),
				((char) 192, "└", "Box drawing character"),
				((char) 193, "┴", "Box drawing character"),
				((char) 194, "┬", "Box drawing character"),
				((char) 195, "├", "Box drawing character"),
				((char) 196, "─", "Box drawing character"),
				((char) 197, "┼", "Box drawing character"),
				((char) 198, "ã", "letter\"a\" with tilde or\"a-tilde\""),
				((char) 199, "Ã", "letter\"A\" with tilde or\"A-tilde\""),
				((char) 200, "╚", "Box drawing character"),
				((char) 201, "╔", "Box drawing character"),
				((char) 202, "╩", "Box drawing character"),
				((char) 203, "╦", "Box drawing character"),
				((char) 204, "╠", "Box drawing character"),
				((char) 205, "═", "Box drawing character"),
				((char) 206, "╬", "Box drawing character"),
				((char) 207, "¤", "generic currency sign"),
				((char) 208, "ð", "lowercase\"eth\""),
				((char) 209, "Ð", "Capital letter\"Eth\""),
				((char) 210, "Ê", "letter\"E\" with circumflex accent or\"E-circumflex\""),
				((char) 211, "Ë", "letter\"E\" with umlaut or diaeresis ;\"E-umlaut\""),
				((char) 212, "È", "letter\"E\" with grave accent"),
				((char) 213, "ı", "lowercase dot less i"),
				((char) 214, "Í", "Capital letter\"I\" with acute accent or\"I-acute\""),
				((char) 215, "Î", "letter\"I\" with circumflex accent or\"I-circumflex\""),
				((char) 216, "Ï", "letter\"I\" with umlaut or diaeresis ;\"I-umlaut\""),
				((char) 217, "┘", "Box drawing character"),
				((char) 218, "┌", "Box drawing character"),
				((char) 219, "█", "Block"),
				((char) 220, "▄", "Bottom half block"),
				((char) 221, "¦", "vertical broken bar"),
				((char) 222, "Ì", "letter\"I\" with grave accent"),
				((char) 223, "▀", "Top half block"),
				((char) 224, "Ó", "Capital letter\"O\" with acute accent or\"O-acute\""),
				((char) 225, "ß", "letter\"Eszett\" ;\"scharfes S\" or\"sharp S\""),
				((char) 226, "Ô", "letter\"O\" with circumflex accent or\"O-circumflex\""),
				((char) 227, "Ò", "letter\"O\" with grave accent"),
				((char) 228, "õ", "letter\"o\" with tilde or\"o-tilde\""),
				((char) 229, "Õ", "letter\"O\" with tilde or\"O-tilde\""),
				((char) 230, "µ", "Lowercase letter\"Mu\" ; micro sign or micron"),
				((char) 231, "þ", "capital letter\"Thorn\""),
				((char) 232, "Þ", "lowercase letter\"thorn\""),
				((char) 233, "Ú", "Capital letter\"U\" with acute accent or\"U-acute\""),
				((char) 234, "Û", "letter\"U\" with circumflex accent or\"U-circumflex\""),
				((char) 235, "Ù", "letter\"U\" with grave accent"),
				((char) 236, "ý", "letter\"y\" with acute accent"),
				((char) 237, "Ý", "Capital letter\"Y\" with acute accent"),
				((char) 238, "¯", "macron symbol"),
				((char) 239, "´", "Acute accent"),
				((char) 240, "¬", "Hyphen"),
				((char) 241, "±", "Plus-minus sign"),
				((char) 242, "‗", "underline or underscore"),
				((char) 243, "¾", "three quarters"),
				((char) 244, "¶", "paragraph sign or pilcrow ; end paragraph mark "),
				((char) 245, "§", "Section sign"),
				((char) 246, "÷", "The division sign ; Obelus"),
				((char) 247, "¸", "cedilla"),
				((char) 248, "°", "degree symbol"),
				((char) 249, "¨", "Diaeresis"),
				((char) 250, "•", "Interpunct or space dot"),
				((char) 251, "¹", "superscript one"),
				((char) 252, "³", "cube or superscript three"),
				((char) 253, "²", "Square or superscript two"),
				((char) 254, "■", "black square"),
				((char) 255, "nbsp", "non-breaking space or no-break space")
			};

		/// <summary>
		///    Get frequently used.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> FrequentlyUsed =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(164) &&
				                      v.Ascii.ToInt().Equals(164) &&
				                      v.Ascii.ToInt().Equals(165) &&
				                      v.Ascii.ToInt().Equals(64) &&
				                      v.Ascii.ToInt().Equals(168) &&
				                      v.Ascii.ToInt().Equals(63) &&
				                      v.Ascii.ToInt().Equals(173) &&
				                      v.Ascii.ToInt().Equals(33) &&
				                      v.Ascii.ToInt().Equals(58) &&
				                      v.Ascii.ToInt().Equals(47) &&
				                      v.Ascii.ToInt().Equals(92));

		/// <summary>
		///    Get lowercase letters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> LowercaseLetters
		{
			get
			{
				var holder00 = Duosexagesimal.Characters.Where(c => c >= 97 && c <= 122).ToList();

				return PrintableChars.Where(printableChar => holder00.Contains(printableChar.Ascii)).ToList();
			}
		}

		/// <summary>
		///    Get mathematical symbols.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> MathematicalSymbols =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(171) &&
				                      v.Ascii.ToInt().Equals(172) &&
				                      v.Ascii.ToInt().Equals(243) &&
				                      v.Ascii.ToInt().Equals(251) &&
				                      v.Ascii.ToInt().Equals(252) &&
				                      v.Ascii.ToInt().Equals(253) &&
				                      v.Ascii.ToInt().Equals(159) &&
				                      v.Ascii.ToInt().Equals(241) &&
				                      v.Ascii.ToInt().Equals(158) &&
				                      v.Ascii.ToInt().Equals(246));

		/// <summary>
		///    Get Non letter printable characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> NonLetterPrintableChars =>
			PrintableChars.Where(printableChar => !Duosexagesimal.Characters.Contains(printableChar.Ascii)).ToList();

		/// <summary>
		///    Get non printable characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> NonPrintableChars => ControlChars;

		/// <summary>
		///    Get printable characters.
		/// </summary>
		// ReSharper disable once MemberCanBePrivate.Global
		public static IEnumerable<(char Ascii, string Character, string Description)> PrintableChars =>
			new Collections.Generic.List<(char Ascii, string Character, string Description)>
			{
				((char) 32, " ", "space"),
				((char) 33, "!", "exclamation mark"),
				((char) 34, "\"", "Quotation mark"),
				((char) 35, "#", "Number sign"),
				((char) 36, "$", "Dollar sign"),
				((char) 37, "%", "Percent sign"),
				((char) 38, "&", "Ampersand"),
				((char) 39, "'", "Apostrophe"),
				((char) 40, "(", "round brackets or parentheses, opening round bracket"),
				((char) 41, ")", "parentheses or round brackets, closing parentheses"),
				((char) 42, "*", "Asterisk"),
				((char) 43, "+", "Plus sign"),
				((char) 44, ",", "Comma"),
				((char) 45, "-", "Hyphen"),
				((char) 46, ".", "Full stop , dot"),
				((char) 47, "/", "Slash"),
				((char) 48, "0", "number zero"),
				((char) 49, "1", "number one"),
				((char) 50, "2", "number two"),
				((char) 51, "3", "number three"),
				((char) 52, "4", "number four"),
				((char) 53, "5", "number five"),
				((char) 54, "6", "number six"),
				((char) 55, "7", "number seven"),
				((char) 56, "8", "number eight"),
				((char) 57, "9", "number nine"),
				((char) 58, ":", "Colon"),
				((char) 59, ";", "Semicolon"),
				((char) 60, "<", "Less-than sign"),
				((char) 61, "=", "Equals sign"),
				((char) 62, ">", "Greater-than sign ; Inequality"),
				((char) 63, "?", "Question mark"),
				((char) 64, "@", "At sign"),
				((char) 65, "A", "Capital A"),
				((char) 66, "B", "Capital B"),
				((char) 67, "C", "Capital C"),
				((char) 68, "D", "Capital D"),
				((char) 69, "E", "Capital E"),
				((char) 70, "F", "Capital F"),
				((char) 71, "G", "Capital G"),
				((char) 72, "H", "Capital H"),
				((char) 73, "I", "Capital I"),
				((char) 74, "J", "Capital J"),
				((char) 75, "K", "Capital K"),
				((char) 76, "L", "Capital L"),
				((char) 77, "M", "Capital M"),
				((char) 78, "N", "Capital N"),
				((char) 79, "O", "Capital O"),
				((char) 80, "P", "Capital P"),
				((char) 81, "Q", "Capital Q"),
				((char) 82, "R", "Capital R"),
				((char) 83, "S", "Capital S"),
				((char) 84, "T", "Capital T"),
				((char) 85, "U", "Capital U"),
				((char) 86, "V", "Capital V"),
				((char) 87, "W", "Capital W"),
				((char) 88, "X", "Capital X"),
				((char) 89, "Y", "Capital Y"),
				((char) 90, "Z", "Capital Z"),
				((char) 91, "[", "square brackets or box brackets"),
				((char) 92, "\\", "Backslash"),
				((char) 93, "]", "square brackets or box brackets"),
				((char) 94, "^", "Caret or circumflex accent"),
				((char) 95, "_", "underscore , under-strike , under-bar or low line"),
				((char) 96, "`", "Grave accent"),
				((char) 97, "a", "Lowercase a"),
				((char) 98, "b", "Lowercase b"),
				((char) 99, "c", "Lowercase c"),
				((char) 100, "d", "Lowercase d"),
				((char) 101, "e", "Lowercase e"),
				((char) 102, "f", "Lowercase f"),
				((char) 103, "g", "Lowercase g"),
				((char) 104, "h", "Lowercase h"),
				((char) 105, "i", "Lowercase i"),
				((char) 106, "j", "Lowercase j"),
				((char) 107, "k", "Lowercase k"),
				((char) 108, "l", "Lowercase l"),
				((char) 109, "m", "Lowercase m"),
				((char) 110, "n", "Lowercase n"),
				((char) 111, "o", "Lowercase o"),
				((char) 112, "p", "Lowercase p"),
				((char) 113, "q", "Lowercase q"),
				((char) 114, "r", "Lowercase r"),
				((char) 115, "s", "Lowercase s"),
				((char) 116, "t", "Lowercase t"),
				((char) 117, "u", "Lowercase u"),
				((char) 118, "v", "Lowercase v"),
				((char) 119, "w", "Lowercase w"),
				((char) 120, "x", "Lowercase x"),
				((char) 121, "y", "Lowercase y"),
				((char) 122, "z", "Lowercase z"),
				((char) 123, "{", "curly brackets or braces"),
				((char) 124, "|", "vertical-bar, vbar, vertical line or vertical slash"),
				((char) 125, "}", "curly brackets or braces"),
				((char) 126, "~", "Tilde ; swung dash")
			};

		/// <summary>
		///    Get quotes and parenthesis.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> QuotesAndParenthesis =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(34) &&
				                      v.Ascii.ToInt().Equals(39) &&
				                      v.Ascii.ToInt().Equals(40) &&
				                      v.Ascii.ToInt().Equals(41) &&
				                      v.Ascii.ToInt().Equals(91) &&
				                      v.Ascii.ToInt().Equals(93) &&
				                      v.Ascii.ToInt().Equals(123) &&
				                      v.Ascii.ToInt().Equals(125) &&
				                      v.Ascii.ToInt().Equals(174) &&
				                      v.Ascii.ToInt().Equals(175));

		/// <summary>
		///    Get unsafe characters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> UnsafeChars =>
			AsciiCharacters.Where(c => !PrintableChars.Contains(c));

		/// <summary>
		///    Get uppercase letters.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> UppercaseLetters
		{
			get
			{
				var holder00 = Duosexagesimal.Characters.Where(c => c >= 65 && c <= 90).ToList();

				return PrintableChars.Where(printableChar => holder00.Contains(printableChar.Ascii)).ToList();
			}
		}

		/// <summary>
		///    Get vowels acute accent.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> VowelsAcuteAccent =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(160) &&
				                      v.Ascii.ToInt().Equals(130) &&
				                      v.Ascii.ToInt().Equals(161) &&
				                      v.Ascii.ToInt().Equals(162) &&
				                      v.Ascii.ToInt().Equals(163) &&
				                      v.Ascii.ToInt().Equals(181) &&
				                      v.Ascii.ToInt().Equals(144) &&
				                      v.Ascii.ToInt().Equals(214) &&
				                      v.Ascii.ToInt().Equals(224) &&
				                      v.Ascii.ToInt().Equals(233));

		/// <summary>
		///    Get vowels with diuresis.
		/// </summary>
		public static IEnumerable<(char Ascii, string Character, string Description)> VowelsWithDiuresis =>
			AsciiCharacters.Where(v =>
				                      v.Ascii.ToInt().Equals(132) &&
				                      v.Ascii.ToInt().Equals(137) &&
				                      v.Ascii.ToInt().Equals(139) &&
				                      v.Ascii.ToInt().Equals(148) &&
				                      v.Ascii.ToInt().Equals(129) &&
				                      v.Ascii.ToInt().Equals(142) &&
				                      v.Ascii.ToInt().Equals(211) &&
				                      v.Ascii.ToInt().Equals(216) &&
				                      v.Ascii.ToInt().Equals(153) &&
				                      v.Ascii.ToInt().Equals(154));
	}
}