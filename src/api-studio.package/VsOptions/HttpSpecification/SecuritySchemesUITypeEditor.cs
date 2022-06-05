namespace ApiStudioIO.VsOptions.HttpSpecification
{
    using ApiStudioIO.VsOptions.Helper;

    class AudienceUITypeEditor : ApiStudioUITypeEditor
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
