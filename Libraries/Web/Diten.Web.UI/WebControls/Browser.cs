#region Using Directives

using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:Browser runat=\"server\"></{0}:Browser>")]
	[SuppressMessage("ReSharper", "UnusedVariable")]
	public class Browser : Panel
	{
		public Browser()
		{
			var win = new Window
			{
				ID = "Window1",
				Title = @"Ext.NET",
				Width = Unit.Pixel(1000),
				Height = Unit.Pixel(600),
				Modal = true,
				AutoRender = false,
				Collapsible = true,
				Maximizable = true,
				Hidden = true,
				Loader = new ComponentLoader
				{
					Url = "http://ext.net",
					Mode = LoadMode.Frame,
					LoadMask =
					{
						ShowMask = true
					}
				}
			};
		}
	}
}