// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioProjectItem
    {
        internal static void AddNestedFile(string sourceFile, string dependentUponFile)
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
                ProjectItem sourceProjectItem = dte.Solution.FindProjectItem(sourceFile)
                                                ?? throw new ArgumentNullException(nameof(sourceProjectItem));
                var dependentUponProjectItem = sourceProjectItem.ProjectItems.AddFromFile(dependentUponFile);
                VisualStudioDebug.Print($"[VisualStudioDteManager::AddNestedFile] {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");

                SetDependentUpon(dependentUponProjectItem, sourceProjectItem.Name);
                SetBuildAction(dependentUponProjectItem);
            }
            catch (ArgumentNullException)
            {
                VisualStudioDebug.Print($"[VisualStudioDteManager::AddNestedFile] skip {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");
            }
            catch (Exception e)
            {
                VisualStudioDebug.Print($"[VisualStudioDteManager::AddNestedFile] error {sourceFileInfo.Name} {e.Message}");
            }            
        }

        internal static void DeleteFile(string sourceFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            var sourceFileInfo = new FileInfo(sourceFile);
            try
            {
                ProjectItem projectItem = dte.Solution.FindProjectItem(sourceFile)
                                          ?? throw new ArgumentNullException(nameof(projectItem));
                projectItem.Delete();
                VisualStudioDebug.Print($"[VisualStudioDteManager::DeleteFile] {sourceFileInfo.Name}");
            }
            catch (ArgumentNullException)
            {
                VisualStudioDebug.Print($"[VisualStudioDteManager::DeleteFile] skip {sourceFileInfo.Name}");
            }
            catch (Exception e)
            {
                VisualStudioDebug.Print($"[VisualStudioDteManager::DeleteFile] error {e.Message}");
            }
        }

        private static void SetDependentUpon(ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
            VisualStudioDebug.Print($"[VisualStudioDteManager::SetDependentUpon] {sourceProjectItemName}");
        }

        private static void SetBuildAction(ProjectItem item)
        {
            if (item.ContainsProperty("BuildAction")) item.Properties.Item("BuildAction").Value = 0; //Set to "None"
        }

        private static bool ContainsProperty(this ProjectItem projectItem, string propertyName)
        {
            if (projectItem.Properties != null)
                foreach (Property item in projectItem.Properties)
                    if (item != null && item.Name == propertyName)
                        return true;

            return false;
        }
    }
}