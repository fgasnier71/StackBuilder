using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            actualLength = 0.0;
            actualWidth = 0.0;

            return (palletLength >= boxLength + boxWidth) && (palletWidth >= boxLength + boxWidth); 
        }
        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
        }

        #region Helpers
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
                        int j3 = Convert.ToInt32(Math.Floor((palletWidth - j2 * boxLength) / boxWidth));
                        int i3max = Convert.ToInt32(Math.Floor((palletLength - boxWidth) / boxLength));
                        for (int i3 = 1; i3 < i3max; ++i3)
                        {
                            int i4 = Convert.ToInt32(Math.Floor((palletLength - i3 * boxLength) / boxWidth));
                            int j4 = Convert.ToInt32(Math.Floor((palletWidth - j1 * boxWidth) / boxLength));
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
    }
}
