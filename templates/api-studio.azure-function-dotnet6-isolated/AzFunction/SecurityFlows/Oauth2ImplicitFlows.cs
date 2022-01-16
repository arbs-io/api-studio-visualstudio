using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.OpenApi.Models;
using System;

namespace SecurityFlows
{
    public class ApiStudioAuthentication : OpenApiOAuthSecurityFlows
    {
        public ApiStudioAuthentication()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("http://api-studio.io/oauth2/token"),
                Scopes = { { "write:resource", "modify a given resource in your api" }, { "read:resource", "read a given resource in your api" } }
            };
        }
    }
}
