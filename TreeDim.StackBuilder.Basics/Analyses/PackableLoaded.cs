using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class PackableLoaded : PackableBrick
    {
        public override GlobID ID => _analysis.ID;
        public override double Weight => ParentSolution.Weight;
        public override OptDouble NetWeight => ParentSolution.NetWeight;
        public Analysis ParentAnalysis => _analysis;

        #region Non-Public Members
        protected Analysis _analysis;

        protected PackableLoaded(Analysis analysis)
            : base(analysis.ParentDocument)
        {
            _analysis = analysis;
        }

        protected Solution ParentSolution => _analysis.Solution;
        #endregion
    }
}
