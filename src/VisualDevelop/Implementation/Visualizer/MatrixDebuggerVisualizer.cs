using Emgu.CV.UI;
using Emgu.Util;
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
    public class MatrixDebuggerVisualizer : DialogDebuggerVisualizer
    {
        public const string DEBUGGER_NAME = "Mat visualizer";

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService != null)
            {
                if (objectProvider != null)
                {
                    try
                    {
                        UnmanagedObject mat = objectProvider.GetObject() as UnmanagedObject;
                        if (mat != null)
                        {
                            using (MatrixViewer viewer = new MatrixViewer())
                            {
                                viewer.Matrix = mat;
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
