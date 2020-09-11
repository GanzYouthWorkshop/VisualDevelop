using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.VisualDevelop.Implementation.Visualizer
{
    public partial class FormImage : Form
    {
        private Bitmap m_Display;

        public FormImage()
        {
            InitializeComponent();
        }

        public FormImage(Bitmap bmp) : this()
        {
            this.m_Display = bmp;

            this.imgBox.Image = this.m_Display;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.m_Display != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = this.GetFileDialogFilterForImages();
                    sfd.CheckPathExists = true;
                    sfd.CheckFileExists = false;

                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.m_Display.Save(sfd.FileName);
                        }
                        catch(Exception ex)
                        {
                            string error = $"Save failed! - {ex.Message}\n\n{ex.StackTrace}";
                            MessageBox.Show(this, error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot save - Inspected object is null!");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetFileDialogFilterForImages()
        {
            string result = string.Empty;

            List<string> foundCodecs = new List<string>();
            string[] codecs = new string[]
            {
                "png",
                "jpg",
                "tiff",
                "bmp",
            };

            foreach (string c in codecs)
            {
                foundCodecs.Add($"{c.ToUpper()} files (*.{c})|*.{c}");
            }

            return String.Join("|", foundCodecs);
        }
    }
}
