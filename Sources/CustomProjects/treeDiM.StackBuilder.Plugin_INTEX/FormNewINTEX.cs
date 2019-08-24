#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using log4net;

using treeDiM.Basics;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public partial class FormNewINTEX : Form
    {
        #region Constructor
        public FormNewINTEX()
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region Event handlers
        private void OnCbDescriptionSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentItem = (DataItemINTEX)cbRefDescription.SelectedItem;
            if (null == _currentItem)
                return;
            tbUPC.Text = _currentItem._UPC;
            tbGenCode.Text = _currentItem._gencode;
            uCtrlTriDimensions.ValueX = _currentItem._length;
            uCtrlTriDimensions.ValueY = _currentItem._width;
            uCtrlTriDimensions.ValueZ = _currentItem._height;
            uCtrlWeight.Value = _currentItem._weight;

            uCtrlTriDimensions.Enabled = false;
            uCtrlWeight.Enabled = false;

            // set output file path
            fileSelectCtrl.FileName = BuildFilePath(_currentItem._ref);
            // update pallet height if necessary
            UpdatePalletHeight();
            UpdateButtonOkStatus();
        }
        private void OnCbPalletSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPallet = (DataPalletINTEX)cbPallet.SelectedItem;
            // update pallet height if necessary
            UpdatePalletHeight();
            UpdateButtonOkStatus();
        }
        private void OnCbCasesSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCase = (DataCaseINTEX)cbCases.SelectedItem;
            UpdateButtonOkStatus();
        }
        private void OnChkbUseIntermediatePackingCheckedChanged(object sender, EventArgs e)
        {
            lbCase.Enabled = chkUseIntermediatePacking.Checked;
            cbCases.Enabled = chkUseIntermediatePacking.Checked;
            uCtrlThickness.Enabled = chkUseIntermediatePacking.Checked;
            // update status and enable/disable OK button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Form Loading & Closing
        //private void FormNewINTEX_Load(object sender, EventArgs e)
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                foreach (DataItemINTEX item in ListItems)
                    cbRefDescription.Items.Add(item);
                if (cbRefDescription.Items.Count > 0)
                    cbRefDescription.SelectedIndex = 0;

                foreach (DataPalletINTEX pallet in ListPallets)
                    cbPallet.Items.Add(pallet);
                if (cbPallet.Items.Count > 0)
                    cbPallet.SelectedIndex = 0;

                foreach (DataCaseINTEX interCase in ListCases)
                    cbCases.Items.Add(interCase);
                if (cbCases.Items.Count > 0)
                    cbCases.SelectedIndex = 0;

                // initialize pallet height
                PalletHeight = Properties.Settings.Default.PalletHeight;
                // initialize intermediate packing
                chkUseIntermediatePacking.Checked = ListCases.Count > 0 && Properties.Settings.Default.IntermediatePacking;
                chkUseIntermediatePacking.Enabled = ListCases.Count > 0;
                OnChkbUseIntermediatePackingCheckedChanged(null, null);
                // initialize thickness
                DefaultCaseThickness = Properties.Settings.Default.DefaultCaseThickness;
                // update status and enable/disable OK button
                UpdateButtonOkStatus();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Properties.Settings.Default.IntermediatePacking = UseIntermediatePacking;
            Properties.Settings.Default.DefaultCaseThickness = DefaultCaseThickness;
            Properties.Settings.Default.PalletHeight = PalletHeight;
            Properties.Settings.Default.Save();
        } 
        #endregion

        #region Update status
        private void UpdatePalletHeight()
        { 
            // set minimal pallet height
            if (null != _currentPallet && null != _currentItem)
            {
                uCtrlPalletHeight.Minimum = (decimal)(_currentPallet._height + _currentItem._height);

                if (PalletHeight < (double)uCtrlPalletHeight.Minimum)
                    PalletHeight = (double)uCtrlPalletHeight.Minimum;
            }
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            if (null != _currentPallet)
            {
                if (UseIntermediatePacking && (null != _currentCase))
                {
                    if (_currentCase._heightExt + _currentPallet._height > PalletHeight)
                        message = Properties.Resources.ID_PALLETHEIGHTINSUFFICIENT;
                }
                else if (!UseIntermediatePacking && (null != _currentItem))
                {
                    if (_currentItem._height + _currentPallet._height > PalletHeight)
                        message = Properties.Resources.ID_PALLETHEIGHTINSUFFICIENT;
                }
            }
            if (UseIntermediatePacking && null != _currentCase && null != _currentItem)
            {
                if (!_currentCase.CanContain(_currentItem, DefaultCaseThickness))
                    message = string.Format(Properties.Resources.ID_CASECANNOTCONTAINITEM
                        , _currentCase._ref, _currentItem._ref);
            }
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Properties.Resources.ID_READY : message;
            bnOK.Enabled = string.IsNullOrEmpty(message);
        }
        #endregion

        #region Public properties
        public bool UseIntermediatePacking
        {
            get { return chkUseIntermediatePacking.Checked; }
            set { chkUseIntermediatePacking.Checked = value; }
        }
        public string FilePath
        {
            get { return fileSelectCtrl.FileName; }
        }
        public double PalletHeight
        {
            get { return uCtrlPalletHeight.Value; }
            set { uCtrlPalletHeight.Value = value; }
        }
        public double DefaultCaseThickness
        {
            get { return uCtrlThickness.Value; }
            set { uCtrlThickness.Value = value; }
        }

        public List<DataCaseINTEX> ListCases { get; set; }
        public List<DataItemINTEX> ListItems { get; set; }
        public List<DataPalletINTEX> ListPallets { get; set; }
        #endregion

        #region Helpers
        private string BuildFilePath(string sRef)
        {
            string defaultDir = Properties.Settings.Default.DefaultDir;
            if (!System.IO.Directory.Exists(defaultDir))
                defaultDir = System.IO.Path.GetTempPath();

            string filePath = System.IO.Path.Combine(defaultDir, sRef);
            return System.IO.Path.ChangeExtension(filePath, "stb");
        }

        #endregion
        #region Data members
        public DataItemINTEX _currentItem;
        public DataPalletINTEX _currentPallet;
        public DataCaseINTEX _currentCase;

        private static ILog _log = LogManager.GetLogger(typeof(FormNewINTEX));
        #endregion
    }
}
