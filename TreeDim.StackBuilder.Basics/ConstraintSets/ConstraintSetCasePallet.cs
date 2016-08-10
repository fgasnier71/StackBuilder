#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetCasePallet : ConstraintSetAbstract
    {
        #region Data members
        private bool[] _axesAllowed = new bool[] { true, true, true };
        private OptDouble _maxHeight;
        private Vector2D _overhang;
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetCasePallet));
        #endregion

        #region Constructor
        public ConstraintSetCasePallet()
        { 
        }
        #endregion

        #region ConstraintSetAbstract override
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            switch (axisOrtho)
            { 
                case HalfAxis.HAxis.AXIS_X_N:
                case HalfAxis.HAxis.AXIS_X_P:
                    return _axesAllowed[0];
                case HalfAxis.HAxis.AXIS_Y_N:
                case HalfAxis.HAxis.AXIS_Y_P:
                    return _axesAllowed[1];
                case HalfAxis.HAxis.AXIS_Z_N:
                case HalfAxis.HAxis.AXIS_Z_P:
                    return _axesAllowed[2];
                default:
                    throw new Exception("Invalid axis");
            }
        }
        public override OptDouble OptMaxHeight
        {
            get { return _maxHeight; }
        }        
        public override bool Valid
        {
            get { return _maxHeight.Activated || _maxWeight.Activated || _maxNumber.Activated; }
        }
        #endregion

        #region ConstraintSetCasePallet specific
        public void SetMaxHeight(OptDouble maxHeight)
        {
            _maxHeight = maxHeight;
        }
        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            _axesAllowed = axesAllowed;
        }
        public Vector2D Overhang
        {
            get { return _overhang; }
            set { _overhang = value; }
        }
        #endregion
    }
}
