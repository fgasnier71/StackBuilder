#region Using directives
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class Bottle : Cyl
    {
        #region Constructor
        public Bottle(uint pickId, List<Vector2D> profile, Color color)
        {
            PickId = pickId;
            Profile = profile;
            Color = color;
        }
        public Bottle(uint pickId, BottleProperties bottleProp)
        {
            PickId = pickId;
            Profile = bottleProp.Profile;
            Color = bottleProp.Color;
        }
        public Bottle(uint pickId, BottleProperties bottleProp, CylPosition position)
        {
            PickId = pickId;
            Profile = bottleProp.Profile;
            Color = bottleProp.Color;
            Position = position;
        }
        #endregion
        #region Overrides Drawable
        public override void Draw(Graphics3D graphics)
        {
            System.Drawing.Graphics g = graphics.Graphics;
            Vector3D viewDir = graphics.ViewDirection;

            // build pen path
            Brush brushPath = new SolidBrush(ColorPath);
            Pen penPath = new Pen(brushPath, 1.7f);
 
            // bottom, top
            Point[] ptsBottom = graphics.TransformPoint(GetBottomPoints());
            Point[] ptsTop = graphics.TransformPoint(GetTopPoints());

            // outer wall
            Face[] facesWalls = GetFaceWalls();
            foreach (Face face in facesWalls)
            {
                try
                {
                    var normal = face.Normal;
                    // visible ?
                    if (!face.IsVisible(viewDir)) continue;
                    // draw polygon
                    Point[] ptsFace = graphics.TransformPoint(face.Points);
                    g.FillPolygon(new SolidBrush(face.ColorGraph(graphics)), ptsFace);
                }
                catch (Exception /*ex*/)
                { 
                }
            }
            // top
            double cosTop = Math.Abs(Vector3D.DotProduct(HalfAxis.ToVector3D(Position.Direction), graphics.VLight));
            Color colorTop = Color.FromArgb((int)(Color.R * cosTop), (int)(Color.G * cosTop), (int)(Color.B * cosTop));
            Brush brushTop = new SolidBrush(colorTop);
            bool topVisible = Vector3D.DotProduct(HalfAxis.ToVector3D(Position.Direction), viewDir) < 0;
            if (topVisible)
                g.FillPolygon(brushTop, ptsTop);
            else
                g.FillPolygon(brushTop, ptsBottom);
        }
        #endregion
        #region Private properties
        private List<Vector2D> Profile { get; set; } = new List<Vector2D>();
        private Color Color;
        private Color ColorPath => Color.Black;
        public override double RadiusOuter { get => 0.5 * Profile.Max(p => p.Y); protected set { } }
        public override double Height { get => Profile.Max(p => p.X); protected set { } }
        #endregion
        #region Helpers
        public override Vector3D[] Points
        {
            get
            {
                int noSteps = Cyl.NoFaces;
                var pts = new Vector3D[noSteps * Profile.Count];
                Transform3D t = Position.Transf;
                for (int i = 0; i < Profile.Count; ++i)
                    for (int j = 0; j < noSteps; ++j)
                {
                    double angle = j * 2.0 * Math.PI / noSteps;
                    var vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i * noSteps + j] = t.transform(Profile[i].Y * vRadius + Profile[i].X * Vector3D.XAxis);
                }
                return pts;
            }
        }
        public Vector3D[] GetTopPoints()
        {
            Transform3D t = Position.Transf;
            Vector3D[] pts = new Vector3D[Cyl.NoFaces];
            Vector2D pfPoint = Profile.LastOrDefault();
            for (int i = 0; i < Cyl.NoFaces; ++i)
            {
                double angle = i * 2.0 * Math.PI / Cyl.NoFaces;
                var vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                pts[i] = t.transform(0.5 * pfPoint.Y * vRadius + pfPoint.X * Vector3D.XAxis);
            }
            return pts;
        }

        public Vector3D[] GetBottomPoints()
        {
            Transform3D t = Position.Transf;
            Vector3D[] pts = new Vector3D[NoFaces];
            Vector2D pfPoint = Profile.FirstOrDefault();
            for (int i = 0; i < NoFaces; ++i)
            {
                double angle = i * 2.0 * Math.PI / NoFaces;
                var vRadius = new Vector3D(pfPoint.X, Math.Cos(angle), Math.Sin(angle));
                pts[i] = t.transform(0.5 * pfPoint.Y * vRadius + pfPoint.X * Vector3D.XAxis);
            }
            return pts;
        }

        public Face[] GetFaceWalls()
        {
            Transform3D t = Position.Transf;
            Face[] faces = new Face[NoFaces * (Profile.Count - 1)];
            for (int i = 0; i < Profile.Count - 1; ++i)
            {
                Vector2D v1 = Profile[i];
                Vector2D v2 = Profile[i + 1];
                for (int j = 0; j < NoFaces; ++j)
                {
                    double angleBeg = j * 2.0 * Math.PI / NoFaces;
                    double angleEnd = (j + 1) * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(0.5 * v1.Y * vRadiusBeg + v1.X * Vector3D.XAxis);
                    vertices[1] = t.transform(0.5 * v1.Y * vRadiusEnd + v1.X * Vector3D.XAxis);
                    vertices[2] = t.transform(0.5 * v2.Y * vRadiusEnd + v2.X * Vector3D.XAxis);
                    vertices[3] = t.transform(0.5 * v2.Y * vRadiusBeg + v2.X * Vector3D.XAxis);
                    faces[i * NoFaces + j] = new Face(PickId, vertices, "CYLINDER") { ColorFill = Color };
                }
            }
            return faces;
        }
        #endregion
    }
}
