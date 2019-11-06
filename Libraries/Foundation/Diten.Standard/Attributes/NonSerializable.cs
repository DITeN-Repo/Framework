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
// Creation Date: 2019/09/13 1:53 AM

#region Used Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Diten.Attributes
{
	[AttributeUsage(AttributeTargets.All,
		Inherited = false)]
	[ComVisible(true)]
	public class NonSerializable: Attribute {}
}