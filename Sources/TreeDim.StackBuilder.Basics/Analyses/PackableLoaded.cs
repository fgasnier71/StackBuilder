#region Using directives
using treeDiM.Basics;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class PackableLoaded : PackableBrick
    {
        #region Non-Public Members
        protected PackableLoaded(AnalysisHomo analysis)
            : base(analysis.ParentDocument)
        {
            ParentAnalysis = analysis;
        }
        protected SolutionHomo ParentSolution => ParentAnalysis.Solution;
        #endregion

        #region Public properties
        public AnalysisHomo ParentAnalysis { get; private set; }
        #endregion

        #region Override 
        public override GlobID ID => ParentAnalysis.ID;
        public override double Weight => ParentSolution.Weight;
        public override OptDouble NetWeight => ParentSolution.NetWeight;
        #endregion

        #region Override ItemBase (dependancies)
        public override void AddDependancy(ItemBase dependancy)
        { ParentAnalysis?.AddDependancy(dependancy); }
        public override void RemoveDependancy(ItemBase dependancy)
        { ParentAnalysis?.RemoveDependancy(dependancy); }
        #endregion
    }
}
