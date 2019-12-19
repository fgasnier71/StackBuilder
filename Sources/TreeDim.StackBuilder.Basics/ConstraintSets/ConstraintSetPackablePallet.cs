using System;

using Sharp3D.Math.Core;

using treeDiM.Basics;

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
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return (axisOrtho == HalfAxis.HAxis.AXIS_Z_N)
                || (axisOrtho == HalfAxis.HAxis.AXIS_Z_P);
        }
        public override bool AllowUncompleteLayer => false;
        public override bool Valid => HasSomeAllowedOrientations || _maxHeight.Activated || OptMaxWeight.Activated || OptMaxNumber.Activated;

        public void SetMaxHeight(OptDouble maxHeight)
        {
            _maxHeight = maxHeight;
        }
        public Vector2D Overhang { get; set; }

        #region Non-Public Members
        protected OptDouble _maxHeight;
        #endregion
    }
}
