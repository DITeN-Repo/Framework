#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Diagnostics;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// ReSharper disable UnusedParameter.Global

#endregion

namespace Diten
{
	public static class ExObject
	{
		/// <summary>
		///    Converting object to array of object bytes then convert it to string.
		/// </summary>
		/// <param name="value">Object that must be converted.</param>
		/// <returns>A string that represent string converted bytes of the current object.</returns>
		public static string ToString(this object value)
		{
			return value.ToBytes().ToString();
		}

		/// <summary>
		///    Converting <see cref="UnmanagedMemoryStream" /> into <see cref="MemoryStream" />.
		/// </summary>
		/// <param name="value">An <see cref="UnmanagedMemoryStream" />.</param>
		/// <returns>A <see cref="MemoryStream" />.</returns>
		public static MemoryStream ToMemoryStream(object value)
		{
			return ((UnmanagedMemoryStream)value).ToMemoryStream();
		}

		/// <summary>
		///    Converting object into byte array.
		/// </summary>
		/// <param name="value">Data for conversion.</param>
		/// <returns>A byte array.</returns>
		public static byte[] ToBytes(this object value)
		{
			var binaryFormatter = new BinaryFormatter();
			using(var memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, ToMemoryStream(value));
				return memoryStream.ToArray();
			}
		}

		/// <summary>
		///    Try to casting an object into type <see cref="T" />.
		/// </summary>
		/// <typeparam name="T">Type <see cref="T" /> to return from casting.</typeparam>
		/// <param name="value">Object that must be caste to the specify type.</param>
		/// <returns>Type <see cref="T" /> specified for returning from cast.</returns>
		public static T TryCast<T>(this object value)
		{
			try
			{
				return (T)value;
			}
			catch
			{
				return default;
			}
		}

		/// <summary>
		///    Get current frame return type.
		/// </summary>
		/// <param name="value">Current frame container object.</param>
		/// <returns>Type of current frame.</returns>
		public static Type GetFrameType(this object value)
		{
			return new StackTrace().GetFrame(1).GetMethod().DeclaringType;
		}

		/// <summary>
		///    Get current frame return name.
		/// </summary>
		/// <param name="value">Current frame container object.</param>
		/// <returns>Name of current frame.</returns>
		public static string GetFrameName(this object value)
		{
			var _return = new StackTrace().GetFrame(2).GetMethod().Name;

			if(_return.StartsWith("get_"))
				return _return.TrimStart("get_".ToCharArray());

			return _return.StartsWith("set_") ? _return.TrimStart("set_".ToCharArray()) : _return;
		}
	}
}