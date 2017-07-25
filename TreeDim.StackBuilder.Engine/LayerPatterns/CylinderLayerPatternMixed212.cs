using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class CylinderLayerPatternMixed212 : LayerPatternCyl
    {
        public override string Name => "Mixed212";
        public override bool CanBeSwapped => true;

        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = GetRadius(layer);
            actualLength = 0.0;
            actualWidth = 0.0;
            return false;
        }

        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = GetRadius(layer);

            throw new NotImplementedException();
        }
    }
}
