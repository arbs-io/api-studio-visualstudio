<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="6901cf7d-afbd-4a0a-a1bc-da1fe25f0e73" Description="Azure Function (ApiStudio) design component for visual studio" Name="ApiStudioIO" DisplayName="Azure Function (ApiStudio)" HelpKeyword="Azure Function (ApiStudio)" Namespace="ApiStudioIO" ProductName="Azure Function (ApiStudio)" PackageGuid="4a6ef9c8-3428-4bd6-9b17-c57b4285bbd8" PackageNamespace="ApiStudioIO" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="8aba1eb0-dc24-44f9-8751-d236150d7e4e" Description="Enterprise Application Diagram for component interface definition" Name="ApiStudio" DisplayName="Api Studio" Namespace="ApiStudioIO" HasCustomConstructor="true">
      <Properties>
        <DomainProperty Id="bf23063f-bb0a-44f8-8554-c4a196b452a0" Description="The variable naming convention to be used.\n- Camel Case &quot;propertyName&quot;\n- Pascel Case &quot;PropertyName&quot;\n- Snake Case &quot;property_name&quot;" Name="CodeGenerationVariableCaseType" DisplayName="Variable Case" DefaultValue="PascalCase" Category="Code Generation">
          <Type>
            <DomainEnumerationMoniker Name="CodeGenerationVariableCaseTypes" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="90933f55-837e-4634-bb05-1087119efb2f" Description="ApiStudio Identifier unique to this schema" Name="Identifier" DisplayName="Identifier" DefaultValue="00000000-0000-0000-0000-000000000000" Category="ApiStudio Metadata" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="712e1357-a4a1-406b-af9e-ce07d7b99a05" Description="The name of the organisation providing the API specification. This will form part of the contract title" Name="Vendor" DisplayName="Vendor" DefaultValue="ApiStudio" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0945c325-69d8-4687-9ba0-92283b53b275" Description="The name of the product the api is part a member. This will form part of the contract title" Name="Product" DisplayName="Product" DefaultValue="Prototype" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="44a7be5c-2683-4c72-a096-41aa3d38e497" Description="The name of the API. Normally based on the subdomain and/or feature for the API contract. This will form part of the contract title" Name="ApiName" DisplayName="Api Name" DefaultValue="Api Name" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f55db371-3424-4fca-b228-46d6be5c73d4" Description="The version of the API contract. This will form part of the contract title" Name="Version" DisplayName="Version" DefaultValue="1.0.0" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bbbcf9e9-5136-40cd-a572-38980db0610a" Description="The title of the API. For example Reference Group Data Warehouse." Name="Title" DisplayName="Title" DefaultValue="" Kind="Calculated" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d326904b-49e2-4afe-b5b2-bc237d674fcb" Description="The value is used as the description for the resource tree and will form part of the OpenAPI specification" Name="Description" DisplayName="Description" DefaultValue="The API description should be based provide information about the features and capabilities of the API. Typical information would include **business capability** and the area of focus.\r\n\r\nFor example:\r\nThis API is part of the **core-banking** business capability and provides features for **domestic** and **international** payment processing.\r\n\r\nRequest access to this API via\r\n* **Delegated (RBAC): GBL ROL IT [DEV/UAT/PRD] ApiStudio MyAccess Role**\r\n* **Application: Please contact: ApiStudio@ApiStudio.com for more information**" Category="Specification">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(System.ComponentModel.Design.MultilineStringEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="fae6e846-4cfe-42bc-8ccb-83e949c427c9" Description="The url which provides additional information about the solution or team" Name="ContactUrl" DisplayName="Contact Url" DefaultValue="http://api.api-studio.io/" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="160e9f7e-0d9a-47ae-af2c-f042a1d67f68" Description="The name of the solution provider e.g. team, shared mail, etc.." Name="ContactName" DisplayName="Contact Name" DefaultValue="Azure Function (ApiStudio)" Category="Specification">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="cdca44e3-36ba-4620-baf8-b628095159ef" Description="The audience category flags if the consumers are Private (Internal), Partner (Trusted/VPN), Public (Public Domain)" Name="Audience" DisplayName="Audience" DefaultValue="Private" Category="Specification">
          <Type>
            <DomainEnumerationMoniker Name="HttpApiAudienceTypes" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a6280a94-1043-4440-a034-8ae87bff0b42" Description="Determine if the first resource in the resource tree (uri) is used as the root uri e.g. &quot;/&quot; or &quot;/accounts&quot;" Name="InitialResourceIsRoot" DisplayName="Initial Resource is Root" Category="Design">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6f3e9977-0f9f-433d-b248-3ad919a618ab" Description="The request could not be authenticated and\or the request was authenticated but is not authorised to access the resource." Name="ResponseCodesSecurity" DisplayName="(401) Authentication" DefaultValue="true" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="51d3518d-f44b-48f7-bf74-b013feb90f8c" Description="The server cannot process the request (such as malformed request syntax, size too large, invalid request message framing, or deceptive request routing, invalid values in the request)" Name="ResponseCodesBadRequest" DisplayName="(400) Bad Request" DefaultValue="true" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e89d4c47-0299-4d39-8f45-a0e00248d69a" Description="The resource was not found." Name="ResponseCodesNotFound" DisplayName="(404) Not Found" DefaultValue="true" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="387e8c92-343a-4e7e-9330-470e8aa29509" Description="Method not allowed on resource. The response may include an Allow header containing a list of valid methods for the resource." Name="ResponseCodesNotAllowed" DisplayName="(405) Not Allowed" DefaultValue="false" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1a6e93f3-1787-4bea-904d-c11b6dc2db06" Description="This status code indicates that the server received the request but it did not fulfil the requirements of the back end. An example is a mandatory field was not provided in the payload." Name="ResponseCodesUnprocessable" DisplayName="(422) Unprocessable" DefaultValue="true" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f4cf2494-e972-4cc8-8f5a-1d22088acb9d" Description="This status code indicates that the server refuses to accept the request because the content type specified in the request is not supported by the server" Name="ResponseCodesUnsupportedMediaType" DisplayName="(415) Unsupported MediaType" DefaultValue="true" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7510774d-60ea-4ce9-8e04-2d90e229bfff" Description="An internal server error. The response body may contain error messages." Name="ResponseCodesServerError" DisplayName="(500) Server Error" DefaultValue="false" Category="Response Codes">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Resource" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ApiStudioHasResourced.Resourced</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Api" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ApiStudioHasApis.Apis</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DataModel" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ApiStudioHasDataModeled.DataModeled</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="8f3da64b-6647-4840-b424-db6023a735be" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="Resource" DisplayName="Resource" InheritanceModifier="Abstract" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="03af69d1-f9d2-49c1-93bf-fa28af949404" Description="The name of a given resource. This name form part of the uri structure." Name="Name" DisplayName="Name" DefaultValue="" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="db19658e-1079-4252-a6f9-f730dd5572a8" Description="Calculated field build from the resource relationship path" Name="HttpApiUri" DisplayName="URI" Kind="Calculated" Category="RESTful API">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f3e51359-b5a8-464c-958d-ab9ac499294f" Description="A document resource is a singular concept that is akin to an object instance or database record. In REST, you can view it as a single resource inside resource collection. A document’s state representation typically includes both fields with values and links to other related resources." Name="ResourceInstance" DisplayName="Document" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="Resource" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="e93cc319-2b6b-4c3c-8e82-e94cdb5ff7b7" Description="A unique, immutable identifier that identifies a resource" Name="InstanceIdentity" DisplayName="Identifier" DefaultValue="InstanceCode" Category="Instance Information">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a07297f6-9a34-420e-93a4-d295bc4184d3" Description="The description associated to the unique code used to help 3rd parties identify the value" Name="InstanceDescription" DisplayName="Description" DefaultValue="A unique, immutable identifier that identifies a resource" Category="Instance Information">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="614d1655-e0e5-48a8-b052-1209e2066a67" Description="The data type for the unique code parameter" Name="InstanceDataType" DisplayName="DataType" DefaultValue="Guid" Category="Instance Information">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="3e516750-e711-4e8c-86e2-711c232b8e15" Description="A collection resource is a server-managed directory of resources. Clients may propose new resources to be added to a collection. However, it is up to the collection to choose to create a new resource, or not. A collection resource chooses what it wants to contain and also decides the URIs of each contained resource." Name="ResourceCollection" DisplayName="Collection" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="Resource" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="8ad628a5-9969-4e5e-b567-726bc49bd2ce" Description="Use limit and offset parameters to paginate records in a GET request. Note that offset i returns record i+1 as the first record in the set (for example, offset = 0 returns record 1 as the first record in the set, offset =10 returns record 11 as the first record in the set, and so forth)." Name="UsePagination" DisplayName="Use Pagination" DefaultValue="False" Category="Large Result Sets">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d3d71817-0541-45d9-8f07-61e059c7e129" Description="Sorting is determined through the use of the ‘sort’ query string parameter. The value of this parameter is a comma-separated list of sort keys. Sort directions can optionally be appended to each sort key, separated by the ‘:’ character. The supported sort directions are either ‘asc’ for ascending or ‘desc’ for descending. The caller may (but is not required to) specify a sort direction for each key. If a sort direction is not specified for a key, then a default is set by the server" Name="UseSorting" DisplayName="Use Sorting" DefaultValue="False" Category="Large Result Sets">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f3c5c6fd-b7e3-489c-b50c-f59bc5ac90f0" Description="Description for ApiStudioIO.HttpApi" Name="HttpApi" DisplayName="Http Api" InheritanceModifier="Abstract" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="Api" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="f01c0ff4-98f0-47f3-a2c3-1665d21b6274" Description="The description which will be published for this Rest Resource. The description should be helpful for 3rd parties to understand the purpose of the operation" Name="Description" DisplayName="Description" DefaultValue="This is a description of the rest verbs actions" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1c2f46ab-1966-4f03-b6e3-d4a116b9532a" Description="Which parties are able to use this resoure" Name="AuthorisationRole" DisplayName="Authorisation Role" DefaultValue="Product.Subject.Action" Kind="Calculated" Category="Security">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7e555ff3-fb88-4735-8273-bf110d26b007" Description="The HTTP verb which is used by this Rest Resource" Name="HttpVerb" DisplayName="Http Verb" DefaultValue="NotSet" Kind="Calculated" Category="Hidden" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0b0bd3d5-7c95-4964-b544-b90cd4af96f8" Description="API parameter collection for the RESTFul resource" Name="RequestParameters" DisplayName="Parameters" Kind="Calculated" Category="Request">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentParameter&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentParameter&gt;" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="525d924f-4072-47a0-b74c-b150fd8a11a2" Description="Valid HTTP status codes which provide from the HTTP Api" Name="ResponseStatusCodes" DisplayName="Status Codes" Kind="Calculated" Category="Response">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentResponseStatusCode&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentResponseStatusCode&gt;" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="cae73e7a-8e11-444f-be69-b4a55d76eab6" Description="API output media type collection for the HTTP Api" Name="ResponseMediaTypes" DisplayName="Media Types" Kind="Calculated" Category="Response">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentMediaTypeResponse&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentMediaTypeResponse&gt;" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="54f44c42-8781-4bbc-85bc-a9cd0528f456" Description="API input media type collection for the HTTP Api" Name="RequestMediaTypes" DisplayName="Media Types" Kind="Calculated" Category="Request">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentMediaTypeRequest&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentMediaTypeRequest&gt;" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ad456fa9-3544-4337-b88f-ddaa34d69ddd" Description="API headers for the outbound HTTP Api" Name="ResponseHeaders" DisplayName="Headers" Kind="Calculated" Category="Response">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentHeaderResponse&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentHeaderResponse&gt;" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="838e029b-464a-4a1b-9109-81762175271a" Description="API headers for the inbound HTTP Api" Name="RequestHeaders" DisplayName="Headers" Kind="Calculated" Category="Request">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(ApiStudioComponentUITypeEditor&lt;HttpApi, ApiStudioComponentHeaderRequest&gt;)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System.Collections.Generic/List&lt;ApiStudioComponentHeaderRequest&gt;" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiParameter" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasParameters.HttpApiParameters</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiResponseStatusCode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasResponseStatusCodes.HttpApiResponseStatusCodes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiMediaTypeResponse" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasMediaTypeResponse.HttpApiMediaTypeResponsed</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiMediaTypeRequest" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasMediaTypeRequest.HttpApiMediaTypeRequestd</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiHeaderRequest" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasHeaderRequest.HttpApiHeaderRequests</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="HttpApiHeaderResponse" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>HttpApiHasHeaderResponse.HttpApiHeaderResponses</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="3f6ef04d-da19-45f5-9b78-6e5115067400" Description="An action resource models a procedural concept. Action resources are like executable functions, with parameters and return values; inputs and outputs." Name="ResourceAction" DisplayName="Action" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="Resource" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="20473669-b673-4c49-9ef4-e90e0f717735" Description="The GET method requests a representation of the specified resource. Requests using GET should only retrieve data." Name="HttpApiGet" DisplayName="Http::GET" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="37bb2c14-2747-46f6-9ff6-cd9d74b24f0b" Description="The PUT method replaces all current representations of the target resource with the request payload." Name="HttpApiPut" DisplayName="Http::PUT" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="023524ae-d4d8-45dd-87d5-04a61f53602f" Description="The POST method submits an entity to the specified resource, often causing a change in state or side effects on the server." Name="HttpApiPost" DisplayName="Http::POST" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="ea41c46b-0e0e-4763-8380-fa5456b99262" Description="The DELETE method deletes the specified resource." Name="HttpApiDelete" DisplayName="Http::DELETE" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="79a1ace0-4eb9-4e12-978c-499045ad8edb" Description="Data entities to be used as definition within OpenAPI specifciation" Name="DataModel" DisplayName="Data Model" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="6fffa5cc-bf10-406f-a041-2d7a9b10f523" Description="The name of the data model. This should align with the GDM name when possible." Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ee416165-3a63-4c6c-b8c4-0ba1117fcc1d" Description="The description of the data model. This should align with the GDM name when possible." Name="Description" DisplayName="Description" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="67e3206a-7393-4ecb-ad34-28fb59ebbd47" Description="An attribute resource is a procedural concept. Attributes allow the specific resource for a given attribute of a parent resource. Typically Getter and Putter functionality." Name="ResourceAttribute" DisplayName="Attribute" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="Resource" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="76d61bcc-3e15-41fb-916c-4815e0c511cc" Description="Description for ApiStudioIO.HttpApiMediaTypeResponse" Name="HttpApiMediaTypeResponse" DisplayName="Response Media Type" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApiMediaType" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="429c9ce3-911c-44cc-9b3f-574ec36b8bed" Description="Description for ApiStudioIO.HttpApiMediaTypeRequest" Name="HttpApiMediaTypeRequest" DisplayName="Request Media Type" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApiMediaType" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="b4fba5c1-00f0-4d9b-92c1-24a952a6313a" Description="Description for ApiStudioIO.HttpApiParameter" Name="HttpApiParameter" DisplayName="Parameter" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="382606f2-0aaf-426f-b7e2-de2442718c21" Description="The identifier (variable name) of the given parameter" Name="Identifier" DisplayName="Identifier " DefaultValue="ParameterName" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="05df3aa8-91f5-4c54-bea7-6cb175dad111" Description="Description for ApiStudioIO.HttpApiParameter.Data Type" Name="DataType" DisplayName="Data Type" DefaultValue="string" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e0cf4e69-77dc-43fb-a043-0c55d2897fcf" Description="Description for ApiStudioIO.HttpApiParameter.Description" Name="Description" DisplayName="Description" DefaultValue="This is a description about the API parameter" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d9cec306-8d1c-4ed8-bbf4-899186997e8f" Description="Description for ApiStudioIO.HttpApiParameter.Is Required" Name="IsRequired" DisplayName="Is Required" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f0853a14-3d29-4d60-b8ec-f39f1f068920" Description="This property determines where the parameter comes from e.g. Header, Body, Query, ..." Name="FromType" DisplayName="From Type" DefaultValue="Query" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="HttpApiParameterTypes" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="af415229-6fd9-4fe2-a718-9015d5a01270" Description="Description for ApiStudioIO.HttpApiParameter.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" DefaultValue="false" Category="ApiStudio Metadata" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="384030a6-20b1-4519-935b-ebe64aa62274" Description="This property is used for deplay within the designer" Name="DisplayName" DisplayName="Display Name" Kind="Calculated" Category="Hidden" IsElementName="true" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="e0cbd9e4-dc1c-4b20-aaa5-4a58c1a2a101" Description="Description for ApiStudioIO.HttpApiResponseStatusCode" Name="HttpApiResponseStatusCode" DisplayName="Response Status Code" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="dabe33b8-515f-4111-ab71-9491b8eac0be" Description="This property is used for deplay within the designer" Name="DisplayName" DisplayName="Display Name" Kind="Calculated" Category="Hidden" IsElementName="true" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6a2e0d39-707c-4fba-9266-d89caba6ffa5" Description="Description for ApiStudioIO.HttpApiResponseStatusCode.Http Status" Name="HttpStatus" DisplayName="Http Status" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Int32" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="10b6fa85-bc59-4512-9b41-4ed0eae29ff1" Description="Description for ApiStudioIO.HttpApiResponseStatusCode.Type" Name="Type" DisplayName="Type" Kind="Calculated" Category="RFC 7231">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2558ae2c-e05d-48b2-b497-e94e9a744d58" Description="Description for ApiStudioIO.HttpApiResponseStatusCode.Description" Name="Description" DisplayName="Description" Kind="Calculated" Category="RFC 7231">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="685eb132-73bc-4608-b452-877750b9939d" Description="Description for ApiStudioIO.HttpApiResponseStatusCode.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" Category="ApiStudio Metadata" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="5cddab78-4333-4cc4-b75b-2b01f31d3a9e" Description="Description for ApiStudioIO.Api" Name="Api" DisplayName="Api" InheritanceModifier="Abstract" Namespace="ApiStudioIO" HasCustomConstructor="true">
      <Properties>
        <DomainProperty Id="4908bf7c-751d-41ef-977e-be510f573f37" Description="Description for ApiStudioIO.Api.Display Name" Name="DisplayName" DisplayName="Display Name" Kind="Calculated" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b975b930-6bd5-47f8-aa19-1b5f1a650a2c" Description="Names (verbs) in the imperative mood plus and may include the aggregate type, for example ConfirmOrder" Name="ImperativeVerb" DisplayName="Imperative Verb" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="fc1dc367-a453-496f-8778-064cad05e3a5" Description="ApiStudio Identifier unique to this schema" Name="Identifier" DisplayName="Identifier" DefaultValue="00000000-0000-0000-0000-000000000000" Category="ApiStudio Metadata" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="b8e61b93-76c4-49b2-b920-22d396c27d3e" Description="Description for ApiStudioIO.HttpApiMediaType" Name="HttpApiMediaType" DisplayName="Http Api Media Type" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="f2689fd5-bd29-4fae-aec4-2560de08ed22" Description="This property is used for deplay within the designer" Name="DisplayName" DisplayName="Display Name" Kind="Calculated" Category="Hidden" IsElementName="true" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="518771c0-b2e4-415c-98e1-f5b00b3d6696" Description="Description for ApiStudioIO.HttpApiMediaType.Primary Type" Name="PrimaryType" DisplayName="Primary Type" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9e6f9da7-f54d-4a7e-a653-b109507f6162" Description="Description for ApiStudioIO.HttpApiMediaType.Sub Type" Name="SubType" DisplayName="Sub Type" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="95d800cc-950b-46a0-bc87-dbb012bd81d9" Description="Description for ApiStudioIO.HttpApiHeader" Name="HttpApiHeader" DisplayName="Http Api Header" Namespace="ApiStudioIO">
      <Properties>
        <DomainProperty Id="08d51db3-4ab0-4ff9-a44a-233d6f9e9a1e" Description="Description for ApiStudioIO.HttpApiHeader.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1c0871b0-c0fe-4c81-a3e4-d1c9d78f7aac" Description="Description for ApiStudioIO.HttpApiHeader.Description" Name="Description" DisplayName="Description" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8df27ba2-6f45-4f6b-a27f-d32727feccf3" Description="Description for ApiStudioIO.HttpApiHeader.Is Required" Name="IsRequired" DisplayName="Is Required" DefaultValue="false" Category="Configuration">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6a60f8a8-1e8b-406b-942e-084e729df156" Description="Description for ApiStudioIO.HttpApiHeader.Allow Empty Value" Name="AllowEmptyValue" DisplayName="Allow Empty Value" DefaultValue="true" Category="Configuration">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8b2e9d2b-6a06-4f6c-8948-75abb93d81ec" Description="Description for ApiStudioIO.HttpApiHeader.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" Category="ApiStudio Metadata" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="fb7f3eaf-66bf-4cd2-8197-0eface693800" Description="Description for ApiStudioIO.HttpApiHeaderRequest" Name="HttpApiHeaderRequest" DisplayName="Request Header" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApiHeader" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="f9571f07-21e2-47b5-9490-2c8ad1cc2e1d" Description="Description for ApiStudioIO.HttpApiHeaderResponse" Name="HttpApiHeaderResponse" DisplayName="Response Header" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApiHeader" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="a835d551-6b87-4524-b693-73960cc48112" Description="Which type of response should the header be included with." Name="IncludeOn" DisplayName="Include On" DefaultValue="OnSuccess" Category="Scope">
          <Type>
            <DomainEnumerationMoniker Name="HttpApiHeaderResponseOnTypes" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="5267abe5-30c1-4358-9501-38bb12f095e8" Description="The PATCH method applies partial modifications to a resource." Name="HttpApiPatch" DisplayName="Http::PATCH" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="8ba16422-637b-4fca-9615-3cd34954c929" Description="The HEAD method asks for a response identical to a GET request, but without the response body." Name="HttpApiHead" DisplayName="Http::HEAD" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="752e81b2-4142-4109-a785-92bb44a69250" Description="The OPTIONS method describes the communication options for the target resource." Name="HttpApiOptions" DisplayName="Http::OPTIONS" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="d9341680-ce85-4083-ad0f-e15d44d3d9b9" Description="The TRACE method performs a message loop-back test along the path to the target resource." Name="HttpApiTrace" DisplayName="Http::TRACE" Namespace="ApiStudioIO">
      <BaseClass>
        <DomainClassMoniker Name="HttpApi" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="d11ce085-2df6-463c-bf92-9f80ee1c5400" Description="Description for ApiStudioIO.ResourceReferencesResources" Name="ResourceReferencesResources" DisplayName="Resource References Resources" Namespace="ApiStudioIO">
      <Source>
        <DomainRole Id="f52d4c33-0f0b-459b-9272-153e2e284491" Description="Description for ApiStudioIO.ResourceReferencesResources.SourceResource" Name="SourceResource" DisplayName="Source Resource" PropertyName="Resources" PropertyDisplayName="Resources">
          <RolePlayer>
            <DomainClassMoniker Name="Resource" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a7936b77-5348-49e3-8709-3267393f423c" Description="Description for ApiStudioIO.ResourceReferencesResources.TargetResource" Name="TargetResource" DisplayName="Target Resource" PropertyName="SourceResource" PropertyDisplayName="Source Resource">
          <RolePlayer>
            <DomainClassMoniker Name="Resource" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3ee75ed1-a30e-4725-bb2d-5047960df433" Description="Description for ApiStudioIO.HttpApiSuccessRequestModel" Name="HttpApiSuccessRequestModel" DisplayName="Http Api Success Request Model" Namespace="ApiStudioIO">
      <Source>
        <DomainRole Id="4dc78a61-cfb1-448f-a8f2-1777d462a697" Description="Description for ApiStudioIO.HttpApiSuccessRequestModel.DataModel" Name="DataModel" DisplayName="Data Model" PropertyName="HttpApis" PropertyDisplayName="Http APIs">
          <RolePlayer>
            <DomainClassMoniker Name="DataModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9c8d4e57-e887-4e62-960b-45a5915ff614" Description="Description for ApiStudioIO.HttpApiSuccessRequestModel.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="SourceDataModel" PropertyDisplayName="Source Data Model">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="ba3ce080-e2ec-4347-97dc-69d3981e5aeb" Description="Description for ApiStudioIO.HttpApiSuccessResponseModel" Name="HttpApiSuccessResponseModel" DisplayName="Http Api Success Response Model" Namespace="ApiStudioIO">
      <Source>
        <DomainRole Id="2fc549d9-b391-4db7-a9fe-ff724e0dd64a" Description="Description for ApiStudioIO.HttpApiSuccessResponseModel.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="DataModels" PropertyDisplayName="Data Models">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="dd37e82a-905b-499c-8ddb-ba9012f3cd1f" Description="Description for ApiStudioIO.HttpApiSuccessResponseModel.DataModel" Name="DataModel" DisplayName="Data Model" PropertyName="SourceHttpApi" PropertyDisplayName="Source Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="DataModel" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="fa7d2f8c-1e77-4a66-9912-d8204ac208f3" Description="Description for ApiStudioIO.HttpApiHasParameters" Name="HttpApiHasParameters" DisplayName="Http Api Has Http Api Parameters" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="5f9c4b56-75da-4390-bf67-2ab359da36ff" Description="Description for ApiStudioIO.HttpApiHasParameters.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiParameters" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Parameters">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4e1f0e00-e8d5-4f7d-8262-223451e94393" Description="Description for ApiStudioIO.HttpApiHasParameters.HttpApiParameter" Name="HttpApiParameter" DisplayName="Http Api Parameter" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiParameter" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8a692ff9-dcc7-414f-9ac9-5265fe4ec202" Description="Description for ApiStudioIO.HttpApiHasResponseStatusCodes" Name="HttpApiHasResponseStatusCodes" DisplayName="Http Api Has Http Api Responses" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="2fe627a6-9b2e-4742-8bd1-94f2138e07f8" Description="Description for ApiStudioIO.HttpApiHasResponseStatusCodes.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiResponseStatusCodes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Responses">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5c236289-865f-4407-8d55-474618ec4ac2" Description="Description for ApiStudioIO.HttpApiHasResponseStatusCodes.HttpApiResponseStatusCode" Name="HttpApiResponseStatusCode" DisplayName="Http Api Response" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiResponseStatusCode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="a9ffebca-8f26-4d5e-a3ea-d1bd234ff860" Description="Description for ApiStudioIO.HttpApiHasMediaTypeResponse" Name="HttpApiHasMediaTypeResponse" DisplayName="Http Api Has Http Api Media Type Produced" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="d3665080-f49b-45dd-af8c-0afa9bcf219b" Description="Description for ApiStudioIO.HttpApiHasMediaTypeResponse.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiMediaTypeResponsed" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Media Type Produced">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="66478424-605c-45dd-b8da-cc748d5a8ff8" Description="Description for ApiStudioIO.HttpApiHasMediaTypeResponse.HttpApiMediaTypeResponse" Name="HttpApiMediaTypeResponse" DisplayName="Http Api Media Type Produce" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiMediaTypeResponse" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d744ca70-d39c-4204-9fda-8281a96d13e2" Description="Description for ApiStudioIO.HttpApiHasMediaTypeRequest" Name="HttpApiHasMediaTypeRequest" DisplayName="Http Api Has Http Api Media Type Consumed" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="6eae1b8f-ab94-4b52-85f9-4a4a4842a9fe" Description="Description for ApiStudioIO.HttpApiHasMediaTypeRequest.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiMediaTypeRequestd" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Media Type Consumed">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="38e764b1-d576-4e3c-9db9-e24726a3fc35" Description="Description for ApiStudioIO.HttpApiHasMediaTypeRequest.HttpApiMediaTypeRequest" Name="HttpApiMediaTypeRequest" DisplayName="Http Api Media Type Consume" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiMediaTypeRequest" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="97a03524-ddf1-462d-8aa1-3b991a119608" Description="Description for ApiStudioIO.ResourceReferencesApis" Name="ResourceReferencesApis" DisplayName="Resource References Apis" Namespace="ApiStudioIO">
      <Source>
        <DomainRole Id="78f75c24-4b0d-40cc-a1bd-bb9d1d31ca85" Description="Description for ApiStudioIO.ResourceReferencesApis.Resource" Name="Resource" DisplayName="Resource" PropertyName="Apis" PropertyDisplayName="Apis">
          <RolePlayer>
            <DomainClassMoniker Name="Resource" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c23208d4-9cbf-4c86-bf4c-896d2fb153d0" Description="Description for ApiStudioIO.ResourceReferencesApis.Api" Name="Api" DisplayName="Api" PropertyName="Resourced" PropertyDisplayName="Resourced">
          <RolePlayer>
            <DomainClassMoniker Name="Api" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e4e82758-72de-402c-a610-fe6df8a9ac1d" Description="Description for ApiStudioIO.HttpApiHasHeaderRequest" Name="HttpApiHasHeaderRequest" DisplayName="Http Api Has Http Api Request Headers" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="201c414c-b3c9-49cc-81ad-64bd31a95281" Description="Description for ApiStudioIO.HttpApiHasHeaderRequest.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiHeaderRequests" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Request Headers">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a53f79d2-b840-44f0-8e9f-ee8f4af63637" Description="Description for ApiStudioIO.HttpApiHasHeaderRequest.HttpApiHeaderRequest" Name="HttpApiHeaderRequest" DisplayName="Http Api Request Header" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiHeaderRequest" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="def037d5-1495-4547-8dd6-cb91b92abfa3" Description="Description for ApiStudioIO.HttpApiHasHeaderResponse" Name="HttpApiHasHeaderResponse" DisplayName="Http Api Has Http Api Response Headers" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="3991413f-0c9f-47b0-8818-9e773b7f246b" Description="Description for ApiStudioIO.HttpApiHasHeaderResponse.HttpApi" Name="HttpApi" DisplayName="Http Api" PropertyName="HttpApiHeaderResponses" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Http Api Response Headers">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApi" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="d36478e4-8466-4f46-ad74-3cd1dc1a0f35" Description="Description for ApiStudioIO.HttpApiHasHeaderResponse.HttpApiHeaderResponse" Name="HttpApiHeaderResponse" DisplayName="Http Api Response Header" PropertyName="HttpApi" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Http Api">
          <RolePlayer>
            <DomainClassMoniker Name="HttpApiHeaderResponse" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="ee5b1dbe-25e0-460f-be24-d2c234b79fc1" Description="Description for ApiStudioIO.ApiStudioHasResourced" Name="ApiStudioHasResourced" DisplayName="Api Studio Has Resourced" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="0837992d-25ad-49e3-9fec-8d5da6c13191" Description="Description for ApiStudioIO.ApiStudioHasResourced.ApiStudio" Name="ApiStudio" DisplayName="Api Studio" PropertyName="Resourced" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Resourced">
          <RolePlayer>
            <DomainClassMoniker Name="ApiStudio" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2a98130e-db8a-42c6-b178-12484ee3f8d5" Description="Description for ApiStudioIO.ApiStudioHasResourced.Resource" Name="Resource" DisplayName="Resource" PropertyName="ApiStudio" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Api Studio">
          <RolePlayer>
            <DomainClassMoniker Name="Resource" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="eded6647-b5c9-4f5c-ba0f-48f5a54e7d64" Description="Description for ApiStudioIO.ApiStudioHasApis" Name="ApiStudioHasApis" DisplayName="Api Studio Has Apis" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="794b38ee-0862-4a1f-b73a-c05ffc77bf6d" Description="Description for ApiStudioIO.ApiStudioHasApis.ApiStudio" Name="ApiStudio" DisplayName="Api Studio" PropertyName="Apis" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Apis">
          <RolePlayer>
            <DomainClassMoniker Name="ApiStudio" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4c61d465-dc4c-4b48-bca0-bc95c9ba30e9" Description="Description for ApiStudioIO.ApiStudioHasApis.Api" Name="Api" DisplayName="Api" PropertyName="ApiStudio" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Api Studio">
          <RolePlayer>
            <DomainClassMoniker Name="Api" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="cefe5767-c48f-4781-a0ad-320070d4d2af" Description="Description for ApiStudioIO.ApiStudioHasDataModeled" Name="ApiStudioHasDataModeled" DisplayName="Api Studio Has Models" Namespace="ApiStudioIO" IsEmbedding="true">
      <Source>
        <DomainRole Id="8816db77-5b8e-405b-8a02-3a4c7f480fd5" Description="Description for ApiStudioIO.ApiStudioHasDataModeled.ApiStudio" Name="ApiStudio" DisplayName="Api Studio" PropertyName="DataModeled" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Models">
          <RolePlayer>
            <DomainClassMoniker Name="ApiStudio" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a8765d18-f408-4aff-938b-8563e8f21a4f" Description="Description for ApiStudioIO.ApiStudioHasDataModeled.DataModel" Name="DataModel" DisplayName="Data Model" PropertyName="ApiStudio" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Api Studio">
          <RolePlayer>
            <DomainClassMoniker Name="DataModel" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <DomainEnumeration Name="HttpApiParameterTypes" Namespace="ApiStudioIO" Description="Description for ApiStudioIO.HttpApiParameterTypes">
      <Literals>
        <EnumerationLiteral Description="Parameters is taken from Body" Name="Body" Value="" />
        <EnumerationLiteral Description="Parameters is taken from Query" Name="Query" Value="" />
        <EnumerationLiteral Description="Parameters is taken from Route" Name="Path" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="CodeGenerationVariableCaseTypes" Namespace="ApiStudioIO" Description="Description for ApiStudioIO.CodeGenerationVariableCaseTypes">
      <Literals>
        <EnumerationLiteral Description="Description for ApiStudioIO.CodeGenerationVariableCaseTypes.CamelCase" Name="CamelCase" Value="0" />
        <EnumerationLiteral Description="Description for ApiStudioIO.CodeGenerationVariableCaseTypes.PascalCase" Name="PascalCase" Value="1" />
        <EnumerationLiteral Description="Description for ApiStudioIO.CodeGenerationVariableCaseTypes.SnakeCase" Name="SnakeCase" Value="2" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="List&lt;ApiStudioComponentMediaTypeRequest&gt;" Namespace="System.Collections.Generic" />
    <ExternalType Name="List&lt;ApiStudioComponentMediaTypeResponse&gt;" Namespace="System.Collections.Generic" />
    <ExternalType Name="List&lt;ApiStudioComponentParameter&gt;" Namespace="System.Collections.Generic" />
    <ExternalType Name="List&lt;ApiStudioComponentResponseStatusCode&gt;" Namespace="System.Collections.Generic" />
    <DomainEnumeration Name="HttpApiAudienceTypes" Namespace="ApiStudioIO" Description="Description for ApiStudioIO.HttpApiAudienceTypes">
      <Literals>
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiAudienceTypes.Private" Name="Private" Value="" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiAudienceTypes.Partner" Name="Partner" Value="" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiAudienceTypes.Public" Name="Public" Value="" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="List&lt;ApiStudioComponentHeaderRequest&gt;" Namespace="System.Collections.Generic" />
    <ExternalType Name="List&lt;ApiStudioComponentHeaderResponse&gt;" Namespace="System.Collections.Generic" />
    <DomainEnumeration Name="HttpApiHeaderResponseOnTypes" Namespace="ApiStudioIO" Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes">
      <Literals>
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnAlways" Name="OnAlways" Value="0" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnInformation" Name="OnInformation" Value="1" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnRedirection" Name="OnRedirection" Value="3" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnServerError" Name="OnServerError" Value="5" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnClientError" Name="OnClientError" Value="4" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiHeaderResponseOnTypes.OnSuccess" Name="OnSuccess" Value="2" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="HttpApiAuthorizationTypes" Namespace="ApiStudioIO" Description="Description for ApiStudioIO.HttpApiAuthorizationTypes">
      <Literals>
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiAuthorizationTypes.Roles" Name="Roles" Value="" />
        <EnumerationLiteral Description="Description for ApiStudioIO.HttpApiAuthorizationTypes.Policy" Name="Policy" Value="" />
      </Literals>
    </DomainEnumeration>
  </Types>
  <Shapes>
    <CompartmentShape Id="e489bbfa-2b05-46fa-a5a7-acfd9dae520d" Description="Description for ApiStudioIO.ResourceShape" Name="ResourceShape" DisplayName="Resource Shape" Namespace="ApiStudioIO" FixedTooltipText="Resource Shape" InitialWidth="2" InitialHeight="0.3" FillGradientMode="None" HasDefaultConnectionPoints="true" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" FontStyle="Bold" />
      </ShapeHasDecorators>
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="HttpApi" TitleFontStyle="Bold" Title="HTTP APIs" />
    </CompartmentShape>
    <CompartmentShape Id="48ad5525-6cdd-4c82-82f7-86808f325f47" Description="A document resource is a singular concept that is akin to an object instance or database record. In REST, you can view it as a single resource inside resource collection. A document’s state representation typically includes both fields with values and links to other related resources." Name="ResourceInstanceShape" DisplayName="Document Resource" Namespace="ApiStudioIO" FixedTooltipText="A document resource is a singular concept that is akin to an object instance or database record. In REST, you can view it as a single resource inside resource collection. A document’s state representation typically includes both fields with values and links to other related resources." FillColor="210, 223, 255" OutlineColor="111, 154, 246" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="ResourceShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\ResourceInstance.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="07df8a5f-ff47-405d-9a53-3263991b84f9" Description="A collection resource is a server-managed directory of resources. Clients may propose new resources to be added to a collection. However, it is up to the collection to choose to create a new resource, or not. A collection resource chooses what it wants to contain and also decides the URIs of each contained resource." Name="ResourceCollectionShape" DisplayName="Collection Resource" Namespace="ApiStudioIO" FixedTooltipText="A collection resource is a server-managed directory of resources. Clients may propose new resources to be added to a collection. However, it is up to the collection to choose to create a new resource, or not. A collection resource chooses what it wants to contain and also decides the URIs of each contained resource." FillColor="249, 246, 203" OutlineColor="253, 243, 148" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="ResourceShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\ResourceCollection.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="8cab4e9e-ce79-487c-a346-31bc65dcb8b5" Description="An action resource models a procedural concept. Action resources are like executable functions, with parameters and return values; inputs and outputs." Name="ResourceActionShape" DisplayName="Action Resource" Namespace="ApiStudioIO" FixedTooltipText="An action resource models a procedural concept. Action resources are like executable functions, with parameters and return values; inputs and outputs." FillColor="173, 214, 184" OutlineColor="126, 165, 112" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="ResourceShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\ResourceAction.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <GeometryShape Id="35a9508c-3087-4bf3-8a55-00c8bcd66044" Description="Data entities to be used as definition within OpenAPI specifciation" Name="DataModelShape" DisplayName="Data Model" Namespace="ApiStudioIO" FixedTooltipText="Data entities to be used as definition within OpenAPI specifciation" FillColor="Gainsboro" OutlineColor="DimGray" InitialHeight="0.3" OutlineThickness="0.01" FillGradientMode="None" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerMiddleLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\DataModel.bmp" />
      </ShapeHasDecorators>
    </GeometryShape>
    <CompartmentShape Id="dd9a8e7d-9d77-45ae-9fc8-f6e40af35fe1" Description="Description for ApiStudioIO.HttpApiShape" Name="HttpApiShape" DisplayName="Http Api Shape" Namespace="ApiStudioIO" FixedTooltipText="Http Api Shape" InitialWidth="2" InitialHeight="0.3" OutlineThickness="0.01" FillGradientMode="None" Geometry="Rectangle" DefaultExpandCollapseState="Collapsed">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapse" DisplayName="Expand Collapse" />
      </ShapeHasDecorators>
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="RequestParameters" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Parameters (Request)" EntryTextColor="DimGray" />
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="ResponseStatusCodes" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Status Codes (Response)" EntryTextColor="DimGray" />
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="ResponseMediaTypes" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Media Types (Response)" EntryTextColor="DimGray" />
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="RequestMediaTypes" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Media Types (Request)" EntryTextColor="DimGray" />
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="ResponseHeaders" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Headers (Response)" EntryTextColor="DimGray" />
      <Compartment FillColor="Transparent" TitleFillColor="Transparent" Name="RequestHeaders" TitleFontStyle="Bold" EntryFontStyle="Italic" Title="Headers (Request)" EntryTextColor="DimGray" />
    </CompartmentShape>
    <CompartmentShape Id="54ec3028-306f-4d33-9950-77dbe3f33596" Description="The PUT method replaces all current representations of the target resource with the request payload." Name="HttpApiPutShape" DisplayName="Http PUT" Namespace="ApiStudioIO" FixedTooltipText="The PUT method replaces all current representations of the target resource with the request payload." FillColor="255, 245, 234" OutlineColor="252, 161, 48" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiPut.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="c3893b5d-f1de-44fc-9708-a1f3e3028396" Description="The POST method submits an entity to the specified resource, often causing a change in state or side effects on the server." Name="HttpApiPostShape" DisplayName="Http POST" Namespace="ApiStudioIO" FixedTooltipText="The POST method submits an entity to the specified resource, often causing a change in state or side effects on the server." FillColor="236, 250, 244" OutlineColor="73, 204, 144" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiPost.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="d104c64c-e292-4f05-8166-9d609107339b" Description="The DELETE method deletes the specified resource." Name="HttpApiDeleteShape" DisplayName="Http DELETE" Namespace="ApiStudioIO" FixedTooltipText="The DELETE method deletes the specified resource." FillColor="254, 235, 235" OutlineColor="249, 62, 62" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiDelete.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="8660ccd6-0d9c-4617-9656-8f6420d5771e" Description="The GET method requests a representation of the specified resource. Requests using GET should only retrieve data." Name="HttpApiGetShape" DisplayName="Http GET" Namespace="ApiStudioIO" FixedTooltipText="The GET method requests a representation of the specified resource. Requests using GET should only retrieve data." FillColor="239, 247, 255" OutlineColor="97, 175, 254" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiGet.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="e3129bbe-785c-496f-b433-2a2831a88391" Description="An attribute resource is a procedural concept. Attributes allow the specific resource for a given attribute of a parent resource. Typically Getter and Putter functionality." Name="ResourceAttributeShape" DisplayName="Attribute Resource" Namespace="ApiStudioIO" FixedTooltipText="An attribute resource is a procedural concept. Attributes allow the specific resource for a given attribute of a parent resource. Typically Getter and Putter functionality." FillColor="251, 220, 206" OutlineColor="242, 187, 173" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="ResourceShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\ResourceAttribute.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="444949cb-c15c-4b67-9fa2-293c89c19104" Description="The PATCH method applies partial modifications to a resource." Name="HttpApiPatchShape" DisplayName="Http PATCH" Namespace="ApiStudioIO" FixedTooltipText="The PATCH method applies partial modifications to a resource." FillColor="237, 252, 249" OutlineColor="80, 227, 194" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiPatch.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="b4aad5ff-18a0-4bb6-b815-6485ea726285" Description="The HEAD method asks for a response identical to a GET request, but without the response body." Name="HttpApiHeadShape" DisplayName="Http HEAD" Namespace="ApiStudioIO" FixedTooltipText="The HEAD method asks for a response identical to a GET request, but without the response body." FillColor="244, 231, 255" OutlineColor="144, 18, 254" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiHead.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="c6aaf5ba-dc31-4ec2-9d38-63dbc19831a6" Description="The OPTIONS method describes the communication options for the target resource." Name="HttpApiOptionsShape" DisplayName="Http OPTIONS" Namespace="ApiStudioIO" FixedTooltipText="The OPTIONS method describes the communication options for the target resource." FillColor="230, 238, 246" OutlineColor="13, 90, 167" InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiOptions.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
    <CompartmentShape Id="16e2d892-8c37-494a-9661-9e725e61ded8" Description="The TRACE method performs a message loop-back test along the path to the target resource." Name="HttpApiTraceShape" DisplayName="Http TRACE" Namespace="ApiStudioIO" FixedTooltipText="The TRACE method performs a message loop-back test along the path to the target resource." InitialHeight="1" Geometry="Rectangle">
      <BaseCompartmentShape>
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </BaseCompartmentShape>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\HttpApiTrace.bmp" />
      </ShapeHasDecorators>
    </CompartmentShape>
  </Shapes>
  <Connectors>
    <Connector Id="537ecac4-8dfe-4dd9-9550-4e5f9bb6ffe4" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="ResourceToResourceConnector" DisplayName="Resource To Resource Connector" Namespace="ApiStudioIO" FixedTooltipText="Resource To Resource Connector" Color="DimGray" DashStyle="Dash" TargetEndStyle="FilledArrow" Thickness="0.015" />
    <Connector Id="0d0cac4c-9fa8-4dc3-ba4e-580eae34d038" Description="Associate Request\Response to Resource" Name="ResourceToApiConnector" DisplayName="Resource To Http Api" Namespace="ApiStudioIO" FixedTooltipText="Associate Request\Response to Resource" TargetEndStyle="EmptyArrow" Thickness="0.015">
      <ConnectorHasDecorators Position="TargetBottom" OffsetFromShape="0.1" OffsetFromLine="0">
        <TextDecorator Name="Information" DisplayName="HTTP" DefaultText="HTTP" FontStyle="Italic" FontSize="7" />
      </ConnectorHasDecorators>
    </Connector>
    <Connector Id="d6a1970d-b389-43de-a13a-62301a3f7488" Description="Description for ApiStudioIO.DataModelToHttpApiConnector" Name="DataModelToHttpApiConnector" DisplayName="Data Model To Http Api Connector" Namespace="ApiStudioIO" FixedTooltipText="Data Model To Http Api Connector" Color="RoyalBlue" DashStyle="Dot" TargetEndStyle="FilledArrow" Thickness="0.01">
      <ConnectorHasDecorators Position="TargetBottom" OffsetFromShape="0.1" OffsetFromLine="0">
        <TextDecorator Name="Information" DisplayName="Request" DefaultText="Request" FontStyle="Italic" FontSize="7" />
      </ConnectorHasDecorators>
    </Connector>
    <Connector Id="16cee18b-bc54-4744-b0d6-988b3b32787e" Description="Description for ApiStudioIO.RestToDataModelConnector" Name="RestToDataModelConnector" DisplayName="Rest To Data Model Connector" Namespace="ApiStudioIO" FixedTooltipText="Rest To Data Model Connector" Color="SeaGreen" DashStyle="Dot" TargetEndStyle="FilledArrow" Thickness="0.01">
      <ConnectorHasDecorators Position="SourceBottom" OffsetFromShape="0.1" OffsetFromLine="0">
        <TextDecorator Name="Information" DisplayName="Response" DefaultText="Response" FontStyle="Italic" FontSize="7" />
      </ConnectorHasDecorators>
    </Connector>
  </Connectors>
  <XmlSerializationBehavior Name="ApiStudioIOSerializationBehavior" Namespace="ApiStudioIO">
    <ClassData>
      <XmlClassData TypeName="ApiStudio" MonikerAttributeName="" SerializeId="true" MonikerElementName="ApiStudioMoniker" ElementName="ApiStudio" MonikerTypeName="ApiStudioMoniker">
        <DomainClassMoniker Name="ApiStudio" />
        <ElementData>
          <XmlPropertyData XmlName="codeGenerationVariableCaseType">
            <DomainPropertyMoniker Name="ApiStudio/CodeGenerationVariableCaseType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="identifier">
            <DomainPropertyMoniker Name="ApiStudio/Identifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="vendor">
            <DomainPropertyMoniker Name="ApiStudio/Vendor" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="product">
            <DomainPropertyMoniker Name="ApiStudio/Product" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="apiName">
            <DomainPropertyMoniker Name="ApiStudio/ApiName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="version">
            <DomainPropertyMoniker Name="ApiStudio/Version" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="title" Representation="Ignore">
            <DomainPropertyMoniker Name="ApiStudio/Title" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="ApiStudio/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="contactUrl">
            <DomainPropertyMoniker Name="ApiStudio/ContactUrl" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="contactName">
            <DomainPropertyMoniker Name="ApiStudio/ContactName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="audience">
            <DomainPropertyMoniker Name="ApiStudio/Audience" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="initialResourceIsRoot">
            <DomainPropertyMoniker Name="ApiStudio/InitialResourceIsRoot" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesSecurity">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesSecurity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesBadRequest">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesBadRequest" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesNotFound">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesNotFound" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesNotAllowed">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesNotAllowed" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesUnprocessable">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesUnprocessable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesUnsupportedMediaType">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesUnsupportedMediaType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseCodesServerError">
            <DomainPropertyMoniker Name="ApiStudio/ResponseCodesServerError" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="resourced">
            <DomainRelationshipMoniker Name="ApiStudioHasResourced" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="apis">
            <DomainRelationshipMoniker Name="ApiStudioHasApis" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="dataModeled">
            <DomainRelationshipMoniker Name="ApiStudioHasDataModeled" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Resource" MonikerAttributeName="name" SerializeId="true" MonikerElementName="resourceMoniker" ElementName="resource" MonikerTypeName="ResourceMoniker">
        <DomainClassMoniker Name="Resource" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Resource/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="resources">
            <DomainRelationshipMoniker Name="ResourceReferencesResources" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="HttpApiUri" Representation="Ignore">
            <DomainPropertyMoniker Name="Resource/HttpApiUri" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="apis">
            <DomainRelationshipMoniker Name="ResourceReferencesApis" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ResourceToResourceConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceToResourceConnectorMoniker" ElementName="resourceToResourceConnector" MonikerTypeName="ResourceToResourceConnectorMoniker">
        <ConnectorMoniker Name="ResourceToResourceConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ApiStudioDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="ApiStudioDiagramMoniker" ElementName="ApiStudioDiagram" MonikerTypeName="ApiStudioDiagramMoniker">
        <DiagramMoniker Name="ApiStudioDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceReferencesResources" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceReferencesResourcesMoniker" ElementName="resourceReferencesResources" MonikerTypeName="ResourceReferencesResourcesMoniker">
        <DomainRelationshipMoniker Name="ResourceReferencesResources" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceInstance" MonikerAttributeName="" SerializeId="true" MonikerElementName="ResourceInstanceMoniker" ElementName="ResourceInstance" MonikerTypeName="ResourceInstanceMoniker">
        <DomainClassMoniker Name="ResourceInstance" />
        <ElementData>
          <XmlPropertyData XmlName="InstanceIdentity">
            <DomainPropertyMoniker Name="ResourceInstance/InstanceIdentity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="InstanceDescription">
            <DomainPropertyMoniker Name="ResourceInstance/InstanceDescription" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="InstanceDataType">
            <DomainPropertyMoniker Name="ResourceInstance/InstanceDataType" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ResourceCollection" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceCollectionMoniker" ElementName="resourceCollection" MonikerTypeName="ResourceCollectionMoniker">
        <DomainClassMoniker Name="ResourceCollection" />
        <ElementData>
          <XmlPropertyData XmlName="usePagination">
            <DomainPropertyMoniker Name="ResourceCollection/UsePagination" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="useSorting">
            <DomainPropertyMoniker Name="ResourceCollection/UseSorting" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ResourceShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceShapeMoniker" ElementName="resourceShape" MonikerTypeName="ResourceShapeMoniker">
        <CompartmentShapeMoniker Name="ResourceShape" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceInstanceShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="ResourceInstanceShapeMoniker" ElementName="ResourceInstanceShape" MonikerTypeName="ResourceInstanceShapeMoniker">
        <CompartmentShapeMoniker Name="ResourceInstanceShape" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceCollectionShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceCollectionShapeMoniker" ElementName="resourceCollectionShape" MonikerTypeName="ResourceCollectionShapeMoniker">
        <CompartmentShapeMoniker Name="ResourceCollectionShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApi" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiMoniker" ElementName="HttpApi" MonikerTypeName="HttpApiMoniker">
        <DomainClassMoniker Name="HttpApi" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="dataModels">
            <DomainRelationshipMoniker Name="HttpApiSuccessResponseModel" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="HttpApi/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="authorisationRole" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/AuthorisationRole" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="httpVerb" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/HttpVerb" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="httpApiParameters">
            <DomainRelationshipMoniker Name="HttpApiHasParameters" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApiResponseStatusCodes">
            <DomainRelationshipMoniker Name="HttpApiHasResponseStatusCodes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApiMediaTypeResponsed">
            <DomainRelationshipMoniker Name="HttpApiHasMediaTypeResponse" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApiMediaTypeRequestd">
            <DomainRelationshipMoniker Name="HttpApiHasMediaTypeRequest" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="requestParameters" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/RequestParameters" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="responseStatusCodes" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/ResponseStatusCodes" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="ResponseMediaTypes" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/ResponseMediaTypes" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="RequestMediaTypes" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/RequestMediaTypes" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApiHeaderRequests">
            <DomainRelationshipMoniker Name="HttpApiHasHeaderRequest" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApiHeaderResponses">
            <DomainRelationshipMoniker Name="HttpApiHasHeaderResponse" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="responseHeaders" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/ResponseHeaders" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="requestHeaders" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApi/RequestHeaders" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ResourceToApiConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceToApiConnectorMoniker" ElementName="resourceToApiConnector" MonikerTypeName="ResourceToApiConnectorMoniker">
        <ConnectorMoniker Name="ResourceToApiConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceAction" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceActionMoniker" ElementName="resourceAction" MonikerTypeName="ResourceActionMoniker">
        <DomainClassMoniker Name="ResourceAction" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceActionShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceActionShapeMoniker" ElementName="resourceActionShape" MonikerTypeName="ResourceActionShapeMoniker">
        <CompartmentShapeMoniker Name="ResourceActionShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiGet" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiGetMoniker" ElementName="HttpApiGet" MonikerTypeName="HttpApiGetMoniker">
        <DomainClassMoniker Name="HttpApiGet" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPut" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiPutMoniker" ElementName="HttpApiPut" MonikerTypeName="HttpApiPutMoniker">
        <DomainClassMoniker Name="HttpApiPut" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPost" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiPostMoniker" ElementName="HttpApiPost" MonikerTypeName="HttpApiPostMoniker">
        <DomainClassMoniker Name="HttpApiPost" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiDelete" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiDeleteMoniker" ElementName="HttpApiDelete" MonikerTypeName="HttpApiDeleteMoniker">
        <DomainClassMoniker Name="HttpApiDelete" />
      </XmlClassData>
      <XmlClassData TypeName="DataModel" MonikerAttributeName="name" SerializeId="true" MonikerElementName="dataModelMoniker" ElementName="dataModel" MonikerTypeName="DataModelMoniker">
        <DomainClassMoniker Name="DataModel" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="DataModel/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="HttpApis">
            <DomainRelationshipMoniker Name="HttpApiSuccessRequestModel" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="DataModel/Description" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DataModelShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="dataModelShapeMoniker" ElementName="dataModelShape" MonikerTypeName="DataModelShapeMoniker">
        <GeometryShapeMoniker Name="DataModelShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiSuccessRequestModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiSuccessRequestModelMoniker" ElementName="HttpApiSuccessRequestModel" MonikerTypeName="HttpApiSuccessRequestModelMoniker">
        <DomainRelationshipMoniker Name="HttpApiSuccessRequestModel" />
      </XmlClassData>
      <XmlClassData TypeName="DataModelToHttpApiConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="dataModelToHttpApiConnectorMoniker" ElementName="dataModelToHttpApiConnector" MonikerTypeName="DataModelToHttpApiConnectorMoniker">
        <ConnectorMoniker Name="DataModelToHttpApiConnector" />
      </XmlClassData>
      <XmlClassData TypeName="RestToDataModelConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="restToDataModelConnectorMoniker" ElementName="restToDataModelConnector" MonikerTypeName="RestToDataModelConnectorMoniker">
        <ConnectorMoniker Name="RestToDataModelConnector" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiSuccessResponseModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiSuccessResponseModelMoniker" ElementName="HttpApiSuccessResponseModel" MonikerTypeName="HttpApiSuccessResponseModelMoniker">
        <DomainRelationshipMoniker Name="HttpApiSuccessResponseModel" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiShapeMoniker" ElementName="HttpApiShape" MonikerTypeName="HttpApiShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPutShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiPutShapeMoniker" ElementName="HttpApiPutShape" MonikerTypeName="HttpApiPutShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiPutShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPostShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiPostShapeMoniker" ElementName="HttpApiPostShape" MonikerTypeName="HttpApiPostShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiPostShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiDeleteShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiDeleteShapeMoniker" ElementName="HttpApiDeleteShape" MonikerTypeName="HttpApiDeleteShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiDeleteShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiGetShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiGetShapeMoniker" ElementName="HttpApiGetShape" MonikerTypeName="HttpApiGetShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiGetShape" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceAttribute" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceAttributeMoniker" ElementName="resourceAttribute" MonikerTypeName="ResourceAttributeMoniker">
        <DomainClassMoniker Name="ResourceAttribute" />
      </XmlClassData>
      <XmlClassData TypeName="ResourceAttributeShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceAttributeShapeMoniker" ElementName="resourceAttributeShape" MonikerTypeName="ResourceAttributeShapeMoniker">
        <CompartmentShapeMoniker Name="ResourceAttributeShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiMediaTypeResponse" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiMediaTypeResponseMoniker" ElementName="HttpApiMediaTypeResponse" MonikerTypeName="HttpApiMediaTypeResponseMoniker">
        <DomainClassMoniker Name="HttpApiMediaTypeResponse" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiMediaTypeRequest" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiMediaTypeRequestMoniker" ElementName="HttpApiMediaTypeRequest" MonikerTypeName="HttpApiMediaTypeRequestMoniker">
        <DomainClassMoniker Name="HttpApiMediaTypeRequest" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiParameter" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiParameterMoniker" ElementName="httpApiParameter" MonikerTypeName="HttpApiParameterMoniker">
        <DomainClassMoniker Name="HttpApiParameter" />
        <ElementData>
          <XmlPropertyData XmlName="identifier">
            <DomainPropertyMoniker Name="HttpApiParameter/Identifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dataType">
            <DomainPropertyMoniker Name="HttpApiParameter/DataType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="HttpApiParameter/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isRequired">
            <DomainPropertyMoniker Name="HttpApiParameter/IsRequired" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="fromType">
            <DomainPropertyMoniker Name="HttpApiParameter/FromType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="HttpApiParameter/IsAutoGenerated" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApiParameter/DisplayName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HttpApiResponseStatusCode" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiResponseStatusCodeMoniker" ElementName="HttpApiResponseStatusCode" MonikerTypeName="HttpApiResponseStatusCodeMoniker">
        <DomainClassMoniker Name="HttpApiResponseStatusCode" />
        <ElementData>
          <XmlPropertyData XmlName="displayName" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApiResponseStatusCode/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="httpStatus">
            <DomainPropertyMoniker Name="HttpApiResponseStatusCode/HttpStatus" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApiResponseStatusCode/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApiResponseStatusCode/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="HttpApiResponseStatusCode/IsAutoGenerated" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasParameters" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasParametersMoniker" ElementName="HttpApiHasParameters" MonikerTypeName="HttpApiHasParametersMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasParameters" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasResponseStatusCodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasResponseStatusCodesMoniker" ElementName="HttpApiHasResponseStatusCodes" MonikerTypeName="HttpApiHasResponseStatusCodesMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasResponseStatusCodes" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasMediaTypeResponse" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasMediaTypeResponseMoniker" ElementName="HttpApiHasMediaTypeResponse" MonikerTypeName="HttpApiHasMediaTypeResponseMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasMediaTypeResponse" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasMediaTypeRequest" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasMediaTypeRequestMoniker" ElementName="HttpApiHasMediaTypeRequest" MonikerTypeName="HttpApiHasMediaTypeRequestMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasMediaTypeRequest" />
      </XmlClassData>
      <XmlClassData TypeName="Api" MonikerAttributeName="" SerializeId="true" MonikerElementName="apiMoniker" ElementName="api" MonikerTypeName="ApiMoniker">
        <DomainClassMoniker Name="Api" />
        <ElementData>
          <XmlPropertyData XmlName="displayName" Representation="Ignore">
            <DomainPropertyMoniker Name="Api/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="imperativeVerb">
            <DomainPropertyMoniker Name="Api/ImperativeVerb" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="identifier">
            <DomainPropertyMoniker Name="Api/Identifier" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ResourceReferencesApis" MonikerAttributeName="" SerializeId="true" MonikerElementName="resourceReferencesApisMoniker" ElementName="resourceReferencesApis" MonikerTypeName="ResourceReferencesApisMoniker">
        <DomainRelationshipMoniker Name="ResourceReferencesApis" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiMediaType" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiMediaTypeMoniker" ElementName="httpApiMediaType" MonikerTypeName="HttpApiMediaTypeMoniker">
        <DomainClassMoniker Name="HttpApiMediaType" />
        <ElementData>
          <XmlPropertyData XmlName="displayName" Representation="Ignore">
            <DomainPropertyMoniker Name="HttpApiMediaType/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="primaryType">
            <DomainPropertyMoniker Name="HttpApiMediaType/PrimaryType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="subType">
            <DomainPropertyMoniker Name="HttpApiMediaType/SubType" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHeader" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiHeaderMoniker" ElementName="httpApiHeader" MonikerTypeName="HttpApiHeaderMoniker">
        <DomainClassMoniker Name="HttpApiHeader" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="HttpApiHeader/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="HttpApiHeader/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isRequired">
            <DomainPropertyMoniker Name="HttpApiHeader/IsRequired" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="allowEmptyValue">
            <DomainPropertyMoniker Name="HttpApiHeader/AllowEmptyValue" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="HttpApiHeader/IsAutoGenerated" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHeaderRequest" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHeaderRequestMoniker" ElementName="HttpApiHeaderRequest" MonikerTypeName="HttpApiHeaderRequestMoniker">
        <DomainClassMoniker Name="HttpApiHeaderRequest" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHeaderResponse" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHeaderResponseMoniker" ElementName="HttpApiHeaderResponse" MonikerTypeName="HttpApiHeaderResponseMoniker">
        <DomainClassMoniker Name="HttpApiHeaderResponse" />
        <ElementData>
          <XmlPropertyData XmlName="includeOn">
            <DomainPropertyMoniker Name="HttpApiHeaderResponse/IncludeOn" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasHeaderRequest" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasHeaderRequestMoniker" ElementName="HttpApiHasHeaderRequest" MonikerTypeName="HttpApiHasHeaderRequestMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasHeaderRequest" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHasHeaderResponse" MonikerAttributeName="" SerializeId="true" MonikerElementName="HttpApiHasHeaderResponseMoniker" ElementName="HttpApiHasHeaderResponse" MonikerTypeName="HttpApiHasHeaderResponseMoniker">
        <DomainRelationshipMoniker Name="HttpApiHasHeaderResponse" />
      </XmlClassData>
      <XmlClassData TypeName="ApiStudioHasResourced" MonikerAttributeName="" SerializeId="true" MonikerElementName="apiStudioHasResourcedMoniker" ElementName="apiStudioHasResourced" MonikerTypeName="ApiStudioHasResourcedMoniker">
        <DomainRelationshipMoniker Name="ApiStudioHasResourced" />
      </XmlClassData>
      <XmlClassData TypeName="ApiStudioHasApis" MonikerAttributeName="" SerializeId="true" MonikerElementName="apiStudioHasApisMoniker" ElementName="apiStudioHasApis" MonikerTypeName="ApiStudioHasApisMoniker">
        <DomainRelationshipMoniker Name="ApiStudioHasApis" />
      </XmlClassData>
      <XmlClassData TypeName="ApiStudioHasDataModeled" MonikerAttributeName="" SerializeId="true" MonikerElementName="apiStudioHasDataModeledMoniker" ElementName="apiStudioHasDataModeled" MonikerTypeName="ApiStudioHasDataModeledMoniker">
        <DomainRelationshipMoniker Name="ApiStudioHasDataModeled" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPatch" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiPatchMoniker" ElementName="httpApiPatch" MonikerTypeName="HttpApiPatchMoniker">
        <DomainClassMoniker Name="HttpApiPatch" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHead" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiHeadMoniker" ElementName="httpApiHead" MonikerTypeName="HttpApiHeadMoniker">
        <DomainClassMoniker Name="HttpApiHead" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiOptions" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiOptionsMoniker" ElementName="httpApiOptions" MonikerTypeName="HttpApiOptionsMoniker">
        <DomainClassMoniker Name="HttpApiOptions" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiTrace" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiTraceMoniker" ElementName="httpApiTrace" MonikerTypeName="HttpApiTraceMoniker">
        <DomainClassMoniker Name="HttpApiTrace" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiPatchShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiPatchShapeMoniker" ElementName="httpApiPatchShape" MonikerTypeName="HttpApiPatchShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiPatchShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiHeadShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiHeadShapeMoniker" ElementName="httpApiHeadShape" MonikerTypeName="HttpApiHeadShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiHeadShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiOptionsShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiOptionsShapeMoniker" ElementName="httpApiOptionsShape" MonikerTypeName="HttpApiOptionsShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiOptionsShape" />
      </XmlClassData>
      <XmlClassData TypeName="HttpApiTraceShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="httpApiTraceShapeMoniker" ElementName="httpApiTraceShape" MonikerTypeName="HttpApiTraceShapeMoniker">
        <CompartmentShapeMoniker Name="HttpApiTraceShape" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ApiStudioExplorer">
    <CustomNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\ResourceCollection.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="ResourceCollection" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\ResourceInstance.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="ResourceInstance" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\ResourceAttribute.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="ResourceAttribute" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\ResourceAction.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="ResourceAction" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiGet.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="HttpApiGet" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiDelete.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="HttpApiDelete" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiPost.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="HttpApiPost" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiPut.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="HttpApiPut" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\DataModel.bmp" ShowsDomainClass="true">
        <Class>
          <DomainClassMoniker Name="DataModel" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiHasHeaderResponse.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasHeaderResponse" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiHasHeaderRequest.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasHeaderRequest" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiMediaTypeRequest.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasMediaTypeRequest" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiMediaTypeResponse.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasMediaTypeResponse" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiParameter.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasParameters" />
        </Class>
      </ExplorerNodeSettings>
      <ExplorerNodeSettings IconToDisplay="Resources\HttpApiResponseStatusCode.bmp" ShowsDomainClass="true">
        <Class>
          <DomainRelationshipMoniker Name="HttpApiHasResponseStatusCodes" />
        </Class>
      </ExplorerNodeSettings>
    </CustomNodeSettings>
  </ExplorerBehavior>
  <ConnectionBuilders>
    <ConnectionBuilder Name="ResourceReferencesResourcesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ResourceReferencesResources" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Resource" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Resource" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="HttpApiSuccessRequestModelBuilder" IsCustom="true">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="HttpApiSuccessRequestModel" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DataModel" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="HttpApi" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="HttpApiSuccessResponseModelBuilder" IsCustom="true">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="HttpApiSuccessResponseModel" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="HttpApi" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DataModel" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ResourceReferencesApisBuilder" IsCustom="true">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ResourceReferencesApis" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Resource" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Api" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="5bdfe02c-2d97-48a7-afd9-8a9acd6ab2c0" Description="Description for ApiStudioIO.ApiStudioDiagram" Name="ApiStudioDiagram" DisplayName="Azure Function (ApiStudio) Diagram" Namespace="ApiStudioIO">
    <Class>
      <DomainClassMoniker Name="ApiStudio" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="Resource" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasResourced.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ResourceShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Resource/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="ResourceShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="ResourceShape/HttpApi" />
          <ElementsDisplayed>
            <DomainPath>ResourceReferencesApis.Apis/!Api</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Api/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ResourceInstance" />
        <CompartmentShapeMoniker Name="ResourceInstanceShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ResourceCollection" />
        <CompartmentShapeMoniker Name="ResourceCollectionShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ResourceAction" />
        <CompartmentShapeMoniker Name="ResourceActionShape" />
      </CompartmentShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="DataModel" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasDataModeled.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="DataModelShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="DataModel/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="DataModelShape" />
      </ShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApi" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasApis.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="HttpApiShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Api/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="HttpApiShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/RequestParameters" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasParameters.HttpApiParameters/!HttpApiParameter</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiParameter/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/ResponseStatusCodes" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasResponseStatusCodes.HttpApiResponseStatusCodes/!HttpApiResponseStatusCode</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiResponseStatusCode/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/ResponseMediaTypes" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasMediaTypeResponse.HttpApiMediaTypeResponsed/!HttpApiMediaTypeResponse</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiMediaType/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/RequestMediaTypes" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasMediaTypeRequest.HttpApiMediaTypeRequestd/!HttpApiMediaTypeRequest</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiMediaType/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/ResponseHeaders" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasHeaderResponse.HttpApiHeaderResponses/!HttpApiHeaderResponse</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiHeader/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="HttpApiShape/RequestHeaders" />
          <ElementsDisplayed>
            <DomainPath>HttpApiHasHeaderRequest.HttpApiHeaderRequests/!HttpApiHeaderRequest</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="HttpApiHeader/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiGet" />
        <CompartmentShapeMoniker Name="HttpApiGetShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiPut" />
        <CompartmentShapeMoniker Name="HttpApiPutShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiPost" />
        <CompartmentShapeMoniker Name="HttpApiPostShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiDelete" />
        <CompartmentShapeMoniker Name="HttpApiDeleteShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ResourceAttribute" />
        <CompartmentShapeMoniker Name="ResourceAttributeShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiPatch" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasApis.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <CompartmentShapeMoniker Name="HttpApiPatchShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiHead" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasApis.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <CompartmentShapeMoniker Name="HttpApiHeadShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiOptions" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasApis.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <CompartmentShapeMoniker Name="HttpApiOptionsShape" />
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="HttpApiTrace" />
        <ParentElementPath>
          <DomainPath>ApiStudioHasApis.ApiStudio/!ApiStudio</DomainPath>
        </ParentElementPath>
        <CompartmentShapeMoniker Name="HttpApiTraceShape" />
      </CompartmentShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="ResourceToResourceConnector" />
        <DomainRelationshipMoniker Name="ResourceReferencesResources" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="DataModelToHttpApiConnector" />
        <DomainRelationshipMoniker Name="HttpApiSuccessRequestModel" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="RestToDataModelConnector" />
        <DomainRelationshipMoniker Name="HttpApiSuccessResponseModel" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="ResourceToApiConnector" />
        <DomainRelationshipMoniker Name="ResourceReferencesApis" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="ApiStudio" Icon="Resources\ApiStudioIODiagram.ico" EditorGuid="7adec530-a54b-4af5-8284-6edc08e65131">
    <RootClass>
      <DomainClassMoniker Name="ApiStudio" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ApiStudioIOSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="ApiStudio - Resources">
      <Notes>Resource tree used to navigable paths</Notes>
      <ConnectionTool Name="ResourceAssociation" ToolboxIcon="Resources\ConnectorToolResourceAssociation.bmp" Caption="Link Resource" Tooltip="Associate HTTP Verb to a Resource" HelpKeyword="F1KeywordResourceToResource" SourceCursorIcon="Resources\ConnectorToolResourceAssociation.cur" TargetCursorIcon="Resources\ConnectorToolResourceAssociation.cur">
        <ConnectionBuilderMoniker Name="ApiStudioIO/ResourceReferencesResourcesBuilder" />
      </ConnectionTool>
      <ElementTool Name="ResourceCollectionTool" ToolboxIcon="Resources\ResourceCollection.bmp" Caption="Collection" Tooltip="A collection resource is a server-managed directory of resources. Clients may propose new resources to be added to a collection. However, it is up to the collection to choose to create a new resource, or not. A collection resource chooses what it wants to contain and also decides the URIs of each contained resource." HelpKeyword="F1KeywordResourceCollection">
        <DomainClassMoniker Name="ResourceCollection" />
      </ElementTool>
      <ElementTool Name="ResourceInstanceTool" ToolboxIcon="Resources\ResourceInstance.bmp" Caption="Instance" Tooltip="A document resource is a singular concept that is akin to an object instance or database record. In REST, you can view it as a single resource inside resource collection. A document’s state representation typically includes both fields with values and links to other related resources." HelpKeyword="F1KeywordResourceInstance">
        <DomainClassMoniker Name="ResourceInstance" />
      </ElementTool>
      <ElementTool Name="ResourceAttributeTool" ToolboxIcon="Resources\ResourceAttribute.bmp" Caption="Attribute" Tooltip="An attribute resource is a procedural concept. Attributes allow the specific resource for a given attribute of a parent resource. Typically Getter and Putter functionality." HelpKeyword="F1KeywordResourceAttribute">
        <DomainClassMoniker Name="ResourceAttribute" />
      </ElementTool>
      <ElementTool Name="ResourceActionTool" ToolboxIcon="Resources\ResourceAction.bmp" Caption="Action" Tooltip="An action resource models a procedural concept. Action resources are like executable functions, with parameters and return values; inputs and outputs." HelpKeyword="F1KeywordResourceAction">
        <DomainClassMoniker Name="ResourceAction" />
      </ElementTool>
    </ToolboxTab>
    <ToolboxTab TabText="ApiStudio - HTTP APIs">
      <Notes>HTTP verbs used to define request and response for resource within the solution</Notes>
      <ConnectionTool Name="HttpApiResourceTool" ToolboxIcon="Resources\ConnectorToolResourceLinkApi.bmp" Caption="Resource Association" Tooltip="Associate Request\Response to Resource" HelpKeyword="F1KeywordResourceToHttpApi" SourceCursorIcon="Resources\ConnectorToolResourceAssociation.cur" TargetCursorIcon="Resources\ConnectorToolResourceLinkApi.cur">
        <ConnectionBuilderMoniker Name="ApiStudioIO/ResourceReferencesApisBuilder" />
      </ConnectionTool>
      <ElementTool Name="HttpApiGetTool" ToolboxIcon="Resources\HttpApiGet.bmp" Caption="GET" Tooltip="The GET method requests a representation of the specified resource. Requests using GET should only retrieve data." HelpKeyword="F1KeywordApiGetTool">
        <Notes>The GET method requests a representation of the specified resource. Requests using GET should only retrieve data.</Notes>
        <DomainClassMoniker Name="HttpApiGet" />
      </ElementTool>
      <ElementTool Name="HttpApiPutTool" ToolboxIcon="Resources\HttpApiPut.bmp" Caption="PUT" Tooltip="The PUT method replaces all current representations of the target resource with the request payload." HelpKeyword="F1KeywordHttpApiPutTool">
        <Notes>The PUT method replaces all current representations of the target resource with the request payload.</Notes>
        <DomainClassMoniker Name="HttpApiPut" />
      </ElementTool>
      <ElementTool Name="HttpApiPostTool" ToolboxIcon="Resources\HttpApiPost.bmp" Caption="POST" Tooltip="The POST method submits an entity to the specified resource, often causing a change in state or side effects on the server." HelpKeyword="F1KeywordHttpApiPostTool">
        <Notes>The POST method submits an entity to the specified resource, often causing a change in state or side effects on the server.</Notes>
        <DomainClassMoniker Name="HttpApiPost" />
      </ElementTool>
      <ElementTool Name="HttpApiDeleteTool" ToolboxIcon="Resources\HttpApiDelete.bmp" Caption="DELETE" Tooltip="The DELETE method deletes the specified resource." HelpKeyword="F1KeywordHttpApiDeleteTool">
        <Notes>The DELETE method deletes the specified resource.</Notes>
        <DomainClassMoniker Name="HttpApiDelete" />
      </ElementTool>
      <ElementTool Name="HttpApiPatchTool" ToolboxIcon="Resources\HttpApiPatch.bmp" Caption="PATCH" Tooltip="The PATCH method applies partial modifications to a resource." HelpKeyword="F1KeywordApiGetTool">
        <Notes>The PATCH method applies partial modifications to a resource.</Notes>
        <DomainClassMoniker Name="HttpApiPatch" />
      </ElementTool>
      <ElementTool Name="HttpApiHeadTool" ToolboxIcon="Resources\HttpApiHead.bmp" Caption="HEAD" Tooltip="The HEAD method asks for a response identical to a GET request, but without the response body." HelpKeyword="F1KeywordApiGetTool">
        <Notes>The HEAD method asks for a response identical to a GET request, but without the response body.</Notes>
        <DomainClassMoniker Name="HttpApiHead" />
      </ElementTool>
      <ElementTool Name="HttpApiOptionsTool" ToolboxIcon="Resources\HttpApiOptions.bmp" Caption="OPTIONS" Tooltip="The OPTIONS method describes the communication options for the target resource." HelpKeyword="F1KeywordApiGetTool">
        <Notes>The OPTIONS method describes the communication options for the target resource.</Notes>
        <DomainClassMoniker Name="HttpApiOptions" />
      </ElementTool>
      <ElementTool Name="HttpApiTraceTool" ToolboxIcon="Resources\HttpApiTrace.bmp" Caption="TRACE" Tooltip="The TRACE method performs a message loop-back test along the path to the target resource." HelpKeyword="F1KeywordApiGetTool">
        <Notes>The TRACE method performs a message loop-back test along the path to the target resource.</Notes>
        <DomainClassMoniker Name="HttpApiTrace" />
      </ElementTool>
      <ConnectionTool Name="HttpApiRequestTool" ToolboxIcon="Resources\ConnectorToolApiRequest.bmp" Caption="Api Request (Payload)" Tooltip="Associate Http verb to Data Model (Request input)" HelpKeyword="F1KeywordHttpApiRequest" ReversesDirection="true" SourceCursorIcon="Resources\ConnectorToolResourceLinkApi.cur" TargetCursorIcon="Resources\ConnectorToolApiRequest.cur">
        <ConnectionBuilderMoniker Name="ApiStudioIO/HttpApiSuccessRequestModelBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="HttpApiResponseTool" ToolboxIcon="Resources\ConnectorToolApiResponse.bmp" Caption="Api Response (Payload)" Tooltip="Associate Http verb to Data Model (Response output)" HelpKeyword="F1KeywordHttpApiResponseStatusCode" SourceCursorIcon="Resources\ConnectorToolResourceLinkApi.cur" TargetCursorIcon="Resources\ConnectorToolApiResponse.cur">
        <ConnectionBuilderMoniker Name="ApiStudioIO/HttpApiSuccessResponseModelBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <ToolboxTab TabText="ApiStudio - Data Model">
      <Notes>Data entities to be used as definition within OpenAPI specifciation</Notes>
      <ElementTool Name="DataModelTool" ToolboxIcon="Resources\DataModel.bmp" Caption="Data Model" Tooltip="Data entities to be used as definition within OpenAPI specifciation" HelpKeyword="F1KeywordDataModelTool">
        <DomainClassMoniker Name="DataModel" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ApiStudioDiagram" />
  </Designer>
  <Explorer ExplorerGuid="77787602-b5e7-42c4-970f-bdadafcb1c22" Title="ApiStudio Explorer">
    <ExplorerBehaviorMoniker Name="ApiStudioIO/ApiStudioExplorer" />
  </Explorer>
</Dsl>