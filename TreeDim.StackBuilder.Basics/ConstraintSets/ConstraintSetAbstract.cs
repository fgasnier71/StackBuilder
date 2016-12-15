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
        #endregion

        #region Abstract properties
        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
        public abstract string AllowedOrientations { get; set; }
        public abstract OptDouble OptMaxHeight { get; }
        public abstract bool Valid { get; }
        #endregion
    }
}
