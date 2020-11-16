#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics.Helpers
{
    public class BoxPositionIndexed
    {
        public BoxPositionIndexed(BoxPosition boxPosition, int index)
        {
            BPos = boxPosition;
            Index = index;
        }

        public BoxPositionIndexed(Vector3D vPos, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth, int index)
        {
            BPos = new BoxPosition(vPos, axisLength, axisWidth);
            Index = index;
        }
        public BoxPosition BPos { get; set; }
        public int Index { get; set; }
    }

    public class BPosIndexedComparer : IComparer<BoxPositionIndexed>
    {
        int IComparer<BoxPositionIndexed>.Compare(BoxPositionIndexed bpi1, BoxPositionIndexed bpi2)
        {
            if (bpi1.Index > bpi2.Index) return 1;
            else if (bpi1.Index == bpi2.Index) return 0;
            else return -1;
        }
    }
}
