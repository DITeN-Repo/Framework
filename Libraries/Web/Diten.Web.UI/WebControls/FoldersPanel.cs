#region Using Directives

using Diten.ExtensionMethods;
using Diten.Variables;

#region

using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using Diten.Globalization.Languages;
using Diten.Text;
using Ext.Net;

#endregion

// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Global

//using Diten.Data.Ado.Helpers;

#endregion

namespace Diten.Web.UI.WebControls
{
	[DefaultProperty("RootNodeId")]
	[ToolboxData("<{0}:FoldersPanel runat=server></{0}:FoldersPanel>")]
	// ReSharper disable once UnusedMember.Global
	public class FoldersPanel : TreePanel
	{
		private const string ViewStateRootNodeId = "RootNodeId";
		public const string NodePrefix = "Node-";

		/// <summary>
		///     Get or Set application dictionary.
		/// </summary>
		/// <returns>Return dictionary data table.</returns>
		public DataTable ApplicationDictionary
		{
			get
			{
				//todo: correct globalization.
				if (HttpContext.Current.Application[this.GetFrameName()] == null)
					HttpContext.Current.Application[this.GetFrameName()] = null;
				//Dictionary.GetApplicationDictionary();

				return (DataTable) HttpContext.Current.Application[this.GetFrameName()];
			}
			// ReSharper disable once UnusedMember.Local
			private set => HttpContext.Current.Application[this.GetFrameName()] = value;
		}

		/// <summary>
		///     get culture database ID.
		/// </summary>
		public Guid CultureId
		{
			get
			{
				//todo: correct globalization.
				if (HttpContext.Current.Session[this.GetFrameName()] == null)
					HttpContext.Current.Session[this.GetFrameName()] = null;
				//Cultures.GetCultureId(CultureName, Cultures.GetCultureTypes.ByCultureName);

				return new Guid(HttpContext.Current.Session[this.GetFrameName()].ToString());
			}
		}

		/// <summary>
		///     Get culture name.
		/// </summary>
		public string CultureName
		{
			get
			{
				if (HttpContext.Current.Session[this.GetFrameName()] == null)
					HttpContext.Current.Session[this.GetFrameName()] = Page.Culture;

				return HttpContext.Current.Session[this.GetFrameName()].ToString();
			}
			set => HttpContext.Current.Session[this.GetFrameName()] = value;
		}

		[Bindable(true)]
		[Category("Appearance")]
		[Localizable(true)]
		public Guid RootNodeId
		{
			get => ViewState.GetValue<Guid>(this.GetFrameName(), Guid.Empty);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get system culture ID.
		/// </summary>
		protected Guid SystemCultureId =>
			(Guid) HttpContext.Current.Application[this.GetFrameName()];

		/// <summary>
		///     Get ID of the node.
		/// </summary>
		/// <param name="node">Tree node.</param>
		/// <returns>ID of the node in database.</returns>
		public Guid GetNodeId(Node node)
		{
			return new Guid(node.NodeID.Replace(NodePrefix, string.Empty));
		}

		/// <summary>
		///     Read nodes recursively.
		/// </summary>
		/// <param name="node">Parent node.</param>
		/// <returns>A tree node.</returns>
		// ReSharper disable once UnusedMember.Local
		private static Node ReadNodesRecursively(Node node)
		{
			//todo: Check for correction.
			var nodeId = new Guid(node.NodeID.Replace(NodePrefix, string.Empty));

			//foreach (DataRow dataRow in Folder.GetFolders(nodeId).Rows)
			//{
			//    var subNode = new Node
			//    {
			//        Text = dataRow["FolderName"].ToString(),
			//        NodeID = $@"{NodePrefix}{dataRow["ID"]}"
			//    };

			//    node.Children.Add(ReadNodesRecursively(subNode));
			//}

			return node;
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			//todo: Check for correction.

			//var rootNode = Folder.GetFolder(RootNodeId);

			//Root[0].NodeID = $@"{NodePrefix}{rootNode["ID"]}";
			//Root[0].Text = Translate($@"{rootNode["FolderName"]}");

			//foreach (DataRow dataRow in Folder.GetFolders(RootNodeId).Rows)
			//{
			//    var node = new Node
			//    {
			//        Text = dataRow["FolderName"].ToString(),
			//        NodeID = $@"{NodePrefix}{dataRow["ID"]}"
			//    };

			//    Root[0].Children.Add(ReadNodesrecursively(node));
			//}
		}

		/// <summary>
		///     Translating from current culture into destination culture,
		/// </summary>
		/// <param name="data">Data for translation.</param>
		/// <returns>Translated data</returns>
		public string Translate(string data)
		{
			string _return;

			if (String.IsNullString(data)) return string.Empty;

			var dataRows = ApplicationDictionary.Select("SourceText='" + Convert.ToSystemText(data) +
			                                            "' AND SourceCultureID='" +
			                                            SystemCultureId +
			                                            "' AND TranslationCultureID='" +
			                                            CultureId + "'");

			if (dataRows.Length == 0)
			{
				_return = Translation.Translate(Convert.ToSystemText(data),
					Constants.Default.CultureName,
					CultureName, RegularExpressions.IsValidSystemWord(data));

				UpdateApplicationDictionary();

				return String.IsNullString(_return) ? data : _return;
			}

			_return = dataRows[0]["TranslatedText"].ToString();

			return String.IsNullString(_return) ? data : _return;
		}

		/// <summary>
		///     Update application dictionary
		/// </summary>
		public void UpdateApplicationDictionary()
		{
			//todo: Check for correction.

			//ApplicationDictionary = Dictionary.GetApplicationDictionary();
		}
	}
}