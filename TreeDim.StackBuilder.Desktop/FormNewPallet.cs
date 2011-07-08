﻿#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;
using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPallet : Form
    {
        #region Data members
        [NonSerialized]private Document _document;
        [NonSerialized]private PalletProperties _palletProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPallet));
        #endregion

        #region Constructor
        public FormNewPallet(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;

            // initialize type combo
            for (int i = 0; i < 7; ++i)
                cbType.Items.Add(PalletProperties.PalletTypeNames[i]);
            cbType.SelectedIndex = 1;

            // initialize database pallet combo
            if (0 == cbPallet.Items.Count)
            {
                radioButtonPallet1.Checked = false;
                radioButtonPallet2.Checked = true;
            }
            // initialize data
            PalletLength = 1200;
            PalletWidth = 1000;
            PalletHeight = 150;
            Weight = 20;

            // select radio button
            radioButtonPallet1.Checked = false;
            radioButtonPallet2.Checked = true;
        }
        public FormNewPallet(Document document, PalletProperties palletProperties)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            _palletProperties = palletProperties;
            // initialize type combo
            for (int i = 0; i < 7; ++i)
                cbType.Items.Add(PalletProperties.PalletTypeNames[i]);
            cbType.SelectedIndex = 1;

            // initialize database pallet combo
            if (0 == cbPallet.Items.Count)
            {
                radioButtonPallet1.Checked = false;
                radioButtonPallet2.Checked = true;
            }
            // set caption text
            Text = string.Format("Edit {0}...", _palletProperties.Name);
            // initialize data
            tbName.Text = _palletProperties.Name;
            tbDescription.Text = _palletProperties.Description;
            PalletLength = _palletProperties.Length;
            PalletWidth = _palletProperties.Width;
            PalletHeight = _palletProperties.Height;
            Weight = _palletProperties.Weight;

            // select radio button
            radioButtonPallet1.Checked = false;
            radioButtonPallet2.Checked = true;
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
            DrawPallet();
            base.OnResize(e);
        }
        #endregion

        #region Public properties
        public string PalletName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }

        public double PalletLength
        {
            get { return System.Convert.ToDouble(nudLength.Text); }
            set { nudLength.Text = string.Format("{0:F}", value); }
        }

        public double PalletWidth
        {
            get { return System.Convert.ToDouble(nudWidth.Text); }
            set { nudWidth.Text = string.Format("{0:F}", value); }
        }

        public double PalletHeight
        {
            get { return System.Convert.ToDouble(nudHeight.Text); }
            set { nudHeight.Text = string.Format("{0:F}", value); }
        }

        public double Weight
        {
            get { return System.Convert.ToDouble(nudWeight.Text); }
            set { nudWeight.Text = string.Format("{0:F}", value); }
        }

        public Color Color
        {
            get { return cbColor.Color; }
        }

        public PalletProperties.PalletType PalletType
        {
            get { return (PalletProperties.PalletType)cbType.SelectedIndex; }
        }
        #endregion

        #region Draw pallet
        private void DrawPallet()
        {
            try
            {
                double angle = trackBarHorizAngle.Value;
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

                PalletProperties palletProperties = new PalletProperties(null, PalletType, PalletLength, PalletWidth, PalletHeight);
                palletProperties.Color = Color;
                Pallet pallet = new Pallet(palletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
                graphics.AddDimensions(new DimensionCube(PalletLength, PalletWidth, PalletHeight));
                graphics.Flush();
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Handlers
        private void onPalletPropertyChanged(object sender, EventArgs e)
        {
            DrawPallet();
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawPallet();
        }
        private void onPalletInsertionModeChanged(object sender, EventArgs e)
        {
            cbPallet.Enabled = radioButtonPallet1.Checked;
            tbPalletProperties.Enabled = radioButtonPallet1.Checked;

            lbName.Enabled = radioButtonPallet2.Checked;
            tbName.Enabled = radioButtonPallet2.Checked;
            lbDescription.Enabled = radioButtonPallet2.Checked;
            tbDescription.Enabled = radioButtonPallet2.Checked;
            lbType.Enabled = radioButtonPallet2.Checked;
            cbType.Enabled = radioButtonPallet2.Checked;
            lbColor.Enabled = radioButtonPallet2.Checked;
            cbColor.Enabled = radioButtonPallet2.Checked;
            lbLength.Enabled = radioButtonPallet2.Checked;
            nudLength.Enabled = radioButtonPallet2.Checked;
            lbWidth.Enabled = radioButtonPallet2.Checked;
            nudWidth.Enabled = radioButtonPallet2.Checked;
            lbHeight.Enabled = radioButtonPallet2.Checked;
            nudHeight.Enabled = radioButtonPallet2.Checked;
            lbWeight.Enabled = radioButtonPallet2.Checked;
            nudWeight.Enabled = radioButtonPallet2.Checked;
            lbMm1.Enabled = radioButtonPallet2.Checked;
            lbMm2.Enabled = radioButtonPallet2.Checked;
            lbMm3.Enabled = radioButtonPallet2.Checked;
            lbKg1.Enabled = radioButtonPallet2.Checked;
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _palletProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            //---
            // button OK
            bnAccept.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;

        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewPallet_Load(object sender, EventArgs e)
        {
            onPalletInsertionModeChanged(this, null);
            UpdateButtonOkStatus();

            // windows settings
            if (null != Settings.Default.FormNewPalletPosition)
                Settings.Default.FormNewPalletPosition.Restore(this);
            DrawPallet();
        }
        private void FormNewPallet_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewPalletPosition)
                Settings.Default.FormNewPalletPosition = new WindowSettings();
            Settings.Default.FormNewPalletPosition.Record(this); 
        }
        #endregion
    }
}