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

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Diten.Collections.Generic;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Collections.Immutable
{
	public class HistoryDictionary<TObjectId, TObject> : IImmutableDictionary<TObjectId, TObject>
		where TObject : Object<object, ISHA>
	{
		public IEnumerator<KeyValuePair<TObjectId, TObject>> GetEnumerator() => throw new NotImplementedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public int Count { get; }

		public bool ContainsKey(TObjectId key) => throw new NotImplementedException();

		public bool TryGetValue(TObjectId key, out TObject value) => throw new NotImplementedException();

		public TObject this[TObjectId key] => throw new NotImplementedException();

		public IEnumerable<TObjectId> Keys { get; }
		public IEnumerable<TObject> Values { get; }

		public IImmutableDictionary<TObjectId, TObject> Clear() => throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> Add(TObjectId key, TObject value) =>
			throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> AddRange(IEnumerable<KeyValuePair<TObjectId, TObject>> pairs) =>
			throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> SetItem(TObjectId key, TObject value) =>
			throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> SetItems(IEnumerable<KeyValuePair<TObjectId, TObject>> items) =>
			throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> RemoveRange(IEnumerable<TObjectId> keys) =>
			throw new NotImplementedException();

		public IImmutableDictionary<TObjectId, TObject> Remove(TObjectId key) => throw new NotImplementedException();

		public bool Contains(KeyValuePair<TObjectId, TObject> pair) => throw new NotImplementedException();

		public bool TryGetKey(TObjectId equalKey, out TObjectId actualKey) => throw new NotImplementedException();
	}
}