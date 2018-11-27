using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

using log4net;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetCaseTruck : ConstraintSetPackableTruck
    {
        public ConstraintSetCaseTruck(IPackContainer container)
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
                    AxesAllowed[0] = int.Parse(m.Result("${x}")) == 1;
                    AxesAllowed[1] = int.Parse(m.Result("${y}")) == 1;
                    AxesAllowed[1] = int.Parse(m.Result("${z}")) == 1;
                }
            }
        }
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            switch (axisOrtho)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                case HalfAxis.HAxis.AXIS_X_P:
                    return AxesAllowed[0];
                case HalfAxis.HAxis.AXIS_Y_N:
                case HalfAxis.HAxis.AXIS_Y_P:
                    return AxesAllowed[1];
                case HalfAxis.HAxis.AXIS_Z_N:
                case HalfAxis.HAxis.AXIS_Z_P:
                    return AxesAllowed[2];
                default:
                    throw new Exception("Invalid axis");
            }
        }
        public override OptDouble OptMaxWeight
        {
            get
            {
                if (_container is TruckProperties truckProperties)
                    return new OptDouble(truckProperties.AdmissibleLoadWeight > 0.0, truckProperties.AdmissibleLoadWeight);
                else
                    return OptDouble.Zero;
            }
        }
        public override OptDouble OptMaxHeight
        {
            get
            {
                if (_container is TruckProperties truckProperties)
                    return new OptDouble(true, truckProperties.InsideHeight - MinDistanceLoadRoof);
                else
                    return OptDouble.Zero;
            }
        }
        public void SetAllowedOrientations(bool[] axesAllowed)
        {
            Debug.Assert(axesAllowed.Length == 3);
            for (int i=0; i<3; ++i)
                AxesAllowed[i] = axesAllowed[i];
        }
        public Vector2D MinDistanceLoadWall { get; set; }
        public double MinDistanceLoadRoof { get; set; }
        public bool[] AxesAllowed { get; } = new bool[] { true, true, true };

        #region Non-Public Members
        static readonly Regex AllowedOrientationRegex = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline | RegexOptions.Compiled);
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetCaseTruck));
        #endregion

    }
}
