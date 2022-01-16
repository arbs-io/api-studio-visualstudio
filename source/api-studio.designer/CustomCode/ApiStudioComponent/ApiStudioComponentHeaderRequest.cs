﻿namespace ApiStudioIO
{
    public class ApiStudioComponentHeaderRequest : ApiStudioComponentHeaderBase
    {
        public static implicit operator ApiStudioComponentHeaderRequest(HttpApiHeaderRequest domain)
        {
            var apiStudioComponent = new ApiStudioComponentHeaderRequest
            {
                Name = domain.Name,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                AllowEmptyValue = domain.AllowEmptyValue,
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }
    }
}