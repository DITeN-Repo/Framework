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
// Creation Date: 2019/09/02 2:05 PM

#region Used Directives

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#endregion

public class Startup
{
	public void Configure(IApplicationBuilder app,
	                      IHostingEnvironment env)
	{
		if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
		else
		{
			app.UseExceptionHandler("/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseSession();
		app.UseHttpContextItemsMiddleware();
		app.UseMvc();
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDistributedMemoryCache();

		services.AddSession(options =>
		                    {
			                    // Set a short timeout for easy testing.
			                    options.IdleTimeout = TimeSpan.FromSeconds(10);
			                    options.Cookie.HttpOnly = true;
			                    // Make the session cookie essential
			                    options.Cookie.IsEssential = true;
		                    });

		services.AddMvc()
		        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
	}
}