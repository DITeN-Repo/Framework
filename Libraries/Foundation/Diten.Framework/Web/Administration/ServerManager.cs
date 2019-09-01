#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:51 AM

#endregion

#region Used Directives

using System.Diagnostics.CodeAnalysis;
using Diten.Diagnostics;
using Microsoft.Web.Administration;

#endregion

namespace Diten.Web.Administration
{
	/// <summary>
	///    The server manager.
	/// </summary>
	public static class ServerManager
	{
		/// <summary>
		///    The sites.
		/// </summary>
		public static SiteCollection Sites => new Microsoft.Web.Administration.ServerManager().Sites;

		/// <summary>
		///    The change web site logging to odbc.
		/// </summary>
		/// <param name="site">
		///    The site.
		/// </param>
		/// <param name="odbcDataSource">
		///    The odbc data source.
		/// </param>
		/// <param name="username">
		///    The username.
		/// </param>
		/// <param name="password">
		///    The password.
		/// </param>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
			Justification = "Reviewed. Suppression is OK here.")]
		public static void ChangeWebSiteLoggingToOdbc(
			Site site,
			string odbcDataSource,
			string username,
			string password)
		{
			var system32FolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.SystemX86);
			Process.ExecuteCommand(
				$"{system32FolderPath}\\inetsrv\\appcmd.exe set config -section:ODBCLogging -datasource:\"{odbcDataSource}\" " +
				$"-tableName:\"InternetLog\" -username:\"{username}\" -password:\"{password}\"",
				Resources.SysAdminUser,
				Resources.SysAdminUserPassword);
			Process.ExecuteCommand(
				$"{system32FolderPath}\\inetsrv\\appcmd.exe set sites \"{site.Name}\" -logFile.logFormat:\"Custom\" " +
				"-logFile.customLogPluginClsid:\"{FF16065B-DE82-11CF-BC0A-00AA006111E0}\"",
				Resources.SysAdminUser,
				Resources.SysAdminUserPassword);
		}
	}
}