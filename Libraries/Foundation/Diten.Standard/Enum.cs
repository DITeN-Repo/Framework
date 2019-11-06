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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Diten.Parameters;

// ReSharper disable InvalidXmlDocComment

#endregion

namespace Diten
{
	public static class Enum
	{
		/// <summary>
		///    Names of general methods in object inherited classes.
		/// </summary>
		public enum MethodNames
		{
			Save,
			Load,
			Add,
			Touch,
			Create,
			ComputeHash,
			Fill
		}

		/// <summary>
		///    Names of general properties in object inherited classes.
		/// </summary>
		public enum PropertyNames
		{
			DateModified,
			CreationDate,
			Dictionary,
			ParentID,
			Path,

			// ReSharper disable once InconsistentNaming
			_id,
			ID
		}

		/// <summary>
		///    Get name of methods.
		/// </summary>
		/// <param name="methodName">Method names in diten object inherited classes.</param>
		/// <returns>Name of a method in object inherited class.</returns>
		public static string GetName(MethodNames methodName) { return GetName(enumerator: methodName); }

		/// <summary>
		///    Get name of property.
		/// </summary>
		/// <param name="methodName">Property names in diten object inherited classes.</param>
		/// <returns>Name of a method in object inherited class.</returns>
		public static string GetName(PropertyNames propertyName) { return GetName(enumerator: propertyName); }

		/// <summary>
		///    Get name of an enumerator.
		/// </summary>
		/// <param name="enumerator">Source enumerator.</param>
		/// <returns>Name on enumerator.</returns>
		public static string GetName(this System.Enum enumerator)
		{
			return System.Enum.GetName(enumerator.GetType(),
			                           enumerator) ??
			       throw new InvalidOperationException();
		}

		/// <summary>
		///    Get names of in enumerator.
		/// </summary>
		/// <param name="enumerator">Source enumerator.</param>
		/// <returns>Name array of enumerator.</returns>
		public static IEnumerable<string> GetNames(this System.Enum enumerator) { return System.Enum.GetNames(enumerator.GetType()); }

		/// <summary>
		///    Get the environmental variable.
		/// </summary>
		/// <returns>Environmental variable.</returns>
		internal static string GetPath()
		{
			var path =
				$@"{
						System.Environment.GetFolderPath(Parse<System.Environment.SpecialFolder>(System.Environment.SpecialFolder.System.GetNames()
						                                                                               .FirstOrDefault(p => p.Equals(new StackTrace()
						                                                                                                             .GetFrame(2)
						                                                                                                             .GetMethod()
						                                                                                                             .Name))))
					}\{
						Names.Default.Diten
					}";

			if (!Directory.Exists(path)) Directory.CreateDirectory(path);

			return path;
		}

		/// <summary>
		///    Converts the string representation of the name or numeric value of one or more enumerated constants to an
		///    equivalent enumerated object. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
		/// <param name="result">
		///    When this method returns, <paramref name="result" /> contains an object of type
		///    <paramref name="TEnum" /> whose value is represented by <paramref name="value" /> if the parse operation succeeds.
		///    If the parse operation fails, <paramref name="result" /> contains the default value of the underlying type of
		///    <paramref name="TEnum" />. Note that this value need not be a member of the <paramref name="TEnum" /> enumeration.
		///    This parameter is passed uninitialized.
		/// </param>
		/// <typeparam name="TEnum">The enumeration type to which to convert <paramref name="value" />.</typeparam>
		/// <returns>
		///    <see langword="true" /> if the <paramref name="value" /> parameter was converted successfully; otherwise,
		///    <see langword="false" />.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		///    <paramref name="TEnum" /> is not an enumeration type.
		/// </exception>
		public static TEnum Parse<TEnum>(string value) where TEnum: struct
		{
			return (TEnum) System.Enum.Parse(typeof(TEnum),
			                                 value);
		}

		/// <summary>
		///    Converts the string representation of the name or numeric value of one or more enumerated constants to an
		///    equivalent enumerated object. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
		/// <param name="result">
		///    When this method returns, <paramref name="result" /> contains an object of type
		///    <paramref name="TEnum" /> whose value is represented by <paramref name="value" /> if the parse operation succeeds.
		///    If the parse operation fails, <paramref name="result" /> contains the default value of the underlying type of
		///    <paramref name="TEnum" />. Note that this value need not be a member of the <paramref name="TEnum" /> enumeration.
		///    This parameter is passed uninitialized.
		/// </param>
		/// <typeparam name="TEnum">The enumeration type to which to convert <paramref name="value" />.</typeparam>
		/// <returns>
		///    <see langword="true" /> if the <paramref name="value" /> parameter was converted successfully; otherwise,
		///    <see langword="false" />.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		///    <paramref name="TEnum" /> is not an enumeration type.
		/// </exception>
		public static bool TryParse<TEnum>(string value,
		                                   out TEnum result) where TEnum: struct
		{
			return System.Enum.TryParse(value,
			                            false,
			                            out result);
		}
	}
}