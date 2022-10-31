// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules.AbuseOfFunctionality
{
    public class MissingRequestRule : IApiStudioRule
    {
        public class Constants : IApiStudioRuleConstants
        {
            public int RuleId => 1102;
            public string RuleType => "APIS";
            public string Severity => "DESIGN_CONSIDERATION";
            public string IssueType => "ABUSE_OF_FUNCTIONALITY";
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

                    var apiStudioIssue = ApiStudioIssueBuilder.GetApiStudioIssue(new Constants(), modelName,
                        $"The operation {apiType}::{api.DisplayName} missing request");
                    errors.Add(new ErrorListItem(new System.Uri($"https://github.com"), apiStudioIssue));
                }
            }
            return errors;
        }
    }
}