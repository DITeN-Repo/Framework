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
// Creation Date: 2019/09/05 1:18 AM

#endregion

#region Used Directives

using System;
using System.Windows.Forms;
using Diten.Windows.Forms;
using Form = System.Windows.Forms.Form;
using SEN = System.Environment;

#endregion

namespace Diten.Windows.Applications.Tools.Official
{
	public partial class MDIParentMain : MDIParent
	{
		private int _childFormNumber;

		public MDIParentMain()
		{
			InitializeComponent();
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			var childForm = new Form {MdiParent = this, Text = @"Window " + _childFormNumber++};
			childForm.Show();
		}

		private void OpenFile(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog
			{
				InitialDirectory = SEN.GetFolderPath(SEN.SpecialFolder.Personal),
				Filter = @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				var unused = openFileDialog.FileName;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog
			{
				InitialDirectory = SEN.GetFolderPath(SEN.SpecialFolder.Personal),
				Filter = @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				var unused = saveFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStrip.Visible = toolBarToolStripMenuItem.Checked;
		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			statusStrip.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var childForm in MdiChildren) childForm.Close();
		}
	}
}