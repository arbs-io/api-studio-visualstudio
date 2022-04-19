namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using System.Collections.Generic;

    public static partial class CodeBuilder
    {
        public static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            sourceList.AddRange(SdkOpenApiConfigurationOptions.Build(apiStudio, modelName));
            sourceList.AddRange(SdkHttpTrigger.Build(apiStudio, modelName));
            sourceList.AddRange(SdkHttpTriggerDesigner.Build(apiStudio, modelName));
            sourceList.AddRange(SdkModel.Build(apiStudio, modelName));
            sourceList.AddRange(SdkHttpAuthOAuth2.Build(apiStudio, modelName));
            sourceList.AddRange(SdkHttpAuthOAuth2Scopes.Build(apiStudio, modelName));

            return sourceList;
        }
    }
}