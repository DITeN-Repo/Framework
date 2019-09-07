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

using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

#endregion

namespace Diten.DirectoryServices.ActiveDirectory
{
	public class Management
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="username">Username of a user that has privilege to do jobs on Active Directory.</param>
		/// <param name="password">Password of user.</param>
		public Management(string username,
			string password)
		{
			UserName = username;
			Password = password;
		}

		private string Password { get; }

		private string UserName { get; }

		/// <summary>
		///    Create a Trust Relationship.
		/// </summary>
		/// <param name="sourceForestName">Source forest name.</param>
		/// <param name="targetForestName">Target forest name.</param>
		public void CreateTrust(string sourceForestName,
			string targetForestName)
		{
			var sourceForest = Forest.GetForest(new DirectoryContext(
				DirectoryContextType.Forest, sourceForestName,
				UserName, Password));

			var targetForest = Forest.GetForest(new DirectoryContext(
				DirectoryContextType.Forest, targetForestName,
				UserName, Password));

			// create an inbound forest trust

			sourceForest.CreateTrustRelationship(targetForest,
				TrustDirection.Outbound);
		}

		/// <summary>
		///    Delete a Trust Relationship.
		/// </summary>
		/// <param name="sourceForestName">Source forest name.</param>
		/// <param name="targetForestName">Target forest name.</param>
		public void DeleteTrust(string sourceForestName,
			string targetForestName)
		{
			var sourceForest = Forest.GetForest(new DirectoryContext(
				DirectoryContextType.Forest, sourceForestName,
				UserName, Password));

			var targetForest = Forest.GetForest(new DirectoryContext(
				DirectoryContextType.Forest, targetForestName,
				UserName, Password));

			// delete forest trust

			sourceForest.DeleteTrustRelationship(targetForest);
		}

		/// <summary>
		///    Enumerate Domains in the Current Forest.
		/// </summary>
		/// <returns>Domains in current forest.</returns>
		public static ArrayList EnumerateDomains()
		{
			var _return = new ArrayList();

			foreach (Domain objDomain in Forest.GetCurrentForest().Domains)
				_return.Add(objDomain.Name);

			return _return;
		}

		/// <summary>
		///    Enumerate Global Catalogs in the Current Forest
		/// </summary>
		/// <returns></returns>
		public static ArrayList EnumerateGlobalCatalogsDomains()
		{
			var _return = new ArrayList();

			foreach (GlobalCatalog gc in Forest.GetCurrentForest().GlobalCatalogs)
				_return.Add(gc.Name);

			return _return;
		}

		/// <summary>
		///    Enumerate Objects in an OU.
		/// </summary>
		/// <param name="ouDn">
		///    The parameter OuDn is the Organizational Unit distinguished name such as
		///    OU=Users,dc=myDomain,dc=com.
		/// </param>
		/// <returns></returns>
		// ReSharper disable once InconsistentNaming
		public ArrayList EnumerateOU(string ouDn)
		{
			var alObjects = new ArrayList();
			var directoryObject = new DirectoryEntry($"LDAP://{ouDn}", UserName, Password);

			foreach (DirectoryEntry child in directoryObject.Children)
			{
				var childPath = child.Path;
				alObjects.Add(childPath.Remove(0, 7));

				//remove the LDAP prefix from the path

				child.Close();
				child.Dispose();
			}

			directoryObject.Close();
			directoryObject.Dispose();

			return alObjects;
		}
	}
}