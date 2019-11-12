#region Using Directives

using System;
using System.Drawing;
using Diten.Collections.Generic;
using Diten.ExtensionMethods;
using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Web.App
{
	/// <summary>
	///     The global.
	/// </summary>
	public class Global : HttpApplication
	{
		public Dictionary<Icons, Bitmap> ApplicationIcons { get; set; }

		/// <summary>
		///     Application authenticate request method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application begin request method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application end handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Application_End(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Application error handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Application_Error(object sender, EventArgs e)
		{
			// Log an exception using HttpContext.Current to get a Web request processing helper  
			HttpContext.Current.Server.GetLastError().ToException();
		}

		/// <summary>
		///     Application start method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Application_Start(object sender, EventArgs e)
		{
#if !DEBUG
            HostingEnvironment.RegisterVirtualPathProvider(new ResourceProvider());
#endif
			ApplicationIcons = new Dictionary<Icons, Bitmap>();
		}

		/// <summary>
		///     Session end handler method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Session_End(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Session start method.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		protected new void Session_Start(object sender, EventArgs e)
		{
		}
	}
}