#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewInterlayer : Form, IDrawingContainer
    {
        #region Data members
        private Document _document;
        private InterlayerProperties _interlayerProperties;
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewInterlayer));
        #endregion

        #region Constructor
        public FormNewInterlayer(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name / description
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_INTERLAYER);
            tbDescription.Text = tbName.Text;
            // initialize value
            InterlayerLength = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            InterlayerWidth = UnitsManager.ConvertLengthFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            Thickness = UnitsManager.ConvertLengthFrom(1.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            // disable Ok button
            UpdateButtonOkStatus();
        }
        public FormNewInterlayer(Document document, InterlayerProperties interlayerProperties)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _interlayerProperties = interlayerProperties;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _interlayerProperties.Name);
            // initialize value
            tbName.Text = _interlayerProperties.Name;
            tbDescription.Text = _interlayerProperties.Description;
            InterlayerLength = _interlayerProperties.Length;
            InterlayerWidth = _interlayerProperties.Width;
            Thickness = _interlayerProperties.Thickness;
            Weight = _interlayerProperties.Weight;
            this.Color = _interlayerProperties.Color;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // windows settings
            if (null != Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition.Restore(this);
            graphCtrl.Invalidate();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // window position
            if (null == Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition = new WindowSettings();
            Settings.Default.FormNewInterlayerPosition.Record(this);
        }
        #endregion

        #region Public properties
        public string InterlayerName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double InterlayerLength
        {
            get { return uCtrlDimensions.ValueX; }
            set { uCtrlDimensions.ValueX = value; }
        }
        public double InterlayerWidth
        {
            get { return uCtrlDimensions.ValueY; }
            set { uCtrlDimensions.ValueY = value; }
        }
        public double Thickness
        {
            get { return uCtrlDimensions.ValueZ; }
            set { uCtrlDimensions.ValueZ = value; }
        }
        public double Weight
        {
            get { return uCtrlWeight.Value; }
            set { uCtrlWeight.Value = value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion

        #region Handlers
        private void onInterlayerPropertyChanged(object sender, EventArgs e)
        {
            graphCtrl.Invalidate();
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _interlayerProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // button OK
            bnOk.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        { 
            InterlayerProperties interlayerProperties = new InterlayerProperties(
                null, tbName.Text, tbDescription.Text
                , InterlayerLength, InterlayerWidth
                , Thickness, Weight, Color);
            Box box = new Box(0, interlayerProperties);
            graphics.AddBox(box);
        }
        #endregion

        #region Send to database
        private void onSendToDatabase(object sender, EventArgs e)
        {
            try
            {
                FormSetItemName form = new FormSetItemName();
                form.ItemName = InterlayerName;
                if (DialogResult.OK == form.ShowDialog())
                {
                    PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
                    client.CreateNewInterlayer(new DCSBInterlayer()
                            {
                                Name = form.ItemName,
                                Description = Description,
                                UnitSystem = (int)UnitsManager.CurrentUnitSystem,
                                Dimensions = new DCSBDim3D() { M0 = InterlayerLength, M1 = InterlayerWidth, M2 = InterlayerWidth },
                                Weight = Weight,
                                Color = Color.ToArgb(),
                                AutoInsert = false
                            }
                        );
                    Close();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion
    }
}