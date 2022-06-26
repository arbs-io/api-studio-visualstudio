// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.VisualStudio
{
    public static class VisualStudioDebug
    {
        private static OutputWindowPane _owp;

        public static void OutputString(string message)
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
            _owp.OutputString($"{message}{Environment.NewLine}");
        }


        public static void OutputTaskItemString(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            // Setup debug Output window.  
            Window w = (Window)dte.Windows.Item(EnvDTE.Constants.vsWindowKindTaskList);
            w.Visible = true;
            OutputWindow ow = (OutputWindow)w.Object;
            if (_owp == null)
                _owp = ow.OutputWindowPanes.Add("Api Studio");
            _owp.Activate();
            _owp.OutputTaskItemString(message, vsTaskPriority.vsTaskPriorityMedium, "test-cat", vsTaskIcon.vsTaskIconComment, "test-file.txt", 24, "test desc");
        }
    }
}
