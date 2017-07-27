using System;
using System.Linq;
using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetPackablePallet : ConstraintSetAbstract
    {
        public override string AllowedOrientationsString
        {
            get => "0,0,1";
            set => throw new InvalidOperationException("Setting this property is not supported.");
        }

        public override OptDouble OptMaxHeight => _maxHeight;

        public override bool Valid
        {
            get { return _maxHeight.Activated || OptMaxWeight.Activated || OptMaxNumber.Activated; }
        }

        public Vector2D Overhang { get; set; }

        public OptDouble OptMinSpace { get; set; }

        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (axisOrtho == HalfAxis.HAxis.AXIS_Z_N)
                || (axisOrtho == HalfAxis.HAxis.AXIS_Z_P);
        }

        public void SetMaxHeight(OptDouble maxHeight)
        {
            _maxHeight = maxHeight;
        }

        #region Non-Public Members

        protected OptDouble _maxHeight;

        #endregion
    }
}
