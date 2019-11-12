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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Diten.Collections.Generic;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Collections.Immutable
{
	public class HistoryDictionary<TObjectId, TObject>: IImmutableDictionary<TObjectId, TObject>
		where TObject: IObject<System.Object, ISHA>
	{
		public IImmutableDictionary<TObjectId, TObject> Add(TObjectId key,
		                                                    TObject value)
		{
			throw new NotImplementedException();
		}

		public IImmutableDictionary<TObjectId, TObject> AddRange(IEnumerable<KeyValuePair<TObjectId, TObject>> pairs)
		{
			throw new NotImplementedException();
		}

		public IImmutableDictionary<TObjectId, TObject> Clear() { throw new NotImplementedException(); }

		public Boolean Contains(KeyValuePair<TObjectId, TObject> pair) { throw new NotImplementedException(); }

		public Boolean ContainsKey(TObjectId key) { throw new NotImplementedException(); }

		public Int32 Count {get;}
		public IEnumerator<KeyValuePair<TObjectId, TObject>> GetEnumerator() { throw new NotImplementedException(); }

		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

		public TObject this[TObjectId key] => throw new NotImplementedException();

		public IEnumerable<TObjectId> Keys {get;}

		public IImmutableDictionary<TObjectId, TObject> Remove(TObjectId key) { throw new NotImplementedException(); }

		public IImmutableDictionary<TObjectId, TObject> RemoveRange(IEnumerable<TObjectId> keys) { throw new NotImplementedException(); }

		public IImmutableDictionary<TObjectId, TObject> SetItem(TObjectId key,
		                                                        TObject value)
		{
			throw new NotImplementedException();
		}

		public IImmutableDictionary<TObjectId, TObject> SetItems(IEnumerable<KeyValuePair<TObjectId, TObject>> items)
		{
			throw new NotImplementedException();
		}

		public Boolean TryGetKey(TObjectId equalKey,
		                      out TObjectId actualKey)
		{
			throw new NotImplementedException();
		}

		public Boolean TryGetValue(TObjectId key,
		                        out TObject value)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TObject> Values {get;}
	}
}