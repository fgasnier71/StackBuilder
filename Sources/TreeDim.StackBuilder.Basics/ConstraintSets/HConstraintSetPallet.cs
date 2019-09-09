#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class HConstraintSetPallet : HConstraintSet
    {
        public double MaximumHeight { get; set; }
        public Vector2D Overhang { get; set; }
    }
}
