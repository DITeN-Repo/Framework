#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:14 AM

#endregion

#region Used Directives

using System;
using System.Reflection;
using System.Web.SessionState;

#endregion

namespace Diten
{
	public static class ExHttpSessionState
	{
		#region Setting session state

		/// <summary>
		///    Setting value of the entity in the session state (sessionState) by type <see cref="System.Object" />.
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="value">Value thea must be set into the session state.</param>
		public static void SetValue(this HttpSessionState httpSessionState, string key, object value)
		{
			SetValue<object>(httpSessionState, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the session state (sessionState) by type <see cref="T" />.
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="value">Value thea must be set into the session state.</param>
		public static void SetValue<T>(this HttpSessionState httpSessionState, string key, object value)
		{
			SetValue<T>(httpSessionState, key, _return => value);
		}

		/// <summary>
		///    Setting value of the entity in the session state (sessionState) by type <see cref="T" />.
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="func">Function that must be executed during setting session state item.</param>
		public static void SetValue<T>(this HttpSessionState httpSessionState, string key, Func<object, object> func)
		{
			try
			{
				httpSessionState[key] = (T) func.Invoke(func.GetMethodInfo().GetParameters());
			}
			catch
			{
				httpSessionState[key] = func.Invoke(func.GetMethodInfo().GetParameters());
			}
		}

		#endregion

		#region Getting session state

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in session state.</returns>
		public static object GetValue(this HttpSessionState httpSessionState, string key)
		{
			return GetValue<object>(httpSessionState, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="value">Value of the item in session state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in session state.</returns>
		public static object GetValue(this HttpSessionState httpSessionState, string key, object value)
		{
			return GetValue<object>(httpSessionState, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="func">Function that must be executed during getting session state item.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in session state.</returns>
		public static object GetValue(this HttpSessionState httpSessionState, string key, Func<object, object> func)
		{
			return GetValue<object>(httpSessionState, key, func);
		}

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <returns><see cref="System.Object" /> type value of the entity in session state.</returns>
		public static T GetValue<T>(this HttpSessionState httpSessionState, string key)
		{
			return GetValue<T>(httpSessionState, key, _return => null);
		}

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="value">Value of the item in session state.</param>
		/// <returns><see cref="T" /> type value of the entity in session state.</returns>
		public static T GetValue<T>(this HttpSessionState httpSessionState, string key, object value)
		{
			return GetValue<T>(httpSessionState, key, _return => value);
		}

		/// <summary>
		///    Getting value of the current entity in the session state (sessionState).
		/// </summary>
		/// <param name="httpSessionState">session state of the current entity.</param>
		/// <param name="key">The key of the item in session state.</param>
		/// <param name="func">Function that must be executed during getting session state item.</param>
		/// <returns><see cref="T" /> type value of the entity in session state.</returns>
		public static T GetValue<T>(this HttpSessionState httpSessionState, string key, Func<object, object> func)
		{
			return (T) (httpSessionState[key] ??
			            (httpSessionState[key] = func.Invoke(func.GetMethodInfo().GetParameters())));
		}

		#endregion
	}
}