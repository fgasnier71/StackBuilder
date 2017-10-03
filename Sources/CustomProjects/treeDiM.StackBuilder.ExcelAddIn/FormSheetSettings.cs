using System;
using System.ComponentModel;
using System.Windows.Forms;
using treeDiM.StackBuilder.ExcelAddIn.Properties;

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class FormSheetSettings : Form
    {
        public FormSheetSettings()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tbLengthCell.Text = Settings.Default.CellCaseLength;
            tbWidthCell.Text = Settings.Default.CellCaseWidth;
            tbHeightCell.Text = Settings.Default.CellCaseHeight;
            tbWeightCell.Text = Settings.Default.CellCaseWeight;

            tbPalletLength.Text = Settings.Default.CellPalletLength;
            tbPalletWidth.Text = Settings.Default.CellPalletWidth;
            tbPalletHeight.Text = Settings.Default.CellPalletHeight;
            tbPalletWeight.Text = Settings.Default.CellPalletWeight;

            tbMaxPalletHeight.Text = Settings.Default.CellMaxPalletHeight;
            tbMaxPalletWeight.Text = Settings.Default.CellMaxPalletWeight;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (e.Cancel)
                return;

            Settings.Default.CellCaseLength = tbLengthCell.Text;
            Settings.Default.CellCaseWidth = tbWidthCell.Text;
            Settings.Default.CellCaseHeight = tbHeightCell.Text;
            Settings.Default.CellCaseWeight = tbWeightCell.Text;

            Settings.Default.CellPalletLength = tbPalletLength.Text;
            Settings.Default.CellPalletWidth = tbPalletWidth.Text;
            Settings.Default.CellPalletHeight = tbPalletHeight.Text;
            Settings.Default.CellPalletWeight = tbPalletWeight.Text;

            Settings.Default.CellMaxPalletHeight = tbMaxPalletHeight.Text;
            Settings.Default.CellMaxPalletWeight = tbMaxPalletWeight.Text;

            Settings.Default.Save();

            base.OnClosing(e);
        }
    }
}
