#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class ViewerHLayeredCrate : IDisposable
    {
        #region Constructor
        public ViewerHLayeredCrate(Vector3D dimOuter)
        {
            Dimensions = dimOuter;
        }
        #endregion
        #region Drawing
        public void Draw(Graphics3D graphics, IEnumerable<Box> boxes, bool selected)
        {
            graphics.BackgroundColor = selected ? Color.LightBlue : Color.White;
            graphics.CameraPosition = Graphics3D.Corner_0;
            // draw case (inside)
            Case crate = new Case(0, Dimensions, Dimensions);
            crate.DrawInside(graphics, Transform3D.Identity);

            var bbox = BBox3D.Initial;
            foreach (var b in boxes)
            {
                graphics.AddBox(b);
                bbox.Extend(b.BBox);
            }
            graphics.Flush();
            crate.DrawEnd(graphics);
        }
        #endregion
        #region IDisposable
        public void Dispose() {}
        #endregion
        #region Data members
        public Vector3D Dimensions { get; set; }
        #endregion
    }
}
