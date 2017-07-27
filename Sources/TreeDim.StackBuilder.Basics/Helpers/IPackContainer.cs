using System;
using Sharp3D.Math.Core;

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
}
