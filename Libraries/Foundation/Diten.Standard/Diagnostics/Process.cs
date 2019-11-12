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
// Creation Date: 2019/08/15 5:06 PM

#region Used Directives

using System.Diagnostics;
using System.Security;

#endregion

namespace Diten.Diagnostics
{
	public static class Process
	{
		public static void ExecuteCommand(System.String command,
		                                  string username,
		                                  string password)
		{
			var secureString = new SecureString();

			foreach (var ch in password) secureString.AppendChar(ch);

			new System.Diagnostics.Process
			{
				StartInfo = new ProcessStartInfo
				{
					UserName = username,
					Password = secureString,
					WindowStyle = ProcessWindowStyle.Normal,
					FileName = "cmd.exe",
					Arguments = $@"/C {command}"
				}
			}.Start();
		}
	}
}