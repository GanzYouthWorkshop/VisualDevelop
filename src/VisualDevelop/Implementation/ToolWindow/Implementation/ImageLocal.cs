using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.ToolWindow.Implementation
{
    public class ImageLocal
    {
        public object RawObject { get; set; }
        public Bitmap Preview { get; set; }
        public string Type { get; set; }
        public string VariableName { get; set; }
    }
}
