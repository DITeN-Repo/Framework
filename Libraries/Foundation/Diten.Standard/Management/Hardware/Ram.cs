#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using Diten.Collections.Generic;

#endregion

namespace Diten.Management.Hardware
{
	public class Ram:Hardware<Ram>
	{
		public int ClockSpeed { get; set; }
		public string Type { get; set; }
	}
}