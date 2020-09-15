using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Resources;
using System.Reflection;
using System.Globalization;
using Emgu.CV.Structure;
using System.Windows.Forms.DataVisualization.Charting;

namespace GEV.VisualDevelop.Implementation.Visualizer
{
    public partial class ImageControl : UserControl
    {
        private Rectangle m_MinimapArea;
        private Bitmap m_ThumbnailBitmap;

        private ColorPalette m_OriginalPalette;
        private Image m_OriginalImage;

        public Image Image
        {
            get { return this.imgBox.Image; }
            set
            {
                this.imgBox.Image = value;
                this.m_OriginalImage?.Dispose();
                this.m_OriginalImage = null;

                if (this.imgBox.Image != null)
                {
                    this.m_OriginalPalette = this.imgBox.Image.Palette;
                    this.GenerateHistogramData();
                    this.m_OriginalImage = new Bitmap(this.Image);
                }

            }
        }

        public ImageControl()
        {
            InitializeComponent();

            this.cbxSelectedPalette.SelectedIndex = 0;
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

        private ColorPalette GeneratePalette(Bitmap paletteBase, int rangeMin, int rangeMax)
        {
            ColorPalette result;
            using (Bitmap bmp = new Bitmap(10, 10, PixelFormat.Format8bppIndexed))
            {
                result = bmp.Palette;

                for (int i = 0; i < 255; i++)
                {
                    if(i < rangeMin)
                    {
                        result.Entries[i] = paletteBase.GetPixel(0, 0);
                    }
                    else if(i > rangeMax)
                    {
                        result.Entries[i] = paletteBase.GetPixel(254, 0);
                    }
                    else
                    {
                        int range = (rangeMax - rangeMin);
                        int zero = rangeMin;
                        float increment = 255f / range;

                        int index = (int)Math.Min((i - zero) * increment, 254);
                        result.Entries[i] = paletteBase.GetPixel(index, 0);
                    }
                }
                result.Entries[255] = paletteBase.GetPixel(254, 0);
            }

            return result;
        }

        private void SetPalette()
        {

            Bitmap bmp = Properties.Resources.ResourceManager.GetObject($"palette_{this.cbxSelectedPalette.SelectedItem}") as Bitmap;
            this.Image.Palette = this.GeneratePalette(bmp, (int)this.nudRangeMin.Value, (int)this.nudRangeMax.Value);

            this.imgBox.Invalidate();
        }

        private void GenerateHistogramData()
        {
            if(this.Image != null)
            {
                Emgu.CV.Image<Bgr, byte> img = new Emgu.CV.Image<Bgr, byte>(this.Image as Bitmap);

                Emgu.CV.Image<Gray, byte>[] channels = img.Split();

                List<Color> colors = new List<Color>()
                {
                    Color.FromArgb(128, 0, 0, 255),
                    Color.FromArgb(128, 0, 255, 0),
                    Color.FromArgb(128, 255, 0, 0),
                };

                for(int c = 0; c < channels.Length; c++)
                {
                    Emgu.CV.DenseHistogram histo = new Emgu.CV.DenseHistogram(256, new RangeF(0, 255));
                    histo.Calculate<byte>(new Emgu.CV.Image<Gray, byte>[] { channels[c] }, false, null);
                    float[] values = histo.GetBinValues();

                    Series channelSeries = new Series()
                    {
                        ChartType = SeriesChartType.Column,
                        Color = colors[c],
                    };

                    for (int i = 0; i < 256; i++)
                    {
                        channelSeries.Points.AddXY(i, values[i]);
                    }

                    VerticalLineAnnotation va = new VerticalLineAnnotation()
                    {
                        LineColor = colors[c],
                        LineWidth = 3,
                        AxisX = chartHisto.ChartAreas[0].AxisX,
                        AxisY = chartHisto.ChartAreas[0].AxisY,
                        AllowMoving = true,
                        IsInfinitive = true,
                        ClipToChartArea = chartHisto.ChartAreas[0].Name,
                        AllowAnchorMoving = false,
                    };

                    this.chartHisto.Annotations.Add(va);
                    this.chartHisto.Series.Add(channelSeries);
                }
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

                    try
                    {
                        Color histoColor = (this.m_OriginalImage as Bitmap).GetPixel(p.X, p.Y);
                        this.chartHisto.Annotations[0].AnchorDataPoint = this.chartHisto.Series[0].Points[histoColor.B];
                        this.chartHisto.Annotations[1].AnchorDataPoint = this.chartHisto.Series[0].Points[histoColor.G];
                        this.chartHisto.Annotations[2].AnchorDataPoint = this.chartHisto.Series[0].Points[histoColor.R];

                        this.chartHisto.UpdateAnnotations();

                        this.lblError.Text = "---";
                    }
                    catch(Exception ex)
                    {
                        this.lblError.Text = ex.Message;
                    }
                }
                catch(Exception ex)
                {
                    //Most probably just out of bounds...
                    this.lblStatus.Text = "---";
                    this.lblError.Text = ex.Message;
                }
            }
        }

        private void chkMinimap_CheckedChanged(object sender, EventArgs e)
        {
            this.tabsTools.Visible = this.chkMinimap.Checked;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkOverridePalette.Checked)
            {
                this.SetPalette();
            }
            else
            {
                this.Image.Palette = this.m_OriginalPalette;
                this.imgBox.Invalidate();
            }
        }

        private void cbxSelectedPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.chkOverridePalette.Checked)
            {
                this.SetPalette();
            }
        }

        private void rangeSelectorControl1_Paint(object sender, PaintEventArgs e)
        {
            if (this.chkOverridePalette.Checked)
            {
                this.SetPalette();
            }
        }

        private void nudRangeMax_ValueChanged(object sender, EventArgs e)
        {
            this.nudRangeMin.Maximum = Math.Min(this.nudRangeMax.Value - 1, 254);

            if (this.chkOverridePalette.Checked)
            {
                this.SetPalette();
            }
        }

        private void nudRangeMin_ValueChanged(object sender, EventArgs e)
        {
            this.nudRangeMax.Minimum = Math.Max(this.nudRangeMin.Value + 1, 1);

            if (this.chkOverridePalette.Checked)
            {
                this.SetPalette();
            }
        }
    }
}
