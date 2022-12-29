// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Common.Models.Linting;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ApiStudioIO.Vs.ErrorList
{
    public class ErrorListItem
    {
        public ErrorListItem()
        {
        }

        public ErrorListItem(Uri baseUrl, ApiStudioIssue issue)
            : this()
        {
            var errorCode = GetErrorCode(issue.Rule);

            ProjectName = string.Empty;
            FileName = GetFileName(issue.Component);

            Line = issue.Line - 1;

            Message = issue.Message;
            ErrorCode = errorCode;
            ErrorCodeToolTip = GetErrorCodeToolTip(errorCode);
            ErrorCategory = GetErrorCategory(issue.Severity, issue.Type);
            Severity = GetErrorSeverity(issue.Severity, issue.Type);
            HelpLink = GetHelpLink(baseUrl, errorCode);
        }

        public string ProjectName { get; set; }
        public string FileName { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorCodeToolTip { get; set; }
        public string ErrorCategory { get; set; }
        public __VSERRORCATEGORY Severity { get; set; }
        public string HelpLink { get; set; }

        #region Static helpers

        private static string GetFileName(string fileName)
        {
            var cleanFileName = fileName.Split(':').LastOrDefault();
            return cleanFileName?.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }

        private static string GetErrorCategory(string severity, string type)
        {
            var errorCategory = string.Empty;
            var textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (!severity.Contains("INFO") && !severity.Contains("DESIGN_CONSIDERATION"))
            {
                errorCategory += textInfo.ToTitleCase(severity.ToLower()) + ' ';
            }

            errorCategory += textInfo.ToTitleCase(type.ToLower()).Replace('_', ' ');

            return errorCategory;
        }

        private static __VSERRORCATEGORY GetErrorSeverity(string severity, string type)
        {
            var errorSeverity = __VSERRORCATEGORY.EC_ERROR;

            if (severity.Contains("INFO"))
            {
                errorSeverity = __VSERRORCATEGORY.EC_MESSAGE;
            }
            else if (severity.Contains("DESIGN_CONSIDERATION"))
            {
                errorSeverity = __VSERRORCATEGORY.EC_WARNING;
            }
            else if (type.Contains("DESIGN_CONSIDERATION"))
            {
                errorSeverity = __VSERRORCATEGORY.EC_WARNING;
            }

            return errorSeverity;
        }

        private static string GetErrorCode(string rule)
        {
            if (rule.Any(char.IsDigit))
            {
                var colonIndex = rule.IndexOf(':');
                var ruleId = rule.Substring(colonIndex + 1);
                return ruleId.Replace(".", "");
            }

            return string.Empty;
        }

        private static string GetHelpLink(Uri baseUrl, string rule)
        {
            var builder = new UriBuilder(baseUrl)
            {
                // will move to api-studio.io in the future but for now just registering in github.com
                Path = $"/arbs-io/api-studio-visualstudio/blob/main/doc/linter-rules/{rule}.md"
            };

            return builder.ToString();
        }

        private static string GetErrorCodeToolTip(string errorCode)
        {
            return $"Get help for '{errorCode}'";
        }
        #endregion
    }
}
