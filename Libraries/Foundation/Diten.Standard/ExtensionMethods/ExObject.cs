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
// Creation Date: 2019/08/15 4:42 PM

#region Used Directives

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Diten.Diagnostics;

// ReSharper disable UnusedParameter.Global

#endregion

namespace Diten
{
	public static class ExObject
	{
		/// <summary>
		///    Get current frame return name.
		/// </summary>
		/// <param name="value">Current frame container object.</param>
		/// <returns>Name of current frame.</returns>
		public static System.String GetFrameName(this object value)
		{
			var _return = new StackTrace().GetFrame(2).GetMethod().Name;

			if (_return.StartsWith("get_",
			                       StringComparison.Ordinal)) return _return.TrimStart("get_".ToCharArray());

			return _return.StartsWith("set_",
			                          StringComparison.Ordinal)
				       ? _return.TrimStart("set_".ToCharArray())
				       : _return;
		}

		/// <summary>
		///    Get current frame return type.
		/// </summary>
		/// <param name="value">Current frame container object.</param>
		/// <returns>Type of current frame.</returns>
		public static Type GetFrameType(this object value) { return new StackTrace().GetFrame(1).GetMethod().DeclaringType; }

		/// <summary>
		///    Converting object into byte array.
		/// </summary>
		/// <param name="value">Data for conversion.</param>
		/// <returns>A byte array.</returns>
		public static byte[] ToBytes(this object value)
		{
			var binaryFormatter = new BinaryFormatter();
			using (var memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream,
				                          ToMemoryStream(value));

				return memoryStream.ToArray();
			}
		}

		/// <summary>
		///    Converting <see cref="UnmanagedMemoryStream" /> into <see cref="MemoryStream" />.
		/// </summary>
		/// <param name="value">An <see cref="UnmanagedMemoryStream" />.</param>
		/// <returns>A <see cref="MemoryStream" />.</returns>
		public static MemoryStream ToMemoryStream(System.Object value) { return ((UnmanagedMemoryStream) value).ToMemoryStream(); }

		/// <summary>
		///    Converting object to array of object bytes then convert it to string.
		/// </summary>
		/// <param name="value">Object that must be converted.</param>
		/// <returns>A string that represent string converted bytes of the current object.</returns>
		public static System.String ToString(this object value) { return value.ToBytes().ToString(); }

		/// <summary>
		///    Try to casting an object into type <see cref="T" />.
		/// </summary>
		/// <typeparam name="T">Type <see cref="T" /> to return from casting.</typeparam>
		/// <param name="value">Object that must be caste to the specify type.</param>
		/// <returns>Type <see cref="T" /> specified for returning from cast.</returns>
		public static T TryCast<T>(this object value)
		{
			try { return (T) value; }
			catch { return default; }
		}
	}
}