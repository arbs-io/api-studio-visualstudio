namespace ApiStudioIO
{
    using ApiStudioIO.Common.Models.Http;
    using ApiStudioIO.Utility.Extensions;
    using System.Collections.Generic;
    using System.Linq;

    public partial class HttpApi
    {
        public override string GetDisplayNameValue()
        {
            return $@"{ImperativeVerb}{GetResourceNameValue()}";
        }

        protected string GetResourceNameValue()
        {
            var resourceName = "";
            if (Resourced.Any())
            {
                resourceName = Resourced.FirstOrDefault()?.Name;
            }

            return resourceName;
        }

        protected virtual string GetHttpVerbValue()
        {
            HttpApi httpApi = this;
            switch (httpApi)
            {
                case HttpApiGet _:
                    return "Get";

                case HttpApiPut _:
                    return "Put";

                case HttpApiPost _:
                    return "Post";

                case HttpApiDelete _:
                    return "Delete";

                case HttpApiPatch _:
                    return "Patch";

                case HttpApiHead _:
                    return "Head";

                case HttpApiOptions _:
                    return "Options";

                case HttpApiTrace _:
                    return "Trace";
            }
            return "Unknown";
        }

        internal int GetSuccessCode()
        {
            var apiResponses = GetResponseStatusCodesValue();
            var successResponse = apiResponses.FirstOrDefault(x => x.Type.Equals("Success"));
            if (null != successResponse)
            {
                return successResponse.HttpStatus;
            }
            else
            {
                return 200; //Default 200 OK
            }
        }

        #region CalculatedProperties

        public virtual string GetAuthorisationRoleValue()
        {
            var resourceContainer = ApiStudio;

            var vendor = resourceContainer.Vendor.ToAlphaNumeric(true);
            var product = resourceContainer.Product.ToAlphaNumeric(true);
            var apiName = resourceContainer.ApiName.ToAlphaNumeric(true);
            var resourceName = GetAuthorisationRoleResourceName().ToAlphaNumeric(true);
            var actionName = GetAuthorisationRoleActionName().ToAlphaNumeric(true);
            return $@"{vendor}.{product}.{apiName}.{resourceName}.{actionName}";
        }

        private string GetAuthorisationRoleResourceName()
        {
            string FuncGetRootName(Resource resource)
            {
                if (resource != null)
                {
                    switch (resource)
                    {
                        case ResourceAttribute _:
                        case ResourceInstance _:
                            var childResource = resource.SourceResource.FirstOrDefault();
                            if (childResource == null)
                            {
                                return resource.Name;
                            }

                            return FuncGetRootName(childResource);

                        case ResourceCollection _:
                        case ResourceAction _:
                            return resource.Name;
                    }
                }

                return "";
            }

            //Get the root collect resource name (if there is one)
            var sourceResource = Resourced.FirstOrDefault();
            return FuncGetRootName(sourceResource);
        }

        internal virtual string GetAuthorisationRoleActionName()
        {
            var resource = Resourced.FirstOrDefault();

            if (resource is ResourceAction)
            {
                return ImperativeVerb;
            }
            else
            {
                HttpApi httpApi = this;
                switch (httpApi)
                {
                    case HttpApiGet _:
                        return "Read";

                    case HttpApiPut _:
                    case HttpApiPost _:
                    case HttpApiDelete _:
                        return "Write";
                }
            }
            return "Unknown";
        }

        #endregion CalculatedProperties


        #region CalculatedPropertiesApiStudioComponent

        internal virtual List<HttpResourceParameter> GetRequestParametersValue()
        {
            var managedList = new List<HttpResourceParameter>();
            HttpApiParameters.OrderBy(x => x.FromType).ThenBy(x => x.Identifier)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceParameter()));
            return managedList;
        }

        internal List<HttpResourceHeaderRequest> GetRequestHeadersValue()
        {
            var managedList = new List<HttpResourceHeaderRequest>();
            HttpApiHeaderRequests.OrderBy(x => x.Name)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceHeaderRequest()));
            return managedList;
        }

        internal List<HttpResourceMediaTypeRequest> GetRequestMediaTypesValue()
        {
            var managedList = new List<HttpResourceMediaTypeRequest>();
            HttpApiMediaTypeRequestd.OrderBy(x => x.DisplayName)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceMediaTypeRequest()));
            return managedList;
        }

        internal List<HttpResourceHeaderResponse> GetResponseHeadersValue()
        {
            var managedList = new List<HttpResourceHeaderResponse>();
            HttpApiHeaderResponses.OrderBy(x => x.Name)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceHeaderResponse()));
            return managedList;
        }

        internal List<HttpResourceMediaTypeResponse> GetResponseMediaTypesValue()
        {
            var managedList = new List<HttpResourceMediaTypeResponse>();
            HttpApiMediaTypeResponsed.OrderBy(x => x.DisplayName)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceMediaTypeResponse()));
            return managedList;
        }

        internal virtual List<HttpResourceResponseStatusCode> GetResponseStatusCodesValue()
        {
            var managedList = new List<HttpResourceResponseStatusCode>();
            HttpApiResponseStatusCodes.OrderBy(x => x.HttpStatus)
                .ToList()
                .ForEach(domainModel => managedList.Add(domainModel.ToHttpResourceResponseStatusCode()));
            return managedList;
        }

        #endregion //CalculatedPropertiesApiStudioComponent
    }
}