#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region Layer classes (box layer + interlayer)
    /// <summary>
    /// Layer interface to be implemented by either BoxLayer or InterlayerPos
    /// </summary>
    public interface ILayer
    {
        double ZLow { get; }
        int BoxCount { get; }
        int CylinderCount { get; }
        int InterlayerCount { get; }
        BBox3D BoundingBox(Packable packable);
    }

    public class InterlayerPos : ILayer
    {
        #region Constructor
        public InterlayerPos(double zLow, int typeId)
        {
            ZLow = zLow;
            TypeId = typeId;
        }
        #endregion

        #region Interlayer specific properties
        public int TypeId { get; } = 0;
        #endregion

        #region ILayer implementation
        public double ZLow { get; } = 0.0;
        public int BoxCount { get { return 0; } }
        public int InterlayerCount {  get { return 1; } }
        public int CylinderCount {  get { return 0; } }
        public BBox3D BoundingBox(Packable packable)
        {
            BBox3D bbox = new BBox3D();
            Vector3D dimensions = packable.OuterDimensions;
            Vector3D[] pts = new Vector3D[8];
            pts[0] = new Vector3D(0.0, 0.0, ZLow);
            pts[1] = pts[0] + dimensions.X * Vector3D.XAxis;
            pts[2] = pts[0] + dimensions.Y * Vector3D.YAxis;
            pts[3] = pts[0] + dimensions.X * Vector3D.XAxis + dimensions.Y * Vector3D.YAxis;
            pts[4] = pts[0] + dimensions.Z * Vector3D.ZAxis;
            pts[5] = pts[1] + dimensions.Z * Vector3D.ZAxis;
            pts[6] = pts[2] + dimensions.Z * Vector3D.ZAxis;
            pts[7] = pts[3] + dimensions.Z * Vector3D.ZAxis;
            foreach (Vector3D pt in pts)
                bbox.Extend(pt);
            return bbox;
        }
        #endregion
    }

    /// <summary>
    /// A layer of box
    /// </summary>
    public class Layer3DBox : List<BoxPosition>, ILayer
    {
        #region Enums
        public enum SortType { XY, DIST, TOTAL };
        #endregion

        #region Constructor
        public Layer3DBox(double zLow, int layerIndex)
        {
            ZLow = zLow;
            LayerIndex = layerIndex;
        }
        #endregion

        #region Public properties
        public double ZLow { get; } = 0.0;
        public int BoxCount { get { return Count; } }
        public int InterlayerCount { get { return 0; } }
        public int CylinderCount { get { return 0; } }
        public int LayerIndex { get; }
        public double MaximumSpace { get; set; } = 0.0;
        #endregion

        #region Public methods
        /// <summary>
        /// adds a case position
        /// </summary>
        /// <param name="vPosition">Box 'origin' position (origin: lower left corner)</param>
        /// <param name="dirLength">Length axis direction</param>
        /// <param name="dirWidth">Width axis direction</param>
        public void AddPosition(Vector3D vPosition, HalfAxis.HAxis dirLength, HalfAxis.HAxis dirWidth)
        {
            Add(new BoxPosition(vPosition, dirLength, dirWidth));
        }
        public BBox3D BoundingBox(Packable packable)
        {
            BBox3D bbox = new BBox3D();
            if (packable is PackableBrick packableBrick)
            {
                Vector3D dimensions = packableBrick.OuterDimensions;
                foreach (BoxPosition bpos in this)
                    bbox.Extend(bpos.BBox(dimensions));
            }
            return bbox;
        }
        public double Thickness(BProperties bProperties)
        {
            if (Count == 0) return 0.0;
            BoxPosition bPos = this[0];
            Vector3D diagonale = bProperties.Length * HalfAxis.ToVector3D(bPos.DirectionLength)
                                + bProperties.Width * HalfAxis.ToVector3D(bPos.DirectionWidth)
                                + bProperties.Height * Vector3D.CrossProduct(HalfAxis.ToVector3D(bPos.DirectionLength), HalfAxis.ToVector3D(bPos.DirectionWidth));
            return Math.Abs(diagonale.Z);
        }
        public void Sort(Packable packable, SortType sortType)
        {
            Vector3D dimensions = packable.OuterDimensions;
            Vector3D minPoint = BoundingBox(packable).PtMin;
            switch (sortType)
            {
                case SortType.XY: Sort(new ComparerBoxPositionXY(dimensions)); break;
                case SortType.DIST : Sort(new ComparerBoxPositionDist(dimensions, minPoint)); break;
                default: break;
            }
        }
        #endregion

        #region Data members
        #endregion
    }

    #region BoxPosition comparers
    internal class ComparerBoxPositionXY : IComparer<BoxPosition>
    {
        #region Constructor
        public ComparerBoxPositionXY(Vector3D dimensions) { Dimensions = dimensions; }
        private Vector3D Dimensions { get; }
        #endregion
        #region Implement IComparer<BoxPosition>
        public int Compare(BoxPosition boxPos1, BoxPosition boxPos2)
        {
            Vector3D vCenter1 = boxPos1.Center(Dimensions);
            Vector3D vCenter2 = boxPos2.Center(Dimensions);
            int xdiff = vCenter1.X.CompareTo(vCenter2.X);
            if (xdiff != 0)
                return xdiff;
            else
                return vCenter1.Y.CompareTo(vCenter2.Y);
        }
        #endregion
    }
    internal class ComparerBoxPositionDist : IComparer<BoxPosition>
    {
        #region Constructor
        public ComparerBoxPositionDist(Vector3D dimensions, Vector3D minPoint) { Dimensions = dimensions; MinPoint = minPoint; }
        private Vector3D Dimensions { get; }
        private Vector3D MinPoint { get; }
        #endregion

        public int Compare(BoxPosition boxPos1, BoxPosition boxPos2)
        {
            double dist1 = (boxPos1.Center(Dimensions) - MinPoint).GetLength();
            double dist2 = (boxPos2.Center(Dimensions) - MinPoint).GetLength();

            if (dist1 < dist2)
                return -1;
            else if (dist1 > dist2)
                return 1;
            else
                return 0;
            
        }
    }
    #endregion

    /// <summary>
    /// A layer of cylinders
    /// </summary>
    public class Layer3DCyl : List<Vector3D>, ILayer
    {
        #region Data members
        double _zLower;
        #endregion

        #region Constructor
        public Layer3DCyl(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region Public properties
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount { get { return 0; } }
        public int InterlayerCount { get { return 0; } }
        public int CylinderCount { get { return Count; } }
        #endregion

        #region Public methods
        /// <summary>
        /// Compute layer bouding box
        /// </summary>
        /// <param name="bProperties">Case properties</param>
        /// <returns>bounding box</returns>
        public BBox3D BoundingBox(Packable packable)
        {
            BBox3D bbox = new BBox3D();
            if (packable is RevSolidProperties cylProperties)
            {
                double radius = cylProperties.RadiusOuter;
                double height = cylProperties.Height;
                foreach (Vector3D pos in this)
                {
                    Vector3D[] pts = new Vector3D[8];
                    pts[0] = pos - radius * Vector3D.XAxis - radius * Vector3D.YAxis;
                    pts[1] = pos + radius * Vector3D.XAxis - radius * Vector3D.YAxis;
                    pts[2] = pos + radius * Vector3D.XAxis + radius * Vector3D.YAxis;
                    pts[3] = pos - radius * Vector3D.XAxis + radius * Vector3D.YAxis;
                    pts[4] = pos - radius * Vector3D.XAxis - radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                    pts[5] = pos + radius * Vector3D.XAxis - radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                    pts[6] = pos + radius * Vector3D.XAxis + radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                    pts[7] = pos - radius * Vector3D.XAxis + radius * Vector3D.YAxis + height * Vector3D.ZAxis;

                    foreach (Vector3D pt in pts)
                        bbox.Extend(pt);
                }
            }
            return bbox;
        }
        public double Thickness(CylinderProperties cylProperties)
        {
            if (Count == 0) return 0.0;
            return cylProperties.Height;
        }
        #endregion
    }
    #endregion

    #region Layer descriptor
    public class LayerDescriptor
    {
        #region Data members
        private bool _swapped = false;
        private bool _hasInterlayer = true;
        #endregion

        #region Constructors
        public LayerDescriptor()
        { 
        }
        public LayerDescriptor(bool swapped, bool hasInterlayer)
        {
            _swapped = swapped; _hasInterlayer = hasInterlayer;
        }
        #endregion

        #region Public properties
        public bool Swapped { get { return _swapped; } set { _swapped = value; } }
        public bool HasInterlayer { get { return _hasInterlayer; } set { _hasInterlayer = value; } }
        #endregion
    }
    #endregion
}