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

#region Used Directives

using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Diten.Attributes;
using Diten.Parameters;

#endregion

namespace Diten.Runtime
{
	public class Serialization
	{
		public static object Deserialize(byte[] objectBytes)
		{
			var memoryStream = new MemoryStream();

			memoryStream.Write(objectBytes,
			                   0,
			                   objectBytes.Length);
			memoryStream.Position = 0;

			return new BinaryFormatter().Deserialize(memoryStream);
		}

		public static byte[] Serialize(System.Object obj)
		{
			var output = new MemoryStream();

			foreach (var propertyInfo in from propertyInfo in obj.GetType().GetProperties()
			                             from name in propertyInfo.Attributes.GetNames()
			                             where name == typeof(NonSerializable).Name ||
			                                   name == typeof(NonSignaturized).Name
			                             select propertyInfo)
			{
				propertyInfo.SetValue(obj,
				                      null);
			}

			new BinaryFormatter().Serialize(output,
			                                obj);

			return output.ToArray();
		}
	}
}