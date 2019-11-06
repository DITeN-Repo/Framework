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
// Creation Date: 2019/09/30 9:40 PM

#region Used Directives

using System;
using Diten.Security;
using Diten.Security.Cryptography;
using MongoDB.Bson;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="IUnit{TKey}" /> that will describe every <see cref="IConcept{TKey}" />.
	/// </summary>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Diten.Security.Signature{TKey}" /> of
	///    the <see cref="Unit{TObject,TKey}" />
	/// </typeparam>
	public interface IUnit<TKey>
		where TKey: ISHA
	{
		/// <summary>
		///    Get Creation date of <see cref="IUnit{TKey}" />
		/// </summary>
		DateTime CreationDate {get;}

		/// <summary>
		///    Identification of the <see cref="IUnit{TKey}" />
		/// </summary>
		ObjectId ID {get;}

		/// <summary>
		///    Get the <see cref="Signature{TKey}" /> in <see cref="TKey" /> hash of current <see cref="IUnit{TKey}" />.
		/// </summary>
		Func<Signature<TKey>> Signature {get;}

		/// <summary>
		///    Get serialized <see cref="Byte" /> of the <see cref="IUnit{TKey}" />.
		/// </summary>
		Func<Byte> Serialize {get;}
	}
}