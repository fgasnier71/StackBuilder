#region Using directives
using System;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelPalletEdition : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelPalletEdition()
        {
            InitializeComponent();

            CategoryPath = Properties.Resources.ID_OPTIONSPALLETEDITION;
            DisplayName = Properties.Resources.ID_DISPLAYPALLETEDITION;

            // initialize distance
            uCtrlDistAbove.Value = UnitsManager.ConvertLengthFrom( Properties.Settings.Default.DistanceAboveSelectedLayer, UnitsManager.UnitSystem.UNIT_METRIC1 );
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
            Properties.Settings.Default.DistanceAboveSelectedLayer = UnitsManager.ConvertLengthTo(uCtrlDistAbove.Value, UnitsManager.UnitSystem.UNIT_METRIC1);
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
