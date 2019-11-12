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
// Creation Date: 2019/08/16 1:10 AM

#region Used Directives

using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

#endregion

// ReSharper disable All

namespace Diten.Parameters
{
	/// <summary>
	///    The const Parameters.
	/// </summary>
	public class Parameters: Constants
	{
		/// <summary>
		///    System database server address in web.config file.
		/// </summary>
		public static System.String DatabaseServerAddress =>
			Application.GetConfig(Names.Default.SystemDatabaseServerAddress).Equals(System.String.Empty)
				? Default.LocalIp
				: Application.GetConfig(Names.Default.SystemDatabaseServerAddress);

		/// <summary>
		///    Application parameters
		/// </summary>
		public struct Application
		{
			/// <summary>
			///    Get AppSettings form config file.
			/// </summary>
			/// <param name="key">Key in config file AppSettings section.</param>
			/// <param name="fileName">Name of config file.</param>
			/// <returns>Value of the key.</returns>
			public static System.String GetConfig(System.String key,
			                               string fileName = "web")
			{
				try
				{
					var configuration =
						WebConfigurationManager.OpenWebConfiguration($@"~/{fileName}.{Default.ConfigFileExtention}");

					if (configuration.AppSettings.Settings.Count <= 0)
						throw new ArgumentException(System.String.Format(
						                                          Exceptions.Default.Diten_Variables_GetConfig_ArgumentException_KeyNotFound,
						                                          key));

					var customSetting = configuration.AppSettings.Settings.AllKeys.Contains(key)
						                    ? configuration.AppSettings.Settings[key]
						                    : throw new ArgumentException(System.String.Format(
						                                                                Exceptions
							                                                                .Default.Diten_Variables_GetConfig_ArgumentException_KeyNotFound,
						                                                                key));

					if (customSetting != null) return customSetting.Value;

					throw new ArgumentException(
					                            System.String.Format(
					                                                 Exceptions.Default.Diten_Variables_GetConfig_ArgumentException_ValueNotFound,
					                                                 key));
				}
				catch (ArgumentException) { return System.String.Empty; }
			}

			/// <summary>
			///    Encrypted uri parameter name in web.config file
			/// </summary>
			public static System.String EncryptedUriParameter => GetConfig(Names.Default.EncryptedUriParameter);

			/// <summary>
			///    Path of resources in web.config file
			/// </summary>
			public static System.String ResourcesPath => GetConfig(Names.Default.ResourcesPath);

			/// <summary>
			///    Additional assembly names in web.config file
			/// </summary>
			public static System.String AssemblyNames => GetConfig(Names.Default.AssemblyNames);

			#if DEBUG
			/// <summary>
			///    Solution directory.
			/// </summary>
			public static System.String SolutionDir => $@"{Environment.CurrentDirectory}\..\..\..\..";
			#endif

			/// <summary>
			///    Application directory
			/// </summary>
			public static System.String ApplicationDir => $@"{Environment.CurrentDirectory}\..\..\..";
		}

		/// <summary>
		///    Diten parameters
		/// </summary>
		public struct DitenParams
		{
			/// <summary>
			///    Diten services server.
			/// </summary>
			public static System.String ServicesServer => Application.GetConfig(typeof(object).GetFrameName());

			/// <summary>
			///    Diten handler service.
			/// </summary>
			public static System.String HandlerService => $@"http://{ServicesServer}/Handler.svc";

			/// <summary>
			///    Diten default separator character.
			/// </summary>
			public static char DefaultSeparator => Default.Separator.ToCharArray()[0];

			/// <summary>
			///    Cache environment encryption key.
			/// </summary>
			public static System.String EnvironmentEncryptionKey
			{
				get
				{
					{
						if (HttpRuntime.Cache[Names.Default.CacheEnvironmentEncryptionKey] == null)
							HttpRuntime.Cache[Names.Default.CacheEnvironmentEncryptionKey] =
								Default.Password;

						return HttpRuntime.Cache[Names.Default.CacheEnvironmentEncryptionKey].ToString();
					}
				}
			}
		}

		/// <summary>
		///    Local system variables
		/// </summary>
		public struct Local
		{
			/// <summary>
			///    System standard no reply mail address.
			/// </summary>
			public static System.String NoReplyMailAddress => Application.GetConfig(typeof(object).GetFrameName());

			/// <summary>
			///    System SMTP mail password.
			/// </summary>
			public static System.String SmtpPassword => Application.GetConfig(typeof(object).GetFrameName());

			/// <summary>
			///    System database server address in web.config file.
			/// </summary>
			public static System.String DatabaseServerAddress =>
				Application.GetConfig(Names.Default.SystemDatabaseServerAddress).Equals(System.String.Empty)
					? Default.LocalIp
					: Application.GetConfig(Names.Default.SystemDatabaseServerAddress);

			/// <summary>
			///    System max url length.
			/// </summary>
			public const int MaxUrlLength = 32768;

			/// <summary>
			///    System physical path address.
			/// </summary>
			public static System.String PhysicalPath =>
				$@"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles)}\{Default.CloudAppPhysicalPath}";

			/// <summary>
			///    System temporary folder path.
			/// </summary>
			public static System.String TempFolderPath
			{
				get
				{
					var holder =
						$@"{
								HttpRuntime.BinDirectory.Replace($@"\\{Default.BinFolder.ToLower()}",
								                                 System.String.Empty)
							}{
								Names.Default.Temp.ToUpper()
							}";
					if (!Directory.Exists(holder)) Directory.CreateDirectory(holder);

					return holder;
				}
			}

			/// <summary>
			///    System cache folder path.
			/// </summary>
			public static System.String CacheFolderPath
			{
				get
				{
					var holder =
						$@"{
								HttpRuntime.BinDirectory.Replace($@"\\{Default.BinFolder.ToLower()}",
								                                 System.String.Empty)
							}{
								Names.Default.Cache.ToUpper()
							}";
					if (!Directory.Exists(holder)) Directory.CreateDirectory(holder);

					return holder;
				}
			}

			/// <summary>
			///    System smtp server address in web.config file.
			/// </summary>
			public static System.String SmtpServerAddress => Application.GetConfig(typeof(object).GetFrameName());

			/// <summary>
			///    System web address in web.config file.
			/// </summary>
			public static System.String WebAddress => Application.GetConfig(typeof(object).GetFrameName());
		}
	}
}