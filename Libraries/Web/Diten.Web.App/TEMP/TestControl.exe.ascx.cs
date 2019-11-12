#region Using Directives

using System;
using Diten.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.App.TEMP
{
	public partial class TestControl : Application
	{
		public TestControl()
		{
			Init += TestControl_Init;
		}

		protected void OnClick(object sender,
			DirectEventArgs e)
		{
			X.Msg.Alert("ddddddddddddddd", "fffffffffff");
		}

		protected void Page_Load(object sender,
			EventArgs e)
		{
		}

		private void TestControl_Init(object sender,
			EventArgs e)
		{
			Title = "ddddddddddddddddd";
		}
	}
}