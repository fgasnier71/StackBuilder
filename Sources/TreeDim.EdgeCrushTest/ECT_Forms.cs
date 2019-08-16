#region Using directives
using log4net;
using WeifenLuo.WinFormsUI.Docking;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public class ECT_Forms
    {
        static public void ComputeECT(DockPanel dockPanel)
        {
            try
            {
                using (var dockContentComputeBCT = new DockContentComputeBCT())
                { dockContentComputeBCT.Show(dockPanel, DockState.Document); }
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

        #region Static data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(ECT_Forms));
        #endregion
    }
}
