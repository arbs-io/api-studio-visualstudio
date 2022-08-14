// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.IO;
using ApiStudioIO.CodeGen.CSharpAzureFunctionDotNet6;
using ApiStudioIO.CodeGen.CSharpMinimalApiDotNet6;
using ApiStudioIO.Common.Interfaces;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Vs.Output;
using Microsoft.VisualStudio.Modeling;
using Newtonsoft.Json;

namespace ApiStudioIO.Build.Config
{
    public class BuildTargetConfig
    {
        internal BuildTargetConfig(string apiStudioFile)
        {
            ApiStudioFileInfo = new FileInfo(apiStudioFile);
            BuildTarget = LoadBuildTarget();
            ApiStudioModel = LoadApiStudioModel();
            switch (BuildTarget.TargetLibrary)
            {
                case "azure_function":
                    ApiStudioCodeBuilder = new CSharpAzureFunctionDotNet6CodeGenerator(ApiStudioModel, ApiStudioModelName);
                    break;

                case "minimum_api":
                    ApiStudioCodeBuilder = new CSharpMinimalApiDotNet6CodeGenerator(BuildTarget, ApiStudioModel, ApiStudioModelName);
                    break;

                default:
                    ApiStudioCodeBuilder = new CSharpAzureFunctionDotNet6CodeGenerator(ApiStudioModel, ApiStudioModelName);
                    break;
            }
        }

        public FileInfo ApiStudioFileInfo { get; }

        public ApiStudio ApiStudioModel { get; }

        public string ApiStudioModelName => ApiStudioFileInfo.Name.Replace(".ApiStudio", "");
        public BuildTargetModel BuildTarget { get; private set; }

        public IApiStudioCodeGeneratorProvider ApiStudioCodeBuilder { get; }

        private BuildTargetModel LoadBuildTarget()
        {
            BuildTargetModel buildTargetModel;
            try
            {
                buildTargetModel = new BuildTargetModel
                {
                    AzureFunctionsVersion = "v4",
                    Language = "csharp",
                    TargetFramework = "net6.0"
                };

                var buildTargetFile = $"{ApiStudioFileInfo.Directory}\\build_target.json";
                if (File.Exists(buildTargetFile))
                {
                    var buildTarget = File.ReadAllText(buildTargetFile);
                    buildTargetModel = JsonConvert.DeserializeObject<BuildTargetModel>(buildTarget);
                }
                else  // If "build_target.json" doesn't exist then default to AzFunc (original project template, without config)
                {
                    var json = JsonConvert.SerializeObject(BuildTarget, Formatting.Indented);
                    File.WriteAllText(buildTargetFile, json);
                }
                VsLogger.Log(
                    $"[ApiStudioInterpreter::LoadBuildTarget]: TargetFramework=={BuildTarget?.TargetFramework} Language=={BuildTarget?.Language} AzureFunctionsVersion=={BuildTarget?.AzureFunctionsVersion}");
            }
            catch (Exception e)
            {
                VsLogger.Log($"[ApiStudioInterpreter::LoadBuildTarget]: Failed {e.Message}");
                return null;
            }
            return buildTargetModel;
        }

        private ApiStudio LoadApiStudioModel()
        {
            ApiStudio apiStudio;
            try
            {
                VsLogger.Log($"[ApiStudioInterpreter::LoadApiStudioModel]: Loading Model {ApiStudioFileInfo.Name}");
                var store = new Store(
                    typeof(ApiStudioIODomainModel));

                // All Store changes must be in a Transaction:
                using (var t =
                       store.TransactionManager.BeginTransaction("ApiStudioExtensions.LoadDiagram"))
                {
                    apiStudio = ApiStudioIOSerializationHelper.Instance
                        .LoadModel(store, ApiStudioFileInfo.FullName, null, null, null);
                    t.Commit(); //We haven't made change, just need the model reference so rollback our transaction.
                }
            }
            catch (Exception e)
            {
                VsLogger.Log($"[ApiStudioInterpreter::LoadApiStudioModel]: Failed {e.Message}");
                return null;
            }
            return apiStudio;
        }
    }
}