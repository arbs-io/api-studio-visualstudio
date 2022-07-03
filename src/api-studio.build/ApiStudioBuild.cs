// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ApiStudioIO.Vs.Project;
using ApiStudioIO.Vs.Output;
using Newtonsoft.Json;
using ApiStudioIO.Linter;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.CodeGen.CSharpNet6AzFunc;

namespace ApiStudioIO.Build
{
    public static class ApiStudioBuild
    {
        public static string Run(string apiStudioFilePath)
        {
            var apiStudioFileInfo = new FileInfo(apiStudioFilePath);
            var buildTarget = LoadBuildTarget(apiStudioFileInfo);

            ApiStudioLinter.Run(apiStudioFilePath);
            var codeGenSummary = ApiStudioCodeGenerator.Run(apiStudioFilePath, buildTarget);

            return codeGenSummary;
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
    }
}