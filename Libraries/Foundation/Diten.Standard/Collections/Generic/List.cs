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
using System.Globalization;
using System.Linq;
using System.Reflection;
using MongoDB.Bson.Serialization.Attributes;
using SCG = System.Collections.Generic;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten.Collections.Generic
{
	/// <inheritdoc />
	/// <typeparam name="T"></typeparam>
	[Attributes.Generic]
	public class List<T>: SCG.List<T>
	{
		/// <summary>
		///    Get list element.
		/// </summary>
		/// <param name="selector">A function for finding element in <see cref="Diten.Collections.Generic.List{T}" /></param>
		/// <returns>An element of the list in type of T.</returns>
		public T this[Func<T, bool> selector]
		{
			get
			{
				var _return = default(T);

				this.Where(o =>
				           {
					           o.GetType()
					            .GetMethod(Enum.GetName(Enum.MethodNames.Load))
					            ?.Invoke(o,
					                     BindingFlags.Default,
					                     null,
					                     null,
					                     CultureInfo.CurrentCulture);

					           _return = o;

					           return selector(_return);
				           })
				    .GetEnumerator()
				    .MoveNext();

				return selector(_return)
					       ? _return
					       : throw new EntryPointNotFoundException($@"Argument of type [{typeof(T)}] not found.");
			}
		}

		public new List<T> AddRange(SCG.IEnumerable<T> range)
		{
			return new Func<SCG.IEnumerable<T>, List<T>>(r =>
			                                             {
				                                             base.AddRange(r);

				                                             return this;
			                                             }).Invoke(range);
		}

		/// <summary>
		///    Casting a <see cref="SCG.List{T}" /> into <see cref="Diten.Collections.Generic.List{T}" />
		/// </summary>
		/// <param name="list">A <see cref="SCG.List{T}" /> for conversion.</param>
		/// <returns>A <see cref="Diten.Collections.Generic.List{T}" />.</returns>
		public List<T> Cast(SCG.List<T> list)
		{
			list.ForEach(Add);

			return this;
		}

		/// <summary>
		///    Filling <see cref="Diten.Collections.Generic.List{T}" /> items by calling fill method if it has one.
		/// </summary>
		/// <returns>A <see cref="Diten.Collections.Generic.List{T}" /> of elements of type T</returns>
		public List<T> Fill()
		{
			return (List<T>) typeof(T).GetMethod(Enum.GetName(Enum.MethodNames.Fill),
			                                     Type.EmptyTypes)
			                          ?.Invoke(Activator.CreateInstance(typeof(T)),
			                                   BindingFlags.Default,
			                                   null,
			                                   null,
			                                   CultureInfo.CurrentCulture);
		}

		/// <summary>
		///    Loading <see cref="Diten.Collections.Generic.List{T}" /> items by calling load method from repository if it has
		///    one.
		/// </summary>
		/// <returns>A <see cref="Diten.Collections.Generic.List{T}" /> of elements of type T</returns>
		public List<T> Load()
		{
			var tmp = GetRange(0,
			                   Count);
			Clear();

			foreach (var item in tmp)
				Add((T) item.GetType()
				            .GetMethod(Enum.GetName(Enum.MethodNames.Load),
				                       Type.EmptyTypes)
				            ?.Invoke(item,
				                     BindingFlags.Default,
				                     null,
				                     null,
				                     CultureInfo.CurrentCulture));

			return this;
		}

		public static implicit operator EnumerableQuery<T>(List<T> value) { return new EnumerableQuery<T>(value.ToList()); }

		/// <summary>
		///    Saving <see cref="Diten.Collections.Generic.List{T}" /> in repository.
		/// </summary>
		public void Save()
		{
			//ForEach(item => item.GetType().GetMethod(Enum.GetName(Enum.MethodNames.Touch))
			//    ?.Invoke(item, BindingFlags.Default, null, null, CultureInfo.CurrentCulture));

			//ForEach(item => item.GetType().GetMethod(Enum.GetName(Enum.MethodNames.Save), new[] {typeof(T)})
			//    ?.Invoke(item, BindingFlags.Default, null, new object[] {item},
			//        CultureInfo.CurrentCulture));

			ForEach(item => item.GetType()
			                    .GetMethods()
			                    .FirstOrDefault(method =>
				                                    method.Name.Equals(Enum.GetName(Enum.MethodNames.Save)) && method.GetParameters().Length.Equals(0))
			                    ?.Invoke(item,
			                             BindingFlags.DeclaredOnly |
			                             BindingFlags.ExactBinding |
			                             BindingFlags.InvokeMethod,
			                             null,
			                             null,
			                             CultureInfo.CurrentCulture));

			//var r = this[0].GetType();

			ForEach(item =>
			        {
				        foreach (var propertyInfo in item.GetType().GetProperties())
				        {
					        /*
					          .Name.ToUpper().Equals("Id".ToUpper()) &&
					                            !propertyInfo.Name.ToUpper().Equals("Database".ToUpper()) &&
					                            !propertyInfo.Name.ToUpper().Equals("MongoClient".ToUpper()) &&
					                            !propertyInfo.Name.ToUpper().Equals("Collection".ToUpper()))
					         */
					        if (!propertyInfo.GetCustomAttributes(typeof(BsonIgnoreAttribute)).Any())
						        if (propertyInfo.SetMethod != null)
							        try
							        {
								        propertyInfo.SetValue(item,
								                              null);
							        }
							        catch (Exception)
							        {
								        // ignored
							        }

					        if (propertyInfo.PropertyType == typeof(DateTime))
						        propertyInfo.SetValue(item,
						                              DateTime.MinValue);
				        }
			        });
		}

		/// <summary>
		///    Converting a <see cref="Generic.List{T}" /> into <see cref="SCG.List{T}" />
		/// </summary>
		/// <param name="value">A <see cref="Generic.List{T}" />.</param>
		/// <returns>A <see cref="SCG.List{T}" /></returns>
		public static List<T> ToList(SCG.IEnumerable<T> value) { return new List<T>().AddRange(value); }
	}
}