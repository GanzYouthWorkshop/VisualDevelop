using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using GEV.VisualDevelop.Implementation.ToolWindow;
using GEV.VisualDevelop.Implementation.ToolWindow.Implementation;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using Task = System.Threading.Tasks.Task;


namespace GEV.VisualDevelop
{
    [Guid(PackageGuidString)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideAutoLoad(UIContextGuids.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ImageLocals))]
    public sealed class VisualDevelopPackage : AsyncPackage
    {
        public const string PackageGuidString = "e5031ad4-ba44-46a3-9d09-851d9de9942c";

        public static DTE2 DTE;
        public static IVsDebugger DebuggerService;

        public VisualDevelopPackage()
        {

        }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            //await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            DTE = GetGlobalService(typeof(DTE)) as DTE2;

            await ImageLocalsCommand.InitializeAsync(this);
        }

        public static void LoadDebuggerService()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            DebuggerService = GetGlobalService(typeof(SVsShellDebugger)) as IVsDebugger;
        }
    }
}
