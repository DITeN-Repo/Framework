#region Using Directives

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:PersianDateField runat=\"server\"></{0}:PersianDateField>")]
	public partial class PDateField : DateField
	{
		private bool _overridedFormat;

		/// <summary>
		///     The default date format string which can be overriden for localization support. The format must be valid according
		///     to Date.parseDate (defaults to 'Y/m/d').
		/// </summary>
		public override string Format
		{
			get
			{
				if (!_overridedFormat)
					base.Format = "yyyy/MM/dd";

				return base.Format;
			}
			set
			{
				_overridedFormat = true;
				base.Format = value;
			}
		}

		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => "Ext.form.field.PDate";

		/// <summary>
		/// </summary>
		[Description("")]
		protected override List<ResourceItem> Resources
		{
			get
			{
				var baseList = base.Resources;
				baseList.Capacity += 4;

				baseList.Add(new ClientScriptItem(typeof(PDateField),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.pdate.js",
					"/PDate/pdate.js"));
				baseList.Add(new ClientScriptItem(typeof(PDateField),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.picker.PMonth.js",
					"/PDate/picker/PMonth.js"));
				baseList.Add(new ClientScriptItem(typeof(PDateField),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.picker.PDate.js",
					"/PDate/picker/PDate.js"));
				baseList.Add(new ClientScriptItem(typeof(PDateField),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.form.field.PDate.js",
					"/PDate/form/field/PDate.js"));

				return baseList;
			}
		}

		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string XType => "pdatefield";
	}
}