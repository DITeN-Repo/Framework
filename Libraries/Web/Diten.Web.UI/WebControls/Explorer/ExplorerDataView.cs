#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Ext.Net;
using Parameter = Ext.Net.Parameter;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ExplorerDataView runat=\"server\"></{0}:ExplorerDataView>")]
	public sealed class ExplorerDataView : DataView
	{
		public ExplorerDataView()
		{
			Init += ExplorerDataView_Init;
		}

		public new Page Page => new Page();

		/// <summary>
		///     Get or Set ParentId.
		/// </summary>
		public Guid ParentId
		{
			get => ViewState.GetValue<Guid>(this.GetFrameName(), Guid.Empty);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get or Set RootId.
		/// </summary>
		public Guid RootId
		{
			get => ViewState.GetValue<Guid>(this.GetFrameName(), Guid.NewGuid());
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get selected items IDs.
		/// </summary>
		public List<Guid> SelectedItemsIds
		{
			get
			{
				var selectedItemsIds = new List<Guid>();

				selectedItemsIds.AddRange(SelectedRows.Select(row => new Guid(row.RecordID)));

				return selectedItemsIds;
			}
		}

		private void CreateStore()
		{
			var model = new Model
			{
				IDProperty = "Id"
			};

			model.Fields.Add(new ModelField {Name = "Id", Type = ModelFieldType.Auto});
			model.Fields.Add(new ModelField {Name = "IconCls", Type = ModelFieldType.String});
			model.Fields.Add(new ModelField {Name = "Title", Type = ModelFieldType.String});
			model.Fields.Add(new ModelField {Name = "CreationDate", Type = ModelFieldType.Date});
			model.Fields.Add(new ModelField {Name = "DateModified", Type = ModelFieldType.Date});
			model.Fields.Add(new ModelField {Name = "Description", Type = ModelFieldType.String});

			var store = new Store {ID = $@"{ID}Store"};
			store.Model.Add(model);
			Store.Add(store);
		}

		private void ExplorerDataView_Init(object sender,
			EventArgs e)
		{
			Border = false;
			Scrollable = ScrollableOption.Vertical;
			ItemSelector = "div.thumb-wrap";
			OverItemCls = "x-view-over";
			Cls = "img-chooser-view";
			MultiSelect = true;
			var toolTip = new ToolTip
			{
				Title = @"{Title}",
				Delegate = ".node",
				TrackMouse = true,
				AutoHide = true,
				Content = Convert.ToITemplate(
					"<div id='content-tip'>" +
					"<ul>" +
					"<li><b>" + Page.Translate("Creation Date") +
					":</b> {CreationDate}</li>" +
					"<li><b>" + Page.Translate("Date Modified") +
					":</b> {DateModified}</li>" +
					"</ul>" +
					"{Description}" +
					"</div>")
			};
			toolTip.Listeners.Show.Handler =
				"var index = #{" + ID + "}.indexOf(this.triggerElement); this.setTitle(#{" + ID +
				"Store}.getAt(index).get('Title'))";
			ToolTips.Add(toolTip);
			Tpl = new XTemplate
			{
				Html = "<tpl for='.'>" +
				       "<div class='thumb-wrap'>" +
				       "<div class='thumb'>" +
				       "<tpl if='!Ext.isIE6'>" +
				       "<img src = '{IconCls}'/>" +
				       "</tpl>" +
				       "<tpl if='Ext.isIE6'>" +
				       "<div style='width:74px;height:74px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='{IconCls}')'></div>" +
				       "</tpl>" +
				       "</div>" +
				       "<span>{Title}</span>" +
				       "<span style='display:none;'>{Id}</span>" +
				       "</div>" +
				       "</tpl>"
			};

			CreateStore();

			DirectEvents.Select.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Select.Event += Select_Event;
			DirectEvents.Deselect.ExtraParams.Add(new Parameter
			{
				Name = "DeselectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Deselect.Event += Deselect_Event;

			DirectEvents.ItemClick.Buffer = 250;
			DirectEvents.ItemClick.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.ItemClick.Event += ItemClick_Event;

			DirectEvents.ItemDblClick.EventMask.ShowMask = true;
			DirectEvents.ItemDblClick.EventMask.Target = MaskTarget.CustomTarget;
			DirectEvents.ItemDblClick.EventMask.CustomTarget =
				$@"#{typeof(ContentPanel).ToString().Split(".".ToCharArray()).Last()}";
			DirectEvents.ItemDblClick.EventMask.Msg = @"بارگذاری";
			DirectEvents.ItemDblClick.ExtraParams.Add(new Parameter
			{
				Name = "SelectedItemId",
				Value = "record.getId()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.ItemDblClick.Event += ItemDblClick_Event;

			DirectEvents.Resize.ExtraParams.Add(new Parameter
			{
				Name = "Width",
				Value = "this.getWidth()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Resize.ExtraParams.Add(new Parameter
			{
				Name = "Height",
				Value = "this.getHeight()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Resize.Event += Resize_Event;
		}

		#region ExplorerDataViewResize event

		/// <summary>
		///     Resize event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Resize_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerDataViewResizeEventArgs
			{
				Width = Unit.Parse(e.ExtraParams["Width"]),
				Height = Unit.Parse(e.ExtraParams["Height"])
			};

			OnExplorerDataViewResize(args);
		}

		/// <summary>
		///     On window resize
		/// </summary>
		/// <param name="e">Window resize event args.</param>
		private void OnExplorerDataViewResize(ExplorerDataViewResizeEventArgs e)
		{
			var handler = Resize;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     Window resize event handler.
		/// </summary>
		public event EventHandler<ExplorerDataViewResizeEventArgs> Resize;

		/// <summary>
		///     Window resize event args.
		/// </summary>
		public class ExplorerDataViewResizeEventArgs : EventArgs
		{
			/// <summary>
			///     Height of window.
			/// </summary>
			public Unit Height { get; set; }

			/// <summary>
			///     Width of window.
			/// </summary>
			public Unit Width { get; set; }
		}

		#endregion

		#region ExplorerDataViewItemClick event

		/// <summary>
		///     ItemClick event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void ItemClick_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerDataViewItemClickEventArgs
			{
				SelectedItemId = new Guid(e.ExtraParams["SelectedItemId"])
			};

			OnExplorerDataViewItemClick(args);
		}

		/// <summary>
		///     OnExplorerDataView ItemClick
		/// </summary>
		/// <param name="e">ExplorerDataView ItemClick event args.</param>
		private void OnExplorerDataViewItemClick(ExplorerDataViewItemClickEventArgs e)
		{
			var handler = ItemClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerDataView ItemClick event handler.
		/// </summary>
		public event EventHandler<ExplorerDataViewItemClickEventArgs> ItemClick;

		/// <summary>
		///     ExplorerDataView ItemClick event args.
		/// </summary>
		public class ExplorerDataViewItemClickEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid SelectedItemId { get; set; }
		}

		#endregion

		#region ExplorerDataViewItemDblClick event

		/// <summary>
		///     ItemDblClick event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void ItemDblClick_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerDataViewItemDblClickEventArgs
			{
				SelectedItemId = new Guid(e.ExtraParams["SelectedItemId"])
			};

			OnExplorerDataViewItemDblClick(args);
		}

		/// <summary>
		///     OnExplorerDataView ItemDblClick
		/// </summary>
		/// <param name="e">ExplorerDataView ItemDblClick event args.</param>
		private void OnExplorerDataViewItemDblClick(ExplorerDataViewItemDblClickEventArgs e)
		{
			var handler = ItemDblClick;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerDataView ItemDblClick event handler.
		/// </summary>
		public event EventHandler<ExplorerDataViewItemDblClickEventArgs> ItemDblClick;

		/// <summary>
		///     ExplorerDataView ItemDblClick event args.
		/// </summary>
		public class ExplorerDataViewItemDblClickEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid SelectedItemId { get; set; }
		}

		#endregion

		#region ExplorerDataViewDeselect event

		/// <summary>
		///     Deselect event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Deselect_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerDataViewDeselectEventArgs
			{
				DeselectedItemId = new Guid(e.ExtraParams["DeselectedItemId"])
			};

			OnExplorerDataViewDeselect(args);
		}

		/// <summary>
		///     OnExplorerDataView Deselect
		/// </summary>
		/// <param name="e">ExplorerDataView Deselect event args.</param>
		private void OnExplorerDataViewDeselect(ExplorerDataViewDeselectEventArgs e)
		{
			var handler = Deselect;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerDataView Deselect event handler.
		/// </summary>
		public new event EventHandler<ExplorerDataViewDeselectEventArgs> Deselect;

		/// <summary>
		///     ExplorerDataView Deselect event args.
		/// </summary>
		public class ExplorerDataViewDeselectEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid DeselectedItemId { get; set; }
		}

		#endregion

		#region ExplorerDataViewSelect event

		/// <summary>
		///     Select event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Select_Event(object sender,
			DirectEventArgs e)
		{
			var args = new ExplorerDataViewSelectEventArgs
			{
				SelectedItemId = new Guid(e.ExtraParams["SelectedItemId"])
			};

			OnExplorerDataViewSelect(args);
		}

		/// <summary>
		///     OnExplorerDataView Select
		/// </summary>
		/// <param name="e">ExplorerDataView Select event args.</param>
		private void OnExplorerDataViewSelect(ExplorerDataViewSelectEventArgs e)
		{
			var handler = Select;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     ExplorerDataView Select event handler.
		/// </summary>
		public new event EventHandler<ExplorerDataViewSelectEventArgs> Select;

		/// <summary>
		///     ExplorerDataView Deselect event args.
		/// </summary>
		public class ExplorerDataViewSelectEventArgs : EventArgs
		{
			/// <summary>
			///     Id of selected item..
			/// </summary>
			public Guid SelectedItemId { get; set; }
		}

		#endregion
	}
}