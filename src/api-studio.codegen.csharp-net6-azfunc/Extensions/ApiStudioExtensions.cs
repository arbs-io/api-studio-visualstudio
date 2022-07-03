// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using Microsoft.VisualStudio.Modeling;

namespace ApiStudioIO.CodeGen.CSharpNet6AzFunc
{
    public static class ApiStudioExtensions
    {
        internal static ApiStudio LoadDiagram(string eaiDiagramFilePath)
        {
            var store = new Store(
                typeof(ApiStudioIODomainModel));

            ApiStudio eaiDiagram;
            // All Store changes must be in a Transaction:
            using (var t =
                   store.TransactionManager.BeginTransaction("ApiStudioExtensions.LoadDiagram"))
            {
                eaiDiagram = ApiStudioIOSerializationHelper.Instance
                    .LoadModel(store, eaiDiagramFilePath, null, null, null);
                t.Commit(); //We haven't made change, just need the model reference so rollback our transaction.
            }

            return eaiDiagram;
        }
    }
}