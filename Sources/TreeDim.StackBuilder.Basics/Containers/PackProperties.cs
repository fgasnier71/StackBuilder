using Sharp3D.Math.Core;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public class PackProperties : PackableBrickNamed
    {
        public PackProperties(Document doc
            , PackableBrick box
            , PackArrangement arrangement
            , HalfAxis.HAxis orientation
            , PackWrapper wrapper)
            : base(doc)
        {
            _innerPackable = box;
            if (null != doc)
                _innerPackable.AddDependancy(this);

            Arrangement = arrangement;
            BoxOrientation = orientation;
            Wrap = wrapper;
        }

        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = _innerPackable;
            number = Arrangement.Number;
            return true;
        }

        public override bool IsCase => true;

        /// <summary>
        /// set/get reference to wrapped box
        /// </summary>
        public PackableBrick Box
        {
            get { return _innerPackable; }
            set { _innerPackable = value; }
        }
        public PackArrangement Arrangement { get; set; }
        public HalfAxis.HAxis BoxOrientation { get; set; }
        public PackWrapper Wrap { get; set; }
        public Vector3D InnerOffset
        {
            get
            {
                return new Vector3D(
                0.5*(Length-InnerLength),
                0.5*(Width-InnerWidth),
                0.5*(Height-InnerHeight)
                );
            }
        }

        // Outer dimensions
        public bool HasForcedOuterDimensions => _forceOuterDimensions;

        public void ForceOuterDimensions(Vector3D outerDimensions)
        {
            _forceOuterDimensions = true;
            _outerDimensions = outerDimensions;
        }

        public override double Length
        {
            get
            {
                if (_forceOuterDimensions)
                    return _outerDimensions.X;
                else
                    return InnerLength + Wrap.Thickness(0); 
            }
        }
        public override double Width
        {
            get
            {
                if (_forceOuterDimensions)
                    return _outerDimensions.Y;
                else
                    return InnerWidth + Wrap.Thickness(1);
            }
        }
        public override double Height
        {
            get
            {
                if (_forceOuterDimensions)
                    return _outerDimensions.Z;
                else
                    return InnerHeight + Wrap.Thickness(2);
            }
        }
        public override bool OrientationAllowed(HalfAxis.HAxis axis)
        {
            return (axis == HalfAxis.HAxis.AXIS_Z_N) || (axis == HalfAxis.HAxis.AXIS_Z_P);
        }

        // Inner dimensions
        public double InnerLength => Arrangement.Length * _innerPackable.Dim(Dim0);
        public double InnerWidth => Arrangement.Width * _innerPackable.Dim(Dim1);
        public double InnerHeight => Arrangement.Height * _innerPackable.Dim(Dim2);

        // Weight
        public override double Weight => InnerWeight + Wrap.Weight;
        public double InnerWeight => Arrangement.Number * _innerPackable.Weight;
        public override OptDouble NetWeight => Arrangement.Number * _innerPackable.NetWeight;

        // Helpers
        public int Dim0 => DimIndex0(BoxOrientation);
        public int Dim1 => DimIndex1(BoxOrientation);
        public int Dim2 => 3 - Dim0 - Dim1;

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

        #region Non-Public Members

        private PackableBrick _innerPackable;
        private bool _forceOuterDimensions = false;
        private Vector3D _outerDimensions;

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
            if (null != _innerPackable)
                _innerPackable.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }

        protected override string TypeName => Properties.Resources.ID_NAMEPACK;

        #endregion

    }
}
