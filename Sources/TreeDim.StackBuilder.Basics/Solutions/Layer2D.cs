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
        #region Constructor
        public LayerDesc(string patternName, bool swapped)
        {
            PatternName = patternName; Swapped = swapped;
        }
        #endregion
        #region Public properties
        public string PatternName { get; }
        public bool Swapped { get; }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is LayerDesc layerDesc)) return false;
            return PatternName == layerDesc.PatternName && Swapped == layerDesc.Swapped;
        }
        public override int GetHashCode() => PatternName.GetHashCode() ^ Swapped.GetHashCode();
        public override string ToString()=> $"{PatternName}_{(Swapped ? "1" : "0")}";
    }
    #endregion

    #region ILayer2D
    public interface ILayer2D
    {
        #region Properties
        string PatternName { get; }
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
        #region Constructor
        public LayerDescBox(string patternName, HalfAxis.HAxis axis, bool swapped)
            : base(patternName, swapped)
        {
            AxisOrtho = axis;
        }
        #endregion
        #region Public properties
        public HalfAxis.HAxis AxisOrtho { get; }
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}", PatternName, HalfAxis.ToString(AxisOrtho), Swapped ? "t" : "f");
        }
        public override bool Equals(object obj)
        {
            if (obj is LayerDescBox layerDesc)
                return PatternName == layerDesc.PatternName && Swapped == layerDesc.Swapped && AxisOrtho == layerDesc.AxisOrtho;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ AxisOrtho.GetHashCode();
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
    public class Layer2D : List<BoxPosition>, ILayer2D
    {
        #region Constructor
        public Layer2D(Vector3D dimBox, Vector2D dimContainer, string patternName, HalfAxis.HAxis axisOrtho, bool swapped)
        {
            PatternName = patternName;
            AxisOrtho = axisOrtho;
            DimBox = dimBox;
            DimContainer = dimContainer;
            Swapped = swapped;
        }
        #endregion

        #region Public properties
        public double ForcedSpace { get; set; } = 0.0;
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
            Transform3D originTranslation = Transform3D.Translation(localTransfInv.transform(VecTransf) - new Vector3D(0.5 * ForcedSpace, 0.5 * ForcedSpace, 0.0));

            var layerPos = new BoxPosition(
                originTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0) + 0.5 * ForcedSpace * vAxisLength + 0.5 * ForcedSpace * vAxisWidth)
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(LengthAxis)))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(WidthAxis)))
                );
            layerPos.Position += new Vector3D(0.5 * ForcedSpace, 0.5 * ForcedSpace, 0.0);
            // add position
            Add(layerPos.Adjusted(DimBox));
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
                if (pt.X < (0.0 - _epsilon) || pt.X > (DimContainer.X + _epsilon) || pt.Y < (0.0 - _epsilon) || pt.Y > (DimContainer.Y + _epsilon))
                    return false;
            }
            return true;
        }
        #endregion

        #region ILayer2D implementation
        public string PatternName { get; private set; } = string.Empty;
        public bool Swapped { get; } = false;
        public string SwappedString => Swapped ? "t" : "f";
        public string Name => $"{PatternName}_{HalfAxis.ToString(AxisOrtho)}_{SwappedString}";
        public int NoLayers(double height) => (int)Math.Floor(height / LayerHeight);
        public int CountInHeight(double height) => NoLayers(height) * Count;
        public double LayerHeight => BoxHeight;
        public double Length => DimContainer.X;
        public double Width => DimContainer.Y;
        public string Tooltip(double height)
            => $"{Count} * {NoLayers(height)} = {CountInHeight(height)}\n {HalfAxis.ToString(AxisOrtho)} | {PatternName} | {SwappedString}";
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
                _log.Info(string.Format("{0} : Negative space value? ({1})", patternName, space));
                return;
            }
            else if (double.IsNaN(space))
            {
                _log.Info(string.Format("{0} : Invalid space value! (NaN (NotANumber))", patternName));
                return;
            }
            else if (double.IsInfinity(space))
            {
                _log.Info(string.Format("{0} : Invalid space value! (Infinity)", patternName));
                return;
            }
            else
                _maximumSpace = Math.Max(space, _maximumSpace);
        }
        #endregion

        #region Public properties
        public HalfAxis.HAxis AxisOrtho { get; } = HalfAxis.HAxis.AXIS_Z_P;

        public HalfAxis.HAxis LengthAxis
        {
            get
            {
                switch (AxisOrtho)
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
                switch (AxisOrtho)
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
        public HalfAxis.HAxis VerticalAxisProp => VerticalAxis(AxisOrtho);
        public int VerticalDirection => HalfAxis.Direction(VerticalAxisProp);
        public double BoxLength
        {
            get
            {
                switch (AxisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return DimBox.Z + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_X_P: return DimBox.Z + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_N: return DimBox.X + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_P: return DimBox.Y + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_N: return DimBox.Y + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_P: return DimBox.X + ForcedSpace;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public double BoxWidth
        {
            get
            {
                switch (AxisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return DimBox.Y + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_X_P: return DimBox.X + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_N: return DimBox.Z + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Y_P: return DimBox.Z + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_N: return DimBox.X + ForcedSpace;
                    case HalfAxis.HAxis.AXIS_Z_P: return DimBox.Y + ForcedSpace;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public double BoxHeight
        {
            get
            {
                switch (AxisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return DimBox.X;
                    case HalfAxis.HAxis.AXIS_X_P: return DimBox.Y;
                    case HalfAxis.HAxis.AXIS_Y_N: return DimBox.Y;
                    case HalfAxis.HAxis.AXIS_Y_P: return DimBox.X;
                    case HalfAxis.HAxis.AXIS_Z_N: return DimBox.Z;
                    case HalfAxis.HAxis.AXIS_Z_P: return DimBox.Z;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public Vector3D VecTransf
        {
            get
            {
                switch (AxisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: return new Vector3D(DimBox.Z, 0.0, 0.0);
                    case HalfAxis.HAxis.AXIS_X_P: return new Vector3D(0.0, 0.0, 0.0); ;
                    case HalfAxis.HAxis.AXIS_Y_N: return new Vector3D(0.0, DimBox.Z, 0.0);
                    case HalfAxis.HAxis.AXIS_Y_P: return Vector3D.Zero;
                    case HalfAxis.HAxis.AXIS_Z_N: return new Vector3D(0.0, 0.0, DimBox.Z);
                    case HalfAxis.HAxis.AXIS_Z_P: return Vector3D.Zero;
                    default: throw new Exception("Invalid ortho axis");
                }
            }
        }
        public int BoxCount => Count;
        public LayerDesc LayerDescriptor => new LayerDescBox(PatternName, AxisOrtho, Swapped);
        #endregion

        #region Generate Layer2DEdited
        public Layer2DEditable GenerateLayer2DEdited()
        {
            var layer = new Layer2DEditable(DimBox, DimContainer, $"{Name}_edit", AxisOrtho);
            foreach (var lp in this)
                layer.Add(new BoxPosition(lp));
            return layer;
        }
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

        #region Data members
        private double _maximumSpace = 0.0;
        public Vector2D DimContainer { get; private set; }
        public Vector3D DimBox { get; private set; }

        private static readonly double _epsilon = 1.0e-03;

        protected static ILog _log = LogManager.GetLogger(typeof(Layer2D));
        #endregion
    }
    #endregion

    #region Comparer for Layer2D (LayerComparerCount)
    public class LayerComparerCount : IComparer<ILayer2D>
    {
        #region Data members
        private readonly double _offsetZ = 0;
        private ConstraintSetAbstract ConstraintSet { get; set; }
        #endregion

        #region Constructor
        public LayerComparerCount(ConstraintSetAbstract constraintSet, double offsetZ)
        {
            _offsetZ = offsetZ;
            ConstraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public bool AllowMultipleLayers
        {
            get
            {
                if (ConstraintSet is ConstraintSetPalletTruck constraintSetPalletTruck)
                    return constraintSetPalletTruck.AllowMultipleLayers;
                else
                    return true;
            }
        }
        public double Height { get { return ConstraintSet.OptMaxHeight.Value - _offsetZ; } }
        #endregion

        #region Implement IComparer
        public int Compare(ILayer2D layer0, ILayer2D layer1)
        {
            int layer0Count = AllowMultipleLayers ? layer0.CountInHeight(Height) : layer0.Count;
            int layer1Count = AllowMultipleLayers ? layer1.CountInHeight(Height) : layer1.Count;

            if (layer0Count < layer1Count) return 1;
            else if (layer0Count == layer1Count)
            {
                if ((layer0 is Layer2D layerBox0) && (layer1 is Layer2D layerBox1))
                {
                    if (layerBox0.AxisOrtho < layerBox1.AxisOrtho)
                        return 1;
                    else if (layerBox0.AxisOrtho == layerBox1.AxisOrtho)
                        return 0;
                    else return -1;
                }
                else
                    return 0;
            }
            else return -1;
        }
        #endregion
    }
    #endregion
}
