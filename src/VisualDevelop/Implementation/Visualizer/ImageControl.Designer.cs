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
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFit = new System.Windows.Forms.Button();
            this.chkMinimap = new System.Windows.Forms.CheckBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.imgMinimap = new Cyotek.Windows.Forms.ImageBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1309, 618);
            this.imgBox.TabIndex = 0;
            this.imgBox.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.imgBox_Zoomed);
            this.imgBox.Scroll += new System.Windows.Forms.ScrollEventHandler(this.imgBox_Scroll);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.imgBox.Resize += new System.EventHandler(this.imgBox_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFit);
            this.panel1.Controls.Add(this.chkMinimap);
            this.panel1.Controls.Add(this.pnlColor);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 31);
            this.panel1.TabIndex = 1;
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
            // pnlColor
            // 
            this.pnlColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(1281, 3);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(25, 25);
            this.pnlColor.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1112, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(7);
            this.lblStatus.Size = new System.Drawing.Size(163, 27);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "X: {###}; Y: {###} - G: {###}";
            // 
            // imgMinimap
            // 
            this.imgMinimap.AllowZoom = false;
            this.imgMinimap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgMinimap.AutoPan = false;
            this.imgMinimap.Location = new System.Drawing.Point(0, 316);
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
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgMinimap);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.panel1);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(1309, 649);
            this.Load += new System.EventHandler(this.ImageControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}
