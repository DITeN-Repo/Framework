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
// Creation Date: 2019/07/30 4:59 PM

#region Used Directives

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

#endregion

namespace dotNetCoreWebApplication
{
	public class Program
	{
		public static IWebHostBuilder CreateWebHostBuilder(System.String[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
			              .UseStartup<Startup>();
		}

		public static void Main(System.String[] args) { CreateWebHostBuilder(args).Build().Run(); }
	}
}