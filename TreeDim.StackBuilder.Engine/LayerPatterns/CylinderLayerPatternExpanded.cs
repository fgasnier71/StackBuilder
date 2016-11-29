#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    class CylinderLayerPatternExpanded : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Expanded"; }
        }
        public override bool CanBeSwapped
        {
            get { return true; }
        }
        public override bool GetLayerDimensions(Layer2DCyl layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.Length;
            double palletWidth = layer.Width;
            double radius = layer.CylinderRadius;
            actualLength = 0.0;
            actualWidth = 0.0;

            return false;
        }

        public override void GenerateLayer(Layer2DCyl layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            throw new NotImplementedException();
        }
        #endregion

    }
}
