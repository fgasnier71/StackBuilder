using System.Drawing;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperPolyethilene : PackWrapper
    {
        public WrapperPolyethilene(double thickness, double weight, Color color)
            : base(thickness, weight, color) { }
        public override bool Transparent => true;
        public override WType Type => WType.WT_POLYETHILENE;
    }
}
