#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace treeDiM.Basics
{
    public partial class UCtrlOptDouble : UserControl
    {
        #region Delegates
        public delegate void ValueChangedDelegate(object sender, EventArgs e);
        #endregion

        #region Events
        [Browsable(true)]
        public event ValueChangedDelegate ValueChanged;
        #endregion

        #region Constructor
        public UCtrlOptDouble()
        {
            InitializeComponent();
            // by default, no unit type
            Unit = UnitsManager.UnitType.UT_NONE;
        }
        #endregion

        #region Public properties
        [Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Category("Appearance")]
        public override string Text
        {
            get { return chkbOpt.Text; }
            set { chkbOpt.Text = value; }
        }
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OptDouble Value
        {
            get { return new OptDouble(chkbOpt.Checked, (double)nudValue.Value); }
            set
            {
                chkbOpt.Checked = value.Activated;
                try { nudValue.Value = (decimal)value.ValueDef; } catch (ArgumentOutOfRangeException) {}
                OnCheckChanged(this, null);
            }
        }
        [Browsable(true)]
        public decimal Minimum
        {
            get { return nudValue.Minimum; }
            set { nudValue.Minimum = value; }
        }
        [Browsable(true)]
        public UnitsManager.UnitType Unit
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                lbUnit.Text = UnitsManager.UnitString(_unitType);
                nudValue.DecimalPlaces = UnitsManager.NoDecimals(_unitType);
            }
        }
        #endregion

        #region Event handlers
        private void OnCheckChanged(object sender, EventArgs e)
        {
            nudValue.Enabled = chkbOpt.Checked;
            lbUnit.Enabled = chkbOpt.Checked;
            ValueChanged?.Invoke(this, e);
        }
        private void OnValueChangedLocal(object sender, EventArgs e) => ValueChanged?.Invoke(this, e);
        private void OnSizeChanged(object sender, EventArgs e)
        {
            // set nud location
            nudValue.Location = new Point(Width - UCtrlDouble.stNudLength - UCtrlDouble.stLbUnitLength, 0);
            // set unit location
            lbUnit.Location = new Point(Width - UCtrlDouble.stLbUnitLength + 1, 4);
        }
        #endregion

        #region Data members
        private UnitsManager.UnitType _unitType;
        #endregion
    }
}
