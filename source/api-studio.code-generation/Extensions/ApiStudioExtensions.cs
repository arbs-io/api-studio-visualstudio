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
                store.TransactionManager.BeginTransaction("Load model"))
            {
                eaiDiagram =
                    ApiStudioIOSerializationHelper.Instance.
                        LoadModel(store, eaiDiagramFilePath, null, null, null);
                t.Commit();   //We haven't made change, just need the model reference so rollback our transaction.
            }
            return eaiDiagram;
        }

        //public static string HttpResponse(this HttpApi httpApi, Resource resource, out string successHttpStatus)
        //{
        //    var responseModel = httpApi.DataModels.FirstOrDefault();
        //    successHttpStatus = "";
        //    var sb = new StringBuilder();
        //    foreach (var response in httpApi.ResponseStatusCodes)
        //    {
        //        var httpStatus = $"{response.HttpStatus}";

        //        if (response.Type == "Success")
        //        {
        //            if (responseModel != null)
        //            {
        //                //var responseType = "";
        //                //if (resource is ResourceCollection && ((ResourceCollection)resource).UsePagination)
        //                //    responseType = "ResponseSuccessPaged";
        //                //else
        //                //    responseType = "ResponseSuccess";

        //                //check is response is linked to collection\store, always return collection
        //                var successDataType = resource is ResourceCollection ? $"List<{responseModel.Name}>" : $"{responseModel.Name}";

        //                //sb.AppendLine($"\t\t[ProducesResponseType(statusCode: {httpStatus}, type: typeof({responseType}<{successDataType}>))]");
        //                sb.AppendLine($"\t\t[ProducesResponseType(statusCode: {httpStatus}, type: typeof({successDataType}))]");
        //            }
        //            else
        //            {
        //                sb.AppendLine($"\t\t[ProducesResponseType(statusCode: {httpStatus})]");
        //            }

        //            successHttpStatus = httpStatus;
        //        }
        //        else
        //        {
        //            sb.AppendLine($"\t\t[ProducesResponseType(statusCode: {httpStatus})]");
        //        }
        //    }

        //    return sb.ToString();
        //}

        //public static string GetHttpApiAuthorizationType(this ApiStudio eai)
        //{
        //    var httpApiAuthorizationType = "";
        //    switch (eai.HttpApiAuthorizationType)
        //    {
        //        case HttpApiAuthorizationTypes.Policy:
        //            httpApiAuthorizationType = "Policy";
        //            break;

        //        case HttpApiAuthorizationTypes.Roles:
        //            httpApiAuthorizationType = "Roles";
        //            break;
        //    }

        //    return httpApiAuthorizationType;
        //}

        //public static string GetModelNamespace(this ApiStudio eai, string modelName)
        //{
        //    // If there are no models then return empty string for Namespace
        //    if (eai.DataModeled.Any())
        //    {
        //        return $"using {modelName}.Domain.Model;";
        //    }

        //    return string.Empty;
        //}
    }
}