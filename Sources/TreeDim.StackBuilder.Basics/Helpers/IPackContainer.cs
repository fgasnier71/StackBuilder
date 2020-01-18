#region Using directives
using System;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public interface IContainer
    {
        double Weight { get; }
        Vector3D GetStackingDimensions(ConstraintSetAbstract constraintSet);
        Vector3D GetOffset(ConstraintSetAbstract constraintSet);
    }
    public class InvalidConstraintSetException : Exception
    {
        public InvalidConstraintSetException() {}
        public override string Message => "Invalid constraint set";
    }
}
