#region Using Directives

using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:DataViewEntities runat=\"server\"></{0}:DataViewEntities>")]
	public class DataViewEntities : DataView
	{
		public DataViewEntities()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			Tpl = new XTemplate
			{
				ID = "XTemplateGroupsAndUsers",
				Html = "<tpl for=\".\">" +
				       "<div class=\"item\" style=\"background: ThreeDFace;\">" +
				       "<tpl if=\"!Ext.isIE6\">" +
				       "<table style='width:100%;'>" +
				       "<tr>" +
				       "<td>" +
				       "<img style=\"width:16px;height:16px;\" src=\"{IconCls}\" />" +
				       "</td>" +
				       "<td>" +
				       "<span style=\"width:100%;\">{Title}</span>" +
				       "</td>" +
				       "</tr>" +
				       "</table>" +
				       "</tpl>" +
				       "<tpl if=\"Ext.isIE6\">" +
				       "<table style='width:100%;'>" +
				       "<tr>" +
				       "<td>" +
				       "<div style=\"position:relative;width:16px;height:16px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\"{IconCls}\") />" +
				       "</td>" +
				       "<td>" +
				       "<span style=\"width:100%;\">{Title}</span>" +
				       "</td>" +
				       "</tr>" +
				       "</table>" +
				       "</tpl>" +
				       "</div>" +
				       "</tpl>"
			};
			ItemSelector = "div.item";
			Border = true;
			BorderWidth = Unit.Pixel(1);
			Plugins.Add(new DataViewAnimated());

			var store = new Store();
			var model = new Model();

			model.Fields.Add(new ModelField("Title", ModelFieldType.String));
			model.Fields.Add(new ModelField("IconCls", ModelFieldType.String));
			store.Model.Add(model);

			Store.Add(store);
		}
	}
}