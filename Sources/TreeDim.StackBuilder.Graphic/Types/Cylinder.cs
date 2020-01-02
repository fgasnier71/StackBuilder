#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class Cylinder : Drawable
    {
        #region Data members
        public uint PickId { get; private set; } = 0;
        public double RadiusOuter { get; private set; }
        public double RadiusInner { get; private set; }
        public uint NoFaces { get; private set; } = 36;
        private CylPosition _cylPosition = new CylPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_Z_P);
        #endregion

        #region Constructor
        public Cylinder(uint pickId, double radiusOuter, double radiusInner, double height, Color colorTop, Color colorWallOuter, Color colorWallInner)
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
        {
            PickId = pickId;
            RadiusOuter = cylProperties.RadiusOuter;
            RadiusInner = cylProperties.RadiusInner;
            Height = cylProperties.Height;
            ColorTop = cylProperties.ColorTop;
            ColorWallOuter = cylProperties.ColorWallOuter;
            ColorWallInner = cylProperties.ColorWallInner;
            _cylPosition = cylPosition;
        }
        #endregion

        #region Public properties
        public double DiameterOuter => 2.0 * RadiusOuter;
        public double DiameterInner => 2.0 * RadiusInner;
        public double Height { get; }
        public CylPosition Position  { get { return _cylPosition; } }
        public Face[] FacesWalls
        {
            get
            {
                Transform3D t = _cylPosition.Transf;

                bool showInnerFaces = RadiusInner > 0;
                Face[] faces = new Face[(showInnerFaces ? 2 : 1) * NoFaces];
                if (showInnerFaces)
                {
                    for (int i = 0; i < NoFaces; ++i)
                    {
                        double angleBeg = (double)i * 2.0 * Math.PI / (double)NoFaces;
                        double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)NoFaces;
                        Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                        Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                        Vector3D[] vertices = new Vector3D[4];
                        vertices[0] = t.transform(RadiusInner * vRadiusBeg);
                        vertices[1] = t.transform(RadiusInner * vRadiusBeg + Height * Vector3D.XAxis);
                        vertices[2] = t.transform(RadiusInner * vRadiusEnd + Height * Vector3D.XAxis);
                        vertices[3] = t.transform(RadiusInner * vRadiusEnd);
                        faces[i] = new Face(PickId, vertices, true);
                        faces[i].ColorFill = ColorWallInner;
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
                    faces[(showInnerFaces ? NoFaces : 0) + i] = new Face(PickId, vertices, true);
                    faces[(showInnerFaces ? NoFaces : 0) + i].ColorFill = ColorWallOuter;
                }
                return faces;
            }
        }
        public Face[] FacesTop
        {
            get
            {
                Transform3D t = _cylPosition.Transf;
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
                    faces[i] = new Face(PickId, vertices, true);
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
                    faces[NoFaces + i] = new Face(PickId, vertices, true)
                    {
                        ColorFill = ColorTop
                    };
                }
                return faces;
            }        
        }
        public Color ColorWallInner { get; }
        public Color ColorWallOuter { get; }
        public Color ColorTop { get; }
        public Color ColorPath
        {
            get { return Color.Black; }
        }
        public List<Texture> Textures { get; set; } = new List<Texture>();
        public Vector3D[] BottomPoints
        {
            get
            {
                Transform3D t = _cylPosition.Transf;
                Vector3D[] pts = new Vector3D[NoFaces];
                for (int i = 0; i < NoFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(RadiusOuter * vRadius);
                }
                return pts;
            }
        }
        public Vector3D[] TopPoints
        {
            get
            {
                Transform3D t = _cylPosition.Transf;
                Vector3D[] pts = new Vector3D[NoFaces];
                for (int i = 0; i < NoFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(RadiusOuter * vRadius + Height * Vector3D.XAxis);
                }
                return pts;
            }
        }
        public override Vector3D[] Points
        {
            get
            {
                uint noSteps = NoFaces;
                var pts = new Vector3D[2* noSteps];
                Transform3D t = _cylPosition.Transf;
                Vector3D vDir = HalfAxis.ToVector3D(_cylPosition.Direction);

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
        public Vector3D[] TopPointsInner
        { 
           get
            {
                Transform3D t = _cylPosition.Transf;
                Vector3D[] pts = new Vector3D[NoFaces];
                for (int i = 0; i < NoFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / NoFaces;
                    Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(RadiusInner * vRadius + Height * Vector3D.XAxis);
                }
                return pts;
            }        
        }
        public BBox3D BBox
        {
            get
            {
                return new BBox3D(
                    new Vector3D(-RadiusOuter, -RadiusOuter, 0.0) + _cylPosition.XYZ
                    , new Vector3D(RadiusOuter, RadiusOuter, Height) + _cylPosition.XYZ
                    );
            }
        }
        #endregion

        #region Drawable overrides
        public override void DrawBegin(Graphics3D graphics)
        {            
        }
        public override void Draw(Graphics3D graphics)
        {
        }
        public override void DrawEnd(Graphics3D graphics)
        {
        }
        #endregion
    }
}
