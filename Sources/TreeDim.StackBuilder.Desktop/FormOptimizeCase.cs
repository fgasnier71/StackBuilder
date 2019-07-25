#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
using log4net;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    /// <summary>
    /// This forms enables optimizing case dimensions
    /// </summary>
    public partial class FormOptimizeCase : Form, IDrawingContainer
    {
        #region Data members
        private DocumentSB _document;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormOptimizeCase));
        #endregion

        #region Combo box item private classes
        private class BoxItem
        {
            private BProperties _boxProperties;
            /// <summary>
            /// Constructor
            /// </summary>
            public BoxItem(BProperties boxProperties)
            {
                _boxProperties = boxProperties;
            }
            /// <summary>
            /// returns the inner item
            /// </summary>
            public BProperties Item
            {
                get { return _boxProperties; }
            }
            /// <summary>
            /// return the box name to be displayed by combo box
            /// </summary>
            public override string ToString()
            {
                return _boxProperties.Name;
            }
        }
        private class PalletItem
        {
            private PalletProperties _palletProperties;
            /// <summary>
            /// constructor
            /// </summary>
            public PalletItem(PalletProperties palletProperties)
            {
                _palletProperties = palletProperties;
            }
            /// <summary>
            /// returns the inner item
            /// </summary>
            public PalletProperties Item
            {
                get { return _palletProperties; }
            }
            /// <summary>
            /// returns the pallet name to be displayed by combo box
            /// </summary>
            public override string ToString()
            {
                return _palletProperties.Name;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// constructor takes document as argument
        /// </summary>
        public FormOptimizeCase(DocumentSB document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // document
            _document = document;

        }
        #endregion

        #region Load / Close methods
        private void FormOptimizeCase_Load(object sender, EventArgs e)
        {
            graphCtrlBoxesLayout.DrawingContainer = this;
            graphCtrlPallet.DrawingContainer = this;
            // intialize box combo
            foreach (BoxProperties bProperties in _document.Boxes)
                cbBoxes.Items.Add(new BoxItem(bProperties));
            if (cbBoxes.Items.Count > 0)
                cbBoxes.SelectedIndex = 0;
            // initialize pallet combo
            foreach (PalletProperties palletProperties in _document.Pallets)
                cbPallet.Items.Add(new PalletItem(palletProperties));
            if (cbPallet.Items.Count > 0)
                cbPallet.SelectedIndex = 0;
            // set default pallet height
            MaximumPalletHeight = Settings.Default.PalletHeight;
            // set default wall numbers and thickness
            uCtrlNoWalls.NoX = Settings.Default.NumberWallsLength;
            uCtrlNoWalls.NoY = Settings.Default.NumberWallsWidth;
            uCtrlNoWalls.NoZ = Settings.Default.NumberWallsHeight;
            uCtrlWallThickness.Value = Settings.Default.WallThickness;
            uCtrlSurfacicMass.Value = Settings.Default.WallSurfaceMass;
            nudNumber.Value = Settings.Default.NumberBoxesPerCase;
            // set vertical orientation only
            ForceVerticalBoxOrientation = Settings.Default.ForceVerticalBoxOrientation;
            // set min / max case dimensions
            SetMinCaseDimensions();
            SetMaxCaseDimensions();
            // set event handler for grid selection change event
            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(Selection_SelectionChanged);
            // fill grid
            FillGrid();

            UpdateButtonOptimizeStatus();
            UpdateButtonAddSolutionStatus();
            // windows settings
            if (null != Settings.Default.FormOptimizeCasePosition)
                Settings.Default.FormOptimizeCasePosition.Restore(this);
        }

        private void FormOptimizeCase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // save settings
                Settings.Default.NumberWallsLength = uCtrlNoWalls.NoX;
                Settings.Default.NumberWallsWidth  = uCtrlNoWalls.NoY;
                Settings.Default.NumberWallsHeight = uCtrlNoWalls.NoZ;
                Settings.Default.PalletHeight = MaximumPalletHeight;
                Settings.Default.WallThickness = uCtrlWallThickness.Value;
                Settings.Default.WallSurfaceMass = uCtrlSurfacicMass.Value;
                Settings.Default.NumberBoxesPerCase = (int)nudNumber.Value;
                // window position
                if (null == Settings.Default.FormOptimizeCasePosition)
                    Settings.Default.FormOptimizeCasePosition = new WindowSettings();
                Settings.Default.FormOptimizeCasePosition.Record(this);
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Status
        private void UpdateButtonOptimizeStatus()
        {
            string message = string.Empty;
            // compute maximum volume
            double maxVol = MaxLength * MaxWidth * MaxHeight;
            // compare max vol with volume of Number 
            if (MaxLength <= MinLength)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_LENGTH, Resources.ID_LENGTH);
            else if (MaxWidth <= MinWidth)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_WIDTH, Resources.ID_WIDTH);
            else if (MaxHeight <= MinHeight)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_HEIGHT, Resources.ID_HEIGHT);
            else if (maxVol < BoxPerCase * SelectedBox.Volume)
                message = string.Format(Resources.ID_INSUFFICIENTVOLUME, BoxPerCase, SelectedBox.Name);
            else if (MaximumPalletHeight < MinHeight + SelectedPallet.Height)
                message = string.Format(Resources.ID_INSUFFICIENTPALLETHEIGHT
                    , MaximumPalletHeight, UnitsManager.LengthUnitString
                    , MinHeight + SelectedPallet.Height, UnitsManager.LengthUnitString);
            // btOptimize
            btOptimize.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }

        private void UpdateButtonAddSolutionStatus()
        {
        }
        #endregion

        #region Event handlers
        private void OnSelectedBoxChanged(object sender, EventArgs e)
        {
            BoxItem boxItem = cbBoxes.SelectedItem as BoxItem;
            BProperties bProperties = boxItem?.Item;
            lbBoxDimensions.Text = null != bProperties ?
                string.Format("({0}*{1}*{2})", bProperties.Length, bProperties.Width, bProperties.Height)
                : string.Empty;
            OptimizationParameterChanged(sender, e);
            SetMinCaseDimensions();
        }
        private void OnSelectedPalletChanged(object sender, EventArgs e)
        {
            PalletItem palletItem = cbPallet.SelectedItem as PalletItem;
            PalletProperties palletProperties = palletItem?.Item;
            lbPalletDimensions.Text = null != palletProperties ?
                string.Format("({0}*{1}*{2})", palletProperties.Length, palletProperties.Width, palletProperties.Height)
                : string.Empty;
            OptimizationParameterChanged(sender, e);
            SetMaxCaseDimensions();
        }
        private void OnbuttonOptimize(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // fill grid using solutions
                FillGrid();
                UpdateButtonAddSolutionStatus();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void OnAddCasePalletAnalysis(object sender, EventArgs e)
        { 
           try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }            
        }
        private void OnAddPackPalletAnalysis(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnSetMinCaseDimensions(object sender, EventArgs e)
        {
            try { SetMinCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void OnSetMaxCaseDimensions(object sender, EventArgs e)
        {
            try { SetMaxCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        void Selection_SelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            // redraw
            graphCtrlBoxesLayout.Invalidate();
            graphCtrlPallet.Invalidate();
            // update "Add solution" button status
            UpdateButtonAddSolutionStatus();
        }
        private void OptimizationParameterChanged(object sender, EventArgs e)
        {
            // update optimize button status
            UpdateButtonOptimizeStatus();
            FillGrid();
        }
        #endregion

        #region Private properties
        private double OverhangX => uCtrlOverhang.ValueX;
        private double OverhangY => uCtrlOverhang.ValueY;
        private double MaxLength => uCtrlPackDimensionsMax.ValueX;
        private double MaxWidth => uCtrlPackDimensionsMax.ValueY;
        private double MaxHeight => uCtrlPackDimensionsMax.ValueZ;
        private double MinLength
        {
            get { return uCtrlPackDimensionsMin.ValueX; }
            set { uCtrlPackDimensionsMin.ValueX = value; }
        }
        private double MinWidth
        {
            get { return uCtrlPackDimensionsMin.ValueY; }
            set { uCtrlPackDimensionsMin.ValueY = value; }
        }
        private double MinHeight
        {
            get { return uCtrlPackDimensionsMin.ValueZ; }
            set { uCtrlPackDimensionsMin.ValueZ = value; }
        }
        private int BoxPerCase { get { return (int)nudNumber.Value; } }
        private int[] NoWalls
        {
            get
            {
                int[] noWalls = new int[3];
                noWalls[0] = uCtrlNoWalls.NoX;
                noWalls[1] = uCtrlNoWalls.NoY;
                noWalls[2] = uCtrlNoWalls.NoZ;
                return noWalls;
            }
        }
        private double WallThickness { get { return uCtrlWallThickness.Value; } }
        private double WallSurfaceMass { get { return uCtrlSurfacicMass.Value; } }

        private bool ForceVerticalBoxOrientation
        {
            get { return chkVerticalOrientationOnly.Checked; }
            set { chkVerticalOrientationOnly.Checked = value; }
        }
        private double MaximumPalletHeight
        {
            get { return uCtrlPalletHeight.Value; }
            set { uCtrlPalletHeight.Value = value; }
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
        }
        #endregion

        #region Drawing
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (ctrl == graphCtrlBoxesLayout)
            {
                // ### draw case definition
                try
                {
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                }
            }
            if (ctrl == graphCtrlPallet)
            {
                // ### draw associated pallet solution
                try
                {
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                }
            }
        }
        #endregion

        #region Helpers
        private BoxProperties SelectedBox
        {
            get
            {
                BoxItem boxItem = cbBoxes.SelectedItem as BoxItem;
                return null != boxItem ? boxItem.Item as BoxProperties : null;
            }
        }
        private PalletProperties SelectedPallet
        {
            get
            {
                PalletItem palletItem = cbPallet.SelectedItem as PalletItem;
                return palletItem != null ? palletItem.Item as PalletProperties : null;
            }
        }
        private int SelectedSolutionIndex
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Use box dimensions to set min case dimensions
        /// </summary>
        private void SetMinCaseDimensions()
        {
            // get selected box
            BProperties boxProperties = SelectedBox;
            if (null == boxProperties) return;
            // compute min dimension
            double minDim = Math.Min(boxProperties.Length, Math.Min(boxProperties.Width, boxProperties.Height));
            if ((int)nudNumber.Value > 8)
                minDim *= 2;
            // set min dimension
            MinLength = minDim;
            MinWidth = minDim;
            MinHeight = minDim;

            // update message + enable/disable optimise button
            UpdateButtonOptimizeStatus();
        }
        private void SetMaxCaseDimensions()
        {
            PalletProperties palletProperties = SelectedPallet;
            if (null == palletProperties) return;
            // use pallet dimensions to set max case dimensions
            uCtrlPackDimensionsMax.ValueX = palletProperties.Length * 0.5;
            uCtrlPackDimensionsMax.ValueY = palletProperties.Width * 0.5;
            uCtrlPackDimensionsMax.ValueZ = MaximumPalletHeight * 0.5;
            // update message + enable/disable optimise button
            UpdateButtonOptimizeStatus();
        }
        private ParamSetPackOptim BuildCaseOptimConstraintSet()
        {
            return new ParamSetPackOptim(
                    (int)nudNumber.Value
                    , new Vector3D(MinLength, MinWidth, MinHeight)
                    , new Vector3D(MaxLength, MaxWidth, MaxHeight)
                    , ForceVerticalBoxOrientation
                    , PackWrapper.WType.WT_POLYETHILENE
                    , NoWalls
                    , WallThickness, WallSurfaceMass
                    , 0.0
                    );
        }
        #endregion
    }
}
