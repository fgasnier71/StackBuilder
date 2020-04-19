#region Using directives
using System;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
// log4net
using log4net;
// treeDiM
using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCasePallet : DockContentAnalysisEdit
    {
        #region Constructor
        public DockContentAnalysisCasePallet(IDocument document, AnalysisCasePallet analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // --- initialize drawing container
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();
            graphCtrlSolution.VolumeSelected += OnLayerSelected;
            // ---

            // --- initialize layer controls
            UpdateControls();

            uCtrlMaxPalletHeight.Value = _analysis.ConstraintSet.OptMaxHeight.Value;
            uCtrlOptMaximumWeight.Value = _analysis.ConstraintSet.OptMaxWeight;
            uCtrlOptMaxNumber.Value = _analysis.ConstraintSet.OptMaxNumber;

            uCtrlMaxPalletHeight.ValueChanged += new UCtrlDouble.ValueChangedDelegate(OnCriterionChanged);
            uCtrlOptMaximumWeight.ValueChanged += new UCtrlOptDouble.ValueChangedDelegate(OnCriterionChanged);
            uCtrlOptMaxNumber.ValueChanged += new UCtrlOptInt.ValueChangedDelegate(OnCriterionChanged);

            AnalysisCasePallet analysisCasePallet = _analysis as AnalysisCasePallet;

            ComboBoxHelpers.FillCombo(PalletCorners, cbPalletCorners, analysisCasePallet?.PalletCornerProperties);
            chkbPalletCorners.Enabled = (cbPalletCorners.Items.Count > 0);
            ComboBoxHelpers.FillCombo(PalletCorners, cbPalletCornersTop, analysisCasePallet?.PalletCornerTopProperties);
            chkbPalletCornersTop.Enabled = (cbPalletCornersTop.Items.Count > 0);
            ComboBoxHelpers.FillCombo(PalletCaps, cbPalletCap, analysisCasePallet?.PalletCapProperties);
            chkbPalletCap.Enabled = (cbPalletCap.Items.Count > 0);
            ComboBoxHelpers.FillCombo(PalletFilms, cbPalletFilm, analysisCasePallet?.PalletFilmProperties);
            chkbPalletFilm.Enabled = (cbPalletFilm.Items.Count > 0);

            if (null != analysisCasePallet)
            {
                chkbPalletCorners.Checked = null != analysisCasePallet.PalletCornerProperties;
                chkbPalletCornersTop.Checked = null != analysisCasePallet.PalletCornerTopProperties;
                chkbPalletCap.Checked = null != analysisCasePallet.PalletCapProperties;
                chkbPalletFilm.Checked = null != analysisCasePallet.PalletFilmProperties;
                ctrlStrapperSet.StrapperSet = analysisCasePallet.StrapperSet;
            }
            // ---
            // --- initialize grid control
            FillGrid();
            UpdateGrid();
            // ---

            _initialized = true;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Document.RemoveView(this);
        }

        private void OnPalletProtectionChanged(object sender, EventArgs e)
        {
            if (!_initialized)  return;

            cbPalletCorners.Enabled = chkbPalletCorners.Checked;
            cbPalletCornersTop.Enabled = chkbPalletCornersTop.Checked;
            cbPalletCap.Enabled = chkbPalletCap.Checked;
            cbPalletFilm.Enabled = chkbPalletFilm.Checked;

            if (_solution.Analysis is AnalysisCasePallet analysisCasePallet)
            {
                analysisCasePallet.PalletCornerProperties = SelectedPalletCorners;
                analysisCasePallet.PalletCornerTopProperties = SelectedPalletCornersTop;
                analysisCasePallet.PalletCapProperties = SelectedPalletCap;
                analysisCasePallet.PalletFilmProperties = SelectedPalletFilm;
                analysisCasePallet.StrapperSet = ctrlStrapperSet.StrapperSet;
            }
            graphCtrlSolution.Invalidate();
        }
        #endregion

        #region Override DockContentAnalysisEdit
        protected override string GridCaption => Resources.ID_PALLET;
        protected override bool AllowExport3D => true;
        #endregion

        #region Private properties (Pallet corners, pallet caps, pallet film)
        private PalletCornerProperties SelectedPalletCorners
        {
            get
            {
                if (cbPalletCorners.Items.Count > 0 && chkbPalletCorners.Checked)
                {
                    if (cbPalletCorners.SelectedItem is ItemBaseCB item)
                        return  item.Item as PalletCornerProperties;
                }
                return null;
            }
        }
        private PalletCornerProperties SelectedPalletCornersTop
        {
            get
            {
                if (cbPalletCornersTop.Items.Count > 0 && chkbPalletCornersTop.Checked)
                {
                    if (cbPalletCornersTop.SelectedItem is ItemBaseCB item)
                        return item.Item as PalletCornerProperties;
                }
                return null;
            }
        }
        private PalletCapProperties SelectedPalletCap
        {
            get
            {
                if (cbPalletCap.Items.Count > 0 && chkbPalletCap.Checked)
                {
                    if (cbPalletCap.SelectedItem is ItemBaseCB item)
                        return item.Item as PalletCapProperties;
                }
                return null;
            }
        }
        private PalletFilmProperties SelectedPalletFilm
        {
            get
            {
                if (cbPalletFilm.Items.Count > 0 && chkbPalletFilm.Checked)
                {
                    if (cbPalletFilm.SelectedItem is ItemBaseCB item)
                        return item.Item as PalletFilmProperties;
                }
                return null;
            }
        }
        #endregion

        #region IItemListener implementation
        public override void Update(ItemBase item)
        {
            base.Update(item);
            graphCtrlSolution.Invalidate();
        }
        public override void Kill(ItemBase item)
        {
            base.Kill(item);
            if (null != _analysis)
                _analysis.RemoveListener(this);
        }
        #endregion

        #region IDrawingContainer
        #endregion

        #region Public properties
        #endregion

        #region Private properties / Helpers
        private ItemBase[] PalletCorners
        {
            get
            {
                Document doc = Document as Document;
                return doc.GetByType(typeof(PalletCornerProperties)).ToArray(); 
            }
        }
        private ItemBase[] PalletCaps
        {
            get
            {
                Document doc = Document as Document;
                return doc.GetByType(typeof(PalletCapProperties)).ToArray(); 
            }
        }
        private ItemBase[] PalletFilms
        {
            get
            {
                Document doc = Document as Document;
                return doc.GetByType(typeof(PalletFilmProperties)).ToArray(); 
            }
        }
        #endregion

        #region Grid filling
        public override void FillGrid()
        { 
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;
            gridSolution.Columns[0].Width = 100;
            gridSolution.FixedColumns = 1;
        }
        public override void UpdateGrid()
        {
            try
            {
                // sanity check
                if (gridSolution.ColumnsCount < 2)
                    return;
                // remove all existing rows
                gridSolution.Rows.Clear();
                // cell visual properties
                var vPropHeader = CellProperties.VisualPropHeader;
                var vPropValue = CellProperties.VisualPropValue;

                int iRow = -1;
                // pallet caption
                gridSolution.Rows.Insert(++iRow);
                SourceGrid.Cells.RowHeader rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_PALLET)
                {
                    ColumnSpan = 2,
                    View = vPropHeader
                };
                gridSolution[iRow, 0] = rowHeader;
                // layer #
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_LAYERNUMBER)
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
                // interlayer #
                if (_solution.InterlayerCount > 0)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_INTERLAYERNUMBER)
                    {
                        View = vPropValue
                    };
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
                }
                // *** Item # (Recursive count)
                Packable content = _analysis.Content;
                int itemCount = _solution.ItemCount ;
                int number = 1;
                do
                {
                    itemCount *= number;
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(string.Format("{0} #", content.DetailedName))
                    {
                        View = vPropValue
                    };
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                }
                while (null != content && content.InnerContent(ref content, ref number));
                // ***
                // outer dimensions
                BBox3D bboxGlobal = _solution.BBoxGlobal;
                // ---
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_OUTERDIMENSIONS, UnitsManager.LengthUnitString))
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxGlobal.Length, bboxGlobal.Width, bboxGlobal.Height));
                // load dimensions
                BBox3D bboxLoad = _solution.BBoxLoad;
                // ---
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADDIMENSIONS, UnitsManager.LengthUnitString))
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
                // net weight
                if (_solution.HasNetWeight)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format(Resources.ID_NETWEIGHT_WU, UnitsManager.MassUnitString))
                    {
                        View = vPropValue
                    };
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.NetWeight));
                }
                // load weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADWEIGHT_WU, UnitsManager.MassUnitString))
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LoadWeight));
                // total weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_TOTALWEIGHT_WU, UnitsManager.MassUnitString))
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.Weight));
                // volume efficiency
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_VOLUMEEFFICIENCY)
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.VolumeEfficiency));

                // ### layers : begin
                for (int i = 0; i < _solution.NoLayerTypesUsed; ++i)
                {
                    // layer caption
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(_solution.LayerCaption(i))
                    {
                        ColumnSpan = 2,
                        View = vPropHeader
                    };
                    gridSolution[iRow, 0] = rowHeader;

                    // *** Item # (recursive count)
                    content = _analysis.Content;
                    itemCount = _solution.LayerBoxCount(i);
                    number = 1;
                    do
                    {
                        itemCount *= number;

                        gridSolution.Rows.Insert(++iRow);
                        rowHeader = new SourceGrid.Cells.RowHeader(
                            string.Format("{0} #", content.DetailedName))
                        {
                            View = vPropValue
                        };
                        gridSolution[iRow, 0] = rowHeader;
                        gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                    }
                    while (null != content && content.InnerContent(ref content, ref number));
                    // ***

                    // layer weight
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(string.Format(Resources.ID_WEIGHT_WU, UnitsManager.MassUnitString))
                    {
                        View = vPropValue
                    };
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerWeight(i)));
                    // layer space
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Spaces")
                    {
                        View = vPropValue
                    };
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerMaximumSpace(i)));
                }
                // ### layers : end
                gridSolution.AutoSizeCells();
                gridSolution.AutoStretchColumnsToFitWidth = true;
                gridSolution.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnLayerSelected(int id)
        {
            try
            {
                _solution.SelectLayer(id);
                UpdateControls();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Event handlers
        private void OnSizeChanged(object sender, EventArgs e)
        {
            int splitDistance = splitContainerHoriz.Size.Height - 120;
            if (splitDistance > 0)
                splitContainerHoriz.SplitterDistance = splitDistance;
        }
        private void OnCriterionChanged(object sender, EventArgs args)
        {
            try
            {
                ConstraintSetCasePallet constraintSet = _solution.Analysis.ConstraintSet as ConstraintSetCasePallet;
                constraintSet.SetMaxHeight(new OptDouble(true, uCtrlMaxPalletHeight.Value));
                constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
                constraintSet.OptMaxNumber = uCtrlOptMaxNumber.Value;
                _solution.RebuildSolutionItemList();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            // update drawing & grid
            graphCtrlSolution.Invalidate();
            UpdateGrid();
        }
        #endregion

        #region Toolbar event handlers
        private void OnBack(object sender, EventArgs e)
        {
            // close this form
            Close();
            // call edit analysis
            Document.EditAnalysis(_analysis);
        }
        private void OnGenerateReport(object sender, EventArgs e)
        {
            FormMain.GetInstance().GenerateReport(_analysis);
        }
        #endregion

        #region Data members
        /// <summary>
        /// logger
        /// </summary>
        protected static readonly new ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisCasePallet));
        private bool _initialized = false;
        #endregion
    }
}
