#region Using Directives

using System;
using System.Collections.Generic;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "SCM")]
	[ToolboxData("<{0}:StandardContextMenu runat=\"server\"></{0}:StandardContextMenu>")]
	public sealed class StandardContextMenu : Menu
	{
		public enum MenuItemType
		{
			Open,
			Cut,
			Copy,
			Paste,
			Delete,
			Rename,
			Properties
		}


		public StandardContextMenu()
		{
			Init += StandardContextMenu_Init;
		}

		/// <summary>
		///     Get NewMenu.
		/// </summary>
		public Menu NewMenu =>
			ViewState.GetValue<Menu>(this.GetFrameName(), new Menu {ID = $@"{ID.ToPrefix()}{this.GetFrameName()}"});

		public new Page Page => base.Page as Page;

		/// <summary>
		///     Get or Set SelectedItemsIds.
		/// </summary>
		public List<Guid> SelectedItemsIds
		{
			get
			{
				if (HttpContext.Current.Session[$@"{ClientID.ToPrefix()}{this.GetFrameName()}"] == null)
					HttpContext.Current.Session[$@"{ClientID.ToPrefix()}{this.GetFrameName()}"] = new List<Guid>();

				return (List<Guid>) HttpContext.Current.Session[$@"{ClientID.ToPrefix()}{this.GetFrameName()}"];
			}
			set => HttpContext.Current.Session[$@"{ClientID.ToPrefix()}{this.GetFrameName()}"] = value;
		}

		/// <summary>
		///     Get SendToMenu.
		/// </summary>
		public Menu SendToMenu =>
			ViewState.GetValue<Menu>(this.GetFrameName(), new Menu {ID = $@"{ID.ToPrefix()}{this.GetFrameName()}"});

		private MenuItem GetMenuItem(string text,
			MenuItemType menuItemType)
		{
			using (var menuItem = new MenuItem
				{Text = text, ID = $@"{ID.ToPrefix()}{menuItemType}{this.GetFrameType()}"})
			{
				menuItem.DirectEvents.Click.ExtraParams.Add(new Parameter
				{
					Name = $"{typeof(MenuItemType).Name}",
					Value = menuItemType.ToString(),
					Mode = ParameterMode.Value
				});

				switch (menuItemType)
				{
					case MenuItemType.Open:
						menuItem.Icon = Ext.Net.Icon.BookOpen;

						break;
					case MenuItemType.Cut:
						menuItem.Icon = Ext.Net.Icon.Cut;

						break;
					case MenuItemType.Copy:
						menuItem.Icon = Ext.Net.Icon.PageCopy;

						break;
					case MenuItemType.Paste:
						menuItem.Icon = Ext.Net.Icon.PagePaste;

						break;
					case MenuItemType.Delete:
						menuItem.Icon = Ext.Net.Icon.Delete;

						break;
					case MenuItemType.Properties:
						menuItem.Icon = Ext.Net.Icon.ApplicationEdit;

						break;
					case MenuItemType.Rename:
						menuItem.Icon = Ext.Net.Icon.TextfieldRename;

						break;
					default:

						throw new ArgumentOutOfRangeException();
				}

				menuItem.DirectEvents.Click.Event += MenuItemClick_Event;

				return menuItem;
			}
		}

		/// <summary>
		///     Insert component before MenuItem.
		/// </summary>
		/// <param name="menuItem">MenuItem type that component will be inserted before it.</param>
		/// <param name="component">Component that will be inserted before MenuItem.</param>
		public void Insert(MenuItemType menuItem,
			AbstractComponent component)
		{
			var index = 0;

			foreach (var item in Items)
			{
				if (item.GetType() != typeof(MenuSeparator))
					if (Enum.TryParse(item.ID.Replace(typeof(MenuItem).Name, string.Empty),
						out MenuItemType menuItemType))
						if (menuItem.Equals(menuItemType))
						{
							Insert(index, component);

							break;
						}

				index += 1;
			}
		}

		/// <summary>
		///     Insert component before MenuItem.
		/// </summary>
		/// <param name="menuItemId">Id of the MenuItem that component will be inserted before it.</param>
		/// <param name="component">Component that will be inserted before MenuItem.</param>
		public void Insert(string menuItemId,
			AbstractComponent component)
		{
			var index = 0;

			foreach (var item in Items)
			{
				if (menuItemId.Equals(item.ID))
				{
					Insert(index, component);

					break;
				}

				index += 1;
			}
		}

		private void MenuItemClick_Event(object sender,
			DirectEventArgs e)
		{
			Enum.TryParse(e.ExtraParams[typeof(MenuItemType).Name], out MenuItemType menuItemType);

			switch (menuItemType)
			{
				case MenuItemType.Open:
					OnOpenMenuItemClick(e);

					break;
				case MenuItemType.Cut:
					OnCutMenuItemClick(e);

					break;
				case MenuItemType.Copy:
					OnCopyMenuItemClick(e);

					break;
				case MenuItemType.Paste:
					OnPasteMenuItemClick(e);

					break;
				case MenuItemType.Delete:
					OnDeleteMenuItemClick(e);

					break;
				case MenuItemType.Properties:
					OnPropertiesMenuItemClick(e);

					break;
				case MenuItemType.Rename:
					OnRenameMenuItemClick(e);

					break;
				default:

					throw new ArgumentOutOfRangeException();
			}
		}

		private void StandardContextMenu_Init(object sender,
			EventArgs e)
		{
			Add(GetMenuItem(Dictionary.Default.Openning, MenuItemType.Open));

			if (!NewMenu.Disabled)
			{
				Add(new MenuSeparator());
				var newMenuItem = new MenuItem
				{
					ID = $@"{NewMenu.ID.ToPrefix()}{Names.Default.New.ToPrefix()}{typeof(MenuItem).Name}",
					Text = Dictionary.Default.New
				};
				newMenuItem.Menu.Add(NewMenu);
				Add(newMenuItem);
			}

			Add(new MenuSeparator());
			Add(GetMenuItem(Dictionary.Default.Cut, MenuItemType.Cut));
			Add(GetMenuItem(Dictionary.Default.Copy, MenuItemType.Copy));
			Add(GetMenuItem(Dictionary.Default.Paste, MenuItemType.Paste));

			if (!SendToMenu.Disabled)
			{
				Add(new MenuSeparator());
				var sendToMenuItem = new MenuItem
				{
					ID = $@"{NewMenu.ID.ToPrefix()}{Names.Default.SendTo}{typeof(MenuItem).Name}",
					Text = Dictionary.Default.SendTo
				};
				sendToMenuItem.Menu.Add(SendToMenu);
				Add(sendToMenuItem);
			}

			Add(new MenuSeparator());
			Add(GetMenuItem(Dictionary.Default.Delete, MenuItemType.Delete));
			Add(GetMenuItem(Dictionary.Default.Rename, MenuItemType.Rename));
			Add(new MenuSeparator());
			Add(GetMenuItem(Dictionary.Default.Properties, MenuItemType.Properties));
		}

		#region ExplorerDataViewOpenMenuItemClick event

		/// <summary>
		///     OnOpen
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnOpenMenuItemClick(DirectEventArgs e)
		{
			var handler = OpenMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem open event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> OpenMenuItemClick;

		#endregion

		#region ExplorerDataViewCutMenuItemClick event

		/// <summary>
		///     OnCut
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnCutMenuItemClick(DirectEventArgs e)
		{
			var handler = CutMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem Cut event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> CutMenuItemClick;

		#endregion

		#region ExplorerDataViewCopyMenuItemClick event

		/// <summary>
		///     OnCopy
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnCopyMenuItemClick(DirectEventArgs e)
		{
			var handler = CopyMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem Copy event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> CopyMenuItemClick;

		#endregion

		#region ExplorerDataViewPasteMenuItemClick event

		/// <summary>
		///     OnPaste
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnPasteMenuItemClick(DirectEventArgs e)
		{
			var handler = PasteMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem Paste event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> PasteMenuItemClick;

		#endregion

		#region ExplorerDataViewDeleteMenuItemClick event

		/// <summary>
		///     OnDelete
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		// ReSharper disable once UnusedParameter.Local
		private void OnDeleteMenuItemClick(DirectEventArgs e)
		{
			var handler = DeleteMenuItemClick;
			handler?.Invoke(this, null);
		}

		/// <summary>
		///     MenuItem Delete event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> DeleteMenuItemClick;

		#endregion

		#region ExplorerDataViewPropertiesMenuItemClick event

		/// <summary>
		///     OnProperties
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnPropertiesMenuItemClick(DirectEventArgs e)
		{
			var handler = PropertiesMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem Properties event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> PropertiesMenuItemClick;

		#endregion

		#region ExplorerDataViewRenameMenuItemClick event

		/// <summary>
		///     OnRename
		/// </summary>
		/// <param name="e">MenuItem MenuItemClick event args.</param>
		private void OnRenameMenuItemClick(DirectEventArgs e)
		{
			var handler = RenameMenuItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     MenuItem Rename event handler.
		/// </summary>
		public event EventHandler<DirectEventArgs> RenameMenuItemClick;

		#endregion
	}
}