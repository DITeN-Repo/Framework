#region Using Directives

using System;
using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ApplicationPanel runat=\"server\"></{0}:ApplicationPanel>")]
	public class ApplicationPanel : ContentPanel
	{
		public ApplicationPanel()
		{
			Init += ApplicationPanel_Init;
		}

		private void ApplicationPanel_Init(object sender,
			EventArgs e)
		{
			Initialize();
		}

		private void Initialize()
		{
			Layout = Layouts.Fit;
			Border = false;
		}
	}
}