using EnvDTE;
using GEV.VisualDevelop;
using GEV.VisualDevelop.Implementation.ToolWindow.Implementation;
using Microsoft.VisualStudio.Debugger.Interop;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GEV.VisualDevelop.Implementation.ToolWindow
{

    /// <summary>
    /// Interaction logic for ImageLocalsControl.
    /// </summary>
    public partial class ImageLocalsControl : UserControl, IDebugEventCallback2
    {
        private LocalsLoader m_Loader;

        private DebuggerEvents m_DebugEventsReference;

        private ToolWindowViewmodel m_ViewModel = new ToolWindowViewmodel();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageLocalsControl"/> class.
        /// </summary>
        public ImageLocalsControl()
        {
            this.InitializeComponent();

            this.m_Loader = new LocalsLoader(VisualDevelopPackage.DTE);

            ThreadHelper.ThrowIfNotOnUIThread();

            //This is exceptionally stupid, but DTE.Events.DebuggerEvents in in fact no singleton
            //so for the event to work you need to save an active reference to it.
            this.m_DebugEventsReference = VisualDevelopPackage.DTE.Events.DebuggerEvents;
            this.m_DebugEventsReference.OnEnterBreakMode += M_DebugEventsReference_OnEnterBreakMode;
            this.m_DebugEventsReference.OnContextChanged += M_DebugEventsReference_OnContextChanged;
            this.m_DebugEventsReference.OnEnterRunMode += M_DebugEventsReference_OnEnterRunMode;

            if(VisualDevelopPackage.DebuggerService == null)
            {
                VisualDevelopPackage.LoadDebuggerService();
            }

            VisualDevelopPackage.DebuggerService.AdviseDebugEventCallback(this);

            this.DataContext = this.m_ViewModel;
        }

        private void M_DebugEventsReference_OnEnterRunMode(dbgEventReason Reason)
        {
        }

        private void M_DebugEventsReference_OnContextChanged(Process NewProcess, Program NewProgram, Thread NewThread, StackFrame NewStackFrame)
        {
        }

        private void M_DebugEventsReference_OnEnterBreakMode(dbgEventReason Reason, ref dbgExecutionAction ExecutionAction)
        {
            List<ImageLocal> locals = this.m_Loader.FilterImages(this.m_Loader.LoadLocals());

            this.m_ViewModel.Items = locals;

            this.m_ViewModel.WindowEnabled = true;
        }

        public int Event(IDebugEngine2 pEngine, IDebugProcess2 pProcess, IDebugProgram2 pProgram, IDebugThread2 pThread, IDebugEvent2 pEvent, ref Guid riidEvent, uint dwAttrib)
        {
            if (riidEvent == new Guid("ce6f92d3-4222-4b1e-830d-3ecff112bf22"))
            {
                if (pThread != null)
                {
                    this.m_Loader.DebugThread = pThread;
                }
            }
            return 0;
        }
    }
}