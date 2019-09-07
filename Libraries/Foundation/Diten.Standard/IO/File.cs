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
// Creation Date: 2019/09/02 7:01 PM

#endregion

#region Used Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Diten.Parameters;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten.IO
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class File
	{
		/// <summary>
		///    Binary comparison of two files
		/// </summary>
		/// <param name="fileName1">the file to compare</param>
		/// <param name="fileName2">the other file to compare</param>
		/// <param name="differentialDiagnosis">Number of bytes of differences between 2 files.</param>
		/// <returns>a value indicating weather the file are identical</returns>
		public static bool Compare(string fileName1,
			string fileName2,
			int differentialDiagnosis = 1)
		{
			var info1 = new FileInfo(fileName1);
			var info2 = new FileInfo(fileName2);
			var same = info1.Length == info2.Length;

			if (!same)
				return false;

			using (var fs1 = info1.OpenRead())
			using (var fs2 = info2.OpenRead())
			using (var bs1 = new BufferedStream(fs1))
			using (var bs2 = new BufferedStream(fs2))
			{
				var defCount = 0;

				for (long i = 0; i < info1.Length; i++)
				{
					if (bs1.ReadByte() == bs2.ReadByte())
						continue;
					defCount += 1;

					if (!defCount.Equals(differentialDiagnosis))
						continue;
					same = false;

					break;
				}
			}

			return same;
		}

		/// <summary>
		///    Check existence of the
		///    <param name="fileName"></param>
		///    in temp folder.
		/// </summary>
		/// <param name="fileName">
		///    Name of the
		///    <param name="fileName"></param>
		///    that must checked.
		/// </param>
		/// <returns>
		///    True if the
		///    <param name="fileName"></param>
		///    is exist.
		/// </returns>
		public static bool ExistInTemp(string fileName) =>
			System.IO.File.Exists($@"{SystemParams.Default.TempFolderPath}\{fileName}");

		/// <summary>
		///    Converting
		///    <param name="fileName"></param>
		///    into safe file name.
		/// </summary>
		/// <param name="fileName">File name that must be changed to safe.</param>
		/// <returns>A safe file name that can be used in windows.</returns>
		public static string ToSafeFileName(string fileName)
		{
			var _return = string.Empty;
			var tmp1 = Char.UnsafeChars.ToList();
			var tmp2 = fileName.ToCharArray();

			foreach (var ch in tmp1)
				if (!tmp2.Contains(ch.Ascii))
					_return += ch.ToString();
				else
					_return += "_";

			return _return;
		}

		/// <summary>
		///    Get file name parts form the
		///    <param name="source"></param>
		///    .
		/// </summary>
		/// <param name="source">Source file name that must be splitted to parts.</param>
		/// <returns>Parts of the file name.</returns>
		public static (string Soure, string Path, string FullName, string Name, string Extension) GetFileName(
			string source)
		{
			var fullFileName = source.Split("\\".ToCharArray()).Last();
			var extenstion = fullFileName.Split(".".ToCharArray()).Last();

			return (source, source.Replace(fullFileName, string.Empty), fullFileName,
				fullFileName.Remove(fullFileName.LastIndexOf(".", StringComparison.Ordinal) - 1, extenstion.Length + 1),
				extenstion);
		}

		/// <summary>
		///    Writing
		///    <param name="contents"></param>
		///    into
		///    <param name="path"></param>
		///    .
		/// </summary>
		/// <param name="path">
		///    Path of the file that
		///    <param name="contents"></param>
		///    must be saved in it.
		/// </param>
		/// <param name="contents">
		///    The content that must be saved in
		///    <param name="path"></param>
		/// </param>
		/// <param name="overwrite">
		///    Overwrite the
		///    <param name="path"></param>
		///    file.
		/// </param>
		public static void WriteAllText(string path, string contents, bool overwrite = false)
		{
			if (overwrite && System.IO.File.Exists(path))
				System.IO.File.Delete(path);

			System.IO.File.WriteAllText(path, contents);
		}
	}
}