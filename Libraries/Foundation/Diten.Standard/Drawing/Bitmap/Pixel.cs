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
// Creation Date: 2019/09/12 6:43 PM

#region Used Directives

#endregion

#region Used Directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Diten.Drawing.Bitmap
{
	public class Pixel
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="r">Red value of the pixel.</param>
		/// <param name="g">Green value of the pixel.</param>
		/// <param name="b">Blue value of the pixel.</param>
		/// <param name="a">Alpha value of the pixel.</param>
		public Pixel(short r,
		             short g,
		             short b,
		             short a)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

		/// <summary>
		///    Get alpha value of the pixel.
		/// </summary>
		public short A {get;}

		/// <summary>
		///    Get blue value of the pixel.
		/// </summary>
		public short B {get;}

		/// <summary>
		///    Get the color of the pixel.
		/// </summary>
		public IEnumerable<byte> Color => R.ToBytes().Append(G.ToBytes()[0]).Append(B.ToBytes()[0]).Append(A.ToBytes()[0]);

		/// <summary>
		///    Get green value of the pixel.
		/// </summary>
		public short G {get;}

		/// <summary>
		///    Get red value of the pixel.
		/// </summary>
		public short R {get;}

		/// <summary>
		///    Overlaying current pixel with another pixel.
		/// </summary>
		/// <param name="pixel"></param>
		/// <returns></returns>
		public IEnumerable<byte> Overlay(Pixel pixel)
		{
			return ((Color.ToInt32() * A + pixel.Color.ToInt32() * pixel.A * (1 - A)) / (A + pixel.A * (1 - A))).ToBytes();
		}
	}
}