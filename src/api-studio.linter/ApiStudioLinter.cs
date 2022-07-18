// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Linter.Rules;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter
{
    public class ApiStudioLinter
    {
        private static ApiStudioLinkIssueDataSource _linkIssueDataSource = new ApiStudioLinkIssueDataSource();
        private static readonly List<IApiStudioRule> _rules = new List<IApiStudioRule>();

        private static void InitiliseLinter()
        {
            ErrorListProviderHelper.RegisterErrorsTable(ref _linkIssueDataSource);
            _rules.Clear();
            _rules.Add(new Rules.AbuseOfFunctionality.MissingRequestRule());
            _rules.Add(new Rules.AbuseOfFunctionality.MissingResponseRule());
            _rules.Add(new Rules.MetaInformation.InfoTitleRule());
            _rules.Add(new Rules.MetaInformation.InfoVersion());
            _rules.Add(new Rules.MetaInformation.InfoContactRule());
            _rules.Add(new Rules.MetaInformation.InfoDescriptionRule());
        }

        public static void RunRules(string apiStudioFilePath)
        {
            InitiliseLinter();

            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);
            var apiStudioFileInfo = new FileInfo(apiStudioFilePath);
            var modelName = apiStudioFileInfo.Name.Replace(".ApiStudio", "");

            _linkIssueDataSource.CleanAllErrors();
            var errors = new List<ErrorListItem>();

            foreach (var rule in _rules)
            {
                errors.AddRange(rule.Validate(apiStudio, modelName));
            }
            _linkIssueDataSource.AddErrors("ApiStudio", errors);
        }
    }
}