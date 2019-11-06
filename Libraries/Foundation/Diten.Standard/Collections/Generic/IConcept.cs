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
// Creation Date: 2019/09/30 9:39 PM

#region Used Directives

using System;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="IConcept{TKey}" /> based on <see cref="IUnit{TKey}" />.
	/// </summary>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Security.Signature{TKey}" /> of the
	///    <see cref="Concept{TObject, TKey}" />
	/// </typeparam>
	public interface IConcept<TKey>: IUnit<TKey>
		where TKey: ISHA
	{
		/// <summary>
		///    Get or Set description of <see cref="IEntity{TKey}" />
		/// </summary>
		String Description {get; set;}

		/// <summary>
		///    Get or Set name of <see cref="IConcept{TKey}" />.
		/// </summary>
		String Name {get; set;}
	}
}