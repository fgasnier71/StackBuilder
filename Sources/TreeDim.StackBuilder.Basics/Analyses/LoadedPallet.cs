using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class LoadedPallet : PackableLoaded
    {
        internal LoadedPallet(AnalysisPackablePallet analysis)
            : base(analysis)
        {
        }

        public override double Length => ParentSolution.BBoxGlobal.Length;
        public override double Width => ParentSolution.BBoxGlobal.Width;
        public override double Height => ParentSolution.BBoxGlobal.Height;
        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = ParentAnalysis.Content;
            number = ParentSolution.ItemCount;
            return true;
        }
        public override bool InnerAnalysis(ref Analysis analysis)
        {
            analysis = ParentAnalysis;
            return true;
        }

        #region Non-Public Members

        private AnalysisCasePallet Analysis => ParentAnalysis as AnalysisCasePallet;
        protected override string TypeName => Properties.Resources.ID_LOADEDPALLET;

        #endregion
    }
}
