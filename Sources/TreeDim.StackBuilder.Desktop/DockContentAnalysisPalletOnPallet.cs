#region Using directives
using System;
using System.Windows.Forms;

using log4net;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisPalletsOnPallet : DockContentView
    {
        #region Constructor
        public DockContentAnalysisPalletsOnPallet(IDocument document, AnalysisPalletsOnPallet analysis)
            : base(document)
        {
            InitializeComponent();
            Analysis = analysis;
        }
        #endregion
        #region IItemListener implementation
        public override void Update(ItemBase item)
        {
            base.Update(item);
            graphCtrlSolution.Invalidate();
        }
        public override void Kill(ItemBase item)
        {
            base.Kill(item);
            if (null != Analysis)
                Analysis.RemoveListener(this);
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FillGrid();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Document.RemoveView(this);
        }
        #endregion
        #region Grid
        private void FillGrid()
        {
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;
            gridSolution.FixedColumns = 1;
            gridSolution.FixedRows = 1;

            // cell visual properties
            var vPropHeader = CellProperties.VisualPropHeader;
            var vPropValue = CellProperties.VisualPropValue;

            int iRow = -1;
            // pallet caption
            gridSolution.Rows.Insert(++iRow);
            gridSolution[iRow, 0] = new ColumnHeaderSolution(Resources.ID_TRUCK) { ColumnSpan = 1 };
            gridSolution[iRow, 1] = new ColumnHeaderSolution(string.Empty) { ColumnSpan = 1 };

            gridSolution.AutoSizeCells();
            gridSolution.Columns.StretchToFit();
            gridSolution.AutoStretchColumnsToFitWidth = true;
            gridSolution.Invalidate();
        }
        #endregion
        #region Toolbar event handlers
        private void OnBack(object sender, EventArgs e)
        {
            // close this form
            Close();
            // call edit analysis
            Document.EditAnalysis(Analysis);
        }
        private void OnGenerateReport(object sender, EventArgs e)
        {
            FormMain.GenerateReport(Analysis);
        }
        private void OnScreenshot(object sender, EventArgs e)
        {
            graphCtrlSolution.ScreenShotToClipboard();
        }
        #endregion
        #region Data members
        /// <summary>
        /// analysis
        /// </summary>
        public AnalysisPalletsOnPallet Analysis { get; set; }
        /// <summary>
        ///  logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisPalletsOnPallet));
        #endregion
    }
}
