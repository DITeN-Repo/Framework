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
// Creation Date: 2019/09/02 7:01 PM

#region Used Directives

using System.IO;
using System.Security.AccessControl;

#endregion

namespace Diten.IO
{
	/// <summary>
	///    Managing directory.
	/// </summary>
	public static class Directory
	{
		/// <summary>
		///    Managing directory in Windows.
		/// </summary>
		public static class Windows
		{
			/// <summary>
			///    Creating directory.
			/// </summary>
			/// <param name="path">Path of directory that must be created.</param>
			/// <returns></returns>
			public static DirectoryInfo CreateDirectory(string path)
			{
				return System.IO.Directory.Exists(path)
					       ? new DirectoryInfo(path)
					       : System.IO.Directory.CreateDirectory(path);
			}

			/// <summary>
			///    Setting full access control to a directory for
			///    <param name="username"></param>
			/// </summary>
			/// <param name="path">The directory for applying permission.</param>
			/// <param name="username">
			///    Username that must have full access to the
			///    <param name="path"></param>
			/// </param>
			public static void SetFullAccessControl(string path,
			                                        string username)
			{
				var directoryInfo = new DirectoryInfo(path);
				var directorySecurity = directoryInfo.GetAccessControl();

				directorySecurity.AddAccessRule(new FileSystemAccessRule($@"{System.Environment.UserDomainName}\{path}",
				                                                         FileSystemRights.FullControl,
				                                                         InheritanceFlags.ObjectInherit,
				                                                         PropagationFlags.None,
				                                                         AccessControlType.Allow));
				directoryInfo.SetAccessControl(directorySecurity);
			}
		}
	}
}