// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.Vs.Output
{
    public static class TaskItem
    {
        public static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                var owp = WindowPane.Output;
                if (owp != null)
                {
                    //TODO validation rules ...
                    //owp.OutputTaskItemString(DateTime.Now.ToString() + ": " + message + Environment.NewLine);
                }
            }
            catch
            {
                // Do nothing
            }
        }
    }
}
