#region Copyright

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
// Creation Date: 2019/11/08 11:27 AM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Web.App.Tools.URLShortener.Models
{
	public class ErrorViewModel
	{
		public System.String RequestId {get; set;}

		public Boolean ShowRequestId => !System.String.IsNullOrEmpty(RequestId);
	}
}