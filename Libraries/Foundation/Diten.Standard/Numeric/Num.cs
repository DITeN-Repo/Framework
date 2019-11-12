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

#endregion

//namespace Diten.Numeric
//{
//	public class Num<TNumeric> : Object<TNumeric>, IDBit<TNumeric>
//		where TNumeric : IComparable, IFormattable, IConvertible, IComparable<TNumeric>, IEquatable<TNumeric>
//	{
//		public Int32 CompareTo(System.Object obj)
//		{
//			if (obj == null)
//				return 1;
//			if (!(obj is TNumeric))
//				throw new ArgumentException(Exceptions.Default.Diten_Numeric_Number_CompareTo_PObject);
//			var num = (TNumeric) obj;
//			if (this < num)
//				return -1;
//			return this > num ? 1 : 0;
//			return ((IComparable) this).CompareTo(obj);
//		}

//		public Int32 CompareTo(TNumeric other) => throw new NotImplementedException();

//		public Boolean Equals(TNumeric other) => throw new NotImplementedException();

//		public TypeCode GetTypeCode() => throw new NotImplementedException();

//		public Boolean ToBoolean(IFormatProvider provider) => throw new NotImplementedException();

//		public byte ToByte(IFormatProvider provider) => throw new NotImplementedException();

//		public char ToChar(IFormatProvider provider) => throw new NotImplementedException();

//		public DateTime ToDateTime(IFormatProvider provider) => throw new NotImplementedException();

//		public decimal ToDecimal(IFormatProvider provider) => throw new NotImplementedException();

//		public double ToDouble(IFormatProvider provider) => throw new NotImplementedException();

//		public Int16 ToInt16(IFormatProvider provider) => throw new NotImplementedException();

//		public Int32 ToInt32(IFormatProvider provider) => throw new NotImplementedException();

//		public long ToInt64(IFormatProvider provider) => throw new NotImplementedException();

//		public sbyte ToSByte(IFormatProvider provider) => throw new NotImplementedException();

//		public float ToSingle(IFormatProvider provider) => throw new NotImplementedException();

//		public System.String ToString(IFormatProvider provider) => throw new NotImplementedException();

//		public System.String ToString(System.String format, IFormatProvider formatProvider) => throw new NotImplementedException();

//		public object ToType(Type conversionType, IFormatProvider provider) => throw new NotImplementedException();

//		public ushort ToUInt16(IFormatProvider provider) => throw new NotImplementedException();

//		public uint ToUInt32(IFormatProvider provider) => throw new NotImplementedException();

//		public ulong ToUInt64(IFormatProvider provider) => throw new NotImplementedException();
//	}
//}
