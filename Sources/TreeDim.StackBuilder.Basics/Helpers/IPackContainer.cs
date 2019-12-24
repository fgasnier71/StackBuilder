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
        double OffsetZ { get; }
    }
    public class InvalidConstraintSetException : Exception
    {
        public InvalidConstraintSetException() {}
        public override string Message => "Invalid constraint set";
    }
}
