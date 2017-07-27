using System;
using System.Drawing;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperPolyethilene : PackWrapper
    {
        public WrapperPolyethilene(double thickness, double weight, Color color, bool transparent)
            : base(thickness, weight, color) { }
        public override bool Transparent => _transparent;
        public override WType Type => PackWrapper.WType.WT_POLYETHILENE;
        // data members
        bool _transparent = true;
    }
}
