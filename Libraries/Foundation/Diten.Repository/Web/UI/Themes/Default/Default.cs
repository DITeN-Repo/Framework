#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/07/30 4:36 PM

#endregion

namespace Diten.Web.UI.Themes.Default
{
	//todo: A brain storm for getting namespace.
	internal class Default : Theme
	{
		/// <summary>
		///    Get namespace of <inheritdoc cref="Default" />.
		/// </summary>
		/// <returns></returns>
		public new static string GetNameSpace()
		{
			//var names = GetType().Split(".".ToCharArray()).Where(n=>n.Equals(Assembly.GetCurrentMethodName()));
			return @"Diten.Web.UI.Themes.Default";
		}
	}
}