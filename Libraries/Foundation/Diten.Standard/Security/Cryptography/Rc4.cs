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

#region Used Directives

using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    RC4 encryption.
	/// </summary>
	public static class Rc4
	{
		/// <summary>
		///    Get decrypted text data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Encrypted Data for decryption.</param>
		/// <returns>Text decrypted data.</returns>
		public static System.String Decrypt(System.String key,
		                             byte[] data)
		{
			return data == null
				       ? null
				       : Decrypt(Encoding.Unicode.GetBytes(key),
				                 data);
		}

		/// <summary>
		///    Get decrypted text data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Encrypted Data for decryption.</param>
		/// <returns>Text decrypted data.</returns>
		public static System.String Decrypt(System.String key,
		                             string data)
		{
			return data == null
				       ? null
				       : Decrypt(Encoding.Unicode.GetBytes(key),
				                 Encoding.Unicode.GetBytes(data));
		}

		/// <summary>
		///    Get decrypted binary data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Binary data for decryption.</param>
		/// <returns>Binary decrypted data.</returns>
		public static System.String Decrypt(byte[] key,
		                             byte[] data)
		{
			return Encoding.Unicode.GetString(EncryptOutput(key,
			                                                data)
				                                  .ToArray());
		}

		/// <summary>
		///    Get encrypt text data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Data for encryption.</param>
		/// <returns>Text RC4 encrypted data.</returns>
		public static System.String Encrypt(System.String key,
		                             byte[] data)
		{
			return data == null
				       ? null
				       : Encrypt(Encoding.Unicode.GetBytes(key),
				                 data);
		}

		/// <summary>
		///    Get encrypt text data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Data for encryption.</param>
		/// <returns>Text RC4 encrypted data.</returns>
		public static System.String Encrypt(System.String key,
		                             string data)
		{
			return data == null
				       ? null
				       : Encrypt(Encoding.Unicode.GetBytes(key),
				                 Encoding.Unicode.GetBytes(data));
		}

		/// <summary>
		///    Get encrypted binary data.
		/// </summary>
		/// <param name="key">Key of encryption.</param>
		/// <param name="data">Binary data for encryption.</param>
		/// <returns>Binary encrypted data.</returns>
		public static System.String Encrypt(byte[] key,
		                             byte[] data)
		{
			return Encoding.Unicode.GetString(EncryptOutput(key,
			                                                data)
				                                  .ToArray());
		}

		private static byte[] EncryptInitalize(IReadOnlyList<System.Byte> key)
		{
			var s = Enumerable.Range(0,
			                         256)
			                  .Select(i => (byte) i)
			                  .ToArray();

			for (int i = 0,
			         j = 0;
			     i < 256;
			     i++)
			{
				j = (j + key[i % key.Count] + s[i]) & 255;

				Swap(s,
				     i,
				     j);
			}

			return s;
		}

		private static IEnumerable<System.Byte> EncryptOutput(IReadOnlyList<System.Byte> key,
		                                               IEnumerable<System.Byte> data)
		{
			var s = EncryptInitalize(key);
			var i = 0;
			var j = 0;

			return data.Select(b =>
			                   {
				                   i = (i + 1) & 255;
				                   j = (j + s[i]) & 255;

				                   Swap(s,
				                        i,
				                        j);

				                   return (byte) (b ^ s[(s[i] + s[j]) & 255]);
			                   });
		}

		private static void Swap(IList<System.Byte> s,
		                         int i,
		                         int j)
		{
			var c = s[i];

			s[i] = s[j];
			s[j] = c;
		}
	}
}