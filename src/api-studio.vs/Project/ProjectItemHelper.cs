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
                    ?? throw new ArgumentNullException(nameof(ProjectItemHelper));

                var dependentUponProjectItem = projectItem.ProjectItems.AddFromFile(dependentUponFile);
                Logger.Log($"[ProjectItem::AddNestedFile] {sourceFileInfo.Name} -> {dependentUponFileInfo.Name}");

                SetDependentUpon(dependentUponProjectItem, projectItem.Name);
                SetBuildAction(dependentUponProjectItem);
            }
            catch (ArgumentNullException) 
            {
                Logger.Log($"[ProjectItem::AddNestedFile] Ignored {sourceFileInfo.Name} SDK style project resource implicitly registered");
                // Note: Ignore SDK style projects will auto-nest using naming convention
            }
            catch (Exception e)
            {
                Logger.Log($"[ProjectItem::AddNestedFile] error {sourceFileInfo.Name} {e.Message}");
            }            
        }

        public static void DeleteFile(string sourceFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var sourceFileInfo = new FileInfo(sourceFile);
            try
            {
                var projectItem = ServiceProviderHelper.DevelopmentToolsEnvironment.Solution.FindProjectItem(sourceFileInfo.FullName)
                    ?? throw new ArgumentNullException(nameof(ProjectItemHelper));

                projectItem.Delete();
                Logger.Log($"[ProjectItem::DeleteFile] {sourceFileInfo.Name}");
            }
            catch (ArgumentNullException)
            {
                // Note: Ignore SDK style projects will auto-nest using naming convention
                Logger.Log($"[ProjectItem::DeleteFile] Ignored {sourceFileInfo.Name} SDK style project resource implicitly registered");
            }
            catch (Exception e)
            {
                Logger.Log($"[ProjectItem::DeleteFile] error {e.Message}");
            }
            finally
            {
                try
                {
                    if (sourceFileInfo.Exists)
                    {
                        sourceFileInfo.Delete();
                        Logger.Log($"[ProjectItem::DeleteFile] forced delete on file {sourceFileInfo.Name}");
                    }
                }
                catch (Exception) { }   // Ignore
            }
        }

        public static void SetDependentUpon(EnvDTE.ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE ??
                      throw new ArgumentNullException("Package.GetGlobalService", nameof(DTE));

            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
            Logger.Log($"[ProjectItem::SetDependentUpon] {sourceProjectItemName}");
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