namespace GEV.VisualDevelop.Implementation.Visualizer
{
    partial class ImageControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkMinimap = new System.Windows.Forms.CheckBox();
            this.btnFit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRangeMax = new System.Windows.Forms.NumericUpDown();
            this.nudRangeMin = new System.Windows.Forms.NumericUpDown();
            this.cbxSelectedPalette = new System.Windows.Forms.ComboBox();
            this.chkOverridePalette = new System.Windows.Forms.CheckBox();
            this.imgMinimap = new Cyotek.Windows.Forms.ImageBox();
            this.tabsTools = new System.Windows.Forms.TabControl();
            this.tabMinimap = new System.Windows.Forms.TabPage();
            this.tabHisto = new System.Windows.Forms.TabPage();
            this.chartHisto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMin)).BeginInit();
            this.tabsTools.SuspendLayout();
            this.tabMinimap.SuspendLayout();
            this.tabHisto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.ImageBorderColor = System.Drawing.Color.Red;
            this.imgBox.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingle;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.ShowPixelGrid = true;
            this.imgBox.Size = new System.Drawing.Size(1309, 607);
            this.imgBox.TabIndex = 0;
            this.imgBox.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.imgBox_Zoomed);
            this.imgBox.Scroll += new System.Windows.Forms.ScrollEventHandler(this.imgBox_Scroll);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.imgBox.Resize += new System.EventHandler(this.imgBox_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 42);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pnlColor);
            this.panel4.Controls.Add(this.lblStatus);
            this.panel4.Location = new System.Drawing.Point(1106, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 32);
            this.panel4.TabIndex = 6;
            // 
            // pnlColor
            // 
            this.pnlColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(170, 3);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(25, 25);
            this.pnlColor.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(7);
            this.lblStatus.Size = new System.Drawing.Size(163, 27);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "X: {###}; Y: {###} - G: {###}";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkMinimap);
            this.panel3.Controls.Add(this.btnFit);
            this.panel3.Location = new System.Drawing.Point(3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 32);
            this.panel3.TabIndex = 6;
            // 
            // chkMinimap
            // 
            this.chkMinimap.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMinimap.AutoSize = true;
            this.chkMinimap.Checked = true;
            this.chkMinimap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimap.Location = new System.Drawing.Point(3, 3);
            this.chkMinimap.Name = "chkMinimap";
            this.chkMinimap.Size = new System.Drawing.Size(56, 23);
            this.chkMinimap.TabIndex = 2;
            this.chkMinimap.Text = "Minimap";
            this.chkMinimap.UseVisualStyleBackColor = true;
            this.chkMinimap.CheckedChanged += new System.EventHandler(this.chkMinimap_CheckedChanged);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(65, 3);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(75, 23);
            this.btnFit.TabIndex = 3;
            this.btnFit.Text = "Fit image";
            this.btnFit.UseVisualStyleBackColor = true;
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nudRangeMax);
            this.panel2.Controls.Add(this.nudRangeMin);
            this.panel2.Controls.Add(this.cbxSelectedPalette);
            this.panel2.Controls.Add(this.chkOverridePalette);
            this.panel2.Location = new System.Drawing.Point(154, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 32);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Palette range:";
            // 
            // nudRangeMax
            // 
            this.nudRangeMax.Location = new System.Drawing.Point(377, 6);
            this.nudRangeMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRangeMax.Name = "nudRangeMax";
            this.nudRangeMax.Size = new System.Drawing.Size(44, 20);
            this.nudRangeMax.TabIndex = 7;
            this.nudRangeMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRangeMax.ValueChanged += new System.EventHandler(this.nudRangeMax_ValueChanged);
            // 
            // nudRangeMin
            // 
            this.nudRangeMin.Location = new System.Drawing.Point(327, 6);
            this.nudRangeMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRangeMin.Name = "nudRangeMin";
            this.nudRangeMin.Size = new System.Drawing.Size(44, 20);
            this.nudRangeMin.TabIndex = 6;
            this.nudRangeMin.ValueChanged += new System.EventHandler(this.nudRangeMin_ValueChanged);
            // 
            // cbxSelectedPalette
            // 
            this.cbxSelectedPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectedPalette.FormattingEnabled = true;
            this.cbxSelectedPalette.Items.AddRange(new object[] {
            "grayscale",
            "monochrome",
            "hue",
            "bluered"});
            this.cbxSelectedPalette.Location = new System.Drawing.Point(110, 5);
            this.cbxSelectedPalette.Name = "cbxSelectedPalette";
            this.cbxSelectedPalette.Size = new System.Drawing.Size(121, 21);
            this.cbxSelectedPalette.TabIndex = 5;
            this.cbxSelectedPalette.SelectedIndexChanged += new System.EventHandler(this.cbxSelectedPalette_SelectedIndexChanged);
            // 
            // chkOverridePalette
            // 
            this.chkOverridePalette.AutoSize = true;
            this.chkOverridePalette.Location = new System.Drawing.Point(3, 7);
            this.chkOverridePalette.Name = "chkOverridePalette";
            this.chkOverridePalette.Size = new System.Drawing.Size(101, 17);
            this.chkOverridePalette.TabIndex = 4;
            this.chkOverridePalette.Text = "Override palette";
            this.chkOverridePalette.UseVisualStyleBackColor = true;
            this.chkOverridePalette.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // imgMinimap
            // 
            this.imgMinimap.AllowZoom = false;
            this.imgMinimap.AutoPan = false;
            this.imgMinimap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgMinimap.Location = new System.Drawing.Point(3, 3);
            this.imgMinimap.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.imgMinimap.Name = "imgMinimap";
            this.imgMinimap.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.Rectangle;
            this.imgMinimap.Size = new System.Drawing.Size(300, 300);
            this.imgMinimap.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
            this.imgMinimap.TabIndex = 2;
            this.imgMinimap.TabStop = false;
            this.imgMinimap.VirtualMode = true;
            this.imgMinimap.SelectionRegionChanged += new System.EventHandler(this.imgMinimap_SelectionRegionChanged);
            this.imgMinimap.Paint += new System.Windows.Forms.PaintEventHandler(this.imgMinimap_Paint);
            // 
            // tabsTools
            // 
            this.tabsTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabsTools.Controls.Add(this.tabMinimap);
            this.tabsTools.Controls.Add(this.tabHisto);
            this.tabsTools.Location = new System.Drawing.Point(0, 275);
            this.tabsTools.Margin = new System.Windows.Forms.Padding(0);
            this.tabsTools.Name = "tabsTools";
            this.tabsTools.SelectedIndex = 0;
            this.tabsTools.Size = new System.Drawing.Size(314, 332);
            this.tabsTools.TabIndex = 3;
            // 
            // tabMinimap
            // 
            this.tabMinimap.Controls.Add(this.imgMinimap);
            this.tabMinimap.Location = new System.Drawing.Point(4, 22);
            this.tabMinimap.Name = "tabMinimap";
            this.tabMinimap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMinimap.Size = new System.Drawing.Size(306, 306);
            this.tabMinimap.TabIndex = 0;
            this.tabMinimap.Text = "Minimap";
            this.tabMinimap.UseVisualStyleBackColor = true;
            // 
            // tabHisto
            // 
            this.tabHisto.Controls.Add(this.chartHisto);
            this.tabHisto.Location = new System.Drawing.Point(4, 22);
            this.tabHisto.Name = "tabHisto";
            this.tabHisto.Padding = new System.Windows.Forms.Padding(3);
            this.tabHisto.Size = new System.Drawing.Size(306, 306);
            this.tabHisto.TabIndex = 1;
            this.tabHisto.Text = "Histogram";
            this.tabHisto.UseVisualStyleBackColor = true;
            // 
            // chartHisto
            // 
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartHisto.ChartAreas.Add(chartArea1);
            this.chartHisto.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartHisto.Legends.Add(legend1);
            this.chartHisto.Location = new System.Drawing.Point(3, 3);
            this.chartHisto.Name = "chartHisto";
            this.chartHisto.Size = new System.Drawing.Size(300, 300);
            this.chartHisto.TabIndex = 0;
            this.chartHisto.Text = "chart1";
            // 
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabsTools);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.panel1);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(1309, 649);
            this.Load += new System.EventHandler(this.ImageControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMin)).EndInit();
            this.tabsTools.ResumeLayout(false);
            this.tabMinimap.ResumeLayout(false);
            this.tabHisto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.ImageBox imgBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label lblStatus;
        private Cyotek.Windows.Forms.ImageBox imgMinimap;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.CheckBox chkMinimap;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxSelectedPalette;
        private System.Windows.Forms.CheckBox chkOverridePalette;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRangeMax;
        private System.Windows.Forms.NumericUpDown nudRangeMin;
        private System.Windows.Forms.TabControl tabsTools;
        private System.Windows.Forms.TabPage tabMinimap;
        private System.Windows.Forms.TabPage tabHisto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHisto;
    }
}
