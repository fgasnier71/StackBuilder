#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    class DrawableComparerSimplifiedPainterAlgo : IComparer<Drawable>
    {
        #region Constructor
        public DrawableComparerSimplifiedPainterAlgo()
        {
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Drawable d1, Drawable d2)
        {
            Vector3D position1 = Pos(d1);
            Vector3D position2 = Pos(d2);

            if (position1.Z > position2.Z)
                return 1;
            else if (position1.Z == position2.Z)
                    return 0;
            else
                return -1;
        }
        #endregion

        #region Helpers
        Vector3D Pos(Drawable d)
        {
            if (d is Box b) return b.Position;
            if (d is Cylinder c) return c.Position.XYZ;
            return Vector3D.Zero;        
        }
        #endregion
    }
}
