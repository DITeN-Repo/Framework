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

using System.IO;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    Base64Text encryption and decryption.
	/// </summary>
	public static class Base64Text
	{
		/// <summary>
		///    Text base64 decoding.
		/// </summary>
		/// <param name="base64EncodedData">Base64 encoded data.</param>
		/// <returns>Decoded text.</returns>
		public static string Decrypt(string base64EncodedData) { return Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData)); }

		/// <summary>
		///    Text base64 encoding.
		/// </summary>
		/// <param name="data">Plain text for encoding.</param>
		/// <returns>Encoded text.</returns>
		public static string Encrypt(string data) { return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(data)); }

		/// <summary>
		///    Text base64 encoding.
		/// </summary>
		/// <param name="data">Plain text for encoding.</param>
		/// <returns>Encoded text.</returns>
		public static string Encrypt(Stream data) { return Encrypt(Convert.ToString(new MemoryStream(data.ToBytes()))); }
	}
}