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
// Creation Date: 2019/08/18 7:40 PM

#region Used Directives

using System;

#endregion

namespace Diten.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Class |
	                AttributeTargets.Struct |
	                AttributeTargets.Constructor |
	                AttributeTargets.Method |
	                AttributeTargets.Field,
		Inherited = false)]
	internal sealed class IntrinsicAttribute: Attribute {}
}