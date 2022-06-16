// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

namespace ApiStudioIO
{
    using ApiStudioIO.CodeGeneration;
    using Microsoft.VisualStudio.TextTemplating.VSHost;
    using System.Text;


    [ProvideCodeGenerator(typeof(ApiStudioCodeGeneration),
        ApiStudioCodeGeneration.Name,
        ApiStudioCodeGeneration.Description, true)]
    internal sealed partial class EnterpriseApplicationIntegrationPackage
    {
    }

    [System.Runtime.InteropServices.Guid("8B628C27-AAB7-4CCF-8972-7C1EDD0A8363")]
    public class ApiStudioCodeGeneration : BaseCodeGeneratorWithSite
    {
        public const string Name = nameof(ApiStudioCodeGeneration);
        public const string Description = "ApiStudio (Visual Studio) generation tool for .ApiStudio files";

        public override string GetDefaultExtension()
        {
            return ".ApiStudio.json";
        }

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            _ = inputFileName ?? throw new System.ArgumentException($"'{nameof(inputFileName)}' cannot be null or whitespace.", nameof(inputFileName));

            var buildInfo = ApiStudioCompiler.Run(Dte, inputFileName);
            return Encoding.ASCII.GetBytes(buildInfo);
        }
    }
}