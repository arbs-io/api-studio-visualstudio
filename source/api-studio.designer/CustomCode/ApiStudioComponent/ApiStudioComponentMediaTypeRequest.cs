namespace ApiStudioIO
{
    using System;
    
    public class ApiStudioComponentMediaTypeRequest : ApiStudioComponentMediaTypeBase
    {
        public static implicit operator ApiStudioComponentMediaTypeRequest(HttpApiMediaType domain)
        {
            var primaryType = (string.IsNullOrEmpty(domain.PrimaryType) || string.IsNullOrEmpty(domain.SubType)) ?
                PrimaryTypeEnum.application : (PrimaryTypeEnum)Enum.Parse(typeof(PrimaryTypeEnum), domain.PrimaryType);

            var apiStudioComponent = new ApiStudioComponentMediaTypeRequest
            {
                PrimaryType = primaryType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }
    }
}