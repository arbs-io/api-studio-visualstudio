// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.CodeGen.CSharpMinimalApiDotNet6.Build;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Vs.Output;
using ApiStudioIO.Common.Interfaces;

namespace ApiStudioIO.CodeGen.CSharpMinimalApiDotNet6
{
    public class CSharpMinimalApiDotNet6CodeGenerator : IApiStudioCodeGeneratorProvider
    {
        private readonly ApiStudio _apiStudio;
        private readonly string _modelName;
        public CSharpMinimalApiDotNet6CodeGenerator(ApiStudio apiStudio, string modelName)
        {
            _apiStudio = apiStudio;
            _modelName = modelName;
        }
        public List<SourceCodeEntity> Run()
        {
            var sourceList = new List<SourceCodeEntity>();

            VsLogger.Log($"[CodeBuilder::Build]: SdkOpenApiConfigurationOptions");
            sourceList.AddRange(SdkOpenApiConfigurationOptions.Build(_apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkHttpTrigger");
            sourceList.AddRange(SdkHttpTrigger.Build(_apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkHttpTriggerDesigner");
            sourceList.AddRange(SdkHttpTriggerDesigner.Build(_apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkModel");
            sourceList.AddRange(SdkModel.Build(_apiStudio, _modelName));
            
            return sourceList;
        }
    }
}