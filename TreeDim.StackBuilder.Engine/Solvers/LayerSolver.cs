#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public abstract class ConstraintSetAbstract
    {
        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
    }

    public class LayerSolver
    {
        #region Static data members

        #endregion
        public List<Layer2D> BuildLayers(Vector3D dimBox, Vector2D dimContainer, ConstraintSetAbstract constraintSet)
        {
            LayerPattern[] patterns = {
                new LayerPatternColumn()
                , new LayerPatternInterlocked()
                , new LayerPatternInterlockedSymetric()
                , new LayerPatternInterlockedFilled()
                , new LayerPatternDiagonale()
                , new LayerPatternSpirale()
                , new LayerPatternEnlargedSpirale()
            };

            List<Layer2D> listLayers = new List<Layer2D>();
            foreach (LayerPattern pattern in patterns)
            {
                foreach (HalfAxis.HAxis axisOrtho in HalfAxis.All)
                {
                    // is orientation allowed
                    if (!constraintSet.AllowOrientation(axisOrtho)) continue;
                    // instantiate layer
                    Layer2D layer = new Layer2D(dimBox, dimContainer, axisOrtho);
                    double actualLength = 0.0, actualWidth = 0.0;
                    bool bResult1 = pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth);
                    pattern.GenerateLayer(layer, actualLength, actualWidth);

                    
                    listLayers.Add(layer);
                }
            }
            listLayers.Sort();



            return listLayers;
        }
    }
}
