#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternColumn : LayerPatternBox
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Column"; }
        }

        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            actualLength = Math.Floor(palletLength / boxLength) * boxLength;
            actualWidth = Math.Floor(palletWidth / boxWidth) * boxWidth;
            return (palletLength >= boxLength) && (palletWidth >= boxWidth);
        }

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            int sizeX = (int)Math.Floor(palletLength / boxLength);
            int sizeY = (int)Math.Floor(palletWidth / boxWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = sizeX > 1 ? (actualLength - sizeX * boxLength) / (sizeX - 1) : 0.0;
            double spaceY = sizeY > 1 ? (actualWidth - sizeY * boxWidth) / (sizeY - 1) : 0.0;

            for (int i = 0; i < sizeX; ++i)
                for (int j = 0; j < sizeY; ++j)
                    AddPosition(layer
                        , new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceY)
                            )
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
            // set spacing to ZERO i.e. no spacing with column layout
            layer.UpdateMaxSpace(spaceX, Name);
            layer.UpdateMaxSpace(spaceY, Name);
        }

        public override int GetNumberOfVariants(Layer2D layer)
        {
            return 1;
        }
        public override bool IsSymetric { get { return false; } }
        public override bool CanBeSwapped { get { return false; } }
        public override bool CanBeInverted { get { return false; } }
        #endregion
    }
}
