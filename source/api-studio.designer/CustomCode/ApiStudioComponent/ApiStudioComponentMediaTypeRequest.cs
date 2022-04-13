namespace ApiStudioIO
{
    using System;

    public class ApiStudioComponentMediaTypeRequest : ApiStudioComponentMediaTypeBase
    {
        public static implicit operator ApiStudioComponentMediaTypeRequest(HttpApiMediaType domain)
        {
            var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
                AllowedDiscreteType.application : (AllowedDiscreteType)Enum.Parse(typeof(AllowedDiscreteType), domain.DiscreteType);

            var apiStudioComponent = new ApiStudioComponentMediaTypeRequest
            {
                DiscreteType = DiscreteType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }
    }
}