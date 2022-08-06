// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApiStudioIO.Build.Config;
using ApiStudioIO.Linter;
using ApiStudioIO.Vs.Output;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Vs.Project;
using Newtonsoft.Json;

namespace ApiStudioIO.Build
{
    public static class ApiStudioBuild
    {
        public static string Run(string apiStudioFile)
        {
            VsLogger.Clear();

            var buildTargetConfig = new BuildTargetConfig(apiStudioFile);
            
            // Register and run Api Studio Linter/Rulesets
            ApiStudioLinter.RunRules(buildTargetConfig.ApiStudioModel, buildTargetConfig.ApiStudioModelName);

            // Code Generation: determined by language, framework and host targets
            var sourceCodeEntities = buildTargetConfig.ApiStudioCodeBuilder.Run();
            var codeGeneration = GenerateSourceCode(buildTargetConfig, sourceCodeEntities);
            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }
        
        private static CodeGenerationModel GenerateSourceCode(BuildTargetConfig buildTargetConfig, List<SourceCodeEntity> sourceCodeEntities)
        {
            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                },
                BuildTarget = buildTargetConfig.BuildTarget
            };
            
            foreach (var sourceCodeEntity in sourceCodeEntities)
            {
                codeGeneration.ResourcesInfoSegment.Add(new ResourcesInformationModel
                {
                    Filename = sourceCodeEntity.Filename,
                    Checksum = sourceCodeEntity.Checksum,
                    AlwaysOverwrite = sourceCodeEntity.AlwaysOverwrite
                });
                var sourceDirectory = buildTargetConfig.ApiStudioFileInfo.Directory;
                var sourceCodeEntityFileInfo = new FileInfo($"{sourceDirectory}\\{sourceCodeEntity.Filename}");
                if (sourceCodeEntity.AlwaysOverwrite || !File.Exists(sourceCodeEntityFileInfo.FullName))
                    File.WriteAllText(sourceCodeEntityFileInfo.FullName, sourceCodeEntity.CodeBase);

                ProjectItemHelper.AddNestedFile(buildTargetConfig.ApiStudioFileInfo, sourceCodeEntityFileInfo.FullName);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                    ProjectItemHelper.AddNestedFile(sourceCodeEntityFileInfo,
                        $"{sourceDirectory}\\{sourceCodeEntity.NestedFilename}");
            }

            CleanupRemovedItems(buildTargetConfig.ApiStudioFileInfo, codeGeneration);
            return codeGeneration;
        }

        private static void CleanupRemovedItems(FileInfo apiStudioFileInfo, CodeGenerationModel codeGeneration)
        {
            if (!File.Exists($"{apiStudioFileInfo.FullName}.json")) return;

            var directoryInfo = apiStudioFileInfo.Directory;
            if (directoryInfo == null) return;

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
                .Select(grp => $@"{sourceDirectory}\{grp.First().Filename}")
                .ToList();

            var missingFileFiles = existingFiles
                .Except(sourceFiles)
                .ToList();

            foreach (var file in missingFileFiles)
            {
                VsLogger.Log($"[ApiStudioBuild::CleanupRemovedItems]: Removing - {file}");
                ProjectItemHelper.DeleteFile($"{file}");
            }
        }
    }
}