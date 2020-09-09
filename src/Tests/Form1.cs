using GEV.VisualDevelop.Implementation.Visualizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(@"C:\Users\Szlatyka\Pictures\71287.bmp");
            new FormImage(bmp).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
