using System;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetCylinderContainer : ConstraintSetPackableContainer
    {
        public ConstraintSetCylinderContainer(IContainer container)
            : base(container)
        {
        }
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (HalfAxis.HAxis.AXIS_Z_N == axisOrtho)
                || (HalfAxis.HAxis.AXIS_Z_P == axisOrtho);
        }

        public override string AllowedOrientationsString
        {
            get { return "0,0,1"; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
    }

    public class ConstraintSetCylinderTruck : ConstraintSetPackableTruck
    {
        public ConstraintSetCylinderTruck(TruckProperties truck)
            : base(truck)
        {
        }
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (HalfAxis.HAxis.AXIS_Z_N == axisOrtho)
                || (HalfAxis.HAxis.AXIS_Z_P == axisOrtho);
        }

        public override string AllowedOrientationsString
        {
            get { return "0,0,1"; }
            set { throw new InvalidOperationException("Setting this property is not supported."); }
        }
    }
}
