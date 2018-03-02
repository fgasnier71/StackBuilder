#region Using directives
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region Box / case selected solution
    public class SelBoxCaseSolution : ItemBaseNamed
    {
        #region Data members
        private BoxCaseAnalysis _analysis;
        private BoxCaseSolution _solution;
        #endregion

        #region Constructor
        public SelBoxCaseSolution(Document document, BoxCaseAnalysis analysis, BoxCaseSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

            _solution = sol;
            ID.Name = sol.Title;
        }
        #endregion

        #region Public properties
        public BoxCaseSolution Solution
        {
            get { return _solution; }
        }
        #endregion

        #region ItemBase override
        #endregion
    }
    #endregion

    #region Pack pallet solution
    public class SelPackPalletSolution : ItemBaseNamed
    {
        #region Data members
        private PackPalletAnalysis _analysis;
        private PackPalletSolution _solution;
        #endregion

        #region Constructor
        public SelPackPalletSolution(Document document, PackPalletAnalysis analysis, PackPalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _solution = sol;
            ID.Name = sol.Title;
        }
        #endregion

        #region Public properties
        public PackPalletAnalysis Analysis
        {
            get { return _analysis; }
        }
        public PackPalletSolution Solution
        {
            get { return _solution; }
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
}
