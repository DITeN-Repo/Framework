#region Using Directives

using System;
using System.ComponentModel;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ApplicationModule runat=\"server\"></{0}:ApplicationModule>")]
	public class ApplicationModule : DesktopModule
	{
		public ApplicationModule(Application application)
		{
			Application = application;

			if (Application != null) Initialize();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("An application to be added to the content of the module.")]
		public Application Application
		{
			get =>
				ViewState.GetValue<Application>(this.GetFrameName(),
					delegate
					{
						throw new ArgumentNullException(Exceptions.Default
							.ApplicationModule_Application_ArgumentNullException);
					});
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		private void Initialize()
		{
			if (Application == null)
				throw new NullReferenceException(Exceptions.Default
					.ApplicationModule_Initialize_NullReferenceException);

			var icon = Application.IconHolder;
			var win = new Window
			{
				ID = $@"{Application.ID.ToPrefix()}{typeof(Window)}",
				Height = Application.Height,
				Width = Application.Width,
				MinWidth = (int) Application.Width.Value,
				MinHeight = (int) Application.Height.Value,
				Title = Application.Title,
				Collapsible = false,
				Maximizable = true,
				Minimizable = true,
				Hidden = true,
				DefaultRenderTo = DefaultRenderTo.Form,
				Layout = Layouts.Fit.GetName(),
				IconCls = icon.ToD16().IconCls
			};


			win.Items.Add(Application.Content); // = { Application.Content}


			ModuleID = $@"{Application.ID.ToPrefix()}{Names.Default.Module}";
			Shortcut = new DesktopShortcut
			{
				Name = Application.Title,
				IconCls = icon.ToD16().IconCls
			};
			Launcher = new MenuItem
			{
				ID = $@"{Application.ID.ToPrefix()}{typeof(MenuItem)}",
				Text = Application.Title,
				IconCls = icon.IconCls
			};
			Window.Add(win);
		}
	}
}