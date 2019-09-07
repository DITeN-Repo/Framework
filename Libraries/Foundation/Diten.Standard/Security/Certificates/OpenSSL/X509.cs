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

namespace Diten.Security.Certificates.OpenSSL
{
	public class X509
	{
		public void GenerateCertificate()
		{
			//X509Name issuer = new X509Name("issuer");

			//X509Name subject = new X509Name("subject");
			//RSA rsa = new RSA();
			//rsa.GenerateKeys(512, 0x10021, null, null);
			//CryptoKey key = new CryptoKey(rsa);

			//X509Certificate cert = new X509Certificate(123, subject, issuer, key, DateTime.Now,
			//    DateTime.Now.AddDays(200));

			//File.WriteAllText("D:\\temp\\public.txt", rsa.PublicKeyAsPEM);
			//File.WriteAllText("D:\\temp\\private.txt", rsa.PrivateKeyAsPEM);

			//BIO bio = BIO.File("D:/temp/cert.cer", "w");
			//cert.Write(bio);
		}
	}
}