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
// Creation Date: 2019/08/18 7:12 PM

#region Used Directives

using EX = Diten.Parameters.Exceptions;

#endregion

//namespace Diten.Runtime.Intrinsics
//{
//	[DebuggerTypeProxy(typeof(Vector128DebugView<>))]
//	[Intrinsic]
//	[DebuggerDisplay("{" + nameof(DisplayString) + ",nq}")]
//	[StructLayout(LayoutKind.Sequential, Size = 16)]
//	public readonly struct Vector128<T> : IEquatable<Vector128<T>>, IFormattable
//		where T : struct
//	{
//		private readonly ulong _00;
//		private readonly ulong _01;

//		public static int Count
//		{
//			get
//			{
//				ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
//				return 16 / Unsafe.SizeOf<T>();
//			}
//		}

//		public static Vector128<T> Zero
//		{
//			[Intrinsic]
//			get
//			{
//				ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
//				return new Vector128<T>();
//			}
//		}

//		[Nullable(1)]
//		internal string DisplayString
//		{
//			[return: Nullable(1)] get => IsSupported ? ToString() : EX.NotSupported_Type;
//		}

//		internal static bool IsSupported
//		{
//			[MethodImpl(MethodImplOptions.AggressiveInlining)]
//			get
//			{
//				if (!(typeof(T) == typeof(byte)) && !(typeof(T) == typeof(sbyte)) && !(typeof(T) == typeof(short)) &&
//				    !(typeof(T) == typeof(ushort)) && !(typeof(T) == typeof(int)) && !(typeof(T) == typeof(uint)) &&
//				    !(typeof(T) == typeof(long)) && !(typeof(T) == typeof(ulong)) && !(typeof(T) == typeof(float)))
//					return typeof(T) == typeof(double);
//				return true;
//			}
//		}

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		public Boolean Equals(Vector128<T> other)
//		{
//			ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
//			if (Sse.IsSupported && typeof(T) == typeof(float))
//				return Sse.MoveMask(Sse.CompareEqual(this.AsSingle<T>(), other.AsSingle<T>())) == 15;
//			if (!Sse2.IsSupported)
//				return SoftwareFallback(in this, other);
//			if (typeof(T) == typeof(double))
//				return Sse2.MoveMask(Sse2.CompareEqual(this.AsDouble<T>(), other.AsDouble<T>())) == 3;
//			return Sse2.MoveMask(Sse2.CompareEqual(this.AsByte<T>(), other.AsByte<T>())) == ushort.MaxValue;

//			bool SoftwareFallback(in Vector128<T> vector, Vector128<T> other2)
//			{
//				for (var index = 0; index < Count; ++index)
//					if (!((IEquatable<T>) vector.GetElement<T>(index)).Equals(other2.GetElement<T>(index)))
//						return false;
//				return true;
//			}
//		}

//		public override bool Equals([Nullable(2)] object obj)
//		{
//			if (obj is Vector128<T>)
//				return Equals((Vector128<T>) obj);
//			return false;
//		}

//		public override int GetHashCode()
//		{
//			ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
//			var num = 0;
//			for (var index = 0; index < Count; ++index)
//				num = HashCode.Combine<int, int>(num, this.GetElement<T>(index).GetHashCode());
//			return num;
//		}

//		[return: Nullable(1)]
//		public override string ToString() => ToString("G");

//		[return: Nullable(1)]
//		public System.String ToString([Nullable(2)] string format) => ToString(format, null);

//		[return: Nullable(1)]
//		public System.String ToString([Nullable(2)] string format, [Nullable(2)] IFormatProvider formatProvider)
//		{
//			ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
//			var numberGroupSeparator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
//			var index1 = Count - 1;
//			StringBuilder sb = StringBuilderCache.Acquire(16);
//			sb.Append('<');
//			for (var index2 = 0; index2 < index1; ++index2)
//			{
//				sb.Append(((IFormattable) this.GetElement<T>(index2)).ToString(format, formatProvider));
//				sb.Append(numberGroupSeparator);
//				sb.Append(' ');
//			}

//			sb.Append(((IFormattable) this.GetElement<T>(index1)).ToString(format, formatProvider));
//			sb.Append('>');
//			return StringBuilderCache.GetStringAndRelease(sb);
//		}
//	}
//}