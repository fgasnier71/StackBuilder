#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// Cylinder position
    /// </summary>
    public struct CylPosition
    {
        #region Constructor
        public CylPosition(Vector3D vPosition, HalfAxis.HAxis axis)
        {
            XYZ = vPosition;
            Direction = axis;        
        }
        #endregion

        #region Public properties
        public Vector3D XYZ { get; set; }
        public HalfAxis.HAxis Direction { get; set; }
        public Transform3D Transf
        {
            get
            {
                Matrix4D mat = new Matrix4D();
                Vector4D vt = new Vector4D(XYZ.X, XYZ.Y, XYZ.Z, 1.0);
                switch (Direction)
                {
                    case HalfAxis.HAxis.AXIS_X_N: mat = new Matrix4D(new Vector4D(-1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, -1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_X_P: mat = new Matrix4D(new Vector4D(1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Y_N: mat = new Matrix4D(new Vector4D(0.0, -1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, -1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Y_P: mat = new Matrix4D(new Vector4D(0.0, 1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Z_N: mat = new Matrix4D(new Vector4D(0.0, 0.0, -1.0, 0.0), new Vector4D(-1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Z_P: mat = new Matrix4D(new Vector4D(0.0, 0.0, 1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), vt); break;
                    default: break;
                }
                return new Transform3D(mat);
            }
        }
        public BBox3D BBox(double radius, double length)
        {
            Transform3D t = Transf;
            Vector3D[] pts = new Vector3D[]
                {
                    new Vector3D(0.0, -radius, -radius),
                    new Vector3D(0.0, -radius, radius),
                    new Vector3D(0.0, radius, -radius),
                    new Vector3D(0.0, radius, radius),
                    new Vector3D(length, -radius, -radius),
                    new Vector3D(length, -radius, radius),
                    new Vector3D(length, radius, -radius),
                    new Vector3D(length, radius, radius)
                };
            BBox3D bbox = new BBox3D();
            foreach (Vector3D pt in pts)
                bbox.Extend(t.transform(pt));
            return bbox;
        }
        public CylPosition Transform(Transform3D transf)
            => new CylPosition(transf.transform(XYZ), HalfAxis.Transform(Direction, transf));
        public static CylPosition operator +(CylPosition cp, Vector3D v) => new CylPosition(cp.XYZ + v, cp.Direction);
        #endregion

        #region Transformation
        public static CylPosition Transform(CylPosition cylPosition, Transform3D transform)
        {
            return new CylPosition(
                transform.transform(cylPosition.XYZ),
                HalfAxis.ToHalfAxis(
                    transform.transformRot(HalfAxis.ToVector3D(cylPosition.Direction))
                    )
                );
        }
        #endregion
    }
}
