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

using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    internal class NamespaceHelper
    {
        private readonly ApiStudio _apiStudio;
        private readonly string _modelName;

        internal NamespaceHelper(ApiStudio apiStudio, string modelName)
        {
            _apiStudio = apiStudio;
            _modelName = modelName;
        }

        public string Solution
        {
            get
            {
                if (!string.IsNullOrEmpty(_apiStudio.NamespaceSolution))
                    return $"{_apiStudio.NamespaceSolution}.{_modelName}";
                return $"{_modelName}".ToAlphaNumeric(true);
            }
        }

        public string DataModel
        {
            get
            {
                // If the developer has provided a data model namespace we should add the ref
                if (!string.IsNullOrEmpty(_apiStudio.NamespaceDataModels))
                    return $"using {_apiStudio.NamespaceDataModels};";
                return "";
            }
        }
    }
}