#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

using treeDiM.EdgeCrushTest.Properties;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class FormEditCardboardQualityData : Form
    {
        #region Data members
        public enum EMode { MODE_CREATE, MODE_MODIFY}
        #endregion
        #region Constructor
        public FormEditCardboardQualityData()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Mode == EMode.MODE_CREATE)
            {
                Profile = Settings.Default.MatProfile;
                Thickness = Settings.Default.MatThickness;
                ECT = Settings.Default.MatECT;
                StiffnessX = Settings.Default.MatStiffnessX;
                StiffnessY = Settings.Default.MatStiffnessY;
            }
            else
            {
                tbQualityName.Enabled = false;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.MatProfile = Profile;
            Settings.Default.MatThickness = Thickness;
            Settings.Default.MatECT = ECT;
            Settings.Default.MatStiffnessX = StiffnessX;
            Settings.Default.MatStiffnessY = StiffnessY;
            Settings.Default.Save();
        }
        #endregion
        #region Status
        private void UpdateStatus()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(QualityName.Trim()))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (Thickness <= 0.0 || StiffnessX <= 0.0 || StiffnessY <= 0.0 || ECT <= 0.0)
                message = Resources.ID_VALUEOUGHTTOBESPOSITIVE;
            else if (Mode == EMode.MODE_CREATE && CardboardQualityAccessor.Instance.NameExists(QualityName))
                message = Resources.ID_NAMEALREADYEXISTS;

            // status label
            statusLabel.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            statusLabel.Text = string.IsNullOrEmpty(message) ? Resources.IDS_READY : message;
            // generate button
            bnOk.Enabled = string.IsNullOrEmpty(message);
        }
        #endregion
        #region Public properties
        public string QualityName
        {
            get => tbQualityName.Text;
            set => tbQualityName.Text = value;
        }
        public string Profile
        {
            get => tbProfile.Text;
            set => tbProfile.Text = value;
        }
        public double Thickness
        {
            get => (double)nudThickness.Value;
            set => nudThickness.Value = (decimal)value;
        }
        public double ECT
        {
            get => (double)nudECT.Value;
            set => nudECT.Value = (decimal)value;
        }
        public double StiffnessX
        {
            get => (double)nudStiffnessX.Value;
            set => nudStiffnessX.Value = (decimal)value;
        }
        public double StiffnessY
        {
            get => (double)nudStiffnessY.Value;
            set => nudStiffnessY.Value = (decimal)value;
        }
        public EMode Mode { get; set; }
        #endregion
        #region Event handler
        private void OnInputChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        #endregion
    }
}
