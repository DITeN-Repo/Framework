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
// Creation Date: 2019/09/04 10:05 PM

#endregion

#region Used Directives

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace Diten.Windows.Forms
{
	public class String : Diten.String
	{
		private Color _color;

		private Font _font;
		private FontFamily _fontFamily;

		public String() => Value = string.Empty;

		public String(string value, Color color = default, Font font = default) : this()
		{
			if (value == null) value = string.Empty;
			Value = value;
			_font = font;
			_color = color;
		}

		public String(string value, FontStyle fontStyle) : this(value, default,
			new Font(new FontFamily(GenericFontFamilies.SansSerif), (float) 8.25, fontStyle))
		{
		}

		/// <summary>
		///    Color of string.
		/// </summary>
		[BsonIgnore]
		public Color Color
		{
			get => _color == default ? Color.FromKnownColor(KnownColor.WindowText) : _color;
			set => _color = value;
		}

		/// <summary>
		///    Font of string.
		/// </summary>
		[BsonIgnore]
		public Font Font
		{
			get => _font ?? (_font = new Font(FontFamily, (float) 8.25));
			set => _font = value;
		}

		/// <summary>
		///    Font of string.
		/// </summary>
		[BsonIgnore]
		public FontFamily FontFamily
		{
			get => _fontFamily ?? (_fontFamily = new FontFamily(GenericFontFamilies.SansSerif));
			set => _fontFamily = value;
		}

		/// <inheritdoc />
		/// <summary>
		///    Getting hash code of <see cref="T:Diten.String" /> value.
		/// </summary>
		/// <returns>A hash code of <see cref="T:Diten.String" /> value.</returns>
		public override int GetHashCode()
		{
			var hashCode = base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
			hashCode = hashCode * -1521134295 + EqualityComparer<Font>.Default.GetHashCode(Font);
			return hashCode;
		}


		/// <summary>
		///    Casting <see cref="System.String" /> to <see cref="Diten.Windows.Forms.String" />
		/// </summary>
		/// <param name="value">A <see cref="Diten.Windows.Forms.String" />.</param>
		public static implicit operator String(string value) => new String {Value = value};

		/// <summary>
		///    Casting <see cref="Diten.Windows.Forms.String" /> to <see cref="System.String" />
		/// </summary>
		/// <param name="value">A <see cref="System.String" />.</param>
		public static implicit operator string(String value) => value.Value;
	}
}