// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using ApiStudioIO.Vs.Output;
using ApiStudioIO.Vs.Services;

namespace ApiStudioIO.Vs.Project
{
    public static class ProjectItemHelper
    {
        public static void AddNestedFile(FileInfo sourceFileInfo, string dependentUponFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dependentUponFileInfo = new FileInfo(dependentUponFile);
            // nested object is not found for nesting designer class, already nested...
            // Plus Generic debug DTE output for analytics
            try
            {
                var projectItem = ServiceProviderHelper.DevelopmentToolsEnvironment.Solution.FindProjectItem(sourceFileInfo.FullName)
                    ?? throw new ArgumentNullException("ProjectItemHelper");

                var dependentUponProjectItem = projectItem.ProjectItems.AddFromFile(dependentUponFile);
                VsLogger.Log($"[ProjectItem::AddNestedFile] {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");

                SetDependentUpon(dependentUponProjectItem, projectItem.Name);
                SetBuildAction(dependentUponProjectItem);
            }
            catch (ArgumentNullException)
            {
                VsLogger.Log($"[ProjectItem::AddNestedFile] Ignored {sourceFileInfo.Name} SDK style project resource implicitly registered");
                // Note: Ignore SDK style projects will auto-nest using naming convention
            }
            catch (Exception e)
            {
                VsLogger.Log($"[ProjectItem::AddNestedFile] error {sourceFileInfo.Name} {e.Message}");
            }
        }

        public static void DeleteFile(string sourceFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var sourceFileInfo = new FileInfo(sourceFile);
            try
            {
                var projectItem = ServiceProviderHelper.DevelopmentToolsEnvironment.Solution.FindProjectItem(sourceFileInfo.FullName)
                    ?? throw new ArgumentNullException("ProjectItemHelper");

                projectItem.Delete();
                VsLogger.Log($"[ProjectItem::DeleteFile] {sourceFileInfo.Name}");
            }
            catch (ArgumentNullException)
            {
                // Note: Ignore SDK style projects will auto-nest using naming convention
                VsLogger.Log($"[ProjectItem::DeleteFile] Ignored {sourceFileInfo.Name} SDK style project resource implicitly registered");
            }
            catch (Exception e)
            {
                VsLogger.Log($"[ProjectItem::DeleteFile] error {e.Message}");
            }
            finally
            {
                try
                {
                    if (sourceFileInfo.Exists)
                    {
                        sourceFileInfo.Delete();
                        VsLogger.Log($"[ProjectItem::DeleteFile] forced delete on file {sourceFileInfo.Name}");
                    }
                }
                catch (Exception) { /* Ignore */ }
            }
        }

        public static void SetDependentUpon(EnvDTE.ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
            VsLogger.Log($"[ProjectItem::SetDependentUpon] {sourceProjectItemName}");
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