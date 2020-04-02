#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using MIConvexHull;
using treeDiM.StackBuilder.Basics;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class Pack : Box
    {
        #region Constructor
        public Pack(uint pickId, PackProperties packProperties)
            : base(pickId, packProperties)
        {
            _packProperties = packProperties;
            _arrangement = _packProperties.Arrangement;
            if (packProperties.Content is PackableBrick boxProperties)
                _innerBox = new Box(0, boxProperties);
            else if (packProperties.Content is CylinderProperties cylProp)
                _innerBox = new Cylinder(0, cylProp);
            else if (packProperties.Content is BottleProperties bottleProp)
                _innerBox = new Bottle(0, bottleProp);
            ForceTransparency = false;
            BoxPosition = BoxPosition.Zero;
        }
        public Pack(uint pickId, PackProperties packProperties, BoxPosition position)
            : base(pickId, packProperties, position)
        {
            _packProperties = packProperties;
            _arrangement = _packProperties.Arrangement;
            if (packProperties.Content is PackableBrick boxProperties)
                _innerBox = new Box(0, boxProperties);
            else if (packProperties.Content is CylinderProperties cylProp)
                _innerBox = new Cylinder(0, cylProp);
            else if (packProperties.Content is BottleProperties bottleProp)
                _innerBox = new Bottle(0, bottleProp);
            ForceTransparency = false;
        }
        #endregion

        #region Public properties
        public bool ForceTransparency { get; set; } = false;
        #endregion

        #region Drawable implementation
        public override void Draw(Graphics2D graphics)
        {
            var drawables = InnerDrawables;
            foreach (var b in drawables)
            {
                b.Draw(graphics);
            }
        }
        public override void Draw(Graphics3D graphics)
        {
            System.Drawing.Graphics g = graphics.Graphics;
            var viewDir = graphics.ViewDirection;

            // draw tray back faces
            if (null != _packProperties.Tray)
            {
                foreach (Face f in TrayFaces)
                {
                    graphics.Draw(
                        f
                        , Graphics3D.FaceDir.BACK
                        , _packProperties.Tray.Color
                        , false);
                }
            }
            // draw inner boxes
            if (null == _packProperties.Wrap
                || _packProperties.Wrap.Type == PackWrapper.WType.WT_POLYETHILENE)
            {
                var innerDrawables = InnerDrawables;
                innerDrawables.Sort( new DrawableComparerSimplifiedPainterAlgo(graphics.GetWorldToEyeTransformation()) );
                foreach (var b in innerDrawables)
                    b.Draw(graphics);
            }
            if (null != _packProperties.Wrap)
            {
                // draw front faces
                foreach (Face f in Faces)
                {
                    graphics.Draw(
                        f
                        , Graphics3D.FaceDir.FRONT
                        , _packProperties.Wrap.Color
                        , _packProperties.Wrap.Transparent);
                }
            }
            if (null != _packProperties.Tray)
            {
                // draw tray front faces
                foreach (Face f in TrayFaces)
                {
                    graphics.Draw(
                        f
                        , Graphics3D.FaceDir.FRONT
                        , _packProperties.Tray.Color
                        , false);
                }
            }

            // draw top points line
            if (_packProperties.Content is RevSolidProperties)
            {
                Color colorTopPoints = (null != _packProperties.Wrap) ? _packProperties.Wrap.Color : Color.White;
                Pen penTopPoints = new Pen(new SolidBrush(colorTopPoints), 1.5f);
                var listConvexHull1 = new List<Vector3D>();
                foreach (var pt in ConvexHullResult)
                    listConvexHull1.Add(GlobalTransformation.transform(pt));
                var tPoints = graphics.TransformPoint(listConvexHull1.ToArray());
                int tPointCount = tPoints.Length;
                for (int i = 1; i < tPointCount; ++i)
                    g.DrawLine(penTopPoints, tPoints[i - 1], tPoints[i]);
                g.DrawLine(penTopPoints, tPoints[tPointCount - 1], tPoints[0]);
            }

            // draw strappers
            Pen penBlack = new Pen(new SolidBrush(Color.Black), 1.5f);
            foreach (var sf in StrapperFaces)
            {
                if (sf.IsVisible(viewDir))
                {
                    // get color
                    double cosA = Math.Abs(Vector3D.DotProduct(sf.Normal, graphics.VLight));
                    Color color = Color.FromArgb((int)(sf.ColorFill.R * cosA), (int)(sf.ColorFill.G * cosA), (int)(sf.ColorFill.B * cosA));
                    // instantiate brush
                    Brush brushStrapper = new SolidBrush(color);
                    // get face points
                    Point[] pts = graphics.TransformPoint(sf.Points);
                    // fill polygon
                    g.FillPolygon(brushStrapper, pts);
                    // draw path
                    int ptCount = pts.Length;
                    for (int j = 1; j < ptCount; ++j)
                        g.DrawLine(penBlack, pts[j - 1], pts[j]);
                    g.DrawLine(penBlack, pts[ptCount - 1], pts[0]);
                }
            }
        }

        private Face[] TrayFaces
        {
            get
            {
                double height = _dim[2];
                if (null != _packProperties.Tray) height = _packProperties.Tray.Height;
                if (height <= 1.0)  height = 40.0;
                Vector3D position = BoxPosition.Position;
                Vector3D lengthAxis = HalfAxis.ToVector3D(BoxPosition.DirectionLength);
                Vector3D widthAxis = HalfAxis.ToVector3D(BoxPosition.DirectionWidth);
                Vector3D heightAxis = Vector3D.CrossProduct(lengthAxis, widthAxis);
                Vector3D[] points = new Vector3D[8];
                points[0] = position;
                points[1] = position + _dim[0] * lengthAxis;
                points[2] = position + _dim[0] * lengthAxis + _dim[1] * widthAxis;
                points[3] = position + _dim[1] * widthAxis;

                points[4] = position + height * heightAxis;
                points[5] = position + height * heightAxis + _dim[0] * lengthAxis;
                points[6] = position + height * heightAxis + _dim[0] * lengthAxis + _dim[1] * widthAxis;
                points[7] = position + height * heightAxis + _dim[1] * widthAxis;

                Face[] faces = new Face[5];
                faces[0] = new Face(PickId, new Vector3D[] { points[3], points[0], points[4], points[7] }, "PACK", false); // AXIS_X_N
                faces[1] = new Face(PickId, new Vector3D[] { points[1], points[2], points[6], points[5] }, "PACK", false); // AXIS_X_P
                faces[2] = new Face(PickId, new Vector3D[] { points[0], points[1], points[5], points[4] }, "PACK", false); // AXIS_Y_N
                faces[3] = new Face(PickId, new Vector3D[] { points[2], points[3], points[7], points[6] }, "PACK", false); // AXIS_Y_P
                faces[4] = new Face(PickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, "PACK", false); // AXIS_Z_N

                return faces;
            }
        }

        public List<Drawable> InnerDrawables
        {
            get
            { 
                List<Drawable> drawables = new List<Drawable>();
                uint pickId = 0;
                if (_packProperties.Content is PackableBrick boxProp)
                {
                    for (int i = 0; i < _arrangement.Length; ++i)
                        for (int j = 0; j < _arrangement.Width; ++j)
                            for (int k = 0; k < _arrangement.Height; ++k)
                                drawables.Add(
                                    new Box(pickId++, boxProp, GetPosition(i, j, k, _packProperties.Dim0, _packProperties.Dim1))
                                );
                }
                else if (_packProperties.Content is RevSolidProperties revSolid)
                {
                    double diameter = revSolid.Diameter;
                    double height = revSolid.Height;
                    double bottomThickness =  (null != _packProperties.Wrap ? 0.5 * _packProperties.Wrap.Thickness(2) : 0.0)
                                            + (null != _packProperties.Tray ? _packProperties.Tray.Thickness(2) : 0.0);

                    for (int j = 0; j < _arrangement.Width; ++j)
                    {
                        double xOffset = 0.0;
                        double y = 0.0;
                        int noX = _arrangement.Length;

                        switch (_packProperties.RevSolidLayout)
                        {
                            case PackProperties.EnuRevSolidLayout.ALIGNED:
                                y = ((double)j + 0.5) * diameter;
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_REGULAR:
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0)); 
                                xOffset = 0.5 * diameter * (j % 2);
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_MINUS1:
                                noX = _arrangement.Length - j % 2;
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0));
                                xOffset = 0.5 * diameter * (j % 2);
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_PLUS1:
                                noX = _arrangement.Length + j % 2;
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0));
                                xOffset = 0.5 * diameter * ((j+1) % 2);
                                break;
                        }
                        for (int i = 0; i < noX; ++i)
                        {
                            var vPos = new Vector3D(((int)i + 0.5) * diameter + xOffset, y, 0.0);
                            for (int k = 0; k < _arrangement.Height; ++k)
                            {
                                CylPosition cylPos = new CylPosition(vPos + (bottomThickness + k * height) * Vector3D.ZAxis, HalfAxis.HAxis.AXIS_Z_P);
                                if (_packProperties.Content is CylinderProperties cylinderProp)
                                    drawables.Add(new Cylinder(pickId++, cylinderProp, cylPos.Transform(GlobalTransformation)));
                                else if (_packProperties.Content is BottleProperties bottleProp)
                                    drawables.Add(new Bottle(pickId++, bottleProp, cylPos.Transform(GlobalTransformation)));
                            }
                        }
                    }
                }
                return drawables;
            }
        }

        private List<Vector3D> TopPoints
        {
            get
            {
                var listPoints = new List<Vector3D>();
                if (_packProperties.Content is RevSolidProperties revSolid)
                {
                    double diameter = revSolid.Diameter;
                    double height = revSolid.Height;
                    double bottomThickness = (null != _packProperties.Wrap ? 0.5 * _packProperties.Wrap.Thickness(2) : 0.0)
                                            + (null != _packProperties.Tray ? _packProperties.Tray.Thickness(2) : 0.0);

                    for (int j = 0; j < _arrangement.Width; ++j)
                    {
                        double xOffset = 0.0;
                        double y = 0.0;
                        int noX = _arrangement.Length;

                        switch (_packProperties.RevSolidLayout)
                        {
                            case PackProperties.EnuRevSolidLayout.ALIGNED:
                                y = ((double)j + 0.5) * diameter;
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_REGULAR:
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0));
                                xOffset = 0.5 * diameter * (j % 2);
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_MINUS1:
                                noX = _arrangement.Length - j % 2;
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0));
                                xOffset = 0.5 * diameter * (j % 2);
                                break;
                            case PackProperties.EnuRevSolidLayout.STAGGERED_PLUS1:
                                noX = _arrangement.Length + j % 2;
                                y = 0.5 * diameter * (1 + j * Math.Sqrt(3.0));
                                xOffset = 0.5 * diameter * ((j + 1) % 2);
                                break;
                        }
                        for (int i = 0; i < noX; ++i)
                        {
                            var vPos = new Vector3D(((int)i + 0.5) * diameter + xOffset, y, 0.0) + (bottomThickness + _arrangement.Height * height) * Vector3D.ZAxis;
                            double radius = revSolid.TopRadius;
                            for (int k=0; k<Cyl.NoFaces; ++k)
                            {
                                double angle = k * 2.0 * Math.PI / Cyl.NoFaces;
                                Vector3D vRadius = new Vector3D(radius * Math.Cos(angle), radius * Math.Sin(angle), 0.0);
                                listPoints.Add(vRadius + vPos);
                            }
                        }
                    }
                }

                return listPoints;
            }
        }

        private BoxPosition GetPosition(int i, int j, int k, int dim0, int dim1)
        {
            PackableBrick packable = _packProperties.Content as PackableBrick;
            double boxLength = packable.Dim(dim0);
            double boxWidth =  packable.Dim(dim1);
            double boxHeight =  packable.Dim(3 - dim0 - dim1);
            HalfAxis.HAxis dirLength = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis dirWidth = HalfAxis.HAxis.AXIS_Y_P;
            Vector3D vPosition = Vector3D.Zero;
            if (0 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = Vector3D.Zero;
            }
            else if (0 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(0.0, 0.0, packable.Width);
            }
            else if (1 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_X_N;
                vPosition = new Vector3D(packable.Width, 0.0, 0.0);
            }
            else if (1 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_N;
                dirWidth = HalfAxis.HAxis.AXIS_X_P;
                vPosition = new Vector3D(0.0, packable.Height, packable.Length);
            }
            else if (2 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(packable.Height, 0.0, packable.Width);
            }
            else if (2 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = new Vector3D(packable.Height, 0.0, 0.0);
            }
            // add offset
            vPosition += Vector3D.Zero;

            Vector3D vOffset = new Vector3D(
                0.5 * (_packProperties.Length - _packProperties.InnerLength)
                , 0.5 * (_packProperties.Width - _packProperties.InnerWidth)
                , 0.5 * (_packProperties.Height - _packProperties.InnerHeight)
                );

            // apply global transformation using _dir0 / _dir1
            return BoxPosition.Transform(
                new BoxPosition(
                    vPosition + vOffset + new Vector3D(i * boxLength, j * boxWidth, k * boxHeight)
                    , dirLength
                    , dirWidth)
                , GlobalTransformation
                );
        }

        private Transform3D GlobalTransformation
        {
            get
            {
                BoxPosition bp = new BoxPosition(Position, HalfAxis.ToHalfAxis(LengthAxis), HalfAxis.ToHalfAxis(WidthAxis));
                return bp.Transformation;
            }
        }
        private List<double[]> ListVector3DToListArray(List<Vector3D> points, int axis)
        {
            var listResult = new List<double[]>();
            foreach (var pt in points)
            {
                double x, y;
                switch (axis)
                {
                    case 0: x = pt.Y; y = pt.Z; break;
                    case 1: x = pt.X; y = pt.Z; break;
                    case 2: x = pt.X; y = pt.Y; break;
                    default: x = 0.0; y = 0.0; break;
                }
                listResult.Add(new double[] { x, y });
            }
            return listResult;
        }
        private List<Vector3D> ListVertex2DToVector3D(IList<DefaultVertex2D> vertices, double abs, int axis)
        {
            var listPoints = new List<Vector3D>();
            foreach (var v in vertices)
            {
                Vector3D point;
                switch (axis)
                {
                    case 0: point = new Vector3D(abs, v.X, v.Y); break;
                    case 1: point = new Vector3D(v.X, abs, v.Y); break;
                    case 2: point = new Vector3D(v.X, v.Y, abs); break;
                    default: point = Vector3D.Zero; break;
                }
                listPoints.Add(point);
            }
            if (1 == axis) listPoints.Reverse();

            return listPoints;
        }
        private List<Vector3D> ConvexHullResult
        {
            get
            {
                if (null == _convexHull)
                {
                    double coord = TopPoints[0].Z;
                    var convexHullResult = ConvexHull.Create2D(ListVector3DToListArray(TopPoints, 2), 1.0E-10);
                    if (null != convexHullResult.Result && convexHullResult.Result.Count > 2)
                        _convexHull =  ListVertex2DToVector3D(convexHullResult.Result, coord, 2);
                }
                return _convexHull;
            }
        }
        #endregion

        #region Data members
        private Drawable _innerBox;
        private PackArrangement _arrangement;
        private PackProperties _packProperties;
        private List<Vector3D> _convexHull;

        #endregion
    }
}
