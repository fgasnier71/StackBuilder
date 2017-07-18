#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sharp3D
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics.IsometricBlocks
{
    // see tutorial and javascript code provided by Shaun Lebron
    // https://github.com/shaunlebron/IsometricBlocks
    //

    #region IsoPos
    internal struct IsoPos
    {
        public IsoPos(double x, double y, double h, double v)
        { X = x; Y = y;  H = h; V = v; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double V { get; set; }
    }
    internal struct BB
    {
        public BB(Vector3D ptMin, Vector3D ptMax)
        { PtMin = ptMin; PtMax = ptMax; }
        public Vector3D PtMin { get; set; }
        public Vector3D PtMax { get; set; }
    }
    internal struct IsoBB
    {
        public IsoBB(IsoPos posMin, IsoPos posMax) { PosMin = posMin; PosMax = posMax; }
        public IsoPos PosMin { get; set; }
        public IsoPos PosMax { get; set; }
    }
    #endregion

    #region Camera
    internal class Camera
    {
        #region Data members
        private Vector3D _origin;
        private double _scale;
        #endregion

        #region Constructor
        public Camera(Vector3D origin, double scale)
        {
            _origin = origin; _scale = scale;
        }
        #endregion

        #region Public methods
        public IsoPos SpaceToIso(Vector3D spacePos)
        {
            var z = spacePos.Z;

            var x = spacePos.X + z;
            var y = spacePos.Y + z;

            return new IsoPos(
                x,
                y,
                (x - y) * Math.Sqrt(3.0) / 2.0,     // Math.cos(Math.PI/6)
                (x + y) / 2.0                       // Math.sin(Math.PI/6)
                );
		}
        private Vector2D IsoToScreen(IsoPos isoPos)
        {
            return new Vector2D(
                isoPos.H * this._scale + this._origin.X,
                -isoPos.V * this._scale + this._origin.Y
                );
		}
        private Vector2D SpaceToScreen(Vector3D spacePos)
        {
            return IsoToScreen(SpaceToIso(spacePos));
        }
        #endregion
    }
    #endregion

    #region Block
    internal class Block
    {
        #region Constructor
        public Block(Box b, Camera camera)
        {
            InternalBox = b;
            InternalCamera = camera;
        }
        #endregion

        #region Accessors
        public Box InternalBox { get; set; }
        public Camera InternalCamera { get; set; }
        public BB Bounds
        {
            get
            {
                return new BB(InternalBox.BBox.PtMin, InternalBox.BBox.PtMax);
            }
        }
        public IsoBB IsoBounds
        {
            get
            {

                IsoPos posMin = new IsoPos(0.0, 0.0, 0.0, 0.0);
                IsoPos posMax = new IsoPos(0.0, 0.0, 0.0, 0.0);
                return new IsoBB(posMin, posMax);
            }
        }
        #endregion

        #region Helpers
        public enum SepAxis
        {
            X,
            Y,
            Z,
            H,
            V,
            Unknown
        }
        private static bool AreRangesDisjoint(double amin, double amax, double bmin, double bmax)
        {
            return (amax <= bmin || bmax <= amin);
        }
        public static SepAxis GetIsoSepAxis(Block block_a, Block block_b)
        {
            IsoBB a = block_a.IsoBounds;
            IsoBB b = block_b.IsoBounds;

            SepAxis sepAxis = SepAxis.Unknown;
            if (AreRangesDisjoint(a.PosMin.X, a.PosMax.X, b.PosMin.X, b.PosMax.X))
            {
                sepAxis = SepAxis.X;
            }
            if (AreRangesDisjoint(a.PosMin.Y, a.PosMax.Y, b.PosMin.Y, b.PosMax.Y))
            {
                sepAxis = SepAxis.Y;
            }
            if (AreRangesDisjoint(a.PosMin.H, a.PosMax.H, b.PosMin.H, b.PosMax.H))
            {
                sepAxis = SepAxis.H;
            }
            return sepAxis;
        }
        public static SepAxis GetSpaceSepAxis(Block block_a, Block block_b)
        {
            BB a = block_a.Bounds, b = block_b.Bounds;
            SepAxis sepAxis = SepAxis.Unknown;
            if (AreRangesDisjoint(a.PtMin.X, a.PtMax.X, b.PtMin.X, b.PtMax.X))
            {
                sepAxis = SepAxis.X;
            }
            else if (AreRangesDisjoint(a.PtMin.Y, a.PtMax.Y, b.PtMin.Y, b.PtMax.Y))
            {
                sepAxis = SepAxis.Y;
            }
            else if (AreRangesDisjoint(a.PtMin.Z, a.PtMax.Z, b.PtMin.Z, b.PtMax.Z))
            {
                sepAxis = SepAxis.Z;
            }
            return sepAxis;
        }
        public static Block GetFrontBlock(Block block_a, Block block_b)
        {
            // If no isometric separation axis is found,
            // then the two blocks do not overlap on the screen.
            // This means there is no "front" block to identify.
            if (SepAxis.Unknown == GetIsoSepAxis(block_a, block_b))
            {
                return null;
            }

            // Find a 3D separation axis, and use it to determine
            // which block is in front of the other.
            var a = block_a.Bounds;
            var b = block_b.Bounds;
            switch (GetSpaceSepAxis(block_a, block_b))
            {
                case SepAxis.X: return (a.PtMin.X < b.PtMin.X) ? block_a : block_b;
                case SepAxis.Y: return (a.PtMin.Y < b.PtMin.Y) ? block_a : block_b;
                case SepAxis.Z: return (a.PtMin.Z < b.PtMin.Z) ? block_b : block_a;
                default: throw new Exception("blocks must be non-intersecting");
            }
        }
        #endregion
    }
    #endregion

    #region IsometricBlocksOrderer
    public class IsometricBlocksOrderer : BoxOrderer
    {
        public override List<Box> GetSortedList()
        {
            return new List<Box>();
        }
    }
    #endregion
}
