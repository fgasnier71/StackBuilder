using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    public class CylinderSolver : ICylinderAnalysisSolver
    {
        public CylinderSolver() { }

        public void ProcessAnalysis(CylinderPalletAnalysis analysis)
        {
            _cylProperties = analysis.CylinderProperties;
            _palletProperties = analysis.PalletProperties;
            _interlayerProperties = analysis.InterlayerProperties;
            _interlayerPropertiesAntiSlip = analysis.InterlayerPropertiesAntiSlip;
            _constraintSet = analysis.ConstraintSet;
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }

        #region Non-Public Members
        private CylinderProperties _cylProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties, _interlayerPropertiesAntiSlip;
        private CylinderPalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CylinderSolver));

        private List<CylinderPalletSolution> GenerateSolutions()
        {
            var solutions = new List<CylinderPalletSolution>();

            // loop through all patterns
            foreach (LayerPatternCyl pattern in EnumeratePatterns())
            {
                for (int iDir = 0; iDir < (pattern.CanBeSwapped ? 2 : 1); ++iDir)
                {
                    // alternate pallet direction
                    Layer2DCyl layer = new Layer2DCyl(
                        _cylProperties.RadiusOuter, _cylProperties.Height
                        , new Vector2D(_palletProperties.Length, _palletProperties.Width)
                        , /*_constraintSet*/iDir % 2 != 0);

                    string title = string.Format("{0}-{1}", pattern.Name, iDir);
                    var sol = new CylinderPalletSolution(null, title, true);

                    try
                    {
                        double actualLength = 0.0, actualWidth = 0.0;
                        pattern.GetLayerDimensions(layer, out actualLength, out actualWidth);
                        pattern.GenerateLayer(layer, actualLength, actualWidth);
                    }
                    catch (NotImplementedException ex)
                    {
                        _log.Debug(ex.Message);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.Message);
                        continue;
                    }

                    // stop
                    double zLayer = _palletProperties.Height;
                    bool maxWeightReached = _constraintSet.UseMaximumPalletWeight && (_palletProperties.Weight + _cylProperties.Weight > _constraintSet.MaximumPalletWeight);
                    bool maxHeightReached = _constraintSet.UseMaximumPalletHeight && (zLayer + _cylProperties.Height > _constraintSet.MaximumPalletHeight);
                    bool maxNumberReached = false;

                    int iCount = 0;

                    // insert anti-slip interlayer
                    if (_constraintSet.HasInterlayerAntiSlip)
                    {
                        sol.CreateNewInterlayer(zLayer, 1);
                        zLayer += _interlayerPropertiesAntiSlip.Thickness;
                    }

                    while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
                    {
                        // interlayer
                        if (_constraintSet.HasInterlayer && (sol.Count > 0))
                        {
                            sol.CreateNewInterlayer(zLayer, 0);
                            zLayer += _interlayerProperties.Thickness;
                        }
                        // select current layer type
                        Layer3DCyl cylLayer = sol.CreateNewLayer(zLayer);
                        foreach (Vector2D layerPos in layer)
                        {
                            ++iCount;
                            maxWeightReached = _constraintSet.UseMaximumPalletWeight && ((iCount * _cylProperties.Weight + _palletProperties.Weight) > _constraintSet.MaximumPalletWeight);
                            maxNumberReached = _constraintSet.UseMaximumNumberOfItems && (iCount > _constraintSet.MaximumNumberOfItems);
                            if (!maxWeightReached && !maxNumberReached)
                                cylLayer.Add(
                                    new Vector3D(
                                        layerPos.X - 0.5 * _constraintSet.OverhangX,
                                        layerPos.Y - 0.5 * _constraintSet.OverhangY,
                                        zLayer));
                        }
                        // increment zLayer
                        zLayer += _cylProperties.Height;

                        maxHeightReached = _constraintSet.UseMaximumPalletHeight && (zLayer + _cylProperties.Height > _constraintSet.MaximumPalletHeight);
                    }
                    // limit reached
                    if (maxWeightReached) sol.LimitReached = Limit.LIMIT_MAXWEIGHTREACHED;
                    else if (maxNumberReached) sol.LimitReached = Limit.LIMIT_MAXNUMBERREACHED;
                    else if (maxHeightReached) sol.LimitReached = Limit.LIMIT_MAXHEIGHTREACHED;
                    else sol.LimitReached = Limit.LIMIT_UNKNOWN;

                    solutions.Add(sol);
                }
            }
            // sort solutions
            solutions.Sort();
            return solutions;
        }

        private static IEnumerable<LayerPatternCyl> EnumeratePatterns()
        {
            // TODO - make these singletons?
            yield return new CylinderLayerPatternAligned();
            yield return new CylinderLayerPatternStaggered();
            yield return new CylinderLayerPatternMixed12();
        }
        #endregion
    }
}
