﻿#region DITeN Registration Info

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
	public class Rsa
	{
		public Rsa()
		{
			UnicodeEncoding=new UnicodeEncoding();

			//RsaCryptoServiceProvider = new RSACryptoServiceProvider(new CspParameters(10,"sadas","asdasd", new CryptoKeySecurity(new CommonSecurityDescriptor(true,true, ControlFlags.SelfRelative, new SecurityIdentifier(new IntPtr()), )), ));
		}

		public RSACryptoServiceProvider RsaCryptoServiceProvider { get; }

		public UnicodeEncoding UnicodeEncoding { get; }

		public string Decrypt(string value)
		{
			return UnicodeEncoding.GetString(Decrypt(UnicodeEncoding.GetBytes(value),
				RsaCryptoServiceProvider.ExportParameters(true), false));
		}

		public static byte[] Decrypt(byte[] data,
			RSAParameters rsaKey,
			bool doOaepPadding)
		{
			byte[] decryptedData;

			using(var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaKey);
				decryptedData=rsa.Decrypt(data, doOaepPadding);
			}

			return decryptedData;
		}

		public string Encrypt(string value)
		{
			return UnicodeEncoding.GetString(Encrypt(UnicodeEncoding.GetBytes(value),
				RsaCryptoServiceProvider.ExportParameters(false), false));
		}

		public static byte[] Encrypt(byte[] data,
			RSAParameters rsaKey,
			bool doOaepPadding)
		{
			byte[] encryptedData;

			using(var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaKey);
				encryptedData=rsa.Encrypt(data, doOaepPadding);
			}

			return encryptedData;
		}
	}
}