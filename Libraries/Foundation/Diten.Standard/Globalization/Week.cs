#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#endregion

#region Used Directives

using System.Collections.Generic;

#endregion

namespace Diten.Globalization
{
	public class Week
	{
		public Week()
		{
			Weekdays=new WeekdaysCollection();
		}

		public WeekdaysCollection Weekdays { get; }

		public sealed class WeekdaysCollection:List<Weekday>
		{
			//public 
		}
	}
}