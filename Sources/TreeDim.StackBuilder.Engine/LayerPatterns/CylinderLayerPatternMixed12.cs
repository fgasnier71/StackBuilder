using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class CylinderLayerPatternMixed12 : LayerPatternCyl
    {
        public override string Name => "Mixed12";
        public override bool CanBeSwapped => true;

        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.Length;
            double palletWidth = layer.Width;

            Layer2DCylImp layerCyl = layer as Layer2DCylImp;
            double radius = layerCyl.Radius;

            int alignedRowLength = 0, stagRowLength = 0;
            int rowNumber1 = 0, rowNumber2 = 0;

            ComputeRowNumberAndLength(layerCyl
                , out alignedRowLength, out rowNumber1
                , out stagRowLength, out rowNumber2
                , out actualLength, out actualWidth);

            return rowNumber1 > 0 && rowNumber2 > 0;
        }

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = GetRadius(layer);
            double diameter = 2.0 * radius;

            int alignedRowLength = 0, stagRowLength = 0;
            int rowNumber1 = 0, rowNumber2 = 0;
            Layer2DCylImp layerCyl = layer as Layer2DCylImp;
            ComputeRowNumberAndLength(layerCyl
                , out alignedRowLength, out rowNumber1
                , out stagRowLength, out rowNumber2
                , out actualLength, out actualWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            for (int j = 0; j < rowNumber1; ++j)
                for (int i = 0; i < alignedRowLength; ++i)
                    AddPosition(layerCyl, new Vector2D(
                        radius + offsetX + i * diameter
                        , radius + offsetY + j * diameter
                        ));

            for (int i = 0; i < rowNumber2; ++i)
            {
                double y = radius + offsetY + (rowNumber1 - 1.0) * diameter + (i+1) * radius * Math.Sqrt(3.0);
                for (int j = 0; j < (i % 2 == 0 ? stagRowLength : alignedRowLength); ++j)
                    AddPosition(layer, new Vector2D(offsetX + ((i % 2 != 0) ? 0.0 : radius) + j * 2.0 * radius + radius, y));
            }
        }

        #region Non-Public Members
        private bool ComputeRowNumberAndLength(Layer2DCylImp layer
            , out int alignedRowLength, out int rowNumber1
            , out int stagRowLength, out int rowNumber2
            , out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = layer.Radius;
            double diameter = 2.0 * layer.Radius;

            // initialize out parameters
            alignedRowLength = 0; rowNumber1 = 0;
            stagRowLength = 0; rowNumber2 = 0;
            actualLength = 0; actualWidth = 0;
            // sanity check
            if (diameter > palletLength || diameter > palletWidth)
                return false;
            // first row number
            alignedRowLength = (int)Math.Floor(palletLength / diameter);
            // second row
            if ((alignedRowLength + 0.5) * diameter < palletLength)
            {
                stagRowLength = alignedRowLength;
                actualLength = (stagRowLength + 0.5) * diameter;
            }
            else
            {
                stagRowLength = alignedRowLength - 1;
                actualLength = stagRowLength * diameter;
            }
            actualLength = Math.Max(actualLength, alignedRowLength * diameter);
            // numbers of rows
            int rowNumber1Max = (int)Math.Floor(palletWidth / diameter);
            // optimization
            int maxCount = 0;
            for (int i = 1; i < rowNumber1Max - 1; ++i)
            {
                int rowNumber1Temp = i;
                int rowNumber2Temp = (int)Math.Floor(((palletWidth / radius) - 2.0 * rowNumber1Temp) / Math.Sqrt(3.0));

                int count = alignedRowLength * rowNumber1Temp
                    +  (rowNumber2Temp / 2 + (rowNumber2Temp % 2 == 0 ? 0 : 1)) * stagRowLength + (rowNumber2Temp / 2) * alignedRowLength;

                if (count >= maxCount)
                {
                    rowNumber1 = rowNumber1Temp;
                    rowNumber2 = rowNumber2Temp;
                }
            }
            actualWidth = diameter + (rowNumber1 - 1) * diameter + radius * Math.Sqrt(3.0) * rowNumber2;
            return true;
        }
        #endregion
    }
}
