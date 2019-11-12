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
// Creation Date: 2019/08/18 6:56 PM

#region Used Directives

using EX = Diten.Parameters.Exceptions;

#endregion

//namespace Diten.Collections
//{
//	[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
//	[Serializable]
//	public sealed class BitArray : ICollection, IEnumerable, ICloneable
//	{
//		private int _version;
//		private int[] m_array;

//		public BitArray(int length)
//			: this(length, false)
//		{
//		}

//		public BitArray(int length, bool defaultValue)
//		{
//			if (length < 0)
//				throw new ArgumentOutOfRangeException(nameof(length), length, EX.ArgumentOutOfRange_NeedNonNegNum);
//			m_array = new int[GetInt32ArrayLengthFromBitLength(length)];
//			Count = length;
//			if (defaultValue)
//				m_array.AsSpan().Fill(-1);
//			_version = 0;
//		}

//		public BitArray(byte[] bytes)
//		{
//			if (bytes == null)
//				throw new ArgumentNullException(nameof(bytes));
//			if (bytes.Length > 268435455)
//				throw new ArgumentException(System.String.Format(EX.Argument_ArrayTooLarge, 8), nameof(bytes));
//			m_array = new int[GetInt32ArrayLengthFromByteLength(bytes.Length)];
//			Count = bytes.Length * 8;
//			var num1 = (uint) bytes.Length / 4U;
//			var source = (ReadOnlySpan<System.Byte>) bytes;
//			for (var index = 0; (long) index < (long) num1; ++index)
//			{
//				m_array[index] = BinaryPrimitives.ReadInt32LittleEndian(source);
//				source = source.Slice(4);
//			}

//			var num2 = 0;
//			switch (source.Length)
//			{
//				case 1:
//					m_array[(int) num1] = num2 | source[0];
//					break;
//				case 2:
//					num2 |= source[1] << 8;
//					goto case 1;
//				case 3:
//					num2 = source[2] << 16;
//					goto case 2;
//			}

//			_version = 0;
//		}

//		public BitArray(bool[] values)
//		{
//			if (values == null)
//				throw new ArgumentNullException(nameof(values));
//			m_array = new int[GetInt32ArrayLengthFromBitLength(values.Length)];
//			Count = values.Length;
//			for (var number = 0; number < values.Length; ++number)
//				if (values[number])
//				{
//					int remainder;
//					m_array[Div32Rem(number, out remainder)] |= 1 << remainder;
//				}

//			_version = 0;
//		}

//		public BitArray(int[] values)
//		{
//			if (values == null)
//				throw new ArgumentNullException(nameof(values));
//			if (values.Length > 67108863)
//				throw new ArgumentException(System.String.Format(EX.Argument_ArrayTooLarge, 32), nameof(values));
//			m_array = new int[values.Length];
//			Array.Copy(values, 0, m_array, 0, values.Length);
//			Count = values.Length * 32;
//			_version = 0;
//		}

//		public BitArray(BitArray bits)
//		{
//			if (bits == null)
//				throw new ArgumentNullException(nameof(bits));
//			var lengthFromBitLength = GetInt32ArrayLengthFromBitLength(bits.Count);
//			m_array = new int[lengthFromBitLength];
//			Array.Copy(bits.m_array, 0, m_array, 0, lengthFromBitLength);
//			Count = bits.Count;
//			_version = bits._version;
//		}

//		public Boolean this[int index]
//		{
//			get => Get(index);
//			set => Set(index, value);
//		}

//		public Int32 Length
//		{
//			get => Count;
//			set
//			{
//				if (value < 0)
//					throw new ArgumentOutOfRangeException(nameof(value), value, EX.ArgumentOutOfRange_NeedNonNegNum);
//				var lengthFromBitLength = GetInt32ArrayLengthFromBitLength(value);
//				if (lengthFromBitLength > m_array.Length || lengthFromBitLength + 256 < m_array.Length)
//					Array.Resize(ref m_array, lengthFromBitLength);
//				if (value > Count)
//				{
//					var index = (Count - 1) >> 5;
//					int remainder;
//					Div32Rem(Count, out remainder);
//					if (remainder > 0)
//						m_array[index] &= (1 << remainder) - 1;
//					m_array.AsSpan(index + 1, lengthFromBitLength - index - 1).Clear();
//				}

//				Count = value;
//				++_version;
//			}
//		}

//		public Boolean IsReadOnly => false;

//		public object Clone() => new BitArray(this);

//		public void CopyTo(Array array, int index)
//		{
//			if (array == null)
//				throw new ArgumentNullException(nameof(array));
//			if (index < 0)
//				throw new ArgumentOutOfRangeException(nameof(index), index, EX.ArgumentOutOfRange_NeedNonNegNum);
//			if (array.Rank != 1)
//				throw new ArgumentException(EX.Arg_RankMultiDimNotSupported, nameof(array));
//			var numArray = array as int[];
//			if (numArray != null)
//			{
//				int remainder;
//				Div32Rem(Count, out remainder);
//				if (remainder == 0)
//				{
//					Array.Copy(m_array, 0, numArray, index, m_array.Length);
//				}
//				else
//				{
//					var length = (Count - 1) >> 5;
//					Array.Copy(m_array, 0, numArray, index, length);
//					numArray[index + length] = m_array[length] & ((1 << remainder) - 1);
//				}
//			}
//			else
//			{
//				var array1 = array as byte[];
//				if (array1 != null)
//				{
//					var lengthFromBitLength = GetByteArrayLengthFromBitLength(Count);
//					if (array.Length - index < lengthFromBitLength)
//						throw new ArgumentException(EX.Argument_InvalidOffLen);
//					var num = (uint) (Count & 7);
//					if (num > 0U)
//						--lengthFromBitLength;
//					var destination = array1.AsSpan(index);
//					int remainder;
//					var index1 = Div4Rem(lengthFromBitLength, out remainder);
//					for (var index2 = 0; index2 < index1; ++index2)
//					{
//						BinaryPrimitives.WriteInt32LittleEndian(destination, m_array[index2]);
//						destination = destination.Slice(4);
//					}

//					if (num > 0U)
//						destination[destination.Length - 1] =
//							(byte) ((m_array[index1] >> (remainder * 8)) & ((1 << (int) num) - 1));
//					switch (remainder)
//					{
//						case 1:
//							destination[0] = (byte) m_array[index1];
//							break;
//						case 2:
//							destination[1] = (byte) (m_array[index1] >> 8);
//							goto case 1;
//						case 3:
//							destination[2] = (byte) (m_array[index1] >> 16);
//							goto case 2;
//					}
//				}
//				else
//				{
//					var flagArray = array as bool[];
//					if (flagArray == null)
//						throw new ArgumentException(EX.Arg_BitArrayTypeUnsupported, nameof(array));
//					if (array.Length - index < Count)
//						throw new ArgumentException(EX.Argument_InvalidOffLen);
//					for (var number = 0; number < Count; ++number)
//					{
//						int remainder;
//						var index1 = Div32Rem(number, out remainder);
//						flagArray[index + number] = (uint) ((m_array[index1] >> remainder) & 1) > 0U;
//					}
//				}
//			}
//		}

//		public Int32 Count { get; private set; }

//		public object SyncRoot => this;

//		public Boolean IsSynchronized => false;

//		public IEnumerator GetEnumerator() => new BitArrayEnumeratorSimple(this);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		public Boolean Get(int index)
//		{
//			if ((uint) index >= (uint) Count)
//				ThrowArgumentOutOfRangeException(index);
//			return (uint) (m_array[index >> 5] & (1 << index)) > 0U;
//		}

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		public void Set(int index, bool value)
//		{
//			if ((uint) index >= (uint) Count)
//				ThrowArgumentOutOfRangeException(index);
//			var num = 1 << index;
//			ref var local = ref m_array[index >> 5];
//			if (value)
//				local |= num;
//			else
//				local &= ~num;
//			++_version;
//		}

//		public void SetAll(bool value)
//		{
//			var num1 = value ? -1 : 0;
//			foreach (var num2 in m_array)
//				num2 = num1;
//			++_version;
//		}

//		public unsafe BitArray And(BitArray value)
//		{
//			if (value == null)
//				throw new ArgumentNullException(nameof(value));
//			if (Length != value.Length)
//				throw new ArgumentException(EX.Arg_ArrayLengthsDiffer);
//			var length = m_array.Length;
//			switch (length)
//			{
//				case 0:
//					++_version;
//					return this;
//				case 1:
//					m_array[0] &= value.m_array[0];
//					goto case 0;
//				case 2:
//					m_array[1] &= value.m_array[1];
//					goto case 1;
//				case 3:
//					m_array[2] &= value.m_array[2];
//					goto case 2;
//				default:
//					var index = 0;
//					if (Sse2.IsSupported)
//						fixed (int* numPtr1 = m_array)
//						fixed (int* numPtr2 = value.m_array)
//							for (; index < length - (Vector128<int>.Count - 1); index += Vector128<int>.Count)
//							{
//								Vector128<int> left = Sse2.LoadVector128(numPtr1 + index);
//								Vector128<int> right = Sse2.LoadVector128(numPtr2 + index);
//								Sse2.Store(numPtr1 + index, Sse2.And(left, right));
//							}

//					for (; index < length; ++index)
//						m_array[index] &= value.m_array[index];
//					goto case 0;
//			}
//		}

//		public unsafe BitArray Or(BitArray value)
//		{
//			if (value == null)
//				throw new ArgumentNullException(nameof(value));
//			if (Length != value.Length)
//				throw new ArgumentException(EX.Arg_ArrayLengthsDiffer);
//			var length = m_array.Length;
//			switch (length)
//			{
//				case 0:
//					++_version;
//					return this;
//				case 1:
//					m_array[0] |= value.m_array[0];
//					goto case 0;
//				case 2:
//					m_array[1] |= value.m_array[1];
//					goto case 1;
//				case 3:
//					m_array[2] |= value.m_array[2];
//					goto case 2;
//				default:
//					var index = 0;
//					if (Sse2.IsSupported)
//						fixed (int* numPtr1 = m_array)
//						fixed (int* numPtr2 = value.m_array)
//							for (; index < length - (Vector128<int>.Count - 1); index += Vector128<int>.Count)
//							{
//								Vector128<int> left = Sse2.LoadVector128(numPtr1 + index);
//								Vector128<int> right = Sse2.LoadVector128(numPtr2 + index);
//								Sse2.Store(numPtr1 + index, Sse2.Or(left, right));
//							}

//					for (; index < length; ++index)
//						m_array[index] |= value.m_array[index];
//					goto case 0;
//			}
//		}

//		public unsafe BitArray Xor(BitArray value)
//		{
//			if (value == null)
//				throw new ArgumentNullException(nameof(value));
//			if (Length != value.Length)
//				throw new ArgumentException(EX.Arg_ArrayLengthsDiffer);
//			var length = m_array.Length;
//			switch (length)
//			{
//				case 0:
//					++_version;
//					return this;
//				case 1:
//					m_array[0] ^= value.m_array[0];
//					goto case 0;
//				case 2:
//					m_array[1] ^= value.m_array[1];
//					goto case 1;
//				case 3:
//					m_array[2] ^= value.m_array[2];
//					goto case 2;
//				default:
//					var index = 0;
//					if (Sse2.IsSupported)
//						fixed (int* numPtr1 = m_array)
//						fixed (int* numPtr2 = value.m_array)
//							for (; index < length - (Vector128<int>.Count - 1); index += Vector128<int>.Count)
//							{
//								Vector128<int> left = Sse2.LoadVector128(numPtr1 + index);
//								Vector128<int> right = Sse2.LoadVector128(numPtr2 + index);
//								Sse2.Store(numPtr1 + index, Sse2.Xor(left, right));
//							}

//					for (; index < length; ++index)
//						m_array[index] ^= value.m_array[index];
//					goto case 0;
//			}
//		}

//		public BitArray Not()
//		{
//			var array = m_array;
//			for (var index = 0; index < array.Length; ++index)
//				array[index] = ~array[index];
//			++_version;
//			return this;
//		}

//		public BitArray RightShift(int count)
//		{
//			if (count <= 0)
//			{
//				if (count < 0)
//					throw new ArgumentOutOfRangeException(nameof(count), count, EX.ArgumentOutOfRange_NeedNonNegNum);
//				++_version;
//				return this;
//			}

//			var start = 0;
//			var lengthFromBitLength = GetInt32ArrayLengthFromBitLength(Count);
//			if (count < Count)
//			{
//				int remainder1;
//				var sourceIndex = Div32Rem(count, out remainder1);
//				int remainder2;
//				Div32Rem(Count, out remainder2);
//				if (remainder1 == 0)
//				{
//					var num = uint.MaxValue >> (32 - remainder2);
//					m_array[lengthFromBitLength - 1] &= (int) num;
//					Array.Copy(m_array, sourceIndex, m_array, 0, lengthFromBitLength - sourceIndex);
//					start = lengthFromBitLength - sourceIndex;
//				}
//				else
//				{
//					var num1 = lengthFromBitLength - 1;
//					while (sourceIndex < num1)
//					{
//						var num2 = (uint) m_array[sourceIndex] >> remainder1;
//						var num3 = m_array[++sourceIndex] << (32 - remainder1);
//						m_array[start++] = num3 | (int) num2;
//					}

//					var num4 = (uint.MaxValue >> (32 - remainder2)) & (uint) m_array[sourceIndex];
//					m_array[start++] = (int) (num4 >> remainder1);
//				}
//			}

//			m_array.AsSpan(start, lengthFromBitLength - start).Clear();
//			++_version;
//			return this;
//		}

//		public BitArray LeftShift(int count)
//		{
//			if (count <= 0)
//			{
//				if (count < 0)
//					throw new ArgumentOutOfRangeException(nameof(count), count, EX.ArgumentOutOfRange_NeedNonNegNum);
//				++_version;
//				return this;
//			}

//			int num1;
//			if (count < Count)
//			{
//				var index1 = (Count - 1) >> 5;
//				int remainder;
//				num1 = Div32Rem(count, out remainder);
//				if (remainder == 0)
//				{
//					Array.Copy(m_array, 0, m_array, num1, index1 + 1 - num1);
//				}
//				else
//				{
//					var index2 = index1 - num1;
//					while (index2 > 0)
//					{
//						var num2 = m_array[index2] << remainder;
//						var num3 = (uint) m_array[--index2] >> (32 - remainder);
//						m_array[index1] = num2 | (int) num3;
//						--index1;
//					}

//					m_array[index1] = m_array[index2] << remainder;
//				}
//			}
//			else
//			{
//				num1 = GetInt32ArrayLengthFromBitLength(Count);
//			}

//			m_array.AsSpan(0, num1).Clear();
//			++_version;
//			return this;
//		}

//		private static int GetInt32ArrayLengthFromBitLength(int n) => (int) ((uint) (n - 1 + 32) >> 5);

//		private static int GetInt32ArrayLengthFromByteLength(int n) => (int) ((uint) (n - 1 + 4) >> 2);

//		private static int GetByteArrayLengthFromBitLength(int n) => (int) ((uint) (n - 1 + 8) >> 3);

//		private static int Div32Rem(int number, out int remainder)
//		{
//			var num = (uint) number / 32U;
//			remainder = number & 31;
//			return (int) num;
//		}

//		private static int Div4Rem(int number, out int remainder)
//		{
//			var num = (uint) number / 4U;
//			remainder = number & 3;
//			return (int) num;
//		}

//		private static void ThrowArgumentOutOfRangeException(int index)
//		{
//			throw new ArgumentOutOfRangeException(nameof(index), index, EX.ArgumentOutOfRange_Index);
//		}

//		private class BitArrayEnumeratorSimple : IEnumerator, ICloneable
//		{
//			private readonly BitArray _bitarray;
//			private readonly int _version;
//			private bool _currentElement;
//			private int _index;

//			internal BitArrayEnumeratorSimple(BitArray bitarray)
//			{
//				_bitarray = bitarray;
//				_index = -1;
//				_version = bitarray._version;
//			}

//			public object Clone() => MemberwiseClone();

//			public virtual bool MoveNext()
//			{
//				var bitarray = (ICollection) _bitarray;
//				if (_version != _bitarray._version)
//					throw new InvalidOperationException(EX.InvalidOperation_EnumFailedVersion);
//				if (_index < bitarray.Count - 1)
//				{
//					++_index;
//					_currentElement = _bitarray.Get(_index);
//					return true;
//				}

//				_index = bitarray.Count;
//				return false;
//			}

//			public virtual object Current
//			{
//				get
//				{
//					if ((uint) _index >= (uint) _bitarray.Count)
//						throw GetInvalidOperationException(_index);
//					return _currentElement;
//				}
//			}

//			public void Reset()
//			{
//				if (_version != _bitarray._version)
//					throw new InvalidOperationException(EX.InvalidOperation_EnumFailedVersion);
//				_index = -1;
//			}

//			private InvalidOperationException GetInvalidOperationException(
//				int index)
//			{
//				if (index == -1)
//					return new InvalidOperationException(EX.InvalidOperation_EnumNotStarted);
//				return new InvalidOperationException(EX.InvalidOperation_EnumEnded);
//			}
//		}
//	}
//}