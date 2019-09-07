namespace Diten.Windows.Forms
{
    partial class JobForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonGo = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.tableLayoutPanelInformationContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new Diten.Windows.Forms.ProgressBar();
            this.INFORMATIUON0 = new Diten.Windows.Forms.Information();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelInformationContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelInformationContainer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 319);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ButtonGo);
            this.flowLayoutPanel1.Controls.Add(this.ButtonStop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 289);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(488, 27);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // ButtonGo
            // 
            this.ButtonGo.Location = new System.Drawing.Point(3, 3);
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(75, 23);
            this.ButtonGo.TabIndex = 3;
            this.ButtonGo.Text = "&Go";
            this.ButtonGo.UseVisualStyleBackColor = true;
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(84, 3);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 4;
            this.ButtonStop.Text = "&Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelInformationContainer
            // 
            this.tableLayoutPanelInformationContainer.ColumnCount = 1;
            this.tableLayoutPanelInformationContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInformationContainer.Controls.Add(this.INFORMATIUON0, 0, 0);
            this.tableLayoutPanelInformationContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInformationContainer.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelInformationContainer.Name = "tableLayoutPanelInformationContainer";
            this.tableLayoutPanelInformationContainer.RowCount = 1;
            this.tableLayoutPanelInformationContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInformationContainer.Size = new System.Drawing.Size(488, 258);
            this.tableLayoutPanelInformationContainer.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(3, 267);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(488, 16);
            this.ProgressBar.TabIndex = 1;
            // 
            // INFORMATIUON0
            // 
            this.INFORMATIUON0.BackColor = System.Drawing.Color.Black;
            this.INFORMATIUON0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INFORMATIUON0.DoReport = false;
            this.INFORMATIUON0.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INFORMATIUON0.ForeColor = System.Drawing.Color.LimeGreen;
            this.INFORMATIUON0.Location = new System.Drawing.Point(3, 3);
            this.INFORMATIUON0.Name = "INFORMATIUON0";
            this.INFORMATIUON0.ReadOnly = true;
            this.INFORMATIUON0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.INFORMATIUON0.Size = new System.Drawing.Size(482, 252);
            this.INFORMATIUON0.TabIndex = 2;
            this.INFORMATIUON0.Text = "";
            // 
            // JobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "JobForm";
            this.Size = new System.Drawing.Size(494, 319);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelInformationContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button ButtonGo;
        public System.Windows.Forms.Button ButtonStop;
        public ProgressBar ProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInformationContainer;
        private Information INFORMATIUON0;
    }
}
