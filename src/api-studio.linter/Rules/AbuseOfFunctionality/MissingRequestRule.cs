// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.AbuseOfFunctionality
{
    public class MissingRequestRule : IApiStudioRule
    {
        public static class Constants
        {
            public const int RuleId = 1002;
            public const string RuleType = "APIS";
            public const string Severity = "DESIGN_SMELL";
            public const string Type = "ABUSE_OF_FUNCTIONALITY";
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
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
                    if (hasRequests.Contains(api)) continue;

                    var apiStudioIssue = new ApiStudioIssue()
                    {
                        Rule = $"APIS:{Constants.RuleType}.{Constants.RuleId}",
                        Severity = $"{Constants.Severity}",
                        Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                        Line = 0,
                        Message = $"The operation {apiType}::{api.DisplayName} missing request",
                        Type = $"{Constants.RuleId}"
                    };
                    errors.Add(new ErrorListItem(new System.Uri($"https://github.com/arbs-io/api-studio-visualstudio/tree/main/doc/linter"), apiStudioIssue));
                }
            }
            return errors;
        }
    }
}