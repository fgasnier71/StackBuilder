#region Using directives
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class Strapper : Drawable
    {
        public Strapper(Vector3D axis, double width, Color color, List<Vector3D> pts)
        {
            Axis = axis;
            HullPoints = pts;
            Width = width;
            Color = color;
        }
        public override void Draw(Graphics3D graphics)
        {
        }
        public override void DrawBegin(Graphics3D graphics)
        {
            Vector3D ptPrev = HullPoints[0];
            for (int i = 1; i < HullPoints.Count; ++i)
            {
                AddFace(graphics, ptPrev, HullPoints[i]);
                ptPrev = HullPoints[i];
            }
            AddFace(graphics, ptPrev,  HullPoints[0] );
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            Vector3D ptPrev = HullPoints[0];
            for (int i = 1; i < HullPoints.Count; ++i)
            {
                AddFace(graphics, ptPrev, HullPoints[i]);
                ptPrev = HullPoints[i];
            }
            AddFace(graphics, ptPrev, HullPoints[0]);
        }
        private void AddFace(Graphics3D graphics, Vector3D p0, Vector3D p1)
        {
            var pt0 = p0 + 0.5 * Width * Axis;
            var pt1 = p0 - 0.5 * Width * Axis;
            var pt2 = p1 - 0.5 * Width * Axis;
            var pt3 = p1 + 0.5 * Width * Axis;
            graphics.AddFace(new Face(0, new Vector3D[] { pt0, pt1, pt2, pt3 }, Color, Color.Black, "STRAPPER"));
        }

        public Vector3D Axis { get; set; }
        public double Width { get; set; }
        public Color Color { get; set; }
        public List<Vector3D> HullPoints { get; set; }
    }
}
