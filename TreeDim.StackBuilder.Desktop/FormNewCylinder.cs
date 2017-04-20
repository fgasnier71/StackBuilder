#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewCylinder : Form, IDrawingContainer
    {
        #region Data members
        [NonSerialized]
        private Document _document;
        public CylinderProperties _cylProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBox));
        #endregion

        #region Constructors
        public FormNewCylinder(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name / description
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_CYLINDER);
            tbDescription.Text = tbName.Text;
            // properties
            uCtrlDiameterOuter.Value = UnitsManager.ConvertLengthFrom(2.0*75.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            uCtrlDiameterInner.Value = UnitsManager.ConvertLengthFrom(0.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            uCtrlHeight.Value = UnitsManager.ConvertLengthFrom(150.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            uCtrlWeight.Value = UnitsManager.ConvertMassFrom(1.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            cbColorWallOuter.Color = System.Drawing.Color.LightSkyBlue;
            cbColorWallInner.Color = System.Drawing.Color.Chocolate;
            cbColorTop.Color = System.Drawing.Color.Gray;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        public FormNewCylinder(Document document, CylinderProperties cylinder)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _cylProperties = cylinder;
            // properties
            tbName.Text = cylinder.Name;
            tbDescription.Text = cylinder.Description;
            uCtrlDiameterOuter.Value = 2.0 * cylinder.RadiusOuter;
            uCtrlDiameterInner.Value = 2.0 * cylinder.RadiusInner;
            uCtrlHeight.Value = cylinder.Height;
            uCtrlWeight.Value = cylinder.Weight;
            cbColorWallOuter.Color = cylinder.ColorWallOuter;
            cbColorWallInner.Color = cylinder.ColorWallInner;
            cbColorTop.Color = cylinder.ColorTop;
            // disable Ok button
            UpdateButtonOkStatus();        
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.DrawingContainer = this;
        }
        #endregion

        #region Public properties
        public string CylinderName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double RadiusOuter
        {
            get { return 0.5 * uCtrlDiameterOuter.Value; }
            set { uCtrlDiameterOuter.Value = 2.0 * value; }
        }
        public double RadiusInner
        {
            get { return 0.5 * uCtrlDiameterInner.Value; }
            set { uCtrlDiameterInner.Value = 2.0 * value; }
        }
        public double CylinderHeight
        {
            get { return uCtrlHeight.Value; }
            set { uCtrlHeight.Value = value; }
        }
        public double Weight
        {
            get { return uCtrlWeight.Value; }
            set { uCtrlWeight.Value = value; }
        }
        public OptDouble NetWeight
        {
            get { return uCtrlNetWeight.Value; }
            set { uCtrlNetWeight.Value = value; }
        }
        public Color ColorTop
        {
            get { return cbColorTop.Color; }
            set { cbColorTop.Color = value; }
        }
        public Color ColorWallOuter
        {
            get { return cbColorWallOuter.Color; }
            set { cbColorWallOuter.Color = value; }
        }
        public Color ColorWallInner
        {
            get { return cbColorWallInner.Color; }
            set { cbColorWallInner.Color = value; }
        }
        #endregion

        #region Handlers
        private void onCylinderPropertiesChanged(object sender, EventArgs e)
        {
            // update ok button status
            UpdateButtonOkStatus();
            // update cylinder drawing
            graphCtrl.Invalidate();
        }

        private void UpdateButtonOkStatus()
        {
            // status + message
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _cylProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            else if (RadiusInner > RadiusOuter)
                message = Resources.ID_INVALIDDIAMETER;
            else if (Weight < 1.0E-06)
                message = Resources.ID_INVALIDMASS;
            // accept
            bnOK.Enabled = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion

        #region Draw cylinder
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            CylinderProperties cylProperties = new CylinderProperties(
                null, CylinderName, Description
                , RadiusOuter, RadiusInner, CylinderHeight, Weight
                , ColorTop, ColorWallOuter, ColorWallInner);
            Cylinder cyl = new Cylinder(0, cylProperties);
            graphics.AddCylinder(cyl);
        }
        #endregion

        #region Send to database
        private void onSendToDatabase(object sender, EventArgs e)
        {
            try
            {
                FormSetItemName form = new FormSetItemName();
                form.ItemName = CylinderName;
                if (DialogResult.OK == form.ShowDialog())
                {
                    PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
                    client.CreateNewCylinder(new DCSBCylinder()
                            {
                                Name = form.ItemName,
                                Description = Description,
                                UnitSystem = (int)UnitsManager.CurrentUnitSystem,
                                RadiusOuter = RadiusOuter,
                                RadiusInner = RadiusInner,
                                Height = Height,
                                Weight = Weight,
                                NetWeight = this.NetWeight.Activated ? this.NetWeight.Value : new Nullable<double>(),
                                ColorOuter = ColorWallOuter.ToArgb(),
                                ColorInner = ColorWallInner.ToArgb(),
                                ColorTop = ColorTop.ToArgb(),
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
