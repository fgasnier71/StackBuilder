#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using treeDiM.StackBuilder.Basics;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    /// <summary>
    /// Layer pattern abstract class
    /// </summary>
    internal abstract class LayerPattern
    { 
        abstract public string Name { get; }
        abstract public bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth);
        abstract public void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth);

        public virtual bool CanBeSwapped { get { return false; } }

        protected double GetPalletLength(ILayer2D layer)
        {
            if (!layer.Swapped)
                return layer.Length;
            else
                return layer.Width;
        }

        protected double GetPalletWidth(ILayer2D layer)
        { 
            if (!layer.Swapped)
                return layer.Width;
            else
                return layer.Length;        
        }

        public bool GetLayerDimensionsChecked(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            bool result = GetLayerDimensions(layer, out actualLength, out actualWidth);
            if (actualLength > GetPalletLength(layer))
                throw new EngineException(string.Format("Pattern name={0} : actualLength={1} > palletLength={2} ?"
                    , this.Name, actualLength, GetPalletLength(layer)));
            if (actualWidth > GetPalletWidth(layer))
                throw new EngineException(string.Format("Pattern name={0} : actualWidth={1} > palletWidth={2} ?"
                    , this.Name, actualWidth, GetPalletWidth(layer)));
            return result;
        }
    }
    /*
    internal abstract class LayerPatternBox : LayerPattern
    {
        #region Abstract methods
        abstract public int GetNumberOfVariants(Layer2D layer);
        abstract public bool CanBeInverted { get; }
        abstract public bool IsSymetric { get; }
        #endregion
 
        #region Private methods
        #endregion

        #region Public properties
        public double GetBoxLength(ILayer2D layer)
        {
            return (layer as Layer2D).BoxLength;
        }
        public double GetBoxWidth(ILayer2D layer)
        {
            return (layer as Layer2D).BoxWidth;
        }
        public void AddPosition(ILayer2D layer, Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (layer.Swapped)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(layer.Length, 0.0, 0.0);
            }
            Transform3D transfRot = new Transform3D(matRot);
            HalfAxis.HAxis lengthAxisSwapped = StackBuilder.Basics.HalfAxis.ToHalfAxis(transfRot.transform(StackBuilder.Basics.HalfAxis.ToVector3D(lengthAxis)));
            HalfAxis.HAxis widthAxisSwapped = StackBuilder.Basics.HalfAxis.ToHalfAxis(transfRot.transform(StackBuilder.Basics.HalfAxis.ToVector3D(widthAxis)));

            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];

            Transform3D transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

            Layer2D layerBox = layer as Layer2D;
            if (!layerBox.IsValidPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y), lengthAxisSwapped, widthAxisSwapped))
            {
                _log.Warn(string.Format("Attempt to add an invalid position in pattern = {0}, Swapped = {1}", this.Name, layer.Swapped));
                return;
            }
            layerBox.AddPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y), lengthAxisSwapped, widthAxisSwapped);
        }
        #endregion

        #region Static methods
        public static LayerPatternBox[] All
        { get { return _allPatterns; } }

        public static LayerPatternBox GetByName(string patternName)
        {
            foreach (LayerPatternBox pattern in LayerPatternBox.All)
            {
                if (string.Equals(pattern.Name, patternName, StringComparison.CurrentCultureIgnoreCase))
                    return pattern;
            }
            // no pattern found!
            throw new Exception(string.Format("Invalid pattern name = {0}", patternName));
        }

        public static int GetPatternNameIndex(string patternName)
        {
            int index = 0;
            foreach (LayerPatternBox pattern in LayerPatternBox.All)
            { 
                if (string.Equals(pattern.Name, patternName, StringComparison.CurrentCultureIgnoreCase))
                    return index;
                ++index;
            }
            // no pattern found!
            throw new Exception(string.Format("Invalid pattern name = {0}", patternName));
        }
        #endregion

        #region Data members
        private static LayerPatternBox[] _allPatterns = {
            new LayerPatternColumn()
            , new LayerPatternInterlocked()
            , new LayerPatternInterlockedSymetric()
            , new LayerPatternInterlockedFilled()
            , new LayerPatternTrilock()
            , new LayerPatternDiagonale()
            , new LayerPatternSpirale()
            , new LayerPatternEnlargedSpirale()
        };
        protected static readonly ILog _log = LogManager.GetLogger(typeof(LayerPatternBox));
        #endregion
    }
    */
}
