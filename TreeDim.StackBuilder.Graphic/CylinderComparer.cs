#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region Cylinder comparison
    public class CylinderComparerSimplifiedPainterAlgo : IComparer<Cylinder>
    {
        #region Constructor
        public CylinderComparerSimplifiedPainterAlgo(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Cylinder c1, Cylinder c2)
        {
            if (_vertical)
            {
                if (c1.Position.XYZ.Z > c2.Position.XYZ.Z)
                    return 1;
                else if (c1.Position.XYZ.Z == c2.Position.XYZ.Z)
                {
                    if (_transform.transform(c1.Position.XYZ).Z < _transform.transform(c2.Position.XYZ).Z)
                        return 1;
                    else if (_transform.transform(c1.Position.XYZ).Z == _transform.transform(c2.Position.XYZ).Z)
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
            {
                if (_transform.transform(c1.Position.XYZ).Z < _transform.transform(c2.Position.XYZ).Z)
                    return 1;
                else if (_transform.transform(c1.Position.XYZ).Z == _transform.transform(c2.Position.XYZ).Z)
                    return 0;
                else
                    return -1;
            }
        }
        #endregion

        #region Data members
        Transform3D _transform;
        bool _vertical = false;
        #endregion
    }
    #endregion

    #region ImageInst comparison
    public class ImageInstComparerSimplifierPainterAlgo : IComparer<ImageInst>
    {
        #region Constructor
        public ImageInstComparerSimplifierPainterAlgo(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation comparer
        public int Compare(ImageInst img1, ImageInst img2)
        {
            if (img1.PointBase.Z > img2.PointBase.Z)
                return 1;
            else if (img1.PointBase.Z == img2.PointBase.Z)
            {
                if (_transform.transform(img1.PointBase).Z < _transform.transform(img2.PointBase).Z)
                    return 1;
                else if (_transform.transform(img1.PointBase).Z == _transform.transform(img2.PointBase).Z)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion

        #region Data members
        Transform3D _transform;
        #endregion
    }
    #endregion


}
