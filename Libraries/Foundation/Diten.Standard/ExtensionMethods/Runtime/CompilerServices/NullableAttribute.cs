#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/18 7:29 PM

#endregion

#region Used Directives

using Diten.CodeAnalysis;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#endregion

namespace Diten.Runtime.CompilerServices
{
	[Embedded]
	[CompilerGenerated]
	internal sealed class NullableAttribute:Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute([In] byte obj0)
		{
			// ISSUE: reference to a compiler-generated field
			NullableFlags=new byte[1] { obj0 };
		}

		public NullableAttribute([In] byte[] obj0)
		{
			// ISSUE: reference to a compiler-generated field
			NullableFlags=obj0;
		}
	}
}