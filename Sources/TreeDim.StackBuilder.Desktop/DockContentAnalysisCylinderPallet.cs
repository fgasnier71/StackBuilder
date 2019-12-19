#region Using directives

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinderPallet : DockContentAnalysisEdit
    {
        #region Constructor
        public DockContentAnalysisCylinderPallet(IDocument document, AnalysisCylinderPallet analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Override DockContentAnalysisEdit
        protected override string GridCaption => Resources.ID_PALLET;
        #endregion
    }
}
