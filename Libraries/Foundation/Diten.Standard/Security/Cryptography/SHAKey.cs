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
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Security.Cryptography
{
	public class SHAKey<TKey> : IDisposable
		where TKey : ISHA
	{
		public SHAKey(object obj) => Holder = obj;

		private object Holder { get; }

		public string Value
		{
			get
			{
				if (typeof(TKey) == typeof(SHA1))
					return SHA1.Encrypt(Holder);
				if (typeof(TKey) == typeof(SHA256))
					return SHA256.Encrypt(Holder);
				if (typeof(TKey) == typeof(SHA384))
					return SHA384.Encrypt(Holder);
				if (typeof(TKey) == typeof(SHA512))
					return SHA512.Encrypt(Holder);

				throw new ArgumentException("SHA algorithme not recognized.");
			}
		}

		public void Dispose()
		{
		}

		public static implicit operator string(SHAKey<TKey> value) => value.Value;
	}
}