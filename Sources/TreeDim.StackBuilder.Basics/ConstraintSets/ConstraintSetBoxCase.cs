using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetBoxCase : ConstraintSetPackableCase
    {
        public ConstraintSetBoxCase(Packable container)
            : base(container)
        {
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
                Match m = AllowedOrientationRegex.Match(value);
                if (m.Success)
                {
                    _axesAllowed[0] = int.Parse(m.Result("${x}")) == 1;
                    _axesAllowed[1] = int.Parse(m.Result("${y}")) == 1;
                    _axesAllowed[1] = int.Parse(m.Result("${z}")) == 1;
                }
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

        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            Debug.Assert(axesAllowed.Length == 3);
            for (int i = 0; i < 3; ++i)
                _axesAllowed[i] = axesAllowed[i];
        }

        #region Non-Public Members
        private bool[] _axesAllowed = new bool[] { true, true, true };
        static readonly Regex AllowedOrientationRegex = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline | RegexOptions.Compiled);
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetBoxCase));
        #endregion
    }
}
