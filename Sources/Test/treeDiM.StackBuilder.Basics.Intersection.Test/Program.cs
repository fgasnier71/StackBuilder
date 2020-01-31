#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics.Intersection.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxPosition bPos = new BoxPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
            var pts = new List<Vector3D>();
            if (bPos.IntersectPlane(new Vector3D(400.0, 300.0, 200.0), -100.0, 0, ref pts))
            {
                foreach (var pt in pts)
                    Console.WriteLine(pt);
            }
        }
    }
}
