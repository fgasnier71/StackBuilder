using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetAbstract
    {
        public virtual OptDouble OptMaxWeight { get; set; }
        public virtual OptInt OptMaxNumber { get; set; }
        public bool[] AllowedOrientations
        {
            get
            {
                return new bool[] {
                    AllowOrientation(HalfAxis.HAxis.AXIS_X_N) || AllowOrientation(HalfAxis.HAxis.AXIS_X_P)
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Y_N) || AllowOrientation(HalfAxis.HAxis.AXIS_Y_P)
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Z_N) || AllowOrientation(HalfAxis.HAxis.AXIS_Z_P)
                };
            }
        }

        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
        public abstract string AllowedOrientationsString { get; set; }
        public abstract OptDouble OptMaxHeight { get; }
        public abstract bool Valid { get; }
    }
}
