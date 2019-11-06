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
// Creation Date: 2019/10/08 3:17 PM

#region Used Directives

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

#endregion

// ReSharper disable InconsistentNaming

namespace Diten.Windows.Applications.Tools.Official.Bookmarks
{
	public partial class FormBookmarksOptimizer: Form
	{
		public FormBookmarksOptimizer() { InitializeComponent(); }

		protected void ImportToolStripMenuItem_Click(object sender,
		                                             EventArgs e)
		{
			toolStripStatusLabelInformation.Text = 0.ToString();

			// ReSharper disable once StringLiteralTypo
			var sourceFile = $@"{path}\nn.html";
			toolStripProgressBar.Value = 0;
			webBrowser.Url = new Uri(sourceFile);
			webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
		}

		private readonly string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Settings\FireFox";

		private void WebBrowser_DocumentCompleted(object sender,
		                                          WebBrowserDocumentCompletedEventArgs e)
		{
			var destFile = $@"{path}\DataSet.xml";

			var htmlDocument = webBrowser.Document;
			var tagsList = new List<string>
			{
				"h3",
				"a"
			};
			var attributesList = new List<string>
			{
				"HREF",
				"ADD_DATE",
				"LAST_MODIFIED",
				"ICON_URI",
				"ICON",
				"SHORTCUTURL",
				"TAGS"
			};

			if (htmlDocument != null &&
			    htmlDocument.Body != null)
			{
				if (!File.Exists(destFile))
				{
					var holderHtmlDocument = new HtmlDocument();
					holderHtmlDocument.LoadHtml(htmlDocument.Body.InnerHtml);

					var row = dataSetBookmarks.DataTableBookmarks.NewDataTableBookmarksRow();
					row.ID = 1;
					row.ADD_DATE = DateTime.Now.ToLong().ToString();
					row.HTMLTAG = treeViewCategories.Nodes[0].Text;
					row.ICON_URI = string.Empty;
					row.LAST_MODIFIED = DateTime.Now.ToLong().ToString();
					row.PID = 0;
					row.SHORTCUTURL = string.Empty;
					row.TAGS = string.Empty;
					row.TEXT = treeViewCategories.Nodes[0].Text;
					row.HREF = string.Empty;
					row.ICON = string.Empty;

					AddDataTableBookmarksRow(row);
					ReadHtml(holderHtmlDocument,
					         row.ID);

					dataSetBookmarksOptimizer.DataTableBookmarks.AcceptChanges();

					File.WriteAllText(destFile,
					                  dataSetBookmarksOptimizer.DataTableBookmarks.DataSet.GetXml());
				}

				using (var xmlReader = new XmlTextReader(new FileStream(destFile,
				                                                        FileMode.Open)))
				{
					dataSetBookmarksOptimizer.DataTableBookmarks.DataSet.ReadXml(xmlReader);
				}

				toolStripProgressBar.Value = 0;
				var rootNode = treeViewCategories.Nodes[0];
				AddTreeNodes(rootNode,
				             dataSetBookmarksOptimizer.DataTableBookmarks
				                                      .Where(r => r.PID == 0)
				                                      .OrderBy(o => o.TEXT)
				                                      .ToList());
				rootNode.Expand();
			}

			void ReadHtml(HtmlDocument htmlAgilityPackDocument,
			              int pid)
			{
				if (htmlAgilityPackDocument.DocumentNode.ChildNodes != null)
				{
					var htmlElements = htmlAgilityPackDocument.DocumentNode.ChildNodes.Where(elm => elm.ChildNodes.Count > 0).ToList();
					toolStripProgressBar.Maximum += htmlElements.Count;

					foreach (var element in htmlElements)
					{
						var row = dataSetBookmarksOptimizer.DataTableBookmarks.NewDataTableBookmarksRow();

						row.ID = dataSetBookmarksOptimizer.DataTableBookmarks.Rows.Count + 1;
						row.PID = pid;
						row.HTMLTAG = element.OriginalName.ToUpper();
						row.TEXT = tagsList.Any(n => string.Equals(n,
						                                           element.OriginalName,
						                                           StringComparison.CurrentCultureIgnoreCase))
							           ? element.InnerText
							           : element.OriginalName;
						row.ADD_DATE = DateTime.Now.ToLong().ToString();
						row.LAST_MODIFIED = DateTime.Now.ToLong().ToString();

						foreach (var attribute in attributesList.Where(attr => element.Attributes.Any(a => a.OriginalName == attr)))
							row[attribute] = element.Attributes.First(a => a.OriginalName == attribute).Value;

						AddDataTableBookmarksRow(row);

						toolStripStatusLabelInformation.Text = (int.Parse(toolStripStatusLabelInformation.Text) + 1).ToString();
						toolStripProgressBar.Value++;
						Application.DoEvents();

						if (element.ChildNodes.Count > 0)
							ReadHtml(PrepHtmlDocument(element),
							         row.ID);
					}
				}

				HtmlDocument PrepHtmlDocument(HtmlNode htmlNode)
				{
					var holderHtmlDocument = new HtmlDocument();
					holderHtmlDocument.LoadHtml(htmlNode.InnerHtml);

					return holderHtmlDocument;
				}
			}

			void AddDataTableBookmarksRow(DataSetBookmarks.DataTableBookmarksRow row)
			{
				dataSetBookmarksOptimizer.DataTableBookmarks.AddDataTableBookmarksRow(row.ID,
				                                                                      row.PID,
				                                                                      row.HTMLTAG,
				                                                                      row.HREF,
				                                                                      row.LAST_MODIFIED,
				                                                                      row.ICON,
				                                                                      row.SHORTCUTURL,
				                                                                      row.TAGS,
				                                                                      row.ADD_DATE,
				                                                                      row.ICON_URI,
				                                                                      row.TEXT);
			}

			void AddTreeNodes(TreeNode parenTreeNode,
			                  IReadOnlyCollection<DataSetBookmarks.DataTableBookmarksRow> dataRowCollection)
			{
				toolStripProgressBar.Maximum += dataRowCollection.Count;

				foreach (var dataRow in dataRowCollection)
				{
					toolStripProgressBar.Value++;
					Application.DoEvents();

					//switch (dataRow.HTMLTAG)
					//{
					//	case "A": continue;
					//	case "P": continue;
					//	case "DT": continue;
					//	case "Root":
					//		AddTreeNodes(parenTreeNode,
					//		             dataSetBookmarksOptimizer.DataTableBookmarks.Where(r => r.PID == dataRow.ID).OrderBy(o => o.TEXT).ToList());

					//		break;

					//	case "DL":
					//		AddTreeNodes(parenTreeNode,
					//		             dataSetBookmarksOptimizer.DataTableBookmarks.Where(r => r.PID == dataRow.ID).OrderBy(o => o.TEXT).ToList());

					//		break;
					//	case "H3":
					//		var treeNode = new TreeNode {Text = $@"{dataRow.TEXT} - [ID: {dataRow.ID}, PID: {dataRow.PID}]", Name = $@"Node{dataRow.ID}"};
					//		treeNode.Expand();
					//		parenTreeNode.Nodes.Add(treeNode);
					//		//AddTreeNodes(treeNode,
					//		//             dataSetBookmarksOptimizer.DataTableBookmarks.Where(r => r.PID == dataRow.ID).OrderBy(o => o.TEXT).ToList());

					//		break;
					//}
					if (dataRow.HTMLTAG.ToUpper() == "A") continue;

					var treeNode =
						new TreeNode {Text = $@"{dataRow.TEXT.ToUpper()} - [ID: {dataRow.ID}, PID: {dataRow.PID}]", Name = $@"Node{dataRow.ID}"};
					treeNode.Expand();
					parenTreeNode.Nodes.Add(treeNode);
					AddTreeNodes(treeNode,
					             dataSetBookmarksOptimizer.DataTableBookmarks.Where(r => r.PID == dataRow.ID).OrderBy(o => o.TEXT).ToList());
				}
			}
		}
	}
}