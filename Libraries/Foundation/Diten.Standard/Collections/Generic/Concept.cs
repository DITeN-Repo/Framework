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
// Creation Date: 2019/09/13 12:55 AM

#region Used Directives

using System;
using System.Runtime.Serialization;
using Diten.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Representing a <inheritdoc cref="Concept{TObject, TKey}" /> based on <see cref="Unit{TObject, TKey}" />.
	/// </summary>
	/// <typeparam name="TObject">And object in type of <see cref="TObject" />.</typeparam>
	/// <typeparam name="TKey">
	///    An <see cref="ISHA" /> that will be used for <see cref="Diten.Security.Signature{TKey}" /> of
	///    the <see cref="IUnit{TKey}" />
	/// </typeparam>
	[BsonIgnoreExtraElements]
	public class Concept<TObject, TKey>: Unit<TObject, TKey>,
	                                     IConcept<TKey>,
	                                     ISerializable
		where TKey: ISHA
		where TObject: ISerializable, IObject<TObject, TKey>
	{
		#region MongoDB Object Properties

		//ToDo: Check Commented code.
		///// <summary>
		/////    Get or Set mongo client of the object.
		///// </summary>
		//[BsonIgnore]
		//private MongoClient MongoClient
		//{
		//	get => _mongoClient ?? (_mongoClient = new MongoClient());
		//	set => _mongoClient = value;
		//}

		///// <summary>
		/////    Get repository database.
		///// </summary>
		//[BsonIgnore]
		//[DataMember]
		//[NotInheritable]
		//private IMongoDatabase Database =>;

		/// <summary>
		///    Get collection of the object in <see cref="IMongoCollection{TDocument}" />.
		/// </summary>
		[BsonIgnore]
		internal IMongoCollection<TObject> Collection =>
			_collection ??
			(_collection = new MongoClient()
			               .GetDatabase(typeof(TObject).Assembly.GetName()
			                                           .Name
			                                           .ToProtected())
			               .GetCollection<TObject>(typeof(TObject).ToString()
			                                                      .ToProtected()));

		#endregion

		/// <inheritdoc cref="IConcept{TKey}.Description" />
		public String Description {get; set;}

		/// <inheritdoc />
		public void GetObjectData(SerializationInfo info,
		                          StreamingContext context)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc cref="Unit{TObject,TKey}.ID" />
		public new ObjectId ID
		{
			get
			{
				#if DEBUG
				if (IgnoreDB) return ObjectId.Empty;
				#endif

				while (true)
					using (var cursor = Collection.FindAsync(Builders<TObject>.Filter.Eq(Enum.PropertyNames._id.GetName(),
					                                                                     _id))
					                              .Result.AnyAsync())
					{
						if (cursor.Result) _id = ObjectId.GenerateNewId();
						else break;
					}

				return _id;
			}
		}

		/// <inheritdoc cref="IConcept{TKey}.Name" />
		public String Name {get; set;}

		[NonSerialized]
		[BsonIgnore]
		private IMongoCollection<TObject> _collection;

		//ToDo: Check Commented code.
		//protected Concept(System.String connectionString = null, string databaseServerAddress = "localhost")
		//{
		//	if (IgnoreDB)
		//		return;

		//	if (connectionString.IsNull())
		//		MongoClient =
		//			new MongoClient(
		//				$@"{SystemParams.Default.MongoDBProtocolExtenstion}{SystemParams.Default.DefaultUser}:{SystemParams.Default.DefaultUserPassword}@{databaseServerAddress}");
		//	else
		//		MongoClient = new MongoClient(connectionString);
		//}

		//protected Concept(MongoClientSettings mongoClientSettings)
		//{
		//	MongoClient = new MongoClient(mongoClientSettings);
		//}

		//protected Concept(MongoUrl mongoUrl)
		//{
		//	if (!IgnoreDB)
		//		MongoClient = new MongoClient(mongoUrl);
		//}

		[NonSerialized]
		[BsonIgnore]
		private ObjectId _id;
	}
}