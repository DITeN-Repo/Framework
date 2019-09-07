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
// Creation Date: 2019/08/18 7:29 PM

#endregion

#region Used Directives

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Diten.CodeAnalysis;

#endregion

namespace Diten.Runtime.CompilerServices
{
	[Embedded]
	[CompilerGenerated]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute([In] byte obj0)
		{
			// ISSUE: reference to a compiler-generated field
			NullableFlags = new byte[1] {obj0};
		}

		public NullableAttribute([In] byte[] obj0) => NullableFlags = obj0;
	}
}