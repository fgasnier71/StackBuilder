#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.Basics
{
    public partial class UCtrlTriDouble : UserControl
    {
        #region Delegates
        public delegate void ValueChangedDelegate(object sender, EventArgs args);
        #endregion

        #region Events
        [Browsable(true)]
        public event ValueChangedDelegate ValueChanged;
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
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Vector3D Value
        {
            get { return new Vector3D(ValueX, ValueY, ValueZ); }
            set
            {
                SkipInvoke = true;
                try { ValueX = value.X; ValueY = value.Y; ValueZ = value.Z; }
                catch (ArgumentOutOfRangeException) { }
                finally { SkipInvoke = false; }
            }
        }
        [Browsable(true)]
        public double ValueX
        {
            get { return (double)nudValueX.Value; }
            set { try { nudValueX.Value = (decimal)value; } catch (ArgumentOutOfRangeException) {} }
        }
        [Browsable(true)]
        public double ValueY
        {
            get { return (double)nudValueY.Value; }
            set { try { nudValueY.Value = (decimal)value; } catch (ArgumentOutOfRangeException) {} }
        }
        [Browsable(true)]
        public double ValueZ
        {
            get { return (double)nudValueZ.Value; }
            set { try { nudValueZ.Value = (decimal)value; } catch (ArgumentOutOfRangeException) {} }
        }
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
        private void OnValueChangedLocal(object sender, EventArgs e)
        {
            if (!SkipInvoke)
                ValueChanged?.Invoke(this, e);
        }
        private void OnSizeChanged(object sender, EventArgs e)
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
        private bool SkipInvoke = false;
        #endregion
    }
}
