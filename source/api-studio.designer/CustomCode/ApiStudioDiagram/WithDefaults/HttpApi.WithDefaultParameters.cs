﻿namespace ApiStudioIO
{
    using ApiStudioIO.Common.Models.Http;
    using ApiStudioIO.Utility.Extensions;
    using Microsoft.VisualStudio.Modeling;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class HttpApiParameterExtension
    {
        internal static HttpApi WithDefaultParameters(this HttpApi httpApi)
        {
            ClearAutoGeneratedDefaults(httpApi);
            CreateDefaults(httpApi);

            return httpApi;
        }

        private static void ClearAutoGeneratedDefaults(HttpApi httpApi)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("HttpApiParameterExtension.ClearAutoGeneratedDefaults"))
            {
                httpApi.HttpApiParameters
                    .Where(x => x.IsAutoGenerated)
                    .ToList()
                    .ForEach(x => httpApi.HttpApiParameters.Remove(x));
                t.Commit();
            }
        }

        private static void CreateDefaults(HttpApi httpApi)
        {
            var sourceApiStudio = httpApi.ApiStudio ??
                                throw new ArgumentNullException(nameof(httpApi.ApiStudio));

            var managedList = new List<HttpResourceParameter>();
            var variableCaseType = sourceApiStudio.CodeGenerationVariableCaseType;

            //Get document identifiers in resource tree
            var resource = httpApi.Resourced.FirstOrDefault();
            while (resource != null)
            {
                if (resource is ResourceInstance document)
                {
                    managedList.Add(
                        CreateManagedApiParameter(variableCaseType, document)
                        );
                }

                if (resource.SourceResource.Count > 0)
                {
                    resource = resource.SourceResource.FirstOrDefault();
                }
                else
                {
                    break;
                }
            }

            //Get custom parameters for this API
            foreach (var parameter in httpApi.HttpApiParameters)
            {
                managedList.Add(
                    CreateManagedApiParameter(variableCaseType, parameter)
                    );
            }

            foreach (var dataModel in sourceApiStudio.DataModeled)
            {
                foreach (var api in dataModel.HttpApis)
                {
                    if (httpApi == api)
                    {
                        managedList.Add(
                            CreateManagedApiParameter(variableCaseType, dataModel.Name, dataModel.Name,
                                dataModel.Description, true, HttpApiParameterTypes.Body, true)
                            );
                    }
                }
            }

            //Check if collection and if UsePagination or UseSorting is set
            if (httpApi.Resourced.FirstOrDefault()?.GetType() == typeof(ResourceCollection))
            {
                var source = (ResourceCollection)httpApi.Resourced.FirstOrDefault();
                if (source != null && source.UsePagination)
                {
                    managedList.Add(
                        CreateManagedApiParameter(variableCaseType, "Page", "int",
                            "The offset parameter will be used to skip past the number of rows specified", false,
                            HttpApiParameterTypes.Query, true)
                        );

                    managedList.Add(
                        CreateManagedApiParameter(variableCaseType, "Limit", "int",
                            "The limit amount will set the number of rows returned in the payload", false,
                            HttpApiParameterTypes.Query, true)
                        );
                }

                if (source != null && source.UseSorting)
                {
                    managedList.Add(
                        CreateManagedApiParameter(variableCaseType, "Sort", "string",
                            "The sort parameter will be used to order the results. The format should be [attribute:direction],[...]. For example mandateCode:desc,portfolioCode:desc",
                            false, HttpApiParameterTypes.Query, true)
                        );
                }
            }
            ApiStudioComponentTransactionManager.Save(httpApi, managedList);
        }

        private static HttpResourceParameter CreateManagedApiParameter(CodeGenerationVariableCaseTypes variableCaseType,
            string identifier, string dataType, string description, bool isRequired, HttpApiParameterTypes fromType, bool isAutoGenerated)
        {

            var response = new HttpResourceParameter
            {
                Identifier = identifier.ToApiStudioVariableCase(variableCaseType),
                DataType = dataType,
                Description = description,
                IsRequired = isRequired,
                FromType = fromType.ToHttpTypeParameterLocation(),
                IsAutoGenerated = isAutoGenerated
            };
            return response;
        }

        private static HttpResourceParameter CreateManagedApiParameter(CodeGenerationVariableCaseTypes variableCaseType, ResourceInstance document)
        {
            return CreateManagedApiParameter(
                variableCaseType,
                document.InstanceIdentity,
                document.InstanceDataType,
                document.InstanceDescription,
                true,
                HttpApiParameterTypes.Path,
                true);
        }

        private static HttpResourceParameter CreateManagedApiParameter(CodeGenerationVariableCaseTypes variableCaseType, HttpApiParameter parameterCustom)
        {
            return CreateManagedApiParameter(
                variableCaseType,
                parameterCustom.Identifier,
                parameterCustom.DataType,
                parameterCustom.Description,
                parameterCustom.IsRequired,
                parameterCustom.FromType,
                true);
        }

        private static string ToApiStudioVariableCase(this String str, CodeGenerationVariableCaseTypes caseType)
        {
            switch (caseType)
            {
                case CodeGenerationVariableCaseTypes.PascalCase:
                    return str.ToPascalCase();

                case CodeGenerationVariableCaseTypes.CamelCase:
                    return str.ToCamelCase();

                case CodeGenerationVariableCaseTypes.SnakeCase:
                    return str.ToSnakeCase();

                default:
                    return str;
            }
        }
    }
}