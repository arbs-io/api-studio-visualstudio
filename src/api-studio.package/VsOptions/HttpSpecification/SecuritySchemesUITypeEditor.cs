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