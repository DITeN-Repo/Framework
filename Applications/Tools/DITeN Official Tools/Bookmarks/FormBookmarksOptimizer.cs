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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

#endregion

// ReSharper disable InconsistentNaming

namespace Diten.Windows.Applications.Tools.Official.Bookmarks
{
	public partial class FormBookmarksOptimizer: Form
	{
		public FormBookmarksOptimizer() { InitializeComponent(); }

		private void AddDataTableBookmarksRow(DataSetMain.DataTableBookmarksRow row)
		{
			try
			{
				dataSetMain.DataTableBookmarks.AddDataTableBookmarksRow(row.ID,
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
			catch (Exception e) { labelInformation.Text = e.Message; }
		}

		private int ID;

		protected void ImportToolStripMenuItem_Click(object sender,
		                                             EventArgs e)
		{
			toolStripStatusLabelInformation.Text = 0.ToString();

			// ReSharper disable once StringLiteralTypo
			var sourceFile = File.ReadAllText($@"{path}\bookmarks.html")
			                     .ReplaceWithEmpty("<!DOCTYPE NETSCAPE-Bookmark-file-1>")
			                     .ReplaceWithEmpty("<!-- This is an automatically generated file.")
			                     .ReplaceWithEmpty("     It will be read and overwritten.")
			                     .ReplaceWithEmpty("     DO NOT EDIT! -->")
			                     .ReplaceWithEmpty(@"<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=UTF-8"">")
			                     .ReplaceWithEmpty("<TITLE>Bookmarks</TITLE>")
			                     .ReplaceWithEmpty("<p>")
			                     .ReplaceWithEmpty("<DT>")
			                     .ReplaceWithEmpty("<HR>")
			                     .ReplaceWithEmpty("<H1>Bookmarks</H1>")
			                     .Replace(@""" >",
			                              @""">")
			                     .Replace(@""">",
			                              @""" TEXT=""")
			                     .Replace("</H3>",
			                              @""">")
			                     .Replace("</DL>",
			                              "</H3>")
			                     .Replace("</A>",
			                              @"""></A>")
			                     .Replace("<H1>Bookmarks Menu</H1>",
			                              $@"<H3 ADD_DATE=""{DateTime.Now.ToLong()}"" LAST_MODIFIED=""{DateTime.Now.ToLong()}"" TEXT=""Bookmarks"">")
			                     .ReplaceWithEmpty("<DL>")
			                     .ReplaceWithEmpty("  ")
			                     .Save($@"{path}\hh.html");

			toolStripProgressBar.Value = 0;
			webBrowser.Url = new Uri(sourceFile);
			webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
		}

		private readonly string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Settings\FireFox";

		private void treeViewCategories_NodeMouseClick(object sender,
		                                               TreeNodeMouseClickEventArgs e)
		{
			labelInformation.Text = e.Node.Name;

			var PNodePath = e.Node.Name.Split("-".ToCharArray());

			dataSetMainBindingSource.DataSource = dataSetMain.DataTableBookmarks.Where(r => r.PID ==
			                                                                                int.Parse(PNodePath
				                                                                                          [PNodePath.Length -
				                                                                                           1]));
		}

		private void WebBrowser_DocumentCompleted(object sender,
		                                          WebBrowserDocumentCompletedEventArgs e)
		{
			var htmlDocument = webBrowser.Document;

			if (htmlDocument == null ||
			    htmlDocument.Body == null) return;
			var holderHtmlDocument = new HtmlDocument();

			holderHtmlDocument.LoadHtml(htmlDocument.Body.InnerHtml);

			ReadHtml(holderHtmlDocument,
			         null);

			toolStripProgressBar.Value = 0;
			toolStripProgressBar.Maximum = 0;
			toolStripProgressBarTmp.Value = 0;
			toolStripProgressBarTmp.Maximum = 0;

			RemoveDuplicateCategories(treeViewCategories.Nodes[0]);
		}



		private void cutToolStripMenuItem_Click(object sender,
		                                        EventArgs e)
		{
			TreeNodeJobBuffer = TreeNodeJobs.Cut;
			SelectedNodeBuffer = treeViewCategories.SelectedNode;
		}

		private void pasteToolStripMenuItem_Click(object sender,
		                                          EventArgs e)
		{
			TreeNodeJob(TreeNodeJobs.Paste);
		}

		private void copyToolStripMenuItem_Click(object sender,
		                                         EventArgs e)
		{
			TreeNodeJobBuffer = TreeNodeJobs.Copy;
			SelectedNodeBuffer = treeViewCategories.SelectedNode;
		}
	}
}