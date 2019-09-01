#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/18 7:40 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.Constructor|
						 AttributeTargets.Method|AttributeTargets.Field, Inherited = false)]
	internal sealed class IntrinsicAttribute:Attribute
	{
	}
}