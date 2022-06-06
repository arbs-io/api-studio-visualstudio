// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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