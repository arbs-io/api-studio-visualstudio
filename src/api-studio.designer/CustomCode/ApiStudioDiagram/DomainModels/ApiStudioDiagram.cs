// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Properties;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ApiStudioIO
{
    public partial class ApiStudioDiagram
    {
        protected override void InitializeInstanceResources()
        {
            IncludeBackgroundImage();

            base.InitializeInstanceResources();
        }

        private static void IncludeBackgroundImage()
        {
            var imageField = new ImageField("BackgroundImage",
                Resources.BackgroundImage)
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