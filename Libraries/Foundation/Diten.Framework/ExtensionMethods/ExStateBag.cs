#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#endregion

#region Used Directives

using System;
using System.Reflection;
using System.Web.UI;

#endregion

namespace Diten
{
	public static class ExStateBag
	{
		#region Setting State Bag

		/// <summary>
		///    Setting value of the entity in the state bag (ViewSate) by type <see cref="System.Object" />.
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="value">Value thea must be set into the state bag.</param>
		public static void SetValue(this StateBag viewStateBag, string key, object value)
		{
			SetValue<object>(viewStateBag, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the state bag (ViewSate) by type <see cref="T" />.
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="value">Value thea must be set into the state bag.</param>
		public static void SetValue<T>(this StateBag viewStateBag, string key, object value)
		{
			SetValue<T>(viewStateBag, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the state bag (ViewSate) by type <see cref="T" />.
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="func">Function that must be executed during setting state bag item.</param>
		public static void SetValue<T>(this StateBag viewStateBag, string key, Func<object, object> func)
		{
			try
			{
				viewStateBag[key] = (T) func.Invoke(func.GetMethodInfo().GetParameters());
			}
			catch
			{
				viewStateBag[key] = func.Invoke(func.GetMethodInfo().GetParameters());
			}
		}

		#endregion

		#region Getting State Bag

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in state bag.</returns>
		public static object GetValue(this StateBag viewStateBag, string key)
		{
			return GetValue<object>(viewStateBag, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="value">Value of the item in state bag.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in state bag.</returns>
		public static object GetValue(this StateBag viewStateBag, string key, object value)
		{
			return GetValue<object>(viewStateBag, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="func">Function that must be executed during getting state bag item.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in state bag.</returns>
		public static object GetValue(this StateBag viewStateBag, string key, Func<object, object> func)
		{
			return GetValue<object>(viewStateBag, key, func);
		}

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in state bag.</returns>
		public static T GetValue<T>(this StateBag viewStateBag, string key)
		{
			return GetValue<T>(viewStateBag, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="value">Value of the item in state bag.</param>
		/// <returns><see cref="T" /> type value of the entity in state bag.</returns>
		public static T GetValue<T>(this StateBag viewStateBag, string key, object value)
		{
			return GetValue<T>(viewStateBag, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the state bag (ViewSate).
		/// </summary>
		/// <param name="viewStateBag">State bag of the current entity.</param>
		/// <param name="key">The key of the item in state bag.</param>
		/// <param name="func">Function that must be executed during getting state bag item.</param>
		/// <returns><see cref="T" /> type value of the entity in state bag.</returns>
		public static T GetValue<T>(this StateBag viewStateBag, string key, Func<object, object> func)
		{
			return (T) (viewStateBag[key] ?? (viewStateBag[key] = func.Invoke(func.GetMethodInfo().GetParameters())));
		}

		#endregion
	}
}