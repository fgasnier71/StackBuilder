#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion


namespace treeDiM.StackBuilder.Graphics
{
    /// <summary>
    /// Drawable truck (used to draw a truck with a Graphics3D object)
    /// </summary>
    public class Truck : Drawable
    {
        #region Data members
        private Vector3D[] _points;
        #endregion

        #region Constructor
        public Truck(TruckProperties truckProperties)
            : base(0)
        {
            Length = truckProperties.Length;
            Width = truckProperties.Width;
            Height = truckProperties.Height;
            ColorFill = truckProperties.Color;
            ColorPath = Color.Black;
        }
        #endregion

        #region Overrides
        public override void DrawBegin(Graphics3D graphics)
        { 
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        public override void Draw(Graphics3D graphics)
        {
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            Vector3D viewDir = graphics.ViewDirection;
            int[] seg0=null, seg1= null, seg2=null;

            if (viewDir.X < 0.0 && viewDir.Y >= 0.0)
            {
                seg0 = new int[2] { 4, 5 };
                seg1 = new int[2] { 5, 6 };
                seg2 = new int[2] { 1, 5 };
            }
            else if (viewDir.X < 0.0 && viewDir.Y < 0.0)
            {
                seg0 = new int[2] { 5, 6 };
                seg1 = new int[2] { 6, 7 };
                seg2 = new int[2] { 2, 6 };
            }
            else if (viewDir.X >= 0.0 && viewDir.Y < 0.0)
            {
                seg0 = new int[2] { 6, 7 };
                seg1 = new int[2] { 7, 4 };
                seg2 = new int[2] { 3, 7 };
            }
            else if (viewDir.X >= 0.0 && viewDir.Y >= 0.0)
            {
                seg0 = new int[2] { 7, 4 };
                seg1 = new int[2] { 4, 5 };
                seg2 = new int[2] { 0, 4 };
            }
            graphics.AddSegment(new Segment(Points[seg0[0]], Points[seg0[1]], ColorPath) );
            graphics.AddSegment(new Segment(Points[seg1[0]], Points[seg1[1]], ColorPath));
            graphics.AddSegment(new Segment(Points[seg2[0]], Points[seg2[1]], ColorPath));
        }
        #endregion

        #region Public properties
        public override Vector3D[] Points
        {
            get
            {
                if (null == _points)
                {
                    _points = new Vector3D[8];
                    _points[0] = new Vector3D(0.0, 0.0, 0.0);
                    _points[1] = new Vector3D(Length, 0.0, 0.0);
                    _points[2] = new Vector3D(Length, Width, 0.0);
                    _points[3] = new Vector3D(0.0, Width, 0.0);

                    _points[4] = new Vector3D(0.0, 0.0, Height);
                    _points[5] = new Vector3D(Length, 0.0, Height);
                    _points[6] = new Vector3D(Length, Width, Height);
                    _points[7] = new Vector3D(0.0, Width, Height);
                }
                return _points;
            }
        }

        public Segment[] Segments
        {
            get
            {
                Segment[] segments = new Segment[12];
                Vector3D[] points = Points;

                segments[0] = new Segment(points[0], points[1], ColorPath);
                segments[1] = new Segment(points[1], points[2], ColorPath);
                segments[2] = new Segment(points[2], points[3], ColorPath);
                segments[3] = new Segment(points[3], points[0], ColorPath);

                segments[4] = new Segment(points[4], points[5], ColorPath);
                segments[5] = new Segment(points[5], points[6], ColorPath);
                segments[6] = new Segment(points[6], points[7], ColorPath);
                segments[7] = new Segment(points[7], points[4], ColorPath);

                segments[8] = new Segment(points[0], points[4], ColorPath);
                segments[9] = new Segment(points[1], points[5], ColorPath);
                segments[10] = new Segment(points[2], points[6], ColorPath);
                segments[11] = new Segment(points[3], points[7], ColorPath);

                return segments;
            }
        }

        public Face[] Faces
        {
            get
            {
                Face[] faces = new Face[5];
                Vector3D[] points = Points;

                faces[0] = new Face(PickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, ColorFill, ColorPath, "TRUCK", false);    // AXIS_Z_P
                faces[1] = new Face(PickId, new Vector3D[] { points[1], points[5], points[4], points[0] }, ColorFill, ColorPath, "TRUCK", false);    // AXIS_Y_P
                faces[2] = new Face(PickId, new Vector3D[] { points[3], points[7], points[6], points[2] }, ColorFill, ColorPath, "TRUCK", false);    // AXIS_Y_N
                faces[3] = new Face(PickId, new Vector3D[] { points[2], points[6], points[5], points[1] }, ColorFill, ColorPath, "TRUCK", false);    // AXIS_X_N
                faces[4] = new Face(PickId, new Vector3D[] { points[4], points[7], points[3], points[0] }, ColorFill, ColorPath, "TRUCK", false);    // AXIS_X_P

                return faces;
            }
        }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Color ColorFill { get; set; }
        public Color ColorPath { get; set; }
        #endregion
    }
}
