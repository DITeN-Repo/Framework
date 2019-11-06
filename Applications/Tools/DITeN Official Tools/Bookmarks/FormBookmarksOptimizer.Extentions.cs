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
// Creation Date: 2019/11/03 10:18 PM

#region Used Directives

using System;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

#endregion

namespace Diten.Windows.Applications.Tools.Official.Bookmarks
{
	public partial class FormBookmarksOptimizer
	{
		private TreeNode SelectedNodeBuffer {get; set;}

		private TreeNodeJobs TreeNodeJobBuffer {get; set;}

		private void TreeNodeJob(TreeNodeJobs job)
		{
			switch (job)
			{
				case TreeNodeJobs.Cut: break;
				case TreeNodeJobs.Copy: break;
				case TreeNodeJobs.Paste:
					if (treeViewCategories.SelectedNode == SelectedNodeBuffer) return;
					if (TreeNodeJobBuffer == TreeNodeJobs.Cut) treeViewCategories.Nodes.Remove(SelectedNodeBuffer);
					var selectedNodeBufferId = GetNodeId(SelectedNodeBuffer);
					var selectedNodeId = GetNodeId(treeViewCategories.SelectedNode);
					dataSetMain.DataTableBookmarks.FindByID(selectedNodeBufferId).PID = selectedNodeId;
					SelectedNodeBuffer.Name = SelectedNodeBuffer.Name.Replace($@"{selectedNodeBufferId}-EON",
					                                                          $@"{selectedNodeId}-EON");
					treeViewCategories.SelectedNode.Nodes.Add(SelectedNodeBuffer);
					SelectedNodeBuffer= null;

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(job),
					                                      job,
					                                      null);
			}
		}

		private void DoProgress()
		{
			// ReSharper disable once PossibleLossOfFraction
			var percentage = (decimal) (toolStripProgressBarTmp.Value * 100 / (toolStripProgressBarTmp.Maximum + 1));

			if (percentage >=
			    int.Parse(toolStripStatusLabelProgressPercentage.Text.Replace("%",
			                                                                  string.Empty)))
			{
				toolStripStatusLabelProgressPercentage.Text = $@"{percentage}%";
				toolStripProgressBar.Value = (int) percentage;
			}

			try { toolStripProgressBarTmp.Value++; }
			catch (Exception)
			{
				// ignored
			}

			toolStripStatusLabelInformation.Text = $@"Item number [{
					toolStripProgressBarTmp.Value.ToString()
				}] of [{
					toolStripProgressBarTmp.Maximum.ToString()
				}] items proceed.";
			Application.DoEvents();
		}

		private void ReadHtml(HtmlDocument htmlAgilityPackDocument,
		                      TreeNode parentNode)
		{
			if (htmlAgilityPackDocument.DocumentNode.ChildNodes != null)
			{
				var htmlElements = htmlAgilityPackDocument.DocumentNode.ChildNodes.ToList();
				toolStripProgressBarTmp.Maximum += htmlElements.Count - 1;

				foreach (var element in htmlElements)
				{
					DoProgress();

					var attrText = element.GetAttrValue("TEXT");

					if (attrText.IsNullString() ||
					    attrText.StartsWith("#",
					                        StringComparison.CurrentCultureIgnoreCase)) continue;

					var node = new TreeNode(attrText)
					{
						Name = $@"Node-{parentNode?.Name.Split("-".ToCharArray()).Last()}-{ID++}".Replace("--",
						                                                                                  "-") +
						       "-EON",
						ToolTipText = Name,
						ImageKey = element.OriginalName.ToUpper() == "A" ? @"Link" : "Folder",
						SelectedImageKey = element.OriginalName.ToUpper() == "A" ? @"Link" : "FolderOpen"
					};
					var row = dataSetMain.DataTableBookmarks.NewDataTableBookmarksRow();

					row.ID = ID;
					row.ADD_DATE = element.GetAttrValue("ADD_DATE").IsNullString() ? DateTime.Now.ToLong().ToString() : element.GetAttrValue("ADD_DATE");
					row.LAST_MODIFIED = element.GetAttrValue("LAST_MODIFIED").IsNullString()
						                    ? DateTime.Now.ToLong().ToString()
						                    : element.GetAttrValue("LAST_MODIFIED");
					row.HTMLTAG = element.OriginalName.ToUpper();
					row.ICON = element.GetAttrValue("ICON");
					row.ICON_URI = element.GetAttrValue("ICON_URI");
					row.SHORTCUTURL = element.GetAttrValue("SHORTCUTURL");
					row.TAGS = element.GetAttrValue("TAGS");
					row.TEXT = element.GetAttrValue("TEXT");

					switch (treeViewCategories.Nodes.Count)
					{
						case 0:
							treeViewCategories.Nodes.Add(node);
							row.PID = 0;
							row.HREF = $@"BF-[{row.ID}]: ""{row.TEXT}""";

							break;
						default:
							parentNode?.Nodes.Add(node);

							row.HREF = element.OriginalName.ToUpper() != "A" ? $@"BF-[{row.ID}]: ""{row.TEXT}""" : element.GetAttrValue("HREF");

							var pNodePath = parentNode?.Name.Split("-".ToCharArray());

							if (pNodePath != null)
								row.PID = int.Parse(pNodePath
									                    [pNodePath.Length -
									                     1]);

							break;
					}

					AddDataTableBookmarksRow(row);

					if (element.ChildNodes.Count != 0)
						ReadHtml(PrepHtmlDocument(element),
						         node);
				}
			}

			//parentNode?.ExpandAll();

			HtmlDocument PrepHtmlDocument(HtmlNode htmlNode)
			{
				var holderHtmlDocument = new HtmlDocument();
				holderHtmlDocument.LoadHtml(htmlNode.InnerHtml);

				return holderHtmlDocument;
			}
		}

		private int GetNodeId(TreeNode node)
		{
			var pNodePath = node.Name.Split("-".ToCharArray());

			return int.Parse(pNodePath
				                 [pNodePath.Length -
				                  2]);
		}

		private void RemoveDuplicateCategories(TreeNode parenTreeNode)
		{
			toolStripProgressBarTmp.Maximum += parenTreeNode.Nodes.Count;

			foreach (TreeNode node in parenTreeNode.Nodes)
			{
				DoProgress();
				Application.DoEvents();

				if (node.Nodes.Count > 0) RemoveDuplicateCategories(node);

				var pNodePath = node.Name.Split("-".ToCharArray());
				var row = dataSetMain.DataTableTreeNodes.NewDataTableTreeNodesRow();

				row.BookmarkID = int.Parse(pNodePath
					                           [pNodePath.Length -
					                            1]);
				row.NodePath = node.FullPath;
				row.Title = node.Text;

				try
				{
					dataSetMain.DataTableTreeNodes.AddDataTableTreeNodesRow(row);
					toolStripStatusLabelInformation.Text = $@"Item [{row.Title}] is done.";
				}
				catch (Exception)
				{
					labelInformation.Text += $@"Duplicate item [{row.Title}]{Environment.NewLine}";
					dataSetMainTmp.DataTableTreeNodes.AddDataTableTreeNodesRow(row);
				}
			}
		}

		private enum TreeNodeJobs
		{
			Cut,
			Copy,
			Paste
		}
	}
}