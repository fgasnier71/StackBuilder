#region Using directives
using System.Collections.Generic;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class BoxPositionIndexed
    {
        public BoxPositionIndexed(BoxPosition boxPosition, int index)
        {
            BPos = boxPosition;
            Index = index;
        }
        public BoxPositionIndexed(BoxPositionIndexed boxPosition)
        {
            BPos = boxPosition.BPos;
            Index = boxPosition.Index;

        }
        public BoxPositionIndexed(Vector3D vPos, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth, int index)
        {
            BPos = new BoxPosition(vPos, axisLength, axisWidth);
            Index = index;
        }
        public BoxPositionIndexed Adjusted(Vector3D dimensions)
        {
            var boxPosTemp = new BoxPositionIndexed(BPos.Position, BPos.DirectionLength, BPos.DirectionWidth, Index);
            // reverse if oriented to Z- (AXIS_Z_N)
            if (BPos.DirectionHeight == HalfAxis.HAxis.AXIS_Z_N)
            {
                if (BPos.DirectionLength == HalfAxis.HAxis.AXIS_X_P)
                    boxPosTemp.BPos = new BoxPosition(BPos.Position + new Vector3D(0.0, -dimensions.Y, -dimensions.Z), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                else if (BPos.DirectionLength == HalfAxis.HAxis.AXIS_Y_P)
                    boxPosTemp.BPos = new BoxPosition(BPos.Position + new Vector3D(dimensions.Y, 0.0, -dimensions.Z), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                else if (BPos.DirectionLength == HalfAxis.HAxis.AXIS_X_N)
                    boxPosTemp.BPos = new BoxPosition(BPos.Position + new Vector3D(-dimensions.X, 0.0, -dimensions.Z), HalfAxis.HAxis.AXIS_X_P, BPos.DirectionWidth);
                else if (BPos.DirectionLength == HalfAxis.HAxis.AXIS_Y_N)
                    boxPosTemp.BPos = new BoxPosition(BPos.Position + new Vector3D(-dimensions.Y, 0.0, -dimensions.Z), HalfAxis.HAxis.AXIS_Y_N, HalfAxis.HAxis.AXIS_X_P);
            }
            return boxPosTemp;
        }
        public override string ToString() => $"{BPos.Position} | ({HalfAxis.ToString(BPos.DirectionLength)},{HalfAxis.ToString(BPos.DirectionWidth)}) | {Index}";
        public static BoxPositionIndexed Parse(string s)
        {
            string[] sArray = s.Split('|');
            var v = Vector3D.Parse(sArray[0]);
            string sOrientation = sArray[1];
            sOrientation = sOrientation.Trim();
            sOrientation = sOrientation.TrimStart('(');
            sOrientation = sOrientation.TrimEnd(')');
            string[] vOrientation = sOrientation.Split(',');
            var index = int.Parse(sArray[2]);
            return new BoxPositionIndexed(v, HalfAxis.Parse(vOrientation[0]), HalfAxis.Parse(vOrientation[1]), index);
        }
        public static List<BoxPositionIndexed> FromListBoxPosition(List<BoxPosition> boxPositions)
        {
            var listBoxPositionIndexed = new List<BoxPositionIndexed>();
            int counter = 0;
            foreach (var bp in boxPositions)
                listBoxPositionIndexed.Add(new BoxPositionIndexed(bp, ++counter));
            return listBoxPositionIndexed;
        }
        public static List<BoxPosition> ToListBoxPosition(List<BoxPositionIndexed> listboxPositionIndexed) => listboxPositionIndexed.ConvertAll(bpi => bpi.BPos);
        public static void Sort(ref List<BoxPositionIndexed> list)
        {
            list.Sort(
                delegate (BoxPositionIndexed bp1, BoxPositionIndexed bp2)
                {
                    if (bp1.Index > bp2.Index) return 1;
                    else if (bp1.Index == bp2.Index) return 0;
                    else return -1;
                });
        }
        public static void ReduceListBoxPositionIndexed(List<BoxPositionIndexed> listBPI, out List<BoxPositionIndexed> listBPIReduced, out Dictionary<int, int> dictIndexNumber)
        {
            listBPIReduced = new List<BoxPositionIndexed>();
            dictIndexNumber = new Dictionary<int, int>();

            foreach (var bpi in listBPI)
            {
                if (dictIndexNumber.ContainsKey(bpi.Index))
                    dictIndexNumber[bpi.Index] += 1;
                else
                {
                    listBPIReduced.Add(bpi);
                    dictIndexNumber.Add(bpi.Index, 1);
                }
            }
            Sort(ref listBPIReduced);
        }
        #region Data members
        public BoxPosition BPos { get; set; }
        public int Index { get; set; }
        #endregion
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
