// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using ApiStudioIO.Vs.Project;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.CodeGen.CSharpNet6AzFunc.v1;

namespace ApiStudioIO.CodeGen.CSharpNet6AzFunc
{
    public static class ApiStudioCodeGenerator
    {
        public static string Run(string apiStudioFilePath, BuildTargetModel buildTarget)
        {
            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);

            var apiStudioFileInfo = new FileInfo(apiStudioFilePath);
            var modelName = apiStudioFileInfo.Name.Replace(".ApiStudio", "");
            var sourceCodeEntities = CodeBuilder.Run(apiStudio, modelName);

            CodeGenerationModel codeGeneration = GenerateSourceCode(apiStudioFileInfo, sourceCodeEntities, buildTarget);

            return JsonConvert.SerializeObject(codeGeneration, Formatting.Indented);
        }

        private static CodeGenerationModel GenerateSourceCode(FileInfo apiStudioFileInfo, List<SourceCodeEntity> sourceCodeEntities, BuildTargetModel buildTarget)
        {
            var codeGeneration = new CodeGenerationModel
            {
                SdkInformationSegment = new SdkInformationModel
                {
                    UtcTimestamp = DateTime.UtcNow,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                },
                BuildTarget = buildTarget
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

                ProjectItemHelper.AddNestedFile(apiStudioFileInfo, sourceCodeEntityFileInfo.FullName);

                if (!string.IsNullOrEmpty(sourceCodeEntity.NestedFilename))
                    ProjectItemHelper.AddNestedFile(sourceCodeEntityFileInfo,
                        $"{apiStudioFileInfo.Directory}\\{sourceCodeEntity.NestedFilename}");
            }

            CleanupRemovedItems(apiStudioFileInfo, codeGeneration);
            return codeGeneration;
        }

        private static void CleanupRemovedItems(FileInfo apiStudioFileInfo, CodeGenerationModel codeGeneration)
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


                    var abc = existingFiles
                        .Except(sourceFiles)
                        .ToList();

                    existingFiles
                        .Except(sourceFiles)
                        .ToList()
                        .ForEach(buildStep => ProjectItemHelper.DeleteFile($"{buildStep}"));
                }
            }
        }
    }
}