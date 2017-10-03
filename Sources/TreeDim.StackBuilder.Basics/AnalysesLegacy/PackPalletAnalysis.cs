using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class PackPalletAnalysis : AnalysisLegacy
    {
        public PackPalletAnalysis(
            PackProperties packProperties,
            PalletProperties palletProperties,
            InterlayerProperties interlayerProperties,
            PackPalletConstraintSet constraintSet)
            : base(packProperties.ParentDocument)
        {
            // sanity checks
            if (palletProperties.ParentDocument != ParentDocument
                || (interlayerProperties != null && interlayerProperties.ParentDocument != ParentDocument))
                throw new Exception("box, pallet, interlayer do not belong to the same document");
            // setting members
            this.PackProperties = packProperties;
            this.PalletProperties = palletProperties;
            this.InterlayerProperties = interlayerProperties;
            this.ConstraintSet = constraintSet;
        }

        public delegate void ModifyAnalysis(PackPalletAnalysis analysis);
        public delegate void SelectSolution(PackPalletAnalysis analysis, SelPackPalletSolution selSolution);

        public event ModifyAnalysis Modified;
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;

        #region Public properties
        public List<PackPalletSolution> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                foreach (PackPalletSolution sol in _solutions)
                    sol.Analysis = this;
            }
        }

        public PackProperties PackProperties
        {
            get { return _packProperties; }
            set
            {
                if (value == _packProperties) return;
                _packProperties?.RemoveDependancy(this);
                _packProperties = value;
                _packProperties?.AddDependancy(this);
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

        public PackPalletConstraintSet ConstraintSet { get; set; }

        public bool HasInterlayer => _interlayerProperties != null;

        public static IPackPalletAnalysisSolver Solver { set { _solver = value; } }
        #endregion

        #region Solution selection

        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count)
                return; // no solution with this index
            if (HasSolutionSelected(index)) return;
            // instantiate new SelSolution
            var selSolution = new SelPackPalletSolution(ParentDocument, this, _solutions[index]);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            SolutionSelected?.Invoke(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution(GetSelSolutionBySolutionIndex(index));
        }
        public void UnSelectSolution(SelPackPalletSolution selSolution)
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
        public SelPackPalletSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(delegate(SelPackPalletSolution selSol) { return selSol.Solution == _solutions[index]; });
        }
        public SelPackPalletSolution GetSelSolutionBySolution(PackPalletSolution sol)
        {
            return _selectedSolutions.Find(selSol => selSol.Solution == sol);
        }
        public bool HasSolutionSelected(PackPalletSolution sol)
        {
            return GetSelSolutionBySolution(sol) != null;
        }
        public void SelectSolutionBySol(PackPalletSolution sol)
        {
            if (HasSolutionSelected(sol)) return;
            // instantiate new SelSolution
            var selSolution = new SelPackPalletSolution(ParentDocument, this, sol);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            SolutionSelected?.Invoke(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionBySol(PackPalletSolution sol)
        {
            UnSelectSolution(GetSelSolutionBySolution(sol));
        }
        #endregion

        #region Dependancies
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            // clear solutions
            _solutions.Clear();
            // base
            base.OnAttributeModified(modifiedAttribute);
        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            base.OnEndUpdate(updatedAttribute);
            Modified?.Invoke(this);
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
        #endregion

        #region Non-Public Members

        private PackProperties _packProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private List<PackPalletSolution> _solutions;
        private List<SelPackPalletSolution> _selectedSolutions = new List<SelPackPalletSolution>();
        private static IPackPalletAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(PackPalletAnalysis));

        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected override void RemoveItselfFromDependancies()
        {
            if (null != _packProperties)
                _packProperties.RemoveDependancy(this);
            if (null != _palletProperties)
                _palletProperties.RemoveDependancy(this);
            if (null != _interlayerProperties)
                _interlayerProperties.RemoveDependancy(this);
            // base
            base.RemoveItselfFromDependancies();
        }

        #endregion

    }
}
