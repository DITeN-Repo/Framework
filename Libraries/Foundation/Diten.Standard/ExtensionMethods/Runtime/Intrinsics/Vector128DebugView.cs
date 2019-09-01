#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/18 7:27 PM

#endregion

#region Used Directives

using Diten.Runtime.CompilerServices;
using System.Runtime.CompilerServices;

#endregion

namespace Diten.Runtime.Intrinsics
{
	internal readonly struct Vector128DebugView<T> where T : struct
	{
		private readonly Vector128<T> _value;

		public Vector128DebugView(Vector128<T> value)
		{
			_value=value;
		}

		[Nullable(new byte[] { 1, 0 })]
		public byte[] ByteView
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new byte[16];
				Unsafe.WriteUnaligned(ref numArray[0], _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public double[] DoubleView
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new double[2];
				Unsafe.WriteUnaligned(ref Unsafe.As<double, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public short[] Int16View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new short[8];
				Unsafe.WriteUnaligned(ref Unsafe.As<short, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public int[] Int32View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new int[4];
				Unsafe.WriteUnaligned(ref Unsafe.As<int, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public long[] Int64View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new long[2];
				Unsafe.WriteUnaligned(ref Unsafe.As<long, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public sbyte[] SByteView
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new sbyte[16];
				Unsafe.WriteUnaligned(ref Unsafe.As<sbyte, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public float[] SingleView
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new float[4];
				Unsafe.WriteUnaligned(ref Unsafe.As<float, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public ushort[] UInt16View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new ushort[8];
				Unsafe.WriteUnaligned(ref Unsafe.As<ushort, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public uint[] UInt32View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new uint[4];
				Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}

		[Nullable(new byte[] { 1, 0 })]
		public ulong[] UInt64View
		{
			[return: Nullable(new byte[] { 1, 0 })]
			get
			{
				var numArray = new ulong[2];
				Unsafe.WriteUnaligned(ref Unsafe.As<ulong, byte>(ref numArray[0]), _value);
				return numArray;
			}
		}
	}
}