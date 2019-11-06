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
// Creation Date: 2019/08/15 4:35 PM

#region Used Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Diten.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace Diten
{
	[ComVisible(true)]
	[Serializable]
	[DefaultProperty("Value")]
	[Attributes.Type]
	public class String: WebObject<String>
	{
		/// <summary>
		///    Constructor.
		/// </summary>
		public String()
		{
			Value = string.Empty;
			Words = new Collections.Generic.List<Word>();
		}

		/// <inheritdoc />
		/// <summary>
		///    Constructor.
		/// </summary>
		/// <param name="value">
		///    A <see cref="string" /> that must be set in Value property of <see cref="Diten.String" />
		/// </param>
		public String(string value): this()
		{
			if (value == null) value = string.Empty;
			Value = value;
		}

		public String SerializedValue {get; private set;}

		/// <summary>
		///    Value of string.
		/// </summary>
		[BsonIgnore]
		public string Value
		{
			get
			{
				string _return = null;

				if (Words == null) return null;

				if (!Words.Count.Equals(0))
				{
					var decryptedWord = Words[0].Load();
					if (decryptedWord?.Value.IsNull() == true &&
					    decryptedWord.HasItem()) Words.Load();

					_return = Words.Aggregate(string.Empty,
					                          (current,
					                           word) => current + $@"{word.Value} ");
				}

				if (_return == null) return null;

				_return = _return.IsNull()
					          ? null
					          : _return.Substring(0,
					                              _return.Length - 1);

				return _return ?? string.Empty;
			}
			set
			{
				if (value == null)
				{
					Words.Load();

					return;
				}

				if (value.IsNull()) return;

				foreach (var word in value.Split(" ".ToCharArray())) Words.Add(new Word {Value = word});
			}
		}

		/// <summary>
		///    Get words collection in string.
		/// </summary>
		public Collections.Generic.List<Word> Words {get;}

		/// <summary>Determines whether the specified object instances are considered equal.</summary>
		/// <param name="a">The first Diten.String to compare. </param>
		/// <param name="b">The second Diten.String to compare. </param>
		/// <returns>
		///    <see langword="true" /> if the objects are considered equal; otherwise, <see langword="false" />. If both
		///    <paramref name="a" /> and <paramref name="b" /> are null, the method returns <see langword="true" />.
		/// </returns>
		public static bool Equals(String a,
		                          String b)
		{
			if (a.Value == b.Value) return true;
			if (a.IsNull() ||
			    b.IsNull()) return false;

			return a.Equals(b);
		}

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="obj">The object to compare with the current object. </param>
		/// <returns>
		///    <see langword="true" /> if the specified object  is equal to the current object; otherwise,
		///    <see langword="false" />.
		/// </returns>
		/// <inheritdoc cref="string" />
		public override bool Equals(object obj)
		{
			return RuntimeHelpers.Equals(this,
			                             obj);
		}

		public bool Equals(string value) { return Value.Equals(value); }

		/// <summary>
		///    Getting hash code of <see cref="Diten.String" /> value.
		/// </summary>
		/// <returns>A hash code of <see cref="Diten.String" /> value.</returns>
		public override int GetHashCode()
		{
			var hashCode = -310749264;
			//hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(SerializedValue);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
			hashCode = hashCode * -1521134295 +
			           EqualityComparer<Collections.Generic.List<Word>>.Default.GetHashCode(Words);

			return hashCode;
		}

		/// <summary>
		///    Check that string is <c>null</c> or not.<br/>
		///    This function check that string <c>IsNullOrEmpty</c> and <c>IsNullOrWhiteSpace</c>. If both functions return true value this
		///    function return true.
		/// </summary>
		/// <param name="value">An <see cref="string" />value.</param>
		/// <returns>True if string is null.</returns>
		public static bool IsNullString(string value) { return new String(value).IsNull(); }

		/// <summary>
		///    Detect that <see cref="Diten.String" /> is safe or not.
		/// </summary>
		/// <returns>True if string is safe.</returns>
		public bool IsSafe()
		{
			var range = Char.PrintableChars.ToList();

			return Value.ToCharArray().All(c1 => range.Any(c2 => c2.Ascii.Equals(c1)));
		}

		/// <summary>Determines whether two specified <see cref="String"/>s have the same <c>value</c>.</summary>
		/// <param name="a">The first <see cref="String"/> to <c>compare</c>, or <see langword="null" />. </param>
		/// <param name="b">The second <see cref="String"/> to <c>compare</c>, or <see langword="null" />. </param>
		/// <returns>
		///    <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />;
		///    otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator ==(String a,
		                               String b)
		{
			return Equals(a,
			              b);
		}

		/// <summary>
		///    Casting <see cref="string" /> to <see cref="Diten.String" />
		/// </summary>
		/// <param name="value">A <see cref="System.String" />.</param>
		public static implicit operator String(string value) { return new String {Value = value}; }

		/// <summary>
		///    Casting <see cref="Diten.String" /> to <see cref="string" />
		/// </summary>
		/// <param name="value">A <see cref="string" />.</param>
		public static implicit operator string(String value) { return value.Value; }

		/// <summary>Determines whether two specified <see cref="Diten.String" /> have different <c>value</c>.</summary>
		/// <param name="a">The first <see cref="Diten.String" /> to <c>compare</c>, or <see langword="null" />. </param>
		/// <param name="b">The second <see cref="Diten.String" /> to <c>compare</c>, or <see langword="null" />. </param>
		/// <returns>
		///    <see langword="true" /> if the value of <paramref name="a" /> is different from the value of <paramref name="b" />;
		///    otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator !=(String a,
		                               String b)
		{
			return !Equals(a,
			               b);
		}

		/// <summary>
		///    Saving <see cref="Diten.String" /> in database.
		/// </summary>
		public void Save() { Save(this); }

		/// <summary>
		///    Serialize current <see cref="String" />.
		/// </summary>
		/// <summary>
		///    <inheritdoc cref="Concept{TObject,TKey}.Serialize()" />
		/// </summary>
		/// <returns>A <see cref="Byte" />.</returns>
		public new Byte Serialize()
		{
			SerializedValue = Value;

			return base.Serialize();
		}

		/// <summary>
		///    Converting current <see cref="Diten.String" /> into safe <see cref="Diten.String" />.
		/// </summary>
		/// <returns>Represent a safe <see cref="Diten.String" />.</returns>
		public String ToSafeString() { return new String(Value.ToSafe()); }

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A <see cref="System.String" /> that represents the current object.</returns>
		public override string ToString() { return Value; }

		/// <summary>Returns this instance of <see cref="System.String" />; no actual conversion is performed.</summary>
		/// <returns>The current String value on System.String type.</returns>
		public string ToSystemString() { return Value; }

		/// <summary>
		///    Converting current <see cref="Diten.String" /> into safe string.
		/// </summary>
		/// <returns>Represent a safe <see cref="Diten.String" />.</returns>
		public String ToUnsafeString() { return new String(Value.ToUnsafe()); }
	}
}