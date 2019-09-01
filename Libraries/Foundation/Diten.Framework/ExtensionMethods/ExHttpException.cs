#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:13 AM

#endregion

#region Used Directives

using Diten.Web;

#endregion

namespace Diten
{
	public static class ExHttpException
	{
		public static HttpException ToHttpException(this System.Web.HttpException exception)
		{
			return (HttpException) exception;
		}
	}
}