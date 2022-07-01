// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    public static class CodeBuilder
    {
        public static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            VsOutputString.Log($"[CodeBuilder::Build]: SdkOpenApiConfigurationOptions");
            sourceList.AddRange(SdkOpenApiConfigurationOptions.Build(apiStudio, modelName));

            VsOutputString.Log($"[CodeBuilder::Build]: SdkHttpTrigger");
            sourceList.AddRange(SdkHttpTrigger.Build(apiStudio, modelName));

            VsOutputString.Log($"[CodeBuilder::Build]: SdkHttpTriggerDesigner");
            sourceList.AddRange(SdkHttpTriggerDesigner.Build(apiStudio, modelName));

            VsOutputString.Log($"[CodeBuilder::Build]: SdkModel");
            sourceList.AddRange(SdkModel.Build(apiStudio, modelName));

            VsOutputString.Log($"[CodeBuilder::Build]: SdkHttpAuthOAuth2");
            sourceList.AddRange(SdkHttpAuthOAuth2.Build(apiStudio, modelName));

            VsOutputString.Log($"[CodeBuilder::Build]: SdkHttpAuthOAuth2Scopes");
            sourceList.AddRange(SdkHttpAuthOAuth2Scopes.Build(apiStudio, modelName));

            return sourceList;
        }
    }
}