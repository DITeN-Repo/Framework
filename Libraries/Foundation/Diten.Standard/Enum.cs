#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:35 PM

#endregion

#region Used Directives

using System;

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
			_id,
			ID
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
		public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
		{
			return System.Enum.TryParse(value, false, out result);
		}

		/// <summary>
		///    Get name of methods.
		/// </summary>
		/// <param name="methodName">Method names in diten object inherited classes.</param>
		/// <returns>Name of a method in object inherited class.</returns>
		public static string GetName(MethodNames methodName)
		{
			return GetName(enumerator: methodName);
		}

		/// <summary>
		///    Get name of property.
		/// </summary>
		/// <param name="methodName">Property names in diten object inherited classes.</param>
		/// <returns>Name of a method in object inherited class.</returns>
		public static string GetName(PropertyNames propertyName)
		{
			return GetName(enumerator: propertyName);
		}

		/// <summary>
		///    Get name of an enumerator.
		/// </summary>
		/// <param name="enumerator">Source enumerator.</param>
		/// <returns>Name on enumerator.</returns>
		public static string GetName(this System.Enum enumerator)
		{
			return System.Enum.GetName(enumerator.GetType(), enumerator)??throw new InvalidOperationException();
		}

		/// <summary>
		///    Get names of in enumerator.
		/// </summary>
		/// <param name="enumerator">Source enumerator.</param>
		/// <returns>Name array of enumerator.</returns>
		public static string[] GetNames(this System.Enum enumerator)
		{
			return System.Enum.GetNames(enumerator.GetType());
		}
	}
}