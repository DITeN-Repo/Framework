#region Using Directives

using System.Collections.Generic;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PGridFilters : GridFilters
	{
		protected override List<ResourceItem> Resources
		{
			get
			{
				var baseList = base.Resources;
				baseList.Capacity += 1;
				baseList.RemoveAt(baseList.Count - 1);
				baseList.Add(new ClientScriptItem(typeof(PGridFilters),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.grid.gridfilters.GridFilters.js",
					"/PDate/grid/gridfilters/GridFilters.js"));

				return baseList;
			}
		}
	}
}