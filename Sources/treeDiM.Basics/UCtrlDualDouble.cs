#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.Basics
{
    public partial class UCtrlDualDouble : UserControl
    {
        #region Delegates
        public delegate void ValueChangedDelegate(object sender, EventArgs args);
        #endregion

        #region Events
        public event ValueChangedDelegate ValueChanged;
        #endregion

        #region Constructor
        public UCtrlDualDouble()
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
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Vector2D Value
        {
            get { return new Vector2D(ValueX, ValueY); }
            set { try { ValueX = value.X; ValueY = value.Y; } catch (ArgumentOutOfRangeException) { } }
        }
        [Browsable(true)]
        public double ValueX
        {
            get { return (double)nudValueX.Value; }
            set { try { nudValueX.Value = (decimal)value; } catch (ArgumentOutOfRangeException) { } }
        }
        [Browsable(true)]
        public double ValueY
        {
            get { return (double)nudValueY.Value; }
            set { try { nudValueY.Value = (decimal)value; } catch (ArgumentOutOfRangeException) { } }
        }
        [Browsable(true)]
        public UnitsManager.UnitType Unit
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                lbUnit.Text = UnitsManager.UnitString(_unitType);
                nudValueX.DecimalPlaces = UnitsManager.NoDecimals(_unitType);
                nudValueY.DecimalPlaces = UnitsManager.NoDecimals(_unitType);
            }
        }
        [Browsable(true)]
        public double MinValue
        {
            set
            {
                nudValueX.Minimum = (decimal)value;
                nudValueY.Minimum = (decimal)value;
            }
            get { return (double)nudValueX.Minimum; }
        }
        #endregion

        #region Override UserControl
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Unit = _unitType;
        }
        #endregion

        #region Event handlers
        private void OnValueChangedLocal(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {
            // set nud location
            nudValueX.Location = new Point(Width - 2 * UCtrlDualDouble.stNudLength - 2 - UCtrlDualDouble.stLbUnitLength, 0);
            nudValueY.Location = new Point(Width - UCtrlDualDouble.stNudLength - UCtrlDualDouble.stLbUnitLength, 0);
            // set unit location
            lbUnit.Location = new Point(Width - UCtrlDualDouble.stLbUnitLength + 1, 4);
        }
        #endregion

        #region Data members
        private UnitsManager.UnitType _unitType;
        public static int stNudLength = 60;
        public static int stLbUnitLength = 38;
        #endregion
    }
}
