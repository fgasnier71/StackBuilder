#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using treeDiM.StackBuilder;
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
        private void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            // save combo box
            Properties.Settings.Default.DimCasePalletSol1 = cbDim1.SelectedIndex;
            Properties.Settings.Default.DimCasePalletSol2 = cbDim2.SelectedIndex;
            Properties.Settings.Default.Save();

            Graphics.ViewerSolution.DimCasePalletSol1 = Properties.Settings.Default.DimCasePalletSol1;
            Graphics.ViewerSolution.DimCasePalletSol2 = Properties.Settings.Default.DimCasePalletSol2;

        }
        #endregion

        #region Handlers
        private void OptionPanelDimensions_Load(object sender, EventArgs e)
        {
            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion
    }
}
