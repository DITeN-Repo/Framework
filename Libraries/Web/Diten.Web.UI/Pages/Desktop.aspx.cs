#region Using Directives

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using Diten.Globalization;
using Ext.Net;

#endregion

namespace Diten.Web.UI.Pages
{
	public partial class Desktop : Page
	{
		private const string ApplicationApplications = "ApplicationApplications";

		public Dictionary<TypeInfo, Application> Applications
		{
			get
			{
				if (Application[ApplicationApplications] == null)
					Application[ApplicationApplications] = ResourceManager.Assemblies.SelectMany(assembly => assembly
							.DefinedTypes.ToList()
							.Where(t => t.BaseType != null && t.BaseType.Name.Equals(typeof(Application).Name) &&
							            t.Name.EndsWith("Test")))
						.ToDictionary(typeInfo => typeInfo, typeInfo => (Application) LoadControl(typeInfo));

				return (Dictionary<TypeInfo, Application>) Application[ApplicationApplications];
			}
		}

		[DirectMethod(ShowMask = true)]
		// ReSharper disable once UnusedMember.Global
		public void Initialize()
		{
			foreach (var application in Applications)
				DesktopControl.AddApplication(application.Value);

			Ext.Net.Desktop.GetInstance().RemoveModule("tmp_Module");
		}

		protected void Logout_Click(object sender, DirectEventArgs e)
		{
			// Logout from Authenticated Session
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (X.IsAjaxRequest) return;

			// Fixes some theme-specific settings
			var curTheme = Ext.Net.ResourceManager.GetInstance(System.Web.HttpContext.Current);

			switch (curTheme.Theme)
			{
				case Theme.Triton:

					// For this one the value specified in markup is good.
					break;
				case Theme.Default:
				case Theme.Gray:
					DesktopControl.TaskBar.QuickStartWidth = 50;
					DesktopControl.TaskBar.TrayWidth = 90;

					break;
				case Theme.CrispTouch:
				case Theme.NeptuneTouch:
					DesktopControl.TaskBar.QuickStartWidth = 84;
					DesktopControl.TaskBar.TrayWidth = 127;

					break;
				case Theme.Crisp:
				case Theme.Neptune:
					DesktopControl.TaskBar.QuickStartWidth = 64;
					DesktopControl.TaskBar.TrayWidth = 114;

					break;
				case Theme.Aria:
					DesktopControl.TaskBar.QuickStartWidth = 64;
					DesktopControl.TaskBar.TrayWidth = 119;

					break;
				case Theme.None:

					break;
				case Theme.Graphite:
					break;
				default:

					throw new ArgumentOutOfRangeException();
			}

			CultureInfo cultureInfo;

			switch (Culture)
			{
				case "Persian (Iran)":
					curTheme.Locale = "fa-IR";
					cultureInfo = new PersianCulture();

					break;
				case "Italian (Italy)":
					cultureInfo = CultureInfo.InvariantCulture;
					curTheme.Locale = "it-IT";

					break;
				default:
					cultureInfo = CultureInfo.InvariantCulture;

					//ResourceManager.Locale = "en-US";
					break;
			}

			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
	}
}