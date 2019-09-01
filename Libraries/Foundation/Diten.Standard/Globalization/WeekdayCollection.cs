#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#endregion

#region Used Directives

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Diten.Globalization
{
	public class WeekdayCollection:ICollection<Weekday>
	{
		public WeekdayCollection()
		{
			HolderList=new Collections.Generic.List<Weekday>();
		}

		private List<Weekday> HolderList { get; }

		public IEnumerator<Weekday> GetEnumerator()
		{
			return HolderList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Weekday item)
		{
			HolderList.Add(item);
		}

		public void Clear()
		{
			HolderList.Clear();
		}

		public bool Contains(Weekday item)
		{
			return HolderList.Contains(item);
		}

		public void CopyTo(Weekday[] array, int arrayIndex)
		{
			HolderList.CopyTo(array, arrayIndex);
		}

		public bool Remove(Weekday item)
		{
			return HolderList.Remove(item);
		}

		public int Count => HolderList.Count;

		public bool IsReadOnly => false;
	}
}