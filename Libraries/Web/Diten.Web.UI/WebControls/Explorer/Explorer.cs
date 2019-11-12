#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Xml;
using Diten.Data;
using Diten.ExtensionMethods;
using Diten.Variables;
using Diten.Xml;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:Explorer runat=\"server\"></{0}:Explorer>")]
	public class Explorer : Panel
	{
		public enum ViewModes
		{
			ViewDetail,
			ViewIcons
		}


		public Explorer()
		{
			Init += Explorer_Init;
		}

		/// <summary>
		///     Get ContextMenu.
		/// </summary>
		public StandardContextMenu ContextMenu => ViewState.GetValue<StandardContextMenu>(this.GetFrameName(),
			new StandardContextMenu
			{
				ID = $@"{ID.ToPrefix()}{Names.Default.StandardContextMenu}",
				SelectedItemsIds = SelectedItemsIds
			});

		/// <summary>
		///     Get DeleteConfirmationDialog.
		/// </summary>
		public ConfirmationDialog DeleteConfirmationDialog =>
			ViewState.GetValue<ConfirmationDialog>(this.GetFrameName(), delegate
			{
				var id = $@"{ID.ToPrefix()}{Names.Default.DeleteConfirmationDialog}";
				if (!Controls.OfType<ConfirmationDialog>().Any(c => c.ID.Equals(id)))
					Controls.Add(new ConfirmationDialog
					{
						ID = id
					});

				return Controls.OfType<ConfirmationDialog>().First(c => c.ID.Equals(id));
			});

		public new string ID
		{
			get =>
				ViewState.GetValue<string>(this.GetFrameName(), $@"{GetType().Name.ToPrefix()}{new Random().Next()}");
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		public bool IsInitialized
		{
			get => ViewState.GetValue<bool>(this.GetFrameName(), false);
			private set => ViewState.SetValue(this.GetFrameName(), value);
		}

		public new Page Page
		{
			get
			{
				try
				{
					return (Page) base.Page;
				}
				catch (InvalidCastException)
				{
					return new Page((SelfRenderingPage) base.Page);
				}
			}
		}

		/// <summary>
		///     Get or Set ParentId.
		/// </summary>
		public Guid ParentId
		{
			get
			{
				switch (ViewMode)
				{
					case ViewModes.ViewDetail:

						return ExplorerGridPanel.ParentId;
					case ViewModes.ViewIcons:

						return ExplorerDataView.ParentId;
					default:

						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (ViewMode)
				{
					case ViewModes.ViewDetail:
						ExplorerGridPanel.ParentId = value;

						break;
					case ViewModes.ViewIcons:
						ExplorerDataView.ParentId = value;

						break;
					default:

						throw new ArgumentOutOfRangeException();
				}
			}
		}

		/// <summary>
		///     Get or Set RegisteredTypes.
		/// </summary>
		private IEnumerable<Types.RegisteredType> RegisteredTypes =>
			ViewState.GetValue<List<Types.RegisteredType>>(this.GetFrameName(), delegate
			{
				using (var resourceManager = new ResourceManager())
				{
					return new Document(new XmlDocument().LoadXmlDocument(resourceManager
							.GetManifestResource($@"{GetType()}.{Constants.Default.ManifestFileExtention}", true)
							.Resource.ToString()))
						.GetAttributes($@"{Names.Default.Configuration}.{Names.Default.RegisteredTypes}")
						.Select(node => new Types.RegisteredType
						{
							Name = node[Names.Default.Name],
							Description = node[Names.Default.Description],
							Title = node[Names.Default.Title],
							IconCls = node[Names.Default.IconCls]
						})
						.ToList();
				}
			});

		public List<Guid> SelectedItemsIds =>
			ViewMode.Equals(ViewModes.ViewDetail)
				? ExplorerGridPanel.SelectedItemsIDs
				: ExplorerDataView.SelectedItemsIds;

		public ViewModes ViewMode
		{
			get => ExplorerGridPanel.Visible ? ViewModes.ViewDetail : ViewModes.ViewIcons;
			set
			{
				switch (value)
				{
					case ViewModes.ViewDetail:
						ExplorerDataView.Visible = false;
						ExplorerGridPanel.Visible = true;

						break;
					case ViewModes.ViewIcons:
						ExplorerGridPanel.Visible = false;
						ExplorerDataView.Visible = true;

						break;
					default:

						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void ContextMenuNewFolderMenuItemClick_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ContextMenuNewShortcutMenuItemClick_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ContextMenuSendToDesktopMenuItemClick_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Binding data.
		/// </summary>
		public new void DataBind()
		{
			var dataSource = new List<Entity>();

			foreach (var entity in Entity.GetData())
			foreach (var RegisteredType in RegisteredTypes)
			{
				if (!entity.EntityType.Equals(RegisteredType.Name)) continue;

				var tmpEntity = new Entity
				{
					EntityType = RegisteredType.Title,
					CreationDate = entity.CreationDate,
					DateModified = entity.DateModified,
					Description = entity.Description,
					Id = entity.Id,
					Title = entity.Title,
					IconCls = entity.IconCls
				};

				dataSource.Add(tmpEntity);

				break;
			}

			switch (ViewMode)
			{
				case ViewModes.ViewDetail:
					ExplorerGridPanel.GetStore().DataSource = dataSource;
					ExplorerGridPanel.GetStore().DataBind();

					break;
				case ViewModes.ViewIcons:
					ExplorerDataView.GetStore().DataSource = dataSource;
					ExplorerDataView.GetStore().DataBind();

					break;
				default:

					throw new ArgumentOutOfRangeException();
			}
		}

		private void Explorer_Init(object sender,
			EventArgs e)
		{
			Initialize();
		}

		private void Initialize()
		{
			if (IsInitialized) return;

			Items.Add(ContextMenu);
			ContextMenuID = ContextMenu.ID;
			Layout = Layouts.Fit;
			Controls.Add(DeleteConfirmationDialog);
			Items.Add(ExplorerGridPanel);

			//Items.Add(ExplorerDataView);

			var newFolderMenuItem = new MenuItem
			{
				ID = $@"{ContextMenu.NewMenu.ID.ToPrefix()}{Names.Default.NewFolder}",
				Text = Page.Translate(Dictionary.Default.NewFolder),
				Icon = Ext.Net.Icon.FolderAdd
			};
			newFolderMenuItem.DirectEvents.Click.Event += ContextMenuNewFolderMenuItemClick_Event;
			ContextMenu.NewMenu.Add(newFolderMenuItem);

			var newShortcutMenuItem = new MenuItem
			{
				ID = $@"{ContextMenu.NewMenu.ID.ToPrefix()}{Names.Default.NewShortcut}",
				Text = Page.Translate(Dictionary.Default.NewShortcut),
				Icon = Ext.Net.Icon.PluginAdd
			};
			newShortcutMenuItem.DirectEvents.Click.Event += ContextMenuNewShortcutMenuItemClick_Event;
			ContextMenu.NewMenu.Add(newShortcutMenuItem);

			var sendToDesktopMenuItem = new MenuItem
			{
				ID = $@"{ContextMenu.SendToMenu.ID.ToPrefix()}{Names.Default.DesktopMenuItem}",
				Text = Page.Translate($@"{Dictionary.Default.Desktop} ({Dictionary.Default.CreateShortCut})"),
				Icon = Ext.Net.Icon.ApplicationAdd
			};
			sendToDesktopMenuItem.DirectEvents.Click.Event += ContextMenuSendToDesktopMenuItemClick_Event;

			ContextMenu.SendToMenu.Add(sendToDesktopMenuItem);

			IsInitialized = true;
		}

		#region ExplorerGridPanel

		/// <summary>
		///     Get or Set ExplorerGridPanel.
		/// </summary>
		private ExplorerGridPanel ExplorerGridPanel =>
			ViewState.GetValue<ExplorerGridPanel>(this.GetFrameName(), delegate
			{
				var explorePanel = new ExplorerGridPanel {ID = $@"{ID.ToPrefix()}{this.GetFrameName()}"};

				explorePanel.Select += ExplorerGridPanel_Select;
				explorePanel.Deselect += ExplorerGridPanel_Deselect;

				return explorePanel;
			});

		private void ExplorerGridPanel_Select(object sender,
			ExplorerGridPanel.ExplorerGridPanelSelectEventArgs e)
		{
			ContextMenu.SelectedItemsIds = SelectedItemsIds;
		}

		private void ExplorerGridPanel_Deselect(object sender,
			ExplorerGridPanel.ExplorerGridPanelDeselectEventArgs e)
		{
			ContextMenu.SelectedItemsIds = SelectedItemsIds;
		}

		#endregion

		#region ExplorerDataView

		/// <summary>
		///     Get or Set ExplorerDataView.
		/// </summary>
		private ExplorerDataView ExplorerDataView => ViewState.GetValue<ExplorerDataView>(this.GetFrameName(), delegate
		{
			var explorePanel = new ExplorerDataView {ID = $@"{ID}ExplorerDataView"};

			explorePanel.Select += ExplorerDataView_Select;
			explorePanel.Deselect += ExplorerDataView_Deselect;

			return explorePanel;
		});

		private void ExplorerDataView_Select(object sender,
			ExplorerDataView.ExplorerDataViewSelectEventArgs e)
		{
			ContextMenu.SelectedItemsIds = SelectedItemsIds;
		}

		private void ExplorerDataView_Deselect(object sender,
			ExplorerDataView.ExplorerDataViewDeselectEventArgs e)
		{
			ContextMenu.SelectedItemsIds = SelectedItemsIds;
		}

		#endregion
	}
}