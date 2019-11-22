#region Using directives
using System;
using System.Windows.Forms;

// log4net
using log4net;
// Sharp3D
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisHCylPallet : DockContentView, IDrawingContainer
    {
        #region Constructor
        public DockContentAnalysisHCylPallet(IDocument document, AnalysisHCylPallet analysis)
            : base(document)
        {
            InitializeComponent();
            Analysis = analysis;
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            GridFontSize = Settings.Default.GridFontSize;

            // --- window caption
            if (null != Analysis)
                Text = Analysis.Name + " - " + Analysis.ParentDocument.Name;

            // initialize drawing container
            graphCtrlSolution.DrawingContainer = this;
            graphCtrlSolution.Viewer = new ViewerSolutionHCyl(Solution);
            graphCtrlSolution.Invalidate();

            // --- initialize grid control
            FillGrid();
            UpdateGrid();
            // ---
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
        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            var sv = new ViewerSolutionHCyl(Solution);
            sv.Draw(graphics, Transform3D.Identity);
        }
        #endregion

        #region Virtual functions
        public virtual void FillGrid()
        {
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;

            gridSolution.FixedColumns = 1;

        }
        public virtual void UpdateGrid()
        {
            try
            {
                // remove all existing rows
                gridSolution.Rows.Clear();
                // *** IViews
                // caption header
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Private properties
        private OptDouble MaximumHeight => new OptDouble(true, uCtrlMaxHeight.Value);
        private OptDouble MaximumWeight => uCtrlMaxWeight.Value;
        private OptInt MaximumNumber => uCtrlMaxNumber.Value;
        #endregion

        #region Event handlers
        private void OnSizeChanged(object sender, EventArgs e)
        {
            int splitDistance = splitContainerHoriz.Size.Height - 120;
            if (splitDistance > 0)
                splitContainerHoriz.SplitterDistance = splitDistance;
        }
        private void OnCriterionChanged(object sender, EventArgs args)
        {
            try
            {
                var constraintSet = Solution.AnalysisHCyl.ConstraintSet as ConstraintSetPackablePallet;
                constraintSet.SetMaxHeight(MaximumHeight);
                constraintSet.OptMaxWeight = MaximumWeight;
                constraintSet.OptMaxNumber = MaximumNumber;
                Solution.RebuildSolution();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            // update drawing & grid
            graphCtrlSolution.Invalidate();
            UpdateGrid();
        }
        #endregion

        #region Data members
        protected int GridFontSize { get; set; }
        private AnalysisHCylPallet Analysis { get; set; }
        private SolutionHCyl Solution => Analysis.Solution as SolutionHCyl;

        protected static ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisHCylPallet));
        #endregion


    }
}
