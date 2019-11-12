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
// Creation Date: 2019/09/09 5:16 PM

#region Used Directives

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    <see cref="SHA256" /> encryption.
	/// </summary>
	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	public abstract class SHA256: SHA<SHA256Managed>,
	                              ISHA
	{
		/// <inheritdoc cref="SHA{TSHA}()" />
		protected SHA256() {}

		/// <inheritdoc cref="SHA{TSHA}(object)" />
		protected SHA256(IEnumerable<System.Byte> value): base(value) {}
	}
}