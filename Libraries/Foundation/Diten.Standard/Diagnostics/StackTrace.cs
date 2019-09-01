#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 5:06 PM

#endregion

namespace Diten.Diagnostics
{
	public class StackTrace:System.Diagnostics.StackTrace
	{
		public static string GetFrameName()
		{
			var _return = new StackTrace().GetFrame(2).GetMethod().Name;

			if(_return.StartsWith("get_"))
				return _return.TrimStart("get_".ToCharArray());

			return _return.StartsWith("set_") ? _return.TrimStart("set_".ToCharArray()) : _return;
		}
	}
}