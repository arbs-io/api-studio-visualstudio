// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.Linter.RuleSets
{
    public static class MissingResponse
    {
        public static void Run(ApiStudio apiStudio, string modelName)
        {
            foreach (var api in apiStudio.Apis)
            {
                var apiType = api.GetType().ToString().Replace("ApiStudioIO.", "");

                if (api is HttpApiGet ||
                    api is HttpApiPut ||
                    api is HttpApiPost ||
                    api is HttpApiPatch)
                {
                    if ((api as HttpApi).DataModels.Count == 0)
                        Logger.Log($"[RuleSet::MissingResponse] {api.DisplayName}", EnvDTE.vsTaskPriority.vsTaskPriorityMedium, "Payload", EnvDTE.vsTaskIcon.vsTaskIconComment, $"{modelName}.ApiStudio", -1, $"{apiType} {api.DisplayName} missing response");
                }
            }
        }
    }
}