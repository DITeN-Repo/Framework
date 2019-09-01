#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 1:05 AM

#endregion

namespace Diten.Net.Http
{
	public class Tools
	{
		public static string GetDomainName(string url)
		{
			return url.Split("/".ToCharArray())[2];
		}
	}
}