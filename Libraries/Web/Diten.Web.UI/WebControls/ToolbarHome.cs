#region Using Directives

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Ext.Net;

#endregion

// ReSharper disable InconsistentNaming

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ToolbarHome runat=\"server\"></{0}:ToolbarHome>")]
	[SuppressMessage("ReSharper", "UnusedMember.Local")]
	[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class ToolbarHome : Toolbar
	{
		public ToolbarHome()
		{
			InitializeComponents();
		}

		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString();

		private static MenuSeparator MenuSeparator =>
			new MenuSeparator
			{
				Cls = "MenuSeparator"
			};

		public void InitializeComponents()
		{
			InitButtonGroupClipboard();
			InitButtonGroupOrganize();
			InitButtonGroupNew();
			InitButtonGroupOpen();
			InitButtonGroupSelect();

			Items.Add(ButtonGroupClipboard);
			Items.Add(ButtonGroupOrganize);
			Items.Add(ButtonGroupNew);
			Items.Add(ButtonGroupOpen);
			Items.Add(ButtonGroupSelect);
		}

		#region ButtonGroupClipboard

		public ButtonGroup ButtonGroupClipboard
		{
			get
			{
				if (ViewState["ButtonGroupClipboard"] == null)
					ViewState["ButtonGroupClipboard"] = new ButtonGroup
					{
						ID = "ButtonGroupClipboard",
						Title = @"Clipboard",
						Columns = 4
					};

				return (ButtonGroup) ViewState["ButtonGroupClipboard"];
			}
		}

		public Button ButtonPinTo;
		public Button ButtonPaste;
		public Button ButtonCut;
		public Button ButtonCopyPath;
		public Button ButtonPasteShortcut;

		public Button ButtonCopy
		{
			get
			{
				if (ViewState["ButtonCopy"] == null)
					ViewState["ButtonCopy"] = new Button
					{
						ID = "ButtonCopy",
						Text = @"Copy",
						Icon = Ext.Net.Icon.PageCopy,
						Scale = ButtonScale.Large,
						IconAlign = IconAlign.Top,
						RowSpan = 3,
						ToolTip = @"Copy the selected items to clipboard (Ctrl+C)."
					};

				return (Button) ViewState["ButtonCopy"];
			}
		}

		private void InitButtonGroupClipboard()
		{
			ButtonPinTo = new Button
			{
				ID = "ButtonPinTo",
				Text = @"Pin",
				OverflowText = @"Pin...",
				Scale = ButtonScale.Large,
				DTIcon = Icons.Pin,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Pin folder to quick access"
			};
			ButtonGroupClipboard.Items.Add(ButtonPinTo);

			ButtonGroupClipboard.Items.Add(ButtonCopy);

			ButtonPaste = new Button
			{
				ID = "ButtonPaste",
				Text = @"Paste",
				Icon = Ext.Net.Icon.PagePaste,
				Scale = ButtonScale.Large,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Paste the contents of Clipboard to the current location. (Ctrl+V)"
			};
			ButtonGroupClipboard.Items.Add(ButtonPaste);

			ButtonCut = new Button
			{
				ID = "ButtonCut",
				Text = @"Cut",
				Icon = Ext.Net.Icon.Cut,
				ToolTip = @"Move the selected items to the Clipboard. (Ctrl+X)"
			};
			ButtonGroupClipboard.Items.Add(ButtonCut);

			ButtonCopyPath = new Button
			{
				ID = "ButtonCopyPath",
				Text = @"Copy path",
				Icon = Ext.Net.Icon.PageCopy,
				ToolTip = @"Copy the path of selected items to the Clipboard."
			};
			ButtonGroupClipboard.Items.Add(ButtonCopyPath);

			ButtonPasteShortcut = new Button
			{
				ID = "ButtonPasteShortcut",
				Text = @"Paste shortcut",
				Icon = Ext.Net.Icon.PagePaste,
				ToolTip = @"Paste shortcuts to the items on the Clipboard."
			};
			ButtonGroupClipboard.Items.Add(ButtonPasteShortcut);
		}

		#endregion

		#region ButtonGroupOrganize

		private ButtonGroup ButtonGroupOrganize;
		public SplitButton SplitButtonMoveTo;
		public Menu SplitButtonMoveToMenu;
		public SplitButton SplitButtonCopyTo;
		public Menu SplitButtonCopyToMenu;
		public SplitButton SplitButtonDelete;
		public Menu SplitButtonDeleteMenu;
		public MenuItem SplitButtonDeleteMenuItemRecycle;
		public MenuItem SplitButtonDeleteMenuItemPermanentlyDelete;
		public Button ButtonRename;

		private void InitButtonGroupOrganize()
		{
			ButtonGroupOrganize = new ButtonGroup
			{
				ID = "ButtonGroupOrganize",
				Title = @"Organize",
				Columns = 4
			};

			SplitButtonMoveTo = new SplitButton
			{
				ID = "SplitButtonMoveTo",
				Text = @"Move to",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.ShapeMoveBack,
				IconAlign = IconAlign.Top,
				ArrowAlign = ArrowAlign.Right,
				RowSpan = 3,
				ToolTip = @"Move the selected items to the location you choose."
			};

			ButtonGroupOrganize.Items.Add(SplitButtonMoveTo);

			SplitButtonCopyTo = new SplitButton
			{
				ID = "SplitButtonCopyTo",
				Text = @"Copy to",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.PageWhiteCopy,
				IconAlign = IconAlign.Top,
				ArrowAlign = ArrowAlign.Right,
				RowSpan = 3,
				ToolTip = @"Copy the selected items to the location you choose."
			};

			ButtonGroupOrganize.Items.Add(SplitButtonCopyTo);

			#region SplitButtonDelete

			SplitButtonDelete = new SplitButton
			{
				ID = "SplitButtonDelete",
				Text = @"Delete",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.Delete,
				IconAlign = IconAlign.Top,
				ArrowAlign = ArrowAlign.Right,
				RowSpan = 3,
				ToolTip =
					@"Move the selected items to teh Recycle Bin or permanently delete them. (Ctrl+D)"
			};

			#region SplitButtonDelete

			SplitButtonDeleteMenu = new Menu();

			#region SplitButtonDeleteMenuItemRecycle

			SplitButtonDeleteMenuItemRecycle = new MenuItem
			{
				Text = "Recycle",
				ToolTip = @"Move the selected items to the Recycle Bin. (Ctrl+D)"
			};

			SplitButtonDeleteMenu.Items.Add(SplitButtonDeleteMenuItemRecycle);

			#endregion

			#region SplitButtonDeleteMenuItemPermanentlyDelete

			SplitButtonDeleteMenuItemPermanentlyDelete = new MenuItem
			{
				Text = "Permanently delete",
				ToolTip = @"Permanently delete the selected items."
			};

			SplitButtonDeleteMenu.Items.Add(SplitButtonDeleteMenuItemPermanentlyDelete);

			#endregion

			SplitButtonDelete.Menu.Add(SplitButtonDeleteMenu);

			ButtonGroupOrganize.Items.Add(SplitButtonDelete);

			#endregion

			#endregion

			ButtonGroupOrganize.Items.Add(MenuSeparator);

			ButtonRename = new Button
			{
				ID = "ButtonRename",
				Text = @"Rename",
				DTIcon = Icons.Rename,
				Scale = ButtonScale.Large,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Rename the selected item. (F2)"
			};

			ButtonGroupOrganize.Items.Add(ButtonRename);
		}

		#endregion

		#region ButtonGroupNew

		private ButtonGroup ButtonGroupNew;
		public Button ButtonNewFolder;
		public SplitButton SplitButtonNewItem;
		public SplitButton SplitButtonEasyAccess;
		public Menu SplitButtonEasyAccessMenu;
		public MenuItem SplitButtonEasyAccessMenuItemIncludeInLibrary;
		public MenuItem SplitButtonEasyAccessMenuItemMapAsDrive;
		public MenuItem SplitButtonEasyAccessMenuItemAlwaysAvailableOffline;
		public MenuItem SplitButtonEasyAccessMenuItemSync;
		public MenuItem SplitButtonEasyAccessMenuItemWorkOffline;
		private Button ButtonTmp;

		private void InitButtonGroupNew()
		{
			ButtonGroupNew = new ButtonGroup
			{
				ID = "ButtonGroupNew",
				Title = @"New",
				Columns = 2
			};

			ButtonNewFolder = new Button
			{
				ID = "ButtonNewFolder",
				Text = @"New folder",
				Icon = Ext.Net.Icon.FolderAdd,
				Scale = ButtonScale.Large,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Create a new folder."
			};
			ButtonGroupNew.Items.Add(ButtonNewFolder);

			SplitButtonNewItem = new SplitButton
			{
				ID = "SplitButtonNewItem",
				Text = @"New item",
				Icon = Ext.Net.Icon.New,
				ArrowAlign = ArrowAlign.Right,
				ToolTip = @"Create a new item in the current location."
			};
			ButtonGroupNew.Items.Add(SplitButtonNewItem);

			#region SplitButtonEasyAccess

			SplitButtonEasyAccess = new SplitButton
			{
				ID = "SplitButtonEasyAccess",
				Text = @"Easy access",
				Icon = Ext.Net.Icon.ApplicationStart,
				ArrowAlign = ArrowAlign.Right,
				ToolTip =
					@"Create a way to access the selected location quickly, and work with offline files."
			};
			SplitButtonEasyAccessMenu = new Menu();

			SplitButtonEasyAccessMenuItemIncludeInLibrary = new MenuItem
			{
				Text = "Include in library",
				Icon = Ext.Net.Icon.FolderBookmark,
				Enabled = false
			};
			SplitButtonEasyAccessMenu.Items.Add(SplitButtonEasyAccessMenuItemIncludeInLibrary);
			SplitButtonEasyAccessMenu.Items.Add(new MenuSeparator());

			SplitButtonEasyAccessMenuItemMapAsDrive = new MenuItem
			{
				Text = "Map as drive",
				Icon = Ext.Net.Icon.DriveNetwork,
				Enabled = false
			};
			SplitButtonEasyAccessMenu.Items.Add(SplitButtonEasyAccessMenuItemMapAsDrive);
			SplitButtonEasyAccessMenu.Items.Add(new MenuSeparator());

			SplitButtonEasyAccessMenuItemAlwaysAvailableOffline = new MenuItem
			{
				Text = "Always available offline",
				Icon = Ext.Net.Icon.TableRefresh,
				Enabled = false
			};
			SplitButtonEasyAccessMenu.Items.Add(SplitButtonEasyAccessMenuItemAlwaysAvailableOffline);

			SplitButtonEasyAccessMenuItemSync = new MenuItem
			{
				Text = "Sync",
				Icon = Ext.Net.Icon.ArrowRefresh,
				Enabled = false
			};
			SplitButtonEasyAccessMenu.Items.Add(SplitButtonEasyAccessMenuItemSync);

			SplitButtonEasyAccessMenuItemWorkOffline = new MenuItem
			{
				Text = "Work offline",
				Icon = Ext.Net.Icon.StatusOffline,
				Enabled = false
			};
			SplitButtonEasyAccessMenu.Items.Add(SplitButtonEasyAccessMenuItemWorkOffline);

			SplitButtonEasyAccess.Menu.Add(SplitButtonEasyAccessMenu);

			#endregion

			ButtonGroupNew.Items.Add(SplitButtonEasyAccess);

			ButtonTmp = new Button
			{
				ID = "ButtonTmp",
				Enabled = false,
				Disabled = true
			};
			ButtonGroupNew.Items.Add(ButtonTmp);
		}

		#endregion

		#region ButtonGroupOpen

		private ButtonGroup ButtonGroupOpen;
		public Button ButtonProperties;
		public SplitButton SplitButtonOpen;
		public Button ButtonEdit;
		public Button ButtonHistory;

		private void InitButtonGroupOpen()
		{
			ButtonGroupOpen = new ButtonGroup
			{
				ID = "ButtonGroupOpen",
				Title = @"Open",
				Columns = 2
			};

			ButtonProperties = new Button
			{
				ID = "ButtonProperties",
				Text = @"Properties",
				Icon = Ext.Net.Icon.PageCode,
				Scale = ButtonScale.Large,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Show the properties for the selected item. (Alt+Enter)"
			};

			ButtonGroupOpen.Items.Add(ButtonProperties);

			#region SplitButtonOpen

			SplitButtonOpen = new SplitButton
			{
				ID = "SplitButtonOpen",
				Text = @"Open",
				Icon = Ext.Net.Icon.BookOpen,
				ToolTip = @"Open the selected file with the default program. (Ctrl+O)"
			};

			ButtonGroupOpen.Items.Add(SplitButtonOpen);

			#endregion

			ButtonEdit = new Button
			{
				ID = "ButtonEdit",
				Text = @"Edit",
				Icon = Ext.Net.Icon.BookEdit,
				ToolTip = @"Edit the selected files."
			};

			ButtonGroupOpen.Items.Add(ButtonEdit);

			ButtonHistory = new Button
			{
				ID = "ButtonHistory",
				Text = @"History",
				DTIcon = Icons.History,
				ToolTip = @"Show history for the selected item."
			};

			ButtonGroupOpen.Items.Add(ButtonHistory);
		}

		#endregion

		#region ButtonGroupSelect

		private ButtonGroup ButtonGroupSelect;
		public Button ButtonSelectAll;
		public Button ButtonSelectNone;
		public Button ButtonInvertSelection;

		private void InitButtonGroupSelect()
		{
			ButtonGroupSelect = new ButtonGroup
			{
				ID = "ButtonGroupSelect",
				Title = @"Select",
				Columns = 1
			};

			ButtonSelectAll = new Button
			{
				ID = "ButtonSelectAll",
				Text = @"Select all",
				DTIcon = Icons.SelectAll,
				ToolTip = @"Select all items in this view. (Ctrl+A)"
			};

			ButtonGroupSelect.Items.Add(ButtonSelectAll);

			ButtonSelectNone = new Button
			{
				ID = "ButtonSelectNone",
				Text = @"Select none",
				DTIcon = Icons.SelectNone,
				ToolTip = @"Clear all your selections."
			};

			ButtonGroupSelect.Items.Add(ButtonSelectNone);

			ButtonInvertSelection = new Button
			{
				ID = "ButtonInvertSelection",
				Text = @"Invert selection",
				DTIcon = Icons.InvertSelection,
				ToolTip = @"Reverse the current selection."
			};

			ButtonGroupSelect.Items.Add(ButtonInvertSelection);
		}

		#endregion

		#region ButtonGroupHelp

		private ButtonGroup ButtonGroupHelp;
		public SplitButton SplitButtonHelp;

		private void InitButtonGroupHelp()
		{
			ButtonGroupHelp = new ButtonGroup
			{
				ID = "ButtonGroupHelp",
				Title = @"Help",
				Columns = 1
			};

			ButtonGroupHelp.Items.Add(MenuSeparator);

			SplitButtonHelp = new SplitButton
			{
				ID = "SplitButtonNewItem",
				Text = @"New item",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.Help,
				IconAlign = IconAlign.Top,
				ArrowAlign = ArrowAlign.Right,
				RowSpan = 3,
				ToolTip = @"Show help of current view."
			};

			var splitButtonHelpMenu = new Menu
			{
				ID = "HelpMenu"
			};

			var splitButtonHelpMenuMenuItem = new MenuItem
			{
				ID = "MenuItemAboutDiten",
				Text = "About DITeN framework",
				Icon = Ext.Net.Icon.Information,
				ToolTip = @"Show information about DITeN."
			};

			splitButtonHelpMenuMenuItem.DirectEvents.Click.Event += MenuItemAboutDitenClick_Event;
			splitButtonHelpMenu.Items.Add(splitButtonHelpMenuMenuItem);

			SplitButtonHelp.Menu.Add(splitButtonHelpMenu);
			SplitButtonHelp.DirectEvents.Click.Event += SplitButtonHelpClick_Event;
			SplitButtonHelp.DirectEvents.Click.EventMask.Msg = new Page().Translate("Show help");
			SplitButtonHelp.DirectEvents.Click.EventMask.Target = MaskTarget.CustomTarget;
			SplitButtonHelp.DirectEvents.Click.EventMask.CustomTarget = @"#{ContentPanel}";
			SplitButtonHelp.DirectEvents.Click.EventMask.ShowMask = true;
			SplitButtonHelp.DirectEvents.Click.ExtraParams.Add(new Parameter
			{
				Name = "HelpID",
				Value =
					"Diten.Web.UI.WebControls.SystemControls.Explorer",
				Mode = ParameterMode.Value
			});

			ButtonGroupHelp.Items.Add(SplitButtonHelp);
		}

		private void SplitButtonHelpClick_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuItemAboutDitenClick_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}