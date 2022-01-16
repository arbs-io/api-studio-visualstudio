﻿namespace ApiStudioIO.CodeGeneration
{
    using ApiStudioIO.CodeGeneration.AzureFunction.v1;
    using ApiStudioIO.CodeGeneration.Models;
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using EnvDTE;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    public static class ApiStudioCompiler
    {
        public static string Run(DTE dte, string apiStudioFilePath)
        {
            var apiStudio = Extensions.ApiStudioExtensions.LoadDiagram(apiStudioFilePath);

            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = "1.0.0",
                },
                TargetInformationSegment = new TargetInformationModel
                {
                    Host = "AzureFunction",
                    Language = "csharp",
                    Framework = "net6.0",
                }
            };

            FileInfo file = new FileInfo(apiStudioFilePath);
            var modelName = file.Name.Replace(".ApiStudio", "");

            var sourceCodeEntities = CodeBuilder.Build(apiStudio, modelName);

            foreach (var sourceCodeEntity in sourceCodeEntities)
            {
                codeGeneration.ResourcesInfoSegment.Add(new ResourcesInformationModel
                {
                    Filename = sourceCodeEntity.Filename,
                    Checksum = sourceCodeEntity.Checksum,
                    AlwaysOverwrite = sourceCodeEntity.AlwaysOverwrite,
                });

                var sourceCodeEntityFile = $"{file.Directory}\\{sourceCodeEntity.Filename}";
                if (sourceCodeEntity.AlwaysOverwrite || !File.Exists(sourceCodeEntityFile))
                {
                    File.WriteAllText(sourceCodeEntityFile, sourceCodeEntity.CodeBase);
                }

                VisualStudioDteManager.AddNestedFile(dte, apiStudioFilePath, sourceCodeEntityFile);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                {
                    VisualStudioDteManager.AddNestedFile(dte, sourceCodeEntityFile, $"{file.Directory}\\{sourceCodeEntity.NestedFilename}");
                }
            }

            RemoveMissingItems(dte, apiStudioFilePath, codeGeneration);

            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }
        private static void RemoveMissingItems(DTE dte, string apiStudioFilePath, CodeGenerationModel codeGeneration)
        {
            if (File.Exists($"{apiStudioFilePath}.json"))
            {
                var sourceDirectory = new FileInfo(apiStudioFilePath).Directory.FullName;

                var previousCodeGenerationInfoJson = File.ReadAllText($"{apiStudioFilePath}.json");
                var previousCodeGenerationInfo = JsonConvert.DeserializeObject<CodeGenerationModel>(previousCodeGenerationInfoJson);

                previousCodeGenerationInfo.ResourcesInfoSegment
                    .Where(p => codeGeneration.ResourcesInfoSegment.All(p2 => p2.Filename != p.Filename))
                    .ToList()
                    .ForEach(buildStep => VisualStudioDteManager.DeleteFile(dte, $"{sourceDirectory}\\{buildStep.Filename}"));
            }
        }
    }
}