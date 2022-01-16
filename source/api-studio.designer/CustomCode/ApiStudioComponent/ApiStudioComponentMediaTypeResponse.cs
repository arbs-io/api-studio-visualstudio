namespace ApiStudioIO
{
    using System;
    public class ApiStudioComponentMediaTypeResponse : ApiStudioComponentMediaTypeBase
    {
        public static implicit operator ApiStudioComponentMediaTypeResponse(HttpApiMediaType domain)
        {
            var primaryType = (string.IsNullOrEmpty(domain.PrimaryType) || string.IsNullOrEmpty(domain.SubType)) ?
                PrimaryTypeEnum.application : (PrimaryTypeEnum)Enum.Parse(typeof(PrimaryTypeEnum), domain.PrimaryType);

            var apiStudioComponent = new ApiStudioComponentMediaTypeResponse
            {
                PrimaryType = primaryType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }
    }
}