#region Using Directives

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.Hosting;
using Diten.Variables;

#endregion

// ReSharper disable UnusedMember.Global

namespace Diten.Web
{
	public class HttpApplication : System.Web.HttpApplication
	{
		public static List<string> Sessions { get; set; }

		/// <summary>
		///     Application error handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Application_Error(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application authenticate request method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application begin request method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application end handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Application_End(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application start method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Application_Start(object sender, EventArgs e)
		{
			HostingEnvironment.RegisterVirtualPathProvider(new ResourceProvider());
			Sessions = new List<string>();
			//todo: Remove commented codes.
			//System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new AssemblyResourceProvider());
			if (!Directory.Exists(Constants.Local.TempFolderPath))
				Directory.CreateDirectory(Constants.Local.TempFolderPath);

			if (!Directory.Exists(Constants.Local.CacheFolderPath))
				Directory.CreateDirectory(Constants.Local.CacheFolderPath);

			//Application[Diten.Variables.Constants.ApplicationDictionary] = Data.Helpers.Dictionary.GetApplicationDictionary();
			//Application[Diten.Variables.Constants.ApplicationSystemCultureId] = Data.Helpers.Cultures.GetSystemCultureId();
		}

		/// <summary>
		///     Session start method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Session_Start(object sender, EventArgs e)
		{
			//base.Session_Start(sender, e);
			Session["SessionCultureName"] = new CultureInfo("en-US").DisplayName;

			if (!Sessions.Contains(Session.SessionID))
				Sessions.Add(Session.SessionID);
		}

		/// <summary>
		///     Session end handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected void Session_End(object sender, EventArgs e)
		{
			if (Sessions.Contains(Session.SessionID))
				Sessions.Remove(Session.SessionID);
			//todo: Remove commented codes.

			//base.Session_End(sender, e);
			//var folderPath = Server.MapPath($@"~/TEMP/Session_{Sha1.Encrypt(Md5.Encrypt(((HttpSessionState)sender).SessionID))}");

			//if (!Directory.Exists(folderPath))
			//    Directory.Delete(folderPath);
		}
	}
}