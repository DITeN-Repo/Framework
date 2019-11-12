#region Using Directives

using System;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Diten.Web.UI.WebControls;
using Ext.Net;
using X = Ext.Net.X;

#endregion

namespace Diten.Web.UI.Apps.Templates.Application
{
	public partial class ApplicationTemplate : UI.Application
	{
		public ApplicationTemplate()
		{
			Init += ApplicationTemplate_Init;
		}

		private void ApplicationTemplate_Init(object sender, EventArgs e)
		{
			Title = "Application Template";
			ApplicationName = "Application Template";
			Width = Unit.Pixel(1150);
			Height = Unit.Pixel(600);
			DTIcon = Icons.Application;
			HelpWindow.ID = $@"{ID.ToPrefix()}Window_ApplicationTemplate_HelpWindow";
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
			CenterPanel.ContentControls.Add(Page.LoadControl(typeof(ApplicationTemplateCenterPanel)));

			//ToolbarHome.ButtonCopy.Click += ButtonCopy_Click;

			Explorer.DeleteConfirmationDialog.Yes += DeleteConfirmationDialog_Yes;
			Explorer.ContextMenu.DeleteMenuItemClick += ContextMenu_DeleteMenuItemClick;
			Explorer.DataBind();
		}

		protected void ButtonCopy_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Copy", "Copy ").Show();
		}

		private void ContextMenu_DeleteMenuItemClick(object sender, DirectEventArgs e)
		{
			SplitButtonDelete_Click(sender, e);
		}

		private void DeleteConfirmationDialog_Yes(object sender, ConfirmationDialog.YesEventArgs e)
		{
			X.Msg.Alert("Delete", "Do Yes ").Show();
		}

		protected void ButtonViewIcons_Click(object sender, DirectEventArgs e)
		{
			Explorer.ViewMode = Explorer.ViewModes.ViewIcons;
			Explorer.DataBind();
			CenterPanel.Update();
		}

		protected void ButtonViewDetail_Click(object sender, DirectEventArgs e)
		{
			Explorer.ViewMode = Explorer.ViewModes.ViewDetail;
			Explorer.DataBind();
			CenterPanel.Update();
		}

		protected void ButtonFormSave_Click(object sender, DirectEventArgs e)
		{
			StatusBar.SetStatus(new StatusBarStatusConfig {Text = "Form saved!", IconCls = " ", Clear2 = true});
		}

		protected void Test_Click(object sender, DirectEventArgs e)
		{
			X.MessageBox.Alert("Test", "Direct Click");
		}

		protected void ButtonTest_OnClick(object sender, EventArgs e)
		{
			X.MessageBox.Alert("Test", "message");
		}

		#region Button groups click event handlers

		#region Clipboard button group

		protected void ButtonPinTo_Click(object sender, DirectEventArgs e)
		{
			X.Msg.Alert("Pin to", "").Show();
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
			//if (Explorer.SelectedItemsIds.Count.Equals(0))
			//    return;

			//var word = Explorer.SelectedItemsIds.Count.Equals(1) ? "مورد" : "موارد";

			//Explorer.DeleteConfirmationDialog.DoConfirm(Page.Translate(ConstVariables.SystemWarningDialogTitle),
			//    Page.Translate($@"آیا از حذف کردن {word} انتخاب شده اطمینان دارید"),
			//    new Dictionary<string, string> {{"SenderID", ID}}, new Dictionary<string, string> {{"SenderID", ID}});
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