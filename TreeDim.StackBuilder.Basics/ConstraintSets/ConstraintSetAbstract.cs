#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetAbstract
    {
        #region Data members
        protected OptDouble _maxWeight;
        protected OptInt _maxNumber;
        #endregion

        #region Virtual properties
        public virtual OptDouble OptMaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }
        public virtual OptInt OptMaxNumber
        {
            get { return _maxNumber; }
            set { _maxNumber = value; }
        }
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
        #endregion

        #region Abstract properties
        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
        public abstract string AllowedOrientationsString { get; set; }
        public abstract OptDouble OptMaxHeight { get; }
        public abstract bool Valid { get; }
        #endregion
    }
}
