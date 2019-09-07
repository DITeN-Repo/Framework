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
// Creation Date: 2019/09/04 6:56 PM

#endregion

#region Used Directives

using System;
using System.Collections;

#endregion

namespace Diten.Numeric
{
	public interface IDBit<T> : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
	{
		/// <summary>
		///    Value of the DBit.
		/// </summary>
		BitArray Value { get; set; }
	}
}