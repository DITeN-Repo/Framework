#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/18 2:21 PM

#endregion

#region Used Directives

using System;
using System.Collections;

#endregion

namespace Diten.Numeric
{
	public interface IDBit<T>:IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
	{
		/// <summary>
		///    Value of the DBit.
		/// </summary>
		BitArray Value { get; set; }
	}
}