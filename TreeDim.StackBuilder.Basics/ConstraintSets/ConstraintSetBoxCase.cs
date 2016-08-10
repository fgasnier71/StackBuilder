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
    public class ConstraintSetBoxCase : ConstraintSetAbstract
    {
        #region Data members
        private Packable _container;
        private bool[] _axesAllowed = new bool[] { true, true, true };
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetBoxCase));
        #endregion

        #region Constructor
        public ConstraintSetBoxCase(Packable container)
        {
            _container = container;
            if (!container.IsCase)
                throw new Exception("Invalid container!");
        }
        #endregion

        #region ConstraintSetAbstract override
        public override OptDouble OptMaxHeight
        {
            get
            {
                BoxProperties caseProperties = _container as BoxProperties;
                if (null == caseProperties)
                    throw new Exception("Invalid container");
                return new OptDouble(true, caseProperties.InsideHeight); 
            }
        }
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
        public override bool Valid { get { return true; } }
        #endregion

        #region ConstraintSetBoxCase specific
        public void SetMaxWeight(OptDouble maxWeight)
        {
            _maxWeight = maxWeight;
        }
        public void SetMaxNumber(int maxNumber)
        {
            _maxNumber = new OptInt(true, maxNumber);
        }
        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            _axesAllowed = axesAllowed;
        }
        #endregion
    }
}
