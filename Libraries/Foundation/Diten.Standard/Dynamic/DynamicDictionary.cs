#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System.Collections.Generic;
using System.Dynamic;

#endregion

namespace Diten.Dynamic
{
	public class DynamicDictionary:DynamicObject
	{
		private Dictionary<string, object> _dictionary;
		public int Count => Dictionary.Count;
		public Dictionary<string, object> Dictionary => _dictionary??(_dictionary=new Dictionary<string, object>());

		public override bool TryGetMember(GetMemberBinder binder,
			out object result)
		{
			return Dictionary.TryGetValue(binder.Name, out result);
		}

		public override bool TrySetMember(SetMemberBinder binder,
			object value)
		{
			Dictionary[binder.Name]=value;

			return true;
		}
	}
}