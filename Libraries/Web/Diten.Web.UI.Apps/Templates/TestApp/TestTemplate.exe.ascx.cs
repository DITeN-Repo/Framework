#region Using Directives

using System;
using Diten.ExtensionMethods;
using Diten.Web.UI.Apps.Templates.Application;
using Ext.Net;

#endregion

namespace Diten.Web.UI.Apps.Templates.TestApp
{
	public partial class TestTemplate : UI.Application
	{
		public TestTemplate()
		{
			Title = "Test Template";
		}

		/// <summary>
		///     Get application ID.
		/// </summary>
		public Guid ApplicationId => new Guid("F192DE25-0C96-4B16-8F77-0000F304BE6A");

		/// <summary>
		///     Page on load event handler.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			InitializeComponents();
		}

		/// <summary>
		///     Initialize components.
		/// </summary>
		private void InitializeComponents()
		{
			CenterPanel.ContentControls.Add(Page.LoadControl(typeof(ApplicationTemplateCenterPanel)));

			DesktopModuleProxy.Module.ModuleID = $"{ID.ToPrefix()}DesktopModule";

			if (X.IsAjaxRequest) return;
		}

		protected void ButtonViewIcons_Click(object sender, DirectEventArgs e)
		{
		}

		protected void ButtonViewDetail_Click(object sender, DirectEventArgs e)
		{
		}

		protected void OnEvent(object sender, DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		#region Button groups click event handlers

		#region Help button group

		/// <summary>
		///     Help button click event handler.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Direct event args.</param>
		protected void ButtonHelp_Click(object sender, DirectEventArgs e)
		{
			HelpWindow.HelpId = e.ExtraParams["HelpId"];
			HelpWindow.Show();
		}

		protected void MenuItemAboutDiten_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("About DITeN", "Copy ").Show();
		}

		#endregion

		#endregion
	}
}