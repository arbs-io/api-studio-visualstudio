// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Shell.TableControl;
using Microsoft.VisualStudio.Shell.TableManager;

namespace ApiStudioIO.Vs.ErrorList
{
    public class ApiStudioLinkIssueDataSource : ITableDataSource
    {
        private readonly List<SinkManager> _managers = new List<SinkManager>();
        private readonly Dictionary<string, TableEntriesSnapshot> _snapshots = new Dictionary<string, TableEntriesSnapshot>();
        public static IReadOnlyCollection<string> Columns { get; } = new[]
        {
            StandardTableColumnDefinitions.DetailsExpander,
            StandardTableColumnDefinitions.ErrorCategory,
            StandardTableColumnDefinitions.ErrorSeverity,
            StandardTableColumnDefinitions.ErrorCode,
            StandardTableColumnDefinitions.ErrorSource,
            StandardTableColumnDefinitions.BuildTool,
            StandardTableColumnDefinitions.Text,
            StandardTableColumnDefinitions.DocumentName,
            StandardTableColumnDefinitions.Line,
            StandardTableColumnDefinitions.Column
        };

        #region ITableDataSource members

        public string SourceTypeIdentifier => StandardTableDataSources.ErrorTableDataSource;
    
        public string Identifier => "ApiStudio";

        public string DisplayName => "ApiStudio";

        public IDisposable Subscribe(ITableDataSink sink)
        {
            var manager = new SinkManager(sink, RemoveSinkManager);

            AddSinkManager(manager);

            return manager;
        }

        #endregion

        private void AddSinkManager(SinkManager manager)
        {
            lock (_managers)
            {
                _managers.Add(manager);
            }
        }

        private void RemoveSinkManager(SinkManager manager)
        {
            lock (_managers)
            {
                _managers.Remove(manager);
            }
        }
    
        private void UpdateAllSinks()
        {
            lock (_managers)
            {
                foreach (var manager in _managers)
                {
                    manager.UpdateSink(_snapshots.Values);
                }
            }
        }
    
        public void AddErrors(string projectName, IEnumerable<ErrorListItem> errors)
        {
            if (errors == null || !errors.Any())
            {
                return;
            }
    
            var cleanErrors = errors.Where(e => (e != null) && !string.IsNullOrEmpty(e.FileName));
    
            lock (_snapshots)
            {
                foreach (var error in cleanErrors.GroupBy(e => e.FileName))
                {
                    _snapshots[error.Key] = new TableEntriesSnapshot(projectName, error.Key, error);
                }
            }
    
            UpdateAllSinks();
        }
    
        public void CleanAllErrors()
        {
            lock (_snapshots)
            {
                lock (_managers)
                {
                    foreach (var manager in _managers)
                    {
                        manager.Clear();
                    }
                }

                foreach (var snapshot in _snapshots.Values)
                {
                    snapshot.Dispose();
                }

                _snapshots.Clear();
            }
        }
    }
}
