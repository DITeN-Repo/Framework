#region Using Directives

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Ext.Net;

#endregion

// ReSharper disable InconsistentNaming

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:ApplicationModuleProxy runat=\"server\"></{0}:ApplicationModuleProxy>")]
	public class ApplicationModuleProxy : DesktopModuleProxy, IWebControlInterface
	{
		public ApplicationModuleProxy()
		{
			Init += ApplicationModuleProxy_Init;
		}

		[DeferredRender]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[Description("An application to be added to this container")]
		public Application Application { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("A single item, or an array of child Components to be added to the content controls")]
		public ControlCollection ContentControls => (ControlCollection) Module.Window.First().ContentControls;

		public new Unit Height
		{
			get => base.Height;
			set
			{
				Module.Window.First().Height = value;
				base.Height = value;
			}
		}

		[DeferredRender]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[Description("A single item, or an array of child Components to be added to this container")]
		public ItemsCollection<AbstractComponent> Items => Module.Window.First().Items;

		public int? MinHeight
		{
			get => Module.Window.First().MinHeight;
			set => Module.Window.First().MinHeight = value;
		}

		public int? MinWidth
		{
			get => Module.Window.First().MinWidth;
			set => Module.Window.First().MinWidth = value;
		}

		public new virtual ApplicationModule Module =>
			ViewState.GetValue<ApplicationModule>(this.GetFrameName(), new ApplicationModule(Application));

		public string ModuleID
		{
			get => Module.ModuleID;
			set => Module.ModuleID = value;
		}

		/// <summary>
		///     Get or Set Title of application.
		/// </summary>
		public string ShortcutName
		{
			get => Module.Window.First().Title;
			set
			{
				Module.Launcher.Text = value;
				Module.Window.First().Title = value;
			}
		}

		/// <summary>
		///     Get or Set Title of application.
		/// </summary>
		public string Title
		{
			get => Module.Window.First().Title;
			set
			{
				Module.Launcher.Text = value;
				Module.Window.First().Title = value;
			}
		}

		[DeferredRender]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[Description("A single item, or an array of toolbar component that contains toolbars.")]
		public ToolbarCollection TopBar => Module.Window.First().TopBar;

		public new Unit Width
		{
			get => base.Width;
			set
			{
				Module.Window.First().Width = value;
				base.Width = value;
			}
		}

		/// <inheritdoc />
		/// <summary>
		///     Holder of the icon object.
		/// </summary>
		public Icon IconHolder
		{
			get =>
				ViewState.GetValue<Icon>(this.GetFrameName(), delegate
				{
					var iconCls = DTIcon.ToString();

					if (!int.TryParse(iconCls.Substring(iconCls.Length - 3, 3), out var iconDimension))
						int.TryParse(iconCls.Substring(iconCls.Length - 2, 2), out iconDimension);

					if (!iconDimension.Equals(64))
						throw new InvalidDataException("Icon should be in the [64 x 64] dimension.");

					Module.Window.First().IconCls = iconCls.Replace(iconDimension.ToString(), "16");
					Module.Shortcut.IconCls = iconCls;
					return Icons.Application;
				});
			private set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		public new Page Page => (HttpContext.Current.CurrentHandler as System.Web.UI.Page) as Page;

		/// <inheritdoc />
		/// <summary>
		///     Get or Set icon.
		/// </summary>
		public Icons DTIcon
		{
			get => IconHolder.Value;
			set => IconHolder = new Icon(value);
		}

		private void ApplicationModuleProxy_Init(object sender, EventArgs e)
		{
			Module.Launcher.IconUrl = IconHolder.ImageUrl;

			//Page.ClientScript.GetWebResourceUrl(typeof(ResourceManager),
			//$@"Diten.Web.UI.Themes.{Ext.Net.ResourceManager.GetInstance()
			//    .Theme}.Icons.{Module.Window.First().IconCls}.png");
		}
	}
}