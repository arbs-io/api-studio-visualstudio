// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal sealed class VisualStudioDebug
    {        
        #region Singleton

        //This should be readonly but we want to load from visual studio

        static VisualStudioDebug()
        {
        }

        private VisualStudioDebug()
        {
        }

        internal static VisualStudioDebug Instance { get; } = new VisualStudioDebug();

        internal static void SetDevelopmentToolsEnvironment(DTE dte) => _dte = dte;

        internal static OutputWindowPane _owp;
        internal static DTE _dte;

        internal void PrintVsOutput(string message)
        {
            if (_dte is null)
            {
                throw new ArgumentNullException(nameof(_dte));
            }

            // Setup debug Output window.  
            Window w = (Window)_dte.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            w.Visible = true;
            OutputWindow ow = (OutputWindow)w.Object;
            if (_owp == null)
                _owp = ow.OutputWindowPanes.Add("Api Studio");
            _owp.Activate();
            _owp.OutputString($"{message}\n");
        }

        #endregion Singleton
    }
}
