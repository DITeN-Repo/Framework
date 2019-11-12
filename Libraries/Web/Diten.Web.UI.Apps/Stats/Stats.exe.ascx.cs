#region Using Directives

using System;
using System.Web.UI.WebControls;
using Diten.Properties;
using Diten.Web.Administration;
using Diten.Win32;
using Ext.Net;

#endregion

namespace Diten.Web.UI.Apps.Stats
{
	public partial class Stats : Application
	{
		// ReSharper disable once InconsistentNaming
		private const string ViewStateWebStats = "ViewStateWebStats";

		public Stats()
		{
			Width = Unit.Pixel(1150);
			Height = Unit.Pixel(600);
			Title = "Stats";
			ApplicationName = "Stats";

			HelpWindow.ID = "Window_Stats_HelpWindow";
		}

		/// <summary>
		///     Get application ID.
		/// </summary>
		public Guid ApplicationId => new Guid("DCD1CA88-15D3-42B2-93DB-00044AD58D1F");

		/// <summary>
		///     Get or Set WebStats.
		/// </summary>
		// ReSharper disable once InconsistentNaming
		public WebStats WebStats
		{
			get
			{
				if (ViewState[ViewStateWebStats] == null)
					ViewState[ViewStateWebStats] = Page.LoadControl(typeof(WebStats));

				return (WebStats) ViewState[ViewStateWebStats];
			}
			set => ViewState[ViewStateWebStats] = value;
		}

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
		public void InitializeComponents()
		{
			//CenterPanel.ContentControls.Add(Page.LoadControl(typeof(StatsCenterPanel)));

			//if (X.IsAjaxRequest) return;

			//StatsButtonPinTo.DTIcon = Icon.Pin16;
			//StatsButtonRename.DTIcon = Icon.Rename16;
			//StatsButtonSelectAll.DTIcon = Icon.Selectall16;
			//StatsButtonSelectNone.DTIcon = Icon.Selectnone16;
			//StatsButtonInvertSelection.DTIcon = Icon.Invertselection16;
			//StatsButtonHistory.DTIcon = Icon.History16;
		}

		protected void ButtonFormSave_Click(object sender, DirectEventArgs e)
		{
			StatusBar.SetStatus(new StatusBarStatusConfig {Text = "Form saved!", IconCls = " ", Clear2 = true});
		}

		private void Reconfigure()
		{
			foreach (var site in ServerManager.Sites)
				TaskScheduler.AddIISLogParser(site, Resources.IISWorkerProcessUser,
					Resources.IISWorkerProcessUserPassword);
		}

		protected void ButtonSetOdbcLogging_OnClick(object sender, DirectEventArgs e)
		{
		}

		protected void ContentPanel_OnAfterClientInit(Observable sender)
		{
			InitializeComponents();
		}

		#region Button groups click event handlers

		#region Clipboard button group

		protected void ButtonPinTo_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Pin to", "Copy ").Show();
		}

		protected void ButtonCopy_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Copy", "Copy ").Show();
		}

		protected void ButtonPaste_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Paste", "Copy ").Show();
		}

		protected void ButtonCut_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Cut", "Copy ").Show();
		}

		protected void ButtonCopyPath_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Copy path", "Copy ").Show();
		}

		protected void ButtonPasteShorcut_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Paste shortcut", "Copy ").Show();
		}

		#endregion

		#region Organize button group

		protected void SplitButtonMoveTo_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Move to", "Copy ").Show();
		}

		protected void SplitButtonCopyTo_Clik(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Copy to", "Copy ").Show();
		}

		protected void SplitButtonDelete_Click(object sender, DirectEventArgs e)
		{
		}

		protected void MenuItemRecycle_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Recycle", "Copy ").Show();
		}

		protected void MenuItemPermanentlyDelete_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Permanently delete", "Copy ").Show();
		}

		protected void ButtonRename_Clik(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Rename", "Copy ").Show();
		}

		#endregion

		#region New button group

		protected void ButtonNewFolder_Clik(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("New folder", "Copy ").Show();
		}

		protected void SplitButtonNewItem_Clik(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("New item", "Copy ").Show();
		}

		#endregion

		#region Open button group

		protected void ButtonProperties_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Properties", "Copy ").Show();
		}

		protected void SplitButtonOpen_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Open", "Copy ").Show();
		}

		protected void ButtonEdit_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Open", "Copy ").Show();
		}

		protected void ButtonHistory_Clik(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("History", "Copy ").Show();
		}

		#endregion

		#region Select button group

		protected void ButtonSelectAll_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Select all", "Copy ").Show();
		}

		protected void ButtonSelectNone_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Select none", "Copy ").Show();
		}

		protected void ButtonInvertSelection_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Invert selection", "Copy ").Show();
		}

		#endregion

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