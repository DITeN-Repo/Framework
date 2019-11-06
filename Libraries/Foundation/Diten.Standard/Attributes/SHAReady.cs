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
// Creation Date: 2019/08/15 8:32 PM

#region Used Directives

using System;
using Diten.Security.Cryptography;

#endregion

// ReSharper disable All

namespace Diten.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class SHAReady: Attribute
	{
		public SHATypes SHAType {get; set;} = SHATypes.SHA1;
	}
}