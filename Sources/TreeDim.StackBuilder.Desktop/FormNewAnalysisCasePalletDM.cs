#region Using directives
using System;
using System.ComponentModel;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCasePalletDM : FormNewAnalysis, IDrawingContainer, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisCasePalletDM()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Properties.Resources.ID_ANALYSIS;
        #endregion

        #region FormNewAnalysis override
        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCases)
            {
                Packable packable = itemBase as Packable;
                return null != packable
                    && (
                    (packable is BProperties) ||
                    (packable is PackProperties) ||
                    (packable is LoadedCase)
                    );
            }
            else if (ctrl == cbPallets)
                return itemBase is PalletProperties;
            else
                return false;
        }
        #endregion

        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
        }
        #endregion

        #region Timer
        private void OnDataChanged(object sender, EventArgs e)
        {
            // stop timer
            _timer.Stop();
            // clear grid
            ClearGrid();
            // restart timer
            _timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                FillGrid();
            }
            catch (Exception /*ex*/)
            {
            }
        }
        #endregion
        #region Fill grid
        private void ClearGrid()
        {
        }
        private void FillGrid()
        {
        }
        #endregion

        #region Event handlers
        protected void OnCaseChanged(object sender, EventArgs e)
        {
            try
            {
                uCtrlCaseOrientation.BProperties = cbCases.SelectedType as PackableBrick;
                OnDataChanged(sender, e);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCasePalletDM));
        #endregion
    }
}
