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

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

#endregion

namespace WebApplication_ASPdotNetCore
{
	public class Program
	{
		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
			              .UseStartup<Startup>();
		}

		public static void Main(string[] args) { CreateWebHostBuilder(args).Build().Run(); }
	}
}