// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Utility.Extensions;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Vs.Output;
using ApiStudioIO.CodeGen.Utility;

namespace ApiStudioIO.CodeGen.CSharpAzureFunctionDotNet6.Build
{
    using static String;

    internal static class SdkModel
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            // If the developer has provided a data model namespace we terminate the code generation
            if (!IsNullOrEmpty(apiStudio.NamespaceDataModels)) return sourceList;

            var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
            var apiResource = apiStudio.Resourced
                .SelectMany(resource => resource.HttpApis(),
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

            return sourceList;
        }

        private static SourceCodeEntity GenerateModels(NamespaceHelper namespaceHelper, string name)
        {
            var payloadName = $"{name.ToAlphaNumeric(true)}";
            var sourceCode = Templates.AzureFunctionResource.Model
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", payloadName);

            VsLogger.Log($"[SdkModel]: {namespaceHelper.Solution}-{payloadName}.Model");

            return new SourceCodeEntity($"{namespaceHelper.Solution}-{payloadName}.Model.cs", sourceCode, false);
        }
    }
}