using System;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.IsometricBlocks;
using Sharp3D.Math.Core;


namespace treeDiM.StackBuilder.Graphics.TestIsometricBlockOrderer
{
    class Program
    {
        static void Main(string[] args)
        {
            IsometricBlocksOrderer blockOrderer = new IsometricBlocksOrderer();
            // Box b1 = new Box(0, 2.0, 2.0, 2.5, new BoxPosition() { Position = new Vector3D(1.0, 3.0, 0.0), DirectionLength = HalfAxis.HAxis.AXIS_X_P, DirectionWidth = HalfAxis.HAxis.AXIS_Y_P });
            // Box b2 = new Box(1, 1.0, 1.0, 1.5, new BoxPosition() { Position = new Vector3D(2.0, 2.0, 0.0), DirectionLength = HalfAxis.HAxis.AXIS_X_P, DirectionWidth = HalfAxis.HAxis.AXIS_Y_P });
            // Box b3 = new Box(2, 1.0, 4.0, 1.0, new BoxPosition() { Position = new Vector3D(3.0, 1.0, 0.0), DirectionLength = HalfAxis.HAxis.AXIS_X_P, DirectionWidth = HalfAxis.HAxis.AXIS_Y_P });
            // blockOrderer.Add(b1);
            // blockOrderer.Add(b2);
            // blockOrderer.Add(b3);

            Box b1 = new Box(0, 2.0, 2.0, 2.0, new BoxPosition() { Position = new Vector3D(3.0, 2.0, 0.0), DirectionLength = HalfAxis.HAxis.AXIS_X_P, DirectionWidth = HalfAxis.HAxis.AXIS_Y_P });
            Box b2 = new Box(1, 2.0, 2.25, 1.0, new BoxPosition() { Position = new Vector3D(2.0, 4.0, 0.0), DirectionLength = HalfAxis.HAxis.AXIS_X_P, DirectionWidth = HalfAxis.HAxis.AXIS_Y_P });
            blockOrderer.Add(b1);
            blockOrderer.Add(b2);

            var orderedBoxes = blockOrderer.GetSortedList();
            foreach (Box b in orderedBoxes)
                Console.WriteLine("Box = {0}", b.PickId);
        }
    }
}
