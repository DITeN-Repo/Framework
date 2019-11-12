#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Security.Cryptography;
using Diten.Variables;
using Ext.Net;
using Ext.Net.Utilities;
using DataView = Ext.Net.DataView;
using ResourceManager = Diten.Web.UI.WebControls.ResourceManager;
using TextField = Diten.Web.UI.WebControls.TextField;

#endregion

//using Diten.Web.UI.WebControls.Events;
//using Button = Diten.Web.UI.WebControls.Button;

//todo: Check commented codes.

namespace Diten.Web.UI
{
	/// <inheritdoc />
	/// <summary>
	///     Page class.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class Page : System.Web.UI.Page
	{
		/// <inheritdoc />
		/// <summary>
		///     Constructor.
		/// </summary>
		public Page()
		{
			Load += Page_Load;
			PreInit += Page_PreInit;
		}

		public Page(SelfRenderingPage basePage) : this()
		{
			SelfRenderingPage = basePage;
		}

		private List<string> AnalyzedControls
		{
			get
			{
				if (Session[this.GetFrameName()] == null)
					Session[this.GetFrameName()] = new List<string>();

				return (List<string>) Session[this.GetFrameName()];
			}
		}

		/// <summary>
		///     Get or Set application dictionary.
		/// </summary>
		/// <returns>Return dictionary data table.</returns>
		public DataTable ApplicationDictionary
		{
			get => (DataTable) Application[this.GetFrameName()];
			set => Application[this.GetFrameName()] = value;
		}

		public SelfRenderingPage BasePage => SelfRenderingPage;

		/// <summary>
		///     get culture database ID.
		/// </summary>
		public Guid CultureId => new Guid(Session[this.GetFrameName()].ToString());

		/// <summary>
		///     Get culture name.
		/// </summary>
		public string CultureName
		{
			get
			{
				if (Session[this.GetFrameName()] == null)
					Session[this.GetFrameName()] = Culture;

				return Session[this.GetFrameName()].ToString();
			}
			set => Session[this.GetFrameName()] = value;
		}

		public bool DoCache { get; set; } = true;

		/// <summary>
		///     Get logged-in user domain ID.
		/// </summary>
		public Guid DomainId
		{
			get => new Guid(Session[this.GetFrameName()].ToString());
			set => Session[this.GetFrameName()] = value;
		}

		/// <summary>
		///     Get encryption key.
		/// </summary>
		public string EncryptionKey
		{
			get
			{
				var key = Session.SessionID + UserId;

				if (Session[this.GetFrameName()] == null)
					Session[this.GetFrameName()] = SHA1.Encrypt(Md5.Encrypt(key));

				return Session[this.GetFrameName()].ToString();
			}
		}

		/// <summary>
		///     Get passed Parameters.
		/// </summary>
		public Dictionary<string, string> Parameters =>
			ViewState.GetValue<Dictionary<string, string>>(this.GetFrameName(), delegate
			{
				return GetParameters(Request.QueryString) ?? GetParameters(Request.Form) ??
				       throw new ArgumentNullException(@"Parameters not found.");
			});

		/// <summary>
		///     Get SessionResourceManager.
		/// </summary>
		public ResourceManager ResourceManager =>
			(ResourceManager) ControlUtils.FindControl(this, typeof(ResourceManager)) ??
			ResourceManager.GetInstance(System.Web.HttpContext.Current);

		/// <summary>
		///     Get and Set right to left of page.
		/// </summary>
		public bool? RightToLeft
		{
			get => ViewState.GetValue<bool?>(this.GetFrameName(), false);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		public SelfRenderingPage SelfRenderingPage { get; }

		//.GetHostEntry(IPAddress.Parse(Request.UserHostName)).HostName.Split(".".ToCharArray()).ToList().First();

		// ReSharper disable once InvalidXmlDocComment
		/// <summary>
		///     ID of current computer.
		/// </summary>
		//public Guid ComputerId => (Guid) Computer.GetComputer(DomainId, UserId, UserHostName)["Id"];
		/// <summary>
		///     Get system culture ID.
		/// </summary>
		public Guid SystemCultureId => (Guid) Application[this.GetFrameName()];

		public string TempFolder
		{
			get
			{
				var sessionName = $@"{Variables.Session.Default.TempFolder.ToPrefix()}{Session.SessionID}";
				if (Session[sessionName] == null)

					Session[sessionName] =
						Server.MapPath(
							$@"{Constants.Default.TempFolderVirtualPath}\{Constants.Default.TempFolderItemExtention.ToPrefix()}{SHA1.Encrypt(Md5.Encrypt(Session.SessionID))}");

				var folderPath = Session[sessionName].ToString();

				if (!Directory.Exists(folderPath))
					Directory.CreateDirectory(folderPath);

				return folderPath;
			}
		}

		/// <summary>
		///     Get or Set theme of application.
		/// </summary>
		public new Theme Theme
		{
			get => ResourceManager.Theme;
			set => ResourceManager.Theme = value;
		}

		/// <summary>
		///     Get user machine name.
		/// </summary>
		public string UserHostName => System.Net.Dns.GetHostName();

		/// <summary>
		///     Get logged-in user ID.
		/// </summary>
		public Guid UserId
		{
			get
			{
				if (Session[this.GetFrameName()] == null)
					Session[this.GetFrameName()] = Guid.Empty;

				return new Guid(Session[this.GetFrameName()].ToString());
			}
			set => Session[this.GetFrameName()] = value;
		}

		protected string StackTraceFirstFrameName
		{
			get
			{
				var _return = new StackTrace().GetFrame(1).GetMethod().Name;

				if (_return.StartsWith("get_")) return _return.TrimStart("get_".ToCharArray());
				return _return.StartsWith("set_") ? _return.TrimStart("set_".ToCharArray()) : _return;
			}
		}

		/// <summary>
		///     Decrypting data using private encryption key.
		/// </summary>
		/// <param name="data">Encrypted data.</param>
		/// <returns>Decrypted data.</returns>
		public string Decrypt(string data)
		{
			return Rc4.Decrypt(EncryptionKey, Server.UrlDecode(data));
		}

		/// <summary>
		///     Encrypting data using private encryption key.
		/// </summary>
		/// <param name="data">Data for encryption.</param>
		/// <returns>Encrypted data.</returns>
		public string Encrypt(string data)
		{
			return Server.UrlEncode(Rc4.Encrypt(EncryptionKey, data));
		}

		public string GetBitmapResourceUrl(Bitmap bitmap,
			Control control)
		{
			return GetBitmapResourceUrl(bitmap, control, string.Empty);
		}

		public string GetBitmapResourceUrl(Bitmap bitmap,
			Control control,
			string extension)
		{
			if (!extension.Equals(string.Empty))
				extension = $@"_{extension}";

			var fileName = $@"{control.ClientID}{extension}.png";
			var virtualPath = $@"~/CACHE/{fileName}";

			//if (Application[virtualPath] != null) return virtualPath;

			var fullPath = Server.MapPath(virtualPath);

			try
			{
				if (!File.Exists(fullPath))
					bitmap.Save(fullPath);
			}
			catch (Exception e)
			{
				throw new InvalidCredentialException(
					$@"Maybe IIS process account is not permitted to write [{fullPath}].", e);
			}

			return virtualPath;
		}

		/// <summary>
		///     Get encrypted parameter.
		/// </summary>
		/// <param name="parameters">Parameters for encryption.</param>
		/// <returns>Encrypted parameter.</returns>
		public string GetEncryptedParameter(Dictionary<string, string> parameters)
		{
			return parameters != null
				? $@"{Constants.Application.EncryptedUriParameter}={Encrypt(Convert.ToSplittedData(parameters))}"
				: string.Empty;
		}

		/// <summary>
		///     Get Parameters.
		/// </summary>
		/// <param name="nameValueCollection">Name value collection.</param>
		/// <returns>A dictionary that contains Parameters and values.</returns>
		private Dictionary<string, string> GetParameters(NameValueCollection nameValueCollection)
		{
			if (nameValueCollection.HasKeys() &&
			    nameValueCollection.AllKeys.Contains(Constants.Application.EncryptedUriParameter))
				return Decrypt(nameValueCollection.Keys.Cast<string>()
					.Aggregate(string.Empty,
						(current,
								key) =>
							current +
							nameValueCollection[key])).ToDictionary();

			return null;
		}

		/// <summary>
		///     Initializing components.
		/// </summary>
		private void InitializeComponents()
		{
			//if (X.IsAjaxRequest) return;

			//Title = Translate(Title);

			//if (Page.IsPostBack ||
			//    !DoCache ||
			//    Response.Cache.GetExpires() > DateTime.Now) return;
#if !debug

			//Response.Cache.SetExpires(DateTime.Now.AddDays(30));
			//Response.Cache.SetCacheability(HttpCacheability.Private);
			//Response.Cache.SetValidUntilExpires(true);
#endif
		}

		/// <summary>
		///     Loading user-control from Diten.Web.UI.WebControls.
		/// </summary>
		/// <param name="controlType">Type of control to load.</param>
		/// <returns>A control.</returns>
		public Control LoadControl(Type controlType)
		{
			string extension;

			if (controlType.BaseType == null)
				throw new ArgumentNullException($@"Base type of [{controlType}] is null.");

			if (controlType.BaseType.Name.Equals(typeof(UserControl).Name))
				extension = "ctrl";
			else if (controlType.BaseType.Name.Equals(typeof(Application).Name))
				extension = "exe";
			else
				throw new NotSupportedException("Extension not recognized.");

			//try
			//{
			//var rr = Page.ClientScript.GetWebResourceUrl(controlType, $@"{controlType.ToString().Replace("Diten.Web.UI.", string.Empty)}.{extension}.ascx");
			//return LoadControl($@"~/bin/{controlType.ToString().Replace("Diten.Web.UI.", string.Empty).Replace(".","/")}.{extension}.ascx");

			//var userControl =
			//    UserControlRenderer.LoadControl(
			//        $@"~/{Diten.Variables.Constants.Application.ResourcesPath}/{controlType}.{extension}.ascx");

			//ControlUtils.FindControl<BaseControl>(userControl)?.Render();

			//return userControl
			return LoadControl($@"~/{Constants.Application.ResourcesPath}/{controlType}.{extension}.ascx");
			//}
			//catch (Exception e)
			//{
			//    throw new ConfigurationErrorsException(
			//        $@"Maybe build action of user control [{controlType}.{extension}.ascx] is not set as embedded resource. Argument exception message is [{e.Message}]",
			//        e);
			//}
		}

		/// <summary>
		///     Page load event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		private void Page_Load(object sender,
			EventArgs e)
		{
			InitializeComponents();
		}

		private void Page_PreInit(object sender,
			EventArgs e)
		{
			if (X.IsAjaxRequest) return;

			Translate(Controls);
		}

		/// <summary>
		///     Redirect page into uri.
		/// </summary>
		/// <param name="url">url for redirection.</param>
		/// <param name="parameters">Parameters to pass.</param>
		/// <param name="doPost">Send data by post method.</param>
		public void Redirect(string url,
			Dictionary<string, string> parameters = null,
			bool doPost = false)
		{
			Response.Redirect(Convert.ToUrl(url, GetEncryptedParameter(parameters), doPost));
		}

		/// <summary>
		///     Redirect into embedded page.
		/// </summary>
		/// <param name="pageType">Type of page for redirection.</param>
		/// <param name="parameters">Parameters to pass.</param>
		/// <param name="doPost">Send data by post method.</param>
		public void Redirect(Type pageType,
			Dictionary<string, string> parameters = null,
			bool doPost = false)
		{
			Redirect($@"{Constants.Application.ResourcesPath}/{pageType}.aspx", parameters, doPost);
		}

		/// <summary>
		/// </summary>
		/// <param name="script"></param>
		protected virtual void RenderScript(string script)
		{
			if (System.Web.HttpContext.Current == null)
				return;

			var instance = ResourceManager.GetInstance(System.Web.HttpContext.Current);

			if (System.Web.HttpContext.Current.CurrentHandler is System.Web.UI.Page && instance != null)
				instance.AddScript(script);
			else
				ResourceManager.AddInstanceScript(script);
		}

		/// <summary>
		///     Set control string properties.
		/// </summary>
		/// <param name="control">Control to set.</param>
		private void SetProperties(Control control)
		{
			if (AnalyzedControls.Contains(control.ID))
				return;

			AnalyzedControls.Add(control.ID);

			if (control.GetType().ToString().ToUpper().Contains("Html".ToUpper()) ||
			    control.GetType() == typeof(ResourceManager) ||
			    control.GetType() == typeof(Ext.Net.ResourceManager) ||
			    control.GetType() == typeof(MenuSeparator) ||
			    control.GetType() == typeof(DesktopStartMenu) ||
			    control.GetType() == typeof(LiteralControl)) return;

			if (control.GetType() == typeof(Button))
			{
				var button = (Button) control;

				button.DirectEvents.Click.EventMask.Msg =
					$@"{Translate(button.DirectEvents.Click.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
				button.OverflowText = Translate(button.OverflowText);
				button.QTipCfg.Text = Translate(button.QTipCfg.Text);
			}
			else if (control.GetType() == typeof(TreePanel))
			{
				var treePanel = (TreePanel) control;

				treePanel.DirectEvents.Select.EventMask.Msg =
					$@"{Translate(treePanel.DirectEvents.Select.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
			}
			else if (control.GetType() == typeof(GridPanel))
			{
				var gridPanel = (GridPanel) control;

				gridPanel.DirectEvents.Select.EventMask.Msg =
					$@"{Translate(gridPanel.DirectEvents.Select.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
			}
			else if (control.GetType() == typeof(DataView))
			{
				var dataView = (DataView) control;

				dataView.DirectEvents.Select.EventMask.Msg =
					$@"{Translate(dataView.DirectEvents.Select.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
				dataView.DirectEvents.ItemClick.EventMask.Msg =
					$@"{Translate(dataView.DirectEvents.ItemClick.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
			}
			else if (control.GetType() == typeof(MenuItem))
			{
				var menuItem = (MenuItem) control;

				menuItem.DirectEvents.Click.EventMask.Msg =
					$@"{Translate(menuItem.DirectEvents.Click.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
			}
			else if (control.GetType() == typeof(RadioGroup))
			{
				var radioGroup = (RadioGroup) control;

				radioGroup.DirectEvents.Change.EventMask.Msg =
					$@"{Translate(radioGroup.DirectEvents.Change.EventMask.Msg)}
                           {Constants.Default.MaskDots}";
			}

			foreach (var propertyInfo in control.GetType().GetProperties())
				if (propertyInfo.Name.Equals("RTL"))
				{
					propertyInfo.SetValue(control, RightToLeft, null);
				}
				else if (propertyInfo.PropertyType == typeof(string))
				{
					if (!propertyInfo.Name.Equals("FieldLabel") && !propertyInfo.Name.Equals("BlankText") &&
					    !propertyInfo.Name.Equals("ToolTip") && !propertyInfo.Name.Equals("EmptyText") &&
					    !propertyInfo.Name.Equals("InvalidText") && !propertyInfo.Name.Equals("Note") &&
					    !propertyInfo.Name.Equals("ValidatorText") && !propertyInfo.Name.Equals("Title") &&
					    !propertyInfo.Name.Equals("Text") && !propertyInfo.Name.Equals("MaskMessage") &&
					    !propertyInfo.Name.Equals("BoxLabel")) continue;

					if ((control.GetType() == typeof(TextArea) || control.GetType() == typeof(TextField))
					    && propertyInfo.Name.Equals("Text")) continue;

					var value = propertyInfo.GetValue(control).ToString();

					if (!(value.Contains("<") || value.Contains(">")) &&
					    !string.IsNullOrEmpty(value) &&
					    !string.IsNullOrWhiteSpace(value) &&
					    !string.IsNullOrEmpty(control.ID) &&
					    !string.IsNullOrWhiteSpace(control.ID))
						propertyInfo.SetValue(control,
							System.Convert.ChangeType(Translate(value), propertyInfo.PropertyType),
							null);
				}
		}

		/// <summary>
		///     Translate control.
		/// </summary>
		/// <param name="control">Control</param>
		public void Translate(Control control)
		{
			SetProperties(control);

			foreach (Control ctrl in control.Controls)
			{
				if (!ctrl.Controls.Count.Equals(0))
					Translate(ctrl.Controls);

				SetProperties(ctrl);
			}
		}

		/// <summary>
		///     Translate controls recursively.
		/// </summary>
		/// <param name="controls">Controls</param>
		public void Translate(System.Web.UI.ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				if (!control.Controls.Count.Equals(0))
					Translate(control.Controls);

				SetProperties(control);
			}
		}

		/// <summary>
		///     Translating from current culture into destination culture,
		/// </summary>
		/// <param name="data">Data for translation.</param>
		/// <returns>Translated data</returns>
		public string Translate(string data)
		{
			return Translate(data, CultureName);
		}

		/// <summary>
		///     Translating from current culture into destination culture,
		/// </summary>
		/// <param name="data">Data for translation.</param>
		/// <param name="cultureName">Translation culture name.</param>
		/// <returns>Translated data</returns>
		public string Translate(string data,
			string cultureName)
		{
#if DEBUG
			return $@"{data} - {DateTime.Now.Millisecond}";
#else
            return $@"{data}";
#endif

			//todo: This part is based on ADO and must be changed
			//try
			//{
			//    if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
			//        return string.Empty;

			//    var dataRows =
			//        ApplicationDictionary.Select(
			//            $@"SourceText='{data}' AND SourceCultureID='{SystemCultureId}' AND TranslationCultureID='{
			//                    CultureId
			//                }'");

			//    string _return;

			//    if (dataRows.Length == 0)
			//    {
			//        _return = Translation.Translate(data, Diten.Constants.Default.SystemCultureName,
			//            cultureName);

			//        UpdateApplicationDictionary();

			//        return _return.Equals(string.Empty) || string.IsNullOrEmpty(_return) ||
			//               string.IsNullOrWhiteSpace(_return)
			//            ? data.Replace("^", "<br />")
			//            : _return.Replace("^", "<br />");
			//    }

			//    _return = dataRows[0]["TranslatedText"].ToString();

			//    return _return.Equals(string.Empty) || string.IsNullOrEmpty(_return) ||
			//           string.IsNullOrWhiteSpace(_return)
			//        ? data
			//        : _return;
			//}
			//catch (Exception)
			//{
			//    return data;
			//}
		}

		///// <summary>
		/////     Writing event into database.
		///// </summary>
		///// <param name="entityId">Entity ID</param>
		///// <param name="qualifier">The qualifier that we run on entity.</param>
		///// <param name="methodName">Name of method that run qualifier.</param>
		///// <param name="level">Level of event.</param>
		///// <param name="keywords">Key words for event for search.</param>
		///// <param name="description"></param>
		///// <param name="exceptionId">Description of the event.</param>
		//public void WriteEvent(Guid entityId, Event.QualifierTypes qualifier, string methodName,
		//    Event.LevelTypes level, List<string> keywords, string description, Guid exceptionId)
		//{
		//    var eventObject = new Event
		//    {
		//        Qualifier = qualifier,
		//        EntityId = entityId,
		//        SourceType = GetType().ToString(),
		//        MethodName = methodName,
		//        Level = level,
		//        Keywords = keywords,
		//        TimeCreated = DateTime.Now,
		//        UserId = UserId,
		//        DomainId = DomainId,
		//        ComputerId = ComputerId,
		//        IpAddress = Request.UserHostAddress ?? "127.0.0.1",
		//        Description = description,
		//        ExceptionId = exceptionId
		//    };

		//    eventObject.WriteEvent();
		//}

		/// <summary>
		///     Update application dictionary
		/// </summary>
		public void UpdateApplicationDictionary()
		{
			//ApplicationDictionary = Dictionary.GetApplicationDictionary();
		}
	}
}