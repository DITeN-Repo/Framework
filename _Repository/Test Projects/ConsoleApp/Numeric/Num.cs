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

#endregion

namespace Diten.Numeric
{
	public class Num<TNumeric>: object,
	                            IDBit<TNumeric>
		where TNumeric: IComparable, IFormattable, IConvertible, IComparable<TNumeric>, IEquatable<TNumeric>
	{
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			if (!(obj is TNumeric)) throw new ArgumentException(Exceptions.Default.Diten_Numeric_Number_CompareTo_PObject);
			var num = (TNumeric) obj;

			if (this < num) return -1;

			return this > num ? 1 : 0;
			return ((IComparable) this).CompareTo(obj);
		}

		public int CompareTo(TNumeric other) { throw new NotImplementedException(); }

		public bool Equals(TNumeric other) { throw new NotImplementedException(); }

		public TypeCode GetTypeCode() { throw new NotImplementedException(); }

		public bool ToBoolean(IFormatProvider provider) { throw new NotImplementedException(); }

		public byte ToByte(IFormatProvider provider) { throw new NotImplementedException(); }

		public char ToChar(IFormatProvider provider) { throw new NotImplementedException(); }

		public DateTime ToDateTime(IFormatProvider provider) { throw new NotImplementedException(); }

		public decimal ToDecimal(IFormatProvider provider) { throw new NotImplementedException(); }

		public double ToDouble(IFormatProvider provider) { throw new NotImplementedException(); }

		public short ToInt16(IFormatProvider provider) { throw new NotImplementedException(); }

		public int ToInt32(IFormatProvider provider) { throw new NotImplementedException(); }

		public long ToInt64(IFormatProvider provider) { throw new NotImplementedException(); }

		public sbyte ToSByte(IFormatProvider provider) { throw new NotImplementedException(); }

		public float ToSingle(IFormatProvider provider) { throw new NotImplementedException(); }

		public string ToString(IFormatProvider provider) { throw new NotImplementedException(); }

		public string ToString(System.String format,
		                       IFormatProvider formatProvider)
		{
			throw new NotImplementedException();
		}

		public object ToType(Type conversionType,
		                     IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ushort ToUInt16(IFormatProvider provider) { throw new NotImplementedException(); }

		public uint ToUInt32(IFormatProvider provider) { throw new NotImplementedException(); }

		public ulong ToUInt64(IFormatProvider provider) { throw new NotImplementedException(); }
	}
}