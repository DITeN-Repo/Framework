#region Using Directives

using System.Diagnostics.CodeAnalysis;
using System.Web.UI;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[ToolboxData("<{0}:StatusBar runat=\"server\"></{0}:StatusBar>")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class StatusBar : Ext.Net.StatusBar
	{
	}
}