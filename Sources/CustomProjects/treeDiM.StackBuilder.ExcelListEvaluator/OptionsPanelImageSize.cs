using System;
using GLib.Options;

namespace treeDiM.StackBuilder.ExcelListEvaluator
{
    public partial class OptionsPanelImageSize : OptionsPanel
    {
        public OptionsPanelImageSize()
        {
            InitializeComponent();
        }

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            nudImageSize.Value = (decimal)Properties.Settings.Default.ImageSize;


            // events
            OptionsForm.OptionsSaving += new EventHandler(OnOptionSaving);
        }
        #endregion

        #region Handlers
        protected void OnOptionSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.ImageSize = (int)nudImageSize.Value;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
