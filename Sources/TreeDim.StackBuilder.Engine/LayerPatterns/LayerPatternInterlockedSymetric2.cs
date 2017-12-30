using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternInterlockedSymetric2
        : LayerPatternInterlockedSymetric
    {
        public override string Name => "Symetric Interlocked 2";

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = maxSizeXLength + maxSizeXWidth > 1 ? (actualLength - (maxSizeXLength * boxLength + maxSizeXWidth * boxWidth)) / (maxSizeXLength + maxSizeXWidth - 1) : 0.0;
            double spaceYLength = maxSizeYLength > 1 ? (actualWidth - maxSizeYLength * boxWidth) / (maxSizeYLength - 1) : 0.0;
            double spaceYWidth = maxSizeYWidth > 1 ? actualWidth - maxSizeYWidth * boxLength : 0.0;

            for (int i = 0; i < maxSizeXLength / 2; ++i)
                for (int j = 0; j < maxSizeYLength; ++j)
                {
                    AddPosition(
                        layer
                        , new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceYLength))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                    AddPosition(
                        layer
                        , new Vector2D(
                            palletLength - offsetX - i * (boxLength + spaceX)
                            , palletWidth - offsetY - j * (boxWidth + spaceYLength))
                        , HalfAxis.HAxis.AXIS_X_N, HalfAxis.HAxis.AXIS_Y_N);
                }
            for (int i = 0; i < maxSizeXWidth; ++i)
                for (int j = 0; j < maxSizeYWidth; ++j)
                    AddPosition(
                        layer
                        , new Vector2D(
                            offsetX + maxSizeXLength / 2 * (boxLength + spaceX) + i * (boxWidth + spaceX) + boxWidth
                            , offsetY + j * (boxLength + spaceYWidth))
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);

            layer.UpdateMaxSpace(spaceX, Name);
            layer.UpdateMaxSpace(spaceYLength, Name);
            layer.UpdateMaxSpace(spaceYWidth, Name);
        }

    }
}
