// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO.CodeGen.Utility
{
    public class NamespaceHelper
    {
        private readonly ApiStudio _apiStudio;
        private readonly string _modelName;

        public NamespaceHelper(ApiStudio apiStudio, string modelName)
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