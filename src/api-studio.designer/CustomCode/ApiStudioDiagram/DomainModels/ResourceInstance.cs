using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO
{
    public partial class ResourceInstance
    {
        protected override string GetHttpApiUriValue()
        {
            var documentId = "";
            switch (ApiStudio.CodeGenerationVariableCaseType)
            {
                case CodeGenerationVariableCaseTypes.CamelCase:
                    documentId = InstanceIdentity.ToCamelCase();
                    break;

                case CodeGenerationVariableCaseTypes.PascalCase:
                    documentId = InstanceIdentity.ToPascalCase();
                    break;

                case CodeGenerationVariableCaseTypes.SnakeCase:
                    documentId = InstanceIdentity.ToSnakeCase();
                    break;
            }

            var uri = "";
            if (SourceResource.Count > 0) uri = SourceResource[0].HttpApiUri;

            uri += $"/{{{documentId}}}";
            return FormatUri(uri);
        }
    }
}