using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    public class HCylinderSolver : IHCylinderAnalysisSolver
    {
        #region Data members
        private static List<HCylinderLoadPattern> _patterns = new List<HCylinderLoadPattern>();
        private CylinderProperties _cylProperties;
        private PalletProperties _palletProperties;
        private HCylinderPalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(HCylinderSolver));
        #endregion

        #region Constructor
        public HCylinderSolver()
        {
            HCylinderSolver.LoadPatterns();
        }
        #endregion

        #region Processing methods
        public void ProcessAnalysis(HCylinderPalletAnalysis analysis)
        {
            _cylProperties = analysis.CylinderProperties;
            _palletProperties = analysis.PalletProperties;
            _constraintSet = analysis.ConstraintSet;
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }
        private List<HCylinderPalletSolution> GenerateSolutions()
        {
            List<HCylinderPalletSolution> solutions = new List<HCylinderPalletSolution>();

            // loop through all patterns
            foreach (HCylinderLoadPattern pattern in _patterns)
            {
                if (!_constraintSet.AllowPattern(pattern.Name))
                    continue;
                // loop through directions
                for (int iDir = 0; iDir < (pattern.CanBeSwapped ? 2 : 1); ++iDir)
                {
                    string title = string.Format("{0}-{1}", pattern.Name, iDir);
                    HCylinderPalletSolution sol = new HCylinderPalletSolution(null, title);

                    double actualLength = 0.0, actualWidth = 0.0;
                    double maxHeight = _constraintSet.UseMaximumPalletHeight ? _constraintSet.MaximumPalletHeight : -1;

                    pattern.Swapped = (iDir % 2 != 0);

                    int maxCountNoItems = -1;
                    if (_constraintSet.UseMaximumNumberOfItems) maxCountNoItems = _constraintSet.MaximumNumberOfItems;
                    int maxCountWeight = -1;
                    if (_constraintSet.UseMaximumPalletWeight)
                        maxCountWeight = (int)Math.Floor((_constraintSet.MaximumPalletWeight - _palletProperties.Weight) / _cylProperties.Weight);
                    int maxCount = -1;
                    if (-1 != maxCountNoItems && -1 == maxCountWeight) maxCount = maxCountNoItems;
                    else if (-1 == maxCountNoItems && -1 != maxCountWeight) maxCount = maxCountWeight;
                    else if (-1 != maxCountNoItems && -1 != maxCountWeight) maxCount = Math.Min(maxCountWeight, maxCountNoItems);
                    try
                    {
                        CylLoad load = new CylLoad(_cylProperties, _palletProperties, _constraintSet);
                        pattern.GetDimensions(load, maxCount, out actualLength, out actualWidth);
                        pattern.Generate(load, maxCount, actualLength, actualWidth, maxHeight - _palletProperties.Height);

                        // Limit reached ?
                        sol.LimitReached = load.LimitReached;
                        // maxCount might actually max weight reached
                        if (load.LimitReached == Limit.LIMIT_MAXNUMBERREACHED && maxCount == maxCountWeight)
                            sol.LimitReached = Limit.LIMIT_MAXWEIGHTREACHED;

                        // copies all cylinder positions
                        foreach (CylPosition pos in load)
                        {
                            sol.Add(new CylPosition(
                                pos.XYZ
                                - 0.5 * _constraintSet.OverhangX * Vector3D.XAxis
                                - 0.5 * _constraintSet.OverhangY * Vector3D.YAxis,
                                pos.Direction
                                ));
                        }
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
                    // add solution
                    if (sol.Count > 0)
                        solutions.Add(sol);
                } // loop on directions
            } // loop through all patterns
            // sort solution
            solutions.Sort();
            return solutions;
        }
        #endregion

        #region Static methods
        private static void LoadPatterns()
        {
            if (0 == _patterns.Count)
            {
                _patterns.Add(new HCylinderLoadPatternColumn());
                _patterns.Add(new HCylinderLoadPatternStaggered());
                _patterns.Add(new HCylinderLoadPatternDefault());
            }
        }
        #endregion
    }
}
