// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.Vs.Output
{
    public static class WindowPane
    {
        private static OutputWindowPane _owp;
        private static DTE _dte;
        private static DTE DevelopmentToolsEnvironment
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                return _dte ?? (_dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE);
            }
        }

        public static OutputWindowPane Output
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                if (_owp == null)
                {
                    // Setup debug Output window.  
                    var w = DevelopmentToolsEnvironment.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
                    w.Visible = true;
                    var ow = (OutputWindow)w.Object;
                    if (_owp == null)
                        _owp = ow.OutputWindowPanes.Add("Api Studio");
                }
                _owp.Activate();
                return _owp;                
            }
        }
    }
}
