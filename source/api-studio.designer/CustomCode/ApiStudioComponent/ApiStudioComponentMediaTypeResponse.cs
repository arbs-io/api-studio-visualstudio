namespace ApiStudioIO
{
    using System;
    public class ApiStudioComponentMediaTypeResponse : ApiStudioComponentMediaTypeBase
    {
        // public static implicit operator ApiStudioComponentMediaTypeResponse(HttpApiMediaType domain)
        // {
        //     var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
        //         AllowedDiscreteType.application : (AllowedDiscreteType)Enum.Parse(typeof(AllowedDiscreteType), domain.DiscreteType);

        //     var apiStudioComponent = new ApiStudioComponentMediaTypeResponse
        //     {
        //         DiscreteType = DiscreteType,
        //         SubType = domain.SubType
        //     };
        //     return apiStudioComponent;
        // }
    }
}