#region Using Directives

using System;

#endregion

namespace Diten.Web.UI.Apps.Templates
{
	public partial class Test : UI.Application
	{
		public Test()
		{
			Title = "Test";
			Width = 500;
			Height = 500;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}