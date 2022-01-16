using ApiStudioIO.CodeGeneration.VisualStudio;
using ApiStudioIO.Utility.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    internal static class SdkModel
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            var apiResource = apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                            (resource, httpApi) => new { resource, httpApi })
                .ToList();

            apiResource
                .SelectMany(x => x.httpApi.DataModels)
                .ToList()
                .ForEach(x => sourceList.Add(GenerateModels(modelName, x.Name)));

            apiResource
                .SelectMany(x => x.httpApi.SourceDataModel)
                .ToList()
                .ForEach(x => sourceList.Add(GenerateModels(modelName, x.Name)));

            return sourceList;
        }

        private static SourceCodeEntity GenerateModels(string modelName, string dataModel)
        {
            var payloadName = $"{dataModel.ToAlphaNumeric(true)}";
            var sourceCode = Templates.Resource.Model
                .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", payloadName);
            return new SourceCodeEntity($"{modelName}-{payloadName}.Model.cs", sourceCode, false);
        }
    }
}