using System;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    public class BundlePalletConstraintSet : PalletConstraintSet
    {
        // Interlayer
        public override bool HasInterlayer
        {
            get { return false; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        } 
        public override int InterlayerPeriod
        {
            get { return 0; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
        public override bool HasInterlayerAntiSlip
        {
            get { return false; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }

        // Allowed box axis
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return (orthoAxis == HalfAxis.HAxis.AXIS_Z_N) || (orthoAxis == HalfAxis.HAxis.AXIS_Z_P);
        }
        public override bool AllowTwoLayerOrientations
        {
            get { return false; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
        public override bool AllowLastLayerOrientationChange
        {
            get { return false; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }

        // TODO consider using double? instead of 2 properties
        public override bool UseMaximumWeightOnBox
        {
            get { return false; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
        public override double MaximumWeightOnBox
        {
            get { return 0.0; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
    }
}
