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
// Creation Date: 2019/09/02 7:01 PM

#region Used Directives

using System.IO;
using System.IO.Compression;
using System.Text;

#endregion

namespace Diten.IO
{
	public class Compression
	{
		public static System.String UnZip(System.String value)
		{
			//Transform string into byte[]
			var byteArray = new byte[value.Length];
			var index = 0;
			foreach (var item in value.ToCharArray()) byteArray[index++] = (byte) item;

			//Prepare for decompress
			var memoryStream = new MemoryStream(byteArray);
			var gZipStream = new GZipStream(memoryStream,
			                                CompressionMode.Decompress);

			//Reset variable to collect uncompressed result
			byteArray = new byte[byteArray.Length];

			//Decompress
			var rByte = gZipStream.Read(byteArray,
			                            0,
			                            byteArray.Length);

			//Transform byte[] unzip data to string
			var stringBuilder = new StringBuilder(rByte);

			//Read the number of bytes GZipStream red and do not a for each bytes in
			//resultByteArray;
			for (var i = 0;
			     i < rByte;
			     i++) stringBuilder.Append((char) byteArray[i]);

			gZipStream.Close();
			memoryStream.Close();
			gZipStream.Dispose();
			memoryStream.Dispose();

			return stringBuilder.ToString();
		}

		public static System.String Zip(System.String value)
		{
			//Transform string into byte[]  
			var byteArray = new byte[value.Length];
			var index = 0;
			foreach (var item in value.ToCharArray()) byteArray[index++] = (byte) item;

			//Prepare for compress
			var memoryStream = new MemoryStream();
			var gZipStream = new GZipStream(memoryStream,
			                                CompressionMode.Compress);

			//Compress
			gZipStream.Write(byteArray,
			                 0,
			                 byteArray.Length);

			//Close, DO NOT FLUSH cause bytes will go missing...
			gZipStream.Close();

			//Transform byte[] zip data to string
			byteArray = memoryStream.ToArray();
			var stringBuilder = new StringBuilder(byteArray.Length);
			foreach (var item in byteArray) stringBuilder.Append((char) item);

			memoryStream.Close();
			gZipStream.Dispose();
			memoryStream.Dispose();

			return stringBuilder.ToString();
		}
	}
}