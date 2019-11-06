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
// Creation Date: 2019/08/15 4:35 PM

#region Used Directives

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Diten.Collections.Generic;
using Diten.Net.NetworkInformation;
using Diten.Parameters;
using Diten.Security;
using Diten.Security.Cryptography;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten
{
	/// <summary>
	///    Provides information about, and means to manipulate, the current environment and platform. This class cannot
	///    be inherited.
	/// </summary>
	[ComVisible(true)]
	public class Environment: WebObject<Environment>
	{
		/// <inheritdoc cref="TextAssignmentSign" />
		public static char AssignmentSign => TextAssignmentSign;

		/// <inheritdoc cref="Char.ReservedChars.UnitSeparator" />
		public static char BinaryAssignmentSign => Char.ReservedChars.UnitSeparator.ToChar();

		/// <inheritdoc cref="Char.ReservedChars.RecordSeparator" />
		public static char BinaryValuingSeparator => Char.ReservedChars.RecordSeparator.ToChar();

		/// <summary>
		///    Get conversation tag.
		/// </summary>
		public static DTTag ConversationBeginning =>
			new DTTag(
			          $@"{Char.ReservedChars.StartOfHeader.ToChar().ToString()}{UserName}{Char.ReservedChars.At.ToChar().ToString()}{UserDomainName}"
				          .ToPrefix() +
			          $@"{Tools.GetNetworkInterfaces()[0].Interface.Id}".ToPrefix() +
			          $@"{Tools.GetNetworkInterfaces()[0].DefaultGateways[0].Address}");

		/// <summary>
		///    Get conversation tag.
		/// </summary>
		public static DTTag ConversationTag => new DTTag("DTCT");

		/// <inheritdoc cref="System.Environment.CurrentDirectory" />
		public static string CurrentDirectory => System.Environment.CurrentDirectory;

		/// <summary>
		///    Get EOF (End Of File) character.
		/// </summary>
		public static char EOF => FileSeparator;

		/// <summary>
		///    Get standard file separator character.
		/// </summary>
		public static char FileSeparator => Char.ReservedChars.FileSeparator.ToChar();

		/// <summary>
		///    Get file tag.
		/// </summary>
		public static DTTag FileTag =>
			new DTTag(
			          $@"{Char.ReservedChars.Semicolon.ToChar().ToString()}{Char.ReservedChars.ShiftOut.ToChar().ToString()}");

		/// <summary>
		///    Get folder divider.
		/// </summary>
		public static string FolderDivider => "\\";

		/// <summary>
		///    Get identity of current user.
		/// </summary>
		public static string Identity => $@"{UserDomainName}.{MachineName}.{UserName}";

		/// <inheritdoc cref="System.Environment.MachineName" />
		public static string MachineName => System.Environment.MachineName;

		/// <inheritdoc cref="System.Environment.MachineName" />
		public static string NewLine => System.Environment.NewLine;

		/// <summary>
		///    Get name of the root folder.
		/// </summary>
		public static string RootFolderName => ".";
		////ToDo: System.Environment Part

		///// <summary>Specifies options to use for getting the path to a special folder. </summary>
		//public enum SpecialFolderOption
		//{
		//	None = 0,
		//	DoNotVerify = 16384, // 0x00004000
		//	Create = 32768 // 0x00008000
		//}

		/// <summary>
		///    Unique signature for the current <see cref="Unit{TObject,TKey}" />.
		/// </summary>
		protected Func<string> Signature =>
			() =>
			{
				var k1 = new Key(new SHAKey<SHA256>(+
					                                    $@"{Identity}")
					                 .Value);
			};

		/// <summary>
		///    Get tab character.
		/// </summary>
		public static char Tab => Char.ReservedChars.HorizontalTab.ToChar();

		/// <summary>
		///    Get temp folder virtual path.
		/// </summary>
		public static string TempFolderVirtualPath => "~/TEMP";

		/// <inheritdoc cref="Char.ReservedChars.Equals" />
		public static char TextAssignmentSign => Char.ReservedChars.Equals.ToChar();

		/// <inheritdoc cref="Char.ReservedChars.Semicolon" />
		public static char TextValuingSeparator => Char.ReservedChars.Semicolon.ToChar();

		/// <summary>
		///    Get unit separator char.
		/// </summary>
		public static char UnitSeparator => Char.ReservedChars.UnitSeparator.ToChar();

		/// <summary>
		///    Get tag for unsafe strings.
		/// </summary>
		public static DTTag UnsafeStringTag =>
			new DTTag(
			          $@"{Char.ReservedChars.ShiftIn.ToChar().ToString()}{Char.ReservedChars.Ampersand.ToString()}");

		/// <inheritdoc cref="System.Environment.UserDomainName" />
		public static string UserDomainName => System.Environment.UserDomainName;

		/// <inheritdoc cref="System.Environment.UserName" />
		public static string UserName => System.Environment.UserName;

		/// <inheritdoc cref="TextValuingSeparator" />
		public static char ValuingSeparator => TextValuingSeparator;

		/// <summary>
		///    Get vertical tab character.
		/// </summary>
		public static char VTab => Char.ReservedChars.VerticalTab.ToChar();

		public static string GetResourceString(string resource,
		                                       params object[] param)
		{
			return string.Format(resource,
			                     param);
		}

		/// <inheritdoc cref="System.Environment.SpecialFolder" />
		public struct SpecialFolders
		{
			/// <inheritdoc cref="System.Environment.GetFolderPath(System.Environment.SpecialFolder)" />
			public static string GetFolderPath(System.Environment.SpecialFolder folder)
			{
				var path =
					$@"{System.Environment.GetFolderPath(folder)}\{Names.Default.Diten}";

				if (!Directory.Exists(path)) Directory.CreateDirectory(path);

				return path;
			}

			internal static System.Environment.SpecialFolder GetEnvironmentProperty =>
				Enum.Parse<System.Environment.SpecialFolder>(System.Environment.SpecialFolder.System.GetNames()
				                                                   .FirstOrDefault(p => p.Equals(new StackTrace().GetFrame(2).GetMethod().Name)));

			/// <inheritdoc cref="System.Environment.SpecialFolder.MyDocuments" />
			public static string MyDocuments => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.MyMusic" />
			public static string MyMusic => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.MyPictures" />
			public static string MyPictures => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.MyVideos" />
			public static string MyVideos => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.MyComputer" />
			public static string MyComputer => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.Templates" />
			public static string Templates => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.SendTo" />
			public static string SendTo => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.ApplicationData" />
			public static string ApplicationData => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.Desktop" />
			public static string Desktop => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.ProgramFiles" />
			public static string ProgramFiles => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.ProgramFilesX86" />
			public static string ProgramFilesX86 => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.Windows" />
			public static string WindowsFolder => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.SystemX86" />
			public static string SystemX86 => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.System" />
			public static string SystemFolder => GetFolderPath(GetEnvironmentProperty);

			/// <inheritdoc cref="System.Environment.SpecialFolder.CommonTemplates" />
			public static string CommonTemplates => GetFolderPath(GetEnvironmentProperty);
		}
	}
}