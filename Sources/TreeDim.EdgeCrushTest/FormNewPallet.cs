#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using log4net;

using treeDiM.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.PLMPack.DBClient;
using treeDiM.EdgeCrushTest.Properties;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class FormNewPallet : Form
    {
        #region Constructor
        public FormNewPallet()
        {
            InitializeComponent();
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // fill type combo
            cbType.Items.AddRange(PalletData.TypeNames);
            if (cbType.Items.Count > 0)
                cbType.SelectedIndex = 0;

            PalletLength = Settings.Default.PalletLength;
            PalletWidth = Settings.Default.PalletWidth;
            PalletHeight = Settings.Default.PalletHeight;
            Weight = Settings.Default.PalletWeight;

            UpdateStatus(string.Empty);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            bool abort = false;
            if (!e.Cancel)
            {
                using (WCFClient wcfClient = new WCFClient())
                {
                    if (wcfClient.Client.ItemExists(DCSBTypeEnum.TPallet, ItemName))
                    {
                        abort = true;
                        MessageBox.Show(string.Format(Resources.ID_NAMEALREADYEXISTS, ItemName));
                    }
                    else 
                        wcfClient.Client?.CreateNewPallet(new DCSBPallet()
                        {
                            Name = ItemName,
                            Description = ItemDescription,
                            UnitSystem = (int)UnitsManager.CurrentUnitSystem,
                            PalletType = PalletTypeName,
                            Dimensions = new DCSBDim3D() { M0 = PalletLength, M1 = PalletWidth, M2 = PalletHeight },
                            Weight = Weight,
                            AdmissibleLoad = 1000.0,
                            Color = Color.Gold.ToArgb(),
                            AutoInsert = false
                        }
                            );
                }
            }
            if (!abort)
                base.OnClosing(e);
        }
        #endregion

        #region Public properties
        public string ItemName { get => tbName.Text; set => tbName.Text = value; }
        public string ItemDescription { get => tbDescription.Text; set => tbDescription.Text = value; }
        public string PalletTypeName
        {
            get { return cbType.Items[cbType.SelectedIndex].ToString(); }
            set
            {
                int index = 0;
                foreach (string item in cbType.Items)
                {
                    if (string.Equals(item, value))
                        break;
                    ++index;
                }
                if (cbType.Items.Count > index)
                    cbType.SelectedIndex = index;
            }
        }
        public double PalletLength { get => uCtrlDimensions.ValueX; set => uCtrlDimensions.ValueX = value; }
        public double PalletWidth { get => uCtrlDimensions.ValueY; set => uCtrlDimensions.ValueY = value; }
        public double PalletHeight { get => uCtrlDimensions.ValueZ; set => uCtrlDimensions.ValueZ = value; }
        public double Weight { get => uCtrlWeight.Value; set => uCtrlWeight.Value = value; }
        #endregion

        #region Helpers
        private void UpdateStatus(string message)
        {

            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            else if (null != PalletNames.Find(n => (n.ToLower() == ItemName.ToLower())))
                message = string.Format(Resources.ID_NAMEALREADYEXISTS, ItemName);
            bnOK.Enabled = string.IsNullOrEmpty(message);
            statusLabel.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            statusLabel.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion

        #region Event handlers
        private void OnInputChanged(object sender, EventArgs e)
        {
            UpdateStatus(string.Empty);
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPallet));
        public List<string> PalletNames { get; set; } = new List<string>();
        #endregion
    }
}
