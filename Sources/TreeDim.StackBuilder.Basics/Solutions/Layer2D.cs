#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region LayerDesc
    public abstract class LayerDesc
    {
        #region Data members
        private string _patternName;
        private bool _swapped;
        #endregion
        #region Constructor
        public LayerDesc(string patternName, bool swapped)
        {
            _patternName = patternName; _swapped = swapped;
        }
        #endregion
        #region Public properties
        public string PatternName
        { get { return _patternName; } }
        public bool Swapped
        { get { return _swapped; } }
        #endregion

        public override bool Equals(object obj)
        {
            LayerDesc layerDesc = obj as LayerDesc;
            if (null == layerDesc) return false;
            return _patternName == layerDesc.PatternName && _swapped == layerDesc.Swapped;
        }
        public override int GetHashCode()
        {
            return _patternName.GetHashCode() ^ _swapped.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}_{1}", _patternName, _swapped?"1":"0");
        }
    }
    #endregion

    #region ILayer2D
    public interface ILayer2D
    {
        #region Properties
        string PatternName { get; set; }
        string Name { get; }
        bool Swapped { get; }
        double LayerHeight { get; }
        int Count { get; }
        double Length { get; }
        double Width { get; }
        LayerDesc LayerDescriptor { get; }
        double MaximumSpace { get; }
         #endregion

        #region Methods
        void Clear();
        int CountInHeight(double height);
        int NoLayers(double height);
        string Tooltip(double height);
        void UpdateMaxSpace(double space, string patternName);
        #endregion
    }
    #endregion

    #region LayerDescBox
    public class LayerDescBox : LayerDesc
    {
        #region Data members
        private HalfAxis.HAxis _axis;
        #endregion
        #region Constructor
        public LayerDescBox(string patternName, HalfAxis.HAxis axis, bool swapped)
            : base(patternName, swapped)
        {
            _axis = axis;
        }
        #endregion
        #region Public properties
        public HalfAxis.HAxis AxisOrtho
        { get { return _axis; } }
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}", PatternName, HalfAxis.ToString(_axis), Swapped ? "t" : "f");
        }
        public override bool Equals(object obj)
        {
            LayerDescBox layerDesc = obj as LayerDescBox;
            return PatternName == layerDesc.PatternName && Swapped == layerDesc.Swapped && AxisOrtho == layerDesc.AxisOrtho;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _axis.GetHashCode();
        }
        #endregion
        #region Static methods
        public static LayerDesc Parse(string value)
        {
            Regex r = new Regex(@"(?<name>.*)\|(?<axis>.*)\|(?<swap>.*)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                string patternName = m.Result("${name}");
                HalfAxis.HAxis axis = HalfAxis.Parse( m.Result("${axis}"));
                bool swapped = string.Equals("t", m.Result("${swap}"), StringComparison.CurrentCultureIgnoreCase);
                return new LayerDescBox(patternName, axis, swapped);
            }
            else
                throw new Exception("Failed to parse LayerDesc");
        }
        #endregion
    }
    #endregion

    #region Layer2D
    public class Layer2D : List<LayerPosition>, ILayer2D
    {
        #region Data members
        private string _patternName = string.Empty;
        /// <summary>
        /// Refers to box default orientation
        /// with ZP Length/Width refered in LayerPattern will be the same as in original
        /// </summary>
        private HalfAxis.HAxis _axisOrtho = HalfAxis.HAxis.AXIS_Z_P;
        /// <summary>
        /// When swapped: pallet length/width are swapped in LayerPattern 
        /// for some LayerPattern, this allows computing 2 different layouts
        /// </summary>
        private bool _swapped = false;

        private double _forcedSpace = 0.0;
        private double _maximumSpace = 0.0;

        private Vector2D _dimContainer;
        private Vector3D _dimBox;

        private static readonly double _epsilon = 1.0e-03;

        protected static ILog _log = LogManager.GetLogger(typeof(Layer2D));
        #endregion

        #region Static methods
        public static HalfAxis.HAxis VerticalAxis(HalfAxis.HAxis axisOrtho)
        {
            switch (axisOrtho)
            {
                case HalfAxis.HAxis.AXIS_X_N: return HalfAxis.HAxis.AXIS_X_N;
                case HalfAxis.HAxis.AXIS_X_P: return HalfAxis.HAxis.AXIS_Y_P;
                case HalfAxis.HAxis.AXIS_Y_N: return HalfAxis.HAxis.AXIS_Y_N;
                case HalfAxis.HAxis.AXIS_Y_P: return HalfAxis.HAxis.AXIS_X_P;
                case HalfAxis.HAxis.AXIS_Z_N: return HalfAxis.HAxis.AXIS_Z_N;
                case HalfAxis.HAxis.AXIS_Z_P: return HalfAxis.HAxis.AXIS_Z_P;
                default: throw new Exception("Invalid ortho axis");
            }        
        }
        #endregion

        #region Constructor
        public Layer2D(Vector3D dimBox, Vector2D dimContainer, string patternName, HalfAxis.HAxis axisOrtho, bool swapped)
        {
            _patternName = patternName;
            _axisOrtho = axisOrtho;
            _dimBox = dimBox;
            _dimContainer = dimContainer;
            _swapped = swapped;
        }
        #endregion

        #region Public properties
        public double ForcedSpace
        {
            get { return _forcedSpace; }
            set { _forcedSpace = value; }
        }
        #endregion

        #region Public methods
        public void AddPosition(Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            // build 4D matrix
            Vector3D vAxisLength = HalfAxis.ToVector3D(lengthAxis);
            Vector3D vAxisWidth = HalfAxis.ToVector3D(widthAxis);
            Vector3D vAxisHeight = Vector3D.CrossProduct(vAxisLength, vAxisWidth);
            Matrix4D mat = Matrix4D.Identity;
            mat.M11 = vAxisLength.X;
            mat.M12 = vAxisLength.Y;
            mat.M13 = vAxisLength.Z;
            mat.M21 = vAxisWidth.X;
            mat.M22 = vAxisWidth.Y;
            mat.M23 = vAxisWidth.Z;
            mat.M31 = vAxisHeight.X;
            mat.M32 = vAxisHeight.Y;
            mat.M33 = vAxisHeight.Z;
            mat.M41 = 0.0;
            mat.M42 = 0.0;
            mat.M43 = 0.0;
            mat.M44 = 1.0;
            Transform3D localTransf = new Transform3D(mat);
            Transform3D localTransfInv = localTransf.Inverse();
            Transform3D originTranslation = Transform3D.Translation(localTransfInv.transform(VecTransf) - new Vector3D(0.5*_forcedSpace, 0.5*_forcedSpace, 0.0));

            LayerPosition layerPos = new LayerPosition(
                originTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0) + 0.5*_forcedSpace*vAxisLength + 0.5*_forcedSpace*vAxisWidth) 
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(LengthAxis)))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(WidthAxis)))
                );
            layerPos.Position += new Vector3D(0.5 * _forcedSpace, 0.5 * _forcedSpace, 0.0);
            // add position
            Add(layerPos.Adjusted(_dimBox));
        }
        public bool IsValidPosition(Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            // check layerPos
            // get 4 points
            Vector3D[] pts = new Vector3D[4];
            pts[0] = new Vector3D(vPosition.X, vPosition.Y, 0.0);
            pts[1] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(lengthAxis) * BoxLength;
            pts[2] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(widthAxis) * BoxWidth;
            pts[3] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(lengthAxis) * BoxLength + HalfAxis.ToVector3D(widthAxis) * BoxWidth;

            foreach (Vector3D pt in pts)
            {
                if (pt.X < (0.0 - _epsilon) || pt.X > (_dimContainer.X + _epsilon) || pt.Y < (0.0 - _epsilon) || pt.Y > (_dimContainer.Y + _epsilon))
                    return false;
            }
            return true;
        }
        #endregion

        #region ILayer2D implementation
        public string PatternName
        {
            get { return _patternName; }
            set { _patternName = value; }
        }
        public bool Swapped
        {
            get { return _swapped; }
        }
        public string Name
        {
            get { return string.Format("{0}_{1}_{2}", PatternName, HalfAxis.ToString(_axisOrtho), _swapped ? "t" : "f"); }
        }
        public int NoLayers(double height)
        {
            return (int)Math.Floor(height / LayerHeight); 
        }
        public int CountInHeight(double height)
        {
            return NoLayers(height) * Count;
        }
        public double LayerHeight => BoxHeight;
        public double Length => _dimContainer.X;
        public double Width  => _dimContainer.Y;
        public string Tooltip(double height)
        {
            return string.Format("{0} * {1} = {2}\n {3} | {4} | {5}"
                    , Count
                    , NoLayers(height)
                    , CountInHeight(height)
                    , HalfAxis.ToString(AxisOrtho)
                    , PatternName
                    , _swapped ? "t" : "f");
        }
        #endregion

        #region Maximum space
        public double MaximumSpace
        {
            get
            {
                System.Diagnostics.Debug.Assert(!double.IsNaN(_maximumSpace) && !double.IsInfinity(_maximumSpace));
                return _maximumSpace; 
            }
            set { _maximumSpace = value; }
        }
        public void UpdateMaxSpace(double space, string patternName)
        {
            if (space < 0.0 - _epsilon)
            {
                _log.Info( string.Format("{0} : Negative space value? ({1})", patternName, space) );
                return;
            }
            else if (double.IsNaN(space))
            {
                _log.Info( string.Format("{0} : Invalid space value! (NaN (NotANumber))", patternName) );
                return;
            }
            else if (double.IsInfinity(space))
            { 
                _log.Info( string.Format("{0} : Invalid space value! (Infinity)", patternName) );
                return;
            }
            else
                _maximumSpace = Math.Max(space, _maximumSpace);
        }
        #endregion

        #region Public properties
        public HalfAxis.HAxis AxisOrtho
        {
            get { return _axisOrtho; }
        }
        public HalfAxis.HAxis LengthAxis
        {
            get
            {
                switch (_axisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return HalfAxis.HAxis.AXIS_Z_P;
                    case HalfAxis.HAxis.AXIS_X_P: return HalfAxis.HAxis.AXIS_Y_P;
                    case HalfAxis.HAxis.AXIS_Y_N: return HalfAxis.HAxis.AXIS_X_P;
                    case HalfAxis.HAxis.AXIS_Y_P: return HalfAxis.HAxis.AXIS_Z_P;
                    case HalfAxis.HAxis.AXIS_Z_N: return HalfAxis.HAxis.AXIS_Y_P;
                    case HalfAxis.HAxis.AXIS_Z_P: return HalfAxis.HAxis.AXIS_X_P;
                    default: throw new Exception("Invalid ortho axis");
                }
            }    
        }
        public HalfAxis.HAxis WidthAxis
        {
            get
            {
                switch (_axisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return HalfAxis.HAxis.AXIS_Y_P;
                    case HalfAxis.HAxis.AXIS_X_P: return HalfAxis.HAxis.AXIS_Z_P;
                    case HalfAxis.HAxis.AXIS_Y_N: return HalfAxis.HAxis.AXIS_Z_P;
                    case HalfAxis.HAxis.AXIS_Y_P: return HalfAxis.HAxis.AXIS_X_P;
                    case HalfAxis.HAxis.AXIS_Z_N: return HalfAxis.HAxis.AXIS_X_P;
                    case HalfAxis.HAxis.AXIS_Z_P: return HalfAxis.HAxis.AXIS_Y_P;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public HalfAxis.HAxis VerticalAxisProp
        {
            get { return VerticalAxis(_axisOrtho); }
        }

        public double BoxLength
        {
            get
            {
                switch (_axisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return _dimBox.Z + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_X_P: return _dimBox.Z + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_N: return _dimBox.X + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_P: return _dimBox.Y + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_N: return _dimBox.Y + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_P: return _dimBox.X + _forcedSpace;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public double BoxWidth
        {
            get
            {
                switch (_axisOrtho)
                { 
                    case HalfAxis.HAxis.AXIS_X_N: return _dimBox.Y + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_X_P: return _dimBox.X + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_N: return _dimBox.Z + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_P: return _dimBox.Z + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_N: return _dimBox.X + _forcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_P: return _dimBox.Y + _forcedSpace;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public double BoxHeight
        {
            get
            {
                switch (_axisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return _dimBox.X;
                    case HalfAxis.HAxis.AXIS_X_P: return _dimBox.Y;
                    case HalfAxis.HAxis.AXIS_Y_N: return _dimBox.Y;
                    case HalfAxis.HAxis.AXIS_Y_P: return _dimBox.X;
                    case HalfAxis.HAxis.AXIS_Z_N: return _dimBox.Z;
                    case HalfAxis.HAxis.AXIS_Z_P: return _dimBox.Z;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public Vector3D VecTransf
        {
            get
            {
                switch (_axisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return new Vector3D(_dimBox.Z, 0.0, 0.0);
                    case HalfAxis.HAxis.AXIS_X_P: return new Vector3D(0.0, 0.0, 0.0); ;
                    case HalfAxis.HAxis.AXIS_Y_N: return new Vector3D(0.0, _dimBox.Z, 0.0);
                    case HalfAxis.HAxis.AXIS_Y_P: return Vector3D.Zero;
                    case HalfAxis.HAxis.AXIS_Z_N: return new Vector3D(0.0, 0.0, _dimBox.Z);
                    case HalfAxis.HAxis.AXIS_Z_P: return Vector3D.Zero;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public int BoxCount
        {
            get { return Count; }
        }
        public LayerDesc LayerDescriptor
        {
            get
            {
                return new LayerDescBox(_patternName, _axisOrtho, _swapped);
            }
        }
        #endregion
    }
    #endregion

    #region Comparer for Layer2D (LayerComparerCount)
    public class LayerComparerCount : IComparer<Layer2D>
    {
        #region Data members
        private double _offsetZ = 0;
        private ConstraintSetAbstract _constraintSet;
        #endregion

        #region Constructor
        public LayerComparerCount(ConstraintSetAbstract constraintSet, double offsetZ)
        {
            _offsetZ = offsetZ;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public bool AllowMultipleLayers
        {
            get
            {
                if (_constraintSet is ConstraintSetPalletTruck constraintSetPalletTruck)
                    return constraintSetPalletTruck.AllowMultipleLayers;
                else
                    return true;
            }
        }
        public double Height { get { return _constraintSet.OptMaxHeight.Value - _offsetZ; } }
        #endregion

        #region Implement IComparer
        public int Compare(Layer2D layer0, Layer2D layer1)
        {
            int layer0Count = AllowMultipleLayers ? layer0.CountInHeight(Height) : layer0.Count;
            int layer1Count = AllowMultipleLayers ? layer1.CountInHeight(Height) : layer1.Count;

            if (layer0Count < layer1Count) return 1;
            else if (layer0Count == layer1Count)
            {
                if (layer0.AxisOrtho < layer1.AxisOrtho)
                    return 1;
                else if (layer0.AxisOrtho == layer1.AxisOrtho)
                {
                    return 0;
                }
                else return -1;
            }
            else return -1;
        }
        #endregion
    }
    #endregion
}
