#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using log4net;
using log4net.Config;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.TestBSPTree
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            try
            {
                Size sz = new Size(1000, 1000);
                Graphics3DImage g = new Graphics3DImage(sz)
                {
                    CameraPosition = new Vector3D(-10000.0, -10000.0, 10000.0),
                    Target = Vector3D.Zero
                };
                g.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

                Box b1 = new Box(0, 400, 300, 200, new BoxPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P)) { };
                b1.SetAllFacesColor(Color.Chocolate);
                Box b2 = new Box(1, 400, 300, 200, new BoxPosition(new Vector3D(400.0, 0.0, 0.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P)) { };
                b2.SetAllFacesColor(Color.BurlyWood);
                Box b3 = new Box(2, 400, 300, 200, new BoxPosition(new Vector3D(300.0, 300.0, 0.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N)) { };
                b3.SetAllFacesColor(Color.Chartreuse);
                Box b4 = new Box(3, 300, 200, 50, new BoxPosition(new Vector3D(50.0, 50.0, 200.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P)) { };
                b4.SetAllFacesColor(Color.Coral);
                List<Box> boxes = new List<Box> { b1, b2, b3, b4 };
                BSPTree bspTree = new BSPTree();
                foreach (Box b in boxes)
                    bspTree.InsertBox(b);
                bspTree.Draw(g);

                g.Bitmap.Save(@"D:\GitHub\StackBuilder\Sources\Test\treeDiM.StackBuilder.Graphics.TestBSPTree\bin\Release\output.png");
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        protected static ILog _log = LogManager.GetLogger(typeof(Program));
    }
}
