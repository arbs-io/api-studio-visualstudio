// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Linter.RuleSets;
using ApiStudioIO.Vs.ErrorList;
using ApiStudioIO.Vs.Output;
using ApiStudioIO.Vs.Services;

namespace ApiStudioIO.Linter
{
    public static class ApiStudioLinter
    {
        private static ApiStudioLinkIssueDataSource _linkIssueDataSource;
        public static void Run(string apiStudioFilePath)
        {
            if (_linkIssueDataSource == null)
            {
                _linkIssueDataSource = new ApiStudioLinkIssueDataSource(); 
                ServiceProviderHelper.RegisterErrorsTable(ref _linkIssueDataSource);
            }

            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);
            var apiStudioFileInfo = new FileInfo(apiStudioFilePath);
            var modelName = apiStudioFileInfo.Name.Replace(".ApiStudio", "");

            _linkIssueDataSource.CleanAllErrors();
            var errors = new List<ErrorListItem>();
            errors.AddRange(MissingRequest.Run(apiStudio, modelName));
            errors.AddRange(MissingResponse.Run(apiStudio, modelName));
            _linkIssueDataSource.AddErrors("ApiStudio", errors);
        }
    }
}