#region Using directives
using System;
using WeifenLuo.WinFormsUI.Docking;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentDocumentExplorer : DockContent
    {
        #region Constructor
        public DockContentDocumentExplorer()
        {
            InitializeComponent();
        }
        #endregion

        #region Menu event handlers
        private void FloatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { DockState = DockState.Float; }
            catch (InvalidOperationException ex) { _log.Error(ex.Message); }
        }
        private void DockableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { DockState = ShowHint; }
            catch (InvalidOperationException ex) { _log.Error(ex.Message); }
        }
        private void TabbedDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { DockState = DockState.Document; }
            catch (InvalidOperationException ex) { _log.Error(ex.Message); }
        }
        private void AutoHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (DockState)
                {
                    case DockState.DockBottom:  DockState = DockState.DockBottomAutoHide;  break;
                    case DockState.DockTop:     DockState = DockState.DockTopAutoHide;     break;
                    case DockState.DockLeft:    DockState = DockState.DockLeftAutoHide;    break;
                    case DockState.DockRight:   DockState = DockState.DockRightAutoHide;   break;
                    default: break;
                }
            }
            catch (InvalidOperationException ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Public properties
        public AnalysisTreeView DocumentTreeView
        {
            get { return _documentTreeView; }
        }
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(DockContentDocumentExplorer));
        #endregion
    }
}
