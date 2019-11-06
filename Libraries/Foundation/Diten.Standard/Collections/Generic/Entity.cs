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
// Creation Date: 2019/08/15 4:42 PM

#region Used Directives

using System;
using System.Runtime.Serialization;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="Entity{TObject, TKey}" /> based on <see cref="Concept{TObject, TKey}" />.
	/// </summary>
	/// <typeparam name="TObject">And object in type of <see cref="TObject" />.</typeparam>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Security.Signature{TKey}" /> of the
	///    <see cref="Entity{TObject, TKey}" />
	/// </typeparam>
	public class Entity<TObject, TKey>: Concept<TObject, TKey>,
	                                    IEntity<TKey>
		where TKey: ISHA
		where TObject: ISerializable, IObject<TObject, TKey>
	{
		/// <inheritdoc cref="IEntity{TKey}.DateModified" />
		public DateTime DateModified {get; set;}
	}
}