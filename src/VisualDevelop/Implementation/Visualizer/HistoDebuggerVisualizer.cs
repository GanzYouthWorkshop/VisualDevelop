using Emgu.CV;
using Emgu.CV.UI;
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
    public class HistoDebuggerVisualizer : DialogDebuggerVisualizer
    {
        public const string DEBUGGER_NAME = "Histogram visualizer";

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService != null)
            {
                if (objectProvider != null)
                {
                    try
                    { 
                        DenseHistogram hist = objectProvider.GetObject() as DenseHistogram;
                        if (hist != null)
                        {
                            using (HistogramViewer viewer = new HistogramViewer())
                            {
                                viewer.HistogramCtrl.AddHistogram("Histogram", Color.Black, hist, 256, new float[] { 0, 255 });
                                viewer.HistogramCtrl.Refresh();
                                windowService.ShowDialog(viewer);
                            }
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
