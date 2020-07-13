#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region Cyl
    public abstract class Cyl : Drawable
    {
        public Cyl(uint pickId) : base(pickId) {}
        public CylPosition Position { get; set; } = new CylPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_Z_P);
        public abstract double RadiusOuter { get; protected set; }
        public double DiameterOuter => 2.0 * RadiusOuter;
        public abstract double Height { get; protected set; }
        public BBox3D BBox => new BBox3D(
            new Vector3D(-RadiusOuter, -RadiusOuter, 0.0) + Position.XYZ
            , new Vector3D(RadiusOuter, RadiusOuter, Height) + Position.XYZ);
        public override Vector3D Center => Position.XYZ + 0.5 * Height * HalfAxis.ToVector3D(Position.Direction);

        public static int NoFaces => 36;

        public abstract double MaxRadius { get; }
        public abstract double MaxRadiusHeight { get; }
        public abstract double RadiusTop { get; }
        public abstract double RadiusBottom { get; }

        public virtual Vector3D[] MaxRadiusPoints => CircPoints(MaxRadius, MaxRadiusHeight);
        public virtual Vector3D[] BottomPoints => CircPoints(RadiusBottom, 0.0);
        public virtual Vector3D[] TopPoints => CircPoints(RadiusTop, Height);

        protected virtual Vector3D[] CircPoints(double radius, double height)
        {
            Transform3D t = Position.Transf;
            Vector3D[] pts = new Vector3D[NoFaces];
            for (int i = 0; i < NoFaces; ++i)
            {
                double angle = i * 2.0 * Math.PI / NoFaces;
                Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                pts[i] = t.transform(radius * vRadius + height * Vector3D.XAxis);
            }
            return pts;
        }
    }
    #endregion

    public class Cylinder : Cyl
    {
        #region Data members
        public override double RadiusOuter { get; protected set; }
        public override double Height { get; protected set; }
        public double RadiusInner { get; private set; }
        public override double RadiusBottom => RadiusOuter;
        public override double RadiusTop => RadiusOuter;
        #endregion

        #region Constructor
        public Cylinder(uint pickId, double radiusOuter, double radiusInner, double height, Color colorTop, Color colorWallOuter, Color colorWallInner)
            : base(pickId)
        {
            PickId = pickId;
            RadiusOuter = radiusOuter;
            RadiusInner = radiusInner;
            Height = height;
            ColorTop = colorTop;
            ColorWallOuter = colorWallOuter;
            ColorWallInner = colorWallInner;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties)
            : base(pickId)
        {
            PickId = pickId;
            RadiusOuter = cylProperties.RadiusOuter;
            RadiusInner = cylProperties.RadiusInner;
            Height = cylProperties.Height;
            ColorTop = cylProperties.ColorTop;
            ColorWallOuter = cylProperties.ColorWallOuter;
            ColorWallInner = cylProperties.ColorWallInner;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties, CylPosition cylPosition)
            : base(pickId)
        {
            PickId = pickId;
            RadiusOuter = cylProperties.RadiusOuter;
            RadiusInner = cylProperties.RadiusInner;
            Height = cylProperties.Height;
            ColorTop = cylProperties.ColorTop;
            ColorWallOuter = cylProperties.ColorWallOuter;
            ColorWallInner = cylProperties.ColorWallInner;
            Position = cylPosition;
        }
        #endregion

        #region Public properties
        public double DiameterInner => 2.0 * RadiusInner;
        public Face[] FacesWalls
        {
            get
            {
                Transform3D t = Position.Transf;

                bool showInnerFaces = RadiusInner > 0;
                Face[] faces = new Face[(showInnerFaces ? 2 : 1) * NoFaces];
                if (showInnerFaces)
                {
                    for (int i = 0; i < NoFaces; ++i)
                    {
                        double angleBeg = i * 2.0 * Math.PI / NoFaces;
                        double angleEnd = (i + 1) * 2.0 * Math.PI / NoFaces;
                        Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                        Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                        Vector3D[] vertices = new Vector3D[4];
                        vertices[0] = t.transform(RadiusInner * vRadiusBeg);
                        vertices[1] = t.transform(RadiusInner * vRadiusBeg + Height * Vector3D.XAxis);
                        vertices[2] = t.transform(RadiusInner * vRadiusEnd + Height * Vector3D.XAxis);
                        vertices[3] = t.transform(RadiusInner * vRadiusEnd);
                        faces[i] = new Face(PickId, vertices, "CYLINDER") { ColorFill = ColorWallInner };
                    }
                }

                for (int i = 0; i < NoFaces; ++i)
                {
                    double angleBeg = i * 2.0 * Math.PI / NoFaces;
                    double angleEnd = (i + 1) * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(RadiusOuter * vRadiusBeg);
                    vertices[1] = t.transform(RadiusOuter * vRadiusEnd);
                    vertices[2] = t.transform(RadiusOuter * vRadiusEnd + Height * Vector3D.XAxis);
                    vertices[3] = t.transform(RadiusOuter * vRadiusBeg + Height * Vector3D.XAxis);
                    faces[(showInnerFaces ? NoFaces : 0) + i] = new Face(PickId, vertices, "CYLINDER") { ColorFill = ColorWallOuter };
                }
                return faces;
            }
        }
        public Face[] FacesTop
        {
            get
            {
                Transform3D t = Position.Transf;
                Face[] faces = new Face[2 * NoFaces];
                for (uint i = 0; i < NoFaces; ++i)
                {
                    double angleBeg = i * 2.0 * Math.PI / NoFaces;
                    double angleEnd = (i + 1) * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(RadiusInner * vRadiusBeg + Height * Vector3D.XAxis);
                    vertices[1] = t.transform(RadiusOuter * vRadiusBeg + Height * Vector3D.XAxis);
                    vertices[2] = t.transform(RadiusOuter * vRadiusEnd + Height * Vector3D.XAxis);
                    vertices[3] = t.transform(RadiusInner * vRadiusEnd + Height * Vector3D.XAxis);
                    faces[i] = new Face(PickId, vertices, "CYLINDER");
                    faces[i].ColorFill = ColorTop;
                }

                for (uint i = 0; i < NoFaces; ++i)
                {
                    double angleBeg = i * 2.0 * Math.PI / NoFaces;
                    double angleEnd = (i + 1) * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(RadiusInner * vRadiusEnd);
                    vertices[1] = t.transform(RadiusOuter * vRadiusEnd);
                    vertices[2] = t.transform(RadiusOuter * vRadiusBeg);
                    vertices[3] = t.transform(RadiusInner * vRadiusBeg);
                    faces[NoFaces + i] = new Face(PickId, vertices, ColorTop, Color.Black, "CYLINDER", true);
                }
                return faces;
            }        
        }
        public Color ColorWallInner { get; }
        public Color ColorWallOuter { get; }
        public Color ColorTop { get; }
        public Color ColorPath => Color.Black; 
        public List<Texture> Textures { get; set; } = new List<Texture>();
        public override Vector3D[] Points
        {
            get
            {
                int noSteps = NoFaces;
                var pts = new Vector3D[2* noSteps];
                Transform3D t = Position.Transf;
                Vector3D vDir = HalfAxis.ToVector3D(Position.Direction);

                for (int i = 0; i < noSteps; ++i)
                {
                    double angle = i *  2.0 * Math.PI / noSteps;
                    var vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(RadiusOuter * vRadius);
                    pts[i + noSteps] = pts[i] + Height *vDir;
                }
                return pts;
            }
        }
        public Vector3D[] TopPointsInner => CircPoints(RadiusInner, Height);
        public override double MaxRadius => RadiusOuter;
        public override double MaxRadiusHeight => Height;
        #endregion

        #region Drawable overrides
        public override void Draw(Graphics3D graphics)
        {
            System.Drawing.Graphics g = graphics.Graphics;
            Vector3D viewDir = graphics.ViewDirection;

            // build pen path
            Brush brushPath = new SolidBrush(ColorPath);
            Pen penPathThick = new Pen(brushPath, 1.5f);

            // bottom (draw only path)
            Point[] ptsBottom = graphics.TransformPoint(BottomPoints);
            g.DrawPolygon(penPathThick, ptsBottom);
            // top
            Point[] ptsTop = graphics.TransformPoint(TopPoints);
            g.DrawPolygon(penPathThick, ptsTop);

            // outer wall
            Face[] facesWalls = FacesWalls;
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
            Color colorTop = Color.FromArgb((int)(ColorTop.R * cosTop), (int)(ColorTop.G * cosTop), (int)(ColorTop.B * cosTop));
            Brush brushTop = new SolidBrush(colorTop);
            bool topVisible = Vector3D.DotProduct(HalfAxis.ToVector3D(Position.Direction), viewDir) < 0;

            if (DiameterInner > 0)
            {
                Face[] facesTop = FacesTop;
                foreach (Face face in facesTop)
                {
                    try
                    {
                        Vector3D normal = face.Normal;

                        // visible ?
                        if (!face.IsVisible(viewDir))
                            continue;
                        // color
                        // draw polygon
                        Point[] ptsFace = graphics.TransformPoint(face.Points);
                        g.FillPolygon(brushTop, ptsFace);
                    }
                    catch (Exception /*ex*/)
                    {
                    }
                }
            }
            else
            {
                if (topVisible)
                    g.FillPolygon(brushTop, ptsTop);
                else
                    g.FillPolygon(brushTop, ptsBottom);
            }

            if (topVisible)
                g.DrawPolygon(penPathThick, ptsTop);
            else
                g.DrawPolygon(penPathThick, ptsBottom);
        }
        public override void Draw(Graphics2D graphics)
        {
            System.Drawing.Graphics g = graphics.Graphics; 

            // get points
            Point[] ptOuter = graphics.TransformPoint(TopPoints); ;
            Point[] ptInner = graphics.TransformPoint(TopPointsInner); ;

            // top color
            Brush brushSolid = new SolidBrush(ColorTop);
            g.FillPolygon(brushSolid, ptOuter);
            if (null != ptInner)
            {
                // hole -> drawing polygon with background color
                Brush brushBackground = new SolidBrush(graphics.ColorBackground);
                g.FillPolygon(brushBackground, ptInner);
            }
            // bottom (draw only path)
            Brush brushPath = new SolidBrush(ColorPath);
            Pen penPath = new Pen(brushPath);
            g.DrawPolygon(penPath, ptOuter);
        }
        public override void DrawBegin(Graphics3D graphics) {}
        public override void DrawEnd(Graphics3D graphics)  {}
        #endregion
    }
}
