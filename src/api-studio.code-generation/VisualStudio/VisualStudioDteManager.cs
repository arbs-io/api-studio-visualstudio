// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using EnvDTE;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioDteManager
    {
        internal static void AddNestedFile(DTE dte, string sourceFile, string dependentUponFile)
        {
            ProjectItem sourceProjectItem = dte.Solution.FindProjectItem(sourceFile)
                                            ?? throw new ArgumentNullException(nameof(sourceProjectItem));

            var dependentUponProjectItem = sourceProjectItem.ProjectItems.AddFromFile(dependentUponFile);

            SetDependentUpon(dependentUponProjectItem, sourceProjectItem.Name);
            SetBuildAction(dependentUponProjectItem);
        }

        internal static void DeleteFile(DTE dte, string projectFile)
        {
            ProjectItem projectItem = dte.Solution.FindProjectItem(projectFile)
                                      ?? throw new ArgumentNullException(nameof(projectItem));
            projectItem.Delete();
        }

        private static void SetDependentUpon(ProjectItem dependentUponProjectItem, string sourceProjectItemName)
        {
            if (dependentUponProjectItem.ContainsProperty("DependentUpon"))
                dependentUponProjectItem.Properties.Item("DependentUpon").Value = sourceProjectItemName;
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