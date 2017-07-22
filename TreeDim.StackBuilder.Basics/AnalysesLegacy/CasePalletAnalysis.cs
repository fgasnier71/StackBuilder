using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class CasePalletAnalysis : AnalysisLegacy
    {
        public CasePalletAnalysis(
            BProperties boxProperties,
            PalletProperties palletProperties,
            InterlayerProperties interlayerProperties,
            InterlayerProperties interlayerPropertiesAntiSlip,
            PalletCornerProperties palletCorners, PalletCapProperties palletCap, PalletFilmProperties palletFilm,
            PalletConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            // sanity checks
            if (palletProperties.ParentDocument != ParentDocument
                || (interlayerProperties != null && interlayerProperties.ParentDocument != ParentDocument))
                throw new Exception("box, pallet, interlayer do not belong to the same document");
            if ((boxProperties is BoxProperties && constraintSet is BundlePalletConstraintSet)
                || (boxProperties is BundleProperties && constraintSet is CasePalletConstraintSet))
                throw new Exception("Invalid analysis: either BoxProperties with ConstraintSetBundle or BundleProperties with ConstraintSetBox");
            // has interlayer ?
            constraintSet.HasInterlayer = null != interlayerProperties;
            // setting members
            this.BProperties = boxProperties;
            this.PalletProperties = palletProperties;
            this.InterlayerProperties = interlayerProperties;
            this.InterlayerPropertiesAntiSlip = interlayerPropertiesAntiSlip;
            this.PalletCornerProperties = palletCorners;
            this.PalletCapProperties = palletCap;
            this.PalletFilmProperties = palletFilm;
            this.ConstraintSet = constraintSet;
        }

        public delegate void ModifyAnalysis(CasePalletAnalysis analysis);
        public delegate void SelectSolution(CasePalletAnalysis analysis, SelCasePalletSolution selSolution);

        public event ModifyAnalysis Modified;
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;

        public List<CasePalletSolution> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                foreach (CasePalletSolution sol in _solutions)
                    sol.Analysis = this;
            }
        }

        public BProperties BProperties
        {
            get { return _bProperties; }
            set
            {
                if (value == _bProperties)  return;
                _bProperties?.RemoveDependancy(this);
                _bProperties = value;
                _bProperties?.AddDependancy(this);
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
                _palletProperties?.AddDependancy(this);
            }
        }

        public PalletCornerProperties PalletCornerProperties
        {
            get { return _palletCornerProperties; }
            set
            {
                if (_palletCornerProperties == value) return;
                _palletCornerProperties?.RemoveDependancy(this);
                _palletCornerProperties = value;
                _palletCornerProperties?.AddDependancy(this);
            }
        }

        public PalletCapProperties PalletCapProperties
        {
            get { return _palletCapProperties; }
            set
            {
                if (_palletCapProperties == value) return;
                _palletCapProperties?.RemoveDependancy(this);
                _palletCapProperties = value;
                _palletCapProperties?.AddDependancy(this);
            }
        }

        public PalletFilmProperties PalletFilmProperties
        {
            get { return _palletFilmProperties; }
            set
            {
                if (_palletFilmProperties == value) return;
                _palletFilmProperties?.RemoveDependancy(this);
                _palletFilmProperties = value;
                _palletFilmProperties?.AddDependancy(this);            
            }
        }

        public bool HasInterlayer => _interlayerProperties != null;
        public bool HasInterlayerAntiSlip => _interlayerPropertiesAntiSlip != null;
        public bool HasPalletCorners => _palletCornerProperties != null;
        public bool HasPalletCap => _palletCapProperties != null;
        public bool HasPalletFilm => _palletFilmProperties != null;

        public InterlayerProperties InterlayerProperties
        {
            get { return _interlayerProperties; }
            set
            {
                if (_interlayerProperties == value) return;
                _interlayerProperties?.RemoveDependancy(this);
                _interlayerProperties = value;
                _interlayerProperties?.AddDependancy(this);
            }
        }

        public InterlayerProperties InterlayerPropertiesAntiSlip
        {
            get { return _interlayerPropertiesAntiSlip; }
            set
            {
                if (_interlayerPropertiesAntiSlip == value) return;
                _interlayerPropertiesAntiSlip?.RemoveDependancy(this);
                _interlayerPropertiesAntiSlip = value;
                _interlayerPropertiesAntiSlip?.AddDependancy(this);
            }
        }

        public PalletConstraintSet ConstraintSet { get; set; }

        public static ICasePalletAnalysisSolver Solver { set { _solver = value; } }

        public bool IsBundleAnalysis => _bProperties is BundleProperties;
        public bool IsBoxAnalysis => _bProperties is BoxProperties;


        public void SelectSolutionBySol(CasePalletSolution sol)
        {
            if (HasSolutionSelected(sol)) return;
            // instantiate new SelSolution
            var selSolution = new SelCasePalletSolution(ParentDocument, this, sol);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            SolutionSelected?.Invoke(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();        
        }
        public void UnSelectSolutionBySol(CasePalletSolution sol)
        {
            UnSelectSolution(GetSelSolutionBySolution(sol));
        }
        public SelCasePalletSolution GetSelSolutionBySolution(CasePalletSolution sol)
        {
            return _selectedSolutions.Find(selSol => selSol.Solution == sol);
        }
        public bool HasSolutionSelected(CasePalletSolution sol)
        {
            return GetSelSolutionBySolution(sol) != null;
        }
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count)
                return;  // no solution with this index
            if (HasSolutionSelected(index)) return;             // solution already selected
            // instantiate new SelSolution
            var selSolution = new SelCasePalletSolution(ParentDocument, this, _solutions[index]);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            SolutionSelected?.Invoke(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution( GetSelSolutionBySolutionIndex(index) );
        }
        public void UnSelectSolution(SelCasePalletSolution selSolution)
        {
            if (selSolution == null) return; // this solution not selected
            // remove from list
            _selectedSolutions.Remove(selSolution);
            ParentDocument.RemoveItem(selSolution);
            // fire event
            SolutionSelectionRemoved?.Invoke(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public bool HasSolutionSelected(int index)
        {
            return GetSelSolutionBySolutionIndex(index) != null;
        }
        public SelCasePalletSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(selSol => selSol.Solution == _solutions[index]);
        }

        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            // clear solutions
            _solutions.Clear();
        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            if (null != Modified)
                Modified(this);
            // clear solutions
            _solutions.Clear();
            // get default analysis solver
            if (_solver != null)
                _solver.ProcessAnalysis(this);
            else
                _log.Error("_solver == null : solver was not set");
            if (_solutions.Count == 0)
                _log.Debug("Recomputed analysis has no solutions");
            // set modified / propagate modifications
            Modify();
        }

        #region Non-Public Members

        private BProperties _bProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties, _interlayerPropertiesAntiSlip;
        private PalletCornerProperties _palletCornerProperties;
        private PalletCapProperties _palletCapProperties;
        private PalletFilmProperties _palletFilmProperties;
        private List<CasePalletSolution> _solutions;
        private List<SelCasePalletSolution> _selectedSolutions = new List<SelCasePalletSolution>();
        private static ICasePalletAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(CasePalletAnalysis));

        protected override void OnDispose()
        {
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            base.OnDispose();
        }

        protected override void RemoveItselfFromDependancies()
        {
            _bProperties.RemoveDependancy(this);
            _palletProperties.RemoveDependancy(this);
            _interlayerProperties?.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }

        #endregion

    }
}
