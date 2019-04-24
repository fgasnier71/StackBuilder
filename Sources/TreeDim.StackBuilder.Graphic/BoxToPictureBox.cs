#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    /// <summary>
    /// Used to draw boxes/cases to picture boxes in winforms UIs
    /// </summary>
    public class BoxToPictureBox
    {
        public static void Draw(PackableBrick packable, HalfAxis.HAxis axis, PictureBox pictureBox)
        {
            try
            {
                // get horizontal angle
                double angle = 45;
                double cameraDistance = 100000;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size)
                {
                    CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * cameraDistance
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * cameraDistance
                    , cameraDistance),
                    Target = Vector3D.Zero
                };
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // draw
                Box box = null;
                if (packable is PackProperties)
                    box = new Pack(0, packable as PackProperties);
                else
                    box = new Box(0, packable);
                // set axes
                HalfAxis.HAxis lengthAxis = HalfAxis.HAxis.AXIS_X_P;
                HalfAxis.HAxis widthAxis = HalfAxis.HAxis.AXIS_Y_P;
                switch (axis)
                {
                    case HalfAxis.HAxis.AXIS_X_P: lengthAxis = HalfAxis.HAxis.AXIS_Z_P; widthAxis = HalfAxis.HAxis.AXIS_X_P; break;
                    case HalfAxis.HAxis.AXIS_Y_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Z_N; break;
                    case HalfAxis.HAxis.AXIS_Z_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Y_P; break;
                    default: break;
                }
                box.HLengthAxis = lengthAxis;
                box.HWidthAxis = widthAxis;
                // draw box
                graphics.AddBox(box);
                graphics.Flush();
                // set to picture box
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                 Bitmap bmp = new Bitmap(pictureBox.Size.Width,pictureBox.Size.Height);
                 System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                 g.DrawString("Invalid content", new Font("Arial", 8), new SolidBrush(Color.Red), new PointF(5, 10));
                 pictureBox.Image = bmp;

                 _log.Error(ex.ToString());
            }
        }

        public static void Draw(Packable packable, PictureBox pictureBox)
        {
            // get horizontal angle
            double angle = 45;
            double cameraDistance = 100000.0;
            // instantiate graphics
            Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * cameraDistance
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * cameraDistance
                , cameraDistance);
            graphics.Target = Vector3D.Zero;
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

            // ### draw : begin ##############################
            if (packable is PackProperties)
            {
                Box box = new Pack(0, packable as PackProperties);
                graphics.AddBox(box);
            }
            else if (packable is BProperties)
            { 
                Box box = new Box(0, packable as PackableBrick);
                graphics.AddBox(box);
            }
            else if (packable is CylinderProperties)
            {
                graphics.AddCylinder(new Cylinder(0, packable as CylinderProperties));
            }
            // ### draw : end #################################

            graphics.Flush();
            // set to picture box
            pictureBox.Image = graphics.Bitmap;
        }

        protected static ILog _log = LogManager.GetLogger(typeof(BoxToPictureBox));
    }
}
