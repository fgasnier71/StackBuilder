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

        }

        public override bool GetLayerDimensions(ILayer2D layer, out double layerLength, out double layerWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double boxLength = GetBoxLength(layer);
            double boxWidth = GetBoxWidth(layer);


            layerLength = 0.0;
            layerWidth = 0.0;

            Debug.Assert(layerLength <= palletLength);
            Debug.Assert(layerWidth <= palletWidth);

            return true;
        }

        protected void RecursiveInsertion(ILayer layer
            , double rectLength, double rectWidth
            , double boxLength, double boxWidth
            )
        {
        }
    }
}
