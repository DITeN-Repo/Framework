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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Diten.Net.Cloud;
using Diten.Parameters;
using Diten.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

#endregion

namespace Diten.Collections.Generic
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Object" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Object.svc or Object.svc.cs at the Solution Explorer and start debugging.

	/// <inheritdoc cref="IObject{TObject}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public class Object<TObject>: Object<TObject, SHA256>,
	                              IObject<TObject> where TObject: ISerializable, IObject<TObject> {}

	/// <inheritdoc cref="ILocalObject{TObject}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public class LocalObject<TObject>: Object<TObject, SHA1>,
	                                   ILocalObject<TObject> where TObject: ISerializable, ILocalObject<TObject> {}

	/// <inheritdoc cref="IWebObject{TObject}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public class WebObject<TObject>: Object<TObject, SHA256>,
	                                 IWebObject<TObject> where TObject: ISerializable, IWebObject<TObject> {}

	/// <inheritdoc cref="IDeepObject{TObject}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public class DeepObject<TObject>: Object<TObject, SHA384>,
	                                  IDeepObject<TObject> where TObject: ISerializable, IDeepObject<TObject> {}

	/// <inheritdoc cref="IDarkObject{TObject}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public class DarkObject<TObject>: Object<TObject, SHA512>,
	                                  IDarkObject<TObject> where TObject: ISerializable, IDarkObject<TObject> {}

	//ToDo: Check commented code
	//[DataContract]
	//[BsonIgnoreExtraElements]
	//public class BlackHole<T> : Object<T, SHA1024>
	//{

	//}

	/// <inheritdoc cref="IObject{TObject, TKey}" />
	[DataContract]
	[BsonIgnoreExtraElements]
	public abstract class Object<TObject, TKey>: Entity<TObject, TKey>,
	                                             IObject<TObject, TKey>
		where TKey: ISHA
		where TObject: ISerializable, IObject<TObject, TKey>
	{
		#region Constructors

		protected Object()
		{
			Children = new List<TObject>();
			HistoryHolder = new Dictionary<ObjectId, IObject<TObject, TKey>>();

			if (typeof(TObject) == typeof(Object<TObject, TKey>))
				throw new ArgumentException(
				                            Exceptions.Default.Diten_TypeException.Format("TObject",
				                                                                          nameof(TObject),
				                                                                          typeof(TObject)));

			if (typeof(TObject) == typeof(String)) IgnoreDB = true;

			Children = new List<TObject>();
			HistoryHolder = new Dictionary<ObjectId, IObject<TObject, TKey>>();
		}

		//protected Object(MongoClientSettings mongoClientSettings)
		//{
		//	Children = new List<TObject>();
		//	HistoryHolder = new Dictionary<ObjectId, IObject<TObject, TKey>>();
		//}

		//protected Object(MongoUrl mongoUrl)
		//{
		//	Children = new List<TObject>();
		//	HistoryHolder = new Dictionary<ObjectId, IObject<TObject, TKey>>();
		//}

		#endregion

		/// <summary>
		///    Holder property of <see cref="Object{TObject,TKey}" /> history in repository.
		/// </summary>
		private Dictionary<ObjectId, IObject<TObject, TKey>> HistoryHolder {get;}

		[DataMember]
		[BsonIgnore]
		public List<TObject> Children
		{
			get => _children ?? (_children = new List<TObject>());
			set => _children = value;
		}

		public TObject GetParent()
		{
			return Find(T =>
				            (ObjectId) T.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID)).GetValue(T) ==
				            ParentID)
				.First();
		}

		public bool HasItem()
		{
			return Collection
			       .FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
			                                              ID))
			       .Result
			       .AnyAsync()
			       .Result;
		}
		//ToDo: Delete commented code
		//{
		//    var result = Collection.FindAsync(Builders<T>.Filter.Eq(Properties.GetPropertyName(Properties.PropertyNames._id), ID)).Result;

		//    result.MoveNext();

		//    if (result.Current.Count().Equals(0)) return false;

		//    return result.Current.First() != null;
		//}

		public bool HasItem(ObjectId id)
		{
			return Collection
			       .FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
			                                              id))
			       .Result
			       .AnyAsync()
			       .Result;
		}

		public bool HasItem(FilterDefinition<TObject> filter) { return Collection.FindAsync(filter).Result.AnyAsync().Result; }

		/// <summary>
		///    Get a dictionary collection of <see cref="Object{TObject,TKey}" /> that hold history of
		///    object <see cref="Object{TObject,TKey}" /> in repository.
		/// </summary>
		[BsonIgnore]
		public Func<ImmutableDictionary<ObjectId, IObject<TObject, TKey>>> History =>
			() =>
				HistoryHolder.Load().ToImmutableDictionary();

		/// <summary>
		///    Get that <see cref="Object{TObject,TKey}" /> is loaded from repository.
		/// </summary>
		[BsonIgnore]
		public bool IsLoaded {get; private set;}

		[DataMember]
		public ObjectId ParentID {get; set;}

		[BsonIgnore]
		public List<RelatedHost> RelatedHosts {get; set;}

		[BsonIgnore]
		public Byte Response {get; set;}

		#region Save Methods

		public void Save(TObject @object,
		                 bool doAsyncProcess = true)
		{
			//ToDo: Check commented code
			/*
			 * propertyInfo.PropertyType == typeof(List<T>) ||
			        propertyInfo.PropertyType == typeof(String) ||
			        propertyInfo
			            .PropertyType.Name.Contains(typeof(List<>).Name) ||
			        propertyInfo.PropertyType.Name.Contains(typeof(Dictionary<,>)
			            .Name
			 */

			foreach (var propertyInfo in @object.GetType()
			                                    .GetProperties()
			                                    .Where(propertyInfo => !propertyInfo.GetCustomAttributes(typeof(BsonIgnoreAttribute)).Any() &&
			                                                           propertyInfo.PropertyType.CustomAttributes.Any(a =>
				                                                                                                          a.AttributeType ==
				                                                                                                          typeof(Attributes.Generic))))
				/* If property has Save method it will be invoked
					 *      Inline function: If property has DitenGeneric attribute and it's true on Saving,
					 *      it will invoke Touch method of property if exist then return property
					 *      else it will return property
					 */
				//ToDo: Check commented code
				//var rr = $@"{propertyInfo.Name}, {propertyInfo.DeclaringType}";

				propertyInfo.PropertyType.GetMethod(Enum.GetName(Enum.MethodNames.Save))
				            ?.Invoke(propertyInfo.PropertyType.GetCustomAttribute<Attributes.Generic>().DoSave
					                     ? new Func<object>(() =>
					                                        {
						                                        //ToDo: Check commented code
						                                        //If generic has Touch method it will be executed.
						                                        //var holderInvoke =
						                                        propertyInfo.PropertyType
						                                                    .GetMethod(Enum.GetName(Enum.MethodNames.Touch))
						                                                    ?.Invoke(@object,
						                                                             BindingFlags.Public,
						                                                             null,
						                                                             null,
						                                                             CultureInfo.CurrentCulture);
						                                        //ToDo: Check commented code
						                                        //holderInvoke?.ToBsonDocument().First().GetType()
						                                        //    .GetMethod(Enum.GetName(Enum.MethodNames.Save))?.Invoke(holderInvoke,
						                                        //        BindingFlags.Public, null, null,
						                                        //        CultureInfo.CurrentCulture);

						                                        return propertyInfo.GetValue(@object); //@object;//propertyInfo;
					                                        }).Invoke()
					                     : propertyInfo.GetValue(@object),
				                     BindingFlags.Public,
				                     null,
				                     null,
				                     CultureInfo.CurrentCulture);

			if (IsLoaded || HasItem())
			{
				@object.GetType()
				       .GetProperty(Enum.GetName(Enum.PropertyNames.DateModified))
				       ?.SetValue(@object,
				                  DateTime.Now);

				if (doAsyncProcess)
				{
					//ToDo: Check commented code
					//var tmpParentID = (ObjectId)@object.GetType()
					//    .GetProperty(Enum.GetName(Enum.PropertyNames.ParentID))
					//    ?.GetValue(@object);

					//var tmpID = (ObjectId)@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID))
					//    ?.GetValue(@object);

					Collection.InsertOneAsync(@object);

					Collection.ReplaceOneAsync(
					                           Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
					                                                       @object.GetType()
					                                                              .GetProperty(Enum.GetName(Enum.PropertyNames.ID))
					                                                              ?.GetValue(@object)),
					                           @object);
				}
				else
				{
					Collection.ReplaceOne(
					                      Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
					                                                  @object.GetType()
					                                                         .GetProperty(Enum.GetName(Enum.PropertyNames.ID))
					                                                         ?.GetValue(@object)),
					                      @object);
				}
			}
			else
			{
				@object.GetType()
				       .GetProperty(Enum.GetName(Enum.PropertyNames.CreationDate))
				       ?.SetValue(@object,
				                  DateTime.Now);
				@object.GetType()
				       .GetProperty(Enum.GetName(Enum.PropertyNames.DateModified))
				       ?.SetValue(@object,
				                  DateTime.Now);

				if (doAsyncProcess) Collection.InsertOneAsync(@object);
				else Collection.InsertOne(@object);
			}
		}

		#endregion

		private List<TObject> _children;

		#region Loader Methods

		public TObject Load()
		{
			#if DEBUG
			if (IgnoreDB) return default;
			#endif
			var result = Collection
			             .FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
			                                                    ID))
			             .Result;

			if (!result.Any()) return default;

			var first = result.First();

			foreach (var property in first.GetType().GetProperties())
				foreach (var memberInfo in from propertyInfo in GetType().GetProperties()
				                           where property.Name.Equals(propertyInfo.Name) &&
				                                 !propertyInfo.Name.Equals(Enum.GetName(Enum.PropertyNames.ID))
				                           select GetType().GetProperty(propertyInfo.Name)
				                           into memberInfo
				                           where memberInfo != null
				                           select memberInfo)
					if (memberInfo.PropertyType == typeof(String) ||
					    memberInfo.PropertyType == typeof(Word) ||
					    memberInfo.PropertyType.Name.Contains(typeof(List<>).Name))
					{
						if (property.GetValue(first) != null)
							memberInfo.PropertyType
							          .GetMethod(Enum.GetName(Enum.MethodNames.Load),
							                     Type.EmptyTypes)
							          ?.Invoke(property.GetValue(first),
							                   BindingFlags.Public,
							                   null,
							                   null,
							                   CultureInfo.CurrentCulture);
					}
					else
					{
						memberInfo.SetValue(this,
						                    property.GetValue(first));
					}

			IsLoaded = true;

			return first;
		}

		public TObject Load(string path)
		{
			return Find(o => o.GetType()
			                  .GetProperty(Enum.GetName(Enum.PropertyNames.Path))
			                  .GetValue(o)
			                  .ToString()
			                  .Equals(path))
				.First();
		}

		#endregion

		#region Find Methods

		/// <inheritdoc />
		public IEnumerable<TObject> Find(Expression<Func<TObject, bool>> selector)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.Find(selector).ToList());

			return _return;
		}

		/// <inheritdoc />
		public List<TObject> Find(Expression<Func<TObject, object>> selector,
		                          object value)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.FindAsync(Builders<TObject>.Filter.Eq(selector,
			                                                                  value))
			                           .Result.ToList());

			return _return;
		}

		/// <inheritdoc />
		public List<TObject> Find(FilterDefinition<TObject> filter)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.FindAsync(filter).Result.ToList());

			return _return;
		}

		#endregion
	}
}