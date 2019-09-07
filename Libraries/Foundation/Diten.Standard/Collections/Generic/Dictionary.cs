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
	/// <inheritdoc />
	[Attributes.Generic]
	public class Dictionary<T1, T2> : System.Collections.Generic.Dictionary<T1, T2>
	{
		public T2 this[Func<T1, bool> selector]
		{
			get
			{
				var _return = default(T2);

				this.Where(o =>
				{
					o.Value.GetType().GetMethod(Enum.GetName(Enum.MethodNames.Load))
						?.Invoke(o, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);

					_return = o.Value;

					return selector(o.Key);
				}).GetEnumerator().MoveNext();

				return _return;
			}
		}

		public Dictionary<T1, T2> Cast(System.Collections.Generic.Dictionary<T1, T2> dictionary)
		{
			foreach (var value in dictionary)
				Add(value.Key, value.Value);

			return this;
		}

		public virtual Dictionary<T1, T2> Load()
		{
			Clear();

			foreach (var item in this)
			{
				var tmp1 = ExecuteMethod(item, Enum.MethodNames.Load);

				Add(tmp1.Key, tmp1.Value);
			}

			return this;
		}

		public virtual void Save()
		{
			foreach (var item in this)
				ExecuteMethod(item, Enum.MethodNames.Save);
		}

		private static KeyValuePair<T1, T2> ExecuteMethod(KeyValuePair<T1, T2> item, Enum.MethodNames method)
		{
			item.Key.GetType().GetMethod(Enum.GetName(method), Type.EmptyTypes)
				?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);
			item.Value.GetType().GetMethod(Enum.GetName(method), Type.EmptyTypes)
				?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture);

			return item;
		}
	}
}