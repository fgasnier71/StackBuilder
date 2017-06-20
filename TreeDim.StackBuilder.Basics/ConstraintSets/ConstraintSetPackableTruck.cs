#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using log4net;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableTruck : ConstraintSetAbstract
    {
        #region Data members
        protected IPackContainer _container;
        #endregion

        #region Constructor
        public ConstraintSetPackableTruck(IPackContainer container)
        {
            _container = container;
            if (!(_container is TruckProperties))
                throw new Exception("Invalid container!");
        }
        #endregion

        #region ConstraintSetAbstract
        public override OptDouble OptMaxHeight
        {
            get
            {
                TruckProperties truckProperties = _container as TruckProperties;
                if (null == truckProperties)
                    throw new Exception("Invalid container");
                return new OptDouble(true, truckProperties.InsideHeight);
            }
        }
        public override bool Valid
        {
            get { return (!_maxNumber.Activated || _maxNumber.Value > 0); }
        }
        #endregion

        #region ConstraintSetPackableTruck
        public void SetMaxWeight(OptDouble maxWeight)
        {
            _maxWeight = maxWeight;
        }
        public void SetMaxNumber(OptInt maxNumber)
        {
            _maxNumber = maxNumber;
        }
        #endregion
    }

    #region ConstraintSetCaseTruck
    public class ConstraintSetCaseTruck : ConstraintSetPackableTruck
    {
        #region Data members
        private bool[] _axesAllowed = new bool[] { true, true, true };
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetBoxCase));
        #endregion

        #region Constructor
        public ConstraintSetCaseTruck(IPackContainer container)
            : base(container)
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
        public override string AllowedOrientationsString
        {
            get
            {
                return string.Format("{0},{1},{2}"
                    , AllowOrientation(HalfAxis.HAxis.AXIS_X_P) ? 1 : 0
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Y_P) ? 1 : 0
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Z_P) ? 1 : 0);
            }
            set
            {
                Regex r = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline);
                Match m = r.Match(value);
                if (m.Success)
                {
                    _axesAllowed[0] = int.Parse(m.Result("${x}")) == 1;
                    _axesAllowed[1] = int.Parse(m.Result("${y}")) == 1;
                    _axesAllowed[1] = int.Parse(m.Result("${z}")) == 1;
                }
            }
        }
        public override bool Valid
        {
            get
            {
                return base.Valid
                    && (_axesAllowed[0] || _axesAllowed[1] || _axesAllowed[2]);
            }
        }
        #endregion

        #region ConstraintSetCaseTruck specific
        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            _axesAllowed = axesAllowed; 
        }
        #endregion
    }
    #endregion
}
