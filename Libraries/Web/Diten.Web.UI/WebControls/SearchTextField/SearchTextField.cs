#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Xml.Serialization;
using Ext.Net;
using Newtonsoft.Json;

#endregion

[assembly: WebResource("Diten.Web.UI.WebControls.SearchTextField.js", "text/javascript")]
[assembly: WebResource("Diten.Web.UI.WebControls.SearchTextField.css", "text/css")]

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:SearchTextField runat=\"server\"></{0}:SearchTextField>")]
	public class SearchTextField : TextField
	{
		#region Constants

		private const string SearchCls = "SearchTextField";

		#endregion

		#region Events

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			_isBaseInitialized = true;

			SetJavascriptEvents();

			//must register css class SearchTextField.css
			SearchModeStyles();
		}

		#endregion

		#region Members

		private bool _isBaseInitialized;
		private bool _searchModeEnabled = true;

		#endregion

		#region Properties

		#region Custom

		/// <summary>
		///     Get or set if the search mode is enabled. Default value 'true'
		/// </summary>
		[DefaultValue(true)]
		public bool SearchModeEnabled
		{
			get => _searchModeEnabled;
			set
			{
				_searchModeEnabled = value;
				SearchModeStyles();
			}
		}

		/// <summary>
		///     Name of the javascript function that raises if anything else goes wrong
		/// </summary>
		[DefaultValue(null)]
		public string FailureFn { get; set; }

		[DefaultValue(null)] public string SuccessFn { get; set; }

		/// <summary>
		///     Url to the controller that makes the search with an specified parameter
		/// </summary>
		[DefaultValue(null)]
		public string SearchUrl { get; set; }

		/// <summary>
		///     Name of the parameter that the controller expects. Default value is 'identificador'
		/// </summary>
		[DefaultValue("identificador")]
		public string ExtraParameterName { get; set; } = "identificador";

		#endregion

		#region Override

		/// <inheritdoc />
		/// <summary>
		///     Generates extra properties for search text field to interact in javascript
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[JsonIgnore]
		public override ConfigOptionsCollection ConfigOptions
		{
			get
			{
				var list = base.ConfigOptions;

				list.Add("searchModeEnabled", new ConfigOption("searchModeEnabled", null, true, SearchModeEnabled));
				list.Add("failureFn", new ConfigOption("failureFn", null, null, FailureFn));
				list.Add("successFn", new ConfigOption("successFn", null, null, SuccessFn));
				list.Add("searchUrl", new ConfigOption("searchUrl", null, null, SearchUrl));
				list.Add("extraParameterName",
					new ConfigOption("extraParameterName", null, "identificador", ExtraParameterName));

				return list;
			}
		}

		/// <summary>
		///     Add the resources for this control
		/// </summary>
		[Description("")]
		protected override List<ResourceItem> Resources
		{
			get
			{
				var baseList = base.Resources;
				var path = $@"{GetType()}.js";

				baseList.Capacity += 1;
				baseList.Add(
					new ClientScriptItem(GetType(), path,
						Page.ClientScript.GetWebResourceUrl(GetType(), path)));

				return baseList;
			}
		}

		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString(); //"Ext.ux.form.SearchTextField";

		//public override string XType => GetType().ToString().Split(".".ToCharArray()).Last().ToLower();//"searchtextfield";

		#endregion

		#endregion

		#region Constructors

		/// <inheritdoc />
		public SearchTextField()
		{
		}

		public SearchTextField(Config config) : base(config)
		{
		}

		public SearchTextField(string text) : base(text)
		{
		}

		#endregion

		#region Methods

		private void SetJavascriptEvents()
		{
			//Blur Listener
			Listeners.Blur.Handler = "return this.getEl().hasClass('" + SearchCls + "');";

			DataBind();

			//Blur Direct Event
			if (string.IsNullOrEmpty(SearchUrl)) return;

			DirectEvents.Blur.Url = SearchUrl;

			if (!string.IsNullOrEmpty(FailureFn))
				DirectEvents.Blur.Failure = FailureFn;

			var extraParams = new ParameterCollection(true)
			{
				new Parameter(ExtraParameterName, Text, ParameterMode.Raw)
			};
		}

		private void SearchModeStyles()
		{
			var path = $@"{GetType()}.css";

			Ext.Net.ResourceManager.RegisterGlobalStyle(Page.ClientScript.GetWebResourceUrl(GetType(), path));

			if (!_isBaseInitialized) return;

			if (SearchModeEnabled)
			{
				//Attention
				//When adding css class to the control it will preventing Window to be appeared in desktop.
				//AddCls(SearchCls);
			}
			else
			{
				RemoveCls(SearchCls);
			}
		}

		#endregion
	}
}