using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System;
using System.Collections.Generic;

namespace ApiStudioIO
{
    public partial class HttpApiShape
    {
        private const double ZOrderToFront = 1e6;
        private Dictionary<Guid, double> _shapeElementZOrder;

        public override void OnMouseEnter(DiagramPointEventArgs e)
        {
            base.OnMouseEnter(e);

            if (_shapeElementZOrder == null)
            {
                _shapeElementZOrder = new Dictionary<Guid, double>();
            }

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

            using (Transaction t = Store.TransactionManager.BeginTransaction("HttpApiShape.OnMouseEnter"))
            {
                SetIsExpandedValue(true);
                Expand();
                t.Commit();
            }
        }

        public override void OnMouseLeave(DiagramPointEventArgs e)
        {
            base.OnMouseLeave(e);

            foreach (var item in NestedChildShapes)
            {
                item.ZOrder = _shapeElementZOrder[item.Id];
            }

            foreach (var item in RelativeChildShapes)
            {
                item.ZOrder = _shapeElementZOrder[item.Id];
            }

            ZOrder = _shapeElementZOrder[Id];

            using (Transaction t = Store.TransactionManager.BeginTransaction("HttpApiShape.OnMouseLeave"))
            {
                SetIsExpandedValue(false);
                Collapse();
                t.Commit();
            }

            _shapeElementZOrder.Clear();
        }
    }
}