using System;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    public class TruckConstraintSet
    {
        public TruckConstraintSet()
        {
            MultilayerAllowed = true;
        }
        public bool MultilayerAllowed { get; set; }
        public bool AllowPalletOrientationX { get; set; }
        public bool AllowPalletOrientationY { get; set; }
        public double MinDistancePalletTruckWall { get; set; }
        public double MinDistancePalletTruckRoof { get; set; }
    }
}
