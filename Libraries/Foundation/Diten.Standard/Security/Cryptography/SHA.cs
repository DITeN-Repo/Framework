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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    Types of SHA hash.
	/// </summary>
	public enum SHATypes
	{
		SHA1,
		SHA256,
		SHA384,
		SHA512
	}

	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	[DefaultProperty("Value")]
	public class SHA<TSHA> where TSHA: HashAlgorithm
	{
		/// <inheritdoc cref="SHA{TSHA}()" />
		/// <param name="value">The data in <see cref="object" /> that must be hashed.</param>
		public SHA(System.Object value): this(value.ToBytes()) {}

		/// <summary>
		///    Constructor of <see cref="SHA{TSHA}" /> hashing engine.
		/// </summary>
		/// <param name="value">The data in <see cref="object" /> that must be hashed.</param>
		public SHA(IEnumerable value) { Value = value; }

		/// <summary>
		///    Constructor of <see cref="SHA{TSHA}" /> hashing engine.
		/// </summary>
		protected SHA() {}

		/// <summary>
		///    The <see cref="object " /> value that will be hashed.
		/// </summary>
		private object Value {get;}

		/// <inheritdoc cref="SHA1.ComputeHash(byte[])" />
		public static byte[] ComputeHash(byte[] buffer)
		{
			var methodInfo = Create()?.GetType().GetMethod(Enum.GetName(Enum.MethodNames.ComputeHash));

			//convert the input text to array of bytes
			return (byte[]) methodInfo?.Invoke(methodInfo,
			                                   new object[] {buffer});
		}

		/// <summary>
		///    Get <see cref="TSHA" /> hashed data.
		/// </summary>
		/// <returns>A <see cref="TSHA" /> hashed data.</returns>
		public byte[] ComputeHash() { return ComputeHash(Value.ToBytes()); }

		/// <inheritdoc cref="SHA1Managed.Create()" />
		public static TSHA Create()
		{
			return (TSHA) typeof(TSHA).GetMethod(Enum.GetName(Enum.MethodNames.Create),
			                                     Type.EmptyTypes)
			                          ?.Invoke(Activator.CreateInstance(typeof(TSHA)),
			                                   BindingFlags.Default,
			                                   null,
			                                   null,
			                                   CultureInfo.CurrentCulture);
		}

		/// <inheritdoc cref="Encrypt(byte[])" />
		/// <param name="value">The data in <see cref="string" /> that must be hashed.</param>
		public static byte[] Encrypt(System.String value) { return Encrypt(new Byte(value.ToBytes())); }

		/// <inheritdoc cref="Encrypt(byte[])" />
		/// <param name="value">The data in <see cref="object" /> that must be hashed.</param>
		public static byte[] Encrypt(System.Object value) { return Encrypt(new Byte(value.ToBytes())); }

		/// <inheritdoc cref="Encrypt(byte[])" />
		/// <param name="value">The data in <see cref="Byte" /> that must be hashed.</param>
		public static byte[] Encrypt(Byte value) { return Encrypt(value.Value); }

		/// <inheritdoc cref="ComputeHash(byte[])" />
		/// <param name="value">The data in <see cref="byte" /> that must be hashed.</param>
		public static byte[] Encrypt(byte[] value) { return new SHA<TSHA>(value).ComputeHash(); }
	}
}