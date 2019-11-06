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
// Creation Date: 2019/09/13 3:58 AM

#region Used Directives

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Diten.Security.Cryptography;
using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace Diten.Security
{
	/// <summary>
	///    Standard signature <see cref="Signature{TKey}" /> with <see cref="SHA256" /> signature.
	/// </summary>
	[DataContract]
	[BsonIgnoreExtraElements]
	public class Signature: Signature<SHA256> {}

	/// <summary>
	///    Local use signature <see cref="Signature{TKey}" /> with <see cref="SHA1" /> signature.
	/// </summary>
	[DataContract]
	[BsonIgnoreExtraElements]
	public class LocalSignature: Signature<SHA1> {}

	/// <summary>
	///    Web use signature <see cref="Signature{TKey}" /> with <see cref="SHA256" /> signature.
	/// </summary>
	[DataContract]
	[BsonIgnoreExtraElements]
	public class WebSignature: Signature<SHA256> {}

	/// <summary>
	///    Deep web use signature <see cref="Signature{TKey}" /> with <see cref="SHA384" /> signature.
	/// </summary>
	[DataContract]
	[BsonIgnoreExtraElements]
	public class DeepSignature: Signature<SHA384> {}

	/// <summary>
	///    Dark web use signature <see cref="Signature{TKey}" /> with <see cref="SHA512" /> signature.
	/// </summary>
	[DataContract]
	[BsonIgnoreExtraElements]
	public class DarkSignature: Signature<SHA512> {}

	/// <summary>
	///    Represent a <see cref="Signature{TKey}" />.
	/// </summary>
	/// <typeparam name="TKey">An <see cref="ISHA" /> that will be used for <see cref="Signature{TKey}" />.</typeparam>
	[DefaultProperty("Value")]
	public class Signature<TKey>
		where TKey: ISHA
	{
		/// <inheritdoc />
		public Signature(): this(null) {}

		/// <inheritdoc />
		public Signature(object value = null): this(value.ToBytes()) {}

		/// <inheritdoc />
		public Signature(IEnumerable<byte> value = null)
		{
			using (var shaKey = new SHAKey<TKey>(Value.Value.Append(value))) { Value = shaKey.Value.ToByte(); }
		}

		/// <summary>
		///    Get value of the <see cref="Signature{TKey}" /> in <see cref="Byte" />.
		/// </summary>
		public Byte Value {get;}

		/// <summary>
		///    Get <see cref="Numeric.Hexadecimal" /> of the <see cref="Value" />.
		/// </summary>
		/// <returns></returns>
		public override string ToString() { return Value.Value.ToHex(); }
	}
}