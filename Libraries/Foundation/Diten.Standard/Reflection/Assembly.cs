#region DITeN Registration Info

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
// Creation Date: 2019/09/02 12:40 AM

#endregion

#region Used Directives

using System.Diagnostics;
using System.Runtime.CompilerServices;

#endregion

namespace Diten.Reflection
{
	public class Assembly
	{
		/// <summary>
		///    Get current executed method name in <inheritdoc cref="string" />.
		/// </summary>
		/// <returns>An <inheritdoc cref="string" /> that contains name of currently executed method.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentMethodName() => new StackTrace().GetFrame(1).GetMethod().Name;

		/// <summary>
		///    Get current executed property name in <inheritdoc cref="string" />.
		/// </summary>
		/// <returns>An <inheritdoc cref="string" /> that contains name of currently executed property.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentPropertyName() => new StackTrace().GetFrame(2).GetMethod().Name;
	}
}