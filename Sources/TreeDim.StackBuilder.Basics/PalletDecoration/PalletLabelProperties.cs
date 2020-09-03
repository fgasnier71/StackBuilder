#region Using directives
using Sharp3D.Math.Core;

using System.Drawing;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletLabelProperties : ItemBaseNamed
    {
        #region Constructors
        public PalletLabelProperties(Document doc)
            : base(doc)
        { 
        }
        public PalletLabelProperties(Document doc, string name, string description,
            Vector2D dimensions, double weight,
            Color color, Bitmap bmp)
            : base(doc, name, description)
        {
            Dimensions = dimensions;
            Weight = weight;
            Color = color;
            Bitmap = bmp;
        }
        #endregion

        #region Public properties
        public Vector2D Dimensions { get; set; }
        public double Weight { get; set; }
        public Color Color { get; set; } = Color.White;
        public Bitmap Bitmap { get; set; }
        #endregion
    }

    public class PalletLabelInst
    {
        public PalletLabelInst(PalletLabelProperties palletLabelProperties, Vector2D position, HalfAxis.HAxis side)
        {
            PalletLabelProperties = palletLabelProperties;
            Position = position;
            Side = side;
        }
        public PalletLabelProperties PalletLabelProperties { get; set; }
        public Vector2D Position { get; set; }
        public HalfAxis.HAxis Side { get; set; }
        public BoxPosition ToBoxPosition(BBox3D bbox)
        {
            Vector3D vOrig = Vector3D.Zero;
            HalfAxis.HAxis axis = HalfAxis.HAxis.AXIS_Y_P;

            switch (Side)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    vOrig = new Vector3D(bbox.PtMin.X, bbox.PtMax.Y, bbox.PtMin.Z);
                    axis = HalfAxis.HAxis.AXIS_Y_N;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    vOrig = new Vector3D(bbox.PtMin.X, bbox.PtMin.Y, bbox.PtMin.Z);
                    axis = HalfAxis.HAxis.AXIS_X_P;
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    vOrig = new Vector3D(bbox.PtMax.X, bbox.PtMin.Y, bbox.PtMin.Z);
                    axis = HalfAxis.HAxis.AXIS_Y_P;
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    vOrig = new Vector3D(bbox.PtMax.X, bbox.PtMax.Y, bbox.PtMin.Z);
                    axis = HalfAxis.HAxis.AXIS_X_N;
                    break;
                default: break;
            }
            return new BoxPosition(vOrig + Position.X * HalfAxis.ToVector3D(axis) + Position.Y * Vector3D.ZAxis, axis, HalfAxis.HAxis.AXIS_Z_P);
        }
    }
}
