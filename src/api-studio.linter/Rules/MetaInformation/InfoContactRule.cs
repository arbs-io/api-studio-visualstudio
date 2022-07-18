// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.MetaInformation
{
    public class InfoContactRule : IApiStudioRule
    {
        public static class Constants
        {
            public const int RuleId = 1004;
            public const string RuleType = "APIS";
            public const string Severity = "DESIGN_CONSIDERATION";
            public const string Type = "INFORMATION";

            public const int InvalidSize = 0;
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();
            
            if (apiStudio.ContactName.Length <= Constants.InvalidSize)
            {
                var apiStudioIssue = new ApiStudioIssue()
                {
                    Rule = $"ApiStudio:{Constants.RuleType}.{Constants.RuleId}",
                    Severity = $"{Constants.Severity}",
                    Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                    Line = 0,
                    Message = $"The Contact Name is missing",
                    Type = $"{Constants.RuleId}"
                };
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }

            if (apiStudio.ContactUrl.Length <= Constants.InvalidSize)
            {
                var apiStudioIssue = new ApiStudioIssue()
                {
                    Rule = $"ApiStudio:{Constants.RuleType}.{Constants.RuleId}",
                    Severity = $"{Constants.Severity}",
                    Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                    Line = 0,
                    Message = $"The Contact Url is missing",
                    Type = $"{Constants.RuleId}"
                };
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }

            return errors;
        }
    }
}