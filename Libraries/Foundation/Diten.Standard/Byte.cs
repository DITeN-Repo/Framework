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

#region Used Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diten.Parameters;

// ReSharper disable UnusedMethodReturnValue.Global

#endregion

namespace Diten
{
	/// <summary>
	///    Byte type in diten framework.
	/// </summary>
	public class Byte
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		public Byte() { Value = new byte[0]; }

		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="data">System byte array data for creating diten byte.</param>
		public Byte(byte[] data) { Value = data; }

		/// <summary>
		///    Value of diten framework byte type.
		/// </summary>
		public byte[] Value {get; private set;}

		public void Append(IEnumerable<byte> bytes)
		{
			var holder = Value.ToList();
			holder.AddRange(bytes);
			Value = holder.ToArray();
		}

		/// <summary>
		///    Appending some string at end of byte array.
		/// </summary>
		/// <param name="value"></param>
		public void Append(string value) { Append(Encoding.UTF8.GetBytes(value.ToCharArray())); }

		/// <summary>
		///    Clear value property of byte type.
		/// </summary>
		public void Clear() { Value = new byte[0]; }

		/// <summary>
		///    Detect that byte array in value property has EOF tag or not.
		/// </summary>
		/// <returns>True if byte array has EOF tag.</returns>
		public bool HasEOF() { return HasTag(Char.ReservedChars.FileSeparator.ToString()); }

		/// <summary>
		///    Detect that byte array in value property has tag or not.
		/// </summary>
		/// <param name="tag"></param>
		/// <returns>True if byte array has tag.</returns>
		public bool HasTag(string tag)
		{
			return Encoding.ASCII.GetString(Value)
			               .IndexOf(tag,
			                        StringComparison.Ordinal) <=
			       -1;
		}

		/// <summary>
		///    Removing EOF tag from end of byte array in value property.
		/// </summary>
		/// <returns>A Diten.Byte that represent a byte type without EOF tag.</returns>
		public Byte RemoveEOF()
		{
			var eofIndex = Encoding.ASCII.GetString(Value)
			                       .IndexOf((char) Char.ReservedChars.EndOfMedium);

			if (eofIndex <= -1)
				throw new ArgumentOutOfRangeException(nameof(Value),
				                                      Value,
				                                      Exceptions.Default.DIten_NoEOFTagInValue);

			var value = Value.ToList();
			value.RemoveRange(eofIndex,
			                  value.Count - eofIndex);
			Value = value.ToArray();

			return this;
		}
	}
}