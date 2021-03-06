﻿// Copyright alright reserved by DITeN™ ©® 2003 - 2019
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
// Creation Date: 2019/08/15 8:37 PM

#region Used Directives

using System.Diagnostics.CodeAnalysis;
using Diten.Collections.Generic;

#endregion

namespace Diten.Management
{
	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	public class OperatingSystem: Hardware<OperatingSystem>
	{
		/// <summary>
		///    Operating system version.
		/// </summary>
		public System.String Caption {get; set;}

		/// <summary>
		///    Operating system version.
		/// </summary>
		public System.String OSVersion => Caption;
	}
}