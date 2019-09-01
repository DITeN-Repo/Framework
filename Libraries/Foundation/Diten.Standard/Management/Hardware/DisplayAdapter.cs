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
	public class DisplayAdapter:Hardware<DisplayAdapter>
	{
		public double ClockSpeed { get; set; }
		public string ID { get; set; }
		public string Info { get; set; }
		public string Model { get; set; }
	}
}