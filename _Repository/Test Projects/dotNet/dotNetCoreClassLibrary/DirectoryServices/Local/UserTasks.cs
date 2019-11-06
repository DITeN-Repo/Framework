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
// Creation Date: 2019/07/30 4:59 PM

#region Used Directives

using System;
using System.DirectoryServices.AccountManagement;

#endregion

namespace Diten.DirectoryServices.Local
{
	public class UserTasks: PrincipalContext
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="username">Username of a user that has privilege to do jobs on local machine.</param>
		/// <param name="password">Password of user.</param>
		public UserTasks(string username,
		                 string password): base(ContextType.Machine,
		                                        Environment.MachineName,
		                                        null,
		                                        ContextOptions.SimpleBind,
		                                        username,
		                                        password) {}

		/// <summary>
		///    Create User Account.
		/// </summary>
		/// <param name="username">Username</param>
		/// <param name="password">Password of user.</param>
		/// <param name="description">Description.</param>
		/// <param name="displayName">Fullname of user.</param>
		/// <returns>GUID of user.</returns>
		public void CreateUserAccount(string username,
		                              string password,
		                              string description = "",
		                              string displayName = "")
		{
			var user = new UserPrincipal(this,
			                             username,
			                             password,
			                             true)
			{
				DisplayName = displayName,
				Name = username,
				Description = description,
				UserCannotChangePassword = true,
				PasswordNeverExpires = true
			};

			user.Save();

			//now add user to "Users" group so it displays in Control Panel
			var group = GroupPrincipal.FindByIdentity(this,
			                                          "Users");

			if (group == null) return;
			group.Members.Add(user);
			group.Save();
		}
	}
}