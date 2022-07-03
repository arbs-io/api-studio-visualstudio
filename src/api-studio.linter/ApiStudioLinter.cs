// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiStudioIO.Linter.Extensions;
using ApiStudioIO.Linter.RuleSets;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.Linter
{
    public static class ApiStudioLinter
    {
        public static void Run(string apiStudioFilePath)
        {
            var apiStudio = ApiStudioExtensions.LoadDiagram(apiStudioFilePath);
            var apiStudioFileInfo = new FileInfo(apiStudioFilePath);
            var modelName = apiStudioFileInfo.Name.Replace(".ApiStudio", "");

            Logger.Clear();

            MissingRequest.Run(apiStudio, modelName);
            MissingResponse.Run(apiStudio, modelName);
        }
    }
}