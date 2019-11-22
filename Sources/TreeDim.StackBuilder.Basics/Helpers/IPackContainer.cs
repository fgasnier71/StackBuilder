#region Using directives
using System;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public interface IPackContainer
    {
        bool HasInsideDimensions { get; }
        double InsideLength { get; }
        double InsideWidth { get; }
        double InsideHeight { get; }
        Vector3D InsideDimensions { get; }
        double[] InsideDimensionsArray { get; }
    }
    public interface IContainer
    {
        Vector3D GetStackingDimensions(ConstraintSetAbstract constraintSet);
    }
    public class InvalidConstraintSetException : Exception
    {
        public InvalidConstraintSetException() {}
        public override string Message => "Invalid constraint set";
    }
}
