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
    public partial class FormNewBox : Form, IDrawingContainer
    {
        #region Mode enum
        public enum Mode
        { 
            MODE_BOX
            , MODE_CASE
        }
        #endregion

        #region Data members
        [NonSerialized]private Document _document;
        public Color[] _faceColors = new Color[6];
        public BoxProperties _boxProperties;
        public Mode _mode;
        public List<Pair<HalfAxis.HAxis, Texture>> _textures;
        private double _thicknessLength = 0.0, _thicknessWidth = 0.0, _thicknessHeight = 0.0;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBox));
        #endregion

        #region Constructor
        /// <summary>
        /// FormNewBox constructor used when defining a new BoxProperties item
        /// </summary>
        /// <param name="document">Document in which the BoxProperties item is to be created</param>
        /// <param name="mode">Mode is either Mode.MODE_CASE or Mode.MODE_BOX</param>
        public FormNewBox(Document document, Mode mode)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                // set unit labels
                UnitsManager.AdaptUnitLabels(this);
                // save document reference
                _document = document;
                // mode
                _mode = mode;

                switch (_mode)
                {
                    case Mode.MODE_CASE:
                        tbName.Text = _document.GetValidNewTypeName(Resources.ID_CASE);
                        uCtrlDimensionsOuter.ValueX = UnitsManager.ConvertLengthFrom(400.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsOuter.ValueY = UnitsManager.ConvertLengthFrom(300.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsOuter.ValueZ = UnitsManager.ConvertLengthFrom(200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsInner.Value = new Vector3D(
                            uCtrlDimensionsOuter.ValueX - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1),
                            uCtrlDimensionsOuter.ValueY - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1),
                            uCtrlDimensionsOuter.ValueZ - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1));
                        uCtrlDimensionsInner.Checked = false;
                        uCtrlTapeWidth.Value = new OptDouble(true, UnitsManager.ConvertLengthFrom(50, UnitsManager.UnitSystem.UNIT_METRIC1));
                        cbTapeColor.Color = Color.Beige;
                        break;
                    case Mode.MODE_BOX:
                        tbName.Text = _document.GetValidNewTypeName(Resources.ID_BOX);
                        uCtrlDimensionsOuter.ValueX = UnitsManager.ConvertLengthFrom(120.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsOuter.ValueY = UnitsManager.ConvertLengthFrom(60.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsOuter.ValueZ = UnitsManager.ConvertLengthFrom(30.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                        uCtrlDimensionsInner.Value = new Vector3D(
                            uCtrlDimensionsOuter.ValueX - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1),
                            uCtrlDimensionsOuter.ValueY - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1),
                            uCtrlDimensionsOuter.ValueZ - UnitsManager.ConvertLengthFrom(6.0, UnitsManager.UnitSystem.UNIT_METRIC1));
                        uCtrlDimensionsInner.Checked = false;
                        break;
                    default:
                        break;
                }
                // description (same as name)
                tbDescription.Text = tbName.Text;
                // color : all faces set together / face by face
                chkAllFaces.Checked = false;
                chkAllFaces_CheckedChanged(this, null);
                // set colors
                for (int i = 0; i < 6; ++i)
                    _faceColors[i] = _mode == Mode.MODE_BOX ? Color.Turquoise : Color.Chocolate;
                // set textures
                _textures = new List<Pair<HalfAxis.HAxis, Texture>>();
                // set default face
                cbFace.SelectedIndex = 0;
                // net weight
                NetWeight = new OptDouble(false, UnitsManager.ConvertMassFrom(0.0, UnitsManager.UnitSystem.UNIT_METRIC1));
                // disable Ok button
                UpdateButtonOkStatus();
            }
        }
        /// <summary>
        /// FormNewBox constructor used to edit existing boxes
        /// </summary>
        /// <param name="document">Document that contains the edited box</param>
        /// <param name="boxProperties">Edited box</param>
        public FormNewBox(Document document, BoxProperties boxProperties)
        { 
            InitializeComponent();
            if (!DesignMode)
            {
                // set unit labels
                UnitsManager.AdaptUnitLabels(this);
                // save document reference
                _document = document;
                _boxProperties = boxProperties;
                _mode = boxProperties.HasInsideDimensions ? Mode.MODE_CASE : Mode.MODE_BOX;
                // set colors
                for (int i = 0; i < 6; ++i)
                    _faceColors[i] = _boxProperties.Colors[i];
                // set textures
                _textures = _boxProperties.TextureListCopy;
                // set caption text
                Text = string.Format(Properties.Resources.ID_EDIT, _boxProperties.Name);
                // initialize value
                tbName.Text = _boxProperties.Name;
                tbDescription.Text = _boxProperties.Description;
                uCtrlDimensionsOuter.ValueX = _boxProperties.Length;
                uCtrlDimensionsOuter.ValueY = _boxProperties.Width;
                uCtrlDimensionsOuter.ValueZ = _boxProperties.Height;
                uCtrlDimensionsInner.Value = new Vector3D(_boxProperties.InsideLength, _boxProperties.InsideWidth, _boxProperties.InsideHeight);
                uCtrlDimensionsInner.Checked = _boxProperties.HasInsideDimensions;
                // weight
                vcWeight.Value = _boxProperties.Weight;
                // net weight
                uCtrlNetWeight.Value = _boxProperties.NetWeight;
                // color : all faces set together / face by face
                chkAllFaces.Checked = _boxProperties.UniqueColor;
                chkAllFaces_CheckedChanged(this, null);
                // tape
                uCtrlTapeWidth.Value = _boxProperties.TapeWidth;
                cbTapeColor.Color = _boxProperties.TapeColor;
                // set default face
                cbFace.SelectedIndex = 0;
                // disable Ok button
                UpdateButtonOkStatus();
            }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Name
        /// </summary>
        public string BoxName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        /// <summary>
        /// Length
        /// </summary>
        public double BoxLength
        {
            get { return uCtrlDimensionsOuter.ValueX; }
            set { uCtrlDimensionsOuter.ValueX = value; }
        }
        /// <summary>
        /// Width
        /// </summary>
        public double BoxWidth
        {
            get { return uCtrlDimensionsOuter.ValueY; }
            set { uCtrlDimensionsOuter.ValueY = value; }
        }
        /// <summary>
        /// Height
        /// </summary>
        public double BoxHeight
        {
            get { return uCtrlDimensionsOuter.ValueZ; }
            set { uCtrlDimensionsOuter.ValueZ = value; }
        }
        /// <summary>
        /// Inside length
        /// </summary>
        public double InsideLength
        {
            get { return uCtrlDimensionsInner.X; }
            set { uCtrlDimensionsInner.X = value; }
        }
        public bool HasInsideDimensions
        {
            get { return uCtrlDimensionsInner.Checked; }
            set { uCtrlDimensionsInner.Checked = false; }
        }
        /// <summary>
        /// Inside width
        /// </summary>
        public double InsideWidth
        {
            get { return uCtrlDimensionsInner.Y; }
            set { uCtrlDimensionsInner.Y = value; }
        }
        /// <summary>
        /// Inside height
        /// </summary>
        public double InsideHeight
        {
            get { return uCtrlDimensionsInner.Z; }
            set { uCtrlDimensionsInner.Z = value; }
        }
        /// <summary>
        /// Weight
        /// </summary>
        public double Weight
        {
            get { return vcWeight.Value; }
            set { vcWeight.Value = value; }
        }
        /// <summary>
        /// Colors
        /// </summary>
        public Color[] Colors
        {
            get { return _faceColors; }
            set { }
        }
        /// <summary>
        /// Textures
        /// </summary>
        public List<Pair<HalfAxis.HAxis, Texture>> TextureList
        {
            get {   return _textures;   }
            set
            {
                _textures.Clear();
                _textures.AddRange(value);
            }
        }
        /// <summary>
        /// Tape width
        /// </summary>
        public OptDouble TapeWidth
        {
            get { return uCtrlTapeWidth.Value; }
            set { uCtrlTapeWidth.Value = value; }
        }
        /// <summary>
        /// Tape color
        /// </summary>
        public Color TapeColor
        {
            get { return cbTapeColor.Color;}
            set { cbTapeColor.Color = value; }
        }
        #endregion

        #region Load / FormClosing event
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            graphCtrl.DrawingContainer = this;

            // show hide inside dimensions controls
            uCtrlDimensionsInner.Visible = _mode == Mode.MODE_CASE;

            gbTape.Visible = _mode == Mode.MODE_CASE;
            lbTapeColor.Visible = _mode == Mode.MODE_CASE;
            cbTapeColor.Visible = _mode == Mode.MODE_CASE;
            uCtrlTapeWidth.Visible = _mode == Mode.MODE_CASE;
            // caption
            this.Text = Mode.MODE_CASE == _mode ? Resources.ID_ADDNEWCASE : Resources.ID_ADDNEWBOX;
            // update thicknesses
            UpdateThicknesses();
            // update tape definition controls
            onTapeWidthChecked(this, null);
            // update box drawing
            graphCtrl.Invalidate();
            // windows settings
            if (null != Settings.Default.FormNewBoxPosition)
                Settings.Default.FormNewBoxPosition.Restore(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // window position
            if (null == Settings.Default.FormNewBoxPosition)
                Settings.Default.FormNewBoxPosition = new WindowSettings();
            Settings.Default.FormNewBoxPosition.Record(this);
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
 	         base.OnResize(e);
        }
        #endregion

        #region Handlers
        private void onBoxPropertyChanged(object sender, EventArgs e)
        {
            // maintain inside dimensions
            UCtrlTriDouble uCtrlDimOut = sender as UCtrlTriDouble;
            if (null != uCtrlDimOut && uCtrlDimensionsOuter == uCtrlDimOut)
            {
                InsideLength = BoxLength - _thicknessLength;
                InsideWidth = BoxWidth - _thicknessWidth;
                InsideHeight = BoxHeight - _thicknessHeight;
            }
            UCtrlOptTriDouble uCtrlDimIn = sender as UCtrlOptTriDouble;
            if (null != uCtrlDimIn && uCtrlDimensionsInner == uCtrlDimIn)
            {
                if ( BoxLength < InsideLength)
                    BoxLength = InsideLength + _thicknessLength;
                if ( BoxWidth < InsideWidth)
                    BoxWidth = InsideWidth + _thicknessWidth;
                if ( BoxHeight <= InsideHeight)
                    BoxHeight = InsideHeight + _thicknessHeight;       
            }
            uCtrlNetWeight.Enabled = !uCtrlDimensionsInner.Checked;

            // update thicknesses
            UpdateThicknesses();
            // update ok button status
            UpdateButtonOkStatus();
            // update box drawing
            graphCtrl.Invalidate();
        }

        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            // get current index
            int iSel = cbFace.SelectedIndex;
            cbColor.Color = _faceColors[iSel];
            graphCtrl.Invalidate();
        }
        private void onFaceColorChanged(object sender, EventArgs e)
        {
            if (!chkAllFaces.Checked)
            {
                int iSel = cbFace.SelectedIndex;
                if (iSel >=0 && iSel < 6)
                    _faceColors[iSel] = cbColor.Color;
            }
            else
            {
                for (int i = 0; i < 6; ++i)
                    _faceColors[i] = cbColor.Color;
            }
            graphCtrl.Invalidate();
        }

        private void UpdateButtonOkStatus()
        {
            // status + message
            string message = string.Empty;
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (!_document.IsValidNewTypeName(tbName.Text, _boxProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // case length consistency
            else if (_mode == Mode.MODE_CASE && InsideLength > BoxLength)
                message = string.Format(Resources.ID_INVALIDINSIDELENGTH, InsideLength, BoxLength);
            // case width consistency
            else if (_mode == Mode.MODE_CASE && InsideWidth > BoxWidth)
                message = string.Format(Resources.ID_INVALIDINSIDEWIDTH, InsideWidth, BoxWidth);
            // case height consistency
            else if (_mode == Mode.MODE_CASE && InsideHeight > BoxHeight)
                message = string.Format(Resources.ID_INVALIDINSIDEHEIGHT, InsideHeight, BoxHeight);
            // box/case net weight consistency
            else if (NetWeight.Activated && NetWeight > Weight)
                message = string.Format(Resources.ID_INVALIDNETWEIGHT, NetWeight.Value, Weight);
            // accept
            bnOK.Enabled = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }

        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }

        private void chkAllFaces_CheckedChanged(object sender, EventArgs e)
        {
            lbFace.Enabled = !chkAllFaces.Checked;
            cbFace.Enabled = !chkAllFaces.Checked;
            if (chkAllFaces.Checked)
                cbColor.Color = _faceColors[0];
        }
        private void btBitmaps_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditBitmaps form = null;
                if (null == _boxProperties)
                    form = new FormEditBitmaps(BoxLength, BoxWidth, BoxHeight, _faceColors);
                else
                    form = new FormEditBitmaps(_boxProperties);
                form.Textures = _textures;
                if (DialogResult.OK == form.ShowDialog())
                    _textures = form.Textures;
                graphCtrl.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onTapeWidthChecked(object sender, EventArgs e)
        {
            bool isActivated = uCtrlTapeWidth.Value.Activated;
            lbTapeColor.Enabled = isActivated;
            cbTapeColor.Enabled = isActivated;
            graphCtrl.Invalidate();
        }      
        #endregion

        #region Helpers
        private void UpdateThicknesses()
        {
            _thicknessLength = BoxLength - InsideLength;
            _thicknessWidth = BoxWidth - InsideWidth;
            _thicknessHeight = BoxHeight - InsideHeight;
        }
        #endregion

        #region Net weight
        public OptDouble NetWeight
        {
            get
            {
                if (HasInsideDimensions)
                    return new OptDouble(false, 0.0);
                else
                    return uCtrlNetWeight.Value; 
            }
            set { uCtrlNetWeight.Value = value; }
        }
        #endregion

        #region Draw box
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            BoxProperties boxProperties = new BoxProperties(null, uCtrlDimensionsOuter.ValueX, uCtrlDimensionsOuter.ValueY, uCtrlDimensionsOuter.ValueZ);
            boxProperties.SetAllColors(_faceColors);
            boxProperties.TextureList = _textures;
            boxProperties.TapeWidth = TapeWidth;
            boxProperties.TapeColor = TapeColor;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(uCtrlDimensionsOuter.ValueX, uCtrlDimensionsOuter.ValueY, uCtrlDimensionsOuter.ValueZ));
        }
        #endregion

        #region Save to database
        private void onSaveToDatabase(object sender, EventArgs e)
        {
            try
            {
                FormSetItemName form = new FormSetItemName()
                {
                    ItemName = BoxName
                };
                if (DialogResult.OK == form.ShowDialog())
                {
                    PLMPackServiceClient client = WCFClientSingleton.Instance.Client;

                    // colors
                    int[] colors = new int[6];
                    for (int i = 0; i < 6; ++i)
                        colors[i] = _faceColors[i].ToArgb();

                    client.CreateNewCase(new DCSBCase()
                            {
                                Name = form.ItemName,
                                Description = Description,
                                UnitSystem = (int)UnitsManager.CurrentUnitSystem,
                                IsCase = (_mode == Mode.MODE_CASE),
                                DimensionsOuter = new DCSBDim3D() { M0 = uCtrlDimensionsOuter.ValueX, M1 = uCtrlDimensionsOuter.ValueY, M2 = uCtrlDimensionsOuter.ValueZ },
                                HasInnerDims = HasInsideDimensions,
                                DimensionsInner = new DCSBDim3D() { M0 = uCtrlDimensionsInner.X, M1 = uCtrlDimensionsInner.Y, M2 = uCtrlDimensionsInner.Z },
                                ShowTape = TapeWidth.Activated,
                                TapeWidth = TapeWidth.Value,
                                TapeColor = TapeColor.ToArgb(),
                                Weight = Weight,
                                NetWeight = this.NetWeight.Activated ? this.NetWeight.Value : new Nullable<double>(),
                                Colors = colors,
                                AutoInsert = false
                            }
                        );
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