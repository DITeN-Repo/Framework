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

using System.Security.Cryptography;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	public class Rsa
	{
		public Rsa() { UnicodeEncoding = new UnicodeEncoding(); }

		public RSACryptoServiceProvider RsaCryptoServiceProvider {get;}

		public UnicodeEncoding UnicodeEncoding {get;}

		public static byte[] Decrypt(byte[] data,
		                             RSAParameters rsaKey,
		                             bool doOaepPadding)
		{
			byte[] decryptedData;

			using (var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaKey);
				decryptedData = rsa.Decrypt(data,
				                            doOaepPadding);
			}

			return decryptedData;
		}

		public System.String Decrypt(System.String value)
		{
			return UnicodeEncoding.GetString(Decrypt(UnicodeEncoding.GetBytes(value),
			                                         RsaCryptoServiceProvider.ExportParameters(true),
			                                         false));
		}

		public static byte[] Encrypt(byte[] data,
		                             RSAParameters rsaKey,
		                             bool doOaepPadding)
		{
			byte[] encryptedData;

			using (var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaKey);
				encryptedData = rsa.Encrypt(data,
				                            doOaepPadding);
			}

			return encryptedData;
		}

		public System.String Encrypt(System.String value)
		{
			return UnicodeEncoding.GetString(Encrypt(UnicodeEncoding.GetBytes(value),
			                                         RsaCryptoServiceProvider.ExportParameters(false),
			                                         false));
		}
	}
}