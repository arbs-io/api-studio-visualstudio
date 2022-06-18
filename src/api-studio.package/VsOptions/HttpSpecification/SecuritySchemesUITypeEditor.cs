// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.VsOptions.Helper;

namespace ApiStudioIO.VsOptions.HttpSpecification
{
    internal class AudienceUITypeEditor : ApiStudioUITypeEditor
    {
        private static readonly string[] audiencePatterns =
        {
            "Private",
            "Partner",
            "Public"
        };

        public AudienceUITypeEditor() : base(audiencePatterns)
        {
        }
    }
}