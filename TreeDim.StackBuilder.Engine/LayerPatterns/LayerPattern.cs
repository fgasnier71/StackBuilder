using System;
using System.Collections.Generic;
using System.Text;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    abstract class LayerPattern
    { 
        public abstract string Name { get; }
        public abstract bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth);
        public abstract void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth);

        public virtual bool CanBeSwapped => false;

        public bool GetLayerDimensionsChecked(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            bool result = GetLayerDimensions(layer, out actualLength, out actualWidth);
            if (actualLength > GetPalletLength(layer))
                throw new EngineException($"Pattern name={Name} : actualLength={actualLength} > palletLength={GetPalletLength(layer)} ?");
            if (actualWidth > GetPalletWidth(layer))
                throw new EngineException($"Pattern name={Name} : actualWidth={actualWidth} > palletWidth={GetPalletWidth(layer)} ?");
            return result;
        }

        #region Non-Public Members

        protected double GetPalletLength(ILayer2D layer)
        {
            return layer.Swapped ? layer.Width : layer.Length;
        }

        protected double GetPalletWidth(ILayer2D layer)
        {
            return layer.Swapped ? layer.Length : layer.Width;
        }

        #endregion
    }
}
