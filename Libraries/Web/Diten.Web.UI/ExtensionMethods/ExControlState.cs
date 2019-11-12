#region Using Directives

using Ext.Net.Utilities;

#endregion

namespace Diten.Web.UI
{
	public static class ExControlState
	{
		/// <summary>
		/// </summary>
		/// <typeparam name="Layouts"></typeparam>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T Get<T>(this string name, T defaultValue)
		{
			return (T) name.IfNull<object>(((object) defaultValue).ToString());
		}
	}
}