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
// Creation Date: 2019/09/02 9:11 PM

#endregion

#region Used Directives

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Diten.Runtime
{
	public class Serialization
	{
		public static object Deserialize(byte[] objectBytes)
		{
			var memoryStream = new MemoryStream();

			memoryStream.Write(objectBytes, 0, objectBytes.Length);
			memoryStream.Position = 0;

			return new BinaryFormatter().Deserialize(memoryStream);
		}

		public static byte[] Serialize(object obj)
		{
			var _return = new MemoryStream();

			new BinaryFormatter().Serialize(_return, obj);

			return _return.ToArray();
		}
	}
}