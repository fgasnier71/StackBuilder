using System;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class CylinderLayerPatternStaggered2 : LayerPatternCyl
    {
        public override string Name => "Staggered";
        public override bool CanBeSwapped => true;
        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            layer.Clear();
            Layer2DCyl layerCyl = layer as Layer2DCyl;
            ComputeRowNumberAndLength(layerCyl
                , out int firstRowLength, out int secondRowLength, out int rowNumber
                , out actualLength, out actualWidth);
            return (firstRowLength > 0) && (secondRowLength > 0) && (rowNumber > 0);
        }
        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = GetRadius(layer);
        }

        #region Non-public members
        private bool ComputeRowNumberAndLength(Layer2DCyl layer
            , out int firstRowLength, out int secondRowLength, out int rowNumber
            , out double actualLength, out double actualWidth)
        {
            actualLength = 0.0;
            actualWidth = 0.0;

            firstRowLength = 0;
            secondRowLength = 0;

            rowNumber = 0;
            return false;
        }
        private bool ComputeNumber(Layer2DCyl layer
            , out int number
            , out double actualLength, out double actualWidth)
        {
            actualLength = 0.0;
            actualWidth = 0.0;

            number = 0;

            double length = GetPalletLength(layer);
            double width = GetPalletWidth(layer);
            double diameter = GetDiameter(layer);

            if (width / diameter < 2)
            {
                double Y = width - diameter;
                double X = diameter * Math.Cos(Math.Asin(Y / diameter));

                if (X <= diameter / 2.0)
                {
                    number = 0;
                }
                else
                {
                    number = 0;
                }
            }
            else
            {
                double Y = width - 2.0 * diameter;
                if (Y >= diameter / 2.0)
                {
                    double X = diameter * Math.Cos(Math.Asin(Y / diameter));
                    number = 0;
                }
                else
                {
                    Y = (width - diameter) / 3.0;
                    if (Y >= diameter / 2.0)
                    {
                        double X = diameter * Math.Cos(Math.Asin(Y / diameter));
                        number = 0;
                    }
                    else
                    {
                        number = 0;
                    }
                }
            }
            return false;
        }
        #endregion

        // X <= OD / 2 AND W / OD < 2
        // Y = W - OD
        // X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/OD))
        // NBstack = (2.rounddown((L-OD-X) / OD)) + 2 = (2.rounddown((L-OD-(OD.cos(arcsin((W-OD)/OD)))) / OD)) + 2
        // Last roll(y/n): L - (OD.NB/2) - OD.cos(30°-arcsin((W-OD)/OD) >0

        // X > OD / 2 AND W / OD < 2
        // Y = W - OD
        // X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/OD)) 
        // NBstack = rounddown(L / X) = rounddown(L / (OD.cos(arcsin((W-OD)/OD))))

        // Y >= OD / 2 AND W / OD >= 2
        // Y = (W - OD) / 3
        // X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/(3.OD))) 
        // NBstack = 2.rounddown(L / X) = 2.rounddown(L / (OD.cos(arcsin((W-OD)/(3.OD)))))

        // Y < OD / 2 AND W / OD >= 2
        // X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-2.OD)/OD)) 
        // NBstack = 2.rounddown(L / X) = 2.rounddown(L / (OD.cos(arcsin((W-2.OD)/OD)))))
        // Last roll(y/n): L - (X.NB/2) - OD.cos(30°) >0
















    }
}
