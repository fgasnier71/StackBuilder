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

    public class LayerSolver
    {
        #region Static data members
        #endregion

        #region Public methods
        public List<Layer2D> BuildLayers(Vector3D dimBox, Vector2D dimContainer, ConstraintSetAbstract constraintSet, bool keepOnlyBest)
        {
            // instantiate list of layers
            List<Layer2D> listLayers0 = new List<Layer2D>();

            // loop through all patterns
            foreach (LayerPattern pattern in LayerPattern.All)
            {
                // loop through all orientation
                foreach (HalfAxis.HAxis axisOrtho in HalfAxis.All)
                {
                    // is orientation allowed
                    if ( !constraintSet.AllowOrientation(axisOrtho) )
                        continue;
                    // not swapped vs swapped pattern
                    for (int iSwapped = 0; iSwapped < 2; ++iSwapped)
                    {
                        // does swapping makes sense for this layer pattern ?
                        if (!pattern.CanBeSwapped && (iSwapped == 1))
                            continue;
                        // instantiate layer
                        Layer2D layer = new Layer2D(dimBox, dimContainer, axisOrtho, iSwapped == 1);
                        double actualLength = 0.0, actualWidth = 0.0;
                        bool bResult1 = pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth);
                        pattern.GenerateLayer(layer, actualLength, actualWidth);

                        listLayers0.Add(layer);
                    }
                }
            }

            // keep only best layers
            if (keepOnlyBest)
            {
                // 1. get best count for each layer orientation
                int[] vcounts = new int[] { 0, 0, 0, 0, 0, 0 };
                foreach (Layer2D layer in listLayers0)
                {
                    int iDir = (int)layer.AxisOrtho;
                    vcounts[iDir] = Math.Max(layer.Count, vcounts[iDir]);
                }
                for (int i = 0; i < 3; ++i)
                {
                    vcounts[i] = Math.Max(vcounts[i], vcounts[i + 1]);
                    vcounts[i + 1] = Math.Max(vcounts[i], vcounts[i + 1]);
                }
                // 2. remove any layer that does not match the best count given its orientation
                List<Layer2D> listLayers1 = new List<Layer2D>();
                foreach (Layer2D layer in listLayers0)
                {
                    if (layer.Count >= vcounts[(int)layer.AxisOrtho])
                        listLayers1.Add(layer);
                }
                listLayers0.Clear();
                listLayers0.AddRange(listLayers1);
            }
            if (constraintSet.OptMaxHeight.Activated)
                listLayers0.Sort(new LayerComparerCount(constraintSet.OptMaxHeight.Value));

            return listLayers0;
        }
        #endregion
    }
}
