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

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Diten.Globalization
{
	public class WeekdayCollection: ICollection<Weekday>
	{
		public WeekdayCollection() { HolderList = new Collections.Generic.List<Weekday>(); }

		private List<Weekday> HolderList {get;}

		public void Add(Weekday item) { HolderList.Add(item); }

		public void Clear() { HolderList.Clear(); }

		public Boolean Contains(Weekday item) { return HolderList.Contains(item); }

		public void CopyTo(Weekday[] array,
		                   int arrayIndex)
		{
			HolderList.CopyTo(array,
			                  arrayIndex);
		}

		public Int32 Count => HolderList.Count;

		public IEnumerator<Weekday> GetEnumerator() { return HolderList.GetEnumerator(); }

		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

		public Boolean IsReadOnly => false;

		public Boolean Remove(Weekday item) { return HolderList.Remove(item); }
	}
}