#region Using directives
using System;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisHCylTruck : DockContentView, IDrawingContainer
    {
        #region Constructor
        public DockContentAnalysisHCylTruck(IDocument document, AnalysisHCylTruck analysis)
            : base(document)
        {
           Analysis = analysis;
           Analysis.AddListener(this);

           InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            // --- window caption
            if (null != Analysis)
                Text = Analysis.Name + " - " + Analysis.ParentDocument.Name;

            // initialize controls
            // initialize drawing container
            // initialize grid control
            FillGrid();
            UpdateGrid();
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
            using (var sv = new ViewerSolutionHCyl(Solution))
                sv.Draw(graphics, Transform3D.Identity);
        }
        #endregion
        #region Virtual functions
        public virtual void FillGrid()
        { 
        }
        public virtual void UpdateGrid()
        { 
        }
        #endregion
        #region Event handlers
        private void OnSizeChanged(object sender, EventArgs args)
        {
        }
        private void OnCriterionChanged(object sender, EventArgs args)
        {
            UpdateGrid();
        }
        private void OnGenerateReport(object sender, EventArgs e)
        {
            Close();
            FormMain.GetInstance().GenerateReport(Analysis);
        }
        private void OnBack(object sender, EventArgs e)
        {
            Close();
            Document.EditAnalysis(Analysis);
        }
        #endregion

        #region Data members
        private AnalysisHCylTruck Analysis { get; set; }
        private SolutionHCyl Solution => Analysis.Solution as SolutionHCyl;
        protected static ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisHCylTruck));
        #endregion

    }
}
