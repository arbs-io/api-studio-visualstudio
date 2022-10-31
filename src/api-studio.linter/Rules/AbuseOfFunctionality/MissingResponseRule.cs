// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Vs.ErrorList;
using System.Collections.Generic;
using ApiStudioIO.Linter.Extensions;

namespace ApiStudioIO.Linter.Rules.AbuseOfFunctionality
{
    public class MissingResponseRule : IApiStudioRule
    {
        public class Constants : IApiStudioRuleConstants
        {
            public int RuleId => 1101;
            public string RuleType => "APIS";
            public string Severity => "DESIGN_CONSIDERATION";
            public string IssueType => "ABUSE_OF_FUNCTIONALITY";
        }

        public IEnumerable<ErrorListItem> Validate(ApiStudio apiStudio, string modelName)
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
                    if ((api as HttpApi).DataModels.Count != 0) continue;

                    var apiStudioIssue = ApiStudioIssueBuilder.GetApiStudioIssue(new Constants(), modelName,
                        $"The operation {apiType}::{api.DisplayName} missing response");
                    errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
                }
            }
            return errors;
        }
    }
}