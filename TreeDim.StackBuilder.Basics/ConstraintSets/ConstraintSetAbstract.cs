#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetAbstract
    {
        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
        public abstract OptDouble OptMaxHeight { get; }
        public abstract OptDouble OptMaxWeight { get; }
    }
}
