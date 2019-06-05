#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    #region Limit enum : the different reasons the stacking process might be stopped
    public enum Limit
    {
        LIMIT_MAXHEIGHTREACHED
        , LIMIT_MAXWEIGHTREACHED
        , LIMIT_MAXNUMBERREACHED
        , LIMIT_UNKNOWN
    };
    #endregion

    class CylLoad : List<CylPosition>
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(CylLoad));
        #endregion

        #region Constructor
        public CylLoad(CylinderProperties cylProperties, PalletProperties palletProperties, HCylinderPalletConstraintSet constraintSet)
        {
            PalletLength = palletProperties.Length + constraintSet.OverhangX;
            PalletWidth = palletProperties.Width + constraintSet.OverhangY;
            PalletHeight = palletProperties.Height;
            RowSpacing = constraintSet.RowSpacing;
            Initialize(cylProperties);
        }
        #endregion

        #region Private methods
        private void Initialize(CylinderProperties cylProperties)
        {
            CylinderRadius = cylProperties.RadiusOuter;
            CylinderLength = cylProperties.Height;
        }
        #endregion

        #region Public methods
        public bool IsValidPosition(CylPosition cylPosition)
        {
            switch (cylPosition.Direction)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    if (cylPosition.XYZ.X - CylinderLength < 0.0) return false;
                    if (cylPosition.XYZ.X > PalletLength) return false;
                    if (cylPosition.XYZ.Y - CylinderRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + CylinderRadius > PalletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    if (cylPosition.XYZ.X < 0.0) return false;
                    if (cylPosition.XYZ.X - CylinderLength > PalletLength) return false;
                    if (cylPosition.XYZ.Y - CylinderRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + CylinderRadius > PalletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    if (cylPosition.XYZ.Y - CylinderLength < 0) return false;
                    if (cylPosition.XYZ.Y > PalletWidth) return false;
                    if (cylPosition.XYZ.X - CylinderRadius < 0) return false;
                    if (cylPosition.XYZ.X + CylinderRadius > PalletLength) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    if (cylPosition.XYZ.Y < 0) return false;
                    if (cylPosition.XYZ.Y + CylinderLength > PalletWidth) return false;
                    if (cylPosition.XYZ.X - CylinderRadius < 0) return false;
                    if (cylPosition.XYZ.X + CylinderRadius > PalletLength) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }
        public bool IntersectWithContent(CylPosition cylPosition)
        {
            Vector3D cylDirection = HalfAxis.ToVector3D(cylPosition.Direction);
            foreach (CylPosition c in this)
            {
                Vector3D vDiff = c.XYZ - cylPosition.XYZ;
                double axisProj = Vector3D.DotProduct(cylDirection, vDiff);
                Vector3D vDiffProj = vDiff - axisProj * cylDirection;
                if (axisProj < CylinderLength && vDiffProj.GetLength() < CylinderRadius)
                    return true;
            }
            return false;
        }
        #endregion

        #region Public properties
        public double PalletLength { get; } = 0.0;
        public double PalletWidth { get; } = 0.0;
        public double PalletHeight { get; } = 0.0;
        public double CylinderRadius { get; private set; } = 0.0;
        public double CylinderLength { get; private set; } = 0.0;
        public double RowSpacing { get; } = 0.0;
        public Limit LimitReached { get; set; } = Limit.LIMIT_UNKNOWN;
        #endregion
    }
}
