#region Using directives
using log4net;

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
        public override string GridCaption
        { get { return Resources.ID_TRUCK; } }
        #endregion

        #region Data members
        private new static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisCylinderTruck));
        #endregion
    }
}
