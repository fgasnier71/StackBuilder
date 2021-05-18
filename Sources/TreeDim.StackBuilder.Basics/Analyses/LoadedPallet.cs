#region Using directives
using System.Collections.Generic;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class LoadedPallet : PackableLoaded
    {
        internal LoadedPallet(AnalysisHomo analysis)
            : base(analysis)
        {
        }

        public override double Length => ParentSolution.BBoxGlobal.Length;
        public override double Width => ParentSolution.BBoxGlobal.Width;
        public override double Height => ParentSolution.BBoxGlobal.Height;
        public override bool InnerContent(ref List<Pair<Packable, int>> listInnerPackables)
        {
            listInnerPackables = new List<Pair<Packable, int>>
            {
                new Pair<Packable, int>(ParentAnalysis.Content, ParentSolution.ItemCount)
            };
            return true;
        }
        public override bool InnerAnalysis(ref AnalysisHomo analysis)
        {
            analysis = ParentAnalysis;
            return true;
        }

        #region Non-Public Members
        private AnalysisCasePallet AnalysisCasePallet => ParentAnalysis as AnalysisCasePallet;
        private AnalysisHCylPallet AnalysisHCylPallet => ParentAnalysis as AnalysisHCylPallet;
        protected override string TypeName => Properties.Resources.ID_LOADEDPALLET;
        #endregion
    }
}
