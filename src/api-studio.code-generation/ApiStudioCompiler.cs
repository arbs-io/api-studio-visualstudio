// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

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
                    // Only check for existing ApiStudio related file for the current model.
                    var modelName = Path.GetFileNameWithoutExtension(apiStudioFilePath);
                    var sourceDirectory = directoryInfo.FullName;
                    var ext = new List<string> { "cs" };
                    var existingFiles = Directory
                        .EnumerateFiles(sourceDirectory, $"{modelName}*.*", SearchOption.AllDirectories)
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