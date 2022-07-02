// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApiStudioIO.Build.Extensions;
using ApiStudioIO.Vs.Project;
using ApiStudioIO.Vs.Output;
using Newtonsoft.Json;
using ApiStudioIO.Build.Linter.RuleSets;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Build.CSharpNet6AzFunc.v1;

namespace ApiStudioIO.Build
{
    public static class ApiStudioInterpreter 
    {
        public static string Run(string apiStudioFilePath)
        {
            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);

            var apiStudioFileInfo= new FileInfo(apiStudioFilePath);
            var modelName = apiStudioFileInfo.Name.Replace(".ApiStudio", "");

            RuleSet.Run(apiStudio, modelName);
            var sourceCodeEntities = CodeBuilder.Run(apiStudio, modelName);

            CodeGenerationModel codeGeneration = CreateSourceCode(apiStudioFileInfo, sourceCodeEntities);

            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }

        private static CodeGenerationModel CreateSourceCode(FileInfo apiStudioFileInfo, List<SourceCodeEntity> sourceCodeEntities)
        {
            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                },
                BuildTarget = LoadBuildTarget(apiStudioFileInfo)
            };

            foreach (var sourceCodeEntity in sourceCodeEntities)
            {
                codeGeneration.ResourcesInfoSegment.Add(new ResourcesInformationModel
                {
                    Filename = sourceCodeEntity.Filename,
                    Checksum = sourceCodeEntity.Checksum,
                    AlwaysOverwrite = sourceCodeEntity.AlwaysOverwrite
                });

                var sourceCodeEntityFileInfo = new FileInfo($"{apiStudioFileInfo.Directory}\\{sourceCodeEntity.Filename}");
                if (sourceCodeEntity.AlwaysOverwrite || !File.Exists(sourceCodeEntityFileInfo.FullName))
                    File.WriteAllText(sourceCodeEntityFileInfo.FullName, sourceCodeEntity.CodeBase);

                ProjectItem.AddNestedFile(apiStudioFileInfo, sourceCodeEntityFileInfo.FullName);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                    ProjectItem.AddNestedFile(sourceCodeEntityFileInfo,
                        $"{apiStudioFileInfo.Directory}\\{sourceCodeEntity.NestedFilename}");
            }

            DeleteMissingItems(apiStudioFileInfo, codeGeneration);
            return codeGeneration;
        }

        private static BuildTargetModel LoadBuildTarget(FileInfo fileInfo)
        {
            var buildTargetModel = new BuildTargetModel
            {
                AzureFunctionsVersion = "v4",
                Language = "csharp",
                TargetFramework = "net6.0"
            };

            var buildTargetFile = $"{fileInfo.Directory}\\build_target.json";
            if (File.Exists(buildTargetFile))
            {
                var buildTarget = File.ReadAllText(buildTargetFile);
                buildTargetModel = JsonConvert.DeserializeObject<BuildTargetModel>(buildTarget);
            }
            else  // If "build_target.json" doesn't exist then default to AzFunc (original project template, without config)
            {
                var json = JsonConvert.SerializeObject(buildTargetModel, Formatting.Indented);
                File.WriteAllText(buildTargetFile, json);
            }
            Logger.Log($"[ApiStudioInterpreter::BuildTarget]: TargetFramework=={buildTargetModel?.TargetFramework} Language=={buildTargetModel?.Language} AzureFunctionsVersion=={buildTargetModel?.AzureFunctionsVersion}");
            return buildTargetModel;
        }

        private static void DeleteMissingItems(FileInfo apiStudioFileInfo, CodeGenerationModel codeGeneration)
        {
            if (File.Exists($"{apiStudioFileInfo.FullName}.json"))
            {
                var directoryInfo = apiStudioFileInfo.Directory;
                if (directoryInfo != null)
                {
                    // Only check for existing ApiStudio related file for the current model.
                    var modelName = Path.GetFileNameWithoutExtension(apiStudioFileInfo.FullName);
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
                        .ForEach(buildStep => ProjectItem.DeleteFile($"{buildStep}"));
                }
            }
        }
    }
}