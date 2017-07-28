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
    public partial class FormNewBundle : Form, IDrawingContainer
    {
        #region Data members
        private Document _document;
        private BundleProperties _bundleProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBundle));
        #endregion

        #region Constructor
        public FormNewBundle(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_BUNDLE);
            tbDescription.Text = tbName.Text;
            // initialize value
            BundleLength = UnitsManager.ConvertLengthFrom(400.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            BundleWidth = UnitsManager.ConvertLengthFrom(300.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            UnitThickness = UnitsManager.ConvertLengthFrom(5.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            NoFlats = 10;
            // disable Ok buttons
            UpdateButtonOkStatus();
        }
        public FormNewBundle(Document document, BundleProperties bundleProperties)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _bundleProperties = bundleProperties;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _bundleProperties.Name);
            // initialize value
            tbName.Text = bundleProperties.Name;
            tbDescription.Text = bundleProperties.Description;
            BundleLength = bundleProperties.Length;
            BundleWidth = bundleProperties.Width;
            UnitThickness = bundleProperties.UnitThickness;
            UnitWeight = bundleProperties.UnitWeight;
            NoFlats = bundleProperties.NoFlats;
            // disable Ok buttons
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event handlers
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);
            graphCtrl.DrawingContainer = this;
            // windows settings
            if (null != Settings.Default.FormNewBundlePosition)
                Settings.Default.FormNewBundlePosition.Restore(this);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // window position
            if (null == Settings.Default.FormNewBundlePosition)
                Settings.Default.FormNewBundlePosition = new WindowSettings();
            Settings.Default.FormNewBundlePosition.Record(this);
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
            graphCtrl.Invalidate();
            base.OnResize(e);
        }
        #endregion

        #region Public properties
        public string BundleName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double BundleLength
        {
            get { return uCtrlLength.Value; }
            set { uCtrlLength.Value = value; }
        }
        public double BundleWidth
        {
            get { return uCtrlWidth.Value; }
            set { uCtrlWidth.Value = value; }
        }
        public double UnitThickness
        {
            get { return uCtrlThickness.Value; }
            set { uCtrlThickness.Value = value; }
        }
        public double UnitWeight
        {
            get { return uCtrlWeight.Value; }
            set { uCtrlWeight.Value = value; }
        }
        public int NoFlats
        {
            get { return (int)nudNoFlats.Value; }
            set { nudNoFlats.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value;}
        }
        #endregion

        #region Handlers
        private void onBundlePropertyChanged(object sender, EventArgs e)
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
            else if (!_document.IsValidNewTypeName(tbName.Text, _bundleProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // ---
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
            BundleProperties bundleProperties = new BundleProperties(
                null, BundleName, Description
                , BundleLength, BundleWidth, UnitThickness, UnitWeight, NoFlats, Color);
            Box box = new Box(0, bundleProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(BundleLength, BundleWidth, UnitThickness * NoFlats));
        }
        #endregion

        #region Send to database
        private void onSendToDatabase(object sender, EventArgs e)
        {
            try
            {
                FormSetItemName form = new FormSetItemName()
                {
                    ItemName = BundleName
                };
                if (DialogResult.OK == form.ShowDialog())
                {
                    PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
                    client.CreateNewBundle( new DCSBBundle()
                        {
                            Name = form.ItemName,
                            Description = Description,
                            UnitSystem = (int)UnitsManager.CurrentUnitSystem,
                            DimensionsUnit = new DCSBDim3D() { M0=BundleLength, M1=BundleWidth, M2=UnitThickness},
                            Number = NoFlats,
                            UnitWeight = UnitWeight,
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