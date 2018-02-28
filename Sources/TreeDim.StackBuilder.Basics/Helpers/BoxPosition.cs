#region Using directives
using System;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// Box position
    /// </summary>
    public struct BoxPosition
    {
        #region Constructor
        public BoxPosition(Vector3D vPosition, HalfAxis.HAxis dirLength = HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis dirWidth = HalfAxis.HAxis.AXIS_Y_P)
        {
            Position = vPosition;
            DirectionLength = dirLength;
            DirectionWidth = dirWidth;
        }
        #endregion

        #region Public properties
        public Vector3D Position { get; set; }
        public HalfAxis.HAxis DirectionLength { get; set; }
        public HalfAxis.HAxis DirectionWidth { get; set; }
        public HalfAxis.HAxis DirectionHeight
        {
            get
            {
                if (!IsValid)
                    throw new Exception("Invalid position -> Can not compute DirectionHeight.");
                return HalfAxis.ToHalfAxis(Vector3D.CrossProduct(HalfAxis.ToVector3D(DirectionLength), HalfAxis.ToVector3D(DirectionWidth)));
            }
        }
        public bool IsValid => DirectionLength != DirectionWidth; 
        #endregion

        #region Static properties
        public static BoxPosition Zero => new BoxPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
        #endregion

        #region Transformation
        public Transform3D Transformation
        {
            get
            {
                // build 4D matrix
                Vector3D vAxisLength = HalfAxis.ToVector3D(DirectionLength);
                Vector3D vAxisWidth = HalfAxis.ToVector3D(DirectionWidth);
                Vector3D vAxisHeight = Vector3D.CrossProduct(vAxisLength, vAxisWidth);
                Matrix4D mat = Matrix4D.Identity;
                mat.M11 = vAxisLength.X; mat.M12 = vAxisWidth.X; mat.M13 = vAxisHeight.X; mat.M14 = Position.X;
                mat.M21 = vAxisLength.Y; mat.M22 = vAxisWidth.Y; mat.M23 = vAxisHeight.Y; mat.M24 = Position.Y;
                mat.M31 = vAxisLength.Z; mat.M32 = vAxisWidth.Z; mat.M33 = vAxisHeight.Z; mat.M34 = Position.Z;
                return new Transform3D(mat);
            }
        }
        public static BoxPosition Transform(BoxPosition boxPosition, Transform3D transform)
        {
            if (!boxPosition.IsValid)
                throw new Exception("Invalid box position : can not transform");
            return new BoxPosition(
                transform.transform(boxPosition.Position)
                , HalfAxis.Transform(boxPosition.DirectionLength, transform)
                , HalfAxis.Transform(boxPosition.DirectionWidth, transform)
                );
        }
        public BoxPosition Transform(Transform3D transform)
        {
            return Transform(this, transform);
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            return string.Format("{0} | ({1},{2})", Position, HalfAxis.ToString(DirectionLength), HalfAxis.ToString(DirectionWidth));
        }
        #endregion
    }

    public struct BoxPositionIndexed
    {
        #region Constructor
        public BoxPositionIndexed(Vector3D vPosition, int orientation)
        {
            Position = vPosition;
            Orientation = orientation;
        }
        #endregion

        #region Public properties
        public Vector3D Position { get; set; }
        public int Orientation { get; set; }
        public BoxPosition ToBoxPosition(Vector3D dimensions)
        {
                // 1 -> L W H
                // 2 -> W L H
                // 3 -> W H L
                // 4 -> H W L
                // 5 -> L H W
                // 6 -> H L W

                switch (Orientation)
                {
                    case 1: return new BoxPosition(Position, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                    case 2: return new BoxPosition(Position + dimensions.Y * Vector3D.XAxis, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                    case 3: return new BoxPosition(Position + dimensions.Z * Vector3D.YAxis, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Z_P);
                    case 4: return new BoxPosition(Position, HalfAxis.HAxis.AXIS_Z_P, HalfAxis.HAxis.AXIS_X_P);
                    case 5: return new BoxPosition(Position, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_Z_P);
                    case 6: return new BoxPosition(Position + dimensions.Z * Vector3D.XAxis, HalfAxis.HAxis.AXIS_Z_P, HalfAxis.HAxis.AXIS_Y_P);
                    default: throw new Exception("BoxPositionIndexed : Invalid orientation!");
                }
        }
        #endregion

        #region Object method override
        public override string ToString()
        {
            return $"{Position} | {Orientation}";
        }
        #endregion
    }
}
