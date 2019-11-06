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
// Creation Date: 2019/08/16 12:16 AM

#region Used Directives

using System.Collections.Generic;

#endregion

namespace Diten.Globalization
{
	public class Week
	{
		public sealed class WeekdaysCollection: List<Weekday>
		{
			//public 
		}

		public Week() { Weekdays = new WeekdaysCollection(); }

		public WeekdaysCollection Weekdays {get;}
	}
}