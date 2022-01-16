# api-studio-visualstudio
Visual studio plug-in to create clean RESTful APIs. The plug-in provides a quick and easy ways to scaffold HTTP end-points following RFC and best practice.

## Supported Projects

The initially supported project are:
### Azure Function

Azure Functions is a serverless solution that allows you to write less code, maintain less infrastructure, and save on costs. Instead of worrying about deploying and maintaining servers, the cloud infrastructure provides all the up-to-date resources needed to keep your applications running.

## Designer

A REST API is an application programming interface that conforms to specific architectural constraints, like stateless communication and cacheable data. It is not a protocol or standard. While REST APIs can be accessed through a number of communication protocols, most commonly, they are called over HTTPS,  the designer helps to create clean REST API endpoints.


## References 

### Microsoft.Azure.WebJobs.Extensions.OpenApi.Core
https://github.com/Azure/azure-functions-openapi-extension/blob/main/docs/openapi-core.md

### Visual Studio Updates (visual-studio-2022)
Finally vs2022 removes the million+ dependancies:
- https://docs.microsoft.com/en-us/visualstudio/extensibility/migration/migrated-assemblies?view=vs-2022


## Notes
### Request payload semantics:
https://www.rfc-editor.org/rfc/rfc7231#section-4.3.5
    "request might cause some existing implementations to reject the request"
  - Swagger Editor:	GET DELETE
  - Api Gateway:      GET HEAD OPTIONS (But validates with HEAD OPTIONS)
  - RFC:              GET HEAD DELETE CONNECT 
