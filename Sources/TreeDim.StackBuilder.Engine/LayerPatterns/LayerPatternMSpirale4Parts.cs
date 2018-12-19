using System;
using System.Diagnostics;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternMSpirale4Parts : LayerPatternBox
    {
        public override string Name => "MSpirale 4 parts";
        public override bool CanBeSwapped => true;
        public override bool CanBeInverted => true;
        public override bool IsSymetric => true;
        public override int GetNumberOfVariants(Layer2D layer) => 1;

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            double spiraleLength = GetBoxLength(layer) + GetBoxWidth(layer);
            int noSpiralesInLength = (int)Math.Floor(palletLength / spiraleLength);
            int noSpiralesInWidth = (int)Math.Floor(palletWidth / spiraleLength);

            actualLength = 0.0;
            actualWidth = 0.0;

            Debug.Assert(actualLength <= palletLength);
            Debug.Assert(actualWidth <= palletWidth);
        }
        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            actualLength = 0.0;
            actualWidth = 0.0;
            return true;
        }

        #region Non-public members
        #endregion
    }
}
