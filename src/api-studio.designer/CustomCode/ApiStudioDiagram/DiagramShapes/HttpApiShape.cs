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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ApiStudioIO
{
    public partial class HttpApiShape
    {
        private const double ZOrderToFront = 1e6;
        private Dictionary<Guid, double> _shapeElementZOrder;

        public override void OnMouseEnter(DiagramPointEventArgs e)
        {
            base.OnMouseEnter(e);

            if (_shapeElementZOrder == null) _shapeElementZOrder = new Dictionary<Guid, double>();

            foreach (var item in NestedChildShapes)
            {
                _shapeElementZOrder.Add(item.Id, item.ZOrder);
                item.ZOrder += ZOrderToFront;
            }

            foreach (var item in RelativeChildShapes)
            {
                _shapeElementZOrder.Add(item.Id, item.ZOrder);
                item.ZOrder += ZOrderToFront;
            }

            _shapeElementZOrder.Add(Id, ZOrder);
            ZOrder += ZOrderToFront;

            using (var t = Store.TransactionManager.BeginTransaction("HttpApiShape.OnMouseEnter"))
            {
                SetIsExpandedValue(true);
                Expand();
                t.Commit();
            }
        }

        public override void OnMouseLeave(DiagramPointEventArgs e)
        {
            base.OnMouseLeave(e);

            foreach (var item in NestedChildShapes) item.ZOrder = _shapeElementZOrder[item.Id];

            foreach (var item in RelativeChildShapes) item.ZOrder = _shapeElementZOrder[item.Id];

            ZOrder = _shapeElementZOrder[Id];

            using (var t = Store.TransactionManager.BeginTransaction("HttpApiShape.OnMouseLeave"))
            {
                SetIsExpandedValue(false);
                Collapse();
                t.Commit();
            }

            _shapeElementZOrder.Clear();
        }
    }
}