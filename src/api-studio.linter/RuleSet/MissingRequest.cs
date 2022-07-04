// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.Linter.RuleSets
{
    public static class MissingRequest
    {
        public static class Constants
        {
            public const int RuleId = 1002;
            public const string RuleType = "AOF";
            public const string Severity = "DESIGN_SMELL";
            public const string Type = "ABUSE_OF_FUNCTIONALITY";
        }

        public static IEnumerable<ErrorListItem> Run(ApiStudio apiStudio, string modelName)
        {
            var errors = new List<ErrorListItem>();

            var hasRequests = new List<HttpApi>();
            foreach (var dataModel in apiStudio.DataModeled)
            {
                hasRequests.Add(dataModel.HttpApis.FirstOrDefault());
            }
                
            foreach (var api in apiStudio.Apis)
            {
                var apiType = api.GetType().ToString().Replace("ApiStudioIO.", "");
                if (api is HttpApiPut ||
                    api is HttpApiPost ||
                    api is HttpApiPatch)
                {                    
                    if (!hasRequests.Contains(api))
                    {
                        var apiStudioIssue = new ApiStudioIssue()
                        {
                            Rule = $"APIS:{Constants.RuleType}.{Constants.RuleId}",
                            Severity = $"{Constants.Severity}",
                            Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                            Line = 0,
                            Message = $"The operation {apiType}::{api.DisplayName} missing request",
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