#region Using directives
using System.Collections.Generic;
using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
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

        #endregion

        #region Public properties
        public double PalletLength { get; } = 0.0;
        public double PalletWidth { get; } = 0.0;
        public double PalletHeight { get; } = 0.0;
        public double CylinderRadius { get; private set; } = 0.0;
        public double CylinderLength { get; private set; } = 0.0;
        public double RowSpacing { get; } = 0.0;
        public Limit LimitReached { get; set; } = Limit.UNKNOWN;
        #endregion
    }
}
