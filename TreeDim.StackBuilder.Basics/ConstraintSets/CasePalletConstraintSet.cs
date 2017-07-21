using System;
using System.Collections.Generic;
using System.Text;

namespace treeDiM.StackBuilder.Basics
{
    public class CasePalletConstraintSet : PalletConstraintSet
    {
        public CasePalletConstraintSet() { }

        public override bool HasInterlayer { get; set; } = false;
        public override int InterlayerPeriod { get; set; }
        public override bool HasInterlayerAntiSlip { get; set; } = false;
        public override bool AllowTwoLayerOrientations { get; set; } = false;
        public override bool AllowLastLayerOrientationChange { get; set; } = false;
        public override bool UseMaximumWeightOnBox { get; set; }
        public override double MaximumWeightOnBox { get; set; }

        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return _allowedOrthoAxis[(int)orthoAxis];
        }

        public void SetAllowedOrthoAxis(HalfAxis.HAxis axis, bool allowed)
        {
            _allowedOrthoAxis[(int)axis] = allowed;
        }

        #region Non-Public Members

        private bool[] _allowedOrthoAxis = new bool[6];

        #endregion

    }
}
