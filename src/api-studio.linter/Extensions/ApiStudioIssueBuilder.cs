// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Common.Models.Linting;
using ApiStudioIO.Linter.Rules;

namespace ApiStudioIO.Linter.Extensions
{
    internal static class ApiStudioIssueBuilder
    {
        internal static ApiStudioIssue GetApiStudioIssue(IApiStudioRuleConstants constants, string modelName, string message)
        {
            return new ApiStudioIssue()
            {
                Rule = $"ApiStudio:{constants.RuleType}.{constants.RuleId}",
                Severity = $"{constants.Severity}",
                Component = $"serviceKey:ApiStudio/{modelName}.ApiStudio",
                Line = 0,
                Message = message,
                Type = $"{constants.RuleId}"
            };
 }
    }
}