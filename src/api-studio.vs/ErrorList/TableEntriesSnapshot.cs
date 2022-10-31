// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Shell.TableManager;

namespace ApiStudioIO.Vs.ErrorList
{
    public class TableEntriesSnapshot : TableEntriesSnapshotBase
    {
        private readonly List<ErrorListItem> _errors;
        public TableEntriesSnapshot(string projectName, string filePath, IEnumerable<ErrorListItem> errors)
        {
            ProjectName = projectName;
            FilePath = filePath;
            _errors = errors.ToList();
        }

        #region ITableEntriesSnapshot

        public string ProjectName { get; }
        public string FilePath { get; }
        public override int Count => _errors.Count;
        public override int VersionNumber { get; } = 1;

        public override bool TryGetValue(int index, string keyName, out object content)
        {
            if ((index < 0) || (index >= Count))
            {
                content = null;
                return false;
            }
    
            switch(keyName)
            {
            case StandardTableKeyNames.ProjectName:
                content = ProjectName;
                break;
    
            case StandardTableKeyNames.DocumentName:
                // We return the full file path here. The UI handles displaying only the filename.
                content = FilePath;
                break;
    
            case StandardTableKeyNames.Text:
                content = _errors[index].Message;
                break;
    
            case StandardTableKeyNames.Line:
                content = _errors[index].Line;
                break;
    
            case StandardTableKeyNames.ErrorCategory:
                content = _errors[index].ErrorCategory;
                break;
    
            case StandardTableKeyNames.ErrorSeverity:
                content = _errors[index].Severity;
                break;
    
            case StandardTableKeyNames.ErrorCode:
                content = _errors[index].ErrorCode;
                break;
    
            case StandardTableKeyNames.BuildTool:
                content = "ApiStudio";
                break;
    
            case StandardTableKeyNames.HelpLink:
                content = _errors[index].HelpLink;
                break;
    
            case StandardTableKeyNames.ErrorCodeToolTip:
                content = _errors[index].ErrorCodeToolTip;
                break;
    
            default:
                content = null;
                return false;
            }
    
            return true;
        }

        #endregion
    }
}
