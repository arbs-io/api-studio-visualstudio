using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiStudioIO.CodeGen.Utility
{
    public static class HttpApiExtension
    {
        public static string BuildHttpTriggerResponseStatusCodes(this HttpApi httpApi)
        {
            var statusCode = httpApi.ResponseStatusCodes
                .First(p => p.Type == "Success");
            var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);

            return httpStatus != null ? $"HttpStatusCode.{httpStatus}" : $"(HttpStatusCode){statusCode.HttpStatus}";
        }
    }
}
