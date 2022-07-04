using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Linting;

namespace ApiStudioIO.Vs.ErrorList
{
    class ErrorListService
    {
        public static void ProcessLintingResults(IEnumerable<LintingResult> results, bool showErrorList)
        {
            var errors = results.Where(r => r.HasErrors).SelectMany(r => r.Errors);
            var clean = results.Where(r => !r.HasErrors).SelectMany(r => r.FileNames);

            if (errors.Any())
            {
                TableDataSource.Instance.AddErrors(errors);
                if (showErrorList)
                    TableDataSource.BringToFront();
            }

            TableDataSource.Instance.CleanErrors(clean);
        }
    }
}
