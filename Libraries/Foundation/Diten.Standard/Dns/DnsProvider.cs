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
// Creation Date: 2019/09/02 8:55 PM

#endregion

#region Used Directives

using System.Management;
using Diten.Parameters;

#endregion

namespace Diten.Dns
{
	public class DnsProvider
	{
		public DnsProvider(string serverName,
			string userName,
			string password)
		{
			Server = serverName;
			User = userName;
			_password = password;
			Logon();
			Initialize();
		}

		private void Initialize()
		{
		}

		private void Logon()
		{
			NameSpace = SystemParams.Default.Microsoft_DNS.Format(Server);

			var con = new ConnectionOptions
			{
				Username = User,
				Password = _password,
				Impersonation = ImpersonationLevel.Impersonate
			};

			_session = new ManagementScope(NameSpace) {Options = con};
			_session.Connect();
		}

		#region Members

		private ManagementScope _session;
		public string Server;
		public string User;
		private readonly string _password;

		#endregion

		#region Methods

		public void Dispose()
		{
		}

		public void Dispose(ref ManagementClass x)
		{
			if (x == null)
				return;
			x.Dispose();
			x = null;
		}

		public void Dispose(ref ManagementBaseObject x)
		{
			if (x == null)
				return;
			x.Dispose();
			x = null;
		}

		public bool DomainExists(string domainName)
		{
			var retval = false;
			var wql = "SELECT *";
			wql += " FROM MicrosoftDNS_ATYPE";
			wql += " WHERE OwnerName = '" + domainName + "'";
			var q = new ObjectQuery(wql);
			var s = new ManagementObjectSearcher(_session, q);
			var col = s.Get();

			foreach (var unused in col)
				retval = true;

			return retval;
		}

		public void AddDomain(string domainName,
			string ipDestination)
		{
			//check if domain already exists
			if (DomainExists(domainName))
				throw new Exception("The domain you are trying to add already exists on this server!");

			//generate zone
			var man = Manage("MicrosoftDNS_Zone");
			ManagementBaseObject ret = null;
			var obj = man.GetMethodParameters("CreateZone");
			obj["ZoneName"] = domainName;
			obj["ZoneType"] = 0;

			//invoke method, dispose unneccesary vars
			man.InvokeMethod("CreateZone", obj, null);
			Dispose(ref obj);
			Dispose(ref ret);
			Dispose(ref man);

			//add rr containing the ip destination
			AddARecord(domainName, null, ipDestination);
		}

		public void RemoveDomain(string domainName)
		{
			var wql = "SELECT *";
			wql += " FROM MicrosoftDNS_Zone";
			wql += " WHERE Name = '" + domainName + "'";
			var q = new ObjectQuery(wql);
			var s = new ManagementObjectSearcher(_session, q);
			var col = s.Get();

			foreach (var managementBaseObject in col)
			{
				var o = (ManagementObject) managementBaseObject;
				o.Delete();
			}
		}

		public void AddARecord(string domain,
			string recordName,
			string ipDestination)
		{
			if (DomainExists(recordName + "." + domain))
				throw new Exception("That record already exists!");
			var man = new ManagementClass(_session, new ManagementPath("MicrosoftDNS_ATYPE"), null);
			var vars = man.GetMethodParameters("CreateInstanceFromPropertyData");
			vars["DnsServerName"] = Server;
			vars["ContainerName"] = domain;
			if (recordName == null)
				vars["OwnerName"] = domain;
			else
				vars["OwnerName"] = recordName + "." + domain;
			vars["IPAddress"] = ipDestination;
			man.InvokeMethod("CreateInstanceFromPropertyData", vars, null);
		}

		public void RemoveARecord(string domain,
			string aRecord)
		{
			var wql = "SELECT *";
			wql += " FROM MicrosoftDNS_ATYPE";
			wql += " WHERE OwnerName = '" + aRecord + "." + domain + "'";
			var q = new ObjectQuery(wql);
			var s = new ManagementObjectSearcher(_session, q);
			var col = s.Get();

			foreach (var managementBaseObject in col)
			{
				var o = (ManagementObject) managementBaseObject;
				o.Delete();
			}
		}

		#endregion

		#region Properties

		public string NameSpace { get; private set; }

		public bool Enabled
		{
			get
			{
				const bool retval = false;

				try
				{
					var wql = new SelectQuery {QueryString = ""};
				}
				catch
				{
					// ignored
				}

				return retval;
			}
		}

		public ManagementClass Manage(string path)
		{
			//ManagementClass retval=new ManagementClass(path);
			var retval = new ManagementClass(_session, new ManagementPath(path), null);

			return retval;
		}

		#endregion
	}
}