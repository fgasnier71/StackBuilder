#region Using directives
using System;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentHAnalysis : DockContentView, IDrawingContainer
    {
        #region Constructors
        public DockContentHAnalysis()
            : base(null)
        {
            InitializeComponent();
        }
        public DockContentHAnalysis(IDocument document, HAnalysis analysis)
            : base(document)
        {
            Analysis = analysis;
            Analysis.AddListener(this);
            Solution = Analysis.Solution;

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

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Document.RemoveView(this);
        }
        #endregion

        #region IItemListener implementation
        public override void Update(ItemBase item)
        {
        }
        public override void Kill(ItemBase item)
        {
            Close();
            if (null != Analysis)
                Analysis.RemoveListener(this);
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            ViewerHSolution sv = new ViewerHSolution(Solution, SolItemIndex);
            sv.Draw(graphics, Transform3D.Identity)
        }
        #endregion

        #region Public properties
        public HAnalysis Analysis { get; set; } = null;
        public HSolution Solution { get; set; }
        private int SolItemIndex { get; set; }
        #endregion

        #region Data members
        protected HSolution _solution;
        private static ILog _log = LogManager.GetLogger(typeof(DockContentHAnalysis));
        #endregion

        #region Event handlers
        private void OnSolItemIndexDown(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnSolItemIndexUp(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnBack(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnGenerateReport(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnGenerateExportXML(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnGenerateExportCSV(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
