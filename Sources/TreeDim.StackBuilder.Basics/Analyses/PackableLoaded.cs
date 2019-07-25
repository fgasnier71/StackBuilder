using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class PackableLoaded : PackableBrick
    {
        public override GlobID ID => _analysis.ID;
        public override double Weight => ParentSolution.Weight;
        public override OptDouble NetWeight => ParentSolution.NetWeight;
        public AnalysisHomo ParentAnalysis => _analysis;

        #region Non-Public Members
        protected PackableLoaded(AnalysisHomo analysis)
            : base(analysis.ParentDocument)
        {
            _analysis = analysis;
        }

        protected Solution ParentSolution => _analysis.Solution;
        protected AnalysisHomo _analysis;
        #endregion

        #region Override ItemBase (dependancies)
        public override void AddDependancy(ItemBase dependancy)
        { _analysis?.AddDependancy(dependancy); }
        public override void RemoveDependancy(ItemBase dependancy)
        { _analysis?.RemoveDependancy(dependancy); }
        #endregion
    }
}
