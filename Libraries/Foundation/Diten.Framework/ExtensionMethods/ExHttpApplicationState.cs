#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:13 AM

#endregion

#region Used Directives

using System;
using System.Reflection;
using System.Web;

#endregion

namespace Diten
{
	public static class ExHttpApplicationState
	{
		#region Setting Application state

		/// <summary>
		///    Setting value of the entity in the Application state (ApplicationState) by type <see cref="System.Object" />.
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="value">Value thea must be set into the Application state.</param>
		public static void SetValue(this HttpApplicationState httpApplicationState, string key, object value)
		{
			SetValue<object>(httpApplicationState, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the Application state (ApplicationState) by type <see cref="T" />.
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="value">Value thea must be set into the Application state.</param>
		public static void SetValue<T>(this HttpApplicationState httpApplicationState, string key, object value)
		{
			SetValue<T>(httpApplicationState, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the Application state (ApplicationState) by type <see cref="T" />.
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="func">Function that must be executed during setting Application state item.</param>
		public static void SetValue<T>(this HttpApplicationState httpApplicationState, string key,
			Func<object, object> func)
		{
			try
			{
				httpApplicationState[key] = (T) func.Invoke(func.GetMethodInfo().GetParameters());
			}
			catch
			{
				httpApplicationState[key] = func.Invoke(func.GetMethodInfo().GetParameters());
			}
		}

		#endregion

		#region Getting Application state

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in Application state.</returns>
		public static object GetValue(this HttpApplicationState httpApplicationState, string key)
		{
			return GetValue<object>(httpApplicationState, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="value">Value of the item in Application state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in Application state.</returns>
		public static object GetValue(this HttpApplicationState httpApplicationState, string key, object value)
		{
			return GetValue<object>(httpApplicationState, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="func">Function that must be executed during getting Application state item.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in Application state.</returns>
		public static object GetValue(this HttpApplicationState httpApplicationState, string key,
			Func<object, object> func)
		{
			return GetValue<object>(httpApplicationState, key, func);
		}

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in Application state.</returns>
		public static T GetValue<T>(this HttpApplicationState httpApplicationState, string key)
		{
			return GetValue<T>(httpApplicationState, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="value">Value of the item in Application state.</param>
		/// <returns><see cref="T" /> type value of the entity in Application state.</returns>
		public static T GetValue<T>(this HttpApplicationState httpApplicationState, string key, object value)
		{
			return GetValue<T>(httpApplicationState, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the Application state (ApplicationState).
		/// </summary>
		/// <param name="httpApplicationState">Application state of the current entity.</param>
		/// <param name="key">The key of the item in Application state.</param>
		/// <param name="func">Function that must be executed during getting Application state item.</param>
		/// <returns><see cref="T" /> type value of the entity in Application state.</returns>
		public static T GetValue<T>(this HttpApplicationState httpApplicationState, string key, Func<object, object> func)
		{
			return (T) (httpApplicationState[key] ??
			            (httpApplicationState[key] = func.Invoke(func.GetMethodInfo().GetParameters())));
		}

		#endregion
	}
}