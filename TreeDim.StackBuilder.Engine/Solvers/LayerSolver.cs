#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    #region LayerSolver
    public class LayerSolver : ILayerSolver
    {
        #region Static data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(LayerSolver));
        #endregion

        #region Public methods
        public List<Layer2D> BuildLayers(
            Vector3D dimBox, Vector2D dimContainer,
            double offsetZ, /* e.g. pallet height */
            ConstraintSetAbstract constraintSet, bool keepOnlyBest)
        {
            // instantiate list of layers
            List<Layer2D> listLayers0 = new List<Layer2D>();

            // loop through all patterns
            foreach (LayerPatternBox pattern in LayerPatternBox.All)
            {
                // loop through all orientation
                HalfAxis.HAxis[] patternAxes = pattern.IsSymetric ? HalfAxis.Positives : HalfAxis.All;
                foreach (HalfAxis.HAxis axisOrtho in patternAxes)
                {
                    // is orientation allowed
                    if (!constraintSet.AllowOrientation(Layer2D.VerticalAxis(axisOrtho)))
                        continue;

                    // not swapped vs swapped pattern
                    for (int iSwapped = 0; iSwapped < 2; ++iSwapped)
                    {
                        // does swapping makes sense for this layer pattern ?
                        if (!pattern.CanBeSwapped && (iSwapped == 1))
                            continue;
                        // instantiate layer
                        Layer2D layer = new Layer2D(dimBox, dimContainer, axisOrtho, iSwapped == 1);
                        if (layer.NoLayers(constraintSet.OptMaxHeight.Value) < 1)
                            continue;
                        layer.PatternName = pattern.Name;
                        double actualLength = 0.0, actualWidth = 0.0;
                        if (!pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth))
                            continue;
                        pattern.GenerateLayer(layer, actualLength, actualWidth);
                        if (0 == layer.Count)
                            continue;
                        listLayers0.Add(layer);
                    }
                }
            }
            // keep only best layers
            if (keepOnlyBest)
            {
                // 1. get best count
                int bestCount = 0;
                foreach (Layer2D layer in listLayers0)
                    bestCount = Math.Max(layer.CountInHeight(constraintSet.OptMaxHeight.Value - offsetZ), bestCount);

                // 2. remove any layer that does not match the best count given its orientation
                List<Layer2D> listLayers1 = new List<Layer2D>();
                foreach (Layer2D layer in listLayers0)
                {
                    if (layer.CountInHeight(constraintSet.OptMaxHeight.Value - offsetZ) >= bestCount)
                        listLayers1.Add(layer);
                }
                // 3. copy back in original list
                listLayers0.Clear();
                listLayers0.AddRange(listLayers1);
            }
            if (constraintSet.OptMaxHeight.Activated)
                listLayers0.Sort(new LayerComparerCount(constraintSet.OptMaxHeight.Value - offsetZ));

            return listLayers0;
        }

        public Layer2D BuildLayer(Vector3D dimBox, Vector2D dimContainer, LayerDescBox layerDesc)
        {
            LayerDescBox layerDescBox = layerDesc as LayerDescBox;
            // instantiate layer
            Layer2D layer = new Layer2D(dimBox, dimContainer, layerDescBox.AxisOrtho, layerDesc.Swapped);
            // get layer pattern
            LayerPatternBox pattern = LayerPatternBox.GetByName(layerDesc.PatternName);
            // dimensions
            double actualLength = 0.0, actualWidth = 0.0;
            if (!pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth))
                return null;
            pattern.GenerateLayer(
                layer
                , actualLength
                , actualWidth);
            return layer;
        }

        public ILayer2D BuildLayer(Packable packable, Vector2D dimContainer, LayerDesc layerDesc)
        {
            ILayer2D layer = null;
            if (packable.IsBrick)
            {
                // casts
                LayerDescBox layerDescBox = layerDesc as LayerDescBox;
                // layer instantiation
                layer = new Layer2D(packable.OuterDimensions, dimContainer, layerDescBox.AxisOrtho, layerDesc.Swapped);
                // get layer pattern
                LayerPatternBox pattern = LayerPatternBox.GetByName(layerDesc.PatternName);
                // dimensions
                double actualLength = 0.0, actualWidth = 0.0;
                if (!pattern.GetLayerDimensionsChecked(layer as Layer2D, out actualLength, out actualWidth))
                    return null;
                pattern.GenerateLayer(
                    layer as Layer2D
                    , actualLength
                    , actualWidth);
                return layer;
            }
            else if (packable.IsCylinder)
            {
                // casts
                CylinderProperties cylProperties = packable as CylinderProperties;
                // layer instantiation
                layer = new Layer2DCyl(cylProperties.RadiusOuter, cylProperties.Height, dimContainer, layerDesc.Swapped);
                // get layer pattern
                LayerPatternCyl pattern = LayerPatternCyl.GetByName(layerDesc.PatternName);
                double actualLength = 0.0, actualWidth = 0.0;
                if (!pattern.GetLayerDimensions(layer as Layer2DCyl, out actualLength, out actualWidth))
                    return null;
                pattern.GenerateLayer(
                    layer as Layer2DCyl, actualLength, actualWidth);
            }
            else
                throw new EngineException(string.Format("Unexpected packable {0} (Type = {1})", packable.Name, packable.GetType().ToString()));
            return layer;
        }

        public ILayer2D BuildLayer(Packable packable, Vector2D dimContainer, LayerDesc layerDesc, Vector2D actualDimensions)
        {
            ILayer2D layer = null;
            LayerPattern pattern = null;
            if (packable.IsBrick)
            {
                LayerDescBox layerDescBox = layerDesc as LayerDescBox;
                // instantiate layer
                layer = new Layer2D(packable.OuterDimensions, dimContainer, layerDescBox.AxisOrtho, layerDesc.Swapped);
                // get layer pattern
                pattern = LayerPatternBox.GetByName(layerDesc.PatternName);
            }
            else if (packable.IsCylinder)
            {
                CylinderProperties cylProperties = packable as CylinderProperties;
                layer = new Layer2DCyl(cylProperties.RadiusOuter, cylProperties.Height, dimContainer, layerDesc.Swapped);
                // get layer pattern
                pattern = LayerPatternCyl.GetByName(layerDesc.PatternName);
            }
            else
                throw new EngineException(string.Format("Unexpected packable {0} (Type = {1})", packable.Name, packable.GetType().ToString()));

            pattern.GenerateLayer(
                layer
                , layer.Swapped ? actualDimensions.Y : actualDimensions.X
                , layer.Swapped ? actualDimensions.X : actualDimensions.Y
                );
            return layer;
        }

        public Layer2D BuildLayer(Vector3D dimBox, Vector2D dimContainer, LayerDescBox layerDesc, Vector2D actualDimensions)
        {
            // instantiate layer
            Layer2D layer = new Layer2D(dimBox, dimContainer, layerDesc.AxisOrtho, layerDesc.Swapped);
            // get layer pattern
            LayerPatternBox pattern = LayerPatternBox.GetByName(layerDesc.PatternName);
            // build layer
            pattern.GenerateLayer(
                layer
                , layer.Swapped ? actualDimensions.Y : actualDimensions.X
                , layer.Swapped ? actualDimensions.X : actualDimensions.Y);
            return layer;
        }
        /// <summary>
        /// Used to compute load dimension
        /// </summary>
        public bool GetDimensions(List<LayerDesc> layers, Packable packable, Vector2D dimContainer, out Vector2D actualDimensions)
        {
            actualDimensions = new Vector2D();
            foreach (LayerDesc layerDesc in layers)
            {
                // dimensions
                double actualLength = 0.0, actualWidth = 0.0;

                if (packable.IsBrick)
                {
                    LayerDescBox layerDescBox = layerDesc as LayerDescBox;
                    // instantiate layer
                    Layer2D layer = new Layer2D(packable.OuterDimensions, dimContainer, layerDescBox.AxisOrtho, layerDesc.Swapped);
                    // get layer pattern
                    LayerPatternBox pattern = LayerPatternBox.GetByName(layerDesc.PatternName);
                    // dimensions
                    if (!pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth))
                    {
                        _log.Error(string.Format("Failed to get layer dimension : {0}", pattern.Name));
                        break;
                    }
                }
                else if (packable.IsCylinder)
                {
                    CylinderProperties cylProp = packable as CylinderProperties;
                    // instantiate layer
                    Layer2DCyl layer = new Layer2DCyl(cylProp.RadiusOuter, cylProp.Height, dimContainer, layerDesc.Swapped);
                    // get layer pattern
                    LayerPatternCyl pattern = LayerPatternCyl.GetByName(layerDesc.PatternName);
                    // dimensions
                    if (!pattern.GetLayerDimensions(layer, out actualLength, out actualWidth))
                    {
                        _log.Error(string.Format("Failed to get layer dimension : {0}", pattern.Name));
                        break;
                    }
                }
                else
                    throw new EngineException(string.Format("Unexpected packable {0} (Type = {1})", packable.Name, packable.GetType().ToString()));

                actualDimensions.X = Math.Max(actualDimensions.X, layerDesc.Swapped ? actualWidth : actualLength);
                actualDimensions.Y = Math.Max(actualDimensions.Y, layerDesc.Swapped ? actualLength : actualWidth);
            }
            return true;
        }

        public static bool GetBestCombination(Vector3D dimBox, Vector2D dimContainer,
            ConstraintSetAbstract constraintSet, ref List<KeyValuePair<LayerDesc, int>> listLayer)
        {
            LayerDesc[] layDescs = new LayerDesc[3];
            int[] counts = new int[3] { 0, 0, 0 };
            double[] heights = new double[3] { 0.0, 0.0, 0.0 };

            // loop through all patterns
            foreach (LayerPatternBox pattern in LayerPatternBox.All)
            {
                // loop through all orientation
                HalfAxis.HAxis[] patternAxes = pattern.IsSymetric ? HalfAxis.Positives : HalfAxis.All;
                foreach (HalfAxis.HAxis axisOrtho in patternAxes)
                {
                    // is orientation allowed
                    if (!constraintSet.AllowOrientation(Layer2D.VerticalAxis(axisOrtho)))
                        continue;
                    // not swapped vs swapped pattern
                    for (int iSwapped = 0; iSwapped < 2; ++iSwapped)
                    {
                        // does swapping makes sense for this layer pattern ?
                        if (!pattern.CanBeSwapped && (iSwapped == 1))
                            continue;
                        // instantiate layer
                        Layer2D layer = new Layer2D(dimBox, dimContainer, axisOrtho, iSwapped == 1);
                        layer.PatternName = pattern.Name;
                        double actualLength = 0.0, actualWidth = 0.0;
                        if (!pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth))
                            continue;
                        pattern.GenerateLayer(layer, actualLength, actualWidth);
                        if (0 == layer.Count)
                            continue;

                        int iAxisIndex = HalfAxis.Direction(axisOrtho);
                        if (layer.Count > counts[iAxisIndex])
                        {
                            counts[iAxisIndex] = layer.Count;
                            layDescs[iAxisIndex] = layer.LayerDescriptor;
                            heights[iAxisIndex] = layer.BoxHeight;
                        }
                    }
                }
            }

            // get list of values
            int indexIMax = 0, indexJMax = 0, noIMax = 0, noJMax = 0, iCountMax = 0;
            for (int i = 0; i < 2; ++i)
            {
                int j = i + 1;
                // search best count
                double palletHeight = constraintSet.OptMaxHeight.Value;
                int noI = (int)Math.Floor(palletHeight / heights[i]);
                // search all index
                while (noI > 0)
                {
                    double remainingHeight = palletHeight - noI * heights[i];
                    int noJ = (int)Math.Floor(remainingHeight / heights[j]);
                    if (noI * counts[i] + noJ * counts[j] > iCountMax)
                    {
                        indexIMax = i;  indexJMax = j;
                        noIMax = noI;   noJMax = noJ;
                        iCountMax = noI * counts[i] + noJ * counts[j];
                    }
                    --noI;
                } // while
            }

            listLayer.Add(new KeyValuePair<LayerDesc, int>(layDescs[indexIMax], noIMax));
            listLayer.Add(new KeyValuePair<LayerDesc, int>(layDescs[indexJMax], noJMax));
            return true;
        }
        #endregion

        #region Cylinders
        public List<Layer2DCyl> BuildLayers(
            double radius, double height
            , Vector2D dimContainer
            , double offsetZ /* e.g. pallet height */
            , ConstraintSetAbstract constraintSet
            , bool keepOnlyBest)
        {
            List<Layer2DCyl> listLayers0 = new List<Layer2DCyl>();
            foreach (LayerPatternCyl pattern in LayerPatternCyl.All)
            {            
                // not swapped vs swapped pattern
                for (int iSwapped = 0; iSwapped < 2; ++iSwapped)
                {
                    // does swapping makes sense for this layer pattern ?
                    if (!pattern.CanBeSwapped && (iSwapped == 1))
                        continue;
                    // instantiate layer
                    Layer2DCyl layer = new Layer2DCyl(radius, height, dimContainer, iSwapped == 1);
                    layer.PatternName = pattern.Name;

                    double actualLength = 0.0, actualWidth = 0.0;
                    if (!pattern.GetLayerDimensions(layer, out actualLength, out actualWidth))
                        continue;
                    pattern.GenerateLayer(layer, actualLength, actualWidth);
                    listLayers0.Add(layer);
                }

                // keep only best layers
                if (keepOnlyBest)
                {
                    // 1. get best count
                    int bestCount = 0;
                    foreach (Layer2DCyl layer in listLayers0)
                        bestCount = Math.Max(layer.CountInHeight(constraintSet.OptMaxHeight.Value - offsetZ), bestCount);

                    // 2. remove any layer that does not match the best count given its orientation
                    List<Layer2DCyl> listLayers1 = new List<Layer2DCyl>();
                    foreach (Layer2DCyl layer in listLayers0)
                    {
                        if (layer.CountInHeight(constraintSet.OptMaxHeight.Value - offsetZ) >= bestCount)
                            listLayers1.Add(layer);
                    }
                    // 3. copy back in original list
                    listLayers0.Clear();
                    listLayers0.AddRange(listLayers1);
                }
                listLayers0.Sort(new LayerCylComparerCount(constraintSet.OptMaxHeight.Value - offsetZ));
            }
            return listLayers0;
        }
        #endregion

        #region Static methods
        public static List<ILayer2D> ConvertList(List<Layer2D> list)
        {
            List<ILayer2D> lres = new List<ILayer2D>();
            foreach (Layer2D l in list)
                lres.Add(l);
            return lres;
        }
        public static List<ILayer2D> ConvertList(List<Layer2DCyl> list)
        {
            List<ILayer2D> lres = new List<ILayer2D>();
            foreach (Layer2DCyl l in list)
                lres.Add(l);
            return lres;
        }
        #endregion
    }
    #endregion
}
