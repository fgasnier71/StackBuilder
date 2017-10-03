using System;
using System.Collections.Generic;
using System.Text;

using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class BoxCaseAnalysis : AnalysisLegacy
    {
        public BoxCaseAnalysis(BProperties bProperties, BoxProperties caseProperties, BCaseConstraintSet constraintSet)
            : base(bProperties.ParentDocument)
        {
            if (!constraintSet.IsValid)
                throw new Exception("Using invalid box/case constraintset -> Can not instantiate box/case analysis!");
            this.BProperties = bProperties;
            this.CaseProperties = caseProperties;
            _constraintSet = constraintSet;
        }

        public delegate void ModifyAnalysis(BoxCaseAnalysis analysis);
        public delegate void SelectSolution(BoxCaseAnalysis analysis, SelBoxCaseSolution selSolution);

        public event ModifyAnalysis Modified;
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;

        public bool IsBundleAnalysis => _bProperties is BundleProperties;
        public bool IsBoxAnalysis => _bProperties is BoxProperties;
        public BProperties BProperties
        {
            get { return _bProperties; }
            set
            {
                if (value == _bProperties) return;
                _bProperties?.RemoveDependancy(this);
                _bProperties = value;
                _bProperties?.AddDependancy(this);
            }
        }
        public BoxProperties CaseProperties
        {
            get { return _caseProperties; }
            set
            {
                if (value == _caseProperties) return;
                _caseProperties?.RemoveDependancy(this);
                _caseProperties = value;
                _caseProperties?.AddDependancy(this);
            }
        }
        public BCaseConstraintSet ConstraintSet => _constraintSet;

        public List<BoxCaseSolution> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                foreach (BoxCaseSolution sol in _solutions)
                    sol.Analysis = this;
            }
        }
        public static IBoxCaseAnalysisSolver Solver { set { _solver = value; } }

        #region Solution selection
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count)
                return;  // no solution with this index
            if (HasSolutionSelected(index)) return;             // solution already selected
            // instantiate new SelSolution
            var selSolution = new SelBoxCaseSolution(ParentDocument, this, _solutions[index]);
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
        public void UnSelectSolution(SelBoxCaseSolution selSolution)
        {
            if (null == selSolution) return; // this solution not selected
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
        public SelBoxCaseSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(selSol => selSol.Solution == _solutions[index]);
        }
        #endregion

        #region Depandancies
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
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

        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            Modified?.Invoke(this);
            // get default analysis solver
            if (_solver != null)
            {
                // clear solutions
                _solutions.Clear();
                _solver.ProcessAnalysis(this);
            }
            else
                _log.Error("_solver == null : solver was not set");

            if (_solutions.Count == 0)
                _log.Debug("Recomputed analysis has no solutions");
            // set modified / propagate modifications
            Modify();
        }
        #endregion

        #region Non-Public Members

        BProperties _bProperties;
        BoxProperties _caseProperties;
        BCaseConstraintSet _constraintSet;
        List<BoxCaseSolution> _solutions;
        private List<SelBoxCaseSolution> _selectedSolutions = new List<SelBoxCaseSolution>();
        private static IBoxCaseAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisBoxCase));

        protected override void OnDispose()
        {
            base.OnDispose();
        }
        protected override void RemoveItselfFromDependancies()
        {
            if (null != _bProperties)
                _bProperties.RemoveDependancy(this);
            if (null != _caseProperties)
                _caseProperties.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }

        #endregion
    }
}
