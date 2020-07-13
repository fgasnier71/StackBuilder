#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region PalletCap
    public class PalletCap : Drawable
    {
        #region Data members
        private double[] _dim = new double[3];
        private BoxPosition _bPosition = new BoxPosition();
        private Color _color;
        #endregion

        #region Constructor
        public PalletCap(uint pickId, PalletCapProperties capProperties, BoxPosition bPosition)
            : base(0)
        {
            _dim[0] = capProperties.Length;
            _dim[1] = capProperties.Width;
            _dim[2] = capProperties.Height;

            _color = capProperties.Color;

            _bPosition = bPosition;
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _bPosition.Position; }
            set { _bPosition.Position = value; }
        }
        public Vector3D LengthAxis
        { get { return HalfAxis.ToVector3D(_bPosition.DirectionLength); } }
        public Vector3D WidthAxis
        { get { return HalfAxis.ToVector3D(_bPosition.DirectionWidth); } }
        public Vector3D HeightAxis
        { get { return Vector3D.CrossProduct(LengthAxis, WidthAxis); } }
        public double Length
        { get { return _dim[0]; } }
        public double Width
        { get { return _dim[1]; } }
        public double Height
        { get { return _dim[2]; } }
        public override Vector3D[] Points
        {
            get
            {
                Vector3D position = Position;
                Vector3D axisLength = LengthAxis;
                Vector3D axisWidth = WidthAxis;
                Vector3D heightAxis = HeightAxis;

                Vector3D[] points = new Vector3D[8];

                points[0] = position;
                points[1] = position + _dim[0] * axisLength;
                points[2] = position + _dim[0] * axisLength + _dim[1] * axisWidth;
                points[3] = position + _dim[1] * axisWidth;
                points[4] = position + _dim[2] * heightAxis;
                points[5] = position + _dim[2] * heightAxis + _dim[0] * axisLength;
                points[6] = position + _dim[2] * heightAxis + _dim[0] * axisLength + _dim[1] * axisWidth;
                points[7] = position + _dim[2] * heightAxis + _dim[1] * axisWidth;

                return points;
            }
        }
        public Face[] Faces
        {
            get
            {
                Vector3D[] points = Points;

                Face[] faces = new Face[6];
                faces[0] = new Face(PickId, new Vector3D[] { points[3], points[0], points[4], points[7] }, _color, Color.Black, "PALLETCAP"); // AXIS_X_N
                faces[1] = new Face(PickId, new Vector3D[] { points[1], points[2], points[6], points[5] }, _color, Color.Black, "PALLETCAP"); // AXIS_X_P
                faces[2] = new Face(PickId, new Vector3D[] { points[0], points[1], points[5], points[4] }, _color, Color.Black, "PALLETCAP"); // AXIS_Y_N
                faces[3] = new Face(PickId, new Vector3D[] { points[2], points[3], points[7], points[6] }, _color, Color.Black, "PALLETCAP"); // AXIS_Y_P
                faces[4] = new Face(PickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, _color, Color.Black, "PALLETCAP"); // AXIS_Z_N
                faces[5] = new Face(PickId, new Vector3D[] { points[4], points[5], points[6], points[7] }, _color, Color.Black, "PALLETCAP"); // AXIS_Z_P

                return faces;
            }
        }
        #endregion

        #region Drawable override
        public override void Draw(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        #endregion
    }
    #endregion
}
