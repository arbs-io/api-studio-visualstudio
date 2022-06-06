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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiStudioIO.CodeGeneration.Extensions;
using ApiStudioIO.CodeGeneration.Models;
using ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1;
using ApiStudioIO.CodeGeneration.VisualStudio;
using EnvDTE;
using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration
{
    public static class ApiStudioCompiler
    {
        public static string Run(DTE dte, string apiStudioFilePath)
        {
            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);

            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = "1.0.0"
                },
                TargetInformationSegment = new TargetInformationModel
                {
                    Host = "AzureFunction",
                    Language = "csharp",
                    Framework = "net6.0"
                }
            };

            var file = new FileInfo(apiStudioFilePath);
            var modelName = file.Name.Replace(".ApiStudio", "");

            var sourceCodeEntities = CodeBuilder.Build(apiStudio, modelName);

            foreach (var sourceCodeEntity in sourceCodeEntities)
            {
                codeGeneration.ResourcesInfoSegment.Add(new ResourcesInformationModel
                {
                    Filename = sourceCodeEntity.Filename,
                    Checksum = sourceCodeEntity.Checksum,
                    AlwaysOverwrite = sourceCodeEntity.AlwaysOverwrite
                });

                var sourceCodeEntityFile = $"{file.Directory}\\{sourceCodeEntity.Filename}";
                if (sourceCodeEntity.AlwaysOverwrite || !File.Exists(sourceCodeEntityFile))
                    File.WriteAllText(sourceCodeEntityFile, sourceCodeEntity.CodeBase);

                VisualStudioDteManager.AddNestedFile(dte, apiStudioFilePath, sourceCodeEntityFile);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                    VisualStudioDteManager.AddNestedFile(dte, sourceCodeEntityFile,
                        $"{file.Directory}\\{sourceCodeEntity.NestedFilename}");
            }

            RemoveMissingItems(dte, apiStudioFilePath, codeGeneration);

            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }

        private static void RemoveMissingItems(DTE dte, string apiStudioFilePath, CodeGenerationModel codeGeneration)
        {
            if (File.Exists($"{apiStudioFilePath}.json"))
            {
                var directoryInfo = new FileInfo(apiStudioFilePath).Directory;
                if (directoryInfo != null)
                {
                    var sourceDirectory = directoryInfo.FullName;
                    var ext = new List<string> { "cs" };
                    var existingFiles = Directory
                        .EnumerateFiles(sourceDirectory, "*.*", SearchOption.AllDirectories)
                        .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .ToList();

                    var sourceFiles = codeGeneration.ResourcesInfoSegment
                        .GroupBy(s => s.Filename)
                        .Select(grp => $"{sourceDirectory}\\{grp.First().Filename}")
                        .ToList();

                    existingFiles
                        .Except(sourceFiles)
                        .ToList()
                        .ForEach(buildStep => VisualStudioDteManager.DeleteFile(dte, $"{buildStep}"));
                }
            }
        }
    }
}