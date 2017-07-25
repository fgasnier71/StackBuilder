using System;

namespace treeDiM.StackBuilder.Basics
{
    public class BundleCaseConstraintSet : BCaseConstraintSet
    {
        public BundleCaseConstraintSet()
        {
        }

        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return (orthoAxis == HalfAxis.HAxis.AXIS_Z_N) || (orthoAxis == HalfAxis.HAxis.AXIS_Z_P);
        }

        public override bool IsValid => true;
    }
}
