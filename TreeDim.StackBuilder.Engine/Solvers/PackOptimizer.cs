#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using log4net;

using Sharp3D.Math.Core;
using PrimeFactorisation;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    #region Internal class PrimeMultiple
    internal class PrimeMultiple
    {
        #region Constructor
        public PrimeMultiple(int iPrime, int iMultiple)
        {
            _iPrime = iPrime; _iMultiple = iMultiple;
        }
        #endregion

        #region System.Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1})", _iPrime, _iMultiple);
            return sb.ToString(); ;
        }
        #endregion

        #region Data members
        public int _iPrime, _iMultiple;
        #endregion
    }
    #endregion

    #region PackOptimizer
    public class PackOptimizer : ISolver
    {
        #region Static data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(PackOptimizer));
        #endregion

        #region Constructor
        public PackOptimizer(
            PackableBrick packable
            , PalletProperties palletProperties
            , ParamSetPackOptim paramSetPackOptim
            , Color packColor
            )
        {
            _packable                   = packable;
            _palletProperties           = palletProperties;
            _paramSetPackOptim          = paramSetPackOptim;
            _packColor = packColor;
        }
        #endregion

        #region ISolver implementation
        public List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet)
        {
            List<Analysis> analyses = PackOptimSolutions(
                constraintSet as ConstraintSetCasePallet,
                _paramSetPackOptim.NoBoxes);
            return analyses;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Build a list of all case definitions given a number of box
        /// </summary>
        /// <param name="iNumber">Number of items to fit in box</param>
        /// <returns></returns>
        private List<CaseDefinition> CaseDefinitions(int iNumber)
        {
            List<CaseDefinition> caseDefinitionList = new List<CaseDefinition>();
            foreach (PackArrangement arr in BoxArrangements(iNumber))
            {
                for (int i=0; i<3; ++i)
                    for (int j=0; j<3; ++j)
                    {
                        if (j == i)
                            continue;
                        
                        CaseDefinition caseDefinition = new CaseDefinition(arr, i, j);
                        if (caseDefinition.IsValid(_packable, _paramSetPackOptim))
                            caseDefinitionList.Add(caseDefinition);
                    }
            }
            return caseDefinitionList;
        }

        private List<Analysis> PackOptimSolutions(ConstraintSetCasePallet constraintSet, int iNumber)
        {
            List<Analysis> analyses = new List<Analysis>();
            foreach (CaseDefinition caseDefinition in CaseDefinitions(iNumber))
            {
                try
                {
                    // build pack properties
                    Vector3D outerDimensions = caseDefinition.OuterDimensions(_packable, _paramSetPackOptim);
                    PackProperties packProperties = new PackProperties(
                        null, _packable,
                        caseDefinition.Arrangement, PackProperties.Orientation(caseDefinition.Dim0, caseDefinition.Dim1),
                        BuildWrapper());
                    packProperties.ForceOuterDimensions(outerDimensions);

                    // solver
                    SolverCasePallet solver = new SolverCasePallet(packProperties, _palletProperties);
                    analyses.AddRange(solver.BuildAnalyses(constraintSet));
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message);
                }
            }
            // sort caseOptimSolution
            analyses.Sort(new ComparerAnalysis());
            return analyses;
        }

        private PackWrapper BuildWrapper()
        {
            int[] noWalls = _paramSetPackOptim.NoWalls;
            double length = 0.0, width = 0.0, height = 0.0;
            double weight = _paramSetPackOptim.WallSurfaceMass * (noWalls[0] * width * height + noWalls[1] * length * height + noWalls[2] * length * width);

            PackWrapper wrapper = null;
            switch (_paramSetPackOptim.WrapperType)
            { 
                case PackWrapper.WType.WT_POLYETHILENE:
                    wrapper = new WrapperPolyethilene(
                        _paramSetPackOptim.WallThickness, weight, _packColor, true);
                    break;
                case PackWrapper.WType.WT_PAPER:
                    wrapper = new WrapperPaper(
                        _paramSetPackOptim.WallThickness, weight, _packColor);
                    break;
                case PackWrapper.WType.WT_CARDBOARD:
                    {
                        WrapperCardboard wrapperCardboard = new WrapperCardboard(
                            _paramSetPackOptim.WallThickness, weight, _packColor);
                        wrapperCardboard.SetNoWalls(noWalls);
                        return wrapperCardboard;
                    }
                case PackWrapper.WType.WT_TRAY:
                    {
                        WrapperTray wrapperTray = new WrapperTray(
                            _paramSetPackOptim.WallThickness, weight, _packColor);
                        wrapperTray.Height = _paramSetPackOptim.TrayHeight;
                        wrapperTray.SetNoWalls(noWalls);
                        return wrapperTray;
                    }
                default:
                    break;

            }
            return wrapper;
        }

        /// <summary>
        /// Pallet properties
        /// </summary>
        public PalletProperties PalletProperties
        {
            set { _palletProperties = value; }
            get { return _palletProperties; }
        }
        /// <summary>
        /// Product BoxProperties
        /// </summary>
        public PackableBrick BoxProperties
        {
            set { _packable = value; }
            get { return _packable; }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private IEnumerable<PackArrangement> BoxArrangements(int iNumber)
        {
            // get the prime factorisation of iNumber
            List<int> primeList = new List<int>(Eratosthenes.GetPrimeFactors(iNumber));
            primeList.Sort();
            // build list of prime multiple
            List<PrimeMultiple> primeMultiples = new List<PrimeMultiple>();
            int i = 0, j = 0;
            while (j < primeList.Count)
            {
                while (j < primeList.Count && primeList[j] == primeList[i])
                    ++j;
                primeMultiples.Add(new PrimeMultiple(primeList[i], j - i));
                i = j;
            }

            List<PackArrangement> listArrangements = new List<PackArrangement>();
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

        #region Public properties
        #endregion

        #region Data members
        /// <summary>
        /// Input product used to search solution
        /// </summary>
        private PackableBrick _packable;
        /// <summary>
        /// Input pallet properties
        /// </summary>
        private PalletProperties _palletProperties;
        /// <summary>
        /// Optimisation parameters
        /// </summary>
        private ParamSetPackOptim _paramSetPackOptim;
        /// <summary>
        /// Wrapper color
        /// </summary>
        private Color _packColor;
        #endregion
    }
    #endregion
}
