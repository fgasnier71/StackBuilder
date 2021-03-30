#region Using directives
using System.Windows.Forms;
using System.Drawing;
using System;
#endregion

namespace treeDiM.StackBuilder.WCFService.Test
{
    public partial class FormAddItem : Form
    {
        public FormAddItem()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            nudLength.Value = 400.0M;
            nudWidth.Value = 300.0M;
            nudHeight.Value = 200.0M;

            nudWeight.Value = 1.0M;
            nudNumber.Value = 1M;

            cbPriority.SelectedIndex = 0;
        }

        #region Event handlers
        private void OnBnColor(object sender, System.EventArgs e)
        {
            colorDialog.Color = ColorFaces;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                ColorFaces = colorDialog.Color;
                lbColor.BackColor = ColorFaces;
            }
        }
        private void OnOrientationsChanged(object sender, EventArgs e)
        {
            bnOK.Enabled = AllowX || AllowY || AllowZ;
        }
        #endregion

        #region Public properties
        public string CaseName => tbName.Text;
        public Color ColorFaces { get; set; } = Color.Chocolate;
        public double CaseLength => (double)nudLength.Value;
        public double CaseWidth => (double)nudWidth.Value;
        public double CaseHeight => (double)nudHeight.Value;
        public double CaseWeight => (double)nudWeight.Value;
        public uint Number => (uint)nudNumber.Value;
        public bool AllowX => chkbAllowX.Checked;
        public bool AllowY => chkbAllowY.Checked;
        public bool AllowZ => chkbAllowZ.Checked;
        public int Priority => cbPriority.SelectedIndex - 1;
        #endregion
    }
}
