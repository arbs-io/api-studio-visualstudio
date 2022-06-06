// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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

        private void IncludeBackgroundImage()
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