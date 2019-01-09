using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class LoadedCase : PackableLoaded
    {
        internal LoadedCase(AnalysisPackableCase analysis)
            : base(analysis)
        {
        }

        public override GlobID ID
        {
            get
            {
                return new GlobID(
                    _analysis.ID.IGuid,
                    string.Format("{0}({1})", Properties.Resources.ID_NAMECASE, _analysis.Name),
                    _analysis.Description
                    );
            }
        }

        public Packable Container => Analysis.CaseProperties;
        public override bool IsCase => true;
        public override double Length => Analysis.CaseProperties.Length;
        public override double Width => Analysis.CaseProperties.Width;
        public override double Height => Analysis.CaseProperties.Height;

        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = ParentAnalysis.Content;
            number = ParentSolution.ItemCount;
            return true;
        }
        public override bool InnerAnalysis(ref AnalysisHomo analysis)
        {
            analysis = Analysis;
            return true;
        }

        #region Non-Public Members
        private AnalysisBoxCase Analysis => ParentAnalysis as AnalysisBoxCase;
        protected override string TypeName => Properties.Resources.ID_LOADEDCASE;
        #endregion
    }
}
