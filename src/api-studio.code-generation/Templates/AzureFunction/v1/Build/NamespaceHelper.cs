using System;
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
                if (!String.IsNullOrEmpty(_apiStudio.NamespaceSolution))
                    return $"{_apiStudio.NamespaceSolution}.{_modelName}";
                else
                    return $"{_modelName}".ToAlphaNumeric(true);
            }
        }

        public string DataModel
        {
            get
            {
                // If the developer has provided a data model namespace we should add the ref
                if (!String.IsNullOrEmpty(_apiStudio.NamespaceDataModels))
                    return $"using {_apiStudio.NamespaceDataModels};";
                else
                    return "";
            }
        }
    }
}