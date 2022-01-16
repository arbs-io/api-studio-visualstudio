namespace ApiStudioIO
{
    using Microsoft.VisualStudio.Modeling;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class ApiStudioComponentStoreDomainModel
    {

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentParameter> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ApiParameters"))
            {
                httpApi.HttpApiParameters.Clear();
                value.OrderBy(x => x.FromType).ThenBy(x => x.Identifier)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiParameters.Add(domainModel.ToDomainModel(httpApi.Store)));
                
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentHeaderRequest> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ConsumesHeaderd"))
            {
                httpApi.HttpApiHeaderRequests.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiHeaderRequests.Add(domainModel.ToDomainModel(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentMediaTypeRequest> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ConsumesMediaTyped"))
            {
                httpApi.HttpApiMediaTypeRequestd.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiMediaTypeRequestd.Add(domainModel.ToDomainModel(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentHeaderResponse> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ProducesHeaderd"))
            {
                httpApi.HttpApiHeaderResponses.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiHeaderResponses.Add(domainModel.ToDomainModel(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentMediaTypeResponse> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ProducesMediaTyped"))
            {
                httpApi.HttpApiMediaTypeResponsed.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiMediaTypeResponsed.Add(domainModel.ToDomainModel(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<ApiStudioComponentResponseStatusCode> value)
        {
            using (Transaction t = httpApi.Store.TransactionManager.BeginTransaction("Saving ApiResponses"))
            {
                httpApi.HttpApiResponseStatusCodes.Clear();
                value.OrderBy(x => x.HttpStatus)
                    .ToList()
                    .ForEach(domainModel => httpApi.HttpApiResponseStatusCodes.Add(domainModel.ToDomainModel(httpApi.Store)));
                t.Commit();
            }
        }
    }
}