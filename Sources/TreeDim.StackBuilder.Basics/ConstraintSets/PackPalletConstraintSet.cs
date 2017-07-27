using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class PackPalletConstraintSet
    {
        public PackPalletConstraintSet() { }

        public bool IsValid => MaximumPalletHeight.Activated || MaximumPalletWeight.Activated;

        // Stop conditions
        public OptDouble MaximumPalletHeight { get; set; } = OptDouble.Zero;
        public OptDouble MaximumPalletWeight { get; set; } = OptDouble.Zero;

        // Layout constraints
        public OptDouble MinimumSpace { get; set; }
        public double OverhangX { get; set; } = 0.0;
        public double OverhangY { get; set; } = 0.0;
        public int InterlayerPeriod { get; set; }
        public int LayerSwapPeriod { get; set; }
        public bool HasFirstInterlayer { get; set; }

        // Solution filtering
        public OptDouble MaximumLayerWeight { get; set; }
        public OptDouble MaximumSpaceAllowed { get; set; }
        public OptDouble MinOverhangX { get; set; }
        public OptDouble MinOverhangY { get; set; }

        public override string ToString()
        {
            return "";
        }
    }
}
