#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class UCtrlCase : UCtrlPackable
    {
        #region Constructor
        public UCtrlCase()
        {
            InitializeComponent();

            uCtrlDimensions.ValueChanged += this.onPropertyChanged;
            uCtrlWeight.ValueChanged += this.onPropertyChanged;
        }
        #endregion

        #region Public properties
        public double[] Dimensions
        {
            get { return new double[] { uCtrlDimensions.ValueX, uCtrlDimensions.ValueY, uCtrlDimensions.ValueZ }; }
            set
            {
                uCtrlDimensions.ValueX = value[0];
                uCtrlDimensions.ValueY = value[1];
                uCtrlDimensions.ValueZ = value[2];
            }
            
        }
        public double Weight
        {
            get { return uCtrlWeight.Value; }
            set { uCtrlWeight.Value = value; }
        }
        public override Packable PackableProperties
        {
            get
            {
                BoxProperties bCase = new BoxProperties(null, Dimensions);
                bCase.SetWeight(Weight);
                bCase.SetColor(Color.Chocolate);
                return bCase;
            }
        }
        #endregion

        #region Event handlers
        private void onPropertyChanged(object sender, EventArgs e)
        {
            if (null != ValueChanged)
                ValueChanged(this, e);
        }
        #endregion

        #region Events
        public delegate void OnValueChanged(object sender, EventArgs e);
        public event OnValueChanged ValueChanged;
        #endregion
    }
}
