#region Using directives
using System;
using System.ComponentModel;
using System.Windows.Forms;

using treeDiM.StackBuilder.ExcelAddIn.Properties;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class FormSettingsPerRow : Form
    {
        public FormSettingsPerRow()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ExcelHelpers.FillComboWithColumnName(cbName);
            ExcelHelpers.FillComboWithColumnName(cbDescription);
            ExcelHelpers.FillComboWithColumnName(cbLength);
            ExcelHelpers.FillComboWithColumnName(cbWidth);
            ExcelHelpers.FillComboWithColumnName(cbHeight);
            ExcelHelpers.FillComboWithColumnName(cbWeight);
            ExcelHelpers.FillComboWithColumnName(cbOutputStart);

            try
            {
                cbName.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterName) - 1;
                cbDescription.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(
                    string.IsNullOrEmpty(Settings.Default.ColumnLetterDescription) ? Settings.Default.ColumnLetterName : Settings.Default.ColumnLetterDescription) - 1;
                cbLength.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterLength) - 1;
                cbWidth.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterWidth) - 1;
                cbHeight.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterHeight) - 1;
                cbWeight.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterWeight) - 1;
                cbOutputStart.SelectedIndex = ExcelHelpers.ColumnLetterToColumnIndex(Settings.Default.ColumnLetterOutputStart) - 1;

                nudImageSize.Value = Settings.Default.ImageSize;
                nudMaxCountImage.Value = Settings.Default.StackCountMax;
                uCtrlMinDimensions.Value = Settings.Default.MinDimensions;

                chkbDescription.Checked = !string.IsNullOrEmpty(Settings.Default.ColumnLetterDescription);
                cbUnitSystem.SelectedIndex = Settings.Default.UnitSystem;
            }
            catch (Exception /*ex*/)
            { 
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel)
            {
                try
                {
                    Settings.Default.ColumnLetterName = cbName.SelectedItem.ToString();
                    Settings.Default.ColumnLetterDescription = cbDescription.SelectedItem.ToString();
                    Settings.Default.ColumnLetterLength = cbLength.SelectedItem.ToString();
                    Settings.Default.ColumnLetterWidth = cbWidth.SelectedItem.ToString();
                    Settings.Default.ColumnLetterHeight = cbHeight.SelectedItem.ToString();
                    Settings.Default.ColumnLetterWeight = cbWeight.SelectedItem.ToString();
                    Settings.Default.ColumnLetterOutputStart = cbOutputStart.SelectedItem.ToString();
                    Settings.Default.ImageSize = (int)nudImageSize.Value;
                    Settings.Default.StackCountMax = (int)nudMaxCountImage.Value;
                    Settings.Default.MinDimensions = uCtrlMinDimensions.Value;

                    if (!chkbDescription.Checked)
                        Settings.Default.ColumnLetterDescription = string.Empty;

                    Settings.Default.UnitSystem = cbUnitSystem.SelectedIndex;
                    Settings.Default.Save();
                }
                catch (Exception /*ex*/)
                {                    
                }
            }
        }

        private void OnDescriptionChecked(object sender, EventArgs e)
        {
            cbDescription.Enabled = chkbDescription.Checked;
        }
    }
}
