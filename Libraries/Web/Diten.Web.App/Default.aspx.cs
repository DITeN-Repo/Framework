#region Using Directives

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Hosting;
using Diten.Diagnostics;
using Diten.Web.UI;
using Diten.Web.UI.Pages;


//using Diten.Data.Ado.Helpers;

#endregion

namespace Diten.Web.App
{
	/// <inheritdoc />
	/// <summary>
	///     Default page of App.Diten.Net.
	/// </summary>
	public partial class Default : Page
	{
		public static Dictionary<string, Assembly> Assemblies
		{
			get
			{
				if (HttpContext.Current.Application[StackTrace.GetFrameName()] == null)
					HttpContext.Current.Application[StackTrace.GetFrameName()] =
						Reflection.Assembly.GetAssemblies();

				return (Dictionary<string, Assembly>) HttpContext.Current.Application[
					StackTrace.GetFrameName()];
			}
		}

		/// <summary>
		///     Page load event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
#if DEBUG
			clear:
			Application.Clear();
			HttpContext.Current.Application.Clear();

			if (Application.Count > 0) goto clear;

			HostingEnvironment.RegisterVirtualPathProvider(new ResourceProvider());
#endif

			Redirect(typeof(Desktop));
			//Redirect(typeof(Test));

			//try
			//{
			//    DomainId = Domains.GetDomainId(Diten.Variables.Constants.SystemDomainName);
			//}
			//catch
			//{
			//    DomainId = Guid.NewGuid();

			//    var ownerId = Users.InsertUser(DomainId,
			//        "Arash.Rahimian",
			//        "Arash.Rahimian@Diten.Net",
			//        "System administrator",
			//        Page.Culture,
			//        "Arash.Rahimian@Diten.net",
			//        Md5.Encrypt("Vilo49%RFKi$$"),
			//        "0452570034",
			//        "Arash",
			//        "Rahimian",
			//        "Kordestani",
			//        DateTime.Parse("1977/10/23"),
			//        "Iran",
			//        "Tehran", "Tehran",
			//        "Amanieh",
			//        "Sq. Vanak, St. Vali-e Assr, Aly. Mahnaz, No:9, Apt:2",
			//        "1966784583",
			//        "+98 (0935) 100-6144",
			//        "+98 (021) 2621-5352",
			//        "+98 (021) 2621-5580",
			//        "+98 (021) 2621-5352",
			//        string.Empty);

			//    Domains.InsertDomain(DomainId,
			//        Diten.Variables.Constants.SystemDomainName,
			//        "System domain",
			//        DateTime.Now.AddYears(1000),
			//        ownerId);
			//}

			DomainId = Guid.Empty;

			//Redirect(typeof(Login));
		}
	}
}