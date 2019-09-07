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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace Diten
{
	/// <summary>
	///    A calls for jobs on current installed framework.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class Framework
	{
		/// <summary>
		///    A class for jobs on .Net Framework.
		/// </summary>
		public class DotNet
		{
			public DotNet(string versionName,
				string servicePack)
			{
				VersionName = versionName;
				SP = servicePack;
			}

			/// <summary>
			///    Get Installed service pack information.
			/// </summary>
			public string SP { get; }

			/// <summary>
			///    Get name of the installed version of the file.
			/// </summary>
			public string VersionName { get; }

			/// <summary>
			///    Get list of installed updates for current installed .Net Framework.
			/// </summary>
			/// <returns>A list of installed updates.</returns>
			public static List<DotNet> GetUpdatesList()
			{
				var output = new List<DotNet>();

				using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
					.OpenSubKey(@"SOFTWARE\Microsoft\Updates"))
				{
					if (baseKey == null)
						return output;

					foreach (var baseKeyName in baseKey
						.GetSubKeyNames()
						.Where(baseKeyName => baseKeyName.Contains(".NET Framework")))
						using (var updateKey = baseKey.OpenSubKey(baseKeyName))
						{
							if (updateKey == null)
								continue;

							foreach (var kbKeyName in updateKey.GetSubKeyNames())
								using (updateKey.OpenSubKey(kbKeyName))
									output.Add(new DotNet(baseKeyName, kbKeyName));
						}
				}

				return output;
			}

			/// <summary>
			///    Get installed .Net Framework version.
			/// </summary>
			/// <returns>A file object that contains formation of the .Net Framework.</returns>
			private static List<DotNet> GetVersionFromRegistry()
			{
				var output = new List<DotNet>();

				// Opens the registry key for the .NET Framework entry.
				using (var ndpKey =
					RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "")
						.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
				{
					// As an alternative, if you know the computers you will query are running .NET Framework 4.5 
					// or later, you can use:
					// using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
					// RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
					if (ndpKey == null)
						throw new
							NullReferenceException(
								"There is no version of the .NET Framework is installed on this machine.");

					foreach (var versionKeyName in ndpKey.GetSubKeyNames())
					{
						if (!versionKeyName.StartsWith("v"))
							continue;
						var versionKey = ndpKey.OpenSubKey(versionKeyName);

						if (versionKey == null)
							continue;
						var name = (string) versionKey.GetValue("Version", "");
						var sp = versionKey.GetValue("SP", "").ToString();
						var install = versionKey.GetValue("Install", "").ToString();

						if (install == "") //no install info, must be later.
						{
							output.Add(new DotNet(name, string.Empty));
						}
						else
						{
							if (sp != "" && install == "1")
								output.Add(new DotNet(name, sp));
						}

						if (name != "")
							continue;

						foreach (var subKey in versionKey
							.GetSubKeyNames().Select(subKeyName => versionKey.OpenSubKey(subKeyName)))
						{
							if (subKey != null)
							{
								name = (string) subKey.GetValue("Version", "");
								if (name != "")
									sp = subKey.GetValue("SP", "").ToString();
								install = subKey.GetValue("Install", "").ToString();
							}

							if (install == "") //no install info, must be later.
							{
								output.Add(new DotNet(name, string.Empty));
							}
							else
							{
								if (sp != "" && install == "1")
									output.Add(new DotNet(name, sp));
								else if (install == "1")
									output.Add(new DotNet(name, string.Empty));
							}
						}
					}
				}

				return output;
			}
		}
	}
}