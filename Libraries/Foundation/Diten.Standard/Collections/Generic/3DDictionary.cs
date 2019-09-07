#region DITeN Registration Info

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
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

#endregion

namespace Diten.Collections.Generic
{
	[Attributes.Generic]
	public class Dictionary<T1, T2, T3> : Dictionary<T1, KeyValuePair<T2, T3>>
	{
		public T3 this[T1 key1, T2 key2]
		{
			get => base[key1].Value;
			set
			{
				Remove(key1, key2);
				Add(key1, key2, value);
			}
		}

		public void Add(T1 key1, T2 key2, T3 value)
		{
			if (ContainsKey(key1, key2))
				throw new ArgumentException(
					$@"Keys [{nameof(key1)}: {key1}, {nameof(key2)}: {key2}] already is exist.");

			Add(key1, new KeyValuePair<T2, T3>(key2, value));
		}

		public bool ContainsKey(T1 key1, T2 key2)
		{
			return this.Any(i => i.Key.Equals(key1) && i.Value.Key.Equals(key2));
		}

		public bool ContainsValue(T3 value)
		{
			return this.Any(i => i.Value.Value.Equals(value));
		}

		public void Remove(T1 key1, T2 key2)
		{
			foreach (var item in this.Where(k => k.Key.Equals(key1) && k.Value.Key.Equals(key2)))
				Remove(item.Key);
		}

		public override Dictionary<T1, KeyValuePair<T2, T3>> Load()
		{
			Clear();

			foreach (var item in this)
			{
				var tmp1 = ExecuteMethod(item, Enum.MethodNames.Load);

				Add(tmp1.Key, tmp1.Value);
			}

			return this;
		}

		public override void Save()
		{
			foreach (var item in this)
				ExecuteMethod(item, Enum.MethodNames.Save);
		}

		private static KeyValuePair<T1, KeyValuePair<T2, T3>> ExecuteMethod(KeyValuePair<T1, KeyValuePair<T2, T3>> item,
			Enum.MethodNames method)
		{
			item.Key.GetType().GetMethod(Enum.GetName(method), Type.EmptyTypes)
				?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);
			item.Value.Key.GetType().GetMethod(Enum.GetName(method), Type.EmptyTypes)
				?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);
			item.Value.Value.GetType().GetMethod(Enum.GetName(method), Type.EmptyTypes)
				?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);

			return item;
		}
	}
}