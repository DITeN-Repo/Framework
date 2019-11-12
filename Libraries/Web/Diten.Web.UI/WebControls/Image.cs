#region Using Directives

using System;
using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:Image runat=\"server\"></{0}:Image>")]
	public class Image : Ext.Net.Image
	{
		/// <summary>
		///     Get container page of the control.
		/// </summary>
		public new Page Page
		{
			get
			{
				try
				{
					return (base.Page ?? HttpContext.Current.Handler) as Page;
				}
				catch (InvalidCastException)
				{
					return new Page((SelfRenderingPage) base.Page);
				}
			}
		}
	}
}