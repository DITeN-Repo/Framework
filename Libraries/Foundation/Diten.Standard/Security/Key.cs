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
// Creation Date: 2019/08/15 8:37 PM

#region Used Directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Diten.Attributes;
using Diten.Drawing.Bitmap;
using Diten.Parameters;
using MongoDB.Bson.Serialization.Attributes;
using Org.BouncyCastle.Security;

#endregion

namespace Diten.Security
{
	[DefaultProperty("Value")]
	public class Key
	{
		/// <summary>
		///    Length types for generating key.
		/// </summary>
		public enum LengthTypes
		{
			K16 = 16,
			K32 = 32,
			K64 = 64,
			K128 = 128,
			K256 = 256,
			K512 = 512,
			K768 = 768,
			K1024 = 1024,
			K2048 = 2048,
			K4094 = 4096,
			K8192 = 8192,
			K16384 = 16384
		}

		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="length"
		///        default="512 bytes key">
		///    Length of the ke that must be generated.
		/// </param>
		public Key(LengthTypes length = LengthTypes.K512): this(null,
		                                                        length) {}

		public Key(): this(null) {}

		private Key(byte[] value,
		            LengthTypes length = LengthTypes.K512)
		{
			LengthType = length;

			if (value is null)
			{
				var random = new Random();
				var holder = new byte[(int) LengthType * 2];

				for (var i = 0;
				     i <= holder.Length - 1;
				     i++)
					holder[i] += BitConverter.GetBytes(random.Next(0,
					                                               255))[0];
				Value = holder;
			}
			else { Value = value; }
		}

		/// <summary>
		///    Length of the key value.
		/// </summary>
		[BsonIgnore]
		[NonSerializable]
		public int Length => Value.Length;

		[BsonIgnore]
		[NonSerializable]
		private LengthTypes LengthType {get;}

		[BsonIgnore]
		[NonSerializable]
		private Random Random => _random ?? (_random = new Random());

		/// <summary>
		///    Value of the key.
		/// </summary>
		public byte[] Value {get;}

		[BsonIgnore]
		[NonSerialized]
		[NonSerializable]
		private Random _random;

		/// <summary>
		///    Control equality between two keys.
		/// </summary>
		/// <param name="primary">Primary key to control.</param>
		/// <param name="secondary">Secondary key to control.</param>
		/// <returns>True if the keys are equal.</returns>
		public static bool Equals(Key primary,
		                          Key secondary)
		{
			return StructuralComparisons.StructuralEqualityComparer.Equals(primary.Value,
			                                                               secondary.Value);
		}

		/// <summary>
		///    Control equality with a key.
		/// </summary>
		/// <param name="value">Source key to control.</param>
		/// <returns>True if the source key is equal.</returns>
		public bool Equals(Key value)
		{
			return Equals(value,
			              this);
		}

		/// <summary>
		///    Overlay a key on current value.
		/// </summary>
		/// <param name="value">The key that must be overlaid.</param>
		/// <returns>A key.</returns>
		public Key Overlay(Key value)
		{
			if (!value.Length.Equals(Value.Length)) throw new InvalidKeyException(Exceptions.Default.Diten_SameLenght.Format("both keys"));

			var holder = new byte[value.Length];

			for (var i = 0;
			     i < value.Length;
			     i += 4)
			{
				var tmp2 = new short[4];
				var tmp1 = new short[4];

				for (var j = 0;
				     j < 4;
				     j++)
				{
					tmp1[j] = Value[i + j];
					tmp2[j] = (short) Random.Next(0,
					                              255);
				}

				foreach (var b in new Pixel(tmp1[0],
				                            tmp1[1],
				                            tmp1[2],
				                            tmp1[3])
					.Overlay(new Pixel(tmp2[0],
					                   tmp1[1],
					                   tmp1[2],
					                   tmp1[3]))) holder.Append(b);
			}

			return new Key(holder);
			//ToDo: Remove Commented code.
			//Task.Factory.StartNew(() =>
			//{
			//	var val = Task.Factory.StartNew(() => value.Value);

			//	for (var i = 0; i < val.Result.Length; i += 4)
			//	{
			//		var tmp2 = new short[4];
			//		var tmp1 = new short[4];

			//		for (var j = 0; j < 4; j++)
			//		{
			//			tmp1[j] = Value[i + j];
			//			tmp2[j] = (short) Random.Next(0, 255);
			//		}

			//		//using (var tmpBitmap1 = new Bitmap(1, 1))
			//		//{
			//		//	tmpBitmap1.SetPixel(0, 0, Color.FromArgb(tmp1[0], tmp1[1], tmp1[2], tmp1[3]));

			//		//	using (var tmpBitmap2 = new Bitmap(1, 1))
			//		//	{
			//		//		tmpBitmap1.SetPixel(0, 0,
			//		//			Color.FromArgb(tmp2[0], tmp2[1], tmp2[2], tmp2[3]));
			//		//		Graphics.FromImage(tmpBitmap1).DrawImageUnscaled(tmpBitmap2, 0, 0);
			//		//		var color = tmpBitmap1.GetPixel(0, 0);
			//		//		Value[i] = color.A;
			//		//		Value[i + 1] = color.R;
			//		//		Value[i + 2] = color.G;
			//		//		Value[i + 3] = color.B;
			//		//	}
			//		//}
			//	}
			//});
		}

		/// <summary>
		///    Converting the key value to hex.
		/// </summary>
		/// <returns>A hex string number.</returns>
		public string ToHex() { return Value.ToHex(); }
	}
}