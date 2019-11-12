#region Using Directives

using System;
using Diten.ExtensionMethods;
using Diten.Web.Administration;
using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Web.UI.Apps.Stats
{
	public partial class StatsCenterPanel : UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			return;
			foreach (var site in ServerManager.Sites)
			{
				var webStats = (WebStats) Page.LoadControl(typeof(WebStats));
				webStats.ID = $@"WebStats_W3SVC{site.Id}";
				webStats.SiteName = site.Name;

				var panel = new Panel
				{
					Title = site.Name,
					ID = $@"{ID.ToPrefix()}Panel{webStats.ID}",
					Layout = Layouts.Fit
				};

				panel.ContentControls.Add(webStats);
				TabPanelWebSites.Items.Add(panel);
			}
		}
	}
}