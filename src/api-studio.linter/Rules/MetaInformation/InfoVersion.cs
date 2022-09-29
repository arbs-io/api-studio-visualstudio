﻿// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.MetaInformation
{
    public class InfoVersion : IApiStudioRule
    {
        public static class Constants
        {
            public const int RuleId = 1002;
            public const string RuleType = "APIS";
            public const string Severity = "DESIGN_CONSIDERATION";
            public const string Type = "INFORMATION";

            public const int InvalidSize = 0;
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();

            string pattern = @"^([0-9]|[1-9][0-9]*)\.([0-9]|[1-9][0-9]*)\.([0-9]|[1-9][0-9]*)(?:-([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?(?:\+([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?$";
            Regex rg = new Regex(pattern);
            if (rg.Matches(apiStudio.Version).Count == 0)
            {
                var apiStudioIssue = new ApiStudioIssue()
                {
                    Rule = $"ApiStudio:{Constants.RuleType}.{Constants.RuleId}",
                    Severity = $"{Constants.Severity}",
                    Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                    Line = 0,
                    Message = $"The API version should use semantic versioning",
                    Type = $"{Constants.RuleId}"
                };
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }

            return errors;
        }
    }
}