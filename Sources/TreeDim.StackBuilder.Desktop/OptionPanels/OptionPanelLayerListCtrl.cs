#region Using directives
using System;

using treeDiM.StackBuilder.Graphics.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelLayerListCtrl : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelLayerListCtrl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // set radio buttons 2D/3D
            rbView1.Checked = !Settings.Default.LayerView3D;
            rbView2.Checked = Settings.Default.LayerView3D;
            // set size
            cbThumbSize.SelectedIndex = Settings.Default.LayerViewThumbSizeIndex;
        }
        #endregion

        #region Handlers
        private void OnThumbnailSizeChanged(object sender, EventArgs e)
        {
            Settings.Default.LayerViewThumbSizeIndex = cbThumbSize.SelectedIndex;
            Settings.Default.Save();
        }
        private void OnLayerViewChanged(object sender, EventArgs e)
        {
            Settings.Default.LayerView3D = rbView2.Checked;
            Settings.Default.Save();
        }
        #endregion
    }
}
