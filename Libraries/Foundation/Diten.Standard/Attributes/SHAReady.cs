#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:32 PM

#endregion

#region Used Directives

using Diten.Security.Cryptography;
using System;

#endregion

// ReSharper disable All

namespace Diten.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class SHAReady:Attribute
	{
		public SHATypes SHAType { get; set; } = SHATypes.SHA1;
	}
}