using System;
using System.Drawing;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperPaper : PackWrapper
    {
        public WrapperPaper(double thickness, double weight, Color color)
            : base(thickness, weight, color) { }
        public override PackWrapper.WType Type => PackWrapper.WType.WT_PAPER;
    }
}
