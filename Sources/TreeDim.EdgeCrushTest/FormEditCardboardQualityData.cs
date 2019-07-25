#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class FormEditCardboardQualityData : Form
    {
        #region Data members
        enum Mode { MODE_CREATE, MODE_MODIFY}
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
        public double RigidityX
        {
            get => (double)nudRigidityX.Value;
            set => nudRigidityX.Value = (decimal)value;
        }
        public double RigidityY
        {
            get => (double)nudRigidityY.Value;
            set => nudRigidityY.Value = (decimal)value;
        }
        #endregion
    }
}
