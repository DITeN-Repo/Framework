#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System.Collections.Generic;

#endregion

namespace Diten
{
	/// <summary>
	///    Extended list methods.
	/// </summary>
	public static class ExList
	{
		/// <summary>
		///    Converting a <see cref="Collections.Generic.List{T}" /> into <see cref="System.Collections.Generic.List{T}" />
		/// </summary>
		/// <typeparam name="T">Source type of list elements.</typeparam>
		/// <param name="value">A <see cref="Collections.Generic.List{T}" />.</param>
		/// <returns>A <see cref="System.Collections.Generic.List{T}" /></returns>
		// ReSharper disable once ParameterTypeCanBeEnumerable.Global
		public static List<T> ToList<T>(this Collections.Generic.List<T> value)
		{
			var result = new List<T>();

			result.AddRange(value);

			return result;
		}

		/// <summary>
		///    Converting a <see cref="Collections.Generic.List{T}" /> into <see cref="System.Collections.Generic.List{T}" />
		/// </summary>
		/// <typeparam name="T">Source type of list elements.</typeparam>
		/// <param name="value">A <see cref="System.Collections.Generic.List{T}" />.</param>
		/// <returns>A <see cref="Collections.Generic.List{T}" /></returns>
		// ReSharper disable once ParameterTypeCanBeEnumerable.Global
		public static Collections.Generic.List<T> ToList<T>(this List<T> value)
		{
			return new Collections.Generic.List<T>().AddRange(value);
		}
	}
}