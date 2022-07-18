// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.MetaInformation
{
    public class InfoDescriptionRule : IApiStudioRule
    {
        public static class Constants
        {
            public const int RuleId = 1003;
            public const string RuleType = "APIS";
            public const string Severity = "DESIGN_CONSIDERATION";
            public const string Type = "INFORMATION";

            public const int MinimumDescriptionSize = 60;
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();
            
            if (apiStudio.Description.Length < Constants.MinimumDescriptionSize)
            {
                var apiStudioIssue = new ApiStudioIssue()
                {
                    Rule = $"ApiStudio:{Constants.RuleType}.{Constants.RuleId}",
                    Severity = $"{Constants.Severity}",
                    Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                    Line = 0,
                    Message = $"The description is too short to be useful for consumers of your solution",
                    Type = $"{Constants.RuleId}"
                };
                errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
            }
            
            return errors;
        }
    }
}