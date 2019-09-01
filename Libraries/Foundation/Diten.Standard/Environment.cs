#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:35 PM

#endregion

#region Used Directives

using System;
using System.IO;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten
{
	/// <summary>
	///    Provides information about, and means to manipulate, the current environment and platform. This class cannot
	///    be inherited.
	/// </summary>
	[ComVisible(true)]
	public static class Environment
	{
		/// <summary>Specifies enumerated constants used to retrieve directory paths to system special folders.</summary>
		[ComVisible(true)]
		public enum SpecialFolder
		{
			Root = 1000,
			Doors = 1001,
			Users = 1002,
			Documents = 1003,
			Pictures = 1004,
			Contacts = 1005,
			Computers = 1006,
			Cultures = 1007,
			Types = 1008,

			Desktop = 0,
			Programs = 2,
			MyDocuments = 5,
			Personal = 5,
			Favorites = 6,
			Startup = 7,
			Recent = 8,
			SendTo = 9,
			StartMenu = 11, // 0x0000000B
			MyMusic = 13, // 0x0000000D
			MyVideos = 14, // 0x0000000E
			DesktopDirectory = 16, // 0x00000010
			MyComputer = 17, // 0x00000011
			NetworkShortcuts = 19, // 0x00000013
			Fonts = 20, // 0x00000014
			Templates = 21, // 0x00000015
			CommonStartMenu = 22, // 0x00000016
			CommonPrograms = 23, // 0x00000017
			CommonStartup = 24, // 0x00000018
			CommonDesktopDirectory = 25, // 0x00000019
			ApplicationData = 26, // 0x0000001A
			PrinterShortcuts = 27, // 0x0000001B
			LocalApplicationData = 28, // 0x0000001C
			InternetCache = 32, // 0x00000020
			Cookies = 33, // 0x00000021
			History = 34, // 0x00000022
			CommonApplicationData = 35, // 0x00000023
			Windows = 36, // 0x00000024
			System = 37, // 0x00000025
			ProgramFiles = 38, // 0x00000026
			MyPictures = 39, // 0x00000027
			UserProfile = 40, // 0x00000028
			SystemX86 = 41, // 0x00000029
			ProgramFilesX86 = 42, // 0x0000002A
			CommonProgramFiles = 43, // 0x0000002B
			CommonProgramFilesX86 = 44, // 0x0000002C
			CommonTemplates = 45, // 0x0000002D
			CommonDocuments = 46, // 0x0000002E
			CommonAdminTools = 47, // 0x0000002F
			AdminTools = 48, // 0x00000030
			CommonMusic = 53, // 0x00000035
			CommonPictures = 54, // 0x00000036
			CommonVideos = 55, // 0x00000037
			Resources = 56, // 0x00000038
			LocalizedResources = 57, // 0x00000039
			CommonOemLinks = 58, // 0x0000003A
			CDBurning = 59 // 0x0000003B
		}
		//ToDo: System.Environment Part


		/// <summary>Specifies options to use for getting the path to a special folder. </summary>
		public enum SpecialFolderOption
		{
			None = 0,
			DoNotVerify = 16384, // 0x00004000
			Create = 32768 // 0x00008000
		}

		/// <summary>
		///    Main separator character.
		/// </summary>
		public const char Separator = (char)59;

		/// <summary>
		///    Value separator character.
		/// </summary>
		public const char ValueSeparator = (char)61;

		/// <inheritdoc cref="System.Environment.CurrentDirectory" />
		public static string CurrentDirectory => System.Environment.CurrentDirectory;

		/// <inheritdoc cref="System.Environment.UserName" />
		public static string UserName => System.Environment.UserName;

		/// <inheritdoc cref="System.Environment.UserDomainName" />
		public static string UserDomainName => System.Environment.UserDomainName;

		/// <inheritdoc cref="System.Environment.MachineName" />
		public static string MachineName => System.Environment.MachineName;

		/// <inheritdoc cref="UnitSeparator" />
		public static char StandardSeparator => UnitSeparator;

		/// <inheritdoc cref="System.Environment.MachineName" />
		public static string NewLine => System.Environment.NewLine;

		/// <summary>
		///    Get name of the root folder.
		/// </summary>
		public static string RootFolderName => ".";

		/// <summary>
		///    Get folder divider.
		/// </summary>
		public static string FolderDivider => "\\";

		/// <summary>
		///    Get tag for unsafe strings.
		/// </summary>
		public static DTTag UnsafeStringTag => new DTTag("DTUCT");

		/// <summary>
		///    Get file tag.
		/// </summary>
		public static DTTag FileTag => new DTTag("DTFT");

		/// <summary>
		///    Get conversation tag.
		/// </summary>
		public static DTTag ConversationTag => new DTTag("DTCT");

		/// <summary>
		///    Get temp folder virtual path.
		/// </summary>
		public static string TempFolderVirtualPath => "~/TEMP";

		/// <summary>
		///    Get standard file separator character.
		/// </summary>
		public static char FileSeparator => Char.ReservedChars.FileSeparator.ToChar();

		/// <summary>
		///    Get EOF (End Of File) character.
		/// </summary>
		public static char EOF => FileSeparator;

		/// <summary>
		///    Get unit separator char.
		/// </summary>
		public static char UnitSeparator => Char.ReservedChars.UnitSeparator.ToChar();

		/// <summary>
		///    Get tab character.
		/// </summary>
		public static char Tab => Char.ReservedChars.HorizontalTab.ToChar();

		public static string GetResourceString(string resource, params object[] param)
		{
			return string.Format(resource, param);
		}

		public static string GetFolderPath(SpecialFolder specialFolder)
		{
			if((string.IsNullOrEmpty(UserDomainName)||string.IsNullOrWhiteSpace(UserDomainName)||
				  UserDomainName==null)&&
				 !specialFolder.Equals(SpecialFolder.Root)&&
				 !specialFolder.Equals(SpecialFolder.ProgramFiles)&&
				 !specialFolder.Equals(SpecialFolder.System)&&
				 !specialFolder.Equals(SpecialFolder.Cultures)&&
				 !specialFolder.Equals(SpecialFolder.Types)&&
				 !specialFolder.Equals(SpecialFolder.Doors))
				throw new ArgumentNullException("Domain Name can not be null or empty.");

			switch(specialFolder)
			{
				case SpecialFolder.Root:

					return @".";
				case SpecialFolder.ProgramFiles:

					return @".\Program Files";
				case SpecialFolder.Doors:

					return @".\Doors";
				case SpecialFolder.System:

					return @".\Doors\System";
				case SpecialFolder.Cultures:

					return @".\Doors\System\Cultures";
				case SpecialFolder.Types:

					return @".\Doors\System\Types";
				case SpecialFolder.Users:

					return $@".\Domains\{UserDomainName}\Users";
				case SpecialFolder.Computers:

					return $@".\Domains\{UserDomainName}\{specialFolder}";
				case SpecialFolder.StartMenu:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Documents:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Desktop:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Favorites:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Pictures:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Contacts:

					if(string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(UserName)||UserName==null)
						throw new ArgumentNullException("Username can not be null or empty.");

					return $@".\Domains\{UserDomainName}\Users\{UserName}\{specialFolder}";
				case SpecialFolder.Programs:
					break;
				case SpecialFolder.MyDocuments:
					break;
				case SpecialFolder.Startup:
					break;
				case SpecialFolder.Recent:
					break;
				case SpecialFolder.SendTo:
					break;
				case SpecialFolder.MyMusic:
					break;
				case SpecialFolder.MyVideos:
					break;
				case SpecialFolder.DesktopDirectory:
					break;
				case SpecialFolder.MyComputer:
					break;
				case SpecialFolder.NetworkShortcuts:
					break;
				case SpecialFolder.Fonts:
					break;
				case SpecialFolder.Templates:
					break;
				case SpecialFolder.CommonStartMenu:
					break;
				case SpecialFolder.CommonPrograms:
					break;
				case SpecialFolder.CommonStartup:
					break;
				case SpecialFolder.CommonDesktopDirectory:
					break;
				case SpecialFolder.ApplicationData:
					break;
				case SpecialFolder.PrinterShortcuts:
					break;
				case SpecialFolder.LocalApplicationData:
					break;
				case SpecialFolder.InternetCache:
					break;
				case SpecialFolder.Cookies:
					break;
				case SpecialFolder.History:
					break;
				case SpecialFolder.CommonApplicationData:
					break;
				case SpecialFolder.Windows:
					break;
				case SpecialFolder.MyPictures:
					break;
				case SpecialFolder.UserProfile:
					break;
				case SpecialFolder.SystemX86:
					break;
				case SpecialFolder.ProgramFilesX86:
					break;
				case SpecialFolder.CommonProgramFiles:
					break;
				case SpecialFolder.CommonProgramFilesX86:
					break;
				case SpecialFolder.CommonTemplates:
					break;
				case SpecialFolder.CommonDocuments:
					break;
				case SpecialFolder.CommonAdminTools:
					break;
				case SpecialFolder.AdminTools:
					break;
				case SpecialFolder.CommonMusic:
					break;
				case SpecialFolder.CommonPictures:
					break;
				case SpecialFolder.CommonVideos:
					break;
				case SpecialFolder.Resources:
					break;
				case SpecialFolder.LocalizedResources:
					break;
				case SpecialFolder.CommonOemLinks:
					break;
				case SpecialFolder.CDBurning:
					break;
				default:

					throw new ArgumentOutOfRangeException(nameof(specialFolder), specialFolder, null);
			}

			return "yyyyy";
		}

		public struct SpecialFolders
		{
			public struct Windows
			{
				public static string MyDocuments =>
					GetFolderPath(SpecialFolder.MyDocuments);

				public static string MyMusic =>
					GetFolderPath(SpecialFolder.MyMusic);

				public static string MyPictures =>
					GetFolderPath(SpecialFolder.MyPictures);

				public static string MyVideos =>
					GetFolderPath(SpecialFolder.MyVideos);

				public static string MyComputer =>
					GetFolderPath(SpecialFolder.MyComputer);

				public static string Templates =>
					GetFolderPath(SpecialFolder.Templates);

				public static string SendTo =>
					GetFolderPath(SpecialFolder.SendTo);

				public static string ApplicationData =>
					GetFolderPath(SpecialFolder.ApplicationData);

				public static string Desktop =>
					GetFolderPath(SpecialFolder.Desktop);

				public static string ProgramFiles =>
					GetFolderPath(SpecialFolder.ProgramFiles);

				public static string ProgramFilesX86 =>
					GetFolderPath(SpecialFolder.ProgramFilesX86);

				public static string WindowsFolder =>
					GetFolderPath(SpecialFolder.Windows);

				public static string SystemX86 =>
					GetFolderPath(SpecialFolder.SystemX86);

				public static string SystemFolder =>
					GetFolderPath(SpecialFolder.System);
			}

			public struct Diten
			{
				public static string ApplicationData
				{
					get
					{
						var path = $@"{Windows.ApplicationData}\Diten";
						if(!Directory.Exists(path))
							Directory.CreateDirectory(path);

						return path;
					}
				}

				public static string ProgramFilesX86
				{
					get
					{
						var path = $@"{Windows.ProgramFilesX86}\Diten";
						if(!Directory.Exists(path))
							Directory.CreateDirectory(path);

						return path;
					}
				}

				public static string ProgramFiles
				{
					get
					{
						var path = $@"{Windows.ProgramFiles}\Diten";
						if(!Directory.Exists(path))
							Directory.CreateDirectory(path);

						return path;
					}
				}

				public static string MyDocuments
				{
					get
					{
						var path = $@"{Windows.MyDocuments}\Diten";
						if(!Directory.Exists(path))
							Directory.CreateDirectory(path);

						return path;
					}
				}
			}
		}
	}
}