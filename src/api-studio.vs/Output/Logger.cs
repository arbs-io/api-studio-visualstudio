// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.Vs.Output
{
    public static class Logger
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
                    owp.OutputString(DateTime.Now.ToString() + ": " + message + Environment.NewLine);
                }
            }
            catch
            {
                // Do nothing
            }
        }

        public static void Log(Exception ex)
        {
            if (ex != null)
            {
                Log(ex.ToString());
            }
        }
    }
}
