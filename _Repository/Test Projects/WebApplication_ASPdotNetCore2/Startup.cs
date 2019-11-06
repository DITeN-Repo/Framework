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
// Creation Date: 2019/09/02 5:23 AM

#region Used Directives

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace WebApplication_ASPdotNetCore2
{
	public class Startup
	{
		public Startup(IConfiguration configuration) { Configuration = configuration; }

		public IConfiguration Configuration {get;}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,
		                      IHostingEnvironment env)
		{
			if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			                                        {
				                                        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
				                                        options.CheckConsentNeeded = context => true;
				                                        options.MinimumSameSitePolicy = SameSiteMode.None;
			                                        });

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}
	}
}