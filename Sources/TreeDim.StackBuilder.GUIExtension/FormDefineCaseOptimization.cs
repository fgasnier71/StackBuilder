#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.GUIExtension.Properties;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class FormDefineCaseOptimization : Form, IDrawingContainer
    {
        #region Data members
        private Document _doc;
        private List<AnalysisHomo> _analyses = new List<AnalysisHomo>();
        private AnalysisHomo _selectedAnalysis;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormDefineCaseOptimization));
        #endregion

        #region Constructor
        public FormDefineCaseOptimization()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // grid font size
            GridFontSize = Settings.Default.GridFontSize;
            // initialize combo boxes
            cbPallet.Initialize();
            // initialize graph containers
            graphCtrlPack.DrawingContainer = this;
            graphCtrlSolution.DrawingContainer = this;
            // set default pallet height
            MaximumPalletHeight = Settings.Default.PalletHeight;
            // set default wall numbers and thickness
            uCtrlNoWalls.NoX = Settings.Default.NumberWallsLength;
            uCtrlNoWalls.NoY = Settings.Default.NumberWallsWidth;
            uCtrlNoWalls.NoZ = Settings.Default.NumberWallsHeight;
            uCtrlWallThickness.Value = Settings.Default.WallThickness;
            uCtrlSurfacicMass.Value = Settings.Default.WallSurfaceMass;

            // set default number of boxes
            nudNumber.Value = Settings.Default.NumberBoxesPerCase;
            // set default wrapper type
            cbWrapperType.SelectedIndex = Settings.Default.WrapperType;
            // initialize grid
            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);

            UpdateStatus(string.Empty);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
 	        base.OnClosing(e);
            try
            {
                // save setings
                Settings.Default.NumberWallsLength = uCtrlNoWalls.NoX;
                Settings.Default.NumberWallsWidth = uCtrlNoWalls.NoY;
                Settings.Default.NumberWallsHeight = uCtrlNoWalls.NoZ;
                Settings.Default.MaximumPalletHeight = MaximumPalletHeight;
                Settings.Default.WallThickness = WallThickness;
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Status toolstrip updating
        public virtual void UpdateStatus(string message)
        {
            if (null == SelectedAnalysis)
                message = Resources.ID_ANALYSISHASNOVALIDSOLUTION;

            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion

        #region Public properties
        public string BoxName { get; set; }
        public double BoxLength
        {
            get { return uCtrlDimensionsBox.ValueX; }
            set { uCtrlDimensionsBox.ValueX = value; }
        }
        public double BoxWidth
        {
            get { return uCtrlDimensionsBox.ValueY; }
            set { uCtrlDimensionsBox.ValueY = value; }
        }
        public double BoxHeight
        {
            get { return uCtrlDimensionsBox.ValueZ; }
            set { uCtrlDimensionsBox.ValueZ = value; }
        }
        public string AnalysisName
        { get { return string.Format("Analysis {0}", BoxName); } }
        public string AnalysisDescription
        { get { return string.Format("{0} on {1}", BoxName, SelectedPallet.Name); } }
        #endregion

        #region Private properties
        private BoxProperties SelectedBox
        {
            get
            {
                BoxProperties bProperties = new BoxProperties(null, uCtrlDimensionsBox.ValueX, uCtrlDimensionsBox.ValueY, uCtrlDimensionsBox.ValueZ);
                bProperties.ID.SetNameDesc(BoxName, BoxName);
                Color[] colors = new Color[6];
                for (int i = 0; i < 6; ++i) colors[i] = Color.Turquoise;
                bProperties.SetAllColors(colors);
                return bProperties;
            } 
        }
        private PalletProperties SelectedPallet
        { get { return cbPallet.SelectedType as PalletProperties; } }
        private AnalysisCasePallet SelectedAnalysis
        { get { return _selectedAnalysis as AnalysisCasePallet; } }
        private double OverhangX { get { return uCtrlOverhang.ValueX; } }
        private double OverhangY { get { return uCtrlOverhang.ValueY; } }
        private Vector2D Overhang { get { return new Vector2D(uCtrlOverhang.ValueX, uCtrlOverhang.ValueY); } }
        private Vector3D DimensionsMin
        { get { return new Vector3D(uCtrlPackDimensionsMin.ValueX, uCtrlPackDimensionsMin.ValueY, uCtrlPackDimensionsMin.ValueZ); } }
        private Vector3D DimensionsMax
        { get { return new Vector3D(uCtrlPackDimensionsMax.ValueX, uCtrlPackDimensionsMax.ValueY, uCtrlPackDimensionsMax.ValueZ); } }
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

        #region Event handlers
        private void OnWrapperTypeChanged(object sender, EventArgs e)
        {
            // show tray height control
            uCtrlTrayHeight.Visible = (3 == cbWrapperType.SelectedIndex);
            OnDataChanged(sender, e);
        }
        private void OnBoxChanged(object sender, EventArgs e)
        {
            SetMinCaseDimensions();
            OnDataChanged(sender, e);
        }
        private void OnPalletChanged(object sender, EventArgs e)
        {
            SetMaxCaseDimensions();
            OnDataChanged(sender, e);
        }
        private void OnDataChanged(object sender, EventArgs e)
        {
            // stop timer
            _timer.Stop();
            // clear grid
            _analyses.Clear();
            FillGrid();
            // restart timer
            _timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                // instantiate document
                _doc = new Document(BoxName, BoxName, "", DateTime.Now, null);
                // recompute optimisation
                PackOptimizer packOptimizer = new PackOptimizer(
                    SelectedBox, SelectedPallet,
                    BuildParamSetPackOptim(),
                    cbColor.Color
                    );
                _analyses = packOptimizer.BuildAnalyses(BuildConstraintSet(), allowMultipleLayerOrientations: true);
                // refill solution grid
                FillGrid();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onSelChangeGrid(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            try
            {
                SourceGrid.Selection.RowSelection select = sender as SourceGrid.Selection.RowSelection;
                SourceGrid.Grid g = select.Grid as SourceGrid.Grid;

                SourceGrid.RangeRegion region = g.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                if (indexes.Length < 1 || indexes[0] < 1)
                    _selectedAnalysis = null;
                else
                {
                    _selectedAnalysis = _analyses[indexes[0] - 1];
                    // analysis name/description
                    if (null != _selectedAnalysis)
                    {
                        BoxProperties box = SelectedBox;
                        PackProperties pack = _selectedAnalysis.Content as PackProperties;
                        UpdateStatus(string.Empty);
                    }
                }

                graphCtrlPack.Invalidate();
                graphCtrlSolution.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onNext(object sender, EventArgs e)
        {
            try
            {
                // selected analysis -> get pack
                AnalysisCasePallet analysisSel = SelectedAnalysis;
                PackProperties packSel = analysisSel.Content as PackProperties;
                packSel.ID.SetNameDesc(AnalysisName, AnalysisName);

                // create pack
                PackProperties packProperties = _doc.CreateNewPack(packSel);
                PalletProperties palletProperties = _doc.CreateNewPallet(SelectedPallet);
                // create analysis
                List<InterlayerProperties> interlayers = new List<InterlayerProperties>();
                AnalysisHomo analysis = _doc.CreateNewAnalysisCasePallet(
                    AnalysisName, AnalysisDescription,
                    packProperties, palletProperties,
                    interlayers, null, null, null,
                    BuildConstraintSet(), analysisSel.Solution.LayerDescriptors);
                FormBrowseSolution form = new FormBrowseSolution(_doc, analysis);
                if (DialogResult.OK == form.ShowDialog()) { }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btSetMinimum_Click(object sender, EventArgs e)
        {
            try { SetMinCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void btSetMaximum_Click(object sender, EventArgs e)
        {
            try { SetMaxCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Helpers
        private int SelectedSolutionIndex
        {
            get
            {
                SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0) return -1;
                // return index
                return indexes[0] - 1;
            }
        }
        /// <summary>
        /// Use box dimensions to set min case dimensions
        /// </summary>
        private void SetMinCaseDimensions()
        {
            BoxProperties boxProperties = SelectedBox;
            if (null == boxProperties) return;
            double minDim = Math.Min(boxProperties.Length, Math.Min(boxProperties.Width, boxProperties.Height));
            if ((int)nudNumber.Value > 8)
                minDim *= 2;
            // set min dimension
            uCtrlPackDimensionsMin.ValueX = minDim;
            uCtrlPackDimensionsMin.ValueY = minDim;
            uCtrlPackDimensionsMin.ValueZ = minDim;
        }
        private void SetMaxCaseDimensions()
        {
            PalletProperties palletProperties = SelectedPallet;
            if (null == palletProperties) return;
            if (MaximumPalletHeight <= palletProperties.Height)
                MaximumPalletHeight = palletProperties.Height;

            double length = 0.5 * palletProperties.Length;
            uCtrlPackDimensionsMax.ValueX = length;
            uCtrlPackDimensionsMax.ValueY = length;
            uCtrlPackDimensionsMax.ValueZ = length;
        }
        private ParamSetPackOptim BuildParamSetPackOptim()
        {
            return new ParamSetPackOptim(
                BoxPerCase,
                DimensionsMin,
                DimensionsMax,
                ForceVerticalBoxOrientation,
                (PackWrapper.WType)cbWrapperType.SelectedIndex,
                NoWalls, WallThickness,
                WallSurfaceMass,
                uCtrlTrayHeight.Value);
        }
        private ConstraintSetCasePallet BuildConstraintSet()
        {
            ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
            constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
            constraintSet.SetMaxHeight(new OptDouble(true, MaximumPalletHeight));
            constraintSet.Overhang = Overhang;
            return constraintSet;
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == SelectedAnalysis)
                return;
            try
            {
                AnalysisCasePallet analysis = SelectedAnalysis;
                if (graphCtrlPack == ctrl)
                {
                    bool showDimensions = true;
                    // build pack
                    PackProperties packProperties = analysis.Content as PackProperties;
                    Pack pack = new Pack(0, packProperties);
                    pack.ForceTransparency = true;
                    graphics.AddBox(pack);
                    if (showDimensions)
                    {
                        graphics.AddDimensions(new DimensionCube(Vector3D.Zero, pack.Length, pack.Width, pack.Height, Color.Black, true));
                        if (packProperties.Wrap.Transparent)
                            graphics.AddDimensions(
                                new DimensionCube(
                                    packProperties.InnerOffset
                                    , packProperties.InnerLength, packProperties.InnerWidth, packProperties.InnerHeight
                                    , Color.Red, false));
                    }
                }
                else if (graphCtrlSolution == ctrl)
                {
                    ViewerSolution sv = new ViewerSolution(SelectedAnalysis.Solution);
                    sv.Draw(graphics, Transform3D.Identity);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
            try
            {
                // remove all existing rows
                gridSolutions.Rows.Clear();
                // *** IViews
                // captionHeader
                SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
                DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader();
                veHeaderCaption.BackColor = Color.SteelBlue;
                veHeaderCaption.Border = DevAge.Drawing.RectangleBorder.NoBorder;
                captionHeader.Background = veHeaderCaption;
                captionHeader.ForeColor = Color.Black;
                captionHeader.Font = new Font("Arial", GridFontSize, FontStyle.Bold);
                captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                // viewRowHeader
                SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
                DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
                backHeader.BackColor = Color.LightGray;
                backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
                viewColumnHeader.Background = backHeader;
                viewColumnHeader.ForeColor = Color.Black;
                viewColumnHeader.Font = new Font("Arial", GridFontSize, FontStyle.Regular);
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***
                // set first row
                gridSolutions.BorderStyle = BorderStyle.FixedSingle;
                gridSolutions.ColumnsCount = 7;
                gridSolutions.FixedRows = 1;
                gridSolutions.Rows.Insert(0);
                // header
                int iCol = 0;
                SourceGrid.Cells.ColumnHeader columnHeader;
                // A1xA2xA3
                columnHeader = new SourceGrid.Cells.ColumnHeader("A1 x A2 x A3");
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // dimensions
                columnHeader = new SourceGrid.Cells.ColumnHeader(
                    string.Format(Properties.Resources.ID_DIMENSIONS, UnitsManager.LengthUnitString));
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // weight
                columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.MassUnitString));
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // #packs 
                columnHeader = new SourceGrid.Cells.ColumnHeader("#");
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // weight
                columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Properties.Resources.ID_PALLETWEIGHT, UnitsManager.MassUnitString));
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // efficiency
                columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_EFFICIENCYPERCENTAGE);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;
                // maximum space
                columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Properties.Resources.ID_MAXIMUMSPACE, UnitsManager.LengthUnitString));
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, iCol++] = columnHeader;

                int iRow = 0;
                foreach (AnalysisHomo analysis in _analyses)
                {
                    AnalysisCasePallet analysisCasePallet = analysis as AnalysisCasePallet;
                    PackProperties pack = analysisCasePallet.Content as PackProperties;
                    int layerCount = analysisCasePallet.Solution.Layers.Count;
                    if (layerCount < 1) continue;
                    int packPerLayerCount = analysisCasePallet.Solution.Layers[0].BoxCount;
                    int itemCount = analysisCasePallet.Solution.ItemCount;
                    double palletWeight = analysisCasePallet.Solution.Weight;
                    double volumeEfficiency = analysisCasePallet.Solution.VolumeEfficiency;
                    double maximumSpace = analysisCasePallet.Solution.LayerCount > 0 ? analysisCasePallet.Solution.LayerMaximumSpace(0) : 0;


                    gridSolutions.Rows.Insert(++iRow);
                    iCol = 0;
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0} x {1} x {2}",
                        pack.Arrangement.Length, pack.Arrangement.Width, pack.Arrangement.Height));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.#} x {1:0.#} x {2:0.#}",
                        pack.OuterDimensions.X, pack.OuterDimensions.Y, pack.OuterDimensions.Z));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.###}",
                        pack.Weight));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0} = {1} x {2}", itemCount, packPerLayerCount, layerCount));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.###}", palletWeight));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.#}", volumeEfficiency));
                    gridSolutions[iRow, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.#}", maximumSpace));
                }

                gridSolutions.AutoStretchColumnsToFitWidth = true;
                gridSolutions.AutoSizeCells();
                gridSolutions.Columns.StretchToFit();

                // select first solution
                if (gridSolutions.RowsCount > 1)
                    gridSolutions.Selection.SelectRow(1, true);
                else
                {
                    // grid empty -> clear drawing
                    _selectedAnalysis = null;
                    graphCtrlPack.Invalidate();
                    graphCtrlSolution.Invalidate();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Private properties
        private int GridFontSize
        { get; set; }
        #endregion
    }
}
