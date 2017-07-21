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
    public class ConstraintSetPackablePallet : ConstraintSetAbstract
    {
        #region Data members
        protected OptDouble _maxHeight;
        protected Vector2D _overhang;
        protected OptDouble _minSpace;
        #endregion

        #region ConstraintSetAbstract override
        public override OptDouble OptMaxHeight
        {
            get { return _maxHeight; }
        }        
        public override bool Valid
        {
            get { return _maxHeight.Activated || OptMaxWeight.Activated || OptMaxNumber.Activated; }
        }
        #endregion

        #region ConstraintSetPallet specific methods and properties
        public void SetMaxHeight(OptDouble maxHeight)
        {
            _maxHeight = maxHeight;
        }
        public Vector2D Overhang
        {
            get { return _overhang; }
            set { _overhang = value; }
        }
        public OptDouble OptMinSpace
        {
            get { return _minSpace; }
            set { _minSpace = value; }
        }
        #endregion

        #region ConstraintSetAbstract override
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (axisOrtho == HalfAxis.HAxis.AXIS_Z_N)
                || (axisOrtho == HalfAxis.HAxis.AXIS_Z_P);
        }
        public override string AllowedOrientationsString
        {
            get { return "0,0,1"; }
            set {}
        }
        #endregion
    }

    public class ConstraintSetCasePallet : ConstraintSetPackablePallet
    {
        #region Data members
        private bool[] _axesAllowed = new bool[] { true, true, true };
        private int _palletFilmTurns = 0;
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetCasePallet));
        #endregion

        #region Constructor
        public ConstraintSetCasePallet()
            : base()
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
        #endregion

        #region ConstraintSetCasePallet specific
        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            _axesAllowed = axesAllowed;
        }
        public int PalletFilmTurns
        {
            get { return _palletFilmTurns; }
            set { _palletFilmTurns = value; }
        }
        #endregion
    }
}
