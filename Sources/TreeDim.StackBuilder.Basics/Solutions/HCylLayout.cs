#region Using directives
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region Limit enum : the different reasons the stacking process might be stopped
    public enum Limit
    {
        MAXHEIGHTREACHED
        , MAXWEIGHTREACHED
        , MAXNUMBERREACHED
        , UNKNOWN
    };
    #endregion
    #region HCylLayout
    public class HCylLayout : IDisposable
    {
        #region Constructor
        public HCylLayout(double cylDiameter, double cylLength, Vector3D dimContainer, string patternName, bool swapped)
        {
            CylDiameter = cylDiameter;
            CylLength = cylLength;
            DimContainer = dimContainer;
            PatternName = patternName;
            Swapped = swapped;
        }
        public HCylLayout(double cylDiameter, double cyLength, Vector3D dimContainer, string descriptor)
        {
            CylDiameter = cylDiameter;
            CylLength = CylLength;
            DimContainer = dimContainer;
            ParseDescString(descriptor);
        }
        #endregion
        #region Public properties
        public double OffsetZ { get; set; } = 0.0;
        public string PatternName { get; private set; } = string.Empty;
        public double CylDiameter { get; set; }
        public double CylRadius => 0.5 * CylDiameter;
        public double CylLength { get; set; }
        public Vector3D DimContainer { get; private set; }
        public double StackingLength => DimContainer.X;
        public double StackingWidth => DimContainer.Y;
        public double StackingHeight => DimContainer.Z;
        public bool Swapped { get; protected set; } = false;
        public BBox3D BBox => BBoxOffset(Vector3D.Zero);
        public BBox3D BBoxOffset(Vector3D offset)
        {
            var bb = BBox3D.Initial;
            foreach (var cp in Positions)
            {
                CylPosition cpOffset = cp + offset;
                bb.Extend(cpOffset.BBox(CylRadius, CylLength));
            }
            return bb;
        }
        public string Descriptor => $"{PatternName}|{SwappedString}";
        public string Tooltip => $"{Descriptor}";
        public Limit LimitReached { get; set; }
        public double RowSpacing { get; set; } = 0;
        #endregion
        #region Helpers
        private string SwappedString => Swapped ? "t" : "f";
        public void Clear() => Positions.Clear();
        public bool IsValidPosition(CylPosition cylPosition)
        {
            switch (cylPosition.Direction)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    if (cylPosition.XYZ.X - CylLength < 0.0) return false;
                    if (cylPosition.XYZ.X > StackingLength) return false;
                    if (cylPosition.XYZ.Y - CylRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + CylRadius > StackingWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    if (cylPosition.XYZ.X < 0.0) return false;
                    if (cylPosition.XYZ.X - CylLength > StackingLength) return false;
                    if (cylPosition.XYZ.Y - CylRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + CylRadius > StackingWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    if (cylPosition.XYZ.Y - CylLength < 0) return false;
                    if (cylPosition.XYZ.Y > StackingWidth) return false;
                    if (cylPosition.XYZ.X - CylRadius < 0) return false;
                    if (cylPosition.XYZ.X + CylRadius > StackingLength) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    if (cylPosition.XYZ.Y < 0) return false;
                    if (cylPosition.XYZ.Y + CylLength > StackingWidth) return false;
                    if (cylPosition.XYZ.X - CylRadius < 0) return false;
                    if (cylPosition.XYZ.X + CylRadius > StackingLength) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }
        public bool IntersectWithContent(CylPosition cylPosition)
        {
            Vector3D cylDirection = HalfAxis.ToVector3D(cylPosition.Direction);
            foreach (CylPosition c in Positions)
            {
                Vector3D vDiff = c.XYZ - cylPosition.XYZ;
                double axisProj = Vector3D.DotProduct(cylDirection, vDiff);
                Vector3D vDiffProj = vDiff - axisProj * cylDirection;
                if (axisProj < CylLength && vDiffProj.GetLength() < CylRadius)
                    return true;
            }
            return false;
        }
        private void ParseDescString(string desc)
        {
            Regex r = new Regex(@"(?<name>.*)\|(?<swap>.*)", RegexOptions.Singleline);
            Match m = r.Match(desc);
            if (m.Success)
            {
                PatternName = m.Result("${name}");
                Swapped = string.Equals("t", m.Result("${swap}"), StringComparison.CurrentCultureIgnoreCase);
            }
            else
                throw new Exception("Failed to parse layout descriptor");
        }
        #endregion
        #region IDisposable
        public void Dispose() {}
        #endregion
        #region Data members
        public List<CylPosition> Positions { get; set; } = new List<CylPosition>();
        #endregion
    }
    #endregion

    #region HCylLayout comparer
    public class HCylLayoutComparer : Comparer<HCylLayout>
    {
        public override int Compare(HCylLayout x, HCylLayout y)
        {
            if (x.Positions.Count < y.Positions.Count) return 1;
            else if (x.Positions.Count == y.Positions.Count) return 0;
            else return -1;
        }
    }
    #endregion
}
