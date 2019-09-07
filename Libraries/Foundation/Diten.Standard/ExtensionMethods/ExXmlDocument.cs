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
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using System.Xml;

#endregion

namespace Diten
{
	public static class ExXmlDocument
	{
		/// <summary>
		///    Loading XML document into the <see cref="System.Xml.XmlDocument" /> object on memory.
		/// </summary>
		/// <param name="document">Current document that must holding the xml document content..</param>
		/// <param name="xml">Xml document that must be loaded into the memory.</param>
		public static XmlDocument LoadXmlDocument(this XmlDocument document, string xml)
		{
			var xmlDocument = new XmlDocument();

			xmlDocument.LoadXml(xml);

			return xmlDocument;
		}
	}
}