// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioDteManager
    {
        internal static void AddNestedFile(DTE dte, string sourceFile, string dependentUponFile)
        {
            var sourceFileInfo = new FileInfo(sourceFile);
            var dependentUponFileInfo = new FileInfo(dependentUponFile);
            // nested object is not found for nesting designer class, already nested...
            // Plus Generic debug DTE output for analytics
            try
            {
                ProjectItem sourceProjectItem = dte.Solution.FindProjectItem(sourceFile)
                                                ?? throw new ArgumentNullException(nameof(sourceProjectItem));
                var dependentUponProjectItem = sourceProjectItem.ProjectItems.AddFromFile(dependentUponFile);
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::AddNestedFile] {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");

                SetDependentUpon(dte, dependentUponProjectItem, sourceProjectItem.Name);
                SetBuildAction(dependentUponProjectItem);
            }
            catch (ArgumentNullException)
            {
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::AddNestedFile] skip {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");
            }
            catch (Exception e)
            {
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::AddNestedFile] error {sourceFileInfo.Name} {e.Message}");
            }            
        }

        internal static void DeleteFile(DTE dte, string sourceFile)
        {
            var sourceFileInfo = new FileInfo(sourceFile);
            try
            {
                ProjectItem projectItem = dte.Solution.FindProjectItem(sourceFile)
                                          ?? throw new ArgumentNullException(nameof(projectItem));
                projectItem.Delete();
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::DeleteFile] {sourceFileInfo.Name}");
            }
            catch (ArgumentNullException)
            {
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::DeleteFile] skip {sourceFileInfo.Name}");
            }
            catch (Exception e)
            {
                VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::DeleteFile] error {e.Message}");
            }
        }

        private static void SetDependentUpon(DTE dte, ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
            VisualStudioDebug.Instance.PrintVsOutput($"[VisualStudioDteManager::SetDependentUpon] {sourceProjectItemName}");
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