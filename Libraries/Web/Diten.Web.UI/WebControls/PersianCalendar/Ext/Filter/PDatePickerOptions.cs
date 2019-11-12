#region Using Directives

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Xml.Serialization;
using Ext.Net;
using Newtonsoft.Json;

#endregion

namespace Diten.Web.UI.WebControls
{
	[ToolboxItem(false)]
	[Description("")]
	[Meta]
	public partial class PDatePickerOptions : PDatePicker
	{
		/// <summary />
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override bool AutoPostBack
		{
			get => base.AutoPostBack;
			set => base.AutoPostBack = value;
		}

		/// <summary />
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("")]
		public override bool CausesValidation
		{
			get => base.CausesValidation;
			set => base.CausesValidation = value;
		}

		/// <summary />
		[ConfigOption(JsonMode.Ignore)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		protected override string ConfigIDProxy => base.ConfigIDProxy;

		/// <summary />
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[JsonIgnore]
		public override ConfigOptionsCollection ConfigOptions
		{
			get
			{
				var configOptions = base.ConfigOptions;
				configOptions.Add("configIDProxy",
					new ConfigOption("configIDProxy", new SerializationOptions(JsonMode.Ignore), null,
						ConfigIDProxy));
				configOptions.Add("iD", new ConfigOption("iD", new SerializationOptions(JsonMode.Ignore), null, ID));
				configOptions.Add("renderTo",
					new ConfigOption("renderTo", new SerializationOptions(JsonMode.Ignore), null,
						RenderTo));
				configOptions.Add("renderToProxy",
					new ConfigOption("renderToProxy", new SerializationOptions(JsonMode.Ignore), null,
						RenderToProxy));

				return configOptions;
			}
		}

		/// <summary />
		[ConfigOption(JsonMode.Ignore)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string ID
		{
			get => base.ID;

			set => base.ID = value;
		}

		/// <summary />
		[Description("")]
		[Category("0. About")]
		public override string InstanceOf => "";

		/// <summary />
		[ConfigOption(JsonMode.Ignore)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string RenderTo => base.RenderTo;

		/// <summary />
		[ConfigOption(JsonMode.Ignore)]
		protected override string RenderToProxy => "";

		/// <summary />
		[Description("")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override DateTime SelectedDate
		{
			get => base.SelectedDate;
			set => base.SelectedDate = value;
		}

		/// <summary />
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string ValidationGroup
		{
			get => base.ValidationGroup;
			set => base.ValidationGroup = value;
		}

		/// <summary />
		[Description("")]
		[Category("0. About")]
		public override string XType => "";

		/// <summary />
		[Description("")]
		protected override void OnPreRender(EventArgs e)
		{
		}

		/// <summary />
		[Description("")]
		protected override void Render(HtmlTextWriter writer)
		{
		}
	}
}