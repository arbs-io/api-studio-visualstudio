// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioDebug
    {
        private static OutputWindowPane _owp;
        public static void PrintVsOutput(DTE dte, string message)
        {
            // Setup debug Output window.  
            Window w = (Window)dte.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            w.Visible = true;
            OutputWindow ow = (OutputWindow)w.Object;
            if (_owp == null)
                _owp = ow.OutputWindowPanes.Add("Api Studio");
            _owp.Activate();
            _owp.OutputString($"ApiStudio: {message}");
        }
    }
}