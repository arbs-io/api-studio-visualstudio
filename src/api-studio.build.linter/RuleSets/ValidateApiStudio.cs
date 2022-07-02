// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.Build.Linter.RuleSets
{
    public static class RuleSet
    {
        public static void Run(ApiStudio apiStudio, string modelName)
        {
            Logger.Clear();

            var hasRequests = new List<HttpApi>();
            foreach (var dataModel in apiStudio.DataModeled)
            {
                hasRequests.Add(dataModel.HttpApis.FirstOrDefault());
            }
                
            foreach (var api in apiStudio.Apis)
            {
                var apiType = api.GetType().ToString().Replace("ApiStudioIO.", "");

                if (api is HttpApiGet ||
                    api is HttpApiPut ||
                    api is HttpApiPost ||
                    api is HttpApiPatch)
                {
                    if ((api as HttpApi).DataModels.Count == 0)
                        Logger.Log($"[Validate::RuleSet] MissingResponse: {api.DisplayName}", EnvDTE.vsTaskPriority.vsTaskPriorityMedium, "Payload", EnvDTE.vsTaskIcon.vsTaskIconComment, $"{modelName}.ApiStudio", -1, $"{apiType} {api.DisplayName} missing response");
                }

                if (api is HttpApiPut ||
                    api is HttpApiPost ||
                    api is HttpApiPatch)
                {                    
                    if (!hasRequests.Contains(api))
                        Logger.Log($"[Validate::RuleSet] MissingRequest: {api.DisplayName}", EnvDTE.vsTaskPriority.vsTaskPriorityMedium, "Payload", EnvDTE.vsTaskIcon.vsTaskIconComment, $"{modelName}.ApiStudio", -1, $"{apiType} {api.DisplayName} missing request");
                }
            }
        }
    }
}