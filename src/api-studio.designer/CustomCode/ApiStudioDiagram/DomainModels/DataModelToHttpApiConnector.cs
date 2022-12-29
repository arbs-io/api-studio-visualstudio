// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

namespace ApiStudioIO
{
    public partial class DataModelToHttpApiConnector
    {
        private HttpApi _httpApi;
        protected override void OnDeleted()
        {
            base.OnDeleted();

            _httpApi?.SetDefaults();
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            foreach (var node in Nodes)
            {
                if (node.ModelElement is HttpApi httpApi)
                    _httpApi = httpApi;
            }
        }
    }
}