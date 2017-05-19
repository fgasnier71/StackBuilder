#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
// Docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;
using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCasePallet : DockContentView
    {
        #region Data members
        /// <summary>
        /// analysis
        /// </summary>
        private AnalysisCasePallet _analysis;
        /// <summary>
        /// solution
        /// </summary>
        private Solution _solution;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisCasePallet));
        #endregion

        #region Constructor
        public DockContentAnalysisCasePallet(IDocument document, AnalysisCasePallet analysis)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddListener(this);

            _solution = analysis.Solution;

            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // --- window caption
            this.Text = _analysis.Name + " - " + _analysis.ParentDocument.Name;

            // --- initialize drawing container
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();
            graphCtrlSolution.VolumeSelected += onLayerSelected;
            // ---

            // --- initialize layer controls
            FillLayerControls();
            UpdateControls();

            uCtrlMaxPalletHeight.Value = _analysis.ConstraintSet.OptMaxHeight.Value;
            uCtrlOptMaximumWeight.Value = _analysis.ConstraintSet.OptMaxWeight;

            uCtrlMaxPalletHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onCriterionChanged);
            uCtrlOptMaximumWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.onValueChanged(this.onCriterionChanged);

            ComboBoxHelpers.FillCombo(PalletCorners, cbPalletCorners, null);
            chkbPalletCorners.Enabled = (cbPalletCorners.Items.Count > 0);
            ComboBoxHelpers.FillCombo(PalletCaps, cbPalletCap, null);
            chkbPalletCap.Enabled = (cbPalletCap.Items.Count > 0);
            ComboBoxHelpers.FillCombo(PalletFilms, cbPalletFilm, null);
            chkbPalletFilm.Enabled = (cbPalletFilm.Items.Count > 0);

            chkbPalletCorners.CheckedChanged += onPalletProtectionChanged;
            chkbPalletCap.CheckedChanged += onPalletProtectionChanged;
            chkbPalletFilm.CheckedChanged += onPalletProtectionChanged;

            cbPalletCorners.SelectedIndexChanged += onPalletProtectionChanged;
            cbPalletCap.SelectedIndexChanged += onPalletProtectionChanged;
            cbPalletFilm.SelectedIndexChanged += onPalletProtectionChanged;
            // ---

            // --- initialize grid control
            FillGrid();
            UpdateGrid();
            // ---
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Document.RemoveView(this);
        }

        private void onPalletProtectionChanged(object sender, EventArgs e)
        {
            cbPalletCorners.Enabled = chkbPalletCorners.Checked;
            cbPalletCap.Enabled = chkbPalletCap.Checked;
            cbPalletFilm.Enabled = chkbPalletFilm.Checked;

            AnalysisCasePallet casePalletAnalysis = _solution.Analysis as AnalysisCasePallet;
            casePalletAnalysis.PalletCornerProperties = SelectedPalletCorners;
            casePalletAnalysis.PalletCapProperties = SelectedPalletCap;
            casePalletAnalysis.PalletFilmProperties = SelectedPalletFilm;

            graphCtrlSolution.Invalidate();
        }
        #endregion

        #region Private properties (Pallet corners, pallet caps, pallet film)
        private PalletCornerProperties SelectedPalletCorners
        {
            get
            {
                if (cbPalletCorners.Items.Count > 0 && chkbPalletCorners.Checked)
                {
                    ItemBaseCB item = cbPalletCorners.SelectedItem as ItemBaseCB;
                    return  item.Item as PalletCornerProperties;
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
                    ItemBaseCB item = cbPalletCap.SelectedItem as ItemBaseCB;
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
                    ItemBaseCB item = cbPalletFilm.SelectedItem as ItemBaseCB;
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
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            ViewerSolution sv = new ViewerSolution( Solution );
            sv.Draw(graphics, Transform3D.Identity);
        }
        #endregion

        #region Public properties
        public AnalysisCasePallet Analysis
        {
            get { return _analysis; }
        }
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        #endregion

        #region Private properties / Helpers
        private ItemBase[] PalletCorners
        {
            get
            {
                Document doc = _document as Document;
                return doc.ListByType(typeof(PalletCornerProperties)).ToArray(); 
            }
        }
        private ItemBase[] PalletCaps
        {
            get
            {
                Document doc = _document as Document;
                return doc.ListByType(typeof(PalletCapProperties)).ToArray(); 
            }
        }
        private ItemBase[] PalletFilms
        {
            get
            {
                Document doc = _document as Document;
                return doc.ListByType(typeof(PalletFilmProperties)).ToArray(); 
            }
        }
        #endregion

        #region Grid filling
        private void FillGrid()
        { 
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;
            gridSolution.FixedColumns = 1;
        }
        private void UpdateGrid()
        {
            try
            {
                // sanity check
                if (gridSolution.ColumnsCount < 2)
                    return;
                // remove all existing rows
                gridSolution.Rows.Clear();
                // *** IViews 
                // captionHeader
                SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
                DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader();
                veHeaderCaption.BackColor = Color.SteelBlue;
                veHeaderCaption.Border = DevAge.Drawing.RectangleBorder.NoBorder;
                captionHeader.Background = veHeaderCaption;
                captionHeader.ForeColor = Color.Black;
                captionHeader.Font = new Font("Arial", 10, FontStyle.Bold);
                captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                // viewRowHeader
                SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
                DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader();
                backHeader.BackColor = Color.LightGray;
                backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
                viewRowHeader.Background = backHeader;
                viewRowHeader.ForeColor = Color.Black;
                viewRowHeader.Font = new Font("Arial", 10, FontStyle.Regular);
                // viewNormal
                CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***

                SourceGrid.Cells.RowHeader rowHeader;
                int iRow = -1;
                // pallet caption
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_PALLET);
                rowHeader.ColumnSpan = 2;
                rowHeader.View = captionHeader;
                gridSolution[iRow, 0] = rowHeader;
                // layer #
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_LAYERNUMBER);
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
                // interlayer #
                if (_solution.InterlayerCount > 0)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_INTERLAYERNUMBER);
                    rowHeader.View = viewRowHeader;
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
                    rowHeader = new SourceGrid.Cells.RowHeader(string.Format("{0} #", content.DetailedName));
                    rowHeader.View = viewRowHeader;
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
                    string.Format(Resources.ID_OUTERDIMENSIONS, UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxGlobal.Length, bboxGlobal.Width, bboxGlobal.Height));
                // load dimensions
                BBox3D bboxLoad = _solution.BBoxLoad;
                // ---
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADDIMENSIONS, UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
                // net weight
                if (_solution.HasNetWeight)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format(Resources.ID_NETWEIGHT_WU, UnitsManager.MassUnitString));
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.NetWeight));
                }
                // load weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADWEIGHT_WU, UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LoadWeight));
                // total weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_TOTALWEIGHT_WU, UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.Weight));
                // volume efficiency
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_VOLUMEEFFICIENCY);
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.VolumeEfficiency));

                int noLayerTypesUsed = _solution.NoLayerTypesUsed;
                // ### layers : begin
                for (int i = 0; i < _solution.Layers.Count; ++i)
                {
                    // layer caption
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(_solution.LayerCaption(i));
                    rowHeader.ColumnSpan = 2;
                    rowHeader.View = captionHeader;
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
                            string.Format("{0} #", content.DetailedName));
                        rowHeader.View = viewRowHeader;
                        gridSolution[iRow, 0] = rowHeader;
                        gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                    }
                    while (null != content && content.InnerContent(ref content, ref number));
                    // ***

                    // layer weight
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(string.Format(Resources.ID_WEIGHT_WU, UnitsManager.MassUnitString));
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerWeight(i)));
                    // layer space
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Spaces");
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerMaximumSpace(i)));
                }
                // ### layers : end

                gridSolution.AutoSizeCells();
                gridSolution.Columns.StretchToFit();
                gridSolution.AutoStretchColumnsToFitWidth = true;
                gridSolution.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onLayerSelected(int id)
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
        private void onLayerIndexChanged(object sender, EventArgs e)
        {
            // get index of layer type
            int layerIndex = cbLayerType.SelectedIndex;
            if (-1 == layerIndex) return;
            // set on current layer
            _solution.SelectLayer(layerIndex);
            graphCtrlSolution.Invalidate();
            // update controls
            UpdateControls();
        }
        private void onLayerTypeChanged(object sender, EventArgs e)
        {
            try
            {
                int iLayerType = cbLayerType.SelectedIndex;
                // get selected layer
                _solution.SetLayerTypeOnSelected(iLayerType);
                // redraw
                graphCtrlSolution.Invalidate();
                UpdateGrid();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onInterlayerChanged(object sender, EventArgs e)
        {
            try
            {
                // get index of interlayer
                InterlayerProperties interlayer = null;
                if (chkbInterlayer.Checked)
                {
                    ItemBaseCB itemInterlayer = cbInterlayer.SelectedItem as ItemBaseCB;
                    if (null != itemInterlayer)
                        interlayer = itemInterlayer.Item as InterlayerProperties;
                }
                _solution.SetInterlayerOnSelected(interlayer);
                graphCtrlSolution.Invalidate();
                UpdateGrid();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onReflectionX(object sender, EventArgs e)
        {
            _solution.ApplySymetryOnSelected(0);
            graphCtrlSolution.Invalidate();
        }
        private void onReflectionY(object sender, EventArgs e)
        {
            _solution.ApplySymetryOnSelected(1);
            graphCtrlSolution.Invalidate();
        }
        private void onChkbInterlayerClicked(object sender, EventArgs e)
        {
            cbInterlayer.Enabled = chkbInterlayer.Checked;
            onInterlayerChanged(null, null);
            UpdateGrid();
        }
        private void onSizeChanged(object sender, EventArgs e)
        {
            int splitDistance = splitContainerHoriz.Size.Height - 120;
            if (splitDistance > 0)
                splitContainerHoriz.SplitterDistance = splitDistance;
        }
        private void onCriterionChanged(object sender, EventArgs args)
        {
            ConstraintSetCasePallet constraintSet = _solution.Analysis.ConstraintSet as ConstraintSetCasePallet;
            constraintSet.SetMaxHeight( new OptDouble(true, uCtrlMaxPalletHeight.Value) );
            constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
            _solution.RebuildSolutionItemList();
            // update drawing & grid
            graphCtrlSolution.Invalidate();
            UpdateGrid();
        }
        #endregion

        #region Toolbar event handlers
        private void onBack(object sender, EventArgs e)
        {
            // close this form
            Close();
            // call edit analysis
            Document.EditAnalysis(_analysis);
        }
        private void onGenerateReportMSWord(object sender, EventArgs e)
        {
            FormMain.GetInstance().GenerateReportMSWord(_analysis);
        }
        private void onGenerateReportHTML(object sender, EventArgs e)
        {
            FormMain.GetInstance().GenerateReportHTML(_analysis);
        }
        #endregion
 
        #region Layer controls
        private void FillLayerControls()
        {
            try
            {
                cbLayerType.Packable = _analysis.Content;
                // build layers and fill CCtrl
                foreach (LayerDesc layerDesc in _solution.LayerDescriptors)
                {
                    LayerSolver solver = new LayerSolver();
                    Layer2D layer = solver.BuildLayer(_analysis.ContentDimensions, _analysis.ContainerDimensions, layerDesc as LayerDescBox);
                    cbLayerType.Items.Add(layer);
                }
                if (cbLayerType.Items.Count > 0)
                    cbLayerType.SelectedIndex = 0;

                // interlayer combo box
                Document doc = _document as Document;
                if (null == doc) return;
                ItemBase[] interlayers = doc.ListByType(typeof(InterlayerProperties)).ToArray();
                ComboBoxHelpers.FillCombo(interlayers, cbInterlayer, null);
            }
            catch (Exception ex)
            {
                _log.Error( ex.Message );
            }
        }
        private void UpdateControls()
        {
            try
            {
                int index = _solution.SelectedLayerIndex;
                bnSymmetryX.Enabled = (index != -1);
                bnSymetryY.Enabled = (index != -1);
                cbLayerType.Enabled = (index != -1);
                chkbInterlayer.Enabled = (index != -1) && (cbInterlayer.Items.Count > 0);

                gbLayer.Text = index != -1
                    ? string.Format(Resources.ID_SELECTEDLAYER, index)
                    : Resources.ID_DOUBLECLICKALAYER;

                if (index != -1)
                {
                    tbClickLayer.Hide();
                    gbLayer.Show();

                    // get selected solution item
                    SolutionItem selItem = _solution.SelectedSolutionItem;
                    if (null != selItem)
                    {
                        // set current layer
                        cbLayerType.SelectedIndex = selItem.LayerIndex;
                        // set interlayer
                        chkbInterlayer.Checked = selItem.HasInterlayer;
                        onChkbInterlayerClicked(null, null);
                    }
                    // select combo box
                    int selIndex = 0;
                    foreach (object o in cbInterlayer.Items)
                    {
                        InterlayerProperties interlayerProp = o as InterlayerProperties;
                        if (interlayerProp == _solution.SelectedInterlayer)
                            break;
                        ++selIndex;
                    }
                    if (selIndex < cbInterlayer.Items.Count)
                        cbInterlayer.SelectedIndex = selIndex;
                }
                else
                {
                    gbLayer.Hide();
                    tbClickLayer.Show();
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
