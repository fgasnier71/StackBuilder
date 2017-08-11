using System;

namespace treeDiM.StackBuilder.ABYATExcelLoader
{
    public partial class OptionsPanelFiltering  : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionsPanelFiltering()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            nudStackCountMax.Value = (decimal)Properties.Settings.Default.StackCountMax;
            uCtrlLargestDimMin.Value = Properties.Settings.Default.LargestDimMinimum;

            // events
            OptionsForm.OptionsSaving += new EventHandler(OnOptionSaving);
        }
        #endregion

        #region Handlers
        protected void OnOptionSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.StackCountMax = (int)nudStackCountMax.Value;
            Properties.Settings.Default.LargestDimMinimum = uCtrlLargestDimMin.Value;
            Properties.Settings.Default.Save();   
        }        
        #endregion
    }
}
