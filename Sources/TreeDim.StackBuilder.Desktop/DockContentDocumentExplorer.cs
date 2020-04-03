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
        #region DockContent menu items event handlers
        private void OnMenuItemDockable(object sender, EventArgs e)
        {
            try
            {
                ShowHint = DockState.DockLeft;
                if (DockableToolStripMenuItem.Checked)
                    DockState = ShowHint;
                else
                    DockState = DockState.Float;
            }
            catch (InvalidOperationException ex)
            {
                _log.Error(ex.Message); 
            }
        }
        private void OnMenuItemAutoHide(object sender, EventArgs e)
        {
            try
            {
                if (AutoHideToolStripMenuItem.Checked)
                {
                    switch (DockState)
                    {
                        case DockState.DockBottom: DockState = DockState.DockBottomAutoHide; break;
                        case DockState.DockTop: DockState = DockState.DockTopAutoHide; break;
                        case DockState.DockLeft: DockState = DockState.DockLeftAutoHide; break;
                        case DockState.DockRight: DockState = DockState.DockRightAutoHide; break;
                        default: break;
                    }
                }
                else
                {
                     switch (DockState)
                     {
                        case DockState.DockBottomAutoHide: DockState = DockState.DockBottom; break;
                        case DockState.DockTopAutoHide: DockState = DockState.DockTop; break;
                        case DockState.DockLeftAutoHide: DockState = DockState.DockLeft; break;
                        case DockState.DockRightAutoHide: DockState = DockState.DockRight; break;
                        default: break;
                    }
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
