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
// Creation Date: 2019/09/02 5:16 AM

#region Used Directives

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#endregion

namespace WebApplication_ASPdotNetCore.Pages
{
	[ResponseCache(Duration = 0,
		Location = ResponseCacheLocation.None,
		NoStore = true)]
	public class ErrorModel: PageModel
	{
		public string RequestId {get; set;}

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

		public void OnGet() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier; }
	}
}