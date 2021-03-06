// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.CodeGen.CSharpNet6AzFunc.v1.Build;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.CodeGen.CSharpNet6AzFunc.v1
{
    internal static class CodeBuilder
    {
        internal static List<SourceCodeEntity> Run(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            Logger.Log($"[CodeBuilder::Build]: SdkOpenApiConfigurationOptions");
            sourceList.AddRange(SdkOpenApiConfigurationOptions.Build(apiStudio, modelName));

            Logger.Log($"[CodeBuilder::Build]: SdkHttpTrigger");
            sourceList.AddRange(SdkHttpTrigger.Build(apiStudio, modelName));

            Logger.Log($"[CodeBuilder::Build]: SdkHttpTriggerDesigner");
            sourceList.AddRange(SdkHttpTriggerDesigner.Build(apiStudio, modelName));

            Logger.Log($"[CodeBuilder::Build]: SdkModel");
            sourceList.AddRange(SdkModel.Build(apiStudio, modelName));

            Logger.Log($"[CodeBuilder::Build]: SdkHttpAuthOAuth2");
            sourceList.AddRange(SdkHttpAuthOAuth2.Build(apiStudio, modelName));

            Logger.Log($"[CodeBuilder::Build]: SdkHttpAuthOAuth2Scopes");
            sourceList.AddRange(SdkHttpAuthOAuth2Scopes.Build(apiStudio, modelName));

            return sourceList;
        }
    }
}