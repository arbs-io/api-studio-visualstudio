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
        private readonly BuildTargetModel _buildTargetModel;
        public CSharpMinimalApiDotNet6CodeGenerator(BuildTargetModel buildTargetModel, ApiStudio apiStudio, string modelName)
        {
            _apiStudio = apiStudio;
            _modelName = modelName;
            _buildTargetModel = buildTargetModel;
        }
        public List<SourceCodeEntity> Run()
        {
            var sourceList = new List<SourceCodeEntity>();

            VsLogger.Log($"[CodeBuilder::Build]: SdkOpenApiConfigurationOptions");
            sourceList.AddRange(SdkOpenApiConfigurationOptions.Build(_apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkHttpEndpoint");
            sourceList.AddRange(SdkHttpEndpoint.Build(_buildTargetModel, _apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkHttpEndpointDesigner");
            sourceList.AddRange(SdkHttpEndpointDesigner.Build(_buildTargetModel, _apiStudio, _modelName));

            VsLogger.Log($"[CodeBuilder::Build]: SdkModel");
            sourceList.AddRange(SdkModel.Build(_buildTargetModel, _apiStudio, _modelName));
            
            return sourceList;
        }
    }
}