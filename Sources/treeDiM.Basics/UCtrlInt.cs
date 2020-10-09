#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace treeDiM.Basics
{
    public partial class UCtrlInt : UserControl
    {
        #region Delegates
        public delegate void ValueChangedDelegate(object sender, EventArgs e);
        #endregion

        #region Events
        public event ValueChangedDelegate ValueChanged;
        #endregion

        #region Constructor
        public UCtrlInt()
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
        public int Value
        {
            get { return (int)nudValue.Value; }
            set { try { nudValue.Value = value; } catch (ArgumentOutOfRangeException) { } }
        }
        [Browsable(true)]
        public decimal Minimum
        {
            get { return nudValue.Minimum; }
            set { nudValue.Minimum = value; }
        }
        [Browsable(true)]
        public decimal Maximum
        {
            get => nudValue.Maximum;
            set => nudValue.Maximum = value;
        }
        #endregion

        #region Event handlers
        private void OnValueChangedLocal(object sender, EventArgs e) => ValueChanged?.Invoke(this, e);
        private void OnSizeChanged(object sender, EventArgs e) => nudValue.Location = new Point(Width - stNudLength, 0);
        private void OnEnter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                nud.Select(0, nud.Text.Length);
                if (MouseButtons == MouseButtons.Left)
                    selectByMouse = true;
            }
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (selectByMouse && sender is NumericUpDown nud)
            {
                nud.Select(0, nud.Text.Length);
                selectByMouse = false;
            }
        }
        #endregion

        #region Data members
        private bool selectByMouse = false;
        public static int stNudLength = 60;
        #endregion


    }
}
