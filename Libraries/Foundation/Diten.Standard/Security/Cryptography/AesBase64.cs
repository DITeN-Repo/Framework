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

using System.Security.Cryptography;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	/// <summary>
	///    AesBase64 encription.
	/// </summary>
	public static class AesBase64
	{
		private const string Salt = "a2RnHetrDj5nJKHgHJg76544c1dl";
		private const string Iv = "a2RnHetrDj5nc1dl";

		/// <summary>
		///    Get decrypted AesBase64 data.
		/// </summary>
		/// <param name="data">Text data for eecryption.</param>
		/// <param name="password">Password for eecryption.</param>
		/// <returns>Text decrypted data.</returns>
		public static string Decrypt(string data,
			string password) =>
			Decrypt(data, password, Salt, Iv);

		/// <summary>
		///    Get decrypted AesBase64 data.
		/// </summary>
		/// <param name="data">Text data for eecryption.</param>
		/// <param name="password">Password for eecryption.</param>
		/// <param name="salt">Salt data for eecryption.</param>
		/// <param name="iv">16 byte IV data for eecryption.</param>
		/// <returns>Text decrypted data.</returns>
		public static string Decrypt(string data,
			string password,
			string salt,
			string iv)
		{
			using (var csp = new AesCryptoServiceProvider())
			{
				var cryptoTransform = GetCryptoTransform(csp, password, salt, iv, false);
				var output = System.Convert.FromBase64String(data);
				var decryptedOutput = cryptoTransform.TransformFinalBlock(output, 0, output.Length);

				return Encoding.UTF8.GetString(decryptedOutput);
			}
		}

		/// <summary>
		///    Get encrypted AesBase64 data.
		/// </summary>
		/// <param name="data">Text data for encryption.</param>
		/// <param name="password">Password for eecryption.</param>
		/// <returns>Text encrypted data.</returns>
		public static string Encrypt(string data,
			string password) =>
			Encrypt(data, password, Salt, Iv);

		/// <summary>
		///    Get encrypted AesBase64 data.
		/// </summary>
		/// <param name="data">Text data for encryption.</param>
		/// <param name="password">Password for eecryption.</param>
		/// <param name="salt">Salt data for eecryption.</param>
		/// <param name="iv">16 byte IV data for eecryption.</param>
		/// <returns>Text encrypted data.</returns>
		public static string Encrypt(string data,
			string password,
			string salt,
			string iv)
		{
			using (var csp = new AesCryptoServiceProvider())
			{
				var cryptoTransform = GetCryptoTransform(csp, password, salt, iv, true);
				var inputBuffer = Encoding.UTF8.GetBytes(data);
				var output = cryptoTransform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

				return System.Convert.ToBase64String(output);
			}
		}

		private static ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider cryptoServiceProvider,
			string password,
			string salt,
			string iv,
			bool encrypting)
		{
			cryptoServiceProvider.Mode = CipherMode.CBC;
			cryptoServiceProvider.Padding = PaddingMode.PKCS7;
			var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), 65536);
			var key = spec.GetBytes(16);

			cryptoServiceProvider.IV = Encoding.UTF8.GetBytes(iv);
			cryptoServiceProvider.Key = key;

			return encrypting ? cryptoServiceProvider.CreateEncryptor() : cryptoServiceProvider.CreateDecryptor();
		}
	}
}