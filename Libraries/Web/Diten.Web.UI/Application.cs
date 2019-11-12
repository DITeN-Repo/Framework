#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Diten.Web.UI.WebControls;
using Ext.Net;
using Icon = Diten.Web.UI.WebControls.Icon;
using Panel = Diten.Web.UI.WebControls.Panel;
using TabPanel = Diten.Web.UI.WebControls.TabPanel;

//using Diten.Data.Ado.Helpers;

#endregion

namespace Diten.Web.UI
{
	[Meta]
	[ToolboxData("<{0}:Application runat=\"server\"></{0}:Application>")]
	public class Application : BaseUserControl, IWebControlInterface
	{
		public Application()
		{
			Init += Application_Init;
		}

		/// <summary>
		///     Name of the application.
		/// </summary>
		public string ApplicationName
		{
			get => ViewState.GetValue<string>(this.GetFrameName(),
				delegate
				{
					throw new ArgumentNullException(
						Exceptions.Default.Diten_Web_UI_Application_ApplicationName_ParamName,
						Exceptions.Default.Diten_Web_UI_Application_ApplicationName_Message);
				});
			protected set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Description of application.
		/// </summary>
		public string Description => throw new NotImplementedException(); //ApplicationHolder["Description"].ToString();

		private IEnumerable<Panel> GetToolbar
		{
			get
			{
				List<Panel> _return = new ItemsCollection<Panel>();

				try
				{
					foreach (var item in ((TabPanel) FindControl(typeof(TabPanel).Name)).Items)
					{
						if (item.GetType() != typeof(Panel)) continue;
						item.Visible = true;
						_return.Add((Panel) item);
					}
				}
				catch (NullReferenceException)
				{
				}

				return _return;
			}
		}

		/// <summary>
		///     HelpWindow.
		/// </summary>
		public HelpWindow HelpWindow => ViewState.GetValue<HelpWindow>(this.GetFrameName(), new HelpWindow
		{
			ID = $"{ID.ToPrefix()}{this.GetFrameType().Name}"
		});

		public override string ID => GetType().ToString().ToProtected();

		//todo: Removing commented codes.
		///// <summary>
		/////     Get or Set RegisteredTypes.
		///// </summary>
		//private IEnumerable<Type.RegisteredType> RegisteredTypes
		//{
		//    get
		//    {
		//        List<Type.RegisteredType> Output()
		//        {
		//            var xmlDocument = new XmlDocument();

		//            xmlDocument.LoadXml(
		//                                Page.ResourceManager.GetManifestResourceStream(
		//                                                                               $@"{GetType()}.manifest")
		//                                    .ToString());

		//            return new Document(xmlDocument).GetAttributes("Configuration.RegisteredTypes")
		//                                            .Select(node => new Type.RegisteredType
		//                                                            {
		//                                                                Name = node["Name"],
		//                                                                Description = node["Description"],
		//                                                                Title = node["Title"],
		//                                                                IconCls = node["IconCls"]
		//                                                            })
		//                                            .ToList();
		//        }

		//        if (ViewState[this.GetFirstFrameName()] == null)
		//            ViewState[this.GetFirstFrameName()] = Output();

		//        return (List<Type.RegisteredType>) ViewState[this.GetFirstFrameName()];
		//    }
		//}

		/// <summary>
		///     Get or Set Title of application.
		/// </summary>
		public string Title
		{
			get => ViewState.GetValue<string>(this.GetFrameName());
			protected set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		/// <summary>
		///     Get application icon.
		///     Application icon size must be in [64x64] dimension.
		/// </summary>
		public Icon IconHolder
		{
			get => ViewState.GetValue<Icon>(this.GetFrameName(), new Icon(Icons.Application, Icon.Dimensions.D64));
			private set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		/// <summary>
		///     Get or Set application icon.
		///     Application icon size must be in [64x64] dimension.
		/// </summary>
		public Icons DTIcon
		{
			get => IconHolder.Value;
			set => IconHolder = new Icon(value, Icon.Dimensions.D64);
		}

		// ReSharper disable once RedundantCast
		Page IWebControlInterface.Page => Page as Page;

		protected void AddApplication(Application application)
		{
			((TabPanel) FindControl(typeof(TabPanel).Name))?.Items.Add(application.GetToolbar);
			Controls.Add(application);
		}

		private void Application_Init(object sender,
			EventArgs e)
		{
			Initialize();

			//Controls.Add(HelpWindow);
		}

		/// <summary>
		///     Get special folders.
		/// </summary>
		/// <param name="specialFolder">Special folder enum.</param>
		/// <returns>ID of the special folder.</returns>
		public Guid GetSpecialFolderId(Environment.SpecialFolder specialFolder)
		{
			return Guid.Empty;
			//new Folder(Page.DomainId,
			//    ApplicationName, Users.GetUser(Page.UserId)["UserName"].ToString())
			//.GetFolderId(specialFolder);
		}

		private void Initialize()
		{
			Initialize(Controls);
		}

		private void Initialize(IEnumerable controlCollection)
		{
			foreach (Control control in controlCollection)
			{
				if (!control.Controls.Count.Equals(0))
					Initialize(control.Controls);

				control.GetType().GetMethod(Constants.Default.InitializeMethodName)?.Invoke(control,
					BindingFlags.InvokeMethod, null, null, CultureInfo.CurrentCulture);
			}

			Page.Controls.Add(IconHolder);
		}
	}
}