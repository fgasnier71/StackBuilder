#region Using directives
using System;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelDimensions : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelDimensions()
        {
            InitializeComponent();

            CategoryPath = Properties.Resources.ID_OPTIONSDIMENSIONS;
            DisplayName = Properties.Resources.ID_DISPLAYDIMENSIONSCASEPALLET;

            // initialize combo box
            cbDim1.SelectedIndex = Properties.Settings.Default.DimCasePalletSol1;
            cbDim2.SelectedIndex = Properties.Settings.Default.DimCasePalletSol2;
        }
        #endregion

        #region Handlers
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // set event handler
            OptionsForm.OptionsSaving += new EventHandler(OnOptionsSaving);
        }
        private void OnOptionsSaving(object sender, EventArgs e)
        {
            // save combo box
            Properties.Settings.Default.DimCasePalletSol1 = cbDim1.SelectedIndex;
            Properties.Settings.Default.DimCasePalletSol2 = cbDim2.SelectedIndex;
            Properties.Settings.Default.Save();

            Graphics.ViewerSolution.DimCasePalletSol1 = Properties.Settings.Default.DimCasePalletSol1;
            Graphics.ViewerSolution.DimCasePalletSol2 = Properties.Settings.Default.DimCasePalletSol2;
        }
        #endregion
    }
}
