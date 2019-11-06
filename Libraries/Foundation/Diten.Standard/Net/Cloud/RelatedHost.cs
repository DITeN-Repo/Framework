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
// Creation Date: 2019/08/16 12:20 AM

#region Used Directives

using Diten.Collections.Generic;
using Diten.Management.Hardware;

#endregion

namespace Diten.Net.Cloud
{
	public abstract class RelatedHost: Object<RelatedHost>
	{
		public Computer Publisher {get; set;}
		public List<Computer> Subscriptors {get; set;}
	}
}