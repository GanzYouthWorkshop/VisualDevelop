﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.VisualDevelop.Implementation.Visualizer
{
    public partial class ImageControl : UserControl
    {
        private Rectangle m_MinimapArea;
        private Bitmap m_ThumbnailBitmap;

        public Image Image
        {
            get { return this.imgBox.Image; }
            set { this.imgBox.Image = value; }
        }

        public ImageControl()
        {
            InitializeComponent();
        }

        private void UpdateMiniMap()
        {
            // define the initial size. We'll take the current
            // size from the source imagebox's image viewport
            Size viewSize = this.imgBox.GetImageViewPort().Size;
            double w = viewSize.Width;
            double h = viewSize.Height;

            // next we need to scale the size to match the zoomfactor of the source imagebox
            w /= this.imgBox.ZoomFactor;
            h /= this.imgBox.ZoomFactor;

            // next we scale the size again - this time by the zoomfactor the destination imagebox
            w *= this.imgMinimap.ZoomFactor;
            h *= this.imgMinimap.ZoomFactor;

            // with the size define, we can now turn out attention to the origin
            // first, we get the current auto scroll offsets, and reverse them
            // to give us our origin
            double x = -this.imgBox.AutoScrollPosition.X;
            double y = -this.imgBox.AutoScrollPosition.Y;

            // next, we need to scale that to account for the source imagebox zoom
            x /= this.imgBox.ZoomFactor;
            y /= this.imgBox.ZoomFactor;

            // as with the size, we need to scale again to account for the destination imagebox
            x *= this.imgMinimap.ZoomFactor;
            y *= this.imgMinimap.ZoomFactor;

            // and for our final action, we need to offset the origin to account
            // for where the destination imagebox is painting the output image
            Point location = this.imgMinimap.GetImageViewPort().Location;
            x += location.X;
            y += location.Y;

            // all done, create the final rectangle for painting
            Rectangle proposedView = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));

            // see if the final rectangle is different to the one already being used
            // to avoid painting if we don't need to
            if (proposedView != this.m_MinimapArea)
            {
                this.m_MinimapArea = proposedView;
                this.imgMinimap.Invalidate();
            }
        }

        private void RefreshMiniMap()
        {
            if (this.Image != null)
            {
                this.imgMinimap.VirtualSize = this.Image.Size;
                Size minimapSize = this.imgMinimap.GetImageViewPort().Size;
                Bitmap minimap = new Bitmap(minimapSize.Width, minimapSize.Height);

                using (Graphics g = Graphics.FromImage(minimap))
                {
                    g.DrawImage(this.Image, new Rectangle(Point.Empty, minimap.Size), new Rectangle(Point.Empty, this.Image.Size), GraphicsUnit.Pixel);
                }

                // always clean up
                if (this.m_ThumbnailBitmap != null)
                {
                    this.m_ThumbnailBitmap.Dispose();
                    this.m_ThumbnailBitmap = null;
                }
                this.m_ThumbnailBitmap = minimap;

                // force a paint of the minimap
                this.UpdateMiniMap();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.imgBox != null)
            {
                try
                {
                    Point p = this.imgBox.PointToImage(e.Location);
                    Color c = (this.imgBox.Image as Bitmap).GetPixel(p.X, p.Y);

                    this.lblStatus.Text = $"X: {p.X}; Y: {p.Y} - G: {c.R}";
                    this.pnlColor.BackColor = c;
                }
                catch(Exception)
                {
                    //Most probably just out of bounds...
                    this.lblStatus.Text = "---";
                }
            }
        }

        private void chkMinimap_CheckedChanged(object sender, EventArgs e)
        {
            this.imgMinimap.Visible = this.chkMinimap.Checked;
            if(this.chkMinimap.Checked)
            {
                this.RefreshMiniMap();
            }
        }

        private void imgMinimap_Paint(object sender, PaintEventArgs e)
        {
            if (this.m_ThumbnailBitmap != null)
            {
                using (Pen pen = new Pen(Color.Aquamarine, 3))
                {
                    e.Graphics.DrawImage(this.m_ThumbnailBitmap, this.imgMinimap.GetImageViewPort().Location);
                    e.Graphics.DrawRectangle(pen, this.m_MinimapArea.X, this.m_MinimapArea.Y, this.m_MinimapArea.Width, this.m_MinimapArea.Height);
                }
            }
        }

        private void imgBox_Resize(object sender, EventArgs e)
        {
            this.UpdateMiniMap();
        }

        private void imgBox_Zoomed(object sender, Cyotek.Windows.Forms.ImageBoxZoomEventArgs e)
        {
            this.UpdateMiniMap();
        }

        private void imgBox_Scroll(object sender, ScrollEventArgs e)
        {
            this.UpdateMiniMap();
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            this.imgBox.ZoomToFit();
        }

        private void ImageControl_Load(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                this.RefreshMiniMap();
            }
        }

        private void imgMinimap_SelectionRegionChanged(object sender, EventArgs e)
        {

        }
    }
}
