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

//using System;
//using Microsoft.Win32;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Runtime.ConstrainedExecution;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Text;
//using System.Threading;

//namespace Diten
//{
//    /// <summary>Represents text as a sequence of UTF-16 code units.To browse the .NET Framework source code for this type, see the Reference Source.</summary>
//    [ComVisible(true)]

//    [Serializable]
//    public sealed class StringBase : IComparable, ICloneable, System.IConvertible, IEnumerable, IComparable<string>, IEnumerable<char>, IEquatable<string>
//    {
//        [NonSerialized]
//        private int m_stringLength;
//        [NonSerialized]
//        private char m_firstChar;
//        private const int TrimHead = 0;
//        private const int TrimTail = 1;
//        private const int TrimBoth = 2;
//        /// <summary>Represents the empty string. This field is read-only.</summary>

//        public static readonly StringBase Empty;
//        private const int charPtrAlignConst = 1;
//        private const int alignConst = 3;

//        /// <summary>Concatenates all the elements of a StringBase array, using the specified separator between each element. </summary>
//        /// <param name="separator">The StringBase to use as a separator. <paramref name="separator" /> is included in the returned StringBase only if <paramref name="value" /> has more than one element.</param>
//        /// <param name="value">An array that contains the elements to concatenate. </param>
//        /// <returns>A StringBase that consists of the elements in <paramref name="value" /> delimited by the <paramref name="separator" /> string. If <paramref name="value" /> is an empty array, the method returns <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public static StringBase Join(StringBase separator, params string[] value)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            return string.Join(separator, value, 0, value.Length);
//        }

//        /// <summary>Concatenates the elements of an object array, using the specified separator between each element.</summary>
//        /// <param name="separator">The StringBase to use as a separator. <paramref name="separator" /> is included in the returned StringBase only if <paramref name="values" /> has more than one element.</param>
//        /// <param name="values">An array that contains the elements to concatenate.</param>
//        /// <returns>A StringBase that consists of the elements of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> is an empty array, the method returns <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        [ComVisible(false)]

//        public static StringBase Join(StringBase separator, params object[] values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            if (values.Length == 0 || values[0] == null)
//                return string.Empty;
//            if (separator == null)
//                separator = string.Empty;
//            StringBuilder sb = StringBuilderCache.Acquire(16);
//            StringBase str1 = values[0].ToString();
//            if (str1 != null)
//                sb.Append(str1);
//            for (int index = 1; index < values.Length; ++index)
//            {
//                sb.Append(separator);
//                if (values[index] != null)
//                {
//                    StringBase str2 = values[index].ToString();
//                    if (str2 != null)
//                        sb.Append(str2);
//                }
//            }
//            return StringBuilderCache.GetStringAndRelease(sb);
//        }

//        /// <summary>Concatenates the members of a collection, using the specified separator between each member.</summary>
//        /// <param name="separator">The StringBase to use as a separator.<paramref name="separator" /> is included in the returned StringBase only if <paramref name="values" /> has more than one element.</param>
//        /// <param name="values">A collection that contains the objects to concatenate.</param>
//        /// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
//        /// <returns>A StringBase that consists of the members of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        [ComVisible(false)]

//        public static StringBase Join<T>(StringBase separator, IEnumerable<T> values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            if (separator == null)
//                separator = string.Empty;
//            using (IEnumerator<T> enumerator = values.GetEnumerator())
//            {
//                if (!enumerator.MoveNext())
//                    return string.Empty;
//                StringBuilder sb = StringBuilderCache.Acquire(16);
//                if ((object)enumerator.Current != null)
//                {
//                    StringBase str = enumerator.Current.ToString();
//                    if (str != null)
//                        sb.Append(str);
//                }
//                while (enumerator.MoveNext())
//                {
//                    sb.Append(separator);
//                    if ((object)enumerator.Current != null)
//                    {
//                        StringBase str = enumerator.Current.ToString();
//                        if (str != null)
//                            sb.Append(str);
//                    }
//                }
//                return StringBuilderCache.GetStringAndRelease(sb);
//            }
//        }

//        /// <summary>Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />, using the specified separator between each member.</summary>
//        /// <param name="separator">The StringBase to use as a separator.<paramref name="separator" /> is included in the returned StringBase only if <paramref name="values" /> has more than one element.</param>
//        /// <param name="values">A collection that contains the strings to concatenate.</param>
//        /// <returns>A StringBase that consists of the members of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        [ComVisible(false)]

//        public static StringBase Join(StringBase separator, IEnumerable<string> values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            if (separator == null)
//                separator = string.Empty;
//            using (IEnumerator<string> enumerator = values.GetEnumerator())
//            {
//                if (!enumerator.MoveNext())
//                    return string.Empty;
//                StringBuilder sb = StringBuilderCache.Acquire(16);
//                if (enumerator.Current != null)
//                    sb.Append(enumerator.Current);
//                while (enumerator.MoveNext())
//                {
//                    sb.Append(separator);
//                    if (enumerator.Current != null)
//                        sb.Append(enumerator.Current);
//                }
//                return StringBuilderCache.GetStringAndRelease(sb);
//            }
//        }

//        internal char FirstChar
//        {
//            get
//            {
//                return this.m_firstChar;
//            }
//        }

//        /// <summary>Concatenates the specified elements of a StringBase array, using the specified separator between each element. </summary>
//        /// <param name="separator">The StringBase to use as a separator. <paramref name="separator" /> is included in the returned StringBase only if <paramref name="value" /> has more than one element.</param>
//        /// <param name="value">An array that contains the elements to concatenate. </param>
//        /// <param name="startIndex">The first element in <paramref name="value" /> to use. </param>
//        /// <param name="count">The number of elements of <paramref name="value" /> to use. </param>
//        /// <returns>A StringBase that consists of the strings in <paramref name="value" /> delimited by the <paramref name="separator" /> string. -or-
//        /// <see cref="F:System.String.Empty" /> if <paramref name="count" /> is zero, <paramref name="value" /> has no elements, or <paramref name="separator" /> and all the elements of <paramref name="value" /> are <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="count" /> is less than 0.-or-
//        /// <paramref name="startIndex" /> plus <paramref name="count" /> is greater than the number of elements in <paramref name="value" />. </exception>
//        /// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>
//        [SecuritySafeCritical]

//        public static unsafe StringBase Join(StringBase separator, string[] value, int startIndex, int count)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
//            if (startIndex > value.Length - count)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
//            if (separator == null)
//                separator = string.Empty;
//            if (count == 0)
//                return string.Empty;
//            int num1 = 0;
//            int num2 = startIndex + count - 1;
//            for (int index = startIndex; index <= num2; ++index)
//            {
//                if (value[index] != null)
//                    num1 += value[index].Length;
//            }
//            int num3 = num1 + (count - 1) * separator.Length;
//            if (num3 < 0 || num3 + 1 < 0)
//                throw new OutOfMemoryException();
//            if (num3 == 0)
//                return string.Empty;
//            StringBase str = string.FastAllocateString(num3);
//            fixed (char* buffer = &str.m_firstChar)
//            {
//                UnSafeCharBuffer unSafeCharBuffer = new UnSafeCharBuffer(buffer, num3);
//                unSafeCharBuffer.AppendString(value[startIndex]);
//                for (int index = startIndex + 1; index <= num2; ++index)
//                {
//                    unSafeCharBuffer.AppendString(separator);
//                    unSafeCharBuffer.AppendString(value[index]);
//                }
//            }
//            return str;
//        }

//        [SecuritySafeCritical]
//        private static unsafe int CompareOrdinalIgnoreCaseHelper(StringBase strA, StringBase strB)
//        {
//            int num1 = Math.Min(strA.Length, strB.Length);
//            fixed (char* chPtr1 = &strA.m_firstChar)
//            fixed (char* chPtr2 = &strB.m_firstChar)
//            {
//                char* chPtr3 = chPtr1;
//                char* chPtr4 = chPtr2;
//                for (; num1 != 0; --num1)
//                {
//                    int num2 = (int)*chPtr3;
//                    int num3 = (int)*chPtr4;
//                    if ((uint)(num2 - 97) <= 25U)
//                        num2 -= 32;
//                    if ((uint)(num3 - 97) <= 25U)
//                        num3 -= 32;
//                    if (num2 != num3)
//                        return num2 - num3;
//                    chPtr3 += 2;
//                    chPtr4 += 2;
//                }
//                return strA.Length - strB.Length;
//            }
//        }

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal static extern int nativeCompareOrdinalEx(StringBase strA, int indexA, StringBase strB, int indexB, int count);

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal static extern unsafe int nativeCompareOrdinalIgnoreCaseWC(StringBase strA, sbyte* strBBytes);

//        [SecuritySafeCritical]
//        internal static unsafe StringBase SmallCharToUpper(StringBase strIn)
//        {
//            int length = strIn.Length;
//            StringBase str = string.FastAllocateString(length);
//            fixed (char* chPtr1 = &strIn.m_firstChar)
//            fixed (char* chPtr2 = &str.m_firstChar)
//            {
//                for (int index = 0; index < length; ++index)
//                {
//                    int num = (int)chPtr1[index];
//                    if ((uint)(num - 97) <= 25U)
//                        num -= 32;
//                    chPtr2[index] = (char)num;
//                }
//            }
//            return str;
//        }

//        [SecuritySafeCritical]
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
//        private static unsafe bool EqualsHelper(StringBase strA, StringBase strB)
//        {
//            int length = strA.Length;
//            fixed (char* chPtr1 = &strA.m_firstChar)
//            fixed (char* chPtr2 = &strB.m_firstChar)
//            {
//                char* chPtr3 = chPtr1;
//                char* chPtr4 = chPtr2;
//                while (length >= 10)
//                {
//                    if (*(int*)chPtr3 != *(int*)chPtr4 || *(int*)(chPtr3 + 2) != *(int*)(chPtr4 + 2) || (*(int*)(chPtr3 + 4) != *(int*)(chPtr4 + 4) || *(int*)(chPtr3 + 6) != *(int*)(chPtr4 + 6)) || *(int*)(chPtr3 + 8) != *(int*)(chPtr4 + 8))
//                        return false;
//                    chPtr3 += 10;
//                    chPtr4 += 10;
//                    length -= 10;
//                }
//                while (length > 0 && *(int*)chPtr3 == *(int*)chPtr4)
//                {
//                    chPtr3 += 2;
//                    chPtr4 += 2;
//                    length -= 2;
//                }
//                return length <= 0;
//            }
//        }

//        [SecuritySafeCritical]
//        private static unsafe bool EqualsIgnoreCaseAsciiHelper(StringBase strA, StringBase strB)
//        {
//            int length = strA.Length;
//            fixed (char* chPtr1 = &strA.m_firstChar)
//            fixed (char* chPtr2 = &strB.m_firstChar)
//            {
//                char* chPtr3 = chPtr1;
//                char* chPtr4 = chPtr2;
//                for (; length != 0; --length)
//                {
//                    int num1 = (int)*chPtr3;
//                    int num2 = (int)*chPtr4;
//                    if (num1 != num2 && ((num1 | 32) != (num2 | 32) || (uint)((num1 | 32) - 97) > 25U))
//                        return false;
//                    chPtr3 += 2;
//                    chPtr4 += 2;
//                }
//                return true;
//            }
//        }

//        [SecuritySafeCritical]
//        private static unsafe int CompareOrdinalHelper(StringBase strA, StringBase strB)
//        {
//            int num1 = Math.Min(strA.Length, strB.Length);
//            int num2 = -1;
//            fixed (char* chPtr1 = &strA.m_firstChar)
//            fixed (char* chPtr2 = &strB.m_firstChar)
//            {
//                char* chPtr3 = chPtr1;
//                char* chPtr4 = chPtr2;
//                while (num1 >= 10)
//                {
//                    if (*(int*)chPtr3 != *(int*)chPtr4)
//                    {
//                        num2 = 0;
//                        break;
//                    }
//                    if (*(int*)(chPtr3 + 2) != *(int*)(chPtr4 + 2))
//                    {
//                        num2 = 2;
//                        break;
//                    }
//                    if (*(int*)(chPtr3 + 4) != *(int*)(chPtr4 + 4))
//                    {
//                        num2 = 4;
//                        break;
//                    }
//                    if (*(int*)(chPtr3 + 6) != *(int*)(chPtr4 + 6))
//                    {
//                        num2 = 6;
//                        break;
//                    }
//                    if (*(int*)(chPtr3 + 8) != *(int*)(chPtr4 + 8))
//                    {
//                        num2 = 8;
//                        break;
//                    }
//                    chPtr3 += 10;
//                    chPtr4 += 10;
//                    num1 -= 10;
//                }
//                if (num2 != -1)
//                {
//                    char* chPtr5 = chPtr3 + num2;
//                    char* chPtr6 = chPtr4 + num2;
//                    int num3;
//                    if ((num3 = (int)*chPtr5 - (int)*chPtr6) != 0)
//                        return num3;
//                    return (int)*(ushort*)((IntPtr)chPtr5 + 2) - (int)*(ushort*)((IntPtr)chPtr6 + 2);
//                }
//                while (num1 > 0 && *(int*)chPtr3 == *(int*)chPtr4)
//                {
//                    chPtr3 += 2;
//                    chPtr4 += 2;
//                    num1 -= 2;
//                }
//                if (num1 <= 0)
//                    return strA.Length - strB.Length;
//                int num4;
//                if ((num4 = (int)*chPtr3 - (int)*chPtr4) != 0)
//                    return num4;
//                return (int)*(ushort*)((IntPtr)chPtr3 + 2) - (int)*(ushort*)((IntPtr)chPtr4 + 2);
//            }
//        }

//        /// <summary>Determines whether this instance and a specified object, which must also be a <see cref="T:System.String" /> object, have the same value.</summary>
//        /// <param name="obj">The StringBase to compare to this instance. </param>
//        /// <returns>
//        /// <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.String" /> and its value is the same as this instance; otherwise, <see langword="false" />.  If <paramref name="obj" /> is <see langword="null" />, the method returns <see langword="false" />.</returns>
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]

//        public override bool Equals(object obj)
//        {
//            if (this == null)
//                throw new NullReferenceException();
//            StringBase strB = obj as string;
//            if (strB == null)
//                return false;
//            if ((object)this == obj)
//                return true;
//            if (this.Length != strB.Length)
//                return false;
//            return string.EqualsHelper(this, strB);
//        }

//        /// <summary>Determines whether this instance and another specified <see cref="T:System.String" /> object have the same value.</summary>
//        /// <param name="value">The StringBase to compare to this instance. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of the <paramref name="value" /> parameter is the same as the value of this instance; otherwise, <see langword="false" />. If <paramref name="value" /> is <see langword="null" />, the method returns <see langword="false" />. </returns>
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]

//        public bool Equals(StringBase value)
//        {
//            if (this == null)
//                throw new NullReferenceException();
//            if (value == null)
//                return false;
//            if ((object)this == (object)value)
//                return true;
//            if (this.Length != value.Length)
//                return false;
//            return string.EqualsHelper(this, value);
//        }

//        /// <summary>Determines whether this StringBase and a specified <see cref="T:System.String" /> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
//        /// <param name="value">The StringBase to compare to this instance.</param>
//        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of the <paramref name="value" /> parameter is the same as this string; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value. </exception>
//        [SecuritySafeCritical]

//        public bool Equals(StringBase value, StringComparison comparisonType)
//        {
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                case StringComparison.CurrentCultureIgnoreCase:
//                case StringComparison.InvariantCulture:
//                case StringComparison.InvariantCultureIgnoreCase:
//                case StringComparison.Ordinal:
//                case StringComparison.OrdinalIgnoreCase:
//                    if ((object)this == (object)value)
//                        return true;
//                    if (value == null)
//                        return false;
//                    switch (comparisonType)
//                    {
//                        case StringComparison.CurrentCulture:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
//                        case StringComparison.CurrentCultureIgnoreCase:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
//                        case StringComparison.InvariantCulture:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
//                        case StringComparison.InvariantCultureIgnoreCase:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
//                        case StringComparison.Ordinal:
//                            if (this.Length != value.Length)
//                                return false;
//                            return string.EqualsHelper(this, value);
//                        case StringComparison.OrdinalIgnoreCase:
//                            if (this.Length != value.Length)
//                                return false;
//                            if (this.IsAscii() && value.IsAscii())
//                                return string.EqualsIgnoreCaseAsciiHelper(this, value);
//                            return TextInfo.CompareOrdinalIgnoreCase(this, value) == 0;
//                        default:
//                            throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//                    }
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Determines whether two specified <see cref="T:System.String" /> objects have the same value.</summary>
//        /// <param name="a">The first StringBase to compare, or <see langword="null" />. </param>
//        /// <param name="b">The second StringBase to compare, or <see langword="null" />. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />; otherwise, <see langword="false" />. If both <paramref name="a" /> and <paramref name="b" /> are <see langword="null" />, the method returns <see langword="true" />.</returns>

//        public static bool Equals(StringBase a, StringBase b)
//        {
//            if ((object)a == (object)b)
//                return true;
//            if (a == null || b == null || a.Length != b.Length)
//                return false;
//            return string.EqualsHelper(a, b);
//        }

//        /// <summary>Determines whether two specified <see cref="T:System.String" /> objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
//        /// <param name="a">The first StringBase to compare, or <see langword="null" />. </param>
//        /// <param name="b">The second StringBase to compare, or <see langword="null" />. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of the <paramref name="a" /> parameter is equal to the value of the <paramref name="b" /> parameter; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value. </exception>
//        [SecuritySafeCritical]

//        public static bool Equals(StringBase a, StringBase b, StringComparison comparisonType)
//        {
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                case StringComparison.CurrentCultureIgnoreCase:
//                case StringComparison.InvariantCulture:
//                case StringComparison.InvariantCultureIgnoreCase:
//                case StringComparison.Ordinal:
//                case StringComparison.OrdinalIgnoreCase:
//                    if ((object)a == (object)b)
//                        return true;
//                    if (a == null || b == null)
//                        return false;
//                    switch (comparisonType)
//                    {
//                        case StringComparison.CurrentCulture:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
//                        case StringComparison.CurrentCultureIgnoreCase:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
//                        case StringComparison.InvariantCulture:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
//                        case StringComparison.InvariantCultureIgnoreCase:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
//                        case StringComparison.Ordinal:
//                            if (a.Length != b.Length)
//                                return false;
//                            return string.EqualsHelper(a, b);
//                        case StringComparison.OrdinalIgnoreCase:
//                            if (a.Length != b.Length)
//                                return false;
//                            if (a.IsAscii() && b.IsAscii())
//                                return string.EqualsIgnoreCaseAsciiHelper(a, b);
//                            return TextInfo.CompareOrdinalIgnoreCase(a, b) == 0;
//                        default:
//                            throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//                    }
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Determines whether two specified strings have the same value.</summary>
//        /// <param name="a">The first StringBase to compare, or <see langword="null" />. </param>
//        /// <param name="b">The second StringBase to compare, or <see langword="null" />. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>

//        public static bool operator ==(StringBase a, StringBase b)
//        {
//            return string.Equals(a, b);
//        }

//        /// <summary>Determines whether two specified strings have different values.</summary>
//        /// <param name="a">The first StringBase to compare, or <see langword="null" />. </param>
//        /// <param name="b">The second StringBase to compare, or <see langword="null" />. </param>
//        /// <returns>
//        /// <see langword="true" /> if the value of <paramref name="a" /> is different from the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>

//        public static bool operator !=(StringBase a, StringBase b)
//        {
//            return !string.Equals(a, b);
//        }

//        /// <summary>Gets the <see cref="T:System.Char" /> object at a specified position in the current <see cref="T:System.String" /> object.</summary>
//        /// <param name="index">A position in the current string. </param>
//        /// <returns>The object at position <paramref name="index" />.</returns>
//        /// <exception cref="T:System.IndexOutOfRangeException">
//        /// <paramref name="index" /> is greater than or equal to the length of this object or less than zero. </exception>

//        [IndexerName("Chars")]
//        public extern char this[int index] { [SecuritySafeCritical, __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

//        /// <summary>Copies a specified number of characters from a specified position in this instance to a specified position in an array of Unicode characters.</summary>
//        /// <param name="sourceIndex">The index of the first character in this instance to copy. </param>
//        /// <param name="destination">An array of Unicode characters to which characters in this instance are copied. </param>
//        /// <param name="destinationIndex">The index in <paramref name="destination" /> at which the copy operation begins. </param>
//        /// <param name="count">The number of characters in this instance to copy to <paramref name="destination" />. </param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="destination" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="sourceIndex" />, <paramref name="destinationIndex" />, or <paramref name="count" /> is negative -or-
//        /// <paramref name="sourceIndex" /> does not identify a position in the current instance. -or-
//        /// <paramref name="destinationIndex" /> does not identify a valid index in the <paramref name="destination" /> array. -or-
//        /// <paramref name="count" /> is greater than the length of the subStringBase from <paramref name="startIndex" /> to the end of this instance -or-
//        /// <paramref name="count" /> is greater than the length of the subarray from <paramref name="destinationIndex" /> to the end of the <paramref name="destination" /> array. </exception>
//        [SecuritySafeCritical]

//        public unsafe void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
//        {
//            if (destination == null)
//                throw new ArgumentNullException(nameof(destination));
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
//            if (sourceIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(sourceIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (count > this.Length - sourceIndex)
//                throw new ArgumentOutOfRangeException(nameof(sourceIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
//            if (destinationIndex > destination.Length - count || destinationIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(destinationIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
//            if (count <= 0)
//                return;
//            fixed (char* chPtr1 = &this.m_firstChar)
//            fixed (char* chPtr2 = destination)
//                string.wstrcpy(chPtr2 + destinationIndex, chPtr1 + sourceIndex, count);
//        }

//        /// <summary>Copies the characters in this instance to a Unicode character array. </summary>
//        /// <returns>A Unicode character array whose elements are the individual characters of this instance. If this instance is an empty string, the returned array is empty and has a zero length.</returns>
//        [SecuritySafeCritical]

//        public unsafe char[] ToCharArray()
//        {
//            int length = this.Length;
//            char[] chArray = new char[length];
//            if (length > 0)
//            {
//                fixed (char* smem = &this.m_firstChar)
//                fixed (char* dmem = chArray)
//                    string.wstrcpy(dmem, smem, length);
//            }
//            return chArray;
//        }

//        /// <summary>Copies the characters in a specified subStringBase in this instance to a Unicode character array.</summary>
//        /// <param name="startIndex">The starting position of a subStringBase in this instance. </param>
//        /// <param name="length">The length of the subStringBase in this instance. </param>
//        /// <returns>A Unicode character array whose elements are the <paramref name="length" /> number of characters in this instance starting from character position <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.-or-
//        /// <paramref name="startIndex" /> plus <paramref name="length" /> is greater than the length of this instance. </exception>
//        [SecuritySafeCritical]

//        public unsafe char[] ToCharArray(int startIndex, int length)
//        {
//            if (startIndex < 0 || startIndex > this.Length || startIndex > this.Length - length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            char[] chArray = new char[length];
//            if (length > 0)
//            {
//                fixed (char* chPtr = &this.m_firstChar)
//                fixed (char* dmem = chArray)
//                    string.wstrcpy(dmem, chPtr + startIndex, length);
//            }
//            return chArray;
//        }

//        /// <summary>Indicates whether the specified StringBase is <see langword="null" /> or an <see cref="F:System.String.Empty" /> string.</summary>
//        /// <param name="value">The StringBase to test. </param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter is <see langword="null" /> or an empty StringBase (""); otherwise, <see langword="false" />.</returns>

//        public static bool IsNullOrEmpty(StringBase value)
//        {
//            if (value != null)
//                return value.Length == 0;
//            return true;
//        }

//        /// <summary>Indicates whether a specified StringBase is <see langword="null" />, empty, or consists only of white-space characters.</summary>
//        /// <param name="value">The StringBase to test.</param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, or if <paramref name="value" /> consists exclusively of white-space characters. </returns>

//        public static bool IsNullOrWhiteSpace(StringBase value)
//        {
//            if (value == null)
//                return true;
//            for (int index = 0; index < value.Length; ++index)
//            {
//                if (!char.IsWhiteSpace(value[index]))
//                    return false;
//            }
//            return true;
//        }

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal static extern int InternalMarvin32HashString(StringBase s, int strLen, long additionalEntropy);

//        [SecuritySafeCritical]
//        internal static bool UseRandomizedHashing()
//        {
//            return string.InternalUseRandomizedHashing();
//        }

//        [SecurityCritical]
//        [SuppressUnmanagedCodeSecurity]
//        [DllImport("QCall", CharSet = CharSet.Unicode)]
//        private static extern bool InternalUseRandomizedHashing();

//        /// <summary>Returns the hash code for this string.</summary>
//        /// <returns>A 32-bit signed integer hash code.</returns>
//        [SecuritySafeCritical]
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]

//        public override unsafe int GetHashCode()
//        {
//            if (HashHelpers.s_UseRandomizedStringHashing)
//                return string.InternalMarvin32HashString(this, this.Length, 0L);
//            StringBase str = this;
//            char* chPtr = (char*)str;
//            if ((IntPtr)chPtr != IntPtr.Zero)
//                chPtr += RuntimeHelpers.OffsetToStringData;
//            int num1 = 352654597;
//            int num2 = num1;
//            int* numPtr = (int*)chPtr;
//            int length = this.Length;
//            while (length > 2)
//            {
//                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ *numPtr;
//                num2 = (num2 << 5) + num2 + (num2 >> 27) ^ *(int*)((IntPtr)numPtr + 4);
//                numPtr += 2;
//                length -= 4;
//            }
//            if (length > 0)
//                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ *numPtr;
//            return num1 + num2 * 1566083941;
//        }

//        [SecuritySafeCritical]
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
//        internal unsafe int GetLegacyNonRandomizedHashCode()
//        {
//            StringBase str = this;
//            char* chPtr = (char*)str;
//            if ((IntPtr)chPtr != IntPtr.Zero)
//                chPtr += RuntimeHelpers.OffsetToStringData;
//            int num1 = 352654597;
//            int num2 = num1;
//            int* numPtr = (int*)chPtr;
//            int length = this.Length;
//            while (length > 2)
//            {
//                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ *numPtr;
//                num2 = (num2 << 5) + num2 + (num2 >> 27) ^ *(int*)((IntPtr)numPtr + 4);
//                numPtr += 2;
//                length -= 4;
//            }
//            if (length > 0)
//                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ *numPtr;
//            return num1 + num2 * 1566083941;
//        }

//        /// <summary>Gets the number of characters in the current <see cref="T:System.String" /> object.</summary>
//        /// <returns>The number of characters in the current string.</returns>

//        public extern int Length { [SecuritySafeCritical, __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

//        /// <summary>Splits a StringBase into substrings that are based on the characters in an array. </summary>
//        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>

//        public string[] Split(params char[] separator)
//        {
//            return this.SplitInternal(separator, int.MaxValue, StringSplitOptions.None);
//        }

//        /// <summary>Splits a StringBase into a maximum number of substrings based on the characters in an array. You also specify the maximum number of substrings to return.</summary>
//        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <param name="count">The maximum number of substrings to return. </param>
//        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is negative. </exception>

//        public string[] Split(char[] separator, int count)
//        {
//            return this.SplitInternal(separator, count, StringSplitOptions.None);
//        }

//        /// <summary>Splits a StringBase into substrings based on the characters in an array. You can specify whether the substrings include empty array elements.</summary>
//        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <param name="options">
//        /// <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned. </param>
//        /// <returns>An array whose elements contain the substrings in this StringBase that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
//        [ComVisible(false)]

//        public string[] Split(char[] separator, StringSplitOptions options)
//        {
//            return this.SplitInternal(separator, int.MaxValue, options);
//        }

//        /// <summary>Splits a StringBase into a maximum number of substrings based on the characters in an array.</summary>
//        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <param name="count">The maximum number of substrings to return. </param>
//        /// <param name="options">
//        /// <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned. </param>
//        /// <returns>An array whose elements contain the substrings in this StringBase that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is negative. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
//        [ComVisible(false)]

//        public string[] Split(char[] separator, int count, StringSplitOptions options)
//        {
//            return this.SplitInternal(separator, count, options);
//        }

//        [ComVisible(false)]
//        internal string[] SplitInternal(char[] separator, int count, StringSplitOptions options)
//        {
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
//            switch (options)
//            {
//                case StringSplitOptions.None:
//                case StringSplitOptions.RemoveEmptyEntries:
//                    bool flag = options == StringSplitOptions.RemoveEmptyEntries;
//                    if (count == 0 || flag && this.Length == 0)
//                        return new string[0];
//                    int[] sepList = new int[this.Length];
//                    int numReplaces = this.MakeSeparatorList(separator, ref sepList);
//                    if (numReplaces == 0 || count == 1)
//                        return new string[1] { this };
//                    if (flag)
//                        return this.InternalSplitOmitEmptyEntries(sepList, (int[])null, numReplaces, count);
//                    return this.InternalSplitKeepEmptyEntries(sepList, (int[])null, numReplaces, count);
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", (object)options));
//            }
//        }

//        /// <summary>Splits a StringBase into substrings based on the strings in an array. You can specify whether the substrings include empty array elements.</summary>
//        /// <param name="separator">A StringBase array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <param name="options">
//        /// <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned. </param>
//        /// <returns>An array whose elements contain the substrings in this StringBase that are delimited by one or more strings in <paramref name="separator" />. For more information, see the Remarks section.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
//        [ComVisible(false)]

//        public string[] Split(string[] separator, StringSplitOptions options)
//        {
//            return this.Split(separator, int.MaxValue, options);
//        }

//        /// <summary>Splits a StringBase into a maximum number of substrings based on the strings in an array. You can specify whether the substrings include empty array elements.</summary>
//        /// <param name="separator">A StringBase array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />. </param>
//        /// <param name="count">The maximum number of substrings to return. </param>
//        /// <param name="options">
//        /// <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned. </param>
//        /// <returns>An array whose elements contain the substrings in this StringBase that are delimited by one or more strings in <paramref name="separator" />. For more information, see the Remarks section.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is negative. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
//        [ComVisible(false)]

//        public string[] Split(string[] separator, int count, StringSplitOptions options)
//        {
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
//            switch (options)
//            {
//                case StringSplitOptions.None:
//                case StringSplitOptions.RemoveEmptyEntries:
//                    bool flag = options == StringSplitOptions.RemoveEmptyEntries;
//                    if (separator == null || separator.Length == 0)
//                        return this.SplitInternal((char[])null, count, options);
//                    if (count == 0 || flag && this.Length == 0)
//                        return new string[0];
//                    int[] sepList = new int[this.Length];
//                    int[] lengthList = new int[this.Length];
//                    int numReplaces = this.MakeSeparatorList(separator, ref sepList, ref lengthList);
//                    if (numReplaces == 0 || count == 1)
//                        return new string[1] { this };
//                    if (flag)
//                        return this.InternalSplitOmitEmptyEntries(sepList, lengthList, numReplaces, count);
//                    return this.InternalSplitKeepEmptyEntries(sepList, lengthList, numReplaces, count);
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", (object)options));
//            }
//        }

//        private string[] InternalSplitKeepEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
//        {
//            int startIndex = 0;
//            int index1 = 0;
//            --count;
//            int num = numReplaces < count ? numReplaces : count;
//            string[] strArray = new string[num + 1];
//            for (int index2 = 0; index2 < num && startIndex < this.Length; ++index2)
//            {
//                strArray[index1++] = this.Substring(startIndex, sepList[index2] - startIndex);
//                startIndex = sepList[index2] + (lengthList == null ? 1 : lengthList[index2]);
//            }
//            if (startIndex < this.Length && num >= 0)
//                strArray[index1] = this.Substring(startIndex);
//            else if (index1 == num)
//                strArray[index1] = string.Empty;
//            return strArray;
//        }

//        private string[] InternalSplitOmitEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
//        {
//            int length1 = numReplaces < count ? numReplaces + 1 : count;
//            string[] strArray1 = new string[length1];
//            int startIndex = 0;
//            int length2 = 0;
//            for (int index = 0; index < numReplaces && startIndex < this.Length; ++index)
//            {
//                if (sepList[index] - startIndex > 0)
//                    strArray1[length2++] = this.Substring(startIndex, sepList[index] - startIndex);
//                startIndex = sepList[index] + (lengthList == null ? 1 : lengthList[index]);
//                if (length2 == count - 1)
//                {
//                    while (index < numReplaces - 1 && startIndex == sepList[++index])
//                        startIndex += lengthList == null ? 1 : lengthList[index];
//                    break;
//                }
//            }
//            if (startIndex < this.Length)
//                strArray1[length2++] = this.Substring(startIndex);
//            string[] strArray2 = strArray1;
//            if (length2 != length1)
//            {
//                strArray2 = new string[length2];
//                for (int index = 0; index < length2; ++index)
//                    strArray2[index] = strArray1[index];
//            }
//            return strArray2;
//        }

//        [SecuritySafeCritical]
//        private unsafe int MakeSeparatorList(char[] separator, ref int[] sepList)
//        {
//            int num1 = 0;
//            if (separator == null || separator.Length == 0)
//            {
//                fixed (char* chPtr = &this.m_firstChar)
//                {
//                    for (int index = 0; index < this.Length && num1 < sepList.Length; ++index)
//                    {
//                        if (char.IsWhiteSpace(chPtr[index]))
//                            sepList[num1++] = index;
//                    }
//                }
//            }
//            else
//            {
//                int length1 = sepList.Length;
//                int length2 = separator.Length;
//                fixed (char* chPtr1 = &this.m_firstChar)
//                fixed (char* chPtr2 = separator)
//                {
//                    for (int index = 0; index < this.Length && num1 < length1; ++index)
//                    {
//                        char* chPtr3 = chPtr2;
//                        int num2 = 0;
//                        while (num2 < length2)
//                        {
//                            if ((int)chPtr1[index] == (int)*chPtr3)
//                            {
//                                sepList[num1++] = index;
//                                break;
//                            }
//                            ++num2;
//                            chPtr3 += 2;
//                        }
//                    }
//                }
//            }
//            return num1;
//        }

//        [SecuritySafeCritical]
//        private unsafe int MakeSeparatorList(string[] separators, ref int[] sepList, ref int[] lengthList)
//        {
//            int index1 = 0;
//            int length1 = sepList.Length;
//            int length2 = separators.Length;
//            fixed (char* chPtr = &this.m_firstChar)
//            {
//                for (int indexA = 0; indexA < this.Length && index1 < length1; ++indexA)
//                {
//                    for (int index2 = 0; index2 < separators.Length; ++index2)
//                    {
//                        StringBase separator = separators[index2];
//                        if (!string.IsNullOrEmpty(separator))
//                        {
//                            int length3 = separator.Length;
//                            if ((int)chPtr[indexA] == (int)separator[0] && length3 <= this.Length - indexA && (length3 == 1 || string.CompareOrdinal(this, indexA, separator, 0, length3) == 0))
//                            {
//                                sepList[index1] = indexA;
//                                lengthList[index1] = length3;
//                                ++index1;
//                                indexA += length3 - 1;
//                                break;
//                            }
//                        }
//                    }
//                }
//            }
//            return index1;
//        }

//        /// <summary>Retrieves a subStringBase from this instance. The subStringBase starts at a specified character position and continues to the end of the string.</summary>
//        /// <param name="startIndex">The zero-based starting character position of a subStringBase in this instance. </param>
//        /// <returns>A StringBase that is equivalent to the subStringBase that begins at <paramref name="startIndex" /> in this instance, or <see cref="F:System.String.Empty" /> if <paramref name="startIndex" /> is equal to the length of this instance.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is less than zero or greater than the length of this instance. </exception>

//        public StringBase Substring(int startIndex)
//        {
//            return this.Substring(startIndex, this.Length - startIndex);
//        }

//        /// <summary>Retrieves a subStringBase from this instance. The subStringBase starts at a specified character position and has a specified length.</summary>
//        /// <param name="startIndex">The zero-based starting character position of a subStringBase in this instance. </param>
//        /// <param name="length">The number of characters in the substring. </param>
//        /// <returns>A StringBase that is equivalent to the subStringBase of length <paramref name="length" /> that begins at <paramref name="startIndex" /> in this instance, or <see cref="F:System.String.Empty" /> if <paramref name="startIndex" /> is equal to the length of this instance and <paramref name="length" /> is zero.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> plus <paramref name="length" /> indicates a position not within this instance.-or-
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero. </exception>
//        [SecuritySafeCritical]

//        public StringBase Substring(int startIndex, int length)
//        {
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (startIndex > this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndexLargerThanLength"));
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
//            if (startIndex > this.Length - length)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_IndexLength"));
//            if (length == 0)
//                return string.Empty;
//            if (startIndex == 0 && length == this.Length)
//                return this;
//            return this.InternalSubString(startIndex, length);
//        }

//        [SecurityCritical]
//        private unsafe StringBase InternalSubString(int startIndex, int length)
//        {
//            StringBase str = string.FastAllocateString(length);
//            fixed (char* dmem = &str.m_firstChar)
//            fixed (char* chPtr = &this.m_firstChar)
//                string.wstrcpy(dmem, chPtr + startIndex, length);
//            return str;
//        }

//        /// <summary>Removes all leading and trailing occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
//        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />. </param>
//        /// <returns>The StringBase that remains after all occurrences of the characters in the <paramref name="trimChars" /> parameter are removed from the start and end of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>

//        public StringBase Trim(params char[] trimChars)
//        {
//            if (trimChars == null || trimChars.Length == 0)
//                return this.TrimHelper(2);
//            return this.TrimHelper(trimChars, 2);
//        }

//        /// <summary>Removes all leading occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
//        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />. </param>
//        /// <returns>The StringBase that remains after all occurrences of characters in the <paramref name="trimChars" /> parameter are removed from the start of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, white-space characters are removed instead.</returns>

//        public StringBase TrimStart(params char[] trimChars)
//        {
//            if (trimChars == null || trimChars.Length == 0)
//                return this.TrimHelper(0);
//            return this.TrimHelper(trimChars, 0);
//        }

//        /// <summary>Removes all trailing occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
//        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />. </param>
//        /// <returns>The StringBase that remains after all occurrences of the characters in the <paramref name="trimChars" /> parameter are removed from the end of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, Unicode white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged. </returns>

//        public StringBase TrimEnd(params char[] trimChars)
//        {
//            if (trimChars == null || trimChars.Length == 0)
//                return this.TrimHelper(1);
//            return this.TrimHelper(trimChars, 1);
//        }

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of Unicode characters.</summary>
//        /// <param name="value">A pointer to a null-terminated array of Unicode characters. </param>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">The current process does not have read access to all the addressed characters.</exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="value" /> specifies an array that contains an invalid Unicode character, or <paramref name="value" /> specifies an address less than 64000.</exception>
//        [SecurityCritical]
//        [CLSCompliant(false)]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern unsafe String(char* value);

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of Unicode characters, a starting character position within that array, and a length.</summary>
//        /// <param name="value">A pointer to an array of Unicode characters. </param>
//        /// <param name="startIndex">The starting position within <paramref name="value" />. </param>
//        /// <param name="length">The number of characters within <paramref name="value" /> to use. </param>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero, <paramref name="value" /> + <paramref name="startIndex" /> cause a pointer overflow, or the current process does not have read access to all the addressed characters.</exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="value" /> specifies an array that contains an invalid Unicode character, or <paramref name="value" /> + <paramref name="startIndex" /> specifies an address less than 64000.</exception>
//        [SecurityCritical]
//        [CLSCompliant(false)]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern unsafe String(char* value, int startIndex, int length);

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a pointer to an array of 8-bit signed integers.</summary>
//        /// <param name="value">A pointer to a null-terminated array of 8-bit signed integers. The integers are interpreted using the current system code page encoding (that is, the encoding specified by <see cref="P:System.Text.Encoding.Default" />). </param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded in ANSI. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">The length of the new StringBase to initialize, which is determined by the null termination character of <paramref name="value" />, is too large to allocate. </exception>
//        /// <exception cref="T:System.AccessViolationException">
//        /// <paramref name="value" /> specifies an invalid address.</exception>
//        [SecurityCritical]
//        [CLSCompliant(false)]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern unsafe String(sbyte* value);

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of 8-bit signed integers, a starting position within that array, and a length.</summary>
//        /// <param name="value">A pointer to an array of 8-bit signed integers. The integers are interpreted using the current system code page encoding (that is, the encoding specified by <see cref="P:System.Text.Encoding.Default" />). </param>
//        /// <param name="startIndex">The starting position within <paramref name="value" />. </param>
//        /// <param name="length">The number of characters within <paramref name="value" /> to use. </param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero. -or-The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is too large for the current platform; that is, the address calculation overflowed. -or-The length of the new StringBase to initialize is too large to allocate.</exception>
//        /// <exception cref="T:System.ArgumentException">The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is less than 64K.-or- A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded in ANSI.</exception>
//        /// <exception cref="T:System.AccessViolationException">
//        /// <paramref name="value" />, <paramref name="startIndex" />, and <paramref name="length" /> collectively specify an invalid address.</exception>
//        [SecurityCritical]
//        [CLSCompliant(false)]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern unsafe String(sbyte* value, int startIndex, int length);

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of 8-bit signed integers, a starting position within that array, a length, and an <see cref="T:System.Text.Encoding" /> object.</summary>
//        /// <param name="value">A pointer to an array of 8-bit signed integers. </param>
//        /// <param name="startIndex">The starting position within <paramref name="value" />. </param>
//        /// <param name="length">The number of characters within <paramref name="value" /> to use. </param>
//        /// <param name="enc">An object that specifies how the array referenced by <paramref name="value" /> is encoded. If <paramref name="enc" /> is <see langword="null" />, ANSI encoding is assumed.</param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero. -or-The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is too large for the current platform; that is, the address calculation overflowed. -or-The length of the new StringBase to initialize is too large to allocate.</exception>
//        /// <exception cref="T:System.ArgumentException">The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is less than 64K.-or- A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded as specified by <paramref name="enc" />. </exception>
//        /// <exception cref="T:System.AccessViolationException">
//        /// <paramref name="value" />, <paramref name="startIndex" />, and <paramref name="length" /> collectively specify an invalid address.</exception>
//        [SecurityCritical]
//        [CLSCompliant(false)]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern unsafe String(sbyte* value, int startIndex, int length, Encoding enc);

//        [SecurityCritical]
//        private static unsafe StringBase CreateString(sbyte* value, int startIndex, int length, Encoding enc)
//        {
//            if (enc == null)
//                return new string(value, startIndex, length);
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (value + startIndex < value)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
//            byte[] numArray = new byte[length];
//            try
//            {
//                Buffer.Memcpy(numArray, 0, (byte*)value, startIndex, length);
//            }
//            catch (NullReferenceException ex)
//            {
//                throw new ArgumentOutOfRangeException(nameof(value), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
//            }
//            return enc.GetString(numArray);
//        }

//        [SecurityCritical]
//        internal static unsafe StringBase CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding)
//        {
//            int charCount = encoding.GetCharCount(bytes, byteLength, (DecoderNLS)null);
//            if (charCount == 0)
//                return string.Empty;
//            StringBase str = string.FastAllocateString(charCount);
//            fixed (char* chars = &str.m_firstChar)
//                encoding.GetChars(bytes, byteLength, chars, charCount, (DecoderNLS)null);
//            return str;
//        }

//        [SecuritySafeCritical]
//        internal unsafe int GetBytesFromEncoding(byte* pbNativeBuffer, int cbNativeBuffer, Encoding encoding)
//        {
//            fixed (char* chars = &this.m_firstChar)
//                return encoding.GetBytes(chars, this.m_stringLength, pbNativeBuffer, cbNativeBuffer);
//        }

//        [SecuritySafeCritical]
//        internal unsafe int ConvertToAnsi(byte* pbNativeBuffer, int cbNativeBuffer, bool fBestFit, bool fThrowOnUnmappableChar)
//        {
//            uint flags = fBestFit ? 0U : 1024U;
//            uint num = 0;
//            int multiByte;
//            fixed (char* pwzSource = &this.m_firstChar)
//                multiByte = Win32Native.WideCharToMultiByte(0U, flags, pwzSource, this.Length, pbNativeBuffer, cbNativeBuffer, IntPtr.Zero, fThrowOnUnmappableChar ? new IntPtr((void*)&num) : IntPtr.Zero);
//            if (num != 0U)
//                throw new ArgumentException(Environment.GetResourceString("Interop_Marshal_Unmappable_Char"));
//            pbNativeBuffer[multiByte] = (byte)0;
//            return multiByte;
//        }

//        /// <summary>Indicates whether this StringBase is in Unicode normalization form C.</summary>
//        /// <returns>
//        /// <see langword="true" /> if this StringBase is in normalization form C; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
//        public bool IsNormalized()
//        {
//            return this.IsNormalized(NormalizationForm.FormC);
//        }

//        /// <summary>Indicates whether this StringBase is in the specified Unicode normalization form.</summary>
//        /// <param name="normalizationForm">A Unicode normalization form. </param>
//        /// <returns>
//        /// <see langword="true" /> if this StringBase is in the normalization form specified by the <paramref name="normalizationForm" /> parameter; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
//        [SecuritySafeCritical]
//        public bool IsNormalized(NormalizationForm normalizationForm)
//        {
//            if (this.IsFastSort() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || (normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD)))
//                return true;
//            return Normalization.IsNormalized(this, normalizationForm);
//        }

//        /// <summary>Returns a new StringBase whose textual value is the same as this string, but whose binary representation is in Unicode normalization form C.</summary>
//        /// <returns>A new, normalized StringBase whose textual value is the same as this string, but whose binary representation is in normalization form C.</returns>
//        /// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
//        public StringBase Normalize()
//        {
//            return this.Normalize(NormalizationForm.FormC);
//        }

//        /// <summary>Returns a new StringBase whose textual value is the same as this string, but whose binary representation is in the specified Unicode normalization form.</summary>
//        /// <param name="normalizationForm">A Unicode normalization form. </param>
//        /// <returns>A new StringBase whose textual value is the same as this string, but whose binary representation is in the normalization form specified by the <paramref name="normalizationForm" /> parameter.</returns>
//        /// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
//        [SecuritySafeCritical]
//        public StringBase Normalize(NormalizationForm normalizationForm)
//        {
//            if (this.IsAscii() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || (normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD)))
//                return this;
//            return Normalization.Normalize(this, normalizationForm);
//        }

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal static extern StringBase FastAllocateString(int length);

//        [SecuritySafeCritical]
//        private static unsafe void FillStringChecked(StringBase dest, int destPos, StringBase src)
//        {
//            if (src.Length > dest.Length - destPos)
//                throw new IndexOutOfRangeException();
//            fixed (char* chPtr = &dest.m_firstChar)
//            fixed (char* smem = &src.m_firstChar)
//                string.wstrcpy(chPtr + destPos, smem, src.Length);
//        }

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by an array of Unicode characters, a starting character position within that array, and a length.</summary>
//        /// <param name="value">An array of Unicode characters. </param>
//        /// <param name="startIndex">The starting position within <paramref name="value" />. </param>
//        /// <param name="length">The number of characters within <paramref name="value" /> to use. </param>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.-or- The sum of <paramref name="startIndex" /> and <paramref name="length" /> is greater than the number of elements in <paramref name="value" />. </exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern String(char[] value, int startIndex, int length);

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by an array of Unicode characters.</summary>
//        /// <param name="value">An array of Unicode characters. </param>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern String(char[] value);

//        [SecurityCritical]
//        internal static unsafe void wstrcpy(char* dmem, char* smem, int charCount)
//        {
//            Buffer.Memcpy((byte*)dmem, (byte*)smem, charCount * 2);
//        }

//        [SecuritySafeCritical]
//        private unsafe StringBase CtorCharArray(char[] value)
//        {
//            if (value == null || value.Length == 0)
//                return string.Empty;
//            StringBase str1 = string.FastAllocateString(value.Length);
//            StringBase str2 = str1;
//            char* dmem = (char*)str2;
//            if ((IntPtr)dmem != IntPtr.Zero)
//                dmem += RuntimeHelpers.OffsetToStringData;
//            fixed (char* smem = value)
//            {
//                string.wstrcpy(dmem, smem, value.Length);
//                str2 = (string)null;
//            }
//            return str1;
//        }

//        [SecuritySafeCritical]
//        private unsafe StringBase CtorCharArrayStartLength(char[] value, int startIndex, int length)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
//            if (startIndex > value.Length - length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (length <= 0)
//                return string.Empty;
//            StringBase str1 = string.FastAllocateString(length);
//            StringBase str2 = str1;
//            char* dmem = (char*)str2;
//            if ((IntPtr)dmem != IntPtr.Zero)
//                dmem += RuntimeHelpers.OffsetToStringData;
//            fixed (char* chPtr = value)
//            {
//                string.wstrcpy(dmem, chPtr + startIndex, length);
//                str2 = (string)null;
//            }
//            return str1;
//        }

//        [SecuritySafeCritical]
//        private unsafe StringBase CtorCharCount(char c, int count)
//        {
//            if (count > 0)
//            {
//                StringBase str1 = string.FastAllocateString(count);
//                if (c != char.MinValue)
//                {
//                    StringBase str2 = str1;
//                    char* chPtr1 = (char*)str2;
//                    if ((IntPtr)chPtr1 != IntPtr.Zero)
//                        chPtr1 += RuntimeHelpers.OffsetToStringData;
//                    char* chPtr2;
//                    for (chPtr2 = chPtr1; ((int)(uint)chPtr2 & 3) != 0 && count > 0; --count)
//                        *chPtr2++ = c;
//                    uint num = (uint)c << 16 | (uint)c;
//                    if (count >= 4)
//                    {
//                        count -= 4;
//                        do
//                        {
//                            *(int*)chPtr2 = (int)num;
//                            *(int*)((IntPtr)chPtr2 + 4) = (int)num;
//                            chPtr2 += 4;
//                            count -= 4;
//                        }
//                        while (count >= 0);
//                    }
//                    if ((count & 2) != 0)
//                    {
//                        *(int*)chPtr2 = (int)num;
//                        chPtr2 += 2;
//                    }
//                    if ((count & 1) != 0)
//                        *chPtr2 = c;
//                    str2 = (string)null;
//                }
//                return str1;
//            }
//            if (count == 0)
//                return string.Empty;
//            throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_MustBeNonNegNum", (object)nameof(count)));
//        }

//        [SecurityCritical]
//        private static unsafe int wcslen(char* ptr)
//        {
//            char* chPtr = ptr;
//            while (((int)(uint)chPtr & 3) != 0 && *chPtr != char.MinValue)
//                chPtr += 2;
//            if (*chPtr != char.MinValue)
//            {
//                while (((int)*chPtr & (int)*(ushort*)((IntPtr)chPtr + 2)) != 0 || *chPtr != char.MinValue && *(ushort*)((IntPtr)chPtr + 2) != (ushort)0)
//                    chPtr += 2;
//            }
//            while (*chPtr != char.MinValue)
//                chPtr += 2;
//            return (int)(chPtr - ptr);
//        }

//        [SecurityCritical]
//        private unsafe StringBase CtorCharPtr(char* ptr)
//        {
//            if ((IntPtr)ptr == IntPtr.Zero)
//                return string.Empty;
//            if ((UIntPtr)ptr < new UIntPtr(64000))
//                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeStringPtrNotAtom"));
//            try
//            {
//                int num = string.wcslen(ptr);
//                if (num == 0)
//                    return string.Empty;
//                StringBase str1 = string.FastAllocateString(num);
//                StringBase str2;
//                try
//                {
//                    str2 = str1;
//                    char* dmem = (char*)str2;
//                    if ((IntPtr)dmem != IntPtr.Zero)
//                        dmem += RuntimeHelpers.OffsetToStringData;
//                    string.wstrcpy(dmem, ptr, num);
//                }
//                finally
//                {
//                    str2 = (string)null;
//                }
//                return str1;
//            }
//            catch (NullReferenceException ex)
//            {
//                throw new ArgumentOutOfRangeException(nameof(ptr), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
//            }
//        }

//        [SecurityCritical]
//        private unsafe StringBase CtorCharPtrStartLength(char* ptr, int startIndex, int length)
//        {
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            char* smem = ptr + startIndex;
//            if (smem < ptr)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
//            if (length == 0)
//                return string.Empty;
//            StringBase str1 = string.FastAllocateString(length);
//            try
//            {
//                StringBase str2;
//                try
//                {
//                    str2 = str1;
//                    char* dmem = (char*)str2;
//                    if ((IntPtr)dmem != IntPtr.Zero)
//                        dmem += RuntimeHelpers.OffsetToStringData;
//                    string.wstrcpy(dmem, smem, length);
//                }
//                finally
//                {
//                    str2 = (string)null;
//                }
//                return str1;
//            }
//            catch (NullReferenceException ex)
//            {
//                throw new ArgumentOutOfRangeException(nameof(ptr), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
//            }
//        }

//        /// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified Unicode character repeated a specified number of times.</summary>
//        /// <param name="c">A Unicode character. </param>
//        /// <param name="count">The number of times <paramref name="c" /> occurs. </param>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is less than zero. </exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern String(char c, int count);

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to compare. </param>
//        /// <param name="strB">The second StringBase to compare. </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero
//        /// <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order. Zero
//        /// <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order. Greater than zero
//        /// <paramref name="strA" /> follows <paramref name="strB" /> in the sort order. </returns>

//        public static int Compare(StringBase strA, StringBase strB)
//        {
//            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
//        }

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to compare. </param>
//        /// <param name="strB">The second StringBase to compare. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero
//        /// <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order. Zero
//        /// <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order. Greater than zero
//        /// <paramref name="strA" /> follows <paramref name="strB" /> in the sort order. </returns>

//        public static int Compare(StringBase strA, StringBase strB, bool ignoreCase)
//        {
//            if (ignoreCase)
//                return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
//            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
//        }

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects using the specified rules, and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to compare.</param>
//        /// <param name="strB">The second StringBase to compare. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison. </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero
//        /// <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order. Zero
//        /// <paramref name="strA" /> is in the same position as <paramref name="strB" /> in the sort order. Greater than zero
//        /// <paramref name="strA" /> follows <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value. </exception>
//        /// <exception cref="T:System.NotSupportedException">
//        /// <see cref="T:System.StringComparison" /> is not supported.</exception>
//        [SecuritySafeCritical]

//        public static int Compare(StringBase strA, StringBase strB, StringComparison comparisonType)
//        {
//            if ((uint)(comparisonType - 0) > 5U)
//                throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            if ((object)strA == (object)strB)
//                return 0;
//            if (strA == null)
//                return -1;
//            if (strB == null)
//                return 1;
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
//                case StringComparison.CurrentCultureIgnoreCase:
//                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
//                case StringComparison.InvariantCulture:
//                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
//                case StringComparison.InvariantCultureIgnoreCase:
//                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
//                case StringComparison.Ordinal:
//                    if ((int)strA.m_firstChar - (int)strB.m_firstChar != 0)
//                        return (int)strA.m_firstChar - (int)strB.m_firstChar;
//                    return string.CompareOrdinalHelper(strA, strB);
//                case StringComparison.OrdinalIgnoreCase:
//                    if (strA.IsAscii() && strB.IsAscii())
//                        return string.CompareOrdinalIgnoreCaseHelper(strA, strB);
//                    return TextInfo.CompareOrdinalIgnoreCase(strA, strB);
//                default:
//                    throw new NotSupportedException(Environment.GetResourceString("NotSupported_StringComparison"));
//            }
//        }

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects using the specified comparison options and culture-specific information to influence the comparison, and returns an integer that indicates the relationship of the two strings to each other in the sort order.</summary>
//        /// <param name="strA">The first StringBase to compare.  </param>
//        /// <param name="strB">The second StringBase to compare.</param>
//        /// <param name="culture">The culture that supplies culture-specific comparison information.</param>
//        /// <param name="options">Options to use when performing the comparison (such as ignoring case or symbols).  </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between <paramref name="strA" /> and <paramref name="strB" />, as shown in the following tableValueConditionLess than zero
//        /// <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order. Zero
//        /// <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order. Greater than zero
//        /// <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not a <see cref="T:System.Globalization.CompareOptions" /> value.</exception>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />.</exception>

//        public static int Compare(StringBase strA, StringBase strB, CultureInfo culture, CompareOptions options)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            return culture.CompareInfo.Compare(strA, strB, options);
//        }

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and using culture-specific information to influence the comparison, and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to compare. </param>
//        /// <param name="strB">The second StringBase to compare. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />. </param>
//        /// <param name="culture">An object that supplies culture-specific comparison information. </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero
//        /// <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order. Zero
//        /// <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order. Greater than zero
//        /// <paramref name="strA" /> follows <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />. </exception>
//        public static int Compare(StringBase strA, StringBase strB, bool ignoreCase, CultureInfo culture)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            if (ignoreCase)
//                return culture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
//            return culture.CompareInfo.Compare(strA, strB, CompareOptions.None);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to use in the comparison. </param>
//        /// <param name="indexA">The position of the subStringBase within <paramref name="strA" />. </param>
//        /// <param name="strB">The second StringBase to use in the comparison. </param>
//        /// <param name="indexB">The position of the subStringBase within <paramref name="strB" />. </param>
//        /// <param name="length">The maximum number of characters in the substrings to compare. </param>
//        /// <returns>A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition Less than zero The subStringBase in <paramref name="strA" /> precedes the subStringBase in <paramref name="strB" /> in the sort order. Zero The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero. Greater than zero The subStringBase in <paramref name="strA" /> follows the subStringBase in <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative. -or-Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>

//        public static int Compare(StringBase strA, int indexA, StringBase strB, int indexB, int length)
//        {
//            int length1 = length;
//            int length2 = length;
//            if (strA != null && strA.Length - indexA < length1)
//                length1 = strA.Length - indexA;
//            if (strB != null && strB.Length - indexB < length2)
//                length2 = strB.Length - indexB;
//            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to use in the comparison. </param>
//        /// <param name="indexA">The position of the subStringBase within <paramref name="strA" />. </param>
//        /// <param name="strB">The second StringBase to use in the comparison. </param>
//        /// <param name="indexB">The position of the subStringBase within <paramref name="strB" />. </param>
//        /// <param name="length">The maximum number of characters in the substrings to compare. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.ValueCondition Less than zero The subStringBase in <paramref name="strA" /> precedes the subStringBase in <paramref name="strB" /> in the sort order. Zero The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero. Greater than zero The subStringBase in <paramref name="strA" /> follows the subStringBase in <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative. -or-Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
//        public static int Compare(StringBase strA, int indexA, StringBase strB, int indexB, int length, bool ignoreCase)
//        {
//            int length1 = length;
//            int length2 = length;
//            if (strA != null && strA.Length - indexA < length1)
//                length1 = strA.Length - indexA;
//            if (strB != null && strB.Length - indexB < length2)
//                length2 = strB.Length - indexB;
//            if (ignoreCase)
//                return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.IgnoreCase);
//            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects, ignoring or honoring their case and using culture-specific information to influence the comparison, and returns an integer that indicates their relative position in the sort order.</summary>
//        /// <param name="strA">The first StringBase to use in the comparison. </param>
//        /// <param name="indexA">The position of the subStringBase within <paramref name="strA" />. </param>
//        /// <param name="strB">The second StringBase to use in the comparison. </param>
//        /// <param name="indexB">The position of the subStringBase within <paramref name="strB" />. </param>
//        /// <param name="length">The maximum number of characters in the substrings to compare. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />. </param>
//        /// <param name="culture">An object that supplies culture-specific comparison information. </param>
//        /// <returns>An integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero The subStringBase in <paramref name="strA" /> precedes the subStringBase in <paramref name="strB" /> in the sort order. Zero The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero. Greater than zero The subStringBase in <paramref name="strA" /> follows the subStringBase in <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative. -or-Either <paramref name="strA" /> or <paramref name="strB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />. </exception>
//        public static int Compare(StringBase strA, int indexA, StringBase strB, int indexB, int length, bool ignoreCase, CultureInfo culture)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            int length1 = length;
//            int length2 = length;
//            if (strA != null && strA.Length - indexA < length1)
//                length1 = strA.Length - indexA;
//            if (strB != null && strB.Length - indexB < length2)
//                length2 = strB.Length - indexB;
//            if (ignoreCase)
//                return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.IgnoreCase);
//            return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects using the specified comparison options and culture-specific information to influence the comparison, and returns an integer that indicates the relationship of the two substrings to each other in the sort order.</summary>
//        /// <param name="strA">The first StringBase to use in the comparison.   </param>
//        /// <param name="indexA">The starting position of the subStringBase within <paramref name="strA" />.</param>
//        /// <param name="strB">The second StringBase to use in the comparison.</param>
//        /// <param name="indexB">The starting position of the subStringBase within <paramref name="strB" />.</param>
//        /// <param name="length">The maximum number of characters in the substrings to compare.</param>
//        /// <param name="culture">An object that supplies culture-specific comparison information.</param>
//        /// <param name="options">Options to use when performing the comparison (such as ignoring case or symbols).  </param>
//        /// <returns>An integer that indicates the lexical relationship between the two substrings, as shown in the following table.ValueConditionLess than zeroThe subStringBase in <paramref name="strA" /> precedes the subStringBase in <paramref name="strB" /> in the sort order.ZeroThe substrings occur in the same position in the sort order, or <paramref name="length" /> is zero.Greater than zeroThe subStringBase in <paramref name="strA" /> follows the subStringBase in <paramref name="strB" /> in the sort order.</returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="options" /> is not a <see cref="T:System.Globalization.CompareOptions" /> value.</exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="indexA" /> is greater than <paramref name="strA" /><see langword=".Length" />.-or-
//        /// <paramref name="indexB" /> is greater than <paramref name="strB" /><see langword=".Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.-or-Either <paramref name="strA" /> or <paramref name="strB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />.</exception>
//        public static int Compare(StringBase strA, int indexA, StringBase strB, int indexB, int length, CultureInfo culture, CompareOptions options)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            int length1 = length;
//            int length2 = length;
//            if (strA != null && strA.Length - indexA < length1)
//                length1 = strA.Length - indexA;
//            if (strB != null && strB.Length - indexB < length2)
//                length2 = strB.Length - indexB;
//            return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, options);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects using the specified rules, and returns an integer that indicates their relative position in the sort order. </summary>
//        /// <param name="strA">The first StringBase to use in the comparison. </param>
//        /// <param name="indexA">The position of the subStringBase within <paramref name="strA" />. </param>
//        /// <param name="strB">The second StringBase to use in the comparison.</param>
//        /// <param name="indexB">The position of the subStringBase within <paramref name="strB" />. </param>
//        /// <param name="length">The maximum number of characters in the substrings to compare. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison. </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero The subStringBase in <paramref name="strA" /> precedes the subStringBase in <paramref name="strB" /> in the sort order.Zero The substrings occur in the same position in the sort order, or the <paramref name="length" /> parameter is zero. Greater than zero The subStringBase in <paramref name="strA" /> follllows the subStringBase in <paramref name="strB" /> in the sort order. </returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative. -or-Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value. </exception>
//        [SecuritySafeCritical]

//        public static int Compare(StringBase strA, int indexA, StringBase strB, int indexB, int length, StringComparison comparisonType)
//        {
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                case StringComparison.CurrentCultureIgnoreCase:
//                case StringComparison.InvariantCulture:
//                case StringComparison.InvariantCultureIgnoreCase:
//                case StringComparison.Ordinal:
//                case StringComparison.OrdinalIgnoreCase:
//                    if (strA == null || strB == null)
//                    {
//                        if ((object)strA == (object)strB)
//                            return 0;
//                        return strA != null ? 1 : -1;
//                    }
//                    if (length < 0)
//                        throw new ArgumentOutOfRangeException(nameof(length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
//                    if (indexA < 0)
//                        throw new ArgumentOutOfRangeException(nameof(indexA), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//                    if (indexB < 0)
//                        throw new ArgumentOutOfRangeException(nameof(indexB), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//                    if (strA.Length - indexA < 0)
//                        throw new ArgumentOutOfRangeException(nameof(indexA), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//                    if (strB.Length - indexB < 0)
//                        throw new ArgumentOutOfRangeException(nameof(indexB), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//                    if (length == 0 || strA == strB && indexA == indexB)
//                        return 0;
//                    int num1 = length;
//                    int num2 = length;
//                    if (strA != null && strA.Length - indexA < num1)
//                        num1 = strA.Length - indexA;
//                    if (strB != null && strB.Length - indexB < num2)
//                        num2 = strB.Length - indexB;
//                    switch (comparisonType)
//                    {
//                        case StringComparison.CurrentCulture:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.None);
//                        case StringComparison.CurrentCultureIgnoreCase:
//                            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.IgnoreCase);
//                        case StringComparison.InvariantCulture:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.None);
//                        case StringComparison.InvariantCultureIgnoreCase:
//                            return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.IgnoreCase);
//                        case StringComparison.Ordinal:
//                            return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
//                        case StringComparison.OrdinalIgnoreCase:
//                            return TextInfo.CompareOrdinalIgnoreCaseEx(strA, indexA, strB, indexB, num1, num2);
//                        default:
//                            throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"));
//                    }
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Compares this instance with a specified <see cref="T:System.Object" /> and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="T:System.Object" />.</summary>
//        /// <param name="value">An object that evaluates to a <see cref="T:System.String" />. </param>
//        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="value" /> parameter.Value Condition Less than zero This instance precedes <paramref name="value" />. Zero This instance has the same position in the sort order as <paramref name="value" />. Greater than zero This instance follows <paramref name="value" />.-or-
//        /// <paramref name="value" /> is <see langword="null" />. </returns>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="value" /> is not a <see cref="T:System.String" />. </exception>
//        public int CompareTo(object value)
//        {
//            if (value == null)
//                return 1;
//            if (!(value is string))
//                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeString"));
//            return string.Compare(this, (string)value, StringComparison.CurrentCulture);
//        }

//        /// <summary>Compares this instance with a specified <see cref="T:System.String" /> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string. </summary>
//        /// <param name="strB">The StringBase to compare with this instance. </param>
//        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="strB" /> parameter.Value Condition Less than zero This instance precedes <paramref name="strB" />. Zero This instance has the same position in the sort order as <paramref name="strB" />. Greater than zero This instance follows <paramref name="strB" />.-or-
//        /// <paramref name="strB" /> is <see langword="null" />. </returns>

//        public int CompareTo(StringBase strB)
//        {
//            if (strB == null)
//                return 1;
//            return CultureInfo.CurrentCulture.CompareInfo.Compare(this, strB, CompareOptions.None);
//        }

//        /// <summary>Compares two specified <see cref="T:System.String" /> objects by evaluating the numeric values of the corresponding <see cref="T:System.Char" /> objects in each string.</summary>
//        /// <param name="strA">The first StringBase to compare. </param>
//        /// <param name="strB">The second StringBase to compare. </param>
//        /// <returns>An integer that indicates the lexical relationship between the two comparands.ValueCondition Less than zero
//        /// <paramref name="strA" /> is less than <paramref name="strB" />. Zero
//        /// <paramref name="strA" /> and <paramref name="strB" /> are equal. Greater than zero
//        /// <paramref name="strA" /> is greater than <paramref name="strB" />. </returns>

//        public static int CompareOrdinal(StringBase strA, StringBase strB)
//        {
//            if ((object)strA == (object)strB)
//                return 0;
//            if (strA == null)
//                return -1;
//            if (strB == null)
//                return 1;
//            if ((int)strA.m_firstChar - (int)strB.m_firstChar != 0)
//                return (int)strA.m_firstChar - (int)strB.m_firstChar;
//            return string.CompareOrdinalHelper(strA, strB);
//        }

//        /// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects by evaluating the numeric values of the corresponding <see cref="T:System.Char" /> objects in each substring. </summary>
//        /// <param name="strA">The first StringBase to use in the comparison. </param>
//        /// <param name="indexA">The starting index of the subStringBase in <paramref name="strA" />. </param>
//        /// <param name="strB">The second StringBase to use in the comparison. </param>
//        /// <param name="indexB">The starting index of the subStringBase in <paramref name="strB" />. </param>
//        /// <param name="length">The maximum number of characters in the substrings to compare. </param>
//        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.ValueConditionLess than zero The subStringBase in <paramref name="strA" /> is less than the subStringBase in <paramref name="strB" />. Zero The substrings are equal, or <paramref name="length" /> is zero. Greater than zero The subStringBase in <paramref name="strA" /> is greater than the subStringBase in <paramref name="strB" />. </returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="strA" /> is not <see langword="null" /> and <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="strB" /> is not <see langword="null" /> and<paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.-or-
//        /// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative. </exception>
//        [SecuritySafeCritical]

//        public static int CompareOrdinal(StringBase strA, int indexA, StringBase strB, int indexB, int length)
//        {
//            if (strA != null && strB != null)
//                return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
//            if ((object)strA == (object)strB)
//                return 0;
//            return strA != null ? 1 : -1;
//        }

//        /// <summary>Returns a value indicating whether a specified subStringBase occurs within this string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter occurs within this string, or if <paramref name="value" /> is the empty StringBase (""); otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public bool Contains(StringBase value)
//        {
//            return this.IndexOf(value, StringComparison.Ordinal) >= 0;
//        }

//        /// <summary>Determines whether the end of this StringBase instance matches the specified string.</summary>
//        /// <param name="value">The StringBase to compare to the subStringBase at the end of this instance. </param>
//        /// <returns>
//        /// <see langword="true" /> if <paramref name="value" /> matches the end of this instance; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public bool EndsWith(StringBase value)
//        {
//            return this.EndsWith(value, StringComparison.CurrentCulture);
//        }

//        /// <summary>Determines whether the end of this StringBase instance matches the specified StringBase when compared using the specified comparison option.</summary>
//        /// <param name="value">The StringBase to compare to the subStringBase at the end of this instance. </param>
//        /// <param name="comparisonType">One of the enumeration values that determines how this StringBase and <paramref name="value" /> are compared. </param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter matches the end of this string; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
//        [SecuritySafeCritical]
//        [ComVisible(false)]

//        public bool EndsWith(StringBase value, StringComparison comparisonType)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                case StringComparison.CurrentCultureIgnoreCase:
//                case StringComparison.InvariantCulture:
//                case StringComparison.InvariantCultureIgnoreCase:
//                case StringComparison.Ordinal:
//                case StringComparison.OrdinalIgnoreCase:
//                    if ((object)this == (object)value || value.Length == 0)
//                        return true;
//                    switch (comparisonType)
//                    {
//                        case StringComparison.CurrentCulture:
//                            return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
//                        case StringComparison.CurrentCultureIgnoreCase:
//                            return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
//                        case StringComparison.InvariantCulture:
//                            return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
//                        case StringComparison.InvariantCultureIgnoreCase:
//                            return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
//                        case StringComparison.Ordinal:
//                            if (this.Length >= value.Length)
//                                return string.nativeCompareOrdinalEx(this, this.Length - value.Length, value, 0, value.Length) == 0;
//                            return false;
//                        case StringComparison.OrdinalIgnoreCase:
//                            if (this.Length >= value.Length)
//                                return TextInfo.CompareOrdinalIgnoreCaseEx(this, this.Length - value.Length, value, 0, value.Length, value.Length) == 0;
//                            return false;
//                        default:
//                            throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//                    }
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Determines whether the end of this StringBase instance matches the specified StringBase when compared using the specified culture.</summary>
//        /// <param name="value">The StringBase to compare to the subStringBase at the end of this instance. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
//        /// <param name="culture">Cultural information that determines how this instance and <paramref name="value" /> are compared. If <paramref name="culture" /> is <see langword="null" />, the current culture is used.</param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter matches the end of this string; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        public bool EndsWith(StringBase value, bool ignoreCase, CultureInfo culture)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if ((object)this == (object)value)
//                return true;
//            return (culture != null ? culture : CultureInfo.CurrentCulture).CompareInfo.IsSuffix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
//        }

//        internal bool EndsWith(char value)
//        {
//            int length = this.Length;
//            return length != 0 && (int)this[length - 1] == (int)value;
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified Unicode character in this string.</summary>
//        /// <param name="value">A Unicode character to seek. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not.</returns>

//        public int IndexOf(char value)
//        {
//            return this.IndexOf(value, 0, this.Length);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.</summary>
//        /// <param name="value">A Unicode character to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> from the start of the StringBase if that character is found, or -1 if it is not.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of the string. </exception>

//        public int IndexOf(char value, int startIndex)
//        {
//            return this.IndexOf(value, startIndex, this.Length - startIndex);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.</summary>
//        /// <param name="value">A Unicode character to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> from the start of the StringBase if that character is found, or -1 if it is not.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> or <paramref name="startIndex" /> is negative.-or-
//        /// <paramref name="startIndex" /> is greater than the length of this string.-or-
//        /// <paramref name="count" /> is greater than the length of this StringBase minus <paramref name="startIndex" />.</exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern int IndexOf(char value, int startIndex, int count);

//        /// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>

//        public int IndexOfAny(char[] anyOf)
//        {
//            return this.IndexOfAny(anyOf, 0, this.Length);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is negative.-or-
//        /// <paramref name="startIndex" /> is greater than the number of characters in this instance. </exception>

//        public int IndexOfAny(char[] anyOf, int startIndex)
//        {
//            return this.IndexOfAny(anyOf, startIndex, this.Length - startIndex);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> or <paramref name="startIndex" /> is negative.-or-
//        /// <paramref name="count" /> + <paramref name="startIndex" /> is greater than the number of characters in this instance. </exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern int IndexOfAny(char[] anyOf, int startIndex, int count);

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in this instance.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is 0.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public int IndexOf(StringBase value)
//        {
//            return this.IndexOf(value, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in this instance. The search starts at a specified character position.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> from the start of the current instance if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of this string.</exception>

//        public int IndexOf(StringBase value, int startIndex)
//        {
//            return this.IndexOf(value, startIndex, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in this instance. The search starts at a specified character position and examines a specified number of character positions.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> from the start of the current instance if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> or <paramref name="startIndex" /> is negative.-or-
//        /// <paramref name="startIndex" /> is greater than the length of this string.-or-
//        /// <paramref name="count" /> is greater than the length of this StringBase minus <paramref name="startIndex" />.</exception>

//        public int IndexOf(StringBase value, int startIndex, int count)
//        {
//            if (startIndex < 0 || startIndex > this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (count < 0 || count > this.Length - startIndex)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
//            return this.IndexOf(value, startIndex, count, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in the current <see cref="T:System.String" /> object. A parameter specifies the type of search to use for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The index position of the <paramref name="value" /> parameter if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is 0.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>

//        public int IndexOf(StringBase value, StringComparison comparisonType)
//        {
//            return this.IndexOf(value, 0, this.Length, comparisonType);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in the current <see cref="T:System.String" /> object. Parameters specify the starting search position in the current StringBase and the type of search to use for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The zero-based index position of the <paramref name="value" /> parameter from the start of the current instance if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of this string. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>

//        public int IndexOf(StringBase value, int startIndex, StringComparison comparisonType)
//        {
//            return this.IndexOf(value, startIndex, this.Length - startIndex, comparisonType);
//        }

//        /// <summary>Reports the zero-based index of the first occurrence of the specified StringBase in the current <see cref="T:System.String" /> object. Parameters specify the starting search position in the current string, the number of characters in the current StringBase to search, and the type of search to use for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. </param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The zero-based index position of the <paramref name="value" /> parameter from the start of the current instance if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> or <paramref name="startIndex" /> is negative.-or-
//        /// <paramref name="startIndex" /> is greater than the length of this instance.-or-
//        /// <paramref name="count" /> is greater than the length of this StringBase minus <paramref name="startIndex" />.</exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
//        [SecuritySafeCritical]

//        public int IndexOf(StringBase value, int startIndex, int count, StringComparison comparisonType)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if (startIndex < 0 || startIndex > this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (count < 0 || startIndex > this.Length - count)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                    return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
//                case StringComparison.CurrentCultureIgnoreCase:
//                    return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                case StringComparison.InvariantCulture:
//                    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
//                case StringComparison.InvariantCultureIgnoreCase:
//                    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                case StringComparison.Ordinal:
//                    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
//                case StringComparison.OrdinalIgnoreCase:
//                    if (value.IsAscii() && this.IsAscii())
//                        return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                    return TextInfo.IndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance.</summary>
//        /// <param name="value">The Unicode character to seek. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not.</returns>

//        public int LastIndexOf(char value)
//        {
//            return this.LastIndexOf(value, this.Length - 1, this.Length);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
//        /// <param name="value">The Unicode character to seek. </param>
//        /// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than or equal to the length of this instance.</exception>

//        public int LastIndexOf(char value, int startIndex)
//        {
//            return this.LastIndexOf(value, startIndex, startIndex + 1);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of the specified Unicode character in a subStringBase within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the StringBase for a specified number of character positions.</summary>
//        /// <param name="value">The Unicode character to seek. </param>
//        /// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than or equal to the length of this instance.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.</exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern int LastIndexOf(char value, int startIndex, int count);

//        /// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>

//        public int LastIndexOfAny(char[] anyOf)
//        {
//            return this.LastIndexOfAny(anyOf, this.Length - 1, this.Length);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> specifies a position that is not within this instance. </exception>

//        public int LastIndexOfAny(char[] anyOf, int startIndex)
//        {
//            return this.LastIndexOfAny(anyOf, startIndex, startIndex + 1);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the StringBase for a specified number of character positions.</summary>
//        /// <param name="anyOf">A Unicode character array containing one or more characters to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="anyOf" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="count" /> or <paramref name="startIndex" /> is negative.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> minus <paramref name="count" /> + 1 is less than zero. </exception>
//        [SecuritySafeCritical]

//        [MethodImpl(MethodImplOptions.InternalCall)]
//        public extern int LastIndexOfAny(char[] anyOf, int startIndex, int count);

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified StringBase within this instance.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <returns>The zero-based starting index position of <paramref name="value" /> if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public int LastIndexOf(StringBase value)
//        {
//            return this.LastIndexOf(value, this.Length - 1, this.Length, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified StringBase within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <returns>The zero-based starting index position of <paramref name="value" /> if that StringBase is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than the length of the current instance. -or-The current instance equals <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than -1 or greater than zero.</exception>

//        public int LastIndexOf(StringBase value, int startIndex)
//        {
//            return this.LastIndexOf(value, startIndex, startIndex + 1, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified StringBase within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the StringBase for a specified number of character positions.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <returns>The zero-based starting index position of <paramref name="value" /> if that StringBase is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is negative.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is negative.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is greater than the length of this instance.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> - <paramref name="count" />+ 1 specifies a position that is not within this instance. -or-The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="start" /> is less than -1 or greater than zero. -or-The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="count" /> is greater than 1. </exception>

//        public int LastIndexOf(StringBase value, int startIndex, int count)
//        {
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
//            return this.LastIndexOf(value, startIndex, count, StringComparison.CurrentCulture);
//        }

//        /// <summary>Reports the zero-based index of the last occurrence of a specified StringBase within the current <see cref="T:System.String" /> object. A parameter specifies the type of search to use for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that StringBase is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>

//        public int LastIndexOf(StringBase value, StringComparison comparisonType)
//        {
//            return this.LastIndexOf(value, this.Length - 1, this.Length, comparisonType);
//        }

//        /// <summary>Reports the zero-based index of the last occurrence of a specified StringBase within the current <see cref="T:System.String" /> object. The search starts at a specified character position and proceeds backward toward the beginning of the string. A parameter specifies the type of comparison to perform when searching for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that StringBase is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than the length of the current instance. -or-The current instance equals <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than -1 or greater than zero.</exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>

//        public int LastIndexOf(StringBase value, int startIndex, StringComparison comparisonType)
//        {
//            return this.LastIndexOf(value, startIndex, startIndex + 1, comparisonType);
//        }

//        /// <summary>Reports the zero-based index position of the last occurrence of a specified StringBase within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the StringBase for the specified number of character positions. A parameter specifies the type of comparison to perform when searching for the specified string.</summary>
//        /// <param name="value">The StringBase to seek. </param>
//        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
//        /// <param name="count">The number of character positions to examine. </param>
//        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
//        /// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that StringBase is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="count" /> is negative.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is negative.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is greater than the length of this instance.-or-
//        /// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> + 1 - <paramref name="count" /> specifies a position that is not within this instance. -or-The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="start" /> is less than -1 or greater than zero. -or-The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="count" /> is greater than 1. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
//        [SecuritySafeCritical]

//        public int LastIndexOf(StringBase value, int startIndex, int count, StringComparison comparisonType)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if (this.Length == 0 && (startIndex == -1 || startIndex == 0))
//                return value.Length != 0 ? -1 : 0;
//            if (startIndex < 0 || startIndex > this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
//            if (startIndex == this.Length)
//            {
//                --startIndex;
//                if (count > 0)
//                    --count;
//                if (value.Length == 0 && count >= 0 && startIndex - count + 1 >= 0)
//                    return startIndex;
//            }
//            if (count < 0 || startIndex - count + 1 < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                    return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
//                case StringComparison.CurrentCultureIgnoreCase:
//                    return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                case StringComparison.InvariantCulture:
//                    return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
//                case StringComparison.InvariantCultureIgnoreCase:
//                    return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                case StringComparison.Ordinal:
//                    return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
//                case StringComparison.OrdinalIgnoreCase:
//                    if (value.IsAscii() && this.IsAscii())
//                        return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
//                    return TextInfo.LastIndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Returns a new StringBase that right-aligns the characters in this instance by padding them with spaces on the left, for a specified total length.</summary>
//        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters. </param>
//        /// <returns>A new StringBase that is equivalent to this instance, but right-aligned and padded on the left with as many spaces as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new StringBase that is identical to this instance.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="totalWidth" /> is less than zero. </exception>

//        public StringBase PadLeft(int totalWidth)
//        {
//            return this.PadHelper(totalWidth, ' ', false);
//        }

//        /// <summary>Returns a new StringBase that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.</summary>
//        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters. </param>
//        /// <param name="paddingChar">A Unicode padding character. </param>
//        /// <returns>A new StringBase that is equivalent to this instance, but right-aligned and padded on the left with as many <paramref name="paddingChar" /> characters as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new StringBase that is identical to this instance.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="totalWidth" /> is less than zero. </exception>

//        public StringBase PadLeft(int totalWidth, char paddingChar)
//        {
//            return this.PadHelper(totalWidth, paddingChar, false);
//        }

//        /// <summary>Returns a new StringBase that left-aligns the characters in this StringBase by padding them with spaces on the right, for a specified total length.</summary>
//        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters. </param>
//        /// <returns>A new StringBase that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new StringBase that is identical to this instance.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="totalWidth" /> is less than zero. </exception>

//        public StringBase PadRight(int totalWidth)
//        {
//            return this.PadHelper(totalWidth, ' ', true);
//        }

//        /// <summary>Returns a new StringBase that left-aligns the characters in this StringBase by padding them on the right with a specified Unicode character, for a specified total length.</summary>
//        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters. </param>
//        /// <param name="paddingChar">A Unicode padding character. </param>
//        /// <returns>A new StringBase that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar" /> characters as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new StringBase that is identical to this instance.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="totalWidth" /> is less than zero. </exception>

//        public StringBase PadRight(int totalWidth, char paddingChar)
//        {
//            return this.PadHelper(totalWidth, paddingChar, true);
//        }

//        [SecuritySafeCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        private extern StringBase PadHelper(int totalWidth, char paddingChar, bool isRightPadded);

//        /// <summary>Determines whether the beginning of this StringBase instance matches the specified string.</summary>
//        /// <param name="value">The StringBase to compare. </param>
//        /// <returns>
//        /// <see langword="true" /> if <paramref name="value" /> matches the beginning of this string; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>

//        public bool StartsWith(StringBase value)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            return this.StartsWith(value, StringComparison.CurrentCulture);
//        }

//        /// <summary>Determines whether the beginning of this StringBase instance matches the specified StringBase when compared using the specified comparison option.</summary>
//        /// <param name="value">The StringBase to compare. </param>
//        /// <param name="comparisonType">One of the enumeration values that determines how this StringBase and <paramref name="value" /> are compared. </param>
//        /// <returns>
//        /// <see langword="true" /> if this instance begins with <paramref name="value" />; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
//        [SecuritySafeCritical]
//        [ComVisible(false)]

//        public bool StartsWith(StringBase value, StringComparison comparisonType)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            switch (comparisonType)
//            {
//                case StringComparison.CurrentCulture:
//                case StringComparison.CurrentCultureIgnoreCase:
//                case StringComparison.InvariantCulture:
//                case StringComparison.InvariantCultureIgnoreCase:
//                case StringComparison.Ordinal:
//                case StringComparison.OrdinalIgnoreCase:
//                    if ((object)this == (object)value || value.Length == 0)
//                        return true;
//                    switch (comparisonType)
//                    {
//                        case StringComparison.CurrentCulture:
//                            return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
//                        case StringComparison.CurrentCultureIgnoreCase:
//                            return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
//                        case StringComparison.InvariantCulture:
//                            return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
//                        case StringComparison.InvariantCultureIgnoreCase:
//                            return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
//                        case StringComparison.Ordinal:
//                            if (this.Length < value.Length)
//                                return false;
//                            return string.nativeCompareOrdinalEx(this, 0, value, 0, value.Length) == 0;
//                        case StringComparison.OrdinalIgnoreCase:
//                            if (this.Length < value.Length)
//                                return false;
//                            return TextInfo.CompareOrdinalIgnoreCaseEx(this, 0, value, 0, value.Length, value.Length) == 0;
//                        default:
//                            throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//                    }
//                default:
//                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof(comparisonType));
//            }
//        }

//        /// <summary>Determines whether the beginning of this StringBase instance matches the specified StringBase when compared using the specified culture.</summary>
//        /// <param name="value">The StringBase to compare. </param>
//        /// <param name="ignoreCase">
//        /// <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
//        /// <param name="culture">Cultural information that determines how this StringBase and <paramref name="value" /> are compared. If <paramref name="culture" /> is <see langword="null" />, the current culture is used.</param>
//        /// <returns>
//        /// <see langword="true" /> if the <paramref name="value" /> parameter matches the beginning of this string; otherwise, <see langword="false" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        public bool StartsWith(StringBase value, bool ignoreCase, CultureInfo culture)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if ((object)this == (object)value)
//                return true;
//            return (culture != null ? culture : CultureInfo.CurrentCulture).CompareInfo.IsPrefix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
//        }

//        /// <summary>Returns a copy of this StringBase converted to lowercase.</summary>
//        /// <returns>A StringBase in lowercase.</returns>

//        public StringBase ToLower()
//        {
//            return this.ToLower(CultureInfo.CurrentCulture);
//        }

//        /// <summary>Returns a copy of this StringBase converted to lowercase, using the casing rules of the specified culture.</summary>
//        /// <param name="culture">An object that supplies culture-specific casing rules. </param>
//        /// <returns>The lowercase equivalent of the current string.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />. </exception>
//        public StringBase ToLower(CultureInfo culture)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            return culture.TextInfo.ToLower(this);
//        }

//        /// <summary>Returns a copy of this <see cref="T:System.String" /> object converted to lowercase using the casing rules of the invariant culture.</summary>
//        /// <returns>The lowercase equivalent of the current string.</returns>

//        public StringBase ToLowerInvariant()
//        {
//            return this.ToLower(CultureInfo.InvariantCulture);
//        }

//        /// <summary>Returns a copy of this StringBase converted to uppercase.</summary>
//        /// <returns>The uppercase equivalent of the current string.</returns>

//        public StringBase ToUpper()
//        {
//            return this.ToUpper(CultureInfo.CurrentCulture);
//        }

//        /// <summary>Returns a copy of this StringBase converted to uppercase, using the casing rules of the specified culture.</summary>
//        /// <param name="culture">An object that supplies culture-specific casing rules. </param>
//        /// <returns>The uppercase equivalent of the current string.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="culture" /> is <see langword="null" />. </exception>
//        public StringBase ToUpper(CultureInfo culture)
//        {
//            if (culture == null)
//                throw new ArgumentNullException(nameof(culture));
//            return culture.TextInfo.ToUpper(this);
//        }

//        /// <summary>Returns a copy of this <see cref="T:System.String" /> object converted to uppercase using the casing rules of the invariant culture.</summary>
//        /// <returns>The uppercase equivalent of the current string.</returns>

//        public StringBase ToUpperInvariant()
//        {
//            return this.ToUpper(CultureInfo.InvariantCulture);
//        }

//        /// <summary>Returns this instance of <see cref="T:System.String" />; no actual conversion is performed.</summary>
//        /// <returns>The current string.</returns>

//        public override StringBase ToString()
//        {
//            return this;
//        }

//        /// <summary>Returns this instance of <see cref="T:System.String" />; no actual conversion is performed.</summary>
//        /// <param name="provider">(Reserved) An object that supplies culture-specific formatting information. </param>
//        /// <returns>The current string.</returns>
//        public StringBase ToString(System.IFormatProvider provider)
//        {
//            return this;
//        }

//        /// <summary>Returns a reference to this instance of <see cref="T:System.String" />.</summary>
//        /// <returns>This instance of <see cref="T:System.String" />.</returns>
//        public object Clone()
//        {
//            return (object)this;
//        }

//        private static bool IsBOMWhitespace(char c)
//        {
//            return false;
//        }

//        /// <summary>Removes all leading and trailing white-space characters from the current <see cref="T:System.String" /> object.</summary>
//        /// <returns>The StringBase that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged. </returns>

//        public StringBase Trim()
//        {
//            return this.TrimHelper(2);
//        }

//        [SecuritySafeCritical]
//        private StringBase TrimHelper(int trimType)
//        {
//            int end = this.Length - 1;
//            int start = 0;
//            if (trimType != 1)
//            {
//                start = 0;
//                while (start < this.Length && (char.IsWhiteSpace(this[start]) || string.IsBOMWhitespace(this[start])))
//                    ++start;
//            }
//            if (trimType != 0)
//            {
//                end = this.Length - 1;
//                while (end >= start && (char.IsWhiteSpace(this[end]) || string.IsBOMWhitespace(this[start])))
//                    --end;
//            }
//            return this.CreateTrimmedString(start, end);
//        }

//        [SecuritySafeCritical]
//        private StringBase TrimHelper(char[] trimChars, int trimType)
//        {
//            int end = this.Length - 1;
//            int start = 0;
//            if (trimType != 1)
//            {
//                for (start = 0; start < this.Length; ++start)
//                {
//                    char ch = this[start];
//                    int index = 0;
//                    while (index < trimChars.Length && (int)trimChars[index] != (int)ch)
//                        ++index;
//                    if (index == trimChars.Length)
//                        break;
//                }
//            }
//            if (trimType != 0)
//            {
//                for (end = this.Length - 1; end >= start; --end)
//                {
//                    char ch = this[end];
//                    int index = 0;
//                    while (index < trimChars.Length && (int)trimChars[index] != (int)ch)
//                        ++index;
//                    if (index == trimChars.Length)
//                        break;
//                }
//            }
//            return this.CreateTrimmedString(start, end);
//        }

//        [SecurityCritical]
//        private StringBase CreateTrimmedString(int start, int end)
//        {
//            int length = end - start + 1;
//            if (length == this.Length)
//                return this;
//            if (length == 0)
//                return string.Empty;
//            return this.InternalSubString(start, length);
//        }

//        /// <summary>
//        /// Returns a new StringBase in which a specified StringBase is inserted at a specified index position in this instance.</summary>
//        /// <param name="startIndex">The zero-based index position of the insertion. </param>
//        /// <param name="value">The StringBase to insert. </param>
//        /// <returns>A new StringBase that is equivalent to this instance, but with <paramref name="value" /> inserted at position <paramref name="startIndex" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="value" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is negative or greater than the length of this instance. </exception>
//        [SecuritySafeCritical]

//        public unsafe StringBase Insert(int startIndex, StringBase value)
//        {
//            if (value == null)
//                throw new ArgumentNullException(nameof(value));
//            if (startIndex < 0 || startIndex > this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex));
//            int length1 = this.Length;
//            int length2 = value.Length;
//            int length3 = length1 + length2;
//            if (length3 == 0)
//                return string.Empty;
//            StringBase str = string.FastAllocateString(length3);
//            fixed (char* smem1 = &this.m_firstChar)
//            fixed (char* smem2 = &value.m_firstChar)
//            fixed (char* dmem = &str.m_firstChar)
//            {
//                string.wstrcpy(dmem, smem1, startIndex);
//                string.wstrcpy(dmem + startIndex, smem2, length2);
//                string.wstrcpy(dmem + startIndex + length2, smem1 + startIndex, length1 - startIndex);
//            }
//            return str;
//        }

//        [SecuritySafeCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        private extern StringBase ReplaceInternal(char oldChar, char newChar);

//        /// <summary>Returns a new StringBase in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.</summary>
//        /// <param name="oldChar">The Unicode character to be replaced. </param>
//        /// <param name="newChar">The Unicode character to replace all occurrences of <paramref name="oldChar" />. </param>
//        /// <returns>A StringBase that is equivalent to this instance except that all instances of <paramref name="oldChar" /> are replaced with <paramref name="newChar" />. If <paramref name="oldChar" /> is not found in the current instance, the method returns the current instance unchanged. </returns>

//        public StringBase Replace(char oldChar, char newChar)
//        {
//            return this.ReplaceInternal(oldChar, newChar);
//        }

//        [SecuritySafeCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        private extern StringBase ReplaceInternal(StringBase oldValue, StringBase newValue);

//        /// <summary>Returns a new StringBase in which all occurrences of a specified StringBase in the current instance are replaced with another specified string.</summary>
//        /// <param name="oldValue">The StringBase to be replaced. </param>
//        /// <param name="newValue">The StringBase to replace all occurrences of <paramref name="oldValue" />. </param>
//        /// <returns>A StringBase that is equivalent to the current StringBase except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" />. If <paramref name="oldValue" /> is not found in the current instance, the method returns the current instance unchanged. </returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="oldValue" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.ArgumentException">
//        /// <paramref name="oldValue" /> is the empty StringBase (""). </exception>

//        public StringBase Replace(StringBase oldValue, StringBase newValue)
//        {
//            if (oldValue == null)
//                throw new ArgumentNullException(nameof(oldValue));
//            return this.ReplaceInternal(oldValue, newValue);
//        }

//        /// <summary>
//        /// Returns a new StringBase in which a specified number of characters in the current instance beginning at a specified position have been deleted.</summary>
//        /// <param name="startIndex">The zero-based position to begin deleting characters. </param>
//        /// <param name="count">The number of characters to delete. </param>
//        /// <returns>A new StringBase that is equivalent to this instance except for the removed characters.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">Either <paramref name="startIndex" /> or <paramref name="count" /> is less than zero.-or-
//        /// <paramref name="startIndex" /> plus <paramref name="count" /> specify a position outside this instance. </exception>
//        [SecuritySafeCritical]

//        public unsafe StringBase Remove(int startIndex, int count)
//        {
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (count < 0)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
//            if (count > this.Length - startIndex)
//                throw new ArgumentOutOfRangeException(nameof(count), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
//            int length = this.Length - count;
//            if (length == 0)
//                return string.Empty;
//            StringBase str = string.FastAllocateString(length);
//            fixed (char* smem = &this.m_firstChar)
//            fixed (char* dmem = &str.m_firstChar)
//            {
//                string.wstrcpy(dmem, smem, startIndex);
//                string.wstrcpy(dmem + startIndex, smem + startIndex + count, length - startIndex);
//            }
//            return str;
//        }

//        /// <summary>
//        /// Returns a new StringBase in which all the characters in the current instance, beginning at a specified position and continuing through the last position, have been deleted.</summary>
//        /// <param name="startIndex">The zero-based position to begin deleting characters. </param>
//        /// <returns>A new StringBase that is equivalent to this StringBase except for the removed characters.</returns>
//        /// <exception cref="T:System.ArgumentOutOfRangeException">
//        /// <paramref name="startIndex" /> is less than zero.-or-
//        /// <paramref name="startIndex" /> specifies a position that is not within this string. </exception>

//        public StringBase Remove(int startIndex)
//        {
//            if (startIndex < 0)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
//            if (startIndex >= this.Length)
//                throw new ArgumentOutOfRangeException(nameof(startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndexLessThanLength"));
//            return this.Substring(0, startIndex);
//        }

//        /// <summary>Replaces one or more format items in a specified StringBase with the StringBase representation of a specified object.</summary>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="arg0">The object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which any format items are replaced by the StringBase representation of <paramref name="arg0" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">The format item in <paramref name="format" /> is invalid.-or- The index of a format item is not zero. </exception>

//        public static StringBase Format(StringBase format, object arg0)
//        {
//            return string.FormatHelper((System.IFormatProvider)null, format, new ParamsArray(arg0));
//        }

//        /// <summary>Replaces the format items in a specified StringBase with the StringBase representation of two specified objects.</summary>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="arg0">The first object to format. </param>
//        /// <param name="arg1">The second object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which format items are replaced by the StringBase representations of <paramref name="arg0" /> and <paramref name="arg1" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is not zero or one. </exception>

//        public static StringBase Format(StringBase format, object arg0, object arg1)
//        {
//            return string.FormatHelper((System.IFormatProvider)null, format, new ParamsArray(arg0, arg1));
//        }

//        /// <summary>Replaces the format items in a specified StringBase with the StringBase representation of three specified objects.</summary>
//        /// <param name="format">A composite format string.</param>
//        /// <param name="arg0">The first object to format. </param>
//        /// <param name="arg1">The second object to format. </param>
//        /// <param name="arg2">The third object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the StringBase representations of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than two. </exception>

//        public static StringBase Format(StringBase format, object arg0, object arg1, object arg2)
//        {
//            return string.FormatHelper((System.IFormatProvider)null, format, new ParamsArray(arg0, arg1, arg2));
//        }

//        /// <summary>Replaces the format item in a specified StringBase with the StringBase representation of a corresponding object in a specified array.</summary>
//        /// <param name="format">A composite format string.</param>
//        /// <param name="args">An object array that contains zero or more objects to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the StringBase representation of the corresponding objects in <paramref name="args" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> or <paramref name="args" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args" /> array. </exception>

//        public static StringBase Format(StringBase format, params object[] args)
//        {
//            if (args == null)
//                throw new ArgumentNullException(format == null ? nameof(format) : nameof(args));
//            return string.FormatHelper((System.IFormatProvider)null, format, new ParamsArray(args));
//        }

//        /// <summary>Replaces the format item or items in a specified StringBase with the StringBase representation of the corresponding object. A parameter supplies culture-specific formatting information. </summary>
//        /// <param name="provider">An object that supplies culture-specific formatting information. </param>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="arg0">The object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which the format item or items have been replaced by the StringBase representation of <paramref name="arg0" />. </returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> or <paramref name="arg0" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than or equal to one. </exception>

//        public static StringBase Format(System.IFormatProvider provider, StringBase format, object arg0)
//        {
//            return string.FormatHelper(provider, format, new ParamsArray(arg0));
//        }

//        /// <summary>Replaces the format items in a specified StringBase with the StringBase representation of two specified objects. A parameter supplies culture-specific formatting information.</summary>
//        /// <param name="provider">An object that supplies culture-specific formatting information. </param>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="arg0">The first object to format. </param>
//        /// <param name="arg1">The second object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which format items are replaced by the StringBase representations of <paramref name="arg0" /> and <paramref name="arg1" />. </returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" />, <paramref name="arg0" />, or <paramref name="arg1" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than or equal to two. </exception>

//        public static StringBase Format(System.IFormatProvider provider, StringBase format, object arg0, object arg1)
//        {
//            return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1));
//        }

//        /// <summary>Replaces the format items in a specified StringBase with the StringBase representation of three specified objects. An parameter supplies culture-specific formatting information. </summary>
//        /// <param name="provider">An object that supplies culture-specific formatting information. </param>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="arg0">The first object to format. </param>
//        /// <param name="arg1">The second object to format. </param>
//        /// <param name="arg2">The third object to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the StringBase representations of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />. </returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" />, <paramref name="arg0" />, <paramref name="arg1" />, or <paramref name="arg2" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than or equal to three. </exception>

//        public static StringBase Format(System.IFormatProvider provider, StringBase format, object arg0, object arg1, object arg2)
//        {
//            return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1, arg2));
//        }

//        /// <summary>Replaces the format items in a specified StringBase with the StringBase representations of corresponding objects in a specified array. A parameter supplies culture-specific formatting information.</summary>
//        /// <param name="provider">An object that supplies culture-specific formatting information. </param>
//        /// <param name="format">A composite format string. </param>
//        /// <param name="args">An object array that contains zero or more objects to format. </param>
//        /// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the StringBase representation of the corresponding objects in <paramref name="args" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="format" /> or <paramref name="args" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.FormatException">
//        /// <paramref name="format" /> is invalid.-or- The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args" /> array. </exception>

//        public static StringBase Format(System.IFormatProvider provider, StringBase format, params object[] args)
//        {
//            if (args == null)
//                throw new ArgumentNullException(format == null ? nameof(format) : nameof(args));
//            return string.FormatHelper(provider, format, new ParamsArray(args));
//        }

//        private static StringBase FormatHelper(System.IFormatProvider provider, StringBase format, ParamsArray args)
//        {
//            if (format == null)
//                throw new ArgumentNullException(nameof(format));
//            return StringBuilderCache.GetStringAndRelease(StringBuilderCache.Acquire(format.Length + args.Length * 8).AppendFormatHelper(provider, format, args));
//        }

//        /// <summary>Creates a new instance of <see cref="T:System.String" /> with the same value as a specified <see cref="T:System.String" />.</summary>
//        /// <param name="str">The StringBase to copy. </param>
//        /// <returns>A new StringBase with the same value as <paramref name="str" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="str" /> is <see langword="null" />. </exception>
//        [SecuritySafeCritical]
//        public static unsafe StringBase Copy(StringBase str)
//        {
//            if (str == null)
//                throw new ArgumentNullException(nameof(str));
//            int length = str.Length;
//            StringBase str1 = string.FastAllocateString(length);
//            fixed (char* dmem = &str1.m_firstChar)
//            fixed (char* smem = &str.m_firstChar)
//                string.wstrcpy(dmem, smem, length);
//            return str1;
//        }

//        /// <summary>Creates the StringBase  representation of a specified object.</summary>
//        /// <param name="arg0">The object to represent, or <see langword="null" />. </param>
//        /// <returns>The StringBase representation of the value of <paramref name="arg0" />, or <see cref="F:System.String.Empty" /> if <paramref name="arg0" /> is <see langword="null" />.</returns>

//        public static StringBase Concat(object arg0)
//        {
//            if (arg0 == null)
//                return string.Empty;
//            return arg0.ToString();
//        }

//        /// <summary>Concatenates the StringBase representations of two specified objects.</summary>
//        /// <param name="arg0">The first object to concatenate. </param>
//        /// <param name="arg1">The second object to concatenate. </param>
//        /// <returns>The concatenated StringBase representations of the values of <paramref name="arg0" /> and <paramref name="arg1" />.</returns>

//        public static StringBase Concat(object arg0, object arg1)
//        {
//            if (arg0 == null)
//                arg0 = (object)string.Empty;
//            if (arg1 == null)
//                arg1 = (object)string.Empty;
//            return arg0.ToString() + arg1.ToString();
//        }

//        /// <summary>Concatenates the StringBase representations of three specified objects.</summary>
//        /// <param name="arg0">The first object to concatenate. </param>
//        /// <param name="arg1">The second object to concatenate. </param>
//        /// <param name="arg2">The third object to concatenate. </param>
//        /// <returns>The concatenated StringBase representations of the values of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.</returns>

//        public static StringBase Concat(object arg0, object arg1, object arg2)
//        {
//            if (arg0 == null)
//                arg0 = (object)string.Empty;
//            if (arg1 == null)
//                arg1 = (object)string.Empty;
//            if (arg2 == null)
//                arg2 = (object)string.Empty;
//            return arg0.ToString() + arg1.ToString() + arg2.ToString();
//        }

//        [CLSCompliant(false)]
//        public static StringBase Concat(object arg0, object arg1, object arg2, object arg3, __arglist)
//        {
//            ArgIterator argIterator = new ArgIterator(__arglist);
//            int length = argIterator.GetRemainingCount() + 4;
//            object[] objArray = new object[length];
//            objArray[0] = arg0;
//            objArray[1] = arg1;
//            objArray[2] = arg2;
//            objArray[3] = arg3;
//            for (int index = 4; index < length; ++index)
//                objArray[index] = TypedReference.ToObject(argIterator.GetNextArg());
//            return string.Concat(objArray);
//        }

//        /// <summary>Concatenates the StringBase representations of the elements in a specified <see cref="T:System.Object" /> array.</summary>
//        /// <param name="args">An object array that contains the elements to concatenate. </param>
//        /// <returns>The concatenated StringBase representations of the values of the elements in <paramref name="args" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="args" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>

//        public static StringBase Concat(params object[] args)
//        {
//            if (args == null)
//                throw new ArgumentNullException(nameof(args));
//            string[] values = new string[args.Length];
//            int totalLength = 0;
//            for (int index = 0; index < args.Length; ++index)
//            {
//                object obj = args[index];
//                values[index] = obj == null ? string.Empty : obj.ToString();
//                if (values[index] == null)
//                    values[index] = string.Empty;
//                totalLength += values[index].Length;
//                if (totalLength < 0)
//                    throw new OutOfMemoryException();
//            }
//            return string.ConcatArray(values, totalLength);
//        }

//        /// <summary>Concatenates the members of an <see cref="T:System.Collections.Generic.IEnumerable`1" /> implementation.</summary>
//        /// <param name="values">A collection object that implements the <see cref="T:System.Collections.Generic.IEnumerable`1" /> interface.</param>
//        /// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
//        /// <returns>The concatenated members in <paramref name="values" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        [ComVisible(false)]

//        public static StringBase Concat<T>(IEnumerable<T> values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            StringBuilder sb = StringBuilderCache.Acquire(16);
//            using (IEnumerator<T> enumerator = values.GetEnumerator())
//            {
//                while (enumerator.MoveNext())
//                {
//                    if ((object)enumerator.Current != null)
//                    {
//                        StringBase str = enumerator.Current.ToString();
//                        if (str != null)
//                            sb.Append(str);
//                    }
//                }
//            }
//            return StringBuilderCache.GetStringAndRelease(sb);
//        }

//        /// <summary>Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />.</summary>
//        /// <param name="values">A collection object that implements <see cref="T:System.Collections.Generic.IEnumerable`1" /> and whose generic type argument is <see cref="T:System.String" />.</param>
//        /// <returns>The concatenated strings in <paramref name="values" />, or <see cref="F:System.String.Empty" /> if <paramref name="values" /> is an empty <see langword="IEnumerable(Of String)" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        [ComVisible(false)]

//        public static StringBase Concat(IEnumerable<string> values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            StringBuilder sb = StringBuilderCache.Acquire(16);
//            using (IEnumerator<string> enumerator = values.GetEnumerator())
//            {
//                while (enumerator.MoveNext())
//                {
//                    if (enumerator.Current != null)
//                        sb.Append(enumerator.Current);
//                }
//            }
//            return StringBuilderCache.GetStringAndRelease(sb);
//        }

//        /// <summary>Concatenates two specified instances of <see cref="T:System.String" />.</summary>
//        /// <param name="str0">The first StringBase to concatenate. </param>
//        /// <param name="str1">The second StringBase to concatenate. </param>
//        /// <returns>The concatenation of <paramref name="str0" /> and <paramref name="str1" />.</returns>
//        [SecuritySafeCritical]

//        public static StringBase Concat(StringBase str0, StringBase str1)
//        {
//            if (string.IsNullOrEmpty(str0))
//            {
//                if (string.IsNullOrEmpty(str1))
//                    return string.Empty;
//                return str1;
//            }
//            if (string.IsNullOrEmpty(str1))
//                return str0;
//            int length = str0.Length;
//            StringBase dest = string.FastAllocateString(length + str1.Length);
//            string.FillStringChecked(dest, 0, str0);
//            string.FillStringChecked(dest, length, str1);
//            return dest;
//        }

//        /// <summary>Concatenates three specified instances of <see cref="T:System.String" />.</summary>
//        /// <param name="str0">The first StringBase to concatenate. </param>
//        /// <param name="str1">The second StringBase to concatenate. </param>
//        /// <param name="str2">The third StringBase to concatenate. </param>
//        /// <returns>The concatenation of <paramref name="str0" />, <paramref name="str1" />, and <paramref name="str2" />.</returns>
//        [SecuritySafeCritical]

//        public static StringBase Concat(StringBase str0, StringBase str1, StringBase str2)
//        {
//            if (str0 == null && str1 == null && str2 == null)
//                return string.Empty;
//            if (str0 == null)
//                str0 = string.Empty;
//            if (str1 == null)
//                str1 = string.Empty;
//            if (str2 == null)
//                str2 = string.Empty;
//            StringBase dest = string.FastAllocateString(str0.Length + str1.Length + str2.Length);
//            string.FillStringChecked(dest, 0, str0);
//            string.FillStringChecked(dest, str0.Length, str1);
//            string.FillStringChecked(dest, str0.Length + str1.Length, str2);
//            return dest;
//        }

//        /// <summary>Concatenates four specified instances of <see cref="T:System.String" />.</summary>
//        /// <param name="str0">The first StringBase to concatenate. </param>
//        /// <param name="str1">The second StringBase to concatenate. </param>
//        /// <param name="str2">The third StringBase to concatenate. </param>
//        /// <param name="str3">The fourth StringBase to concatenate. </param>
//        /// <returns>The concatenation of <paramref name="str0" />, <paramref name="str1" />, <paramref name="str2" />, and <paramref name="str3" />.</returns>
//        [SecuritySafeCritical]

//        public static StringBase Concat(StringBase str0, StringBase str1, StringBase str2, StringBase str3)
//        {
//            if (str0 == null && str1 == null && (str2 == null && str3 == null))
//                return string.Empty;
//            if (str0 == null)
//                str0 = string.Empty;
//            if (str1 == null)
//                str1 = string.Empty;
//            if (str2 == null)
//                str2 = string.Empty;
//            if (str3 == null)
//                str3 = string.Empty;
//            StringBase dest = string.FastAllocateString(str0.Length + str1.Length + str2.Length + str3.Length);
//            string.FillStringChecked(dest, 0, str0);
//            string.FillStringChecked(dest, str0.Length, str1);
//            string.FillStringChecked(dest, str0.Length + str1.Length, str2);
//            string.FillStringChecked(dest, str0.Length + str1.Length + str2.Length, str3);
//            return dest;
//        }

//        [SecuritySafeCritical]
//        private static StringBase ConcatArray(string[] values, int totalLength)
//        {
//            StringBase dest = string.FastAllocateString(totalLength);
//            int destPos = 0;
//            for (int index = 0; index < values.Length; ++index)
//            {
//                string.FillStringChecked(dest, destPos, values[index]);
//                destPos += values[index].Length;
//            }
//            return dest;
//        }

//        /// <summary>Concatenates the elements of a specified <see cref="T:System.String" /> array.</summary>
//        /// <param name="values">An array of StringBase instances. </param>
//        /// <returns>The concatenated elements of <paramref name="values" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="values" /> is <see langword="null" />. </exception>
//        /// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>

//        public static StringBase Concat(params string[] values)
//        {
//            if (values == null)
//                throw new ArgumentNullException(nameof(values));
//            int totalLength = 0;
//            string[] values1 = new string[values.Length];
//            for (int index = 0; index < values.Length; ++index)
//            {
//                StringBase str = values[index];
//                values1[index] = str == null ? string.Empty : str;
//                totalLength += values1[index].Length;
//                if (totalLength < 0)
//                    throw new OutOfMemoryException();
//            }
//            return string.ConcatArray(values1, totalLength);
//        }

//        /// <summary>Retrieves the system's reference to the specified <see cref="T:System.String" />.</summary>
//        /// <param name="str">A StringBase to search for in the intern pool. </param>
//        /// <returns>The system's reference to <paramref name="str" />, if it is interned; otherwise, a new reference to a StringBase with the value of <paramref name="str" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="str" /> is <see langword="null" />. </exception>
//        [SecuritySafeCritical]
//        public static StringBase Intern(StringBase str)
//        {
//            if (str == null)
//                throw new ArgumentNullException(nameof(str));
//            return Thread.GetDomain().GetOrInternString(str);
//        }

//        /// <summary>Retrieves a reference to a specified <see cref="T:System.String" />.</summary>
//        /// <param name="str">The StringBase to search for in the intern pool. </param>
//        /// <returns>A reference to <paramref name="str" /> if it is in the common language runtime intern pool; otherwise, <see langword="null" />.</returns>
//        /// <exception cref="T:System.ArgumentNullException">
//        /// <paramref name="str" /> is <see langword="null" />. </exception>
//        [SecuritySafeCritical]
//        public static StringBase IsInterned(StringBase str)
//        {
//            if (str == null)
//                throw new ArgumentNullException(nameof(str));
//            return Thread.GetDomain().IsStringInterned(str);
//        }

//        /// <summary>Returns the <see cref="T:System.TypeCode" /> for class <see cref="T:System.String" />.</summary>
//        /// <returns>The enumerated constant, <see cref="F:System.TypeCode.String" />.</returns>
//        public TypeCode GetTypeCode()
//        {
//            return TypeCode.String;
//        }

//        bool System.IConvertible.ToBoolean(System.IFormatProvider provider)
//        {
//            return System.Convert.ToBoolean(this, provider);
//        }

//        char System.IConvertible.ToChar(System.IFormatProvider provider)
//        {
//            return System.Convert.ToChar(this, provider);
//        }

//        sbyte System.IConvertible.ToSByte(System.IFormatProvider provider)
//        {
//            return System.Convert.ToSByte(this, provider);
//        }

//        byte System.IConvertible.ToByte(System.IFormatProvider provider)
//        {
//            return System.Convert.ToByte(this, provider);
//        }

//        short System.IConvertible.ToInt16(System.IFormatProvider provider)
//        {
//            return System.Convert.ToInt16(this, provider);
//        }

//        ushort System.IConvertible.ToUInt16(System.IFormatProvider provider)
//        {
//            return System.Convert.ToUInt16(this, provider);
//        }

//        int System.IConvertible.ToInt32(System.IFormatProvider provider)
//        {
//            return System.Convert.ToInt32(this, provider);
//        }

//        uint System.IConvertible.ToUInt32(System.IFormatProvider provider)
//        {
//            return System.Convert.ToUInt32(this, provider);
//        }

//        long System.IConvertible.ToInt64(System.IFormatProvider provider)
//        {
//            return System.Convert.ToInt64(this, provider);
//        }

//        ulong System.IConvertible.ToUInt64(System.IFormatProvider provider)
//        {
//            return System.Convert.ToUInt64(this, provider);
//        }

//        float System.IConvertible.ToSingle(System.IFormatProvider provider)
//        {
//            return System.Convert.ToSingle(this, provider);
//        }

//        double System.IConvertible.ToDouble(System.IFormatProvider provider)
//        {
//            return System.Convert.ToDouble(this, provider);
//        }

//        Decimal System.IConvertible.ToDecimal(System.IFormatProvider provider)
//        {
//            return System.Convert.ToDecimal(this, provider);
//        }

//        DateTime System.IConvertible.ToDateTime(System.IFormatProvider provider)
//        {
//            return System.Convert.ToDateTime(this, provider);
//        }

//        object System.IConvertible.ToType(Type type, System.IFormatProvider provider)
//        {
//            return System.Convert.DefaultToType((System.IConvertible)this, type, provider);
//        }

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal extern bool IsFastSort();

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal extern bool IsAscii();

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal extern void SetTrailByte(byte data);

//        [SecurityCritical]
//        [MethodImpl(MethodImplOptions.InternalCall)]
//        internal extern bool TryGetTrailByte(out byte data);

//        /// <summary>Retrieves an object that can iterate through the individual characters in this string.</summary>
//        /// <returns>An enumerator object.</returns>
//        public CharEnumerator GetEnumerator()
//        {
//            return new CharEnumerator(this);
//        }

//        IEnumerator<char> IEnumerable<char>.GetEnumerator()
//        {
//            return (IEnumerator<char>)new CharEnumerator(this);
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return (IEnumerator)new CharEnumerator(this);
//        }

//        [SecurityCritical]
//        internal static unsafe void InternalCopy(StringBase src, IntPtr dest, int len)
//        {
//            if (len == 0)
//                return;
//            fixed (char* chPtr = &src.m_firstChar)
//                Buffer.Memcpy((byte*)(void*)dest, (byte*)chPtr, len);
//        }
//    }
//}

