using System;
using System.Text;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    #region SelHCylinderPalletSolution
    public class SelHCylinderPalletSolution : ItemBaseNamed
    {
        #region Data members
        private HCylinderPalletAnalysis _analysis;
        private HCylinderPalletSolution _solution;
        private List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        #endregion

        #region Constructor
        public SelHCylinderPalletSolution(Document document, HCylinderPalletAnalysis analysis, HCylinderPalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

            _solution = sol;
            ID.Name = sol.Title;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Encapsulated solution
        /// </summary>
        public HCylinderPalletSolution Solution
        {
            get { return _solution; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public HCylinderPalletAnalysis Analysis
        {
            get { return _analysis; }
        }
        /// <summary>
        /// List of depending truck analyses
        /// </summary>
        public List<TruckAnalysis> TruckAnalyses
        {
            get { return _truckAnalyses; }
        }
        #endregion

        #region ItemBase override
        protected override void RemoveItselfFromDependancies()
        {
            if (null != _analysis)
                _analysis.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
#endregion
    #region HCylinderPalletSolution
    public class HCylinderPalletSolution : List<CylPosition>, IComparable
    {
        #region Data members
        private string _title;
        private HCylinderPalletAnalysis _parentAnalysis;
        private Limit _limitReached = Limit.LIMIT_UNKNOWN;
        private BBox3D _bbox = new BBox3D();
        #endregion

        #region Constructor
        public HCylinderPalletSolution(HCylinderPalletAnalysis parentAnalysis, string title)
        {
            _parentAnalysis = parentAnalysis;
            _title = title;
        }
        #endregion

        #region Public properties
        public string Title { get { return _title; } }
        public int CylinderCount { get { return Count; } }
        public HCylinderPalletAnalysis Analysis
        {
            get { return _parentAnalysis; }
            set { _parentAnalysis = value; }
        }
        public BBox3D BoundingBox
        {
            get
            {
                BBox3D bbox = new BBox3D();
                // --- extend
                // pallet
                bbox.Extend(Vector3D.Zero);
                bbox.Extend(new Vector3D(Analysis.PalletProperties.Length, Analysis.PalletProperties.Width, Analysis.PalletProperties.Height));
                // load
                bbox.Extend(LoadBoundingBox);
                // --- extend
                return bbox;
            }
        }
        public BBox3D LoadBoundingBox
        {
            get
            {
                if (!_bbox.IsValid)
                {
                    foreach (CylPosition pos in this)
                        _bbox.Extend(pos.BBox(_parentAnalysis.CylinderProperties.RadiusOuter, _parentAnalysis.CylinderProperties.Height));
                }
                return _bbox;
            }
        }

        #endregion

        #region Limit reached
        public Limit LimitReached
        {
            get { return _limitReached; }
            set { _limitReached = value; }
        }

        public double PalletWeight
        {
            get
            {
                return _parentAnalysis.PalletProperties.Weight + Count * _parentAnalysis.CylinderProperties.Weight;
            }
        }

        public double PalletLength { get { return BoundingBox.Length; } }
        public double PalletWidth { get { return BoundingBox.Width; } }
        public double PalletHeight { get { return BoundingBox.Height; } }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            HCylinderPalletSolution sol = (HCylinderPalletSolution)obj;
            if (this.CylinderCount > sol.CylinderCount)
                return -1;
            else if (this.CylinderCount == sol.CylinderCount)
                return 0;
            else
                return 1;
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("=== Solution ===> {0} cylinders", this.Count));
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #region HCylinderPalletAnalysis
    public class HCylinderPalletAnalysis : AnalysisLegacy
    {
        #region Data members
        private CylinderProperties _cylinderProperties;
        private PalletProperties _palletProperties;
        private HCylinderPalletConstraintSet _constraintSet;
        private List<HCylinderPalletSolution> _solutions = new List<HCylinderPalletSolution>();
        private List<SelHCylinderPalletSolution> _selectedSolutions = new List<SelHCylinderPalletSolution>();
        private static IHCylinderAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(HCylinderPalletAnalysis));
        #endregion

        #region Constructor
        public HCylinderPalletAnalysis(
            CylinderProperties cylProperties,
            PalletProperties palletProperties,
            HCylinderPalletConstraintSet constraintSet)
            : base(cylProperties.ParentDocument)
        {
            CylinderProperties = cylProperties;
            PalletProperties = palletProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Delegates
        public delegate void ModifyAnalysis(HCylinderPalletAnalysis analysis);
        public delegate void SelectSolution(HCylinderPalletAnalysis analysis, SelHCylinderPalletSolution selSolution);
        #endregion

        #region Events
        public event ModifyAnalysis Modified;
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;
        #endregion

        #region Public properties
        public CylinderProperties CylinderProperties
        {
            get { return _cylinderProperties; }
            set
            {
                if (value == _cylinderProperties) return;
                _cylinderProperties?.RemoveDependancy(this);
                _cylinderProperties = value;
                if (null != ParentDocument)
                    _cylinderProperties?.AddDependancy(this);
            }
        }
        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
            set
            {
                if (_palletProperties == value) return;
                _palletProperties?.RemoveDependancy(this);
                _palletProperties = value;
                if (null!= ParentDocument)
                    _palletProperties?.AddDependancy(this);
            }
        }
        public HCylinderPalletConstraintSet ConstraintSet
        {
            set { _constraintSet = value; }
            get { return _constraintSet; }
        }
        public List<HCylinderPalletSolution> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                foreach (HCylinderPalletSolution sol in _solutions)
                    sol.Analysis = this;
            }
        }
        public static IHCylinderAnalysisSolver Solver
        { set { _solver = value; } }
        #endregion

        #region Solution selection
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count)
                return;  // no solution with this index
            if (HasSolutionSelected(index)) return;             // solution already selected
            // instantiate new SelSolution
            SelHCylinderPalletSolution selSolution = new SelHCylinderPalletSolution(ParentDocument, this, _solutions[index]);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            if (null != SolutionSelected)
                SolutionSelected(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution(GetSelSolutionBySolutionIndex(index));
        }
        public void UnSelectSolution(SelHCylinderPalletSolution selSolution)
        {
            if (null == selSolution) return; // this solution not selected
            // remove from list
            _selectedSolutions.Remove(selSolution);
            ParentDocument.RemoveItem(selSolution);
            // fire event
            if (null != SolutionSelectionRemoved)
                SolutionSelectionRemoved(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public bool HasSolutionSelected(int index)
        {
            return (null != GetSelSolutionBySolutionIndex(index));
        }
        public SelHCylinderPalletSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(delegate (SelHCylinderPalletSolution selSol) { return selSol.Solution == _solutions[index]; });
        }
        #endregion

        #region Dependancies
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            if (null != Modified)
                Modified(this);
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            // clear solutions
            _solutions.Clear();
            // get default analysis solver
            if (null != _solver)
                _solver.ProcessAnalysis(this);
            else
                _log.Error("_solver == null : solver was not set");
            if (_solutions.Count == 0)
                _log.Debug("Recomputed analysis has no solutions");
            // set modified / propagate modifications
            Modify();
        }
        #endregion
    }
#endregion
    public interface IHCylinderAnalysisSolver
    {
        void ProcessAnalysis(HCylinderPalletAnalysis analysis);
    }

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
