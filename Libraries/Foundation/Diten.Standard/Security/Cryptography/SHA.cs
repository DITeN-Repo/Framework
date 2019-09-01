#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Diten.Security.Cryptography
{
	public enum SHATypes
	{
		SHA1,
		SHA256,
		SHA384,
		SHA512
	}

	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public abstract class SHA<TSHA> where TSHA : HashAlgorithm
	{
		/// <summary>
		///    Get SHA of type T hashed text.
		/// </summary>
		/// <param name="data">Data for encryption.</param>
		/// <returns>An SHA of type T encrypted data.</returns>
		public static string Encrypt(string data)
		{
			return Encrypt(new Byte(data.ToBytes()));
		}

		/// <summary>
		///    Get SHA of type T hashed text.
		/// </summary>
		/// <param name="data">Data for encryption.</param>
		/// <returns>An SHA of type T encrypted data.</returns>
		public static string Encrypt(object data)
		{
			return Encrypt(new Byte(data.ToBytes()));
		}

		/// <summary>
		///    Get SHA of type T hashed text.
		/// </summary>
		/// <param name="data">Data for encryption.</param>
		/// <returns>An SHA of type T encrypted data.</returns>
		public static string Encrypt(Byte data)
		{
			var sha = typeof(TSHA).GetMethod(Enum.GetName(Enum.MethodNames.Create), Type.EmptyTypes)
				?.Invoke(Activator.CreateInstance(typeof(TSHA)),
					BindingFlags.Default, null, null,
					CultureInfo.CurrentCulture);

			var holder = sha?.GetType().GetMethod(Enum.GetName(Enum.MethodNames.ComputeHash));

			//convert the input text to array of bytes
			var hashData = (byte[])holder?.Invoke(holder, new object[] { data.Value });

			//create new instance of StringBuilder to save hashed data
			var returnValue = new StringBuilder();

			if(hashData==null)
				return string.Empty;

			//loop for each byte and add it to StringBuilder
			foreach(var t in hashData)
				returnValue.Append(t.ToString());

			// return hexadecimal string
			return returnValue.ToString();
		}
	}

	/// <summary>
	///    SHA1 encryption.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public abstract class SHA1:SHA<System.Security.Cryptography.SHA1>, ISHA
	{
	}

	/// <summary>
	///    SHA256 encryption.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public abstract class SHA256:SHA<SHA256Managed>, ISHA
	{
	}

	/// <summary>
	///    SHA384 encryption.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public abstract class SHA384:SHA<SHA384Managed>, ISHA
	{
	}

	/// <summary>
	///    SHA512 encryption.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public abstract class SHA512:SHA<SHA512Managed>, ISHA
	{
	}
}