namespace ApiStudioIO
{
    using Microsoft.VisualStudio.Modeling.Diagrams;

    public partial class ApiStudioDiagram
    {
        protected override void InitializeInstanceResources()
        {
            IncludeBackgroundImage();

            base.InitializeInstanceResources();
        }

        private void IncludeBackgroundImage()
        {
            ImageField imageField = new ImageField("BackgroundImage",
                Properties.Resources.BackgroundImage)
            {
                DefaultFocusable = false,
                DefaultSelectable = false,
                DefaultVisibility = true,
                DefaultUnscaled = true
            };

            shapeFields.Add(imageField);
            imageField.AnchoringBehavior.SetTopAnchor(AnchoringBehavior.Edge.Top, 0.35);
            imageField.AnchoringBehavior.SetLeftAnchor(AnchoringBehavior.Edge.Left, 0.01);
        }
    }
}