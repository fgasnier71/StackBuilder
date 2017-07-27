#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.TestRayIntersect
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxProperties bProperties = new BoxProperties(null, 1000, 750, 500);
            Box b = new Box(0, bProperties);

            Vector3D vNear = new Vector3D(400.0, 1000.0, 0.0);
            Vector3D vFar = new Vector3D(500.0, -1000.0, 250.0);
            Ray r = new Ray(vNear, vFar);

            Vector3D ptInter;
            if (b.RayIntersect(r, out ptInter))
                Console.WriteLine("Point inter : {0}", ptInter);
            else
                Console.WriteLine("No intersection found");
        }
    }
}
