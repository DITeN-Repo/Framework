#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:32 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Attributes
{
	[AttributeUsage(AttributeTargets.Method|AttributeTargets.Parameter, Inherited = false)]
	public class MustUrlHex:Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Method|AttributeTargets.Parameter, Inherited = false)]
	public class MustHex:Attribute
	{
	}
}