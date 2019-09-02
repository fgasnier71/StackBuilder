#region Using directives
using System;

using log4net;
using WeifenLuo.WinFormsUI.Docking;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public class ECT_Forms
    {
        #region Static methods
        static public void ComputeECT(DockPanel dockPanel)
        {
            try
            {
                var dockContent = new DockContentBCTPalletisation();
                dockContent.Show(dockPanel, DockState.Document);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        static public void ComputeECTReverse(DockPanel dockPanel)
        {
            try
            {
                var dockContent = new DockContentBCTCase();
                dockContent.Show(dockPanel, DockState.Document);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        static public void EditMaterialList()
        {
            try
            {
                using (var form = new FormCardboardQualityList())
                { form.ShowDialog(); }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        static public void EditPalletList()
        {
            try
            {
                using (var form = new FormPalletsDatabase())
                { form.ShowDialog(); }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
        #region Static data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(ECT_Forms));
        #endregion
    }
}
