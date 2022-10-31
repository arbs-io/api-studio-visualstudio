// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.MetaInformation
{
    public class InfoTitleRule : IApiStudioRule
    {
        public class Constants : IApiStudioRuleConstants
        {
            public int RuleId => 1001;
            public string RuleType => "APIS";
            public string Severity => "DESIGN_CONSIDERATION";
            public string IssueType => "INFORMATION";
            public const int InvalidSize = 0;
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();
            if (apiStudio.Title.Length <= Constants.InvalidSize)
            {
                var apiStudioIssue = ApiStudioIssueBuilder.GetApiStudioIssue(new Constants(), modelName,
                    "The title is missing");
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }
            return errors;
        }
    }
}