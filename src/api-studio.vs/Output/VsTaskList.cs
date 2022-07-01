// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using ApiStudioIO.Vs.Services;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.Output
{
    public static class VsTaskList
    {
        //private static void TestAdd()
        //{
        //    TaskItem.Add("Exception handler", vsTaskPriority.vsTaskPriorityMedium, "WAF", vsTaskIcon.vsTaskIconNone, "test.ApiStudio", "blah blah");
        //}
        public static void AddTask(string description,
            string category,
            string subcategory,
            vsTaskPriority priority,
            vsTaskIcon icon,
            bool checkable,
            string releventFile,
            int lineNumber,
            bool canUserDelete,
            bool flushItem)
        {
            try
            {
                if (!EnsurePane()) return;

                // If we don't allow duplicates we have to itterate the tasks list to 
                // see if there is a duplicate.

                // Do this for all task items.
                for (int ti = 1; ti <= _tl.TaskItems.Count; ti++)
                {
                    // Get a reference to the task item.
                    var existingItem = _tl.TaskItems.Item(ti);
                    // Match attributes and see if this task is as same as the one being added.
                    // If the task is matching all Category, SubCategory and Description properties
                    // must be similar to the pertaining parameters. We don't care about the case here.
                    if (string.Compare(category, existingItem.Category, true) == 0 &&
                        string.Compare(subcategory, existingItem.SubCategory, true) == 0 &&
                        string.Compare(description, existingItem.Description, true) == 0)
                    {
                        // We don't have to proceed.
                        return;
                    }
                }

                // Add the new task item.
                var newItem = _tl.TaskItems.Add(category, subcategory, description, priority, icon,
                    checkable, releventFile, lineNumber, canUserDelete, flushItem);

            }
            catch { }   // Do nothing
        }

        private static TaskList _tl;
        private static bool EnsurePane()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (_tl == null)   // Setup debug Output window if it doesn't exist.
            {   
                var w = ServiceProviderHelper.DevelopmentToolsEnvironment.Windows.Item(EnvDTE.Constants.vsWindowKindTaskList);
                w.Visible = true;
                _tl = (TaskList)w.Object ?? throw new ArgumentNullException(nameof(TaskList));
            }
            _tl.Parent.Activate();
            return _tl != null;
        }
    }
}
