using System;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    public class TruckAnalysis : AnalysisLegacy
    {
        /// <summary>
        /// Truck analysis
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="analysis">Parent pallet analysis</param>
        /// <param name="selSolution">Parent selected solution</param>
        /// <param name="truckProperties">TruckProperties item</param>
        /// <param name="constraintSet">Constraint set</param>
        public TruckAnalysis(
            Document document
            , CasePalletAnalysis analysis
            , SelCasePalletSolution selSolution
            , TruckProperties truckProperties
            , TruckConstraintSet constraintSet)
            : base(document)
        {
            ID.Name = truckProperties.ID.Name;
            _analysis = analysis;
            _selSolution = selSolution;
            this.TruckProperties = truckProperties;
            ConstraintSet = constraintSet;
        }

        public CasePalletAnalysis ParentAnalysis => _analysis;

        public TruckProperties TruckProperties
        {
            get { return _truckProperties; }
            set
            {
                if (value == _truckProperties) return;
                if (null != _truckProperties) _truckProperties.RemoveDependancy(this);
                _truckProperties = value;
                _truckProperties.AddDependancy(this);
            }
        }

        /// <summary>
        /// Parent solution (from pallet analysis)
        /// </summary>
        public CasePalletSolution ParentSolution => _selSolution.Solution;
        
        /// <summary>
        /// Parent selected solution (from pallet analysis)
        /// </summary>
        public SelCasePalletSolution ParentSelSolution => _selSolution;

        public List<TruckSolution> Solutions
        {
            get { return _truckSolutions; }
            set
            {
                _truckSolutions = value;
                foreach (TruckSolution truckSolution in _truckSolutions)
                    truckSolution.ParentTruckAnalysis = this;
            }
        }

        public TruckConstraintSet ConstraintSet { get; set; }
        
        /// <summary>
        /// Selected solution index in list of truck analysis solutions
        /// </summary>
        public int SelectedSolutionIndex
        {
            set
            {
                if (_selectedSolutionIndex < 0 || _selectedSolutionIndex >= Solutions.Count)
                    throw new Exception("Can not select such truck solution");
                _selectedSolutionIndex = value;
                ParentDocument.Modify();
            }
        }

        /// <summary>
        /// Selected solution
        /// </summary>
        public TruckSolution SelectedSolution
        {
            get
            {
                if (_selectedSolutionIndex < 0 || _selectedSolutionIndex >= _truckSolutions.Count)
                    return null;
                else
                    return _truckSolutions[_selectedSolutionIndex]; 
            }
        }

        /// <summary>
        /// True if index corresponds to a selected solution
        /// Note: in truck analysis, only one solution can be selected
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool HasSolutionSelected(int index)
        {
            return index == _selectedSolutionIndex;
        }

        #region Non-Public Members

        private CasePalletAnalysis _analysis;
        private SelCasePalletSolution _selSolution;
        private TruckProperties _truckProperties;
        private List<TruckSolution> _truckSolutions = new List<TruckSolution>();
        private int _selectedSolutionIndex;

        protected override void RemoveItselfFromDependancies()
        {
            _truckProperties.RemoveDependancy(this);
            _selSolution.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }

        #endregion

    }
}
