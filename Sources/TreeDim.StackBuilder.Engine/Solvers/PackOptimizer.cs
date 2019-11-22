#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;

using log4net;

using Sharp3D.Math.Core;
using PrimeFactorisation;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class PackOptimizer : ISolver
    {
        public PackOptimizer(
            PackableBrick packable
            , PalletProperties palletProperties
            , ConstraintSetAbstract constraintSet
            , ParamSetPackOptim paramSetPackOptim
            , Color packColor
            )
        {
            BoxProperties = packable;
            PalletProperties = palletProperties;
            ConstraintSet = constraintSet;
            ParamSetPackOpt = paramSetPackOptim;
            _packColor = packColor;
        }
        public Layer2DBrickImp BuildBestLayer()
        {
            throw new NotImplementedException();
        }
        public List<AnalysisLayered> BuildAnalyses(bool allowMultipleLayerOrientations)
        {
            List<AnalysisLayered> analyses = PackOptimSolutions(
                ConstraintSet as ConstraintSetCasePallet,
                ParamSetPackOpt.NoBoxes);
            return analyses;
        }

        #region Non-Public Members
        private Color _packColor;
        private ParamSetPackOptim ParamSetPackOpt { get; set; }
        private  PalletProperties PalletProperties { set; get; }
        private PackableBrick BoxProperties { set; get; }
        private ConstraintSetAbstract ConstraintSet { get; set; }

        protected static readonly ILog _log = LogManager.GetLogger(typeof(PackOptimizer));

        /// <summary>
        /// Build a list of all case definitions given a number of box
        /// </summary>
        /// <param name="iNumber">Number of items to fit in box</param>
        /// <returns></returns>
        private List<CaseDefinition> CaseDefinitions(int iNumber)
        {
            // TODO: better as IEnumerable<>?
            var caseDefinitionList = new List<CaseDefinition>();
            foreach (PackArrangement arr in BoxArrangements(iNumber))
            {
                for (int i=0; i<3; ++i)
                    for (int j=0; j<3; ++j)
                    {
                        if (j == i)
                            continue;
                        
                        var caseDefinition = new CaseDefinition(arr, i, j);
                        if (caseDefinition.IsValid(BoxProperties, ParamSetPackOpt))
                            caseDefinitionList.Add(caseDefinition);
                    }
            }
            return caseDefinitionList;
        }

        private List<AnalysisLayered> PackOptimSolutions(ConstraintSetCasePallet constraintSet, int iNumber)
        {
            // TODO: better as IEnumerable<>?
            var analyses = new List<AnalysisLayered>();
            foreach (CaseDefinition caseDefinition in CaseDefinitions(iNumber))
            {
                try
                {
                    // build pack properties
                    Vector3D outerDimensions = caseDefinition.OuterDimensions(BoxProperties, ParamSetPackOpt);
                    var packProperties = new PackProperties(
                        null, BoxProperties,
                        caseDefinition.Arrangement, PackProperties.Orientation(caseDefinition.Dim0, caseDefinition.Dim1),
                        BuildWrapper());
                    packProperties.ForceOuterDimensions(outerDimensions);

                    // solver
                    var solver = new SolverCasePallet(packProperties, PalletProperties, constraintSet);
                    analyses.AddRange(solver.BuildAnalyses(false));
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message);
                }
            }
            // sort caseOptimSolution
            analyses.Sort(new AnalysisComparer());
            return analyses;
        }

        private PackWrapper BuildWrapper()
        {
            int[] noWalls = ParamSetPackOpt.NoWalls;
            double length = 0.0, width = 0.0, height = 0.0;
            double weight = ParamSetPackOpt.WallSurfaceMass * (noWalls[0] * width * height + noWalls[1] * length * height + noWalls[2] * length * width);

            switch (ParamSetPackOpt.WrapperType)
            { 
                case PackWrapper.WType.WT_POLYETHILENE:
                    return new WrapperPolyethilene(
                        ParamSetPackOpt.WallThickness, weight, _packColor, true);
                case PackWrapper.WType.WT_PAPER:
                    return new WrapperPaper(
                        ParamSetPackOpt.WallThickness, weight, _packColor);
                case PackWrapper.WType.WT_CARDBOARD:
                    {
                        var wrapperCardboard = new WrapperCardboard(
                            ParamSetPackOpt.WallThickness, weight, _packColor);
                        wrapperCardboard.SetNoWalls(noWalls);
                        return wrapperCardboard;
                    }
                case PackWrapper.WType.WT_TRAY:
                    {
                        var wrapperTray = new WrapperTray(
                            ParamSetPackOpt.WallThickness, weight, _packColor)
                        {
                            Height = ParamSetPackOpt.TrayHeight
                        };
                        wrapperTray.SetNoWalls(noWalls);
                        return wrapperTray;
                    }
                default:
                    throw new InvalidEnumArgumentException(nameof(ParamSetPackOpt.WrapperType), (int)ParamSetPackOpt.WrapperType, typeof(PackWrapper.WType));
            }
        }

        private IEnumerable<PackArrangement> BoxArrangements(int iNumber)
        {
            // get the prime factorisation of iNumber
            var primeList = new List<int>(Eratosthenes.GetPrimeFactors(iNumber));
            primeList.Sort();
            // build list of prime multiple
            var primeMultiples = new List<PrimeMultiple>();
            int i = 0, j = 0;
            while (j < primeList.Count)
            {
                while (j < primeList.Count && primeList[j] == primeList[i])
                    ++j;
                primeMultiples.Add(new PrimeMultiple(primeList[i], j - i));
                i = j;
            }

            var listArrangements = new List<PackArrangement>();
            // Decomp
            int[] multiples1 = new int[primeMultiples.Count];
            Decomp1(primeMultiples, 0, ref multiples1, ref listArrangements);
            return listArrangements;
        }

        private void Decomp1(List<PrimeMultiple> primeMultiples, int iStep, ref int[] multiples1, ref List<PackArrangement> listArrangements)
        {
            if (iStep == primeMultiples.Count)
            {
                int[] multiples2 = new int[primeMultiples.Count];
                Decomp2(primeMultiples, 0, multiples1, ref multiples2, ref listArrangements);
            }
            else
            {
                for (int i = 0; i <= primeMultiples[iStep]._iMultiple; ++i)
                {
                    multiples1[iStep] = i;
                    Decomp1(primeMultiples, iStep+1, ref multiples1, ref listArrangements);
                }
            }
        }

        private void Decomp2(List<PrimeMultiple> primeMultiples, int iStep, int[] multiples1, ref int[] multiples2, ref List<PackArrangement> listArrangements)
        {
            if (iStep == primeMultiples.Count)
            {
                int iLength = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iLength *= (int)Math.Pow(primeMultiples[i]._iPrime, multiples1[i]);
                int iWidth = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iWidth *= (int)Math.Pow(primeMultiples[i]._iPrime, multiples2[i]);
                int iHeight = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iHeight *= (int)Math.Pow(primeMultiples[i]._iPrime, primeMultiples[i]._iMultiple - multiples1[i] - multiples2[i]);
                // add new arrangement
                listArrangements.Add(new PackArrangement(iLength, iWidth, iHeight));
            }
            else
            {
                for (int i=0; i <= (primeMultiples[iStep]._iMultiple-multiples1[iStep]); ++i)
                {
                    multiples2[iStep] = i;
                    Decomp2(primeMultiples, iStep+1, multiples1, ref multiples2, ref listArrangements);
                }
            }
        }
        #endregion
    }
}
