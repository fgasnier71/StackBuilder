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
    #region LayerDescCyl
    public class LayerDescCyl : LayerDesc
    {
        #region Constructor
        public LayerDescCyl(string patternName, bool swapped)
            : base(patternName, swapped)
        {
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            return string.Format("{0} | {1}", PatternName, Swapped ? "t" : "f");
        }
        public static LayerDescCyl Parse(string value)
        {
            Regex r = new Regex(@"(?<name>.*)\|(?<swap>.*)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                string patternName = m.Result("${name}");
                bool swapped = string.Equals("t", m.Result("${swap}"), StringComparison.CurrentCultureIgnoreCase);
                return new LayerDescCyl(patternName, swapped);
            }
            else
                throw new Exception("Failed to parse LayerDesc");
        }
        #endregion
    }
    #endregion

    #region Layer2DCyl
    public class Layer2DCyl : List<Vector2D>, ILayer2D
    {
        #region Data members
        private string _patternName = string.Empty;
        private bool _swapped = false;
        private Vector2D _dimContainer;
        private double _radius, _height;

        protected static ILog _log = LogManager.GetLogger(typeof(Layer2D));
        #endregion

        #region Constructor
        public Layer2DCyl(double radius, double height, Vector2D dimContainer, bool swapped)
        {
            _radius = radius; _height = height;
            _dimContainer = dimContainer;
            _swapped = swapped;
        }
        #endregion

        #region Public methods
        public bool IsValidPosition(Vector2D vPosition)
        {
            return (vPosition.X - _radius >= 0) && (vPosition.X + _radius <= _dimContainer.X)
                && (vPosition.Y - _radius >= 0) && (vPosition.Y + _radius <= _dimContainer.Y);
        }
        public int CountInHeight(double height)
        {
            return NoLayers(height) * Count;
        }
        public int PerPalletCount(double zHeight)
        {
            return NoLayers(zHeight) * Count;
        }
        public int NoLayers(double height)
        {
            return (int)Math.Floor(height / LayerHeight); 
        }
        public double CylinderRadius
        {
            get { return _radius; }
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
            get { return string.Format("{0}_{1}", PatternName, Swapped ? "t" : "f"); }
        }
        public double LayerHeight
        {
            get { return _height; }
        }
        public double MaximumSpace { get { return 0.0; } }
        public double Length { get { return _dimContainer.X; } }
        public double Width  { get { return _dimContainer.Y; } }
        public string Tooltip(double height)
        {
            return string.Format("{0} * {1} = {2}\n {3}"
                    , Count
                    , NoLayers(height)
                    , CountInHeight(height)
                    , Name);
        }
        public void UpdateMaxSpace(double space, string patternName)
        { 
        }
        #endregion

        #region Public properties
        public LayerDesc LayerDescriptor
        {
            get { return new LayerDescCyl(_patternName, _swapped); }
        }
        #endregion
    }
    #endregion

    #region Comparers
    public class LayerCylComparerCount : IComparer<Layer2DCyl>
    {
        #region Data members
        private double _height = 0;
        #endregion

        #region Constructor
        public LayerCylComparerCount(double height)
        {
            _height = height;
        }
        #endregion

        #region Implement IComparer
        public int Compare(Layer2DCyl layer0, Layer2DCyl layer1)
        {
            int layer0Count = layer0.CountInHeight(_height);
            int layer1Count = layer1.CountInHeight(_height);

            if (layer0Count < layer1Count)
                return 1;
            else if (layer0Count == layer1Count)
                return 0;
            else
                return -1;            
        }
        #endregion
    }
    #endregion
}
