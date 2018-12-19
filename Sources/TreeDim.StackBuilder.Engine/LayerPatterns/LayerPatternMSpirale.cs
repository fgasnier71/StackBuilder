using System;
using System.Diagnostics;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternMSpirale : LayerPatternBox
    {
        public override string Name => "Multi-Spirale";
        public override int GetNumberOfVariants(Layer2D layer) => 1;
        public override bool IsSymetric => false;
        public override bool CanBeSwapped => true;
        public override bool CanBeInverted => true;

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();

        }

        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
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

            return true;
        }

        #region Non-Public members
        int GetSizeXY(double boxLength, double boxWidth, double palletLength, double palletWidth
            , out int noSpiraleX, out int noSpiraleY
            , out int noRowX, out int noRowY
            , out int noColX, out int noColY)
        {
            double spiraleLength = boxLength + boxWidth;
            noSpiraleX = (int)Math.Floor(palletLength / spiraleLength);
            noSpiraleY = (int)Math.Floor(palletWidth / spiraleLength);

            noRowX = 0; noRowY = 0;
            noColX = 0; noColY = 0;
            return noSpiraleX * noSpiraleY * 4 + noRowX + noRowY + noColX + noColY;
        }
        #endregion
    }
}
