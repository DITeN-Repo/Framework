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
// Creation Date: 2019/08/15 4:35 PM

#endregion

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
	public class String : WebObject<String>
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
		public String(string value) : this()
		{
			if (value == null)
				value = string.Empty;
			Value = value;
		}

		public String SerializedValue { get; private set; }

		/// <summary>
		///    Value of string.
		/// </summary>
		[BsonIgnore]
		public string Value
		{
			get
			{
				string _return = null;

				if (Words == null)
					return null;

				if (!Words.Count.Equals(0))
				{
					var decryptedWord = Words[0].Load();
					if (decryptedWord?.Value.IsNull() == true &&
					    decryptedWord.HasItem())
						Words.Load();

					_return = Words.Aggregate(string.Empty, (current,
							word) => current + $@"{word.Value} ");
				}

				if (_return == null)
					return null;

				_return = _return.IsNull()
					? null
					: _return.Substring(0, _return.Length - 1);

				return _return ?? string.Empty;
			}
			set
			{
				if (value == null)
				{
					Words.Load();
					return;
				}

				if (value.IsNull())
					return;

				foreach (var word in value.Split(" ".ToCharArray()))
					Words.Add(new Word {Value = word});
			}
		}

		/// <summary>
		///    Get words collection in string.
		/// </summary>
		public Collections.Generic.List<Word> Words { get; }

		public bool Equals(string value) => Value.Equals(value);

		/// <summary>
		///    Casting <see cref="string" /> to <see cref="Diten.String" />
		/// </summary>
		/// <param name="value">A <see cref="Diten.String" />.</param>
		public static implicit operator String(string value) => new String {Value = value};

		/// <summary>
		///    Casting <see cref="Diten.String" /> to <see cref="string" />
		/// </summary>
		/// <param name="value">A <see cref="string" />.</param>
		public static implicit operator string(String value) => value.Value;

		/// <summary>
		///    Saving string in database.
		/// </summary>
		public void Save()
		{
			Save(this);
		}

		/// <summary>
		///    Serializing string value.
		/// </summary>
		public void Serialize()
		{
			SerializedValue = Value;
		}

		/// <summary>Returns this instance of <see cref="T:Syatem.String" />; no actual conversion is performed.</summary>
		/// <returns>The current String value on System.String type.</returns>
		public string ToSystemString() => Value;

		/// <summary>Determines whether two specified Strings have the same value.</summary>
		/// <param name="a">The first String to compare, or <see langword="null" />. </param>
		/// <param name="b">The second String to compare, or <see langword="null" />. </param>
		/// <returns>
		///    <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />;
		///    otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator ==(String a, String b) => Equals(a, b);

		/// <summary>Determines whether two specified Strings have different values.</summary>
		/// <param name="a">The first String to compare, or <see langword="null" />. </param>
		/// <param name="b">The second String to compare, or <see langword="null" />. </param>
		/// <returns>
		///    <see langword="true" /> if the value of <paramref name="a" /> is different from the value of <paramref name="b" />;
		///    otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator !=(String a, String b) => !Equals(a, b);

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString() => Value;

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="obj">The object to compare with the current object. </param>
		/// <returns>
		///    <see langword="true" /> if the specified object  is equal to the current object; otherwise,
		///    <see langword="false" />.
		/// </returns>
		/// <inheritdoc cref="string" />
		public override bool Equals(object obj) => RuntimeHelpers.Equals(this, obj);

		/// <summary>Determines whether the specified object instances are considered equal.</summary>
		/// <param name="a">The first Diten.String to compare. </param>
		/// <param name="b">The second Diten.String to compare. </param>
		/// <returns>
		///    <see langword="true" /> if the objects are considered equal; otherwise, <see langword="false" />. If both
		///    <paramref name="a" /> and <paramref name="b" /> are null, the method returns <see langword="true" />.
		/// </returns>
		public static bool Equals(String a, String b)
		{
			if (a.Value == b.Value)
				return true;
			if (a.IsNull() || b.IsNull())
				return false;
			return a.Equals(b);
		}

		/// <summary>
		///    Check that string is null or not.
		///    This function check that string IsNullOrEmpty and IsNullOrWhiteSpace. If both functions return true value this
		///    function return true.
		/// </summary>
		/// <param name="value">An <see cref="String" />value.</param>
		/// <returns>True if string is null.</returns>
		public static bool IsNullString(string value) => new String(value).IsNull();

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
		///    Detect that <see cref="Diten.String" /> is safe or not.
		/// </summary>
		/// <returns>True if string is safe.</returns>
		public bool IsSafe()
		{
			var range = Char.PrintableChars.ToList();

			return Value.ToCharArray().All(c1 => range.Any(c2 => c2.Ascii.Equals(c1)));
		}

		/// <summary>
		///    Converting current <see cref="Diten.String" /> into safe string.
		/// </summary>
		/// <returns>Represent a safe <see cref="Diten.String" />.</returns>
		public String ToSafeString() => new String(Value.ToSafe());

		/// <summary>
		///    Converting current <see cref="Diten.String" /> into safe string.
		/// </summary>
		/// <returns>Represent a safe <see cref="Diten.String" />.</returns>
		public String ToUnsafeString() => new String(Value.ToUnsafe());
	}
}