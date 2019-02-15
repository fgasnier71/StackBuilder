using System;
using System.Diagnostics;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    internal class LayerPatternBrick : LayerPatternBox
    {
        public override string Name => "Brick";
        public override int GetNumberOfVariants(Layer2D layer) => 1;
        public override bool IsSymetric => true;
        public override bool CanBeSwapped => true;
        public override bool CanBeInverted => true;

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            Vector2D offset = GetOffset(layer, actualLength, actualWidth);
            RecursiveInsertion(layer, offset, actualLength, actualWidth, boxLength, boxWidth);
        }

        public override bool GetLayerDimensions(ILayer2D layer, out double layerLength, out double layerWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            int noInLength = (int)Math.Floor(palletLength / boxLength);
            int noInWidth = (int)Math.Floor((palletWidth - 2 * boxWidth) / boxLength);

            layerLength = noInLength * boxLength;
            layerWidth = noInWidth * boxLength + 2 * boxWidth;

            Debug.Assert(layerLength <= palletLength);
            Debug.Assert(layerWidth <= palletWidth);

            return true;
        }

        protected void RecursiveInsertion(ILayer2D layer
            , Vector2D offset
            , double rectLength, double rectWidth
            , double boxLength, double boxWidth
            )
        {
            int noInLength = (int)Math.Floor(rectLength / boxLength);
            int noInWidth = (int)Math.Floor((rectWidth - 2 * boxWidth) / boxLength);

            Vector2D internalOffset = new Vector2D(
                0.5 * (rectLength - noInLength * boxLength)
                , 0.5 * (rectWidth - noInWidth * boxLength - 2.0 * boxWidth)
                );

            if (noInWidth <= 0 && 2 * boxWidth > rectWidth)
            {
                if (boxWidth > rectWidth)
                    noInLength = 0;

                internalOffset = new Vector2D(
                    0.5 * (rectLength - noInLength * boxLength)
                    , 0.5 * (rectWidth - boxWidth));
            }
            // insert boxes
            if (noInLength > 0)
            {
                for (int i = 0; i < noInLength; ++i)
                {
                    AddPosition(layer
                        , offset + internalOffset + new Vector2D(i * boxLength, 0.0)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                    if (2 * boxWidth <= rectWidth)
                        AddPosition(layer
                            , offset + internalOffset + new Vector2D(i * boxLength, noInWidth * boxLength + boxWidth)
                            , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                }
                for (int i = 0; i < noInWidth; ++i)
                {
                    AddPosition(layer
                        , offset + internalOffset + new Vector2D(boxWidth, boxWidth + i * boxLength)
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                    if (2 * boxWidth <= rectLength)
                        AddPosition(layer
                            , offset + internalOffset + new Vector2D(noInLength * boxLength, boxWidth + i * boxLength)
                            , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                }

                // new internal rectangle
                if (noInLength > 0 && noInWidth > 0)
                    RecursiveInsertion(layer
                        , offset + internalOffset + new Vector2D(boxWidth, boxWidth)
                        , noInLength * boxLength - 2 * boxWidth, noInWidth * boxLength
                        , boxLength, boxWidth);
                }
        }
    }
}
