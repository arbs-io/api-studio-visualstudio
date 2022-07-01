// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using ApiStudioIO.Vs.Services;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.Output
{
    public static class TaskItem
    {
        //private static void TestAdd()
        //{
        //    TaskItem.Add("Exception handler", vsTaskPriority.vsTaskPriorityMedium, "WAF", vsTaskIcon.vsTaskIconNone, "test.ApiStudio", "blah blah");
        //}
        public static void Add(string output, vsTaskPriority priority, string subCategory, vsTaskIcon icon, string fileName, string description)
        {
            if (string.IsNullOrEmpty(output))
                return;

            try
            {
                if (!EnsurePane()) return;

                _owp.OutputTaskItemString(output, priority, subCategory, icon, fileName, 0, description, true);
            }
            catch { }   // Do nothing
        }

        private static OutputWindowPane _owp;
        private static bool EnsurePane()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (_owp == null)   // Setup debug Output window if it doesn't exist.
            {   
                var w = ServiceProviderHelper.DevelopmentToolsEnvironment.Windows.Item(EnvDTE.Constants.vsWindowKindTaskList);
                w.Visible = true;
                var ow = (OutputWindow)w.Object ?? throw new ArgumentNullException(nameof(OutputWindow));
                _owp = ow.OutputWindowPanes.Add("Api Validation") ?? throw new ArgumentNullException(nameof(OutputWindowPane));
            }
            _owp.Activate();    // regardless make the the windows active/visible
            return _owp != null;
        }
    }
}
