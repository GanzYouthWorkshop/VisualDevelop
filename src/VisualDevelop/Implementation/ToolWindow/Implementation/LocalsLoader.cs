﻿using EnvDTE;
using EnvDTE80;
using EnvDTE90a;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Design;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.ToolWindow.Implementation
{
    public class LocalsLoader
    {
        private readonly DTE2 m_Dte2;

        public IDebugThread2 DebugThread { get; set; }

        public LocalsLoader(DTE2 dte)
        {
            this.m_Dte2 = dte;
        }

        public List<ImageLocal> FilterImages(List<Expression> debugExpressions)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            List<ImageLocal> result = new List<ImageLocal>();

            foreach (Expression item in debugExpressions)
            {
                Type type = SupportedTypes.Types.FirstOrDefault(t => t.FullName == item.Type);

                Debugger t2 = this.m_Dte2.Debugger;
                if (type != null)
                {
                    result.Add(new ImageLocal()
                    {
                        VariableName = item.Name,
                        RawObject = null, //TODO
                        Type = item.Type,
                        Preview = null,
                    });

                    this.RetrieveObject(item.Name);
                }
            }

            return result;
        }

        public List<Expression> LoadLocals()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            List<Expression> result = null;

            Debugger debugger = this.m_Dte2.Debugger;
            if (debugger != null && debugger.CurrentMode == dbgDebugMode.dbgBreakMode && debugger.CurrentStackFrame != null)
            {
                result = this.LoadLocals(debugger.CurrentStackFrame);
            }

            return result;
        }

        public List<Expression> LoadLocals(StackFrame stack)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            List<Expression> result = null;

            Expressions localExpresisons = stack.Locals;
            result = localExpresisons.Cast<Expression>().ToList();

            return result;
        }

        //TODO
        public Type GetTypeFromString(string type)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            IServiceProvider serviceProvider = new ServiceProvider(this.m_Dte2 as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
            DynamicTypeService typeService = serviceProvider.GetService(typeof(DynamicTypeService)) as DynamicTypeService;
            IVsSolution solution = serviceProvider.GetService(typeof(IVsSolution)) as IVsSolution;

            if (solution == null)
            {
                return null;
            }

            IVsHierarchy hierarchy;
            solution.GetProjectOfUniqueName(this.m_Dte2.ActiveDocument.ProjectItem.ContainingProject.UniqueName, out hierarchy);

            Type returnType = typeService?.GetTypeResolutionService(hierarchy)?.GetType(type, false, true);

            return returnType;
        }

        //TODO
        public object RetrieveObject(string addressExpressionString)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            StackFrame2 currentFrame2 = this.m_Dte2.Debugger.CurrentStackFrame as StackFrame2;
            if (currentFrame2 == null)
            {
                return null;
            }

            // Depth property is 1-based.
            uint currentFrameDepth = currentFrame2.Depth - 1;

            // Get frame info enum interface.
            IDebugThread2 currentThread2 = this.DebugThread;
            IEnumDebugFrameInfo2 enumDebugFrameInfo2;
            if (VSConstants.S_OK != currentThread2.EnumFrameInfo((uint)enum_FRAMEINFO_FLAGS.FIF_FRAME, 0, out enumDebugFrameInfo2))
            {
                return null;
            }

            // Skip frames above the current one.
            enumDebugFrameInfo2.Reset();
            if (VSConstants.S_OK != enumDebugFrameInfo2.Skip(currentFrameDepth))
            {
                return null;
            }

            // Get the current frame.
            FRAMEINFO[] frameInfo = new FRAMEINFO[1];
            uint fetched = 0;
            int hr = enumDebugFrameInfo2.Next(1, frameInfo, ref fetched);

            if (hr != VSConstants.S_OK || fetched != 1)
            {
                return null;
            }

            IDebugStackFrame2 stackFrame = frameInfo[0].m_pFrame;
            if (stackFrame == null)
            {
                return null;
            }

            // Get a context for evaluating expressions.
            IDebugExpressionContext2 expressionContext;
            if (VSConstants.S_OK != stackFrame.GetExpressionContext(out expressionContext))
            {
                return null;
            }

            // Parse the expression string.
            IDebugExpression2 expression;
            string error;
            uint errorCharIndex;
            if (VSConstants.S_OK != expressionContext.ParseText(addressExpressionString, (uint)enum_PARSEFLAGS.PARSE_EXPRESSION, 10, out expression, out error, out errorCharIndex))
            {
                return null;
            }

            // Evaluate the parsed expression.
            IDebugProperty2 debugProperty = null;
            IDebugProperty3 upgrade = debugProperty as IDebugProperty3;
            if (VSConstants.S_OK != expression.EvaluateSync((uint)enum_EVALFLAGS.EVAL_NOSIDEEFFECTS, unchecked((uint)Timeout.Infinite), null, out debugProperty))
            {
                return null;
            }

            DEBUG_PROPERTY_INFO[] test2 = new DEBUG_PROPERTY_INFO[64];
            debugProperty.GetPropertyInfo((uint)(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE | enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE_NO_TOSTRING), 10, unchecked((uint)Timeout.Infinite), null, 0, test2);
            uint bmpSize = 0;
            var re = debugProperty.GetSize(out bmpSize);

            // Get memory context for the property.
            IDebugMemoryContext2 memoryContext;
            if (VSConstants.S_OK != debugProperty.GetMemoryContext(out memoryContext))
            {
                // In practice, this is where it seems to fail if you enter an invalid expression.
                return null;
            }

            CONTEXT_INFO[] bfnl = new CONTEXT_INFO[64];
            memoryContext.GetInfo((uint)enum_CONTEXT_INFO_FIELDS.CIF_ALLFIELDS, bfnl);

            // Get memory bytes interface.
            IDebugMemoryBytes2 memoryBytes;
            if (VSConstants.S_OK != debugProperty.GetMemoryBytes(out memoryBytes))
            {
                return null;
            }

            string memoryAddress;
            memoryContext.GetName(out memoryAddress);

            int intValue = Convert.ToInt32(memoryAddress, 16);

            //try
            //{
            //    IntPtr ptr = new IntPtr(intValue);
            //    GCHandle imageHandle = GCHandle.FromIntPtr(ptr);
            //    object obj = imageHandle.Target;
            //}
            //catch(Exception ex)
            //{

            //}

            // The number of bytes to read.
            ulong dataSize = 0;
            var res = memoryBytes.GetSize(out dataSize);
            unsafe
            {
                dataSize = 1024 * 1024;
            }
            //if (VSConstants.S_OK != res)
            //{
            //    return null;
            //}

            //// Allocate space for the result.
            byte[] data = new byte[dataSize];
            uint writtenBytes = 0;

            // Read data from the debuggee.
            uint unreadable = 0;
            hr = memoryBytes.ReadAt(memoryContext, (uint)dataSize, data, out writtenBytes, ref unreadable);

            if (hr != VSConstants.S_OK)
            {
                // Read failed.

                Marshal.Copy(new IntPtr(intValue), data, 0, data.Length);
            }
            else //if (writtenBytes < dataSize)
            {
                // Read partially succeeded.

                try
                {
                    //Marshal.Copy(new IntPtr(intValue), data, 0, (int)writtenBytes);

                    BinaryFormatter ser = new BinaryFormatter();
                    using (MemoryStream stream = new MemoryStream(data, 0, (int)writtenBytes))
                    {
                        MemoryStream outStream = new MemoryStream();
                        ser.Serialize(outStream, new Bitmap(800, 600));
                        byte[] serializedImage = outStream.GetBuffer();
                        string test = System.Text.Encoding.UTF8.GetString(serializedImage);
                        string test3 = System.Text.Encoding.ASCII.GetString(serializedImage);

                        //var img = Image.FromStream(stream);
                        object obj = ser.Deserialize(stream);
                    }
                }
                catch(Exception ex)
                {
                    string test = System.Text.Encoding.UTF8.GetString(data, 0, (int)writtenBytes);
                    string test3 = System.Text.Encoding.ASCII.GetString(data, 0, (int)writtenBytes);
                    
                }

                IntPtr parameter = new IntPtr(intValue);
                GCHandle handle = (GCHandle)parameter;

                object o = handle.Target;
            }
            //else
            //{
            //    // Read successful.
            //}

            return null;
        }

        //public object RetrieveFromDebugee(string addressString)
        //{
        //    object result = null;

        //    IDebugObject2 obj;

        //    obj.GetICorDebugValue(out result);

        //    return result;
        //}
    }
}
