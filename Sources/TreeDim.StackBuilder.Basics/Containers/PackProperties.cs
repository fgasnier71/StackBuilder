using Sharp3D.Math.Core;
using System;
using System.Collections.Generic;
using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public class PackProperties : PackableBrickNamed
    {
        #region Enums
        public enum EnuRevSolidLayout
        {
            ALIGNED,
            STAGGERED_REGULAR,
            STAGGERED_MINUS1,
            STAGGERED_PLUS1
        };
        #endregion

        #region Public
        public PackProperties(Document doc
            , Packable packable
            , PackArrangement arrangement
            , HalfAxis.HAxis orientation, EnuRevSolidLayout revSolidLayout
            , PackWrapper wrapper
            , PackTray tray)
            : base(doc)
        {
            Content = packable;
            if (null != doc)
                Content.AddDependancy(this);
            Arrangement = arrangement;
            BoxOrientation = orientation;
            RevSolidLayout = revSolidLayout;
            Wrap = wrapper;
            Tray = tray;
        }
        #endregion

        #region Override PackableBrickNamed
        public override bool InnerContent(ref List<Pair<Packable, int>> listInnerPackables)
        {
            listInnerPackables = new List<Pair<Packable, int>>() { new Pair<Packable, int>(Content, Number) };
            return true;
        }
        /*
        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = Content;
            number = Number;
            return true;
        }*/
        public override bool IsCase => true;
        #endregion

        #region Data members
        public Packable Content { get; set; }
        public PackArrangement Arrangement { get; set; }
        public HalfAxis.HAxis BoxOrientation { get; set; }
        public EnuRevSolidLayout RevSolidLayout { get; set; } = EnuRevSolidLayout.ALIGNED;
        public PackWrapper Wrap { get; set; }
        public PackTray Tray { get; set; }
        #endregion
        public Vector3D InnerOffset => new Vector3D(
                0.5 * (Length - InnerLength),
                0.5 * (Width - InnerWidth),
                0.5 * (Height - InnerHeight)
                );
        public int Number
        {
            get
            {
                if (null != ContentBrick)
                    return Arrangement.Number;
                else
                {
                    switch (RevSolidLayout)
                    {
                        case EnuRevSolidLayout.ALIGNED: 
                        case EnuRevSolidLayout.STAGGERED_REGULAR:
                            return Arrangement.Number;
                        case EnuRevSolidLayout.STAGGERED_MINUS1:
                            return (Arrangement.Length * Arrangement.Width - Arrangement.Width/2) * Arrangement.Height;
                        case EnuRevSolidLayout.STAGGERED_PLUS1:
                            return (Arrangement.Length * Arrangement.Width + Arrangement.Width/2) * Arrangement.Height;
                        default:
                            return 0;
                    }
                }
            }
        }
        // Outer dimensions
        public bool HasForcedOuterDimensions { get; private set; } = false;
        public void ForceOuterDimensions(Vector3D outerDimensions)
        {
            HasForcedOuterDimensions = true;
            _outerDimensions = outerDimensions;
        }
        public override double Length => HasForcedOuterDimensions ? _outerDimensions.X : InnerLength + WrapperThickness(0) + TrayThickness(0);
        public override double Width => HasForcedOuterDimensions ? _outerDimensions.Y : InnerWidth + WrapperThickness(1) + TrayThickness(1);
        public override double Height => HasForcedOuterDimensions ? _outerDimensions.Z : InnerHeight + WrapperThickness(2) + TrayThickness(2);
        public override bool OrientationAllowed(HalfAxis.HAxis axis) => (axis == HalfAxis.HAxis.AXIS_Z_N) || (axis == HalfAxis.HAxis.AXIS_Z_P);

        private PackableBrick ContentBrick => Content as PackableBrick;
        private RevSolidProperties ContentRev => Content as RevSolidProperties;
        private double WrapperThickness(int dir) => null != Wrap ? Wrap.Thickness(dir) : 0.0;
        private double TrayThickness(int dir) => null != Tray ? Tray.Thickness(dir) : 0.0;

        public double BottomThickness => 0.5 * WrapperThickness(2) + TrayThickness(2); 
        // Inner dimensions
        public double InnerLength
        {
            get
            {
                if (Content is RevSolidProperties revSolid)
                {
                    switch (RevSolidLayout)
                    {
                        case EnuRevSolidLayout.ALIGNED:
                        case EnuRevSolidLayout.STAGGERED_MINUS1:
                            return Arrangement.Length * revSolid.Diameter;
                        case EnuRevSolidLayout.STAGGERED_REGULAR:
                            return (Arrangement.Length + 0.5) * revSolid.Diameter;
                        case EnuRevSolidLayout.STAGGERED_PLUS1:
                            return (Arrangement.Length + 1) * revSolid.Diameter;
                        default:
                            return 0.0;
                    }
                }
                else
                    return Arrangement.Length * ContentBrick.Dim(Dim0);
            }
        }
        public double InnerWidth
        {
            get
            {
                if (Content is RevSolidProperties revSolid)
                {
                    switch (RevSolidLayout)
                    {
                        case EnuRevSolidLayout.ALIGNED:
                            return Arrangement.Width * revSolid.Diameter;
                        case EnuRevSolidLayout.STAGGERED_REGULAR:
                        case EnuRevSolidLayout.STAGGERED_MINUS1:
                        case EnuRevSolidLayout.STAGGERED_PLUS1:
                            return ((Arrangement.Width - 1) * 0.5 * System.Math.Sqrt(3.0) + 1) * revSolid.Diameter;
                        default:
                            return 0.0;
                    }
                }
                else
                    return Arrangement.Width * ContentBrick.Dim(Dim1);
            }
        }
        public double InnerHeight
        {
            get
            {
                if (Content is RevSolidProperties revSolid)
                    return Arrangement.Height * revSolid.Height;
                else
                    return Arrangement.Height * ContentBrick.Dim(Dim2);
            }
        }
        // Weight
        public override double Weight => InnerWeight + (null != Wrap ? Wrap.Weight : 0.0);
        public double InnerWeight => Arrangement.Number * Content.Weight;
        public override OptDouble NetWeight => Arrangement.Number * Content.NetWeight;
        // Helpers
        public int Dim0 => DimIndex0(BoxOrientation);
        public int Dim1 => DimIndex1(BoxOrientation);
        public int Dim2 => 3 - Dim0 - Dim1;
        public static void GetDimensions(
            BoxProperties boxProperties
            , HalfAxis.HAxis boxOrientation
            , PackArrangement arrangement
            , ref double length, ref double width, ref double height)
        {
            if (null == boxProperties) return;
            length = arrangement.Length * boxProperties.Dim(DimIndex0(boxOrientation));
            width = arrangement.Width * boxProperties.Dim(DimIndex1(boxOrientation));
            height = arrangement.Height * boxProperties.Dim(3 - DimIndex0(boxOrientation) - DimIndex1(boxOrientation));
        }

        public static void GetDimensions(
            RevSolidProperties revSolid
            , EnuRevSolidLayout revSolidLayout
            , PackArrangement arrangement
            , ref double length, ref double width, ref double height)
        {
            if (null == revSolid) return;

            switch (revSolidLayout)
            {
                case EnuRevSolidLayout.ALIGNED:
                    length = arrangement.Length * revSolid.Diameter;
                    width = arrangement.Width * revSolid.Diameter;
                    break;
                case EnuRevSolidLayout.STAGGERED_REGULAR:
                    length = (arrangement.Length + 0.5) * revSolid.Diameter;
                    width = ((arrangement.Width - 1) * 0.5 * Math.Sqrt(3.0) + 1) * revSolid.Diameter;
                    break;
                case EnuRevSolidLayout.STAGGERED_MINUS1:
                    length = arrangement.Length * revSolid.Diameter;
                    width = ((arrangement.Width - 1) * 0.5 * Math.Sqrt(3.0) + 1) * revSolid.Diameter;
                    break;
                case EnuRevSolidLayout.STAGGERED_PLUS1:
                    length = (arrangement.Length + 1) * revSolid.Diameter;
                    width = ((arrangement.Width - 1) * 0.5 * Math.Sqrt(3.0) + 1) * revSolid.Diameter;
                    break;
                default:
                    length = 0.0; width = 0.0;
                    break;
            }

            height = arrangement.Height * revSolid.Height;
        }
        #region Non-Public Members
        private Vector3D _outerDimensions;
        public static HalfAxis.HAxis Orientation(int dim0, int dim1)
        {
            if (0 == dim0)
            {
                if (1 == dim1) return HalfAxis.HAxis.AXIS_Z_P;
                else if (2 == dim1) return HalfAxis.HAxis.AXIS_Y_N;
            }
            else if (1 == dim0)
            {
                if (0 == dim1) return HalfAxis.HAxis.AXIS_Z_N;
                else if (2 == dim1) return HalfAxis.HAxis.AXIS_X_N;
            }
            else if (2 == dim0)
            {
                if (0 == dim1) return HalfAxis.HAxis.AXIS_Y_P;
                else if (1 == dim1) return HalfAxis.HAxis.AXIS_X_P;
            }
            return HalfAxis.HAxis.AXIS_Z_P;        
        }
        private static int DimIndex0(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N: return 1;
                case HalfAxis.HAxis.AXIS_X_P: return 2;
                case HalfAxis.HAxis.AXIS_Y_N: return 0;
                case HalfAxis.HAxis.AXIS_Y_P: return 2;
                case HalfAxis.HAxis.AXIS_Z_N: return 1;
                case HalfAxis.HAxis.AXIS_Z_P: return 0;
                default: return 0;
            }
        }
        private static int DimIndex1(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N: return 2;
                case HalfAxis.HAxis.AXIS_X_P: return 1;
                case HalfAxis.HAxis.AXIS_Y_N: return 2;
                case HalfAxis.HAxis.AXIS_Y_P: return 0;
                case HalfAxis.HAxis.AXIS_Z_N: return 0;
                case HalfAxis.HAxis.AXIS_Z_P: return 1;
                default: return 1;
            }
        }
        protected override void RemoveItselfFromDependancies()
        {
            if (null != Content)
                Content.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        protected override string TypeName => Properties.Resources.ID_NAMEPACK;
        #endregion
    }
}
