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
// Creation Date: 2019/07/30 4:59 PM

#endregion

#region Used Directives

using System;
using System.Collections;
using System.DirectoryServices;
using Microsoft.AspNetCore.Http;

#endregion

namespace Diten.DirectoryServices.ActiveDirectory
{
	public class UsersTasks
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="username">Username of a user that has privilege to do jobs on Active Directory.</param>
		/// <param name="password">Password of user.</param>
		public UsersTasks(string username,
			string password)
		{
			UserName = username;
			Password = password;
		}

		private string Password { get; }

		private string UserName { get; }

		/// <summary>
		///    Add User to Group.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="groupDn">Group distinguished name.</param>
		public void AddToGroup(string userDn,
			string groupDn)
		{
			var dirEntry = new DirectoryEntry($"LDAP://{groupDn}", UserName, Password);
			dirEntry.Properties["member"].Add(userDn);
			dirEntry.CommitChanges();
			dirEntry.Close();
		}

		/// <summary>
		///    Authenticate a User Against the Directory.
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="domain"></param>
		/// <returns>True if user is authenticated.</returns>
		private bool Authenticate(string userName,
			string password,
			string domain)
		{
			var authentic = false;

			try
			{
				var nativeObject = new DirectoryEntry($"LDAP://{domain}", userName, password).NativeObject;
				authentic = true;
			}
			catch (DirectoryServicesCOMException)
			{
			}

			return authentic;
		}

		/// <summary>
		///    Create User Account.
		/// </summary>
		/// <param name="ldapPath">LDAP path.</param>
		/// <param name="userName">Username</param>
		/// <param name="userPassword">Password of user.</param>
		/// <param name="principalName">
		///    Principal name of user.
		///    <example>user@domain.local</example>
		/// </param>
		/// <param name="displayName">Display name.</param>
		/// <param name="description">Description.</param>
		/// <param name="fullName">Fullname of user.</param>
		/// <returns>GUID of user.</returns>
		public Guid CreateUserAccount(string ldapPath,
			string userName,
			string userPassword,
			string principalName = "",
			string displayName = "",
			string description = "",
			string fullName = "")
		{
			var dirEntry = new DirectoryEntry($"LDAP://{ldapPath}", UserName, Password);
			var newUser = dirEntry.Children.Add($"CN={userName}", "user");

			newUser.Properties["samAccountName"].Value = userName;
			newUser.Properties["displayName"].Add(displayName);
			newUser.Invoke("SetPassword", userPassword);
			newUser.Properties["userPrincipalName"].Add(principalName);
			newUser.Properties["FullName"].Add(fullName);
			newUser.Invoke("Put", "Description", description);
			newUser.CommitChanges();

			var _return = newUser.Guid;

			dirEntry.Close();
			newUser.Close();

			return _return;
		}

		/// <summary>
		///    Disable a User Account.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		public void Disable(string userDn)
		{
			var user = new DirectoryEntry(userDn, UserName, Password);
			var val = (int) user.Properties["userAccountControl"].Value;
			user.Properties["userAccountControl"].Value = val | 0x2;

			//ADS_UF_ACCOUNTDISABLE;

			user.CommitChanges();
			user.Close();
		}

		/// <summary>
		///    Disable a User Flag.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="userFlag">User flag.</param>
		public void DisableUserFlag(string userDn,
			UserFlags userFlag)
		{
			var user = new DirectoryEntry(userDn, UserName, Password);
			var val = (int) user.Properties["userAccountControl"].Value;
			user.Properties["userAccountControl"].Value = val | (int) userFlag;

			//ADS_UF_NORMAL_ACCOUNT;

			user.CommitChanges();
			user.Close();
		}

		/// <summary>
		///    Enable a User Account.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		public void Enable(string userDn)
		{
			var user = new DirectoryEntry(userDn, UserName, Password);
			var val = (int) user.Properties["userAccountControl"].Value;
			user.Properties["userAccountControl"].Value = val & ~0x2;

			//ADS_UF_NORMAL_ACCOUNT;

			user.CommitChanges();
			user.Close();
		}

		/// <summary>
		///    Enable a User Flag.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="userFlag">User flag.</param>
		public void EnableUserFlag(string userDn,
			UserFlags userFlag)
		{
			var user = new DirectoryEntry(userDn, UserName, Password);
			var val = (int) user.Properties["userAccountControl"].Value;

			user.Properties["userAccountControl"].Value = val & (int) ~userFlag;

			//ADS_UF_NORMAL_ACCOUNT;

			user.CommitChanges();
			user.Close();
		}


		/// <summary>
		///    Get User Group Memberships of the Logged in User from ASP.NET.
		/// </summary>
		/// <returns>Groups list.</returns>
		public ArrayList GetGroups()
		{
			var groups = new ArrayList();
			typeof(HttpContext).

			if (HttpContext.Current.Request.LogonUserIdentity == null)
				return groups;
			if (HttpContext.Current.Request.LogonUserIdentity.Groups == null)
				return groups;

			foreach (var group in HttpContext.Current.Request.LogonUserIdentity.Groups)
				groups.Add(group.Translate(typeof(NTAccount)).ToString());

			return groups;
		}

		/// <summary>
		///    Get User Group Memberships.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="recursive">Get groups recursively</param>
		/// <returns>Array list of user group.</returns>
		public ArrayList GetGroups(string userDn,
			bool recursive)
		{
			var groupMemberships = new ArrayList();

			return new Objects(UserName, Password).AttributeValuesMultiString("memberOf", userDn, groupMemberships,
				recursive);
		}

		/// <summary>
		///    Lock a User Account.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		public void Lock(string userDn)
		{
			var uEntry = new DirectoryEntry(userDn, UserName, Password);

			uEntry.Properties["LockOutTime"].Value = 1; //unlock account
			uEntry.CommitChanges(); //may not be needed but adding it anyways
			uEntry.Close();
		}

		/// <summary>
		///    Remove User from Group.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="groupDn">Group distinguished name.</param>
		public void RemoveUserFromGroup(string userDn,
			string groupDn)
		{
			var dirEntry = new DirectoryEntry($"LDAP://{groupDn}", UserName, Password);
			dirEntry.Properties["member"].Remove(userDn);
			dirEntry.CommitChanges();
			dirEntry.Close();
		}

		/// <summary>
		///    Rename an Object.
		/// </summary>
		/// <param name="objectDn">Object distinguished name.</param>
		/// <param name="newName">New name.</param>
		public void Rename(string objectDn,
			string newName)
		{
			new DirectoryEntry($"LDAP://{objectDn}", UserName, Password).Rename("CN=" + newName);
		}

		/// <summary>
		///    Reset a User Password.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		/// <param name="password">Password.</param>
		public void ResetPassword(string userDn,
			string password)
		{
			var uEntry = new DirectoryEntry(userDn, UserName, Password);

			uEntry.Invoke("SetPassword", password);
			uEntry.Properties["LockOutTime"].Value = 0; //unlock account

			uEntry.Close();
		}

		/// <summary>
		///    Unlock a User Account.
		/// </summary>
		/// <param name="userDn">user distinguished name.</param>
		public void Unlock(string userDn)
		{
			var uEntry = new DirectoryEntry(userDn, UserName, Password);

			uEntry.Properties["LockOutTime"].Value = 0; //unlock account
			uEntry.CommitChanges(); //may not be needed but adding it anyways
			uEntry.Close();
		}
	}
}