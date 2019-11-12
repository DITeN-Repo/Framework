#region Using Directives

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Diten.Web.UI.WebControls;
using Ext.Net;
using Ext.Net.Utilities;
using X = Ext.Net.X;

#endregion

namespace Diten.Web.UI
{
	/// <inheritdoc />
	/// <summary>
	///     UserControl class.
	/// </summary>
	public class BaseUserControl : System.Web.UI.UserControl
	{
		//
		//
		//

		/// <inheritdoc />
		/// <summary>
		///     Constructor.
		/// </summary>
		public BaseUserControl()
		{
			Load += UserControl_Load;
		}

		/// <summary>
		///     Get content panel of the control.
		///     Each control must have only one content control that contains the content of the control.
		/// </summary>
		public ContentPanel Content =>
			ViewState.GetValue<ContentPanel>(this.GetFrameName(),
				delegate
				{
					return ControlUtils.FindControl(this, typeof(ContentPanel)).TryCast<ContentPanel>() ??
					       throw new NullReferenceException("Could not find content panel with ID [PanelContent].");
				});

		/// <summary>
		///     Set caching of the control.
		/// </summary>
		public bool DoCache { get; set; } = true;

		/// <summary>
		///     Get or Set height of control.
		/// </summary>
		public Unit Height
		{
			get => ViewState.GetValue<Unit>(this.GetFrameName(), Unit.Pixel(100));
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get container page of the control.
		/// </summary>
		public new Page Page => base.Page.TryCast<Page>() ?? new Page(base.Page.TryCast<SelfRenderingPage>());

		/// <summary>
		///     Get or Set width of control.
		/// </summary>
		public Unit Width
		{
			get => ViewState.GetValue<Unit>(this.GetFrameName(), Unit.Pixel(200));
			set => ViewState.SetValue(this.GetFrameName(), value);
		}


		/// <summary>
		///     Indicates a dictionary of ViewStates.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object this[string key, Func<object> func]
		{
			get => ViewState[key] ?? (ViewState[key] = func.Invoke());
			set => ViewState[key] = value;
		}

		/// <summary>
		///     Initializing components.
		/// </summary>
		private void InitializeComponents()
		{
			if (X.IsAjaxRequest) return;

			Page.Translate(Controls);

#if !debug
			if (!DoCache || Response.Cache.GetExpires() > DateTime.Now) return;

			Response.Cache.SetExpires(DateTime.Now.AddDays(30));
			Response.Cache.SetCacheability(HttpCacheability.Private);
			Response.Cache.SetValidUntilExpires(true);
#endif
		}

		/// <summary>
		///     User control event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		private void UserControl_Load(object sender,
			EventArgs e)
		{
			InitializeComponents();
		}
	}
}