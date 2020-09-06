using GEV.VisualDevelop.Implementation.Visualizer;
using ImageVisualizer.Implementation.Visualizer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: DebuggerVisualizer(typeof(ImageDebuggerVisualizer), typeof(VisualizerObjectSource), Description = ImageDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(System.Drawing.Bitmap))]
[assembly: DebuggerVisualizer(typeof(ImageDebuggerVisualizer), typeof(VisualizerObjectSource), Description = ImageDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(System.Windows.Media.Imaging.BitmapSource))]

[assembly: DebuggerVisualizer(typeof(ImageDebuggerVisualizer), typeof(VisualizerObjectSource), Description = ImageDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(Emgu.CV.Image<,>))]
[assembly: DebuggerVisualizer(typeof(HistoDebuggerVisualizer), typeof(VisualizerObjectSource), Description = HistoDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(Emgu.CV.DenseHistogram))]
[assembly: DebuggerVisualizer(typeof(MatrixDebuggerVisualizer), typeof(VisualizerObjectSource), Description = MatrixDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(Emgu.CV.Mat))]
[assembly: DebuggerVisualizer(typeof(MatrixDebuggerVisualizer), typeof(VisualizerObjectSource), Description = MatrixDebuggerVisualizer.DEBUGGER_NAME, Target = typeof(Emgu.CV.MatND<>))]

//[assembly: DebuggerVisualizer(typeof(Debugger), typeof(VisualizerObjectSource), Description = Debugger.DEBUGGER_NAME, Target = typeof(Cognex.VisionPro.CogImage8Grey))]
//[assembly: DebuggerVisualizer(typeof(Debugger), typeof(VisualizerObjectSource), Description = Debugger.DEBUGGER_NAME, Target = typeof(Cognex.VisionPro.CogImage16Grey))]
//[assembly: DebuggerVisualizer(typeof(Debugger), typeof(VisualizerObjectSource), Description = Debugger.DEBUGGER_NAME, Target = typeof(Cognex.VisionPro.CogImage24PlanarColor))]

namespace ImageVisualizer.Implementation.Visualizer
{
}
