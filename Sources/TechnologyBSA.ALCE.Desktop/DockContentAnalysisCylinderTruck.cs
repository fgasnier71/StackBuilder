#region Using directives
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinderTruck : DockContentAnalysisEdit
    {
        #region Constructor
        public DockContentAnalysisCylinderTruck(IDocument doc, AnalysisCylinderTruck analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Override DockContentAnalysisEdit
        protected override string GridCaption => Resources.ID_TRUCK;
        #endregion
    }
}
