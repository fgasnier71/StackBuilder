#region Using directives
using System;
using System.ComponentModel;
using System.Windows.Forms;

using treeDiM.StackBuilder.ExcelAddIn.Properties;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class FormSettingsPerSheet : Form
    {
        public FormSettingsPerSheet()
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

            tbNoCases.Text = Settings.Default.CellNoCases;
            tbLoadWeight.Text = Settings.Default.CellLoadWeight;
            tbTotalWeight.Text = Settings.Default.CellTotalPalletWeight;

            uCtrlImageLeftTop.ValueX = Settings.Default.ImageLeft;
            uCtrlImageLeftTop.ValueY = Settings.Default.ImageTop;
            uCtrlImageDim.ValueX = Settings.Default.ImageWidth;
            uCtrlImageDim.ValueY = Settings.Default.ImageHeight;
            nudImageDef.Value = (decimal)Settings.Default.ImageSize;

            cbUnitSystem.SelectedIndex = Settings.Default.UnitSystem;
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

            Settings.Default.CellNoCases = tbNoCases.Text;
            Settings.Default.CellLoadWeight = tbLoadWeight.Text;
            Settings.Default.CellTotalPalletWeight = tbTotalWeight.Text;

            Settings.Default.ImageLeft = uCtrlImageLeftTop.ValueX;
            Settings.Default.ImageTop = uCtrlImageLeftTop.ValueY;
            Settings.Default.ImageWidth = uCtrlImageDim.ValueX;
            Settings.Default.ImageHeight = uCtrlImageDim.ValueY;
            Settings.Default.ImageSize = (int)nudImageDef.Value;

            Settings.Default.UnitSystem = cbUnitSystem.SelectedIndex;

            Settings.Default.Save();

            base.OnClosing(e);
        }

        private void OnUnitSystemChanged(object sender, EventArgs e)
        {
            Basics.UnitsManager.CurrentUnitSystem = (Basics.UnitsManager.UnitSystem)cbUnitSystem.SelectedIndex;
            uCtrlImageDim.Invalidate();
            uCtrlImageLeftTop.Invalidate();
        }
    }
}
