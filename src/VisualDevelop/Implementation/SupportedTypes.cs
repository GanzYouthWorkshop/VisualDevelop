using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation
{
    public class SupportedTypes
    {
        public static readonly Type[] Types = new Type[]
        {
            typeof(System.Drawing.Bitmap),
            typeof(System.Windows.Media.Imaging.BitmapSource),
            typeof(Emgu.CV.Image<Gray, byte>)
        };
    }
}
