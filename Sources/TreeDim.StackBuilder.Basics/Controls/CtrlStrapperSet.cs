#region Using directives
using System;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Basics.Controls
{
    public partial class CtrlStrapperSet : UserControl
    {
        #region Constructor
        public CtrlStrapperSet()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public StrapperSet StrapperSet
        {
            get
            {
                return strapperSet;
            }
            set
            {
                strapperSet = value;
                InitializeStrapper();
            }
        }
        public int Dir => cbDir.SelectedIndex;
        public bool EvenlySpaced
        {
            get => true;
        }
        public int Number
        {
            get => uCtrlNumber.Value;
            set => uCtrlNumber.Value = value;
        }
        #endregion

        #region Event
        public delegate void OnValueChanged(object sender, EventArgs e);
        public event OnValueChanged ValueChanged;
        #endregion

        #region Handlers
        private void OnDirectionChanged(object sender, EventArgs e)
        {
            if (DesignMode || null == StrapperSet) return;
            PreventUpdate = true;
            uCtrlNumber.Value = StrapperSet.Number[Dir];
            InitializeSpacing();
            PreventUpdate = false;
        }
        private void OnNumberChanged(object sender, EventArgs e)
        {
            if (DesignMode || null == StrapperSet) return;
            if (!PreventUpdate)
            {
                StrapperSet.SetNumber(Dir, uCtrlNumber.Value);
                InitializeSpacing();
            }
            ValueChanged?.Invoke(this, e);
        }
        private void OnStrapperChanged(object sender, EventArgs e)
        {
            if (!PreventUpdate)
            {
                StrapperSet.Color = cbColor.Color;
                StrapperSet.Width = uCtrlWidth.Value;
                StrapperSet.SetEvenlySpaced(Dir, Number, uCtrlSpacing.Value);
            }
            ValueChanged?.Invoke(this, e);
        }
        private void OnEditAbscissa(object sender, EventArgs e)
        {
            // show dialog
            FormValueArray form = new FormValueArray(StrapperSet.ActualAbscissa(Dir));
            form.ShowDialog();
            StrapperSet.SetUnevenlySpaced(Dir, form.ValueArray);
            // strapper changed
            OnStrapperChanged(sender, e);
        }
        #endregion

        #region Helpers
        private void InitializeStrapper()
        {
            if (DesignMode || null == StrapperSet) return;
            cbDir.SelectedIndex = 0;
            PreventUpdate = true;
            cbColor.Color = StrapperSet.Color;
            uCtrlWidth.Value = StrapperSet.Width;
            PreventUpdate = false;
        }
        private void InitializeSpacing()
        {
            if (DesignMode || null == StrapperSet) return;
            PreventUpdate = true;
            bool enableSpacing = StrapperSet.Number[Dir] >= 2;
            uCtrlSpacing.Enabled = enableSpacing;
            uCtrlSpacing.Value = StrapperSet.GetSpacing(Dir).Value;
            PreventUpdate = false;
        }
        #endregion

        #region Data members
        private StrapperSet strapperSet;
        private bool PreventUpdate { get; set; }
        #endregion
    }
}
