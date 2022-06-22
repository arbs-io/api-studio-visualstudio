// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioDebug
    {
        internal static OutputWindowPane _owp;

        internal static void Print(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ?? 
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            // Setup debug Output window.  
            Window w = (Window)dte.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            w.Visible = true;
            OutputWindow ow = (OutputWindow)w.Object;
            if (_owp == null)
                _owp = ow.OutputWindowPanes.Add("Api Studio");
            _owp.Activate();
            _owp.OutputString($"{message}\n");
        }
    }
}
