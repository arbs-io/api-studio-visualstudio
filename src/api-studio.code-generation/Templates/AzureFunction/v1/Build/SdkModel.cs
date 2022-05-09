namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using ApiStudioIO.Utility.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class SdkModel
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            // If the developer has provided a data model namespace we terminate the code generation
            if (String.IsNullOrEmpty(apiStudio.NamespaceDataModels))
            {

                var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
                var apiResource = apiStudio?.Resourced
                    .SelectMany(resource => resource.HttpApis,
                                (resource, httpApi) => new { resource, httpApi })
                    .ToList();

                apiResource
                    .SelectMany(x => x.httpApi.DataModels)
                    .ToList()
                    .ForEach(x => sourceList.Add(GenerateModels(namespaceHelper, x.Name)));

                apiResource
                    .SelectMany(x => x.httpApi.SourceDataModel)
                    .ToList()
                    .ForEach(x => sourceList.Add(GenerateModels(namespaceHelper, x.Name)));
            }            

            return sourceList;
        }

        private static SourceCodeEntity GenerateModels(NamespaceHelper namespaceHelper, string Name)
        {
            var payloadName = $"{Name.ToAlphaNumeric(true)}";
            var sourceCode = Templates.Resource.Model
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", payloadName);
            return new SourceCodeEntity($"{namespaceHelper.Solution}-{payloadName}.Model.cs", sourceCode, false);
        }
    }
}