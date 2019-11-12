#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ExplorerGridPanel runat=\"server\"></{0}:ExplorerGridPanel>")]
	public sealed class ExplorerGridPanel : GridPanel
	{
		public ExplorerGridPanel()
		{
			Init += ExplorerGridPanel_Init;
		}

		public ExplorerGridPanel(Config config) : this()
		{
			Apply(config);
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
			get => ViewState.GetValue<Guid>(this.GetFrameName(), Guid.Empty);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get selected items IDs.
		/// </summary>
		public List<Guid> SelectedItemsIDs
		{
			get
			{
				var selectedItemsIds = new List<Guid>();

				if (SelectionModel.Primary != null)
					selectedItemsIds.AddRange(
						((RowSelectionModel) SelectionModel.Primary).SelectedRows
						.Select(row =>
							new Guid(row
								.RecordID)));

				return selectedItemsIds;
			}
		}

		private void AddColumns()
		{
			var columnId = new Column {ID = $@"{ID}ColumnId", Text = "Code", DataIndex = "Id", Visible = false};
			ColumnModel.Columns.Add(columnId);

			var templateColumnIcon = new TemplateColumn
			{
				ID = $@"{ID.ToPrefix()}TemplateColumnIcon",
				Width = 22,
				DataIndex = "IconCls",
				TemplateString =
					"<img style=\"width: 16px; height: 16px; \" src=\"{IconCls}\" />",
				MaxWidth = 22,
				MinWidth = 22
			};
			ColumnModel.Columns.Add(templateColumnIcon);

			var columnName = new Column
				{ID = $@"{ID.ToPrefix()}ColumnName", Text = Dictionary.Default.Name, DataIndex = "Title", Flex = 15};

			var txt = new TextField();

			txt.DirectEvents.Change.Event += Change_Event;

			columnName.Editor.Add(txt);
			ColumnModel.Columns.Add(columnName);

			var columnEntityType = new Column
				{ID = $@"{ID.ToPrefix()}ColumnEntityType", Text = Dictionary.Default.Type, DataIndex = "EntityType"};
			ColumnModel.Columns.Add(columnEntityType);

			var dateColumnCreationDate =
				new DateColumn
				{
					ID = $@"{ID.ToPrefix()}DateColumnCreationDate",
					Text = Dictionary.Default.CreationDate,
					DataIndex = "CreationDate",
					Format = "yyyy-MM-dd"
				};
			ColumnModel.Columns.Add(dateColumnCreationDate);

			var dateColumnDateModified =
				new DateColumn
				{
					ID = $@"{ID.ToPrefix()}DateColumnDateModified",
					Text = Dictionary.Default.DateModified,
					DataIndex = "DateModified",
					Format = "yyyy-MM-dd"
				};
			ColumnModel.Columns.Add(dateColumnDateModified);
		}

		private void Change_Event(object sender,
			DirectEventArgs e)
		{
		}

		private void CreateStore()
		{
			var model = new Model
			{
				IDProperty = "Id"
			};

			model.Fields.Add(new ModelField {Name = "Id", Type = ModelFieldType.Auto});
			model.Fields.Add(new ModelField {Name = "Icon", Type = ModelFieldType.String});
			model.Fields.Add(new ModelField {Name = "Title", Type = ModelFieldType.String});
			model.Fields.Add(new ModelField {Name = "EntityType", Type = ModelFieldType.String});
			model.Fields.Add(new ModelField {Name = "CreationDate", Type = ModelFieldType.Date});
			model.Fields.Add(new ModelField {Name = "DateModified", Type = ModelFieldType.Date});
			model.Fields.Add(new ModelField {Name = "Description", Type = ModelFieldType.String});

			var store = new Store();

			store.Model.Add(model);

			Store.Add(store);
		}

		[DirectMethod]
		public void Edit(string id,
			string field,
			string oldValue,
			string newValue)
		{
			const string message =
				@"<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

			// Send Message...
			Ext.Net.X.Msg.Notify(new NotificationConfig
			{
				Title = "Edit Record #" + id,
				Html = string.Format(message, id, field, oldValue, newValue),
				Width = 250,
				Height = 150
			}).Show();

			GetStore().GetById(id).Commit();
		}

		private void Edit_Event(object sender,
			DirectEventArgs e)
		{
			if (SelectionModel.Primary is RowSelectionModel rowSelectionModel)
				Ext.Net.X.Msg.Alert(sender.GetType().ToString(),
					rowSelectionModel.SelectedRows[0].RecordID).Show();
		}

		private void ExplorerGridPanel_Init(object sender,
			EventArgs e)
		{
			Border = false;
			CreateStore();
			AddColumns();

			var rowSelectionModel = new RowSelectionModel {Mode = SelectionMode.Multi};
			rowSelectionModel.DirectEvents.Select.Buffer = 250;
			rowSelectionModel.DirectEvents.Select.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			rowSelectionModel.DirectEvents.Select.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItems",
				Value = "Ext.encode(#{" + ID +
				        "}.getRowsValues({selectedOnly:true}))",
				Mode = ParameterMode.Raw
			});
			rowSelectionModel.DirectEvents.Select.Event += Select_Event;

			rowSelectionModel.DirectEvents.Deselect.Buffer = 250;
			rowSelectionModel.DirectEvents.Deselect.ExtraParams.Add(new Parameter
			{
				Name = "DeselectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			rowSelectionModel.DirectEvents.Deselect.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItems",
				Value = "Ext.encode(#{" + ID +
				        "}.getRowsValues({selectedOnly:true}))",
				Mode = ParameterMode.Raw
			});
			rowSelectionModel.DirectEvents.Deselect.Event += Deselect_Event;

			SelectionModel.Add(rowSelectionModel);
			DirectEvents.RowDblClick.EventMask.ShowMask = true;
			DirectEvents.RowDblClick.EventMask.Target = MaskTarget.CustomTarget;
			DirectEvents.RowDblClick.EventMask.CustomTarget =
				$@"#{typeof(ContentPanel).Name}";
			DirectEvents.RowDblClick.EventMask.Msg = Dictionary.Default.Loading;
			DirectEvents.RowDblClick.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.RowDblClick.Event += RowDblClick_Event;

			//Page.ExtResourceManager.AddScript(@"var edit = function (editor, e) {
			//*
			//    e is an edit event with the following properties:

			//        grid - The grid
			//        record - The record that was edited
			//        field - The field name that was edited
			//        value - The value being set
			//        originalValue - The original value for the field, before the edit.
			//        row - The grid table row
			//        column - The grid Column defining the column that was edited.
			//        rowIdx - The row index that was edited
			//        colIdx - The column index that was edited
			//*/

			//    // Call DirectMethod
			//    if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue))))
			//    {
			//        App.direct." + ClientID + @".Edit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
			//    }
			//};");

			var plugin = new CellEditing();

			plugin.DirectEvents.Edit.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = $@"#{{{ID}}}.selModel.getSelection[0].get('ID')",
				Mode = ParameterMode.Raw
			});
			plugin.DirectEvents.Edit.Event += Edit_Event;

			Plugins.Add(plugin);
		}

		#region ExplorerGridPanelDeselect event

		/// <summary>
		///     Deselect event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Deselect_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerGridPanelDeselectEventArgs
			{
				DeselectedItemId = new Guid(e.ExtraParams["DeselectedItemId"])
			};

			OnExplorerGridPanelDeselect(args);
		}

		/// <summary>
		///     OnExplorerGridPanel Deselect
		/// </summary>
		/// <param name="e">ExplorerGridPanel Deselect event args.</param>
		private void OnExplorerGridPanelDeselect(ExplorerGridPanelDeselectEventArgs e)
		{
			var handler = Deselect;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerGridPanel Deselect event handler.
		/// </summary>
		public event EventHandler<ExplorerGridPanelDeselectEventArgs> Deselect;

		/// <summary>
		///     ExplorerGridPanel Deselect event args.
		/// </summary>
		public class ExplorerGridPanelDeselectEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid DeselectedItemId { get; set; }
		}

		#endregion

		#region ExplorerGridPanelSelect event

		/// <summary>
		///     Select event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Select_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerGridPanelSelectEventArgs
			{
				SelectedItemId = new Guid(e.ExtraParams["SelectedItemId"])
			};

			OnExplorerGridPanelSelect(args);
		}

		/// <summary>
		///     OnExplorerGridPanel Select
		/// </summary>
		/// <param name="e">ExplorerGridPanel Select event args.</param>
		private void OnExplorerGridPanelSelect(ExplorerGridPanelSelectEventArgs e)
		{
			var handler = Select;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerGridPanel Select event handler.
		/// </summary>
		public event EventHandler<ExplorerGridPanelSelectEventArgs> Select;

		/// <summary>
		///     ExplorerGridPanel Deselect event args.
		/// </summary>
		public class ExplorerGridPanelSelectEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid SelectedItemId { get; set; }
		}

		#endregion

		#region ExplorerGridPanelRowDblClick event

		/// <summary>
		///     RowDblClick event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void RowDblClick_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerGridPanelRowDblClickEventArgs
			{
				SelectedItemId = new Guid(e.ExtraParams["SelectedItemId"])
			};

			OnExplorerGridPanelRowDblClick(args);
		}

		/// <summary>
		///     OnExplorerGridPanel RowDblClick
		/// </summary>
		/// <param name="e">ExplorerGridPanel RowDblClick event args.</param>
		private void OnExplorerGridPanelRowDblClick(ExplorerGridPanelRowDblClickEventArgs e)
		{
			var handler = RowDblClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerGridPanel RowDblClick event handler.
		/// </summary>
		public event EventHandler<ExplorerGridPanelRowDblClickEventArgs> RowDblClick;

		/// <summary>
		///     ExplorerGridPanel RowDblClick event args.
		/// </summary>
		public class ExplorerGridPanelRowDblClickEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid SelectedItemId { get; set; }
		}

		#endregion
	}
}