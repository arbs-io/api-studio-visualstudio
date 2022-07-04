// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;
using ApiStudioIO.Vs.Output;
using System.Collections.Generic;

namespace ApiStudioIO.Linter.RuleSets
{
    public static class MissingResponse
    {
        public static class Constants
        {
            public const int RuleId = 1001;
            public const string RuleType = "AOF";
            public const string Severity = "DESIGN_SMELL";
            public const string Type = "ABUSE_OF_FUNCTIONALITY";
        }

        public static IEnumerable<ErrorListItem> Run(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();
            foreach (var api in apiStudio.Apis)
            {
                var apiType = api.GetType().ToString().Replace("ApiStudioIO.", "");

                if (api is HttpApiGet ||
                    api is HttpApiPut ||
                    api is HttpApiPost ||
                    api is HttpApiPatch)
                {
                    if ((api as HttpApi).DataModels.Count == 0)
                    {
                        var apiStudioIssue = new ApiStudioIssue()
                        {
                            Rule = $"APIS:{Constants.RuleType}.{Constants.RuleId}",
                            Severity = $"{Constants.Severity}",
                            Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                            Line = 0,
                            Message = $"The operation {apiType}::{api.DisplayName} missing response",
                            Type = $"{Constants.RuleId}"
                        };
                        errors.Add(new ErrorListItem(new System.Uri($"https://api-studio.io/ruleset/{Constants.RuleId}"), apiStudioIssue));
                    }
                }
            }
            return errors;
        }
    }
}