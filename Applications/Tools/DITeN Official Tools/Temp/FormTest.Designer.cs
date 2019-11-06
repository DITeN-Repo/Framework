namespace Diten.Windows.Applications.Tools.Official.Temp
{
	partial class FormTest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonA = new System.Windows.Forms.Button();
			this.buttonB = new System.Windows.Forms.Button();
			this.buttonC = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.66666F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.333333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.textBoxC, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.textBoxA, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.textBoxB, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.textBoxSource, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 401);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// textBoxC
			// 
			this.textBoxC.BackColor = System.Drawing.Color.Green;
			this.textBoxC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxC.ForeColor = System.Drawing.Color.Yellow;
			this.textBoxC.Location = new System.Drawing.Point(400, 213);
			this.textBoxC.Multiline = true;
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(391, 185);
			this.textBoxC.TabIndex = 3;
			// 
			// textBoxA
			// 
			this.textBoxA.BackColor = System.Drawing.Color.Maroon;
			this.textBoxA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxA.ForeColor = System.Drawing.Color.Yellow;
			this.textBoxA.Location = new System.Drawing.Point(3, 213);
			this.textBoxA.Multiline = true;
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(391, 185);
			this.textBoxA.TabIndex = 2;
			// 
			// textBoxB
			// 
			this.textBoxB.BackColor = System.Drawing.Color.Navy;
			this.textBoxB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxB.ForeColor = System.Drawing.Color.Yellow;
			this.textBoxB.Location = new System.Drawing.Point(400, 3);
			this.textBoxB.Multiline = true;
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(391, 204);
			this.textBoxB.TabIndex = 1;
			// 
			// textBoxSource
			// 
			this.textBoxSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.textBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSource.ForeColor = System.Drawing.Color.Lime;
			this.textBoxSource.Location = new System.Drawing.Point(3, 3);
			this.textBoxSource.Multiline = true;
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.Size = new System.Drawing.Size(391, 204);
			this.textBoxSource.TabIndex = 0;
			this.textBoxSource.Text = resources.GetString("textBoxSource.Text");
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.buttonA);
			this.flowLayoutPanel1.Controls.Add(this.buttonB);
			this.flowLayoutPanel1.Controls.Add(this.buttonC);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 410);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 37);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// buttonA
			// 
			this.buttonA.BackColor = System.Drawing.Color.Maroon;
			this.buttonA.ForeColor = System.Drawing.Color.Yellow;
			this.buttonA.Location = new System.Drawing.Point(3, 3);
			this.buttonA.Name = "buttonA";
			this.buttonA.Size = new System.Drawing.Size(175, 34);
			this.buttonA.TabIndex = 5;
			this.buttonA.Text = "Alg A";
			this.buttonA.UseVisualStyleBackColor = false;
			this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
			// 
			// buttonB
			// 
			this.buttonB.BackColor = System.Drawing.Color.Navy;
			this.buttonB.ForeColor = System.Drawing.Color.Yellow;
			this.buttonB.Location = new System.Drawing.Point(184, 3);
			this.buttonB.Name = "buttonB";
			this.buttonB.Size = new System.Drawing.Size(177, 34);
			this.buttonB.TabIndex = 6;
			this.buttonB.Text = "Alg B";
			this.buttonB.UseVisualStyleBackColor = false;
			this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
			// 
			// buttonC
			// 
			this.buttonC.BackColor = System.Drawing.Color.Green;
			this.buttonC.ForeColor = System.Drawing.Color.Yellow;
			this.buttonC.Location = new System.Drawing.Point(367, 3);
			this.buttonC.Name = "buttonC";
			this.buttonC.Size = new System.Drawing.Size(165, 34);
			this.buttonC.TabIndex = 7;
			this.buttonC.Text = "Alg C";
			this.buttonC.UseVisualStyleBackColor = false;
			this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
			// 
			// FormTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FormTest";
			this.Text = "FormTest";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox textBoxC;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button buttonA;
		private System.Windows.Forms.Button buttonB;
		private System.Windows.Forms.Button buttonC;
	}
}