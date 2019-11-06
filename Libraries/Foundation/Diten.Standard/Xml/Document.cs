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
// Creation Date: 2019/09/02 12:34 AM

#region Used Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

#endregion

namespace Diten.Xml
{
	public class Document
	{
		public Document() {}

		public Document(XmlDocument xmlDocument) { XmlDocument = xmlDocument; }

		private string[] Path {get; set;}

		private int PathCount {get; set;}

		public XmlDocument XmlDocument {get; set;}

		public List<Dictionary<string, string>> GetAttributes(string path)
		{
			Path = path.Split(".".ToCharArray());

			return (from XmlNode node in ReadNodesRecursively(XmlDocument.ChildNodes,
			                                                  Path[0])
				        .ChildNodes
			        select ReadAttributes(node)).ToList();
		}

		private static Dictionary<string, string> ReadAttributes(XmlNode xmlNode)
		{
			return (xmlNode.Attributes ?? throw new InvalidOperationException(@"XML node attributes is empty."))
			       .Cast<XmlAttribute>()
			       .ToDictionary(attribute => attribute.Name,
			                     attribute => attribute.Value);
		}

		private XmlNode ReadNodesRecursively(IEnumerable childNodes,
		                                     string nodeName)
		{
			XmlNode _return = null;

			foreach (XmlNode node in childNodes)
			{
				if (!node.Name.Equals(nodeName)) continue;

				PathCount += 1;

				if (!PathCount.Equals(Path.Length))
					return ReadNodesRecursively(node.ChildNodes,
					                            Path[PathCount]);

				_return = node;

				break;
			}

			return _return;
		}
	}
}