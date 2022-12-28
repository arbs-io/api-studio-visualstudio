// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.MetaInformation
{
    public class InfoVersion : IApiStudioRule
    {
        public class Constants : IApiStudioRuleConstants
        {
            public int RuleId => 1002;
            public string RuleType => "APIS";
            public string Severity => "DESIGN_CONSIDERATION";
            public string IssueType => "INFORMATION";
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();
            string pattern = @"^([0-9]|[1-9][0-9]*)\.([0-9]|[1-9][0-9]*)\.([0-9]|[1-9][0-9]*)(?:-([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?(?:\+([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?$";
            Regex rg = new Regex(pattern, RegexOptions.None, TimeSpan.FromMilliseconds(1000));
            if (rg.Matches(apiStudio.Version).Count == 0)
            {
                var apiStudioIssue = ApiStudioIssueBuilder.GetApiStudioIssue(new Constants(), modelName,
                    "The API version should use semantic versioning");
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }
            return errors;
        }
    }
}