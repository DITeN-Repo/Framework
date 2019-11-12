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

using System;
using Diten.Collections.Generic;
using System.Dynamic;

#endregion

namespace Diten.Dynamic
{
	public class DynamicDictionary: DynamicObject
	{
		public Int32 Count => Dictionary.Count;
		public Dictionary<System.String, object> Dictionary => _dictionary ?? (_dictionary = new Dictionary<System.String, object>());
		private Dictionary<System.String, object> _dictionary;

		public override bool TryGetMember(GetMemberBinder binder,
		                                  out object result)
		{
			return Dictionary.TryGetValue(binder.Name,
			                              out result);
		}

		public override bool TrySetMember(SetMemberBinder binder,
		                                  object value)
		{
			Dictionary[binder.Name] = value;

			return true;
		}
	}
}