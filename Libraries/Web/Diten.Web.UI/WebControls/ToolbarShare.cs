#region Using Directives

using System;
using System.Web.UI;
using Diten.Data;
using Ext.Net;

#endregion

// ReSharper disable InconsistentNaming

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ToolbarShare runat=\"server\"></{0}:ToolbarShare>")]
	public class ToolbarShare : Toolbar
	{
		public ToolbarShare()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			InitButtonGroupSend();
			InitButtonGroupShareWith();

			Items.Add(ButtonGroupSend);
			Items.Add(ButtonGroupShareWith);
		}

		#region ButtonGroupSend

		private ButtonGroup ButtonGroupSend;
		public Button ButtonShare;
		public Button ButtonEmail;
		public Button ButtonZip;
		public Button ButtonBurnToDisc;
		public Button ButtonPrint;
		public Button ButtonFax;

		private void InitButtonGroupSend()
		{
			ButtonGroupSend = new ButtonGroup
			{
				ID = "ButtonGroupSend",
				Title = @"Send",
				Columns = 4
			};

			ButtonShare = new Button
			{
				ID = "ButtonShare",
				Text = @"Share",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.Share,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Choose an app to share the selected files."
			};
			ButtonGroupSend.Items.Add(ButtonShare);

			ButtonEmail = new Button
			{
				ID = "ButtonEmail",
				Text = @"Email",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.Email,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip =
					@"Send the selected items in an email (files are sent as attachments and folders as links)."
			};
			ButtonGroupSend.Items.Add(ButtonEmail);

			ButtonZip = new Button
			{
				ID = "ButtonZip",
				Text = @"Zip",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.PageWhiteZip,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Create a compressed (zipped) folder that contains the selected items."
			};
			ButtonGroupSend.Items.Add(ButtonZip);

			ButtonBurnToDisc = new Button
			{
				ID = "ButtonBurnToDisc",
				Text = @"Burn to disk",
				Icon = Ext.Net.Icon.CdBurn,
				ToolTip = @"Create a compressed (zipped) folder that contains the selected items."
			};
			ButtonGroupSend.Items.Add(ButtonBurnToDisc);

			ButtonPrint = new Button
			{
				ID = "ButtonPrint",
				Text = @"Print",
				Icon = Ext.Net.Icon.Printer,
				ToolTip = @"Send the selected files to the printer."
			};
			ButtonGroupSend.Items.Add(ButtonPrint);

			ButtonFax = new Button
			{
				ID = "ButtonFax",
				Text = @"Fax",
				DTIcon = Icons.PortableComputer,
				ToolTip = @"Fax the selected items."
			};
			ButtonGroupSend.Items.Add(ButtonFax);
		}

		#endregion

		#region ButtonGroupShareWith

		private ButtonGroup ButtonGroupShareWith;
		public GridPanel GridPanelGroupsAndUsers;
		public Button ButtonRemoveAccess;
		public Button ButtonAdvancedSecurity;

		private void InitButtonGroupShareWith()
		{
			ButtonGroupShareWith = new ButtonGroup
			{
				ID = "ButtonGroupShareWith",
				Title = @"Share with",
				ShrinkWrap = ShrinkWrap.Both,
				Columns = 3
			};

			#region GridPanelGroupsAndUsers

			GridPanelGroupsAndUsers = new GridPanel
			{
				Width = 200,
				Height = 66,
				Scrollable = ScrollableOption.Vertical,
				Scroll = ScrollMode.Vertical
			};

			var GridPanelGroupsAndUsersStore = new Store
			{
				ID = "GridPanelGroupsAndUsersStore"
			};
			var GridPanelGroupsAndUsersStoreModel = new Model
			{
				IDProperty = "Id"
			};

			GridPanelGroupsAndUsersStoreModel.Fields.Add(new ModelField {Name = "Id", Type = ModelFieldType.Auto});
			GridPanelGroupsAndUsersStoreModel.Fields.Add(new ModelField {Name = "Icon", Type = ModelFieldType.String});
			GridPanelGroupsAndUsersStoreModel.Fields.Add(new ModelField {Name = "Title", Type = ModelFieldType.String});
			GridPanelGroupsAndUsersStoreModel.Fields.Add(new ModelField
			{
				Name = "EntityType",
				Type = ModelFieldType.String
			});

			GridPanelGroupsAndUsersStore.Model.Add(GridPanelGroupsAndUsersStoreModel);
			GridPanelGroupsAndUsers.Store.Add(GridPanelGroupsAndUsersStore);

			var columnId = new Column {ID = @"GridPanelGroupsAndUsersColumnId", DataIndex = "Id", Visible = false};
			GridPanelGroupsAndUsers.ColumnModel.Columns.Add(columnId);

			var templateColumn = new TemplateColumn
			{
				ID = "GridPanelGroupsAndUsersTemplateColumn",
				DataIndex = "Icon",
				Flex = 2,
				TemplateString = "<table style='width:100%;'>" +
				                 "<tr>" +
				                 "<td>" +
				                 "<img style=\"width:16px;height:16px;\" src=\"{IconCls}\" />" +
				                 "</td>" +
				                 "<td>" +
				                 "<span style=\"width:100%;\">{Title}</span>" +
				                 "</td>" +
				                 "</tr>" +
				                 "</table>"
			};

			GridPanelGroupsAndUsers.ColumnModel.Columns.Add(templateColumn);

			var gridPanelGroupsAndUsersRowSelectionModel = new RowSelectionModel {Mode = SelectionMode.Single};
			gridPanelGroupsAndUsersRowSelectionModel.DirectEvents.Select.Buffer = 250;
			gridPanelGroupsAndUsersRowSelectionModel.DirectEvents.Select.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			gridPanelGroupsAndUsersRowSelectionModel.DirectEvents.Select.Event +=
				gridPanelGroupsAndUsersRowSelectionModelSelect_Event;


			GridPanelGroupsAndUsers.SelectionModel.Add(gridPanelGroupsAndUsersRowSelectionModel);

			#endregion

			var dataViewEntities = new DataViewEntities
			{
				ID = "DataViewGroupsAndUsers",
				Width = 170,
				Height = 67,
				Scrollable = ScrollableOption.Vertical
			};

			dataViewEntities.Store.Primary.DataSource = Entity.GetData();

			ButtonGroupShareWith.Items.Add(dataViewEntities);

			ButtonRemoveAccess = new Button
			{
				ID = "ButtonRemoveAccess",
				Text = @"Remove Access",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.TextIndentRemove,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Stop sharing the selected items.",
				ShrinkWrap = ShrinkWrap.Both
			};
			ButtonGroupShareWith.Items.Add(ButtonRemoveAccess);

			ButtonAdvancedSecurity = new Button
			{
				ID = "ButtonAdvancedSecurity",
				Text = @"Advanced security",
				Scale = ButtonScale.Large,
				Icon = Ext.Net.Icon.Server,
				IconAlign = IconAlign.Top,
				RowSpan = 3,
				ToolTip = @"Manually set up advanced sharing settings for the selected item."
			};
			ButtonGroupShareWith.Items.Add(ButtonAdvancedSecurity);
		}

		private void gridPanelGroupsAndUsersRowSelectionModelSelect_Event(object sender,
			DirectEventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}