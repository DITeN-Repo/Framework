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
	public partial class PDateFilter : DateFilter
	{
		private PDatePickerOptions _pickerOptions;

		/// <summary />
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[JsonIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ConfigOptionsCollection ConfigOptions
		{
			get
			{
				var configOptions = base.ConfigOptions;
				configOptions.Add("type",
					new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), null, Type));
				configOptions.Add("beforeText", new ConfigOption("beforeText", null, "Before", BeforeText));
				configOptions.Add("afterText", new ConfigOption("afterText", null, "After", AfterText));
				configOptions.Add("onText", new ConfigOption("onText", null, "On", OnText));
				configOptions.Add("formatProxy",
					new ConfigOption("formatProxy", new SerializationOptions("dateFormat"), "",
						FormatProxy));
				configOptions.Add("submitFormatProxy",
					new ConfigOption("submitFormatProxy", new SerializationOptions("submitFormat"), "",
						SubmitFormatProxy));
				configOptions.Add("datePickerOptions",
					new ConfigOption("datePickerOptions",
						new SerializationOptions("pickerOpts", JsonMode.Object), null,
						PDatePickerOptions));
				configOptions.Add("maxDate",
					new ConfigOption("maxDate",
						new SerializationOptions(typeof(CtorDateTimeJsonConverter)),
						new DateTime(9999, 12, 31), MaxDate));
				configOptions.Add("minDate",
					new ConfigOption("minDate",
						new SerializationOptions(typeof(CtorDateTimeJsonConverter)),
						new DateTime(1, 1, 1), MinDate));
				configOptions.Add("valueProxy",
					new ConfigOption("valueProxy", new SerializationOptions("value", JsonMode.Raw), "",
						ValueProxy));

				return configOptions;
			}
		}

		[Description("")]
		[Meta]
		[ConfigOption("pickerOpts", JsonMode.Object)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[NotifyParentProperty(true)]
		public PDatePickerOptions PDatePickerOptions
		{
			get
			{
				if (_pickerOptions == null)
					_pickerOptions = new PDatePickerOptions();

				return _pickerOptions;
			}
		}
	}
}