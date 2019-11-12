#region Copyright

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
// Creation Date: 2019/11/08 12:05 PM

#endregion

#region Used Directives

using System;
using System.ComponentModel;
using System.Linq;
using Diten.Collections.Generic;
using Diten.Parameters;
using Diten.Security.Cryptography;
using MongoDB.Driver;
using EX = Diten.Parameters.Exceptions;

// ReSharper disable UnusedMember.Global

#endregion

//using Diten.Extensions;

namespace Diten
{
	[DefaultProperty("Value")]
	public class Word: Object<Word>
	{
		/// <summary>
		///   Constructor.
		/// </summary>
		public Word() {}

		/// <summary>
		///   Constructor.
		/// </summary>
		/// <param name="value">Word string.</param>
		public Word(System.String value) => Value = value;

		/// <summary>
		///   Get or Set value of the word in <see cref="string" />
		/// </summary>
		public System.String Value {get => _value; set => _value = value.ToSafe();}

		private System.String _value;

		//ToDo: Check commented code
		//ToDo: The code must be controlled for logical mistakes.
		//[return: Nullable(1)]
		//private ArgumentException GetAddingDuplicateWithKeyArgumentException(
		//	[Nullable(2)] object key) =>
		//	new ArgumentException(System.String.Format(EX.Argument_AddingDuplicateWithKey, key));

		/// <summary>
		///   Decrypting encrypted <see cref="Diten.Word" /> string into <see cref="string" />.
		/// </summary>
		/// <param name="value">value of type <see cref="string" /></param>
		/// <returns>A decrypted <see cref="string" /></returns>
		public static System.String Decrypt(System.String value)
		{
			var position = 0;

			System.String Key()
			{
				position++;

				return $@"{Names.Default.CacheEnvironmentEncryptionKey}{position}";
			}

			return Enumerable.ToArray(value)
			                 .Aggregate(System.String.Empty,
			                            (result,
			                             current) => result +
			                                         $@"{
					                                         Rc4.Decrypt(Key(),
					                                                     current.ToBytes())
				                                         }");
		}

		/// <summary>
		///   Encrypting an <see cref="string" />.
		/// </summary>
		/// <param name="value">A <see cref="string" /></param>
		/// <returns>An encrypted <see cref="string" /></returns>
		public static System.String Encrypt(System.String value)
		{
			var position = 0;

			System.String Key()
			{
				position++;

				return $@"{Names.Default.CacheEnvironmentEncryptionKey}{position}";
			}

			return value.ToCharArray()
			            .Aggregate(System.String.Empty,
			                       (current,
			                        ch) => current +
			                               $@"{
					                               Rc4.Encrypt(Key(),
					                                           ch.ToString())
				                               };");
		}

		/// <summary>
		///   Find an <see cref="string" /> in the  <see cref="Diten.Word" />.
		/// </summary>
		/// <param name="word">An <see cref="string" />.</param>
		/// <returns>A <see cref="Word" /> that contains <see cref="string" /> value.</returns>
		public Word Find(System.String word)
		{
			if (!word.Contains(" "))
				return Find(Builders<Word>.Filter.Eq("Value",
				                                     Encrypt(word)))[0];

			const System.String paramName = "Word could not has ' ' (Space).";

			throw new ArgumentOutOfRangeException(paramName);
		}

		/// <summary>
		///   Load this word from database.
		/// </summary>
		/// <returns></returns>
		public new Word Load()
		{
			var _return = base.Load();

			if (_return != null) _return.Value = Decrypt(_return.Value);

			return _return;
		}

		/// <summary>
		///   Save this word into database.
		/// </summary>
		public void Save()
		{
			var holder = Encrypt(Value);

			if (!HasItem(Builders<Word>.Filter.Eq("Value",
			                                      holder)))
			{
				Value = holder;
				Save(this);
			}

			//ToDo: Check commented code
			//ID = Find(v => v.Value,
			//          holder)[0]
			//	.ID;
		}

		/// <summary>Returns this instance of <see cref="T:Diten.Word" />; no actual conversion is performed.</summary>
		/// <returns>The current word value.</returns>
		public override System.String ToString() => Value;
	}
}

//namespace Diten.Extensions
//{
//    public static class String
//    {
//        public static Word ToWord(this System.String str)
//        {
//            return ;
//        }
//    }
//}