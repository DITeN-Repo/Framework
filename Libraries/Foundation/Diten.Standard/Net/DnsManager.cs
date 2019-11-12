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
// Creation Date: 2019/08/16 12:20 AM

#region Used Directives

using System;
using System.Linq;
using System.Management;
using System.Net;
using Diten.Collections.Generic;

#endregion

namespace Diten.Net
{
	#region Example usage code

	internal class Program
	{
		private static void Main(System.String[] args)
		{
			Console.Write("Connecting to the DNS Server...");
			var d = new Dns("vex.nullify.net"); //my internal DNS Server, change to yours.

			//You will need to be able to get to it using WMI.
			Console.WriteLine("Connected to the DNS Server");

			Console.Write("Creating a new zone as a test...");

			try
			{
				d.CreateNewZone("testzone.uk.nullify.net.",
				                Dns.NewZoneType.Primary);
				Console.WriteLine("OK");
			}
			catch (Exception) { Console.WriteLine("Failed to create a new zone, it probably exists."); }

			Console.Write("Creating a DNS record as a test...");

			try
			{
				d.CreateDnsRecord("testzone.uk.nullify.net.",
				                  "test1.testzone.uk.nullify.net. IN CNAME xerxes.nullify.net.");
				Console.WriteLine("OK");
			}
			catch (Exception) { Console.WriteLine("Failed to create a new resource record, it probably exists"); }

			Console.WriteLine("Getting a list of domains:");

			foreach (var domain in d.GetListOfDomains())
			{
				Console.WriteLine(@"	" + domain.Name + @" (" + domain.ZoneType + ")");

				//and a list of all the records in the domain:-
				foreach (var record in d.GetRecordsForDomain(domain.Name)) Console.WriteLine(@"		" + record);
			}

			Console.WriteLine("Fetching existing named entry (can be really slow, read the warning):-");
			var records = d.GetExistingDnsRecords("test1.testzone.uk.nullify.net.");

			foreach (var record in records)
			{
				Console.WriteLine("\t\t" + record);
				record.Target = "shodan.nullify.net.";
				record.SaveChanges();
			}
		}
	}

	#endregion

	#region Real code

	/// <summary>
	///    A Microsoft DNS Server class that abstracts out calls to WMI for MS DNS Server
	/// </summary>
	/// <remarks>
	///    WMI Documentation:
	///    http://msdn.microsoft.com/en-us/library/ms682123(VS.85).aspx
	///    System.Management Documentation:
	///    http://msdn.microsoft.com/en-us/library/system.management.managementobjectcollection%28VS.71%29.aspx
	/// </remarks>
	public class Dns
	{
		/// <summary>
		///    Create a new DNS Server connection
		/// </summary>
		/// <param name="server">The hostname, IP or FQDN of a DNS server you have access to with the current credentials</param>
		public Dns(System.String server)
		{
			var co = new ConnectionOptions();
			_scope = new ManagementScope($@"\\{server}\Root\MicrosoftDNS",
			                             co);
			_scope.Connect(); //no disconnect method appears to exist so we do not need to manage the 

			//persistence of this connection and tidy up
		}

		/// <summary>
		///    Create a new DNS Server connection
		/// </summary>
		/// <param name="server">The hostname, IP or FQDN of a DNS server you have access to with the current credentials</param>
		/// <param name="username">The username to connect with</param>
		/// <param name="password">The users password</param>
		public Dns(System.String server,
		           string username,
		           string password)
		{
			var co = new ConnectionOptions
			{
				Username = username,
				Password = password,
				Impersonation = ImpersonationLevel.Impersonate
			};
			_scope = new ManagementScope($@"\\{server}\Root\MicrosoftDNS",
			                             co);
			_scope.Connect();
		}

		/// <summary>
		///    The server this connection applies to
		/// </summary>
		public System.String Server {get;} = "";

		private readonly ManagementScope _scope;

		/// <summary>
		///    Create a new DNS host record
		/// </summary>
		/// <param name="zone"></param>
		/// <param name="bindStyleHostEntry"></param>
		/// <returns></returns>
		public void CreateDnsRecord(System.String zone,
		                            string bindStyleHostEntry)
		{
			try
			{
				ManagementObject mc = new ManagementClass(_scope,
				                                          new ManagementPath("MicrosoftDNS_ResourceRecord"),
				                                          null);
				mc.Get();
				var parameters = mc.GetMethodParameters("CreateInstanceFromTextRepresentation");
				parameters["ContainerName"] = zone;
				parameters["DnsServerName"] = Server;
				parameters["TextRepresentation"] = bindStyleHostEntry;

				//ManagementBaseObject createdEntry = mc.InvokeMethod("CreateInstanceFromTextRepresentation", parameters, null);
				//return createdEntry; (no reason unless you changed your mind and wanted to delete it?!)
			}
			catch (ManagementException) //the details on this exception appear useless.
			{
				throw new ApplicationException("Unable to create the record " +
				                               bindStyleHostEntry +
				                               ", please check" +
				                               " the format and that it does not already exist.");
			}
		}

		/// <summary>
		///    Create a new DNS host record
		/// </summary>
		/// <param name="zone"></param>
		/// <param name="record"></param>
		public void CreateDnsRecord(System.String zone,
		                            DnsRecord record)
		{
			CreateDnsRecord(zone,
			                record.ToString());
		}

		/// <summary>
		///    Create a new zone in MS DNS Server
		/// </summary>
		/// <param name="zoneName">The zone to create</param>
		/// <param name="zoneType">The type of zone to create</param>
		/// <returns>The domain</returns>
		public DnsDomain CreateNewZone(System.String zoneName,
		                               NewZoneType zoneType)
		{
			try
			{
				ManagementObject mc = new ManagementClass(_scope,
				                                          new ManagementPath("MicrosoftDNS_Zone"),
				                                          null);
				mc.Get();
				var parameters = mc.GetMethodParameters("CreateZone");

				/*
				[in]            string ZoneName,
				[in]            uint32 ZoneType,
				[in]            boolean DsIntegrated,   (will always be false for us, if you need AD integration you will need to change this.
				[in, optional]  string DataFileName,
				[in, optional]  string IpAddr[],
				[in, optional]  string AdminEmailName,
				*/

				parameters["ZoneName"] = zoneName;
				parameters["ZoneType"] = (uint) zoneType;
				parameters["DsIntegrated"] = 0; //false
				var createdEntry = mc.InvokeMethod("CreateZone",
				                                   parameters,
				                                   null);
				var dnsDomain = new DnsDomain(zoneName,
				                              createdEntry,
				                              this);

				return dnsDomain;
			}
			catch (ManagementException)

				//returns generic error when it already exists, I'm guessing this is a generic answer!
			{
				throw new ApplicationException("Unable to create the zone " +
				                               zoneName +
				                               ", please check " +
				                               "the format of the name and that it does not already exist.");
			}
		}

		/// <summary>
		///    Fetch DNS records for a particular name
		///    WARNING: This method has performance issues, iterate over the results of getting all the records for a domain
		///    instead.
		/// </summary>
		/// <remarks>
		///    Returns a collection as one hostname/entry can have multiple records but it can take longer
		///    than getting all the records and scanning them!
		/// </remarks>
		/// <param name="hostName">The name to look up</param>
		/// <returns></returns>
		public DnsRecord[] GetExistingDnsRecords(System.String hostName)
		{
			var query = $"SELECT * FROM MicrosoftDNS_ResourceRecord WHERE OwnerName='{hostName}'";
			var searcher = new ManagementObjectSearcher(_scope,
			                                            new ObjectQuery(query));

			var managementObjectCollection = searcher.Get();

			return (from ManagementObject p in managementObjectCollection
			        select new DnsRecord(p)).ToArray();
		}

		public static List<IPAddress> GetHostAddresses(System.String hostName)
		{
			var _return = new List<IPAddress>();

			_return.AddRange(System.Net.Dns.GetHostAddresses(hostName)
			                       .Select(hostAddress => IPAddress.Parse(hostAddress.ToString())));

			return _return;
		}

		/// <summary>
		///    Get host name of the IP address.
		/// </summary>
		/// <param name="ip">IP address.</param>
		/// <returns>Host name.</returns>
		public static System.String GetHostName(IPAddress ip)
		{
			var hostName = "HostName";

			return System.Net.Dns
			             .EndGetHostEntry(System.Net.Dns.BeginGetHostEntry(ip,
			                                                               GetHostName,
			                                                               hostName))
			             .HostName;
		}

		/// <summary>
		///    Get host async callback.
		/// </summary>
		/// <param name="ar">Async result.</param>
		private static void GetHostName(IAsyncResult ar) {}

		/// <summary>
		///    Return a list of domains managed by this instance of MS DNS Server
		/// </summary>
		/// <returns></returns>
		public DnsDomain[] GetListOfDomains()
		{
			var mc = new ManagementClass(_scope,
			                             new ManagementPath("MicrosoftDNS_Zone"),
			                             null);
			mc.Get();
			var collection = mc.GetInstances();

			return
				(from ManagementObject p in collection
				 select new DnsDomain(p["ContainerName"].ToString(),
				                      p,
				                      this))
				.ToArray();
		}

		public static List<IPAddress> GetLocalIpAddresses() { return GetHostAddresses(System.Net.Dns.GetHostName()); }

		/// <summary>
		///    Return a list of records for a domain, note that it may include records
		///    that are stubs to other domains inside the zone and does not automatically
		///    recurse.
		/// </summary>
		/// <param name="domain">The domain to connect to</param>
		/// <returns></returns>
		public DnsRecord[] GetRecordsForDomain(System.String domain)
		{
			var query = $"SELECT * FROM MicrosoftDNS_ResourceRecord WHERE DomainName='{domain}'";
			var searcher = new ManagementObjectSearcher(_scope,
			                                            new ObjectQuery(query));

			var collection = searcher.Get();

			return (from ManagementObject p in collection
			        select new DnsRecord(p)).ToArray();
		}

		public override string ToString() { return Server; }

		#region Supporting classes

		/// <summary>
		///    Different types of DNS zone in MS DNS Server
		/// </summary>
		public enum ZoneType
		{
			DsIntegrated,
			Primary,
			Secondary
		}

		/// <summary>
		///    Different types of DNS zone in MS DNS Server
		/// </summary>
		/// <remarks>For creation of new zones the list is different</remarks>
		public enum NewZoneType
		{
			Primary,
			Secondary,

			/// <remarks>Server 2003+ only</remarks>
			Stub,

			/// <remarks>Server 2003+ only</remarks>
			Forwarder
		}

		/// <summary>
		///    A zone in MS DNS Server
		/// </summary>
		public class DnsDomain
		{
			/// <summary>
			///    Create a DNS zone
			/// </summary>
			/// <param name="name">The name of the DNS zone</param>
			/// <param name="wmiObject">The object that represents it in MS DNS server</param>
			/// <param name="server">The DNS Server it is to be managed by</param>
			public DnsDomain(System.String name,
			                 ManagementBaseObject wmiObject,
			                 Dns server)
			{
				Name = name;
				_wmiObject = wmiObject;
				_server = server;
			}

			/// <summary>
			///    The name of the DNS zone
			/// </summary>
			public System.String Name {get; set;}

			/// <summary>
			///    Is this a reverse DNS zone?
			/// </summary>
			public Boolean ReverseZone => _wmiObject["Reverse"].ToString() == "1";

			/// <summary>
			///    The zone type
			/// </summary>
			public ZoneType ZoneType => (ZoneType) System.Convert.ToInt32(_wmiObject["ZoneType"]);

			private readonly Dns _server;

			private readonly ManagementBaseObject _wmiObject;

			/// <summary>
			///    Create a new DNS host record
			/// </summary>
			/// <param name="record">The record to create</param>
			public void CreateDnsRecord(DnsRecord record)
			{
				_server.CreateDnsRecord(Name,
				                        record.ToString());
			}

			/// <summary>
			///    Get a list of all objects at the base of this zone
			/// </summary>
			/// <returns>A list of <see cref="DnsRecord" /></returns>
			public DnsRecord[] GetAllRecords() { return _server.GetRecordsForDomain(Name); }

			public override string ToString() { return Name; }
		}

		/// <summary>
		///    An entry in a zone
		/// </summary>
		public class DnsRecord
		{
			/// <summary>
			///    Create an class wrapping a DNS record
			///    Defaults to 1 hour TTL
			/// </summary>
			/// <param name="domain"></param>
			/// <param name="recordType"></param>
			/// <param name="target"></param>
			public DnsRecord(System.String domain,
			                 DnsRecordType recordType,
			                 string target):
				this(domain,
				     recordType,
				     target,
				     new TimeSpan(1,
				                  0,
				                  0)) {}

			/// <summary>
			///    Create an class wrapping a DNS record
			/// </summary>
			/// <param name="domain"></param>
			/// <param name="recordType"></param>
			/// <param name="target"></param>
			/// <param name="ttl"></param>
			public DnsRecord(System.String domain,
			                 DnsRecordType recordType,
			                 string target,
			                 TimeSpan ttl)
			{
				DomainHost = domain;
				Ttl1 = ttl;
				Target = target;
				RecordType = recordType;
			}

			/// <summary>
			///    Create an class wrapping a DNS record
			/// </summary>
			/// <param name="wmiObject"></param>
			public DnsRecord(ManagementObject wmiObject)
			{
				_wmiObject = wmiObject;
				DomainHost = wmiObject["OwnerName"].ToString();
				Target = wmiObject["RecordData"].ToString();
				var recordParts = wmiObject["TextRepresentation"]
				                  .ToString()
				                  .Split(' ',
				                         '\t');
				if (recordParts.Length > 2) RecordType = new DnsRecordType(recordParts[2]);
				Ttl1 = new TimeSpan(0,
				                    0,
				                    System.Convert.ToInt32(wmiObject["TTL"]));
			}

			/// <summary>
			///    The location in the DNS system for this record
			/// </summary>
			public System.String DomainHost {get; set;}

			/// <summary>
			///    The record type
			/// </summary>
			public DnsRecordType RecordType {get;}

			/// <summary>
			///    The value of the target is what is written to DNS as the value of a record
			/// </summary>
			/// <remarks>For MX records include the priority as a number with a space or tab between it and the actual target</remarks>
			public System.String Target {get; set;}

			/// <summary>
			///    The time that the resolvers should cache this record for
			/// </summary>
			public TimeSpan Ttl
			{
				get => Ttl1;
				set => Ttl1 = value;
			}

			// ReSharper disable once MemberInitializerValueIgnored
			public TimeSpan Ttl1 {get; set;} = new TimeSpan(0,
			                                                1,
			                                                0);

			private ManagementObject _wmiObject;

			/// <summary>
			///    Delete a record from DNS
			/// </summary>
			public void Delete()
			{
				_wmiObject.Delete();

				//well that was easy...
			}

			/// <summary>
			///    Method to override to add additional methods to the DNS save changes support
			/// </summary>
			/// <param name="parametersIn">
			///    An array of parameters (not yet filled in if it's an
			///    unknown type, potentially partially filled for known types)
			/// </param>
			/// <returns>An array of filled in parameters, or null if the parameters are unknown</returns>
			public virtual ManagementBaseObject OnSaveChanges(ManagementBaseObject parametersIn) { return null; }

			/// <summary>
			///    Save the changes to the resource record
			/// </summary>
			public void SaveChanges()
			{
				//We can call modify and if we have the method available it will work as the sub-class may have it!!
				//Some types DO NOT implement it or implement it differently

				var parameters = _wmiObject.GetMethodParameters("Modify");
				var supported = false;

				//This is a cludge based on the various types that are implemented by MS as they didn't stick to a simple value

				//To add more, please refer to 
				if (RecordType.TextRepresentation == "A")
				{
					parameters["IPAddress"] = Target;
					parameters["TTL"] = Ttl1.TotalSeconds;
					supported = true;
				}

				if (RecordType.TextRepresentation == "AAAA")
				{
					parameters["IPv6Address"] = Target;
					parameters["TTL"] = Ttl1.TotalSeconds;
					supported = true;
				}

				if (RecordType.TextRepresentation == "CNAME")
				{
					parameters["PrimaryName"] = Target;
					parameters["TTL"] = Ttl1.TotalSeconds;
					supported = true;
				}

				if (RecordType.TextRepresentation == "TXT")
				{
					parameters["DescriptiveText"] = Target;
					parameters["TTL"] = Ttl1.TotalSeconds;
					supported = true;
				}

				if (RecordType.TextRepresentation == "MX")
				{
					var components = Target.Trim()
					                       .Split(' ',
					                              '\t');

					if (components.Length > 1)
					{
						parameters["Preference"] = System.Convert.ToUInt16(components[0]);

						//the preference is a UINT16 in MS DNS Server
						parameters["MailExchange"] = components[1]; //the actual host name

						//NOT SUPPORTED BY MX ACCORDING TO THE DOCUMENTATION!? parameters["TTL"] = _ttl;
						supported = true;
					}
				}

				Exception temporaryException = null;

				try
				{
					//This supports improving this classes implementation of this method and adding 
					var lastDitchParameters = OnSaveChanges(parameters);

					if (lastDitchParameters != null)
					{
						parameters = lastDitchParameters;
						supported = true;
					}
				}
				catch (Exception ex)

					//catch all as we do not know what someone will modify OnSaveChanges() to throw or cause
				{
					if (!supported)

						//if we support the data type already then we don't care about exceptions as at worst case
						throw;
					temporaryException = ex;
				}

				if (supported)
				{
					try
					{
						_wmiObject = (ManagementObject) _wmiObject.InvokeMethod("Modify",
						                                                        parameters,
						                                                        null);
					}
					catch (Exception ex)
					{
						if (temporaryException != null)
							throw new ApplicationException("There were two exceptions, the primary failure" +
							                               " was an exception that is encapsulated in this message however additionaly " +
							                               "a virtual method that was optional to functionality also threw an exception " +
							                               "but this was withheld till after the operation failed. Please examine the" +
							                               " InnerException property for copy of the virtual methods exception.  The " +
							                               "virtual methods exception message was: " +
							                               temporaryException.Message +
							                               ".  " +
							                               "The primary exceptions message (a " +
							                               ex.GetType().FullName +
							                               ") " +
							                               "was: " +
							                               ex.Message,
							                               temporaryException);

						throw;
					}

					if (temporaryException != null)
						throw new ApplicationException("A virtual method that was optional to functionality " +
						                               "threw an exception but this was withheld till after the operation completed " +
						                               "successfully, please examine the InnerException property for a full copy of this " +
						                               "exception.  The message was: " +
						                               temporaryException.Message,
						                               temporaryException);
				}
				else
				{
					throw new NotSupportedException("The data type you attmpted to use (" +
					                                RecordType.TextRepresentation +
					                                ") was not supported, please implement support for" +
					                                "it by overriding the method OnSaveChanges() and returning an array of filled WMI parameters " +
					                                "or by updating this implementation.");
				}
			}

			public override string ToString() { return DomainHost + " " + RecordType + " " + Target; }
		}

		/// <summary>
		///    The type of record in MS DNS Server
		/// </summary>
		public class DnsRecordType
		{
			/// <summary>
			///    Create a new DNS record type
			/// </summary>
			/// <param name="textRepresentation">The type to create</param>
			public DnsRecordType(System.String textRepresentation) { _textRepresentation = textRepresentation; }

			/// <summary>
			///    The mode of the record, usually IN but could oneday be something else like OUT
			/// </summary>
			public System.String RecordMode {get; set;} = "IN";

			/// <summary>
			///    The text representation of the record type
			/// </summary>
			public System.String TextRepresentation => _textRepresentation.ToUpper();

			private readonly string _textRepresentation;

			public override string ToString() { return RecordMode + " " + _textRepresentation; }

			#region Some Defaults!

			/// <summary>
			///    An alias
			/// </summary>
			public static DnsRecordType Cname => new DnsRecordType("CNAME");

			/// <summary>
			///    An IPv4 address
			/// </summary>
			public static DnsRecordType A => new DnsRecordType("A");

			/// <summary>
			///    A reverse host address inside yoursubnet.in-addr.arpa
			/// </summary>
			public static DnsRecordType Ptr => new DnsRecordType("PTR");

			/// <summary>
			///    An MX record (mail exchange)
			/// </summary>
			public static DnsRecordType Mx => new DnsRecordType("MX");

			/// <summary>
			///    An IPv6 host address
			/// </summary>
			public static DnsRecordType Aaaa => new DnsRecordType("AAAA");

			/// <summary>
			///    A text record
			/// </summary>
			public static DnsRecordType Txt => new DnsRecordType("TXT");

			/// <summary>
			///    A nameserver record (domain delegation)
			/// </summary>
			public static DnsRecordType Ns => new DnsRecordType("NS");

			/// <summary>
			///    An SOA record (start of authority)
			/// </summary>
			public static DnsRecordType Soa => new DnsRecordType("SOA");

			#endregion
		}

		#endregion
	}

	#endregion
}