#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public partial class UCtrlTriDouble : UserControl
    {
        #region Delegates
        public delegate void onValueChanged(object sender, EventArgs args);
        #endregion

        #region Events
        [Browsable(true)]
        public event onValueChanged ValueChanged;
        #endregion

        #region Constructor
        public UCtrlTriDouble()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        [Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Category("Appearance")]
        public override string Text
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }
        [Browsable(true)]
        public double ValueX { get { return (double)nudValueX.Value; } set { nudValueX.Value = (decimal)value; } }
        [Browsable(true)]
        public double ValueY { get { return (double)nudValueY.Value; } set { nudValueY.Value = (decimal)value; } }
        [Browsable(true)]
        public double ValueZ { get { return (double)nudValueZ.Value; } set { nudValueZ.Value = (decimal)value; } }
        [Browsable(true)]
        public decimal Minimum
        {
            get { return nudValueX.Minimum; }
            set { nudValueX.Minimum = value; }
        }
        [Browsable(true)]
        public UnitsManager.UnitType Unit
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                lbUnit.Text = UnitsManager.UnitString(_unitType);
                nudValueX.DecimalPlaces = nudValueY.DecimalPlaces = nudValueZ.DecimalPlaces = UnitsManager.NoDecimals(_unitType);
            }
        }
        #endregion

        #region Event handlers
        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (null != ValueChanged) ValueChanged(this, e);
        }
        private void onSizeChanged(object sender, EventArgs e)
        {
            // set nud location
            nudValueX.Location = new Point(Width - 3 * UCtrlDouble.stNudLength - 4 - UCtrlDouble.stLbUnitLength, 0);
            nudValueY.Location = new Point(Width - 2 * UCtrlDouble.stNudLength - 2 - UCtrlDouble.stLbUnitLength, 0);
            nudValueZ.Location = new Point(Width - 1 * UCtrlDouble.stNudLength - UCtrlDouble.stLbUnitLength, 0);
            // set unit location
            lbUnit.Location = new Point(Width - UCtrlDouble.stLbUnitLength + 1, 4);
        }
        #endregion

        #region Data members
        private UnitsManager.UnitType _unitType;
        #endregion
    }
}
