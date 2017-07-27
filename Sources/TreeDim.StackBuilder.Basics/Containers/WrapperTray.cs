using System;
using System.Drawing;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperTray : WrapperCardboard
    {
        public WrapperTray(double thickness, double weight, Color color)
            : base(thickness, weight, color) { }

        public double Height { get; set; }

        public override PackWrapper.WType Type => PackWrapper.WType.WT_TRAY;
    }
}
