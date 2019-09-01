namespace UPS_Demo
{
	partial class FormMain
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
			DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange13 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
			DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange14 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
			DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange15 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownActionValue = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxCurrentValue = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.gaugeControlParameter = new DevExpress.XtraGauges.Win.GaugeControl();
			this.circularGaugeParameter = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
			this.arcScaleComponentParameter = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
			this.arcScaleBackgroundLayerComponentParameter = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
			this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
			this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownActionValue)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.circularGaugeParameter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleComponentParameter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponentParameter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.21283F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.78717F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 310);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(219, 270);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Prameters";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.gaugeControlParameter, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.88446F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.11554F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(213, 251);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.numericUpDownActionValue, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.textBoxCurrentValue, 1, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 200);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(207, 48);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shutdown Value";
			// 
			// numericUpDownActionValue
			// 
			this.numericUpDownActionValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownActionValue.Location = new System.Drawing.Point(106, 3);
			this.numericUpDownActionValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDownActionValue.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDownActionValue.Name = "numericUpDownActionValue";
			this.numericUpDownActionValue.Size = new System.Drawing.Size(98, 20);
			this.numericUpDownActionValue.TabIndex = 1;
			this.numericUpDownActionValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Current Value";
			// 
			// textBoxCurrentValue
			// 
			this.textBoxCurrentValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxCurrentValue.Location = new System.Drawing.Point(106, 27);
			this.textBoxCurrentValue.Name = "textBoxCurrentValue";
			this.textBoxCurrentValue.ReadOnly = true;
			this.textBoxCurrentValue.Size = new System.Drawing.Size(98, 20);
			this.textBoxCurrentValue.TabIndex = 3;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.buttonApply);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 279);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(219, 28);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(3, 3);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 0;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// gaugeControlParameter
			// 
			this.gaugeControlParameter.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGaugeParameter});
			this.gaugeControlParameter.Location = new System.Drawing.Point(3, 3);
			this.gaugeControlParameter.Name = "gaugeControlParameter";
			this.gaugeControlParameter.Size = new System.Drawing.Size(207, 191);
			this.gaugeControlParameter.TabIndex = 3;
			// 
			// circularGaugeParameter
			// 
			this.circularGaugeParameter.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponentParameter});
			this.circularGaugeParameter.Bounds = new System.Drawing.Rectangle(6, 6, 195, 179);
			this.circularGaugeParameter.Name = "circularGaugeParameter";
			this.circularGaugeParameter.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
			this.circularGaugeParameter.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponentParameter});
			this.circularGaugeParameter.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
			// 
			// arcScaleComponentParameter
			// 
			this.arcScaleComponentParameter.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.arcScaleComponentParameter.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.arcScaleComponentParameter.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.arcScaleComponentParameter.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.arcScaleComponentParameter.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 9F);
			this.arcScaleComponentParameter.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
			this.arcScaleComponentParameter.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 140F);
			this.arcScaleComponentParameter.EndAngle = 45F;
			this.arcScaleComponentParameter.MajorTickmark.FormatString = "{0:F0}";
			this.arcScaleComponentParameter.MajorTickmark.ShapeOffset = -13F;
			this.arcScaleComponentParameter.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
			this.arcScaleComponentParameter.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
			this.arcScaleComponentParameter.MaxValue = 100F;
			this.arcScaleComponentParameter.MinorTickCount = 4;
			this.arcScaleComponentParameter.MinorTickmark.ShapeOffset = -9F;
			this.arcScaleComponentParameter.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
			this.arcScaleComponentParameter.Name = "scale1";
			arcScaleRange13.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#9EC968");
			arcScaleRange13.EndThickness = 14F;
			arcScaleRange13.EndValue = 33F;
			arcScaleRange13.Name = "Range0";
			arcScaleRange13.ShapeOffset = 0F;
			arcScaleRange13.StartThickness = 14F;
			arcScaleRange14.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#FED96D");
			arcScaleRange14.EndThickness = 14F;
			arcScaleRange14.EndValue = 66F;
			arcScaleRange14.Name = "Range1";
			arcScaleRange14.ShapeOffset = 0F;
			arcScaleRange14.StartThickness = 14F;
			arcScaleRange14.StartValue = 33F;
			arcScaleRange15.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#EF8C75");
			arcScaleRange15.EndThickness = 14F;
			arcScaleRange15.EndValue = 100F;
			arcScaleRange15.Name = "Range2";
			arcScaleRange15.ShapeOffset = 0F;
			arcScaleRange15.StartThickness = 14F;
			arcScaleRange15.StartValue = 66F;
			this.arcScaleComponentParameter.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange13,
            arcScaleRange14,
            arcScaleRange15});
			this.arcScaleComponentParameter.StartAngle = -225F;
			this.arcScaleComponentParameter.Value = 80F;
			// 
			// arcScaleBackgroundLayerComponentParameter
			// 
			this.arcScaleBackgroundLayerComponentParameter.ArcScale = this.arcScaleComponentParameter;
			this.arcScaleBackgroundLayerComponentParameter.Name = "bg1";
			this.arcScaleBackgroundLayerComponentParameter.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.56F);
			this.arcScaleBackgroundLayerComponentParameter.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularThreeFourth_Style16;
			this.arcScaleBackgroundLayerComponentParameter.Size = new System.Drawing.SizeF(250F, 224F);
			this.arcScaleBackgroundLayerComponentParameter.ZOrder = 1000;
			// 
			// arcScaleNeedleComponent1
			// 
			this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponentParameter;
			this.arcScaleNeedleComponent1.EndOffset = 5F;
			this.arcScaleNeedleComponent1.Name = "needle1";
			this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style16;
			this.arcScaleNeedleComponent1.ZOrder = -50;
			// 
			// arcScaleSpindleCapComponent1
			// 
			this.arcScaleSpindleCapComponent1.ArcScale = this.arcScaleComponentParameter;
			this.arcScaleSpindleCapComponent1.Name = "cap1";
			this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style16;
			this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(25F, 25F);
			this.arcScaleSpindleCapComponent1.ZOrder = -100;
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonApply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(225, 310);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UPS Management Console";
			this.TopMost = true;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownActionValue)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.circularGaugeParameter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleComponentParameter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponentParameter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownActionValue;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxCurrentValue;
		private DevExpress.XtraGauges.Win.GaugeControl gaugeControlParameter;
		private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGaugeParameter;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponentParameter;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponentParameter;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
	}
}

