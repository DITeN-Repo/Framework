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
using System.Diagnostics;
using System.Globalization;
using Diten.Web.App.Tools.URLShortener.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

#endregion

namespace Diten.Web.App.Tools.URLShortener.Controllers
{
	public class HomeController: Controller
	{
		public HomeController(ILogger<HomeController> logger) => _logger = logger;
		private readonly ILogger<HomeController> _logger;

		[ResponseCache(Duration = 0,
			Location = ResponseCacheLocation.None,
			NoStore = true)]
		public IActionResult Error() => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

		public IActionResult Index() => View();

		public IActionResult Privacy() => View();

		[HttpPost]
		public IActionResult Shortening(HomeModel model)
		{
			var shortUrl = model.SourceUrl;
			var sourceUrl = model.ShortUrl;

			model.ShortUrl = DateTime.Now.ToString(CultureInfo.InvariantCulture);

			return View(new HomeModel
			            {
				            SourceUrl = model.SourceUrl,
				            ShortUrl = model.ShortUrl
			            });
		}
  }
}