#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Attributes;
using Diten.Dynamic;
using Diten.Management.Hardware;
using Diten.Net.Cloud;
using Diten.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using Type = System.Type;

#endregion


namespace Diten.Collections.Generic
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Object" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Object.svc or Object.svc.cs at the Solution Explorer and start debugging.

	[DataContract]
	[BsonIgnoreExtraElements]
	public class Object<T>:Object<T, SHA1>
	{
	}

	[DataContract]
	[BsonIgnoreExtraElements]
	public class LocalObject<T>:Object<T, SHA1>
	{
	}

	[DataContract]
	[BsonIgnoreExtraElements]
	public class WebObject<T>:Object<T, SHA256>
	{
	}

	[DataContract]
	[BsonIgnoreExtraElements]
	public class DeepObject<T>:Object<T, SHA384>
	{
	}

	[DataContract]
	[BsonIgnoreExtraElements]
	public class DarkObject<T>:Object<T, SHA512>
	{
	}

	//[DataContract]
	//[BsonIgnoreExtraElements]
	//public class BlackHole<T> : Object<T, SHA512>
	//{

	//}

	[DataContract]
	[BsonIgnoreExtraElements]
	public abstract class Object<TObject, TKey>:DynamicDictionary, IObject<TObject, TKey>
		where TKey : ISHA
	{
		private List<TObject> _children;

		private ObjectId _id;

		private MongoClient _mongoClient;

		/// <summary>
		///    Ignore database transaction if true.
		///    default is true.
		/// </summary>
		[BsonIgnore]
		public bool IgnoreDB { get; set; } = true;

		/// <summary>
		///    Holder property of <see cref="Diten.Collections.Generic.Object{TObject,TKey}" /> history in repository.
		/// </summary>
		private Dictionary<ObjectId, Object<TObject, TKey>> HistoryHolder { get; }

		/// <summary>
		///    Get a dictionary collection of <see cref="Diten.Collections.Generic.Object{TObject,TKey}" /> that hold history of
		///    object <see cref="Diten.Collections.Generic.Object{TObject,TKey}" /> in repository.
		/// </summary>
		[BsonIgnore]
		public ImmutableDictionary<ObjectId, Object<TObject, TKey>> History =>
			HistoryHolder.Load().ToImmutableDictionary();

		/// <inheritdoc />
		/// <summary>
		///    Get that <see cref="Diten.Collections.Generic.Object{TObject,TKey}" /> is loaded from repository.
		/// </summary>
		[BsonIgnore]
		public bool IsLoaded { get; private set; }

		/// <inheritdoc />
		/// <summary>
		///    Get hash of <see cref="Diten.Collections.Generic.Object{TObject,TKey}" />.
		/// </summary>
		[BsonIgnore]
		public Byte Hash
		{
			get
			{
				var memoryStream = new MemoryStream();

				new BinaryFormatter().Serialize(memoryStream, this);

				return new Byte(memoryStream.ToArray());
			}
		}

		[BsonIgnore]
		public string Path =>
			$@"{Computer.MachineName}.{WindowsIdentity.GetCurrent().Name}.{Assembly.GetEntryAssembly()?.FullName.Replace(":", string.Empty).Replace("\\", ".")}.{typeof(TObject)}.{ID}";

		[DataMember]
		public string Key
		{
			get
			{
				using(var shaKey = new SHAKey<TKey>(this))
				{
					return shaKey.Value;
				}
			}
		}

		[DataMember]
		[BsonIgnore]
		public List<TObject> Children
		{
			get => _children??(_children=new List<TObject>());
			set => _children=value;
		}

		[BsonId]
		[DataMember]
		public ObjectId ID
		{
			get
			{
				//#if DEBUG
				//                if (IgnoreDB) return ObjectId.Empty;
				//#endif

				if(!_id.Equals(ObjectId.Empty))
					return _id;

				do
				{
					_id=ObjectId.GenerateNewId();
				} while(Collection
					.FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id), _id))
					.Result.AnyAsync().Result);

				return _id;
			}
			set => _id=value;
		}

		[DataMember] [NotInheritable] public DateTime CreationDate { get; internal set; }

		[DataMember] [NotInheritable] public DateTime DateModified { get; internal set; }

		[DataMember] public ObjectId ParentID { get; set; }

		[BsonIgnore] public List<RelatedHost> RelatedHosts { get; set; }

		[BsonIgnore] public Byte response { get; set; }

		public TObject GetParent()
		{
			return Find(T =>
				(ObjectId)T.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID)).GetValue(T)==
				ParentID).First();
		}

		public bool HasItem()
		{
			return Collection
				.FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id), ID)).Result
				.AnyAsync().Result;
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
				.FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id), id)).Result
				.AnyAsync().Result;
		}

		public bool HasItem(FilterDefinition<TObject> filter)
		{
			return Collection.FindAsync(filter).Result.AnyAsync().Result;
		}

		public TObject Load()
		{
#if DEBUG
			if(IgnoreDB)
				return default;
#endif
			var result = Collection
				.FindAsync(Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id), ID)).Result;

			if(!result.Any())
				return default;

			var first = result.First();

			foreach(var property in first.GetType().GetProperties())
				foreach(var memberInfo in from propertyInfo in GetType().GetProperties()
												  where property.Name.Equals(propertyInfo.Name)&&
														  !propertyInfo.Name.Equals(Enum.GetName(Enum.PropertyNames.ID))
												  select GetType().GetProperty(propertyInfo.Name)
					into memberInfo
												  where memberInfo!=null
												  select memberInfo)
					if(memberInfo.PropertyType==typeof(String)||
						 memberInfo.PropertyType==typeof(Word)||
						 memberInfo.PropertyType.Name.Contains(typeof(List<>).Name))
					{
						if(property.GetValue(first)!=null)
							memberInfo.PropertyType
								.GetMethod(Enum.GetName(Enum.MethodNames.Load), Type.EmptyTypes)
								?.Invoke(property.GetValue(first), BindingFlags.Public, null, null,
									CultureInfo.CurrentCulture);
					}
					else
					{
						memberInfo.SetValue(this, property.GetValue(first));
					}

			IsLoaded=true;

			return first;
		}

		public TObject Load(string path)
		{
			return Find(o => o.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.Path)).GetValue(o)
				.ToString().Equals(path)).First();
		}

		/// <inheritdoc />
		/// <summary>
		///    Saving object in database.
		/// </summary>
		/// <param name="object">Object to save.</param>
		/// <param name="doAsyncProcess">Saving object in async mode.</param>
		public void Save(TObject @object, bool doAsyncProcess = true)
		{
			/*
			 * propertyInfo.PropertyType == typeof(List<T>) ||
			        propertyInfo.PropertyType == typeof(String) ||
			        propertyInfo
			            .PropertyType.Name.Contains(typeof(List<>).Name) ||
			        propertyInfo.PropertyType.Name.Contains(typeof(Dictionary<,>)
			            .Name
			 */


			foreach(var propertyInfo in @object.GetType().GetProperties()
					.Where(propertyInfo => !propertyInfo.GetCustomAttributes(typeof(BsonIgnoreAttribute)).Any()&&
												  propertyInfo.PropertyType.CustomAttributes.Any(a =>
													  a.AttributeType==typeof(Attributes.Generic))))
				/* If property has Save method it will be invoked
					 *      Inline function: If property has DitenGeneric attribute and it's true on Saving,
					 *      it will invoke Touch method of property if exist then return property
					 *      else it will return property
					 */

				//var rr = $@"{propertyInfo.Name}, {propertyInfo.DeclaringType}";

				propertyInfo.PropertyType.GetMethod(Enum.GetName(Enum.MethodNames.Save))
					?.Invoke(propertyInfo.PropertyType.GetCustomAttribute<Attributes.Generic>().DoSave
						? new Func<object>(() =>
						{
							//If generic has Touch method it will be executed.
							//var holderInvoke = 
							propertyInfo.PropertyType
								.GetMethod(Enum.GetName(Enum.MethodNames.Touch))
								?.Invoke(@object, BindingFlags.Public, null, null, CultureInfo.CurrentCulture);

							//holderInvoke?.ToBsonDocument().First().GetType()
							//    .GetMethod(Enum.GetName(Enum.MethodNames.Save))?.Invoke(holderInvoke,
							//        BindingFlags.Public, null, null,
							//        CultureInfo.CurrentCulture);

							return propertyInfo.GetValue(@object); //@object;//propertyInfo;
						}).Invoke()
						: propertyInfo.GetValue(@object), BindingFlags.Public, null, null, CultureInfo.CurrentCulture);

			if(IsLoaded||HasItem())
			{
				@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.DateModified))
					?.SetValue(@object, DateTime.Now);

				if(doAsyncProcess)
				{
					//var tmpParentID = (ObjectId)@object.GetType()
					//    .GetProperty(Enum.GetName(Enum.PropertyNames.ParentID))
					//    ?.GetValue(@object);

					//var tmpID = (ObjectId)@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID))
					//    ?.GetValue(@object);

					Collection.InsertOneAsync(@object);

					Collection.ReplaceOneAsync(
						Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
							@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID))
								?.GetValue(@object)), @object);
				}
				else
				{
					Collection.ReplaceOne(
						Builders<TObject>.Filter.Eq(Enum.GetName(Enum.PropertyNames._id),
							@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.ID))
								?.GetValue(@object)), @object);
				}
			}
			else
			{
				@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.CreationDate))
					?.SetValue(@object, DateTime.Now);
				@object.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.DateModified))
					?.SetValue(@object, DateTime.Now);

				if(doAsyncProcess)
					Collection.InsertOneAsync(@object);
				else
					Collection.InsertOne(@object);
			}
		}

		#region Constructors

		protected Object(string connectionString = null, string databaseServerAddress = "localhost")
		{
			Children=new List<TObject>();
			HistoryHolder=new Dictionary<ObjectId, Object<TObject, TKey>>();


			if(typeof(TObject)==typeof(Object<TObject, TKey>))
				throw new ArgumentException($@"T cannot be of type [{nameof(TObject)}: {typeof(TObject)}]");

			if(typeof(string)==typeof(Object<string, TKey>)||
				 typeof(String)==typeof(Object<String, TKey>))
				IgnoreDB=true;

			Children=new List<TObject>();
			HistoryHolder=new Dictionary<ObjectId, Object<TObject, TKey>>();

			if(IgnoreDB)
				return;

			if(connectionString.IsNull())
				MongoClient=
					new MongoClient(
						$@"{Variables.System.Default.MongoDBProtocolExtention}{Variables.System.Default.DBOwnerUser}:{Variables.System.Default.DBOwnerPassword}@{databaseServerAddress}");
			else
				MongoClient=new MongoClient(connectionString);
		}

		protected Object(MongoClientSettings mongoClientSettings)
		{
			Children=new List<TObject>();
			MongoClient=new MongoClient(mongoClientSettings);
			HistoryHolder=new Dictionary<ObjectId, Object<TObject, TKey>>();
		}

		protected Object(MongoUrl mongoUrl)
		{
			Children=new List<TObject>();
			HistoryHolder=new Dictionary<ObjectId, Object<TObject, TKey>>();

			if(!IgnoreDB)
				MongoClient=new MongoClient(mongoUrl);
		}

		#endregion

		#region MongoDB Object Properties

		/// <summary>
		///    Get or Set mongo client of the object.
		/// </summary>
		[BsonIgnore]
		public MongoClient MongoClient
		{
			get => _mongoClient??(_mongoClient=new MongoClient());
			set => _mongoClient=value;
		}

		/// <summary>
		///    Get repository database.
		/// </summary>
		[BsonIgnore]
		private IMongoDatabase Database =>
			MongoClient.GetDatabase(typeof(TObject).Assembly.GetName().Name.ToProtected());

		/// <summary>
		///    Get collection of the object.
		/// </summary>
		[BsonIgnore]
		private IMongoCollection<TObject> Collection =>
			Database.GetCollection<TObject>(typeof(TObject).ToString().ToProtected());

		#endregion

		#region Find Methods

		public List<TObject> Find(Expression<Func<TObject, bool>> selector)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.Find(selector).ToList());

			return _return;
		}

		public List<TObject> Find(Expression<Func<TObject, object>> selector, object value)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.FindAsync(Builders<TObject>.Filter.Eq(selector, value)).Result.ToList());

			return _return;
		}

		public List<TObject> Find(FilterDefinition<TObject> filter)
		{
			var _return = new List<TObject>();

			_return.AddRange(Collection.FindAsync(filter).Result.ToList());

			return _return;
		}

		#endregion
	}
}