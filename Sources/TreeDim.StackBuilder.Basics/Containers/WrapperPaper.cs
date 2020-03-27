using System.Drawing;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperPaper : PackWrapper
    {
        public WrapperPaper(double thickness, double weight, Color color)
            : base(thickness, weight, color) { }
        public override WType Type => PackWrapper.WType.WT_PAPER;
    }
}
