#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region Cylinder comparison
    public class CylinderComparerSimplifiedPainterAlgo : IComparer<Cyl>
    {
        #region Constructor
        public CylinderComparerSimplifiedPainterAlgo(Transform3D transform)
        {
            Transform = transform;
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Cyl c1, Cyl c2)
        {
            if (Vertical)
            {
                if (c1.Position.XYZ.Z > c2.Position.XYZ.Z)
                    return 1;
                else if (c1.Position.XYZ.Z == c2.Position.XYZ.Z)
                {
                    if (Transform.transform(c1.Position.XYZ).Z < Transform.transform(c2.Position.XYZ).Z)
                        return 1;
                    else if (Transform.transform(c1.Position.XYZ).Z == Transform.transform(c2.Position.XYZ).Z)
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
            {
                if (Transform.transform(c1.Position.XYZ).Z < Transform.transform(c2.Position.XYZ).Z)
                    return 1;
                else if (Transform.transform(c1.Position.XYZ).Z == Transform.transform(c2.Position.XYZ).Z)
                    return 0;
                else
                    return -1;
            }
        }
        #endregion

        #region Data members
        private Transform3D Transform { get; set; }
        bool Vertical { get; set; } = false;
        #endregion
    }
    #endregion

    #region ImageInst comparison
    public class ImageInstComparerSimplifierPainterAlgo : IComparer<ImageInst>
    {
        #region Constructor
        public ImageInstComparerSimplifierPainterAlgo(Transform3D transform)
        {
            Transf = transform;
        }
        #endregion

        #region Implementation comparer
        public int Compare(ImageInst img1, ImageInst img2)
        {
            if (img1.PointBase.Z > img2.PointBase.Z)
                return 1;
            else if (img1.PointBase.Z == img2.PointBase.Z)
            {
                if (Transf.transform(img1.PointBase).Z < Transf.transform(img2.PointBase).Z)
                    return 1;
                else if (Transf.transform(img1.PointBase).Z == Transf.transform(img2.PointBase).Z)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion

        #region Data members
        Transform3D Transf { get; set; }
        #endregion
    }
    #endregion


}
