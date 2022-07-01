// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.Vs.Project
{
    public static class ProjectItem
    {
        public static void AddNestedFile(string sourceFile, string dependentUponFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            var sourceFileInfo = new FileInfo(sourceFile);
            var dependentUponFileInfo = new FileInfo(dependentUponFile);
            // nested object is not found for nesting designer class, already nested...
            // Plus Generic debug DTE output for analytics
            try
            {
                var sourceProjectItem = dte.Solution.FindProjectItem(sourceFile)
                                                ?? throw new ArgumentNullException(nameof(ProjectItem));
                var dependentUponProjectItem = sourceProjectItem.ProjectItems.AddFromFile(dependentUponFile);
                VsOutputString.Log($"[ProjectItem::AddNestedFile] {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");

                SetDependentUpon(dependentUponProjectItem, sourceProjectItem.Name);
                SetBuildAction(dependentUponProjectItem);
            }
            catch (ArgumentNullException)
            {
                // Note SDK style projects will auto-nest using naming convention
                //Logger.Log($"[ProjectItem::AddNestedFile] skip {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");
            }
            catch (Exception e)
            {
                VsOutputString.Log($"[ProjectItem::AddNestedFile] error {sourceFileInfo.Name} {e.Message}");
            }            
        }

        public static void DeleteFile(string sourceFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            var sourceFileInfo = new FileInfo(sourceFile);
            try
            {
                EnvDTE.ProjectItem projectItem = dte.Solution.FindProjectItem(sourceFile)
                                          ?? throw new ArgumentNullException(nameof(ProjectItem));
                projectItem.Delete();
                VsOutputString.Log($"[ProjectItem::DeleteFile] {sourceFileInfo.Name}");
            }
            catch (ArgumentNullException)
            {
                VsOutputString.Log($"[ProjectItem::DeleteFile] skip {sourceFileInfo.Name}");
            }
            catch (Exception e)
            {
                VsOutputString.Log($"[ProjectItem::DeleteFile] error {e.Message}");
            }
        }

        public static void SetDependentUpon(EnvDTE.ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
            VsOutputString.Log($"[ProjectItem::SetDependentUpon] {sourceProjectItemName}");
        }

        public static void SetBuildAction(EnvDTE.ProjectItem item)
        {
            if (item.ContainsProperty("BuildAction")) item.Properties.Item("BuildAction").Value = 0; //Set to "None"
        }

        public static bool ContainsProperty(this EnvDTE.ProjectItem projectItem, string propertyName)
        {
            if (projectItem.Properties != null)
                foreach (Property item in projectItem.Properties)
                    if (item != null && item.Name == propertyName)
                        return true;

            return false;
        }
    }
}