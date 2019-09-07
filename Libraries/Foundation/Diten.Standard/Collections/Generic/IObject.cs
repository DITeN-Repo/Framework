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
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Diten.Attributes;
using Diten.Net.Cloud;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

#endregion

namespace Diten.Collections.Generic
{
	/// <summary>
	///    Base of the object class.
	/// </summary>
	/// <typeparam name="TObject">Type of the object that must be handled by the generic.</typeparam>
	/// <typeparam name="TKey"></typeparam>
	//[ServiceContract]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	// ReSharper disable once UnusedTypeParameter
	public interface IObject<TObject, TKey>
	{
		/// <summary>
		///    Get hash of the current object.
		/// </summary>
		Byte Hash { get; }

		/// <summary>
		///    Path to the current object
		/// </summary>
		string Path { get; }

		/// <summary>
		///    Get SHA hash of the object.
		/// </summary>
		string Key { get; }

		/// <summary>
		///    Get children of the object.
		/// </summary>
		[DataMember]
		List<TObject> Children { get; set; }

		/// <summary>
		///    Get or Set creation date of the object.
		/// </summary>
		[DataMember]
		[NotInheritable]
		DateTime CreationDate { get; }

		/// <summary>
		///    Get or Set last modified date of the object.
		/// </summary>
		[DataMember]
		[NotInheritable]
		DateTime DateModified { get; }

		/// <summary>
		///    Determine that object is loaded or not.
		/// </summary>
		[BsonIgnore]
		bool IsLoaded { get; }

		/// <summary>
		///    Get ID of the object.
		/// </summary>
		[BsonId]
		[DataMember]
		ObjectId ID { get; }

		/// <summary>
		///    Get parent ID of the object.
		/// </summary>
		[DataMember]
		ObjectId ParentID { get; set; }

		/// <summary>
		///    Signature of the current object.
		/// </summary>
		string UniqueSignature { get; }

		List<RelatedHost> RelatedHosts { get; set; }

		Byte response { get; set; }

		/// <summary>
		///    History of the current object.
		/// </summary>
		ImmutableDictionary<ObjectId, IObject<TObject, TKey>> History { get; }

		/// <summary>
		///    Find objects that are placed in selector expression.
		/// </summary>
		/// <param name="selector">A lambda expression.</param>
		/// <returns>A list of object.</returns>
		//[OperationContract]
		IEnumerable<TObject> Find(Expression<Func<TObject, bool>> selector);

		/// <summary>
		///    Find objects that are placed in selector expression.
		/// </summary>
		/// <param name="selector">A lambda expression.</param>
		/// <param name="value">Value of the object in selector expression.</param>
		/// <returns>A list of object.</returns>
		List<TObject> Find(Expression<Func<TObject, object>> selector,
			object value);

		/// <summary>
		///    Find objects that are placed in selector expression.
		/// </summary>
		/// <param name="filter">A filter definition.</param>
		/// <returns>A list of object.</returns>
		List<TObject> Find(FilterDefinition<TObject> filter);

		/// <summary>
		///    Find that repository has item or not.
		/// </summary>
		/// <returns>True if there is items in item collection</returns>
		bool HasItem();

		/// <summary>
		///    Find that repository has item by exact ID or not.
		/// </summary>
		/// <returns>True if there is items in item collection</returns>
		/// <param name="id">ID of the object in repository.</param>
		bool HasItem(ObjectId id);

		/// <summary>
		///    Find that repository has item by exact ID or not.
		/// </summary>
		/// <returns>True if there is items in item collection</returns>
		/// <param name="filter">Filter definition for search object in repository.</param>
		bool HasItem(FilterDefinition<TObject> filter);

		/// <summary>
		///    Load data form repository.
		/// </summary>
		/// <returns>Return loaded object.</returns>
		TObject Load();

		/// <summary>
		///    Load data form repository.
		/// </summary>
		/// <param name="path">Path to the object in repository.</param>
		/// <returns>Return object.</returns>
		TObject Load(string path);

		/// <summary>
		///    Save data into repository.
		/// </summary>
		/// <param name="object">Object that must be saved in repository.</param>
		/// <param name="doAsyncProcess" default="True">Set do async process for saving data on repository or not.</param>
		void Save(TObject @object,
			bool doAsyncProcess = true);

		/// <summary>
		///    Get parent object of current object.
		/// </summary>
		/// <returns>Parent object of current object.</returns>
		TObject GetParent();
	}
}