namespace GEV.VisualDevelop.Implementation.ToolWindow
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("6daaaa2a-f0c6-47e3-8fb1-94d8c4b9953a")]
    public class ImageLocals : ToolWindowPane
    {
        public const string WINDOW_NAME = "Image Locals";

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageLocals"/> class.
        /// </summary>
        public ImageLocals() : base(null)
        {
            this.Caption = WINDOW_NAME;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new ImageLocalsControl();
        }
    }
}
