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
// Creation Date: 2019/09/30 9:44 PM

#region Used Directives

using System;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="IEntity{TKey}" /> based on <see cref="IConcept{TKey}" />.
	/// </summary>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Security.Signature{TKey}" /> of the
	///    <see cref="Entity{TObject, TKey}" />
	/// </typeparam>
	public interface IEntity<TKey>: IConcept<TKey>
		where TKey: ISHA
	{
		/// <summary>
		///    Get modification <see cref="DateTime" /> of the <see cref="IEntity{TKey}" />.
		/// </summary>
		DateTime DateModified {get; set;}
	}
}