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

using System;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

#endregion

namespace Diten.DirectoryServices.ActiveDirectory
{
	public class Objects
	{
		public enum ObjectClass
		{
			User,
			Group,
			Computer
		}

		public enum ReturnType
		{
			// ReSharper disable once InconsistentNaming
			DistinguishedName,
			ObjectGuid
		}

		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="username">Username of a user that has privilege to do jobs on Active Directory.</param>
		/// <param name="password">Password of user.</param>
		public Objects(string username,
		               string password)
		{
			UserName = username;
			Password = password;
		}

		private string Password {get;}

		private string UserName {get;}

		/// <summary>
		///    Enumerate Multi-String Attribute Values of an Object.
		///    This method includes a recursive flag in case you want to recursively dig up properties of properties such as
		///    enumerating all the member values of a group and then getting each member group's groups all the way up the tree.
		/// </summary>
		/// <param name="attributeName">Name of attribute.</param>
		/// <param name="objectDn">Object Distinguished name.</param>
		/// <param name="valuesCollection">Values collection</param>
		/// <param name="recursive">Read attributes recursively.</param>
		/// <returns>Values collection.</returns>
		public ArrayList AttributeValuesMultiString(string attributeName,
		                                            string objectDn,
		                                            ArrayList valuesCollection,
		                                            bool recursive)
		{
			var ent = new DirectoryEntry(objectDn,
			                             UserName,
			                             Password);
			var valueCollection = ent.Properties[attributeName];
			var en = valueCollection.GetEnumerator();

			while (en.MoveNext())
			{
				if (en.Current == null) continue;
				if (valuesCollection.Contains(en.Current.ToString())) continue;

				valuesCollection.Add(en.Current.ToString());

				if (recursive)
					AttributeValuesMultiString(attributeName,
					                           $@"LDAP://{en.Current}",
					                           valuesCollection,
					                           true);
			}

			ent.Close();
			ent.Dispose();

			return valuesCollection;
		}

		/// <summary>
		///    Enumerate Single String Attribute Values of an Object,
		/// </summary>
		/// <param name="attributeName">Name of attribute.</param>
		/// <param name="objectDn">Object Distinguished name.</param>
		/// <returns>Value of attribute.</returns>
		public string AttributeValuesSingleString(string attributeName,
		                                          string objectDn)
		{
			var ent = new DirectoryEntry(objectDn,
			                             UserName,
			                             Password);
			var strValue = ent.Properties[attributeName].Value.ToString();
			ent.Close();
			ent.Dispose();

			return strValue;
		}

		/// <summary>
		///    Create a New Security Group.
		///    Note: by default if no GroupType property is set, the group is created as a domain security group..
		/// </summary>
		/// <param name="ouPath">Organization unit path.</param>
		/// <param name="name">Name of new group.</param>
		public void CreateGroup(string ouPath,
		                        string name)
		{
			if (!DirectoryEntry.Exists($"LDAP://CN={name},{ouPath}"))
			{
				var group =
					new DirectoryEntry($"LDAP://{ouPath}",
					                   UserName,
					                   Password).Children.Add($"CN={name}",
					                                          "group");

				group.Properties["sAmAccountName"].Value = name;
				group.CommitChanges();
			}
			else { throw new ActiveDirectoryObjectExistsException($" Group [{name}] already exists."); }
		}

		// ReSharper disable once CommentTypo
		/// <summary>
		///    Publish Network Shares in Active Directory.
		/// </summary>
		/// <param name="ldapPath"></param>
		/// <param name="shareName"></param>
		/// <param name="shareUncPath"></param>
		/// <param name="shareDescription"></param>
		/// <example>CreateShareEntry("OU=HOME,dc=baileysoft,dc=com", "Music", @"\\192.168.2.1\Music", "mp3 Server Share");</example>
		public void CreateShareEntry(string ldapPath,
		                             string shareName,
		                             string shareUncPath,
		                             string shareDescription)
		{
			var directoryObject = new DirectoryEntry($"LDAP://{ldapPath}",
			                                         UserName,
			                                         Password);
			var networkShare = directoryObject.Children.Add($"CN={shareName}",
			                                                "volume");

			networkShare.Properties["uNCName"].Value = shareUncPath;
			networkShare.Properties["Description"].Value = shareDescription;
			networkShare.CommitChanges();

			directoryObject.Close();
			networkShare.Close();
		}

		/// <summary>
		///    Delete a group.
		/// </summary>
		/// <param name="ouPath">Organization unit path.</param>
		/// <param name="groupPath">Group pat.</param>
		public void DeleteGroup(string ouPath,
		                        string groupPath)
		{
			if (DirectoryEntry.Exists("LDAP://" + groupPath))
			{
				var entry = new DirectoryEntry($"LDAP://{ouPath}",
				                               UserName,
				                               Password);
				var group = new DirectoryEntry($"LDAP://{groupPath}",
				                               UserName,
				                               Password);

				entry.Children.Remove(group);
				group.CommitChanges();
			}
			else { throw new ActiveDirectoryObjectExistsException($" Group [{groupPath}] doesn't exist."); }
		}

		/// <summary>
		///    Check for the Existence of an Object
		/// </summary>
		/// <param name="objectPath">Path of the object in AD.</param>
		/// <returns>True if object exist.</returns>
		public static bool Exists(string objectPath) { return DirectoryEntry.Exists($"LDAP://{objectPath}"); }

		/// <summary>
		///    Get an Object DistinguishedName.
		///    This method is the glue that ties all the methods together since most all the methods require the consumer to
		///    provide a distinguishedName.
		///    A call to this class might look like:
		/// </summary>
		/// <param name="objectCls"></param>
		/// <param name="returnValue">
		///    This allows the consumers to specify the type of object to search for and whether they want
		///    the distinguishedName returned or the objectGUID.
		/// </param>
		/// <param name="objectName"></param>
		/// <param name="ldapDomain"></param>
		/// <returns>The distinguishedName returned or the objectGUID.</returns>
		/// <example>
		///    myObjectReference.GetObjectDistinguishedName(objectClass.user, returnType.ObjectGUID, "john.q.public",
		///    "contoso.com")
		/// </example>
		public string GetObjectDistinguishedName(ObjectClass objectCls,
		                                         ReturnType returnValue,
		                                         string objectName,
		                                         string ldapDomain)
		{
			var distinguishedName = string.Empty;
			var connectionPrefix = $"LDAP://{ldapDomain}";
			var entry = new DirectoryEntry(connectionPrefix,
			                               UserName,
			                               Password);
			var mySearcher = new DirectorySearcher(entry);

			switch (objectCls)
			{
				case ObjectClass.User:
					mySearcher.Filter =
						$"(&(objectClass=user)(|(cn={objectName})(sAMAccountName={objectName})))";

					break;
				case ObjectClass.Group:
					mySearcher.Filter = $"(&(objectClass=group)(|(cn={objectName})(dn={objectName})))";

					break;
				case ObjectClass.Computer:
					mySearcher.Filter = $"(&(objectClass=computer)(|(cn={objectName})(dn={objectName})))";

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(objectCls),
					                                      objectCls,
					                                      null);
			}

			var result = mySearcher.FindOne();

			if (result == null)
				throw new NullReferenceException(
				                                 $"unable to locate the distinguishedName for the object [{objectName}] in the [{ldapDomain}] domain.");

			var directoryObject = result.GetDirectoryEntry();

			if (returnValue.Equals(ReturnType.DistinguishedName)) distinguishedName = $"LDAP://{directoryObject.Properties["distinguishedName"].Value}";
			if (returnValue.Equals(ReturnType.ObjectGuid)) distinguishedName = directoryObject.Guid.ToString();

			entry.Close();
			entry.Dispose();
			mySearcher.Dispose();

			return distinguishedName;
		}

		/// <summary>
		///    Enumerate an Object's Properties: The Ones with Values
		/// </summary>
		/// <param name="objectDn">Object domain name.</param>
		/// <returns>Array of attribute's names.</returns>
		public ArrayList GetUsedAttributes(string objectDn)
		{
			var props = new ArrayList();

			foreach (string strAttrName in new DirectoryEntry($"LDAP://{objectDn}",
			                                                  UserName,
			                                                  Password).Properties
			                                                           .PropertyNames) props.Add(strAttrName);

			return props;
		}

		/// <summary>
		///    Move an Object from one Location to Another.
		///    It should be noted that the string newLocation should NOT include the CN= value of the object.
		///    The method will pull that from the objectLocation string for you.
		///    So object CN=group,OU=GROUPS,DC=contoso,DC=com is sent in as the objectLocation but the newLocation is something
		///    like: OU=NewOUParent,DC=contoso,DC=com. The method will take care of the CN=group.
		/// </summary>
		/// <param name="objectLocation">Location of object.</param>
		/// <param name="newLocation">New location of object.</param>
		public void Move(string objectLocation,
		                 string newLocation)
		{
			//For brevity, removed existence checks

			var eLocation = new DirectoryEntry($"LDAP://{objectLocation}",
			                                   UserName,
			                                   Password);
			var nLocation = new DirectoryEntry($"LDAP://{newLocation}",
			                                   UserName,
			                                   Password);
			var newName = eLocation.Name;

			eLocation.MoveTo(nLocation,
			                 newName);
			nLocation.Close();
			eLocation.Close();
		}
	}
}