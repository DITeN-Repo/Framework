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

#region Using Directives

#endregion

namespace Diten.Numeric
{
	///// <summary>Represents a 32-bit signed integer.</summary>
	//[ComVisible(true)]
	//[Serializable]
	//public class Number<TNumeric> : Object<TNumeric>, IComparable, IFormattable, System.IConvertible, IComparable<TNumeric>,IEquatable<TNumeric>
	//where TNumeric : IComparable, IFormattable, System.IConvertible, IComparable<TNumeric>, IEquatable<TNumeric>
	//{

	//	/// <inheritdoc />
	//	public int CompareTo(object value)
	//	{
	//		if(obj==null)
	//			return 1;
	//		if(!(obj is TNumeric))
	//			throw new ArgumentException(Parameters.Exceptions.Default.Diten_Numeric_Number_CompareTo_PObject);
	//		var num = (TNumeric)obj;
	//		if(this<num)
	//			return -1;
	//		return this>num ? 1 : 0;
	//		return ((IComparable) this).CompareTo(value);
	//	}

	//	/// <inheritdoc />
	//	public int CompareTo(TNumeric other)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public System.TypeCode GetTypeCode()
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public bool ToBoolean(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public char ToChar(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public sbyte ToSByte(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public byte ToByte(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public short ToInt16(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public ushort ToUInt16(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public int ToInt32(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public uint ToUInt32(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public long ToInt64(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public ulong ToUInt64(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public float ToSingle(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public double ToDouble(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public decimal ToDecimal(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public DateTime ToDateTime(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public string ToString(System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public object ToType(Type conversionType, System.IFormatProvider provider)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public bool Equals(TNumeric other)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	/// <inheritdoc />
	//	public string ToString(System.String format, System.IFormatProvider formatProvider)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}

	///// <summary>Represents a 32-bit signed integer.</summary>
	//[ComVisible(true)]

	//[Serializable]
	//public struct Int32:IComparable, IFormattable, System.IConvertible, IComparable<int>, IEquatable<int>
	//{
	//	internal int m_value;
	//	/// <summary>Represents the largest possible value of an <see cref="T:System.Int32" />. This field is constant.</summary>

	//	public const int MaxValue = 2147483647;
	//	/// <summary>Represents the smallest possible value of <see cref="T:System.Int32" />. This field is constant.</summary>

	//	public const int MinValue = -2147483648;

	//	/// <summary>Compares this instance to a specified object and returns an indication of their relative values.</summary>
	//	/// <param name="value">An object to compare, or <see langword="null" />.</param>
	//	/// <returns>A signed number indicating the relative values of this instance and <paramref name="value" />.
	//	///  Return Value
	//	/// 
	//	///  Description
	//	/// 
	//	///  Less than zero
	//	/// 
	//	///  This instance is less than <paramref name="value" />.
	//	/// 
	//	///  Zero
	//	/// 
	//	///  This instance is equal to <paramref name="value" />.
	//	/// 
	//	///  Greater than zero
	//	/// 
	//	///  This instance is greater than <paramref name="value" />.
	//	/// 
	//	/// -or-
	//	/// 
	//	/// <paramref name="value" /> is <see langword="null" />.</returns>
	//	/// <exception cref="T:System.ArgumentException">
	//	/// <paramref name="value" /> is not an <see cref="T:System.Int32" />.</exception>
	//	public int CompareTo(object value)
	//	{
	//		if(value==null)
	//			return 1;
	//		if(!(value is int))
	//			throw new ArgumentException(System.Environment.GetResourceString("Arg_MustBeInt32"));
	//		int num = (int)value;
	//		if(this<num)
	//			return -1;
	//		return this>num ? 1 : 0;
	//	}

	//	/// <summary>Compares this instance to a specified 32-bit signed integer and returns an indication of their relative values.</summary>
	//	/// <param name="value">An integer to compare.</param>
	//	/// <returns>A signed number indicating the relative values of this instance and <paramref name="value" />.
	//	/// Return Value
	//	/// 
	//	/// Description
	//	/// 
	//	/// Less than zero
	//	/// 
	//	/// This instance is less than <paramref name="value" />.
	//	/// 
	//	/// Zero
	//	/// 
	//	/// This instance is equal to <paramref name="value" />.
	//	/// 
	//	/// Greater than zero
	//	/// 
	//	/// This instance is greater than <paramref name="value" />.</returns>

	//	public int CompareTo(int value)
	//	{
	//		if(this<value)
	//			return -1;
	//		return this>value ? 1 : 0;
	//	}

	//	/// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
	//	/// <param name="obj">An object to compare with this instance.</param>
	//	/// <returns>
	//	/// <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="T:System.Int32" /> and equals the value of this instance; otherwise, <see langword="false" />.</returns>

	//	public override bool Equals(object obj)
	//	{
	//		if(!(obj is int))
	//			return false;
	//		return this==(int)obj;
	//	}

	//	/// <summary>Returns a value indicating whether this instance is equal to a specified <see cref="T:System.Int32" /> value.</summary>
	//	/// <param name="obj">An <see cref="T:System.Int32" /> value to compare to this instance.</param>
	//	/// <returns>
	//	/// <see langword="true" /> if <paramref name="obj" /> has the same value as this instance; otherwise, <see langword="false" />.</returns>

	//	public bool Equals(int obj)
	//	{
	//		return this==obj;
	//	}

	//	/// <summary>Returns the hash code for this instance.</summary>
	//	/// <returns>A 32-bit signed integer hash code.</returns>

	//	public override int GetHashCode()
	//	{
	//		return this;
	//	}

	//	/// <summary>Converts the numeric value of this instance to its equivalent string representation.</summary>
	//	/// <returns>The string representation of the value of this instance, consisting of a negative sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
	//	[SecuritySafeCritical]

	//	public override string ToString()
	//	{
	//		return Number.FormatInt32(this, (System.String)null, NumberFormatInfo.CurrentInfo);
	//	}

	//	/// <summary>Converts the numeric value of this instance to its equivalent string representation, using the specified format.</summary>
	//	/// <param name="format">A standard or custom numeric format string.</param>
	//	/// <returns>The string representation of the value of this instance as specified by <paramref name="format" />.</returns>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="format" /> is invalid or not supported.</exception>
	//	[SecuritySafeCritical]

	//	public string ToString(System.String format)
	//	{
	//		return Number.FormatInt32(this, format, NumberFormatInfo.CurrentInfo);
	//	}

	//	/// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</summary>
	//	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	//	/// <returns>The string representation of the value of this instance as specified by <paramref name="provider" />.</returns>
	//	[SecuritySafeCritical]

	//	public string ToString(System.IFormatProvider provider)
	//	{
	//		return Number.FormatInt32(this, (System.String)null, NumberFormatInfo.GetInstance(provider));
	//	}

	//	/// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.</summary>
	//	/// <param name="format">A standard or custom numeric format string.</param>
	//	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	//	/// <returns>The string representation of the value of this instance as specified by <paramref name="format" /> and <paramref name="provider" />.</returns>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="format" /> is invalid or not supported.</exception>
	//	[SecuritySafeCritical]

	//	public string ToString(System.String format, System.IFormatProvider provider)
	//	{
	//		return Number.FormatInt32(this, format, NumberFormatInfo.GetInstance(provider));
	//	}

	//	/// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent.</summary>
	//	/// <param name="s">A string containing a number to convert.</param>
	//	/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="s" />.</returns>
	//	/// <exception cref="T:System.ArgumentNullException">
	//	/// <paramref name="s" /> is <see langword="null" />.</exception>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="s" /> is not in the correct format.</exception>
	//	/// <exception cref="T:System.OverflowException">
	//	/// <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />.</exception>

	//	public static int Parse(System.String s)
	//	{
	//		return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
	//	}

	//	/// <summary>Converts the string representation of a number in a specified style to its 32-bit signed integer equivalent.</summary>
	//	/// <param name="s">A string containing a number to convert.</param>
	//	/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	//	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	//	/// <exception cref="T:System.ArgumentNullException">
	//	/// <paramref name="s" /> is <see langword="null" />.</exception>
	//	/// <exception cref="T:System.ArgumentException">
	//	///         <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	//	/// -or-
	//	/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="s" /> is not in a format compliant with <paramref name="style" />.</exception>
	//	/// <exception cref="T:System.OverflowException">
	//	///         <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />.
	//	/// -or-
	//	/// <paramref name="s" /> includes non-zero, fractional digits.</exception>

	//	public static int Parse(System.String s, NumberStyles style)
	//	{
	//		NumberFormatInfo.ValidateParseStyleInteger(style);
	//		return Number.ParseInt32(s, style, NumberFormatInfo.CurrentInfo);
	//	}

	//	/// <summary>Converts the string representation of a number in a specified culture-specific format to its 32-bit signed integer equivalent.</summary>
	//	/// <param name="s">A string containing a number to convert.</param>
	//	/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
	//	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	//	/// <exception cref="T:System.ArgumentNullException">
	//	/// <paramref name="s" /> is <see langword="null" />.</exception>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="s" /> is not of the correct format.</exception>
	//	/// <exception cref="T:System.OverflowException">
	//	/// <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />.</exception>

	//	public static int Parse(System.String s, System.IFormatProvider provider)
	//	{
	//		return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.GetInstance(provider));
	//	}

	//	/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.</summary>
	//	/// <param name="s">A string containing a number to convert.</param>
	//	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	//	/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="s" />.</param>
	//	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	//	/// <exception cref="T:System.ArgumentNullException">
	//	/// <paramref name="s" /> is <see langword="null" />.</exception>
	//	/// <exception cref="T:System.ArgumentException">
	//	///         <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	//	/// -or-
	//	/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
	//	/// <exception cref="T:System.FormatException">
	//	/// <paramref name="s" /> is not in a format compliant with <paramref name="style" />.</exception>
	//	/// <exception cref="T:System.OverflowException">
	//	///         <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />.
	//	/// -or-
	//	/// <paramref name="s" /> includes non-zero, fractional digits.</exception>

	//	public static int Parse(System.String s, NumberStyles style, System.IFormatProvider provider)
	//	{
	//		NumberFormatInfo.ValidateParseStyleInteger(style);
	//		return Number.ParseInt32(s, style, NumberFormatInfo.GetInstance(provider));
	//	}

	//	/// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	//	/// <param name="s">A string containing a number to convert.</param>
	//	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not of the correct format, or represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	//	/// <returns>
	//	/// <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>

	//	public static bool TryParse(System.String s, out int result)
	//	{
	//		return Number.TryParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
	//	}

	//	/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	//	/// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
	//	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	//	/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
	//	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not in a format compliant with <paramref name="style" />, or represents a number less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	//	/// <returns>
	//	/// <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	//	/// <exception cref="T:System.ArgumentException">
	//	///         <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	//	/// -or-
	//	/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>

	//	public static bool TryParse(
	//	  string s,
	//	  NumberStyles style,
	//	  System.IFormatProvider provider,
	//	  out int result)
	//	{
	//		NumberFormatInfo.ValidateParseStyleInteger(style);
	//		return Number.TryParseInt32(s, style, NumberFormatInfo.GetInstance(provider), out result);
	//	}

	//	/// <summary>Returns the <see cref="T:System.TypeCode" /> for value type <see cref="T:System.Int32" />.</summary>
	//	/// <returns>The enumerated constant, <see cref="F:System.TypeCode.Int32" />.</returns>
	//	public System.TypeCode GetTypeCode()
	//	{
	//		return System.TypeCode.Int32;
	//	}

	//	bool System.IConvertible.ToBoolean(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToBoolean(this);
	//	}

	//	char System.IConvertible.ToChar(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToChar(this);
	//	}

	//	sbyte System.IConvertible.ToSByte(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToSByte(this);
	//	}

	//	byte System.IConvertible.ToByte(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToByte(this);
	//	}

	//	short System.IConvertible.ToInt16(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToInt16(this);
	//	}

	//	ushort System.IConvertible.ToUInt16(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToUInt16(this);
	//	}

	//	int System.IConvertible.ToInt32(System.IFormatProvider provider)
	//	{
	//		return this;
	//	}

	//	uint System.IConvertible.ToUInt32(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToUInt32(this);
	//	}

	//	long System.IConvertible.ToInt64(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToInt64(this);
	//	}

	//	ulong System.IConvertible.ToUInt64(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToUInt64(this);
	//	}

	//	float System.IConvertible.ToSingle(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToSingle(this);
	//	}

	//	double System.IConvertible.ToDouble(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToDouble(this);
	//	}

	//	Decimal System.IConvertible.ToDecimal(System.IFormatProvider provider)
	//	{
	//		return System.Convert.ToDecimal(this);
	//	}

	//	DateTime System.IConvertible.ToDateTime(System.IFormatProvider provider)
	//	{
	//		throw new InvalidCastException(System.Environment.GetResourceString("InvalidCast_FromTo", (object)nameof(System.Int32), (object)"DateTime"));
	//	}

	//	object System.IConvertible.ToType(Type type, System.IFormatProvider provider)
	//	{
	//		return System.Convert.DefaultToType((System.IConvertible)this, type, provider);
	//	}
	//}
}