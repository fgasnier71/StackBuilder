using System;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class LayerPatternOpposed : LayerPatternBox
    {
        public override string Name => "Opposed";
        public override int GetNumberOfVariants(Layer2D layer) => 1;
        public override bool IsSymetric => false;
        public override bool CanBeSwapped => true;
        public override bool CanBeInverted => true;
        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);
            
            GetOptimalSizeXY(boxLength, boxWidth, palletLength, palletWidth,
                out int sizeX_area1, out int sizeY_area1,
                out int sizeX_area2, out int sizeY_area2,
                out int sizeX_area3, out int sizeY_area3,
                out int sizeX_area4, out int sizeY_area4);

            actualLength = Math.Max(sizeX_area1 * boxLength + sizeX_area2 * boxWidth, sizeX_area4 * boxWidth + sizeX_area3 * boxLength);
            actualWidth = Math.Max(sizeY_area1 * boxWidth + sizeY_area4 * boxLength, sizeY_area2 * boxLength + sizeY_area3 * boxWidth);

            // is area1 intersecting area3?
            double lengthCum13 = (sizeX_area1 + sizeX_area3) * boxLength;
            double widthCum13 = (sizeY_area1 + sizeY_area3) * boxWidth;
            if ((actualLength - lengthCum13 < 0) && (actualWidth - widthCum13 < 0))
            {
                if (lengthCum13 <= palletLength) actualLength = lengthCum13;
                else if (widthCum13 <= palletWidth) actualWidth = widthCum13;
                else return false;
            }
            // is area2 intersecting area4?
            double lengthCum24 = (sizeX_area2 + sizeX_area4) * boxWidth;
            double widthCum24 = (sizeY_area2 + sizeY_area4) * boxLength;
            if ((actualLength - lengthCum24 < 0) && (actualWidth - widthCum24 < 0))
            {
                if (lengthCum24 <= palletLength) actualLength = lengthCum24;
                else if (widthCum24 <= palletWidth) actualWidth = widthCum24;
                else return false;
            }
            return  sizeX_area1 * sizeY_area1 > 0
                && sizeX_area2 * sizeY_area2 > 0
                && sizeX_area3 * sizeY_area3 > 0
                && sizeX_area4 * sizeY_area4 > 0;
        }
        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);

            GetOptimalSizeXY(boxLength, boxWidth, palletLength, palletWidth,
                out int sizeX_area1, out int sizeY_area1,
                out int sizeX_area2, out int sizeY_area2,
                out int sizeX_area3, out int sizeY_area3,
                out int sizeX_area4, out int sizeY_area4);

            Vector2D offset = GetOffset(layer, actualLength, actualWidth);
            double spaceX12 = (actualLength - sizeX_area1 * boxLength - sizeX_area2 * boxWidth) / (sizeX_area1 + sizeX_area2 - 1);
            double spaceX34 = (actualLength - sizeX_area3 * boxLength - sizeX_area4 * boxWidth) / (sizeX_area3 + sizeX_area4 - 1);
            double spaceY14 = (actualWidth - sizeY_area1 * boxWidth - sizeY_area4 * boxLength) / (sizeY_area1 + sizeY_area4 - 1);
            double spaceY23 = (actualWidth - sizeY_area2 * boxLength - sizeY_area3 * boxWidth) / (sizeY_area2 + sizeY_area3 - 1);

            // area 1
            for (int i = 0; i < sizeX_area1; ++i)
                for (int j = 0; j < sizeY_area1; ++j)
                {
                    LogPosition(new Vector2D(
                            offset.X + i * boxLength,
                            offset.Y + j * boxWidth)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                    AddPosition(
                        layer
                        , new Vector2D(
                            offset.X + i * boxLength,
                            offset.Y + j * boxWidth)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                }
            // area 2
            for (int i = 0; i < sizeX_area2; ++i)
                for (int j = 0; j < sizeY_area2; ++j)
                {
                    LogPosition(new Vector2D(
                            offset.X + actualLength - i * boxWidth,
                            offset.Y + j * boxLength)
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                    AddPosition(
                        layer
                        , new Vector2D(
                            offset.X + actualLength - i * boxWidth,
                            offset.Y + j * boxLength)
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                }
            // area 3
            for (int i = 0; i < sizeX_area3; ++i)
                for (int j = 0; j < sizeY_area3; ++j)
                {
                    LogPosition(new Vector2D(
                            actualLength + offset.X - boxLength - i * boxLength,
                            actualWidth + offset.Y - boxWidth - j * boxWidth)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                    AddPosition(
                        layer
                        , new Vector2D(
                            actualLength + offset.X - boxLength - i * boxLength,
                            actualWidth + offset.Y - boxWidth - j * boxWidth)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                }

            // area 4
            for (int i = 0; i < sizeX_area4; ++i)
                for (int j = 0; j < sizeY_area4; ++j)
                {
                    LogPosition(new Vector2D(
                            offset.X + boxWidth + i * boxWidth,
                            actualWidth + offset.Y - boxLength - j * boxLength)
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                    AddPosition(
                        layer
                        , new Vector2D(
                            offset.X + boxWidth + i * boxWidth,
                            actualWidth + offset.Y - boxLength - j * boxLength)
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                }
            layer.UpdateMaxSpace(spaceX12, Name);
            layer.UpdateMaxSpace(spaceX34, Name);
            layer.UpdateMaxSpace(spaceY14, Name);
            layer.UpdateMaxSpace(spaceY23, Name);
        }

        #region Helpers
        private void LogPosition(Vector2D vPos, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth)
        {
            if (_logPosition)
                _log.Info($"({vPos.X}, {vPos.Y}), {axisLength.ToString()}, {axisWidth.ToString()}");
        }
        private void GetOptimalSizeXY(
            double boxLength, double boxWidth
            , double palletLength, double palletWidth
            , out int sizeX_area1, out int sizeY_area1
            , out int sizeX_area2, out int sizeY_area2
            , out int sizeX_area3, out int sizeY_area3
            , out int sizeX_area4, out int sizeY_area4)
        {
            /*
            ------------------------------
            |              |             |
            |   area 4     |   area 3    |
            |              |             |
            ------------------------------
            |              |             |
            |   area 1     |   area 2    |
            |              |             |
            ------------------------------
            */
            sizeX_area1 = 0;
            sizeX_area2 = 0;
            sizeX_area3 = 0;
            sizeX_area4 = 0;
            sizeY_area1 = 0;
            sizeY_area2 = 0;
            sizeY_area3 = 0;
            sizeY_area4 = 0;
            int iCountMax = 0;
            int i1max = Convert.ToInt32(Math.Floor((palletLength - boxWidth) / boxLength));
            int j1max = Convert.ToInt32(Math.Floor((palletWidth - boxLength) / boxWidth));

            for (int i1 = 1; i1 <= i1max; ++i1)
                for (int j1 = 1; j1 <= j1max; ++j1)
                {
                    int i2 = Convert.ToInt32(Math.Floor((palletLength - i1 * boxLength) / boxWidth));
                    int j2max = Convert.ToInt32(Math.Floor((palletWidth - boxWidth) / boxLength));
                    for (int j2 = 1; j2 <= j2max; ++j2)
                    {
                        int i3max = Convert.ToInt32(Math.Floor((palletLength - boxWidth) / boxLength));
                        for (int i3 = 1; i3 < i3max; ++i3)
                        {
                            double h1 = 0.0;
                            if (i3 * boxLength < palletLength - i1 * boxLength)
                                h1 = j2 * boxLength;
                            else
                                h1 = Math.Max(j1 * boxWidth, j2 * boxLength);
                            int j3 = Convert.ToInt32( Math.Floor( (palletWidth- h1) /boxWidth ) );

                            int i4 = Convert.ToInt32(Math.Floor((palletLength - i3 * boxLength) / boxWidth));

                            double h2 = 0.0;
                            if (i4 * boxWidth < palletLength - i2 * boxWidth)
                                h2 = j1 * boxWidth;
                            else
                                h2 = Math.Max(j1 * boxWidth, j2 * boxLength);
                            int j4 = Convert.ToInt32(Math.Floor((palletWidth - h2) / boxLength));

                            int total = i1 * j1 + i2 * j2 + i3 * j3 + i4 * j4;
                            if ( total > iCountMax)
                            {
                                iCountMax = total;
                                sizeX_area1 = i1;
                                sizeX_area2 = i2;
                                sizeX_area3 = i3;
                                sizeX_area4 = i4;
                                sizeY_area1 = j1;
                                sizeY_area2 = j2;
                                sizeY_area3 = j3;
                                sizeY_area4 = j4;
                            }
                        }
                    }
                }
        }
        #endregion

        #region Data members
        private readonly bool _logPosition = false;
        #endregion
    }
}
