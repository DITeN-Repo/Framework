#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

#endregion

[assembly: WebResource("Diten.Web.UI.WebControls.DateColumn.js", "text/javascript")]
[assembly: WebResource("Diten.Web.UI.Scripts.PDate.js", "text/javascript")]

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:DateColumn runat=\"server\"></{0}:DateColumn>")]
	public class DateColumn : Ext.Net.DateColumn
	{
		public DateColumn()
		{
		}

		public DateColumn(Config config)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));
			Apply(config);
		}

		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString(); //"Ext.grid.column.PDate";

		/// <summary>
		/// </summary>
		[Description("")]
		protected override List<ResourceItem> Resources
		{
			get
			{
				var baseList = base.Resources;
				var type = GetType();
				var path = $@"{type}.js";

				baseList.Capacity += 1;

				baseList.Add(new ClientScriptItem(type, path, Page.ClientScript.GetWebResourceUrl(type, path)));

				path = @"Diten.Web.UI.Scripts.PDate.js";
				baseList.Add(new ClientScriptItem(type, path, Page.ClientScript.GetWebResourceUrl(type, path)));

				return baseList;
			}
		}

		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string XType => "datecolumn";

		public new Builder ToBuilder()
		{
			return ExBuilderFactory.DateColumn(new BuilderFactory(), this);
		}

		public new class Builder : Builder<DateColumn, Builder>
		{
			public Builder() : base(new DateColumn())
			{
			}

			public Builder(DateColumn component) : base(component)
			{
			}

			public Builder(Config config) : base(new DateColumn(config))
			{
			}
		}

		public new class Config : Ext.Net.DateColumn.Config
		{
			public static implicit operator Builder(Config config)
			{
				return new Builder(config);
			}
		}
	}
}