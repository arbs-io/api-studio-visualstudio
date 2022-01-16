using EnvDTE;
using System;

namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    internal static class VisualStudioDteManager
    {
        internal static void AddNestedFile(DTE dte, string diagramFile, string sourceFile)
        {
            ProjectItem projectItem = dte.Solution.FindProjectItem(diagramFile) ?? throw new ArgumentNullException(nameof(projectItem));

            var codeGeneratedItem = projectItem.ProjectItems.AddFromFile(sourceFile);

            SetDependentUpon(codeGeneratedItem, projectItem.Name);
            SetBuildAction(codeGeneratedItem);
        }

        internal static void DeleteFile(DTE dte, string projectFile)
        {
            ProjectItem projectItem = dte.Solution.FindProjectItem(projectFile) ?? throw new ArgumentNullException(nameof(projectItem));
            projectItem.Delete();
        }

        private static void SetDependentUpon(ProjectItem item, string projectItemName)
        {
            if (item.ContainsProperty("DependentUpon"))
            {
                item.Properties.Item("DependentUpon").Value = projectItemName;
            }
        }

        private static void SetBuildAction(ProjectItem item)
        {
            if (item.ContainsProperty("BuildAction"))
            {
                item.Properties.Item("BuildAction").Value = 0;  //Set to "None"
            }
        }

        private static bool ContainsProperty(this ProjectItem projectItem, string propertyName)
        {
            if (projectItem.Properties != null)
            {
                foreach (Property item in projectItem.Properties)
                {
                    if (item != null && item.Name == propertyName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsKind(this Project project, params string[] kindGuids)
        {
            foreach (var guid in kindGuids)
            {
                if (project.Kind.Equals(guid, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}