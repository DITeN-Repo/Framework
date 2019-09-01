#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:35 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten
{
	public static class TypeSwitch
	{
		public static void Do(object source, params CaseInfo[] cases)
		{
			var type = source.GetType();

			foreach(var entry in cases)
				if(entry.IsDefault||type==entry.Target)
				{
					entry.Action(source);

					break;
				}
		}

		public static CaseInfo Case<T>(Action action)
		{
			return new CaseInfo
			{
				Action=x => action(),

				Target=typeof(T)
			};
		}

		public static CaseInfo Case<T>(Action<T> action)
		{
			return new CaseInfo
			{
				Action=x => action((T)x),

				Target=typeof(T)
			};
		}

		public static CaseInfo Default(Action action)
		{
			return new CaseInfo
			{
				Action=x => action(),

				IsDefault=true
			};
		}

		public class CaseInfo
		{
			public bool IsDefault { get; set; }

			public Type Target { get; set; }

			public Action<object> Action { get; set; }
		}
	}
}