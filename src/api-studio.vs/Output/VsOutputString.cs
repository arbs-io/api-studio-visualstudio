// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Globalization;
using ApiStudioIO.Vs.Services;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.Output
{
    public static class VsOutputString
    {
        public static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                if (!EnsurePane()) return;
                
                _owp.OutputString(DateTime.Now.ToString(CultureInfo.InvariantCulture) + ": " + message + Environment.NewLine);
            }
            catch { }   // Do nothing
        }

        public static void Log(Exception ex)
        {
            if (ex != null)
                Log(ex.ToString());
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
