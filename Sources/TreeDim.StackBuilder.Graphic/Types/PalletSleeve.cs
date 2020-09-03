#region Using directives
using Sharp3D.Math.Core;
using System.Drawing;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class PalletSleeve : Drawable
    {
        #region Constructor
        public PalletSleeve(uint pickId, BBox3D bbox, Color color)
            : base(pickId)
        {
            Bbox = bbox;
            ColorFill = color;
        }
        #endregion

        #region Drawable override
        public override void Draw(Graphics3D graphics)
        {
            var g = graphics.Graphics;
            var viewDir = graphics.ViewDirection;

            Face[] faces = Faces;
            for (int i = 0; i < 4; ++i)
            {
                // visible ?
                if (!faces[i].IsVisible(viewDir)) continue;
                // color
                faces[i].ColorFill = ColorFill;
                // points
                Vector3D[] points3D = faces[i].Points;
                Point[] pt = graphics.TransformPoint(points3D);
                //  draw solid face
                Brush brush = new SolidBrush(faces[i].ColorGraph(graphics));
                g.FillPolygon(brush, pt);
                // draw path
                Brush brushPath = new SolidBrush(faces[i].ColorPath);
                Pen penPathThick = new Pen(brushPath, 1.5f);
                int ptCount = pt.Length;
                for (int j = 1; j < ptCount; ++j)
                    g.DrawLine(penPathThick, pt[j - 1], pt[j]);
                g.DrawLine(penPathThick, pt[ptCount - 1], pt[0]);
            }
        }
        public override void DrawBegin(Graphics3D graphics)
        {
            base.DrawBegin(graphics);
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            Face[] faces = Faces;
            for (int i = 0; i < 4; ++i)
                graphics.AddFace(Faces[i]);
        }
        #endregion

        #region Faces
        public virtual Face[] Faces
        {
            get
            {
                Vector3D lengthAxis = HalfAxis.ToVector3D(AxisLength);
                Vector3D widthAxis = HalfAxis.ToVector3D(AxisWidth);
                Vector3D heightAxis = Vector3D.CrossProduct(lengthAxis, widthAxis);
                Vector3D position = Bbox.PtMin;
                Vector3D dimensions = Bbox.DimensionsVec;

                var points = new Vector3D[8];
                points[0] = position;
                points[1] = position + dimensions.X * lengthAxis;
                points[2] = position + dimensions.X * lengthAxis + dimensions.Y * widthAxis;
                points[3] = position + dimensions.Y * widthAxis;

                points[4] = position + dimensions.Z * heightAxis;
                points[5] = position + dimensions.Z * heightAxis + dimensions.X * lengthAxis;
                points[6] = position + dimensions.Z * heightAxis + dimensions.X * lengthAxis + dimensions.Y * widthAxis;
                points[7] = position + dimensions.Z * heightAxis + dimensions.Y * widthAxis;

                var faces = new Face[4];
                faces[0] = new Face(PickId, new Vector3D[] { points[3], points[0], points[4], points[7] }, ColorFill, Color.Black, "SLEEVE", true); // AXIS_X_N
                faces[1] = new Face(PickId, new Vector3D[] { points[1], points[2], points[6], points[5] }, ColorFill, Color.Black, "SLEEVE", true); // AXIS_X_P
                faces[2] = new Face(PickId, new Vector3D[] { points[0], points[1], points[5], points[4] }, ColorFill, Color.Black, "SLEEVE", true); // AXIS_Y_N
                faces[3] = new Face(PickId, new Vector3D[] { points[2], points[3], points[7], points[6] }, ColorFill, Color.Black, "SLEEVE", true); // AXIS_Y_P
                return faces;
            }
        }
        #endregion

        #region Public properties
        public Color ColorFill { get; set; }
        public Color ColorPath => Color.Black;
        public BBox3D Bbox { get; set;  }
        public HalfAxis.HAxis AxisLength { get; set; } = HalfAxis.HAxis.AXIS_X_P;
        public HalfAxis.HAxis AxisWidth { get; set; } = HalfAxis.HAxis.AXIS_Y_P;
        #endregion


    }
}
