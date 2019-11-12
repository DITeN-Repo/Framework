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

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    MD5 encryption.
	/// </summary>
	public static class Md5
	{
		/// <summary>
		///    Get MD5 hashed text.
		/// </summary>
		/// <param name="data">Text for encoding.</param>
		/// <returns>MD5 hashed text.</returns>
		public static System.String Encrypt(System.String data)
		{
			using (var md5Hash = MD5.Create())
			{
				return GetMd5Hash(md5Hash,
				                  data);
			}
		}

		private static System.String GetMd5Hash(HashAlgorithm md5Hash,
		                                 string input)
		{
			// Convert the input string to a byte array and compute the hash.
			var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			var sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			foreach (var t in data) sBuilder.Append(t.ToString("x2"));

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

		// Verify a hash against a string.
		public static bool VerifyMd5Hash(System.String input,
		                                 string hash)
		{
			// Hash the input.
			var hashOfInput = GetMd5Hash(MD5.Create(),
			                             input);

			// Create a StringComparer an compare the hashes.
			var comparer = StringComparer.OrdinalIgnoreCase;

			return 0 ==
			       comparer.Compare(hashOfInput,
			                        hash);
		}
	}
}