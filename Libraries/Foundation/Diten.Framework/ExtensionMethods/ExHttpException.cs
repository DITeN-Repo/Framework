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
// Creation Date: 2019/08/16 12:13 AM

#region Used Directives

using Diten.Web;

#endregion

namespace Diten
{
	public static class ExHttpException
	{
		public static HttpException ToHttpException(this System.Web.HttpException exception) { return (HttpException) exception; }
	}
}