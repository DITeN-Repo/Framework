#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[ToolboxData("<{0}:ResourceManager runat=\"server\"></{0}:ResourceManager>")]
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class ResourceManager : Ext.Net.ResourceManager
	{
		#region ResourceManager general methods an properties

		/// <summary>
		///     Constructor.
		/// </summary>
		public ResourceManager()
		{
			Load += ResourceManager_Load;
		}


		private void ResourceManager_Load(object sender, EventArgs e)
		{
			RegisterClientScriptInclude("MainJS", GetThemeResource(@"Main.js").Url);
			//RegisterClientScriptInclude("MD5JS", GetGeneralScriptsResource(@"MD5Encryption.js").Url);
			RegisterClientStyleInclude("MainCSS", GetThemesGeneralResource(@"Main.css").Url);
			RegisterClientStyleInclude("ThemeMainCSS", GetThemeResource(@"Main.css").Url);
			RegisterClientStyleInclude("ThemesMainCSS", GetThemesGeneralResource(@"Main.css").Url);

			//RegisterClientStyleBlock("ThemeIconsCSS", GetThemeIconsCssStyle());
		}

		private Theme OldTheme
		{
			get => (Theme) ViewState[$@"{ID.ToPrefix()}OldTheme"];
			set => ViewState[$@"{ID.ToPrefix()}OldTheme"] = value;
		}

		/// <summary>
		///     The assemblies.
		/// </summary>
		public IEnumerable<Assembly> Assemblies => ResourceProvider.Assemblies;

		/// <summary>
		///     The <see cref="Stream" /> resources in manifests.
		/// </summary>
		public Dictionary<string, object> ManifestResourceStreams => ResourceProvider.Resources;

		/// <summary>
		/// </summary>
		/// <param name="script"></param>
		[Description("")]
		public new static void AddInstanceScript(string script)
		{
			System.Web.HttpContext.Current.Items["Diten.Web.UI.ResourceMgr.InstanceScript"] =
				((StringBuilder) (System.Web.HttpContext.Current.Items["Diten.Web.UI.ResourceMgr.InstanceScript"] ??
				                  new StringBuilder())).Append(script);
		}

		#endregion

		#region Get resources methods

		#region Get general resources methods 

		/// <summary>
		///     Get resource of them path.
		/// </summary>
		/// <param name="resourceName">Name of resource.</param>
		/// <param name="load">Return <see cref="Stream" /> of resource if set to True.</param>
		/// <returns>Path of resource of Page.Theme.</returns>
		public (string Url, string Name, string Script) GetGeneralScriptsResource(string resourceName,
			bool load = false)
		{
			var (url, name, stream) = GetManifestResource($"Diten.Web.UI.Scripts.{resourceName}", load);

			return (url, name, stream.ToString());
		}

		/// <summary>
		///     Get help file path.
		/// </summary>
		/// <param name="control">Type name of web control.</param>
		/// <param name="load">Return <see cref="Stream" /> of resource if set to True.</param>
		/// <returns>
		///     Return [
		///     <list type="bullet">
		///         <see cref="Theme" /> Resource <see cref="string" /> url
		///         <see cref="Theme" /> Resource <see cref="string" /> name
		///         <see cref="Theme" /> Resource <see cref="Stream" />
		///     </list>
		///     ]
		///     of resource of <see cref="Page" />.<see cref="Theme" />.
		/// </returns>
		public (string Url, string Name, Stream Resource) GetHelpResourcePath(Type control, bool load = false)
		{
			return GetManifestResource($"Diten.Web.UI.Helps.{control.ToString().Replace(".", "_")}", load);
		}

		#endregion

		#region Get theme resources methods

		private const string ThemeNameSpace = "Diten.Web.UI.Themes";

		/// <summary>
		///     Get resource of them path.
		/// </summary>
		/// <param name="icon">Icon</param>
		/// <param name="load">Return <see cref="Icon" /> if set to True.</param>
		/// <returns>
		///     Return [
		///     <list type="bullet">
		///         <see cref="Theme" /> Resource <see cref="string" /> url
		///         <see cref="Theme" /> Resource <see cref="string" /> name
		///         <see cref="Theme" /> Resource <see cref="Stream" />
		///     </list>
		///     ]
		///     of resource of <see cref="Page" />.<see cref="Theme" />.
		/// </returns>
		public (string Url, string Name, Stream Icon) GetIconResource(Icons icon, bool load = false)
		{
			return GetThemeResource($@"{icon.GetName()}.png", load);
		}

		/// <summary>
		///     Get resource of them path.
		/// </summary>
		/// <param name="resourceName">Name of resource</param>
		/// <param name="load">Return <see cref="Stream" /> of resource if set to True.</param>
		/// <returns>
		///     Return [
		///     <list type="bullet">
		///         <see cref="Theme" /> Resource <see cref="string" /> url
		///         <see cref="Theme" /> Resource <see cref="string" /> name
		///         <see cref="Theme" /> Resource <see cref="Stream" />
		///     </list>
		///     ]
		///     of resource of <see cref="Page" />.<see cref="Theme" />.
		/// </returns>
		public (string Url, string Name, Stream Resource) GetThemeResource(string resourceName, bool load = false)
		{
			return GetManifestResource(resourceName.ToUpper().Contains(".png".ToUpper())
				? $"{ThemeNameSpace}.{Theme}.Icons.{resourceName}"
				: $"{ThemeNameSpace}.{Theme}.{resourceName}", load);
		}

		/// <summary>
		///     Get general resource path.
		/// </summary>
		/// <param name="resourceName">Name of resource.</param>
		/// <param name="load">Return <see cref="Stream" /> of resource if set to True.</param>
		/// <returns>
		///     Return [
		///     <list type="bullet">
		///         <see cref="Theme" /> Resource <see cref="string" /> url
		///         <see cref="Theme" /> Resource <see cref="string" /> name
		///         <see cref="Theme" /> Resource <see cref="Stream" />
		///     </list>
		///     ]
		///     of resource of <see cref="Page" />.<see cref="Theme" />.
		/// </returns>
		public (string Url, string Name, Stream Resource) GetThemesGeneralResource(string resourceName,
			bool load = false)
		{
			return GetManifestResource($"{ThemeNameSpace}.{resourceName}", load);
		}

		private string GetThemeIconsCssStyle()
		{
			if (ViewState[$@"{ID.ToPrefix()}ThemeIconsCssStyle"] != null && Theme.Equals(OldTheme))
				return ViewState[$@"{ID.ToPrefix()}ThemeIconsCssStyle"].ToString();

			OldTheme = Theme;

			//todo: Remove commented code
			//ViewState[$@"{ID.ToPrefix()}ThemeIconsCssStyle"] = $@"{
			//        Enum.GetNames(typeof(Icons)).Aggregate(string.Empty, (current, item) => current + $@"{item}.png;")
			//            .Split(";".ToCharArray())
			//            .Aggregate(GetManifestResourceStream($@"{ThemeNameSpace}.{Theme}.Icons.css").ToString(),
			//                (current, iconFileName) => current.Replace($@"[{iconFileName}]",
			//                    GetResourcePathAsync($@"{ThemeNameSpace}.{Theme}.Icons.{iconFileName}")))
			//    }";

			return ViewState[$@"{ID.ToPrefix()}ThemeIconsCssStyle"].ToString();
		}

		#endregion

		#region Get base methods

		/// <summary>
		///     Get manifest resource <see cref="Stream" />.
		/// </summary>
		/// <param name="virtualPath">Manifest resource virtual path.</param>
		/// <param name="load">Return <see cref="Stream" /> of resource if set to True.</param>
		/// <returns>
		///     Return [
		///     <list type="bullet">
		///         Resource <see cref="string" /> url
		///         Resource <see cref="string" /> name
		///         Resource <see cref="Stream" />
		///     </list>
		///     ]
		///     of resource of <see cref="Page" />.<see cref="Theme" />.
		/// </returns>
		public (string Url, string Name, Stream Resource) GetManifestResource(string virtualPath, bool load)
		{
			var viewStateId = $@"{ID.ToPrefix()}{virtualPath}{this.GetFrameName().ToSuffix()}";

			ViewState.SetValue(viewStateId,
				Page.ClientScript.GetWebResourceUrl(typeof(ResourceManager),
					$@"~/{Constants.Application.ResourcesPath}/{virtualPath}"));

			return (ViewState[viewStateId].ToString(), virtualPath, load
				? ManifestResourceStreams.ContainsKey(virtualPath)
					? (UnmanagedMemoryStream) ManifestResourceStreams[virtualPath]
					: new Func<string, Stream>(vp =>
						{
							try
							{
								ManifestResourceStreams.Add(vp, new ResourceProvider()
									.GetFile($@"/{Constants.Application.ResourcesPath}/{vp}")
									.Open());
							}
							catch (ArgumentException e)
							{
								e.ToException();
							}

							return (UnmanagedMemoryStream) ManifestResourceStreams[vp];
						})
						.Invoke(virtualPath)
				: null);
		}

		#endregion

		#endregion

		#region Get resource manager instance

		/// <summary>
		///     Get instance of diten resource manager.
		/// </summary>
		/// <param name="context"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <returns>Diten resource manager.</returns>
		[Description("")]
		public new static ResourceManager GetInstance(System.Web.HttpContext context)
		{
			if (context == null)
				return null;

			if (!(context.CurrentHandler is Page))
				return context.Items[typeof(ResourceManager)] as ResourceManager;

			if (((Page) System.Web.HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)] is ResourceManager
				resourceManager)
				return resourceManager;

			return context.Items[typeof(ResourceManager)] as ResourceManager;
		}

		/// <summary>
		/// </summary>
		/// <returns></returns>
		[Description("")]
		public new static ResourceManager GetInstance()
		{
			return GetInstance(System.Web.HttpContext.Current);
		}

		/// <summary>
		/// </summary>
		/// <param name="page"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <returns></returns>
		[Description("")]
		public static ResourceManager GetInstance(Page page)
		{
			if (page == null)
				throw new ArgumentNullException(nameof(page));

			return page.Items[typeof(ResourceManager)] as ResourceManager;
		}

		#endregion
	}
}

//ToDo: Delete commented codes
///// <summary>
///// Get <see cref="string"/> resource from manifest.
///// </summary>
///// <param name="virtualPath">Virtual path of <see cref="string"/> resource in manifest.</param>
///// <returns>An <see cref="string"/> that contains manifest resource data.</returns>
//public (string Url, string Name, string Resource) GetManifestResourceString(string virtualPath)
//{
//    var (url, name, stream) = GetManifestResourceStream(virtualPath);

//    return (url, name, new Func<Stream, string>(delegate(Stream resource)
//    {
//        var holder = new MemoryStream();
//        resource.CopyTo(holder);
//        return Convert.ToString(holder);
//    }).Invoke(stream));
//}

//internal void FireAsyncEvent(string eventName, ParameterCollection extraParams)
//{
//    ComponentDirectEvents directEvents = (ComponentDirectEvents)this.DirectEvents;
//    PropertyInfo property = directEvents.GetType().GetProperty(eventName);
//    if (property.PropertyType != typeof(ComponentDirectEvent))
//        throw new HttpException("The ResourceManager has no listener with name '{0}'".FormatWith((object)eventName));
//    ComponentDirectEvent componentDirectEvent = property.GetValue((object)directEvents, (object[])null) as ComponentDirectEvent;
//    if (componentDirectEvent == null || componentDirectEvent.IsDefault)
//        throw new HttpException("The ResourceManager has no listener with name '{0}' or handler is absent".FormatWith((object)eventName));
//    DirectEventArgs e = new DirectEventArgs(extraParams);
//    //componentDirectEvent.OnEvent(e);
//}

///// <summary>
///// 
///// </summary>
///// <param name="eventArgument"></param>
//[Description("")]
//public new void RaisePostBackEvent(string eventArgument)
//{
//    if (eventArgument.IsEmpty())
//        return; BaseClientID
//    string[] strArray = eventArgument.Split(new string[1]
//    {
//        "|"
//    }, StringSplitOptions.RemoveEmptyEntries);
//    if (strArray.Length != 3)
//        return;
//    AjaxRequestType ajaxRequestType = (AjaxRequestType)Enum.Parse(typeof(AjaxRequestType),
//        strArray[1].Equals("postback") ? "PostBack" : strArray[1].ToCamelCase(), true);
//    string configID = strArray[0];
//    string str1 = strArray[2];
//    if (!Enum.IsDefined(typeof(AjaxRequestType), (object)ajaxRequestType))
//        throw new HttpException("Incorrect ajax request type - {0}".FormatWith((object)ajaxRequestType));
//    Control ctrl = (Control)null;
//    bool flag1 = ajaxRequestType == AjaxRequestType.Custom;
//    bool flag2 = ajaxRequestType == AjaxRequestType.Public;
//    if (!flag1)
//    {
//        if (configID == "-")
//        {
//            ctrl = !flag2 ? (Control)this : (Control)this.Page;
//        }
//        else
//        {
//            ctrl = Diten.Web.UI.ResourceManager.FindControlByConfigID((Control)this.Page, configID, true,
//                (Control)null);
//            if (ctrl == null)
//                throw new HttpException("The control with ID '{0}' not found".FormatWith((object)configID));
//        }
//    }

//    base.RaisePostBackEvent(eventArgument);
//}