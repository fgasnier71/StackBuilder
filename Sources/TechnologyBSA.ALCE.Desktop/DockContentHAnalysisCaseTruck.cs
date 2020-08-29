#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentHAnalysisCaseTruck : DockContentHAnalysis
    {
        public DockContentHAnalysisCaseTruck(IDocument document, AnalysisHetero analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        public override void UpdateGrid()
        {
            base.UpdateGrid();
        }
    }
}
