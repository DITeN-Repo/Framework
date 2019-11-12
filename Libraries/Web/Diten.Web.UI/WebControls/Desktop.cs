#region Using Directives

using System;
using System.Web.UI;
using Ext.Net;
using Ext.Net.Utilities;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:Desktop runat=\"server\"></{0}:Desktop>")]
	public class Desktop : Ext.Net.Desktop
	{
		public new Page Page
		{
			get
			{
				try
				{
					return (Page) base.Page;
				}
				catch (InvalidCastException)
				{
					return new Page((SelfRenderingPage) base.Page);
				}
			}
		}

		///// <inheritdoc />
		///// <summary>
		///// </summary>
		//[Category("0. About")]
		//[Description("")]
		//public override string InstanceOf => GetType().ToString();

		/// <summary>
		/// </summary>
		/// <param name="application"></param>
		public void AddApplication(Application application)
		{
			//Todo: Delete Commented Code

			var moduleId = $"{application.ID}_DesktopModule";
			var applicationModuleProxy = ControlUtils.FindControl<ApplicationModuleProxy>(application);
			var desktopModuleProxy = ControlUtils.FindControl<DesktopModuleProxy>(application);

			if (applicationModuleProxy != null)
			{
				applicationModuleProxy.ModuleID = moduleId;
				applicationModuleProxy.RegisterModule();
			}
			else if (desktopModuleProxy != null)
			{
				desktopModuleProxy.Module.ModuleID = moduleId;
				desktopModuleProxy.RegisterModule();
			}
			else
			{
				//Modules.Add(new ApplicationModule(application));
				AddModule(new ApplicationModule(application));
				Page.Controls.Add(application);
			}

			//    //AddModule(new DesktopModule
			//    //{
			//    //    ModuleID = moduleId,
			//    //    Shortcut = new DesktopShortcut
			//    //    {
			//    //        Name = application.Title
			//    //    },
			//    //    Launcher = new MenuItem
			//    //    {
			//    //        Text = application.Title
			//    //    },
			//    //    Window =
			//    //    {
			//    //        new Window
			//    //        {
			//    //            Height = application.Height,
			//    //            Width = application.Width,
			//    //            MinWidth = (int) application.Width.Value,
			//    //            MinHeight = (int) application.Height.Value,
			//    //            Title = application.Title,
			//    //            Collapsible = false,
			//    //            Maximizable = true,
			//    //            Minimizable = true,
			//    //            Hidden = true,
			//    //            DefaultRenderTo = DefaultRenderTo.Form,
			//    //            Layout = Layouts.Fit,
			//    //            ContentControls = {application}
			//    //        }
			//    //    }
			//    //});

			//    ////Page.Translate(application);
			//    //base.Page.Controls.Add(application);
			//}
		}
	}
}