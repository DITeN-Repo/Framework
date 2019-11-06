namespace Diten.Windows.Applications.Tools.Official.Bookmarks
{
	partial class FormBookmarksOptimizer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing&&(components!=null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBookmarksOptimizer));
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainerResultMain = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanelCategories = new System.Windows.Forms.TableLayoutPanel();
			this.treeViewCategories = new System.Windows.Forms.TreeView();
			this.imageListResourceIcons = new System.Windows.Forms.ImageList(this.components);
			this.groupBoxInformation = new System.Windows.Forms.GroupBox();
			this.labelInformation = new System.Windows.Forms.Label();
			this.tableLayoutPanelResultMain = new System.Windows.Forms.TableLayoutPanel();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.groupBoxURLs = new System.Windows.Forms.GroupBox();
			this.dataGridViewURLS = new System.Windows.Forms.DataGridView();
			this.ColumnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
			this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnURL = new System.Windows.Forms.DataGridViewLinkColumn();
			this.ColumnTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataSetMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataSetMain = new Diten.Windows.Applications.Tools.Official.Bookmarks.DataSetMain();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabelProgressPercentage = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelInformation = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBarTmp = new System.Windows.Forms.ToolStripProgressBar();
			this.dataSetMainTmp = new Diten.Windows.Applications.Tools.Official.Bookmarks.DataSetMain();
			this.tableLayoutPanelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerResultMain)).BeginInit();
			this.splitContainerResultMain.Panel1.SuspendLayout();
			this.splitContainerResultMain.Panel2.SuspendLayout();
			this.splitContainerResultMain.SuspendLayout();
			this.tableLayoutPanelCategories.SuspendLayout();
			this.groupBoxInformation.SuspendLayout();
			this.tableLayoutPanelResultMain.SuspendLayout();
			this.groupBoxURLs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewURLS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMainBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMain)).BeginInit();
			this.toolStripMain.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMainTmp)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 1;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelMain.Controls.Add(this.splitContainerResultMain, 0, 2);
			this.tableLayoutPanelMain.Controls.Add(this.toolStripMain, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.menuStripMain, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.statusStripMain, 0, 3);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 4;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1117, 754);
			this.tableLayoutPanelMain.TabIndex = 0;
			// 
			// splitContainerResultMain
			// 
			this.splitContainerResultMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerResultMain.Location = new System.Drawing.Point(3, 52);
			this.splitContainerResultMain.Name = "splitContainerResultMain";
			// 
			// splitContainerResultMain.Panel1
			// 
			this.splitContainerResultMain.Panel1.Controls.Add(this.tableLayoutPanelCategories);
			this.splitContainerResultMain.Panel1MinSize = 150;
			// 
			// splitContainerResultMain.Panel2
			// 
			this.splitContainerResultMain.Panel2.Controls.Add(this.tableLayoutPanelResultMain);
			this.splitContainerResultMain.Panel2MinSize = 200;
			this.splitContainerResultMain.Size = new System.Drawing.Size(1111, 677);
			this.splitContainerResultMain.SplitterDistance = 284;
			this.splitContainerResultMain.TabIndex = 6;
			// 
			// tableLayoutPanelCategories
			// 
			this.tableLayoutPanelCategories.ColumnCount = 1;
			this.tableLayoutPanelCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelCategories.Controls.Add(this.treeViewCategories, 0, 0);
			this.tableLayoutPanelCategories.Controls.Add(this.groupBoxInformation, 0, 1);
			this.tableLayoutPanelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelCategories.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelCategories.Name = "tableLayoutPanelCategories";
			this.tableLayoutPanelCategories.RowCount = 2;
			this.tableLayoutPanelCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
			this.tableLayoutPanelCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
			this.tableLayoutPanelCategories.Size = new System.Drawing.Size(284, 677);
			this.tableLayoutPanelCategories.TabIndex = 1;
			// 
			// treeViewCategories
			// 
			this.treeViewCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewCategories.ImageKey = "Folder";
			this.treeViewCategories.ImageList = this.imageListResourceIcons;
			this.treeViewCategories.Location = new System.Drawing.Point(3, 3);
			this.treeViewCategories.Name = "treeViewCategories";
			this.treeViewCategories.SelectedImageKey = "FolderOpen";
			this.treeViewCategories.Size = new System.Drawing.Size(278, 514);
			this.treeViewCategories.TabIndex = 2;
			this.treeViewCategories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCategories_NodeMouseClick);
			// 
			// imageListResourceIcons
			// 
			this.imageListResourceIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListResourceIcons.ImageStream")));
			this.imageListResourceIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListResourceIcons.Images.SetKeyName(0, "Chrome");
			this.imageListResourceIcons.Images.SetKeyName(1, "Folder");
			this.imageListResourceIcons.Images.SetKeyName(2, "FolderOpen");
			this.imageListResourceIcons.Images.SetKeyName(3, "Opera");
			this.imageListResourceIcons.Images.SetKeyName(4, "Firefox");
			this.imageListResourceIcons.Images.SetKeyName(5, "Link");
			// 
			// groupBoxInformation
			// 
			this.groupBoxInformation.Controls.Add(this.labelInformation);
			this.groupBoxInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxInformation.Location = new System.Drawing.Point(3, 523);
			this.groupBoxInformation.Name = "groupBoxInformation";
			this.groupBoxInformation.Size = new System.Drawing.Size(278, 151);
			this.groupBoxInformation.TabIndex = 3;
			this.groupBoxInformation.TabStop = false;
			this.groupBoxInformation.Text = "Information";
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelInformation.Location = new System.Drawing.Point(3, 16);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(38, 13);
			this.labelInformation.TabIndex = 0;
			this.labelInformation.Text = "Ready";
			// 
			// tableLayoutPanelResultMain
			// 
			this.tableLayoutPanelResultMain.ColumnCount = 1;
			this.tableLayoutPanelResultMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelResultMain.Controls.Add(this.webBrowser, 0, 1);
			this.tableLayoutPanelResultMain.Controls.Add(this.groupBoxURLs, 0, 0);
			this.tableLayoutPanelResultMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelResultMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelResultMain.Name = "tableLayoutPanelResultMain";
			this.tableLayoutPanelResultMain.RowCount = 2;
			this.tableLayoutPanelResultMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanelResultMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelResultMain.Size = new System.Drawing.Size(823, 677);
			this.tableLayoutPanelResultMain.TabIndex = 0;
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(3, 409);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(817, 265);
			this.webBrowser.TabIndex = 2;
			this.webBrowser.Visible = false;
			// 
			// groupBoxURLs
			// 
			this.groupBoxURLs.Controls.Add(this.dataGridViewURLS);
			this.groupBoxURLs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxURLs.Location = new System.Drawing.Point(3, 3);
			this.groupBoxURLs.Name = "groupBoxURLs";
			this.groupBoxURLs.Size = new System.Drawing.Size(817, 400);
			this.groupBoxURLs.TabIndex = 0;
			this.groupBoxURLs.TabStop = false;
			this.groupBoxURLs.Text = "URLs";
			// 
			// dataGridViewURLS
			// 
			this.dataGridViewURLS.AllowUserToAddRows = false;
			this.dataGridViewURLS.AllowUserToResizeRows = false;
			this.dataGridViewURLS.AutoGenerateColumns = false;
			this.dataGridViewURLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewURLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSelect,
            this.ColumnIcon,
            this.ColumnTitle,
            this.ColumnURL,
            this.ColumnTags,
            this.ColumnDelete});
			this.dataGridViewURLS.DataSource = this.dataSetMainBindingSource;
			this.dataGridViewURLS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewURLS.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewURLS.Name = "dataGridViewURLS";
			this.dataGridViewURLS.RowHeadersVisible = false;
			this.dataGridViewURLS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewURLS.Size = new System.Drawing.Size(811, 381);
			this.dataGridViewURLS.TabIndex = 0;
			// 
			// ColumnSelect
			// 
			this.ColumnSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ColumnSelect.FillWeight = 1F;
			this.ColumnSelect.Frozen = true;
			this.ColumnSelect.HeaderText = "";
			this.ColumnSelect.MinimumWidth = 36;
			this.ColumnSelect.Name = "ColumnSelect";
			this.ColumnSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnSelect.ToolTipText = "Select";
			this.ColumnSelect.Width = 36;
			// 
			// ColumnIcon
			// 
			this.ColumnIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ColumnIcon.Description = "Show icon of the web site.";
			this.ColumnIcon.FillWeight = 1F;
			this.ColumnIcon.Frozen = true;
			this.ColumnIcon.HeaderText = "";
			this.ColumnIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.ColumnIcon.MinimumWidth = 30;
			this.ColumnIcon.Name = "ColumnIcon";
			this.ColumnIcon.ReadOnly = true;
			this.ColumnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnIcon.ToolTipText = "Icon of the web site.";
			this.ColumnIcon.Width = 30;
			// 
			// ColumnTitle
			// 
			this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnTitle.DataPropertyName = "TEXT";
			this.ColumnTitle.HeaderText = "Title";
			this.ColumnTitle.MinimumWidth = 200;
			this.ColumnTitle.Name = "ColumnTitle";
			this.ColumnTitle.ReadOnly = true;
			this.ColumnTitle.ToolTipText = "Title of the page.";
			// 
			// ColumnURL
			// 
			this.ColumnURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnURL.DataPropertyName = "HREF";
			this.ColumnURL.FillWeight = 50F;
			this.ColumnURL.HeaderText = "URL";
			this.ColumnURL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.ColumnURL.MinimumWidth = 100;
			this.ColumnURL.Name = "ColumnURL";
			this.ColumnURL.ReadOnly = true;
			this.ColumnURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnURL.ToolTipText = "URL of the page.";
			// 
			// ColumnTags
			// 
			this.ColumnTags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnTags.DataPropertyName = "TAGS";
			this.ColumnTags.FillWeight = 25F;
			this.ColumnTags.HeaderText = "Tags";
			this.ColumnTags.MinimumWidth = 100;
			this.ColumnTags.Name = "ColumnTags";
			this.ColumnTags.ToolTipText = "Tags of the page.";
			// 
			// ColumnDelete
			// 
			this.ColumnDelete.DataPropertyName = "ID";
			this.ColumnDelete.DividerWidth = 1;
			this.ColumnDelete.FillWeight = 1F;
			this.ColumnDelete.HeaderText = "Delete";
			this.ColumnDelete.MinimumWidth = 50;
			this.ColumnDelete.Name = "ColumnDelete";
			this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnDelete.Text = "Delete";
			this.ColumnDelete.ToolTipText = "Deleting the bookmark.";
			this.ColumnDelete.UseColumnTextForButtonValue = true;
			this.ColumnDelete.Width = 50;
			// 
			// dataSetMainBindingSource
			// 
			this.dataSetMainBindingSource.DataSource = this.dataSetMain;
			this.dataSetMainBindingSource.Position = 0;
			// 
			// dataSetMain
			// 
			this.dataSetMain.DataSetName = "DataSetMain";
			this.dataSetMain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// toolStripMain
			// 
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
			this.toolStripMain.Location = new System.Drawing.Point(0, 24);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(1117, 25);
			this.toolStripMain.TabIndex = 5;
			this.toolStripMain.Text = "toolStripMain";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "&New";
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton.Text = "&Print";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cutToolStripButton.Text = "C&ut";
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.copyToolStripButton.Text = "&Copy";
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.pasteToolStripButton.Text = "&Paste";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(1117, 24);
			this.menuStripMain.TabIndex = 3;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItemImport,
            this.exportToolStripMenuItem,
            this.toolStripSeparator3,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem1});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.newToolStripMenuItem.Text = "&New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			// 
			// toolStripMenuItemImport
			// 
			this.toolStripMenuItemImport.Name = "toolStripMenuItemImport";
			this.toolStripMenuItemImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.toolStripMenuItemImport.Size = new System.Drawing.Size(186, 22);
			this.toolStripMenuItemImport.Text = "&Import";
			this.toolStripMenuItemImport.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.exportToolStripMenuItem.Text = "&Export";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.printToolStripMenuItem.Text = "&Print";
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
			this.exitToolStripMenuItem1.Text = "E&xit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator6,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.findPreviousToolStripMenuItem,
            this.toolStripMenuItem3,
            this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(193, 6);
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.findToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.findToolStripMenuItem.Text = "&Find";
			// 
			// findNextToolStripMenuItem
			// 
			this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
			this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.findNextToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.findNextToolStripMenuItem.Text = "Find &Next";
			// 
			// findPreviousToolStripMenuItem
			// 
			this.findPreviousToolStripMenuItem.Name = "findPreviousToolStripMenuItem";
			this.findPreviousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
			this.findPreviousToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.findPreviousToolStripMenuItem.Text = "Find Pre&vious";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabelProgressPercentage,
            this.toolStripStatusLabelInformation,
            this.toolStripProgressBarTmp});
			this.statusStripMain.Location = new System.Drawing.Point(0, 732);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(1117, 22);
			this.statusStripMain.TabIndex = 2;
			this.statusStripMain.Text = "statusStripMain";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			this.toolStripProgressBar.Tag = "";
			// 
			// toolStripStatusLabelProgressPercentage
			// 
			this.toolStripStatusLabelProgressPercentage.Name = "toolStripStatusLabelProgressPercentage";
			this.toolStripStatusLabelProgressPercentage.Size = new System.Drawing.Size(23, 17);
			this.toolStripStatusLabelProgressPercentage.Text = "0%";
			// 
			// toolStripStatusLabelInformation
			// 
			this.toolStripStatusLabelInformation.Name = "toolStripStatusLabelInformation";
			this.toolStripStatusLabelInformation.Size = new System.Drawing.Size(42, 17);
			this.toolStripStatusLabelInformation.Text = "Ready.";
			// 
			// toolStripProgressBarTmp
			// 
			this.toolStripProgressBarTmp.Name = "toolStripProgressBarTmp";
			this.toolStripProgressBarTmp.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgressBarTmp.Visible = false;
			// 
			// dataSetMainTmp
			// 
			this.dataSetMainTmp.DataSetName = "DataSetMain";
			this.dataSetMainTmp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// FormBookmarksOptimizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1117, 754);
			this.Controls.Add(this.tableLayoutPanelMain);
			this.MainMenuStrip = this.menuStripMain;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "FormBookmarksOptimizer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bookmarks Optimizer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.ImportToolStripMenuItem_Click);
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.splitContainerResultMain.Panel1.ResumeLayout(false);
			this.splitContainerResultMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerResultMain)).EndInit();
			this.splitContainerResultMain.ResumeLayout(false);
			this.tableLayoutPanelCategories.ResumeLayout(false);
			this.groupBoxInformation.ResumeLayout(false);
			this.groupBoxInformation.PerformLayout();
			this.tableLayoutPanelResultMain.ResumeLayout(false);
			this.groupBoxURLs.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewURLS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMainBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMain)).EndInit();
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSetMainTmp)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProgressPercentage;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInformation;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImport;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findPreviousToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainerResultMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCategories;
		private System.Windows.Forms.TreeView treeViewCategories;
		private System.Windows.Forms.GroupBox groupBoxInformation;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelResultMain;
		private System.Windows.Forms.GroupBox groupBoxURLs;
		private System.Windows.Forms.DataGridView dataGridViewURLS;
		private System.Windows.Forms.ImageList imageListResourceIcons;
		private System.Windows.Forms.Label labelInformation;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarTmp;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelect;
		private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
		private System.Windows.Forms.DataGridViewLinkColumn ColumnURL;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTags;
		private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
		private System.Windows.Forms.BindingSource dataSetMainBindingSource;
		private DataSetMain dataSetMain;
		private DataSetMain dataSetMainTmp;
	}
}