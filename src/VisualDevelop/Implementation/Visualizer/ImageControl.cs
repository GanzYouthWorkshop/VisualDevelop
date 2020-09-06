using System;
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
        public Image Image
        {
            get { return this.imgBox.Image; }
            set { this.imgBox.Image = value; }
        }

        public ImageControl()
        {
            InitializeComponent();
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
    }
}
