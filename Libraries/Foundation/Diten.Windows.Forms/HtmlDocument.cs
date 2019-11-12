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
// Creation Date: 2019/09/04 10:05 PM

#region Used Directives

using System.Net;
using System.Text;

#endregion

namespace Diten.Windows.Forms
{
	public class HtmlDocument: HtmlAgilityPack.HtmlDocument
	{
		public HtmlDocument() {}

		public HtmlDocument(System.String url) { Load(new WebClient {Encoding = Encoding.UTF8}.OpenRead(url)); }
	}
}