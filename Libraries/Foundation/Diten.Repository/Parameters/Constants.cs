#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/07/30 4:53 PM

#endregion

#region Used Directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace Diten.Parameters
{
	/// <summary>
	///    The const variables.
	/// </summary>
	public partial class Constants
	{
		/// <summary>
		///    Get Vigesimal Characters array collection.
		/// </summary>
		public static char[] VigesimalCharacters => new Func<char[]>(() =>
		{
			var _return = new List<char>();

			_return.AddRange(DecimalNumbers);
			_return.AddRange(Enumerable.Range('A', 11).Select(x => (char) x).ToArray());

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Sexagesimal Characters array collection.
		/// </summary>
		public static char[] SexagesimalCharacters => new Func<char[]>(() =>
		{
			var _return = new List<char>();

			_return.AddRange(DecimalNumbers);
			_return.AddRange(UpperCaseLetters);
			_return.AddRange(LowerCaseLetters);

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Decimal Numbers collection.
		/// </summary>
		public static IEnumerable<char> DecimalNumbers => Enumerable.Range('0', 10).Select(x => (char) x).ToArray();

		/// <summary>
		///    Get UpperCase Letters collection.
		/// </summary>
		public static IEnumerable<char> UpperCaseLetters => Enumerable.Range('A', 26).Select(x => (char) x).ToArray();

		/// <summary>
		///    Get LowerCase Letters collection.
		/// </summary>
		public static IEnumerable<char> LowerCaseLetters => Enumerable.Range('a', 26).Select(x => (char) x).ToArray();

		/// <summary>
		///    Get Keyboard Characters Group I collection.
		/// </summary>
		/// <returns>UpperCaseLetters and DecimalNumbers in a collection.</returns>
		public static char[] KeyboardCharacters01 => new Func<char[]>(() =>
		{
			var _return = new List<char>();

			_return.AddRange(DecimalNumbers);
			_return.AddRange(UpperCaseLetters);

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Keyboard Characters Group II collection.
		/// </summary>
		/// <returns>UpperCaseLetters, LowerCaseLetters and DecimalNumbers in a collection.</returns>
		public static char[] KeyboardCharacters02 => new Func<char[]>(() =>
		{
			var _return = KeyboardCharacters01.ToList();

			_return.InsertRange(25, LowerCaseLetters);

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Keyboard Characters Group III collection.
		/// </summary>
		/// <returns>KeyboardCharacters02 and InjectionCharactersGroup01 in a collection.</returns>
		public static char[] KeyboardCharacters03 => new Func<char[]>(() =>
		{
			var _return = KeyboardCharacters02.ToList();

			_return.AddRange(Default.InjectionCharactersGroup01.ToCharArray());

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Keyboard Characters Group IV collection.
		/// </summary>
		/// <returns>KeyboardCharacters03 and InjectionCharactersGroup02 in a collection.</returns>
		public static char[] KeyboardCharacters04 => new Func<char[]>(() =>
		{
			var _return = KeyboardCharacters03.ToList();

			_return.AddRange(Default.InjectionCharactersGroup02.ToCharArray());

			return _return.ToArray();
		}).Invoke();

		/// <summary>
		///    Get Keyboard Characters Group V collection.
		/// </summary>
		/// <returns>KeyboardCharacters04 and InjectionCharactersGroup03 in a collection.</returns>
		public static char[] KeyboardCharacters05 => new Func<char[]>(() =>
		{
			var _return = KeyboardCharacters04.ToList();

			_return.AddRange(Default.InjectionCharactersGroup03.ToCharArray());

			return _return.ToArray();
		}).Invoke();

		public static IEnumerable<string> GetGlobalAssemblyCacheFiles(string path)
		{
			var directoryInfo = new DirectoryInfo(path);

			var files = directoryInfo.GetFiles(System.Default.AllDLLFiles).Select(fi => fi.FullName).ToList();

			foreach (var diChild in directoryInfo.GetDirectories())
				files.AddRange(GetGlobalAssemblyCacheFiles(diChild.FullName));

			return files.ToArray();
		}

		protected static string GetFrameName()
		{
			var _return = new StackTrace().GetFrame(1).GetMethod().Name;

			if (_return.StartsWith(System.Default.GetFrameFunctionExtention))
				return _return.TrimStart(System.Default.GetFrameFunctionExtention.ToCharArray());

			return _return.StartsWith(System.Default.SetFrameFunctionExtention)
				? _return.TrimStart(System.Default.SetFrameFunctionExtention.ToCharArray())
				: _return;
		}
	}
}