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
// Creation Date: 2019/09/04 6:56 PM

#region Used Directives

using System;
using System.Collections;
using System.ComponentModel;

#endregion

namespace Diten.Numeric
{
	/// <summary>
	///    A Byte that could be base of many other objects.
	/// </summary>
	[DefaultProperty("Value")]
	public class DByte: IDBit<bool>
	{
		/// <summary>
		///    Default constructor.
		/// </summary>
		public DByte(int length = 8) { Value = new BitArray(length); }

		#region Implementation of IComparable

		public Int32 CompareTo(System.Object obj) { throw new NotImplementedException(); }

		#endregion

		#region Implementation of IComparable<in bool>

		public Int32 CompareTo(bool other) { throw new NotImplementedException(); }

		#endregion

		#region Implementation of IEquatable<bool>

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///    true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise,
		///    false.
		/// </returns>
		public Boolean Equals(bool other) { throw new NotImplementedException(); }

		#endregion

		#region Implementation of IFormattable

		/// <summary>Formats the value of the current instance using the specified format.</summary>
		/// <param name="format">
		///    The format to use.   -or-   A null reference (Nothing in Visual Basic) to use the default format
		///    defined for the type of the <see cref="T:System.IFormattable"></see> implementation.
		/// </param>
		/// <param name="formatProvider">
		///    The provider to use to format the value.   -or-   A null reference (Nothing in Visual
		///    Basic) to obtain the numeric format information from the current locale setting of the operating system.
		/// </param>
		/// <returns>The value of the current instance in the specified format.</returns>
		public System.String ToString(System.String format,
		                       IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IDBit<bool>

		/// <summary>
		///    Value of the DBit.
		/// </summary>
		public BitArray Value {get; set;}

		#endregion

		#region Implementation of IConvertible

		/// <summary>Returns the <see cref="T:System.TypeCode"></see> for this instance.</summary>
		/// <returns>
		///    The enumerated constant that is the <see cref="T:System.TypeCode"></see> of the class or value type that
		///    implements this interface.
		/// </returns>
		public TypeCode GetTypeCode() { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent Boolean value using the specified culture-specific
		///    formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A Boolean value equivalent to the value of this instance.</returns>
		public Boolean ToBoolean(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 8-bit unsigned integer equivalent to the value of this instance.</returns>
		public byte ToByte(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent Unicode character using the specified culture-specific
		///    formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A Unicode character equivalent to the value of this instance.</returns>
		public char ToChar(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent <see cref="T:System.DateTime"></see> using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A <see cref="T:System.DateTime"></see> instance equivalent to the value of this instance.</returns>
		public DateTime ToDateTime(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent <see cref="T:System.Decimal"></see> number using the
		///    specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A <see cref="T:System.Decimal"></see> number equivalent to the value of this instance.</returns>
		public decimal ToDecimal(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent double-precision floating-point number using the
		///    specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A double-precision floating-point number equivalent to the value of this instance.</returns>
		public double ToDouble(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 16-bit signed integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 16-bit signed integer equivalent to the value of this instance.</returns>
		public Int16 ToInt16(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 32-bit signed integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 32-bit signed integer equivalent to the value of this instance.</returns>
		public Int32 ToInt32(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 64-bit signed integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 64-bit signed integer equivalent to the value of this instance.</returns>
		public long ToInt64(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific
		///    formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 8-bit signed integer equivalent to the value of this instance.</returns>
		public sbyte ToSByte(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent single-precision floating-point number using the
		///    specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A single-precision floating-point number equivalent to the value of this instance.</returns>
		public float ToSingle(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent <see cref="T:System.String"></see> using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>A <see cref="T:System.String"></see> instance equivalent to the value of this instance.</returns>
		public System.String ToString(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an <see cref="T:System.Object"></see> of the specified
		///    <see cref="T:System.Type"></see> that has an equivalent value, using the specified culture-specific formatting
		///    information.
		/// </summary>
		/// <param name="conversionType">The <see cref="T:System.Type"></see> to which the value of this instance is converted.</param>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>
		///    An <see cref="T:System.Object"></see> instance of type
		///    <paramref name="conversionType">conversionType</paramref> whose value is equivalent to the value of this instance.
		/// </returns>
		public object ToType(Type conversionType,
		                     IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///    Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 16-bit unsigned integer equivalent to the value of this instance.</returns>
		public ushort ToUInt16(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 32-bit unsigned integer equivalent to the value of this instance.</returns>
		public uint ToUInt32(IFormatProvider provider) { throw new NotImplementedException(); }

		/// <summary>
		///    Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified
		///    culture-specific formatting information.
		/// </summary>
		/// <param name="provider">
		///    An <see cref="T:System.IFormatProvider"></see> interface implementation that supplies
		///    culture-specific formatting information.
		/// </param>
		/// <returns>An 64-bit unsigned integer equivalent to the value of this instance.</returns>
		public ulong ToUInt64(IFormatProvider provider) { throw new NotImplementedException(); }

		#endregion
	}
}