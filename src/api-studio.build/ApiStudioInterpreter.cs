// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApiStudioIO.CodeGeneration.Extensions;
using ApiStudioIO.Vs.Project;
using ApiStudioIO.Vs.Output;
using Newtonsoft.Json;
using ApiStudioIO.Build.Linter.RuleSets;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Build.CSharpNet6AzFunc.v1;

namespace ApiStudioIO.CodeGeneration
{
    public static class ApiStudioInterpreter 
    {
        public static string Run(string apiStudioFilePath)
        {
            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);

            var file = new FileInfo(apiStudioFilePath);
            var modelName = file.Name.Replace(".ApiStudio", "");
            
            RuleSet.Run(apiStudio, modelName);
            var sourceCodeEntities = ValidateApiStudio.Build(apiStudio, modelName);

            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                },
                BuildTarget = GetBuildTarget(file)
            };
            
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

                ProjectItem.AddNestedFile(apiStudioFilePath, sourceCodeEntityFile);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                    ProjectItem.AddNestedFile(sourceCodeEntityFile,
                        $"{file.Directory}\\{sourceCodeEntity.NestedFilename}");
            }

            RemoveMissingItems(apiStudioFilePath, codeGeneration);

            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }


        private static BuildTargetModel GetBuildTarget(FileInfo fileInfo)
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

        private static void RemoveMissingItems(string apiStudioFilePath, CodeGenerationModel codeGeneration)
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
                        .ForEach(buildStep => ProjectItem.DeleteFile($"{buildStep}"));
                }
            }
        }
    }
}