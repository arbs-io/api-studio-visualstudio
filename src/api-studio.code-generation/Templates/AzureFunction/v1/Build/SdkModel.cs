// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.CodeGeneration.VisualStudio;
using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    using static String;

    internal static class SdkModel
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            // If the developer has provided a data model namespace we terminate the code generation
            if (IsNullOrEmpty(apiStudio.NamespaceDataModels))
            {
                var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
                var apiResource = apiStudio.Resourced
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

        private static SourceCodeEntity GenerateModels(NamespaceHelper namespaceHelper, string name)
        {
            var payloadName = $"{name.ToAlphaNumeric(true)}";
            var sourceCode = Templates.Resource.Model
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", payloadName);
            return new SourceCodeEntity($"{namespaceHelper.Solution}-{payloadName}.Model.cs", sourceCode, false);
        }
    }
}