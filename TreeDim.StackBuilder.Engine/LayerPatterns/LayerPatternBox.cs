#region Using directives
using System;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
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
        public static LayerPatternBox[] All => _allPatterns;

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
}