#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:20 AM

#endregion

#region Used Directives

using Diten.Collections.Generic;
using Diten.Management.Hardware;

#endregion

namespace Diten.Net.Cloud
{
	public abstract class RelatedHost:Object<RelatedHost>
	{
		public Computer Publisher { get; set; }
		public List<Computer> Subscriptors { get; set; }
	}
}