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
// Creation Date: 2019/09/09 5:17 PM

#region Used Directives

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    <see cref="SHA512" /> encryption.
	/// </summary>
	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	public abstract class SHA512: SHA<SHA512Managed>,
	                              ISHA
	{
		/// <inheritdoc cref="SHA{TSHA}()" />
		protected SHA512() {}

		/// <inheritdoc cref="SHA{TSHA}(object)" />
		protected SHA512(IEnumerable<System.Byte> value): base(value) {}
	}
}