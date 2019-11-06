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
// Creation Date: 2019/09/02 9:08 PM

#region Used Directives

using System;
using System.IO;
using System.Xml.Serialization;
using Diten.Collections.Generic;
using Diten.Runtime;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Objects
{
	public class Job: Object<Job>
	{
		public Job() {}

		public Job(object obj,
		           Type objectType)
		{
			var xmlSerializer = new XmlSerializer(objectType);
			var memoryStream = new MemoryStream();

			xmlSerializer.Serialize(memoryStream,
			                        obj);
			Data = new Byte(Serialization.Serialize(xmlSerializer.Deserialize(memoryStream)));
			ObjectType = objectType;
			Methods = new System.Collections.Generic.Dictionary<string, object[]>();
			Save(this);
		}

		public Byte Data {get;}

		public bool IsDone {get; set;}
		public System.Collections.Generic.Dictionary<string, object[]> Methods {get;}
		public Type ObjectType {get;}
		public string Sha1 => SHA1.Encrypt(Data);
	}
}