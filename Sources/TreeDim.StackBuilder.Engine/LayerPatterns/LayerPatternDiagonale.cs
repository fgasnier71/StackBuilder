using System;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternDiagonale : LayerPatternBox
    {
        public override string Name => "Diagonale";
        public override int GetNumberOfVariants(Layer2DBrickDef layer) => 1;
        public override bool IsSymetric => true;
        public override bool CanBeSwapped => true;
        public override bool CanBeInverted => true;

        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out int iStep, out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth);

            actualLength = maxSizeXLength * boxLength + maxSizeXWidth * boxWidth;
            if (maxSizeYWidth >= iStep && (iStep * boxLength <= palletLength))
                actualLength = Math.Max(actualLength, iStep * boxLength);
            actualWidth = maxSizeYWidth * boxWidth + maxSizeYLength * boxLength;
            if (maxSizeXLength >= iStep && (iStep * boxWidth <= palletWidth))
                actualWidth = Math.Max(actualWidth, iStep * boxWidth);

            return maxSizeXLength > 0 && maxSizeXWidth > 0 && maxSizeYLength > 0 && maxSizeYWidth > 0;
        }
        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out int iStep, out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            for (int i = 0; i < iStep; ++i)
            {
                double spaceX = maxSizeXLength + maxSizeXWidth > 1
                    ? (actualLength - maxSizeXLength * boxLength - maxSizeXWidth * boxWidth) / (maxSizeXLength + maxSizeXWidth - 1)
                    : 0.0;
                double spaceY = maxSizeYLength + maxSizeYWidth > 1
                    ? (actualWidth - maxSizeYWidth * boxWidth - maxSizeYLength * boxLength) / (maxSizeYLength + maxSizeYWidth - 1)
                    : 0.0;

                double xBase = offsetX + i * (boxLength + spaceX);
                double yBase = offsetY + i * (boxWidth + spaceY);
                // first box
                AddPosition(
                    layer
                    , new Vector2D(xBase + boxWidth, yBase)
                    , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);

                // along X
                for (int ix = 0; ix < iStep - 1 - i; ++ix)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase + boxWidth + spaceX + ix * (boxLength + spaceX)
                        , yBase)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                int maxY = (int)Math.Floor(actualWidth / boxWidth);
                double ySpaceNew = maxY > 1 ? (actualWidth - boxWidth * maxY) / (maxY - 1) : 0;
                for (int ix = iStep - 1 - i; ix < maxSizeXLength - i && i < iStep - 1; ++ix)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase + boxWidth + spaceX + ix * (boxLength + spaceX)
                        , offsetY + i * (boxWidth + ySpaceNew))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                // along Y
                for (int iy = 0; iy < iStep - 1 - i; ++iy)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase
                        , yBase + boxLength + spaceY + iy * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                int maxX = (int)Math.Floor(actualLength / boxLength);
                double xSpaceNew = maxX > 1 ? (actualLength - boxLength * maxX) / (maxX - 1) : 0;
                for (int iy = iStep - 1 - i; iy < maxSizeYWidth - i && i < iStep - 1; ++iy)
                {
                    AddPosition(
                        layer
                        , new Vector2D(
                        offsetX + i * (boxLength + xSpaceNew)
                        , yBase + boxLength + spaceY + iy * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                }
                // set spacing
                layer.UpdateMaxSpace( spaceX, Name );
                layer.UpdateMaxSpace( spaceY, Name );
                layer.UpdateMaxSpace( Math.Abs(boxLength - boxWidth), Name );
            }
        }

        #region Non-Public Members
        private void GetSizeXY(double boxLength, double boxWidth, double palletLength, double palletWidth,
            out int iStep, out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth)
        {
            iStep = Math.Min(
                (int)Math.Floor((palletLength - boxWidth) / boxLength)
                , (int)Math.Floor((palletWidth - boxLength) / boxWidth)
                ) + 1;

            maxSizeXWidth = boxWidth < palletLength ? 1 : 0;
            maxSizeXLength = (int)Math.Floor((palletLength - boxWidth) / boxLength);

            maxSizeYLength = boxLength < palletWidth ? 1 : 0;
            maxSizeYWidth = (int)Math.Floor((palletWidth - boxLength) / boxWidth);
        }
        #endregion
    }
}
