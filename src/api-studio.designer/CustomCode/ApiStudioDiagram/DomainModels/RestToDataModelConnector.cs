// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

namespace ApiStudioIO
{
    public partial class RestToDataModelConnector
    {
        private HttpApi _httpApi;
        protected override void OnDeleted()
        {
            base.OnDeleted();

            if (_httpApi != null)
                _httpApi.SetDefaults();
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            foreach (var node in this.Nodes)
            {
                if (node.ModelElement is HttpApi httpApi)
                    _httpApi = httpApi;
            }
        }
    }
}