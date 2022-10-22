// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Globalization;
using ApiStudioIO.Vs.Services;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.Output
{
    public static class VsLogger
    {
        public static void Clear()
        {
            if (!EnsurePane()) return;
            _owp.Clear();
        }
        public static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                if (!EnsurePane()) return;
                _owp.OutputString(DateTime.Now.ToString(CultureInfo.InvariantCulture) + ": " + message + Environment.NewLine);
            }
            catch (Exception) { /* Ignore */ }
        }

        public static void Log(string text, vsTaskPriority priority, string subCategory, vsTaskIcon icon, string fileName, int line, string description, bool force = true)
        {
            if (string.IsNullOrEmpty(text))
                return;

            try
            {
                if (!EnsurePane()) return;
                _owp.OutputTaskItemString(DateTime.Now.ToString(CultureInfo.InvariantCulture) + ": " + text + Environment.NewLine,
                    priority, subCategory, icon, fileName, line, description, force);
            }
            catch (Exception) { /* Ignore */ }
        }

        public static void Log(Exception ex)
        {
            if (ex != null)
                Log("Exception", vsTaskPriority.vsTaskPriorityHigh, "Api Studio", vsTaskIcon.vsTaskIconCompile, "", -1, ex.ToString(), true);
        }

        private static OutputWindowPane _owp;
        private static bool EnsurePane()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (_owp == null)   // Setup debug Output window if it doesn't exist.
            {
                var w = ServiceProviderHelper.DevelopmentToolsEnvironment.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
                w.Visible = true;
                var ow = (OutputWindow)w.Object ?? throw new ArgumentNullException(nameof(OutputWindow));
                _owp = ow.OutputWindowPanes.Add("Api Studio") ?? throw new ArgumentNullException(nameof(OutputWindowPane));
            }
            _owp.Activate();    // regardless make the the windows active/visible
            return _owp != null;
        }
    }
}
