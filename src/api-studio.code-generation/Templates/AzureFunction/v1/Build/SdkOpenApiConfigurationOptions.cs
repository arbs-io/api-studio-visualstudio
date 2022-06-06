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

using System.Collections.Generic;
using ApiStudioIO.CodeGeneration.VisualStudio;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    internal static class SdkOpenApiConfigurationOptions
    {
        internal static List<SourceCodeEntity> Build(ApiStudio eai, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            var template = Templates.Resource.OpenApiConfigurationOptions;

            var output = template
                .Replace("{{TOKEN_OAS_TITLE}}", eai?.Title)
                .Replace("{{TOKEN_OAS_VERSION}}", eai?.Version)
                .Replace("{{TOKEN_OAS_DESCRIPTION}}", eai?.Description)
                .Replace("{{TOKEN_OAS_CONTACT_URL}}", eai?.ContactUrl)
                .Replace("{{TOKEN_OAS_CONTACT_NAME}}", eai?.ContactName);

            sourceList.Add(
                new SourceCodeEntity($"{modelName}.OpenApiConfigurationOptions.cs", output, true));

            return sourceList;
        }
    }
}