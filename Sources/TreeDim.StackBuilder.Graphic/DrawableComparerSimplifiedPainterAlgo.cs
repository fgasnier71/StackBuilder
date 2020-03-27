#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region Drawable comparison
    internal class DrawableComparerSimplifiedPainterAlgo : IComparer<Drawable>
    {
        #region Constructor
        public DrawableComparerSimplifiedPainterAlgo(Transform3D transform)
        {
            Transform = transform;
        }
        #endregion
        #region Implementation IComparer
        public int Compare(Drawable d1, Drawable d2)
        {
            if (d1.Center.Z > d2.Center.Z)
                return 1;
            else if (d1.Center.Z == d2.Center.Z)
            {
                if (Transform.transform(d1.Center).Z < Transform.transform(d2.Center).Z)
                    return 1;
                else if (Transform.transform(d1.Center).Z == Transform.transform(d2.Center).Z)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion
        #region Data members
        public Transform3D Transform { get; set; } = Transform3D.Identity;
        #endregion
    }
    #endregion
}
