#region Using Directives

using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:TextField runat=\"server\"></{0}:TextField>")]
	public class TextField : Ext.Net.TextField
	{
		#region Constructors

		/// <inheritdoc />
		public TextField()
		{
		}

		public TextField(Config config) : base(config)
		{
		}

		public TextField(string text) : base(text)
		{
		}

		#endregion
	}
}