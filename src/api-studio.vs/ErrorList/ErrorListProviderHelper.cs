// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using ApiStudioIO.Vs.Services;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell.TableManager;

namespace ApiStudioIO.Vs.ErrorList
{
    public static class ErrorListProviderHelper
    {
        public static void RegisterErrorsTable(ref ApiStudioLinkIssueDataSource issues)
        {
            var componentModel = ServiceProviderHelper.GetGlobalService(typeof(SComponentModel)) as IComponentModel;
            var tableManagerProvider = componentModel?.GetService<ITableManagerProvider>()
                                       ?? throw new InvalidOperationException("ITableManagerProvider");

            var table = tableManagerProvider.GetTableManager(StandardTables.ErrorsTable);
            table.AddSource(issues, ApiStudioLinkIssueDataSource.Columns);
        }
    }
}
