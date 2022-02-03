namespace ApiStudioIO.CodeGeneration.Extensions
{
    using Microsoft.VisualStudio.Modeling;

    public static class ApiStudioExtensions
    {
        internal static ApiStudio LoadDiagram(string eaiDiagramFilePath)
        {
            Store store = new Store(
                typeof(ApiStudioIODomainModel));

            ApiStudio eaiDiagram;
            // All Store changes must be in a Transaction:
            using (Transaction t =
                store.TransactionManager.BeginTransaction("ApiStudioExtensions.LoadDiagram"))
            {
                eaiDiagram =
                    ApiStudioIOSerializationHelper.Instance.
                        LoadModel(store, eaiDiagramFilePath, null, null, null);
                t.Commit();   //We haven't made change, just need the model reference so rollback our transaction.
            }
            return eaiDiagram;
        }
    }
}