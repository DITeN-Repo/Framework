#region DITeN Registration Info

// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 9:12 PM

#endregion

#region Used Directives

using System.IO;
using Diten.Diagnostics;
using Diten.Parameters;
using Microsoft.Web.Administration;

#endregion

namespace Diten.Win32
{
	public static class TaskScheduler
	{
		// ReSharper disable once InconsistentNaming
		public static void AddIISLogParser(Site site,
			string username,
			string password)
		{
			//ToDo: The code must be controlled for logical mistakes.
			throw new NotImplementedException();
			//    SchedulerResponse response = WindowTaskScheduler
			//        .Configure()
			//        .CreateTask($"IIS log parse for [{site.Name}]", $@"C:\Program Files(x86)\Log Parser 2.2\ImportIISLogs.bat W3SVC{site.Id} C:\inetpub\logs\LogFiles\W3SVC{site.Id}")
			//        .RunDaily()
			//        .RunEveryXMinutes(24 * 60)
			//        .SetStartDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
			//        .SetStartTime(new TimeSpan(0, 0, 0))
			//        .Execute();

			//var ff = response.IsSuccess;
			var basePath = Environment.SpecialFolders.ApplicationData;
			//$@"{Environment.SpecialFolders.CommonTemplates}";
			var xmlFilePath = $@"{basePath}\ImportIISLogsTask.xml";
			var batchFilePath = $@"{basePath}\ImportIISLogs.bat";

			if (!File.Exists(xmlFilePath))
				File.WriteAllText(xmlFilePath, Resources.Manifest000
					.Replace("%SiteName%", site.Name)
					.Replace("%UserId%", SystemParams.Default.ScheduledTasksUser)
					.Replace("%Command%", $"{batchFilePath}")
					.Replace("%Arguments%",
						$"{site.Id} \"{site.LogFile.Directory}\""));

			if (!File.Exists(batchFilePath))
				File.WriteAllText(batchFilePath, Resources.Script000);

			Process.ExecuteCommand(
				SystemParams.Default.CMDTaskScheduler.Format(SystemParams.Default.ScheduledTasksUser,
					SystemParams.Default.ScheduledTasksUserPassword, site.Name, xmlFilePath), username, password);
		}
	}
}