using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetCylinderCase : ConstraintSetPackableCase
    {
        public ConstraintSetCylinderCase(Packable container)
            : base(container)
        {
        }
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (HalfAxis.HAxis.AXIS_Z_N == axisOrtho) || (HalfAxis.HAxis.AXIS_Z_P == axisOrtho);
        }
        public override string AllowedOrientationsString
        {
            get { return "0,0,1"; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
    }
}
