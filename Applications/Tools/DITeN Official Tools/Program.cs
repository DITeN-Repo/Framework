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
// Creation Date: 2019/09/05 1:12 AM

#region Used Directives

using System;
using System.Windows.Forms;
using Diten.Windows.Applications.Tools.Official.Bookmarks;
using Diten.Windows.Applications.Tools.Official.Temp;

#endregion

namespace Diten.Windows.Applications.Tools.Official
{
	internal static class Program
	{
		/// <summary>
		///    The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormBookmarksOptimizer());
			//Application.Run(new FormTest());
		}
	}
}