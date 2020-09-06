using GEV.VisualDevelop.Implementation.Converter;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.Visualizer
{
    public class ImageDebuggerVisualizer : DialogDebuggerVisualizer
    {
        public const string DEBUGGER_NAME = "Image visualizer";

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService != null)
            {
                if (objectProvider != null)
                {
                    try
                    {
                        Bitmap bmp = Converter.ImageConverter.ConvertObjectToBitmap(objectProvider.GetObject());
                        using (FormImage form = new FormImage(bmp))
                        {
                            windowService.ShowDialog(form);
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO
                    }
                }
            }

        }

        public static void Test(object testObject)
        {
            VisualizerDevelopmentHost testHost = new VisualizerDevelopmentHost(testObject, typeof(ImageDebuggerVisualizer), typeof(VisualizerObjectSource));
            testHost.ShowVisualizer();
        }
    }
}
