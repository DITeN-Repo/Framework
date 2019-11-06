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
// Creation Date: 2019/09/12 11:44 PM

#region Used Directives

using System;
using System.Runtime.Serialization;
using Diten.Attributes;
using Diten.Dynamic;
using Diten.Runtime;
using Diten.Security;
using Diten.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="Unit{TObject, TKey}" /> that will describe every
	///    <see cref="Concept{TObject,TKey}" />.
	/// </summary>
	/// <typeparam name="TObject">
	///    An <see cref="IObject{TObject}" /> that must be of type <see cref="ISerializable" />,
	///    <see cref="IObject{TObject, TKey}" /> or <see cref="IObject{TObject}" />.
	/// </typeparam>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Diten.Security.Signature{TKey}" /> of
	///    the <see cref="Unit{TObject,TKey}" />
	/// </typeparam>
	public abstract class Unit<TObject, TKey>: DynamicDictionary,
	                                           IUnit<TKey>
		where TKey: ISHA
		where TObject: ISerializable, IObject<TObject, TKey>
	{
		/// <summary>
		///    Constructor of <see cref="Unit{TObject,TKey}" />.
		/// </summary>
		protected Unit() { CreationDate = DateTime.Now; }

		/// <summary>
		///    Ignore database transaction if true.
		///    default is true.
		/// </summary>
		[BsonIgnore]
		protected bool IgnoreDB {get; set;} = true;

		/// <inheritdoc cref="IUnit{TKey}.CreationDate()" />
		[DataMember]
		public DateTime CreationDate {get;}

		/// <inheritdoc cref="IUnit{TKey}.ID" />
		[BsonId]
		[DataMember]
		[NonSignaturized]
		public ObjectId ID
		{
			get
			{
				if (_id.Equals(ObjectId.Empty)) _id = ObjectId.GenerateNewId();

				return _id;
			}
		}

		/// <inheritdoc cref="IConcept{TKey}.Serialize" />
		[BsonIgnore]
		public Func<Byte> Serialize => () => new Byte(Serialization.Serialize(this));

		/// <inheritdoc cref="IUnit{TKey}.Signature" />
		[BsonIgnore]
		public Func<Signature<TKey>> Signature =>
			_signature ??
			(_signature = () => new Signature<TKey>($@"{GetType().Assembly.FullName}{GetType().GUID}{typeof(TObject)}{typeof(TObject).GUID}" +
			                                        $@"{Serialize.Invoke().Value.ToBase64Text()}"));

		private ObjectId _id;

		[BsonIgnore]
		private Func<Signature<TKey>> _signature;
	}
}