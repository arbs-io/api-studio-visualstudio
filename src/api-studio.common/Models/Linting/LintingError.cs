// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

namespace ApiStudioIO.Common.Models.Linting
{
    public class ApiStudioIssue
    {
        public string Rule { get; set; }
        public string Severity { get; set; }
        public string Component { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
