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
// Creation Date: 2019/08/15 8:37 PM

#region Used Directives

using Diten.Collections.Generic;

#endregion

namespace Diten.Management.Hardware
{
	public class DisplayAdapter: Hardware<DisplayAdapter>
	{
		public double ClockSpeed {get; set;}
		public System.String HardwareID {get; set;}
		public System.String Info {get; set;}
		public System.String Model {get; set;}
	}
}