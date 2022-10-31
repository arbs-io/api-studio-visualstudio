// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.Vs.ErrorList;

namespace ApiStudioIO.Linter.Rules
{
    public interface IApiStudioRuleConstants
    {
        int RuleId { get; }
        string RuleType { get; }
        string Severity { get; }
        string IssueType { get; }
    }
}