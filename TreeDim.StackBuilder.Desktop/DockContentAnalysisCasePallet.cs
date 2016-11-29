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
            _analysis.RemoveListener(this);
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            bool showDimensions = true;
            ViewerSolution sv = new ViewerSolution( Solution);
            sv.Draw(graphics, showDimensions);
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
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;
        }
        private void UpdateGrid()
        {
            try
            {
                // sanity check
                if (gridSolutions.ColumnsCount < 2)
                    return;
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
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader("Pallet");
                rowHeader.ColumnSpan = 2;
                rowHeader.View = captionHeader;
                gridSolutions[iRow, 0] = rowHeader;
                // layer #
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader("Layer #");
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
                // interlayer #
                if (_solution.InterlayerCount > 0)
                {
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Interlayer #");
                    rowHeader.View = viewRowHeader;
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
                }
                // *** Item # (Recursive count)
                Packable content = _analysis.Content;
                int itemCount = _solution.ItemCount ;
                int number = 1;
                do
                {
                    itemCount *= number;
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(string.Format("{0} #", content.DetailedName));
                    rowHeader.View = viewRowHeader;
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                }
                while (null != content && content.InnerContent(ref content, ref number));
                // ***
                // outer dimensions
                BBox3D bboxGlobal = _solution.BBoxGlobal;
                // ---
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format("Outer dimensions\n({0} x {0} x {0})", UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxGlobal.Length, bboxGlobal.Width, bboxGlobal.Height));
                // load dimensions
                BBox3D bboxLoad = _solution.BBoxLoad;
                // ---
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format("Load dimensions\n({0} x {0} x {0})", UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
                // net weight
                if (_solution.HasNetWeight)
                {
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format("Net weight ({0})", UnitsManager.MassUnitString));
                    rowHeader.View = viewRowHeader;
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.NetWeight));
                }
                // load weight
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format("Load Weight ({0})", UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LoadWeight));
                // total weight
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format("Total weight ({0})", UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.Weight));
                // volume efficiency
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader("Vol. efficiency (%)");
                rowHeader.View = viewRowHeader;
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.VolumeEfficiency));

                int noLayerTypesUsed = 0;
                for (int i = 0; i < _solution.Layers.Count; ++i)
                    noLayerTypesUsed += _solution.Layers[i].BoxCount > 0 ? 1 : 0;

                // ### layers : begin
                for (int i = 0; i < _solution.Layers.Count; ++i)
                {
                    List<int> layerIndexes = _solution.LayerTypeUsed(i);
                    if (0 == layerIndexes.Count) continue;

                    // layer caption
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader((noLayerTypesUsed == 1) ? "Layers : All" : BuildLayerCaption(layerIndexes));
                    rowHeader.ColumnSpan = 2;
                    rowHeader.View = captionHeader;
                    gridSolutions[iRow, 0] = rowHeader;

                    // *** Item # (recursive count)
                    content = _analysis.Content;
                    itemCount = _solution.LayerBoxCount(i);
                    number = 1;
                    do
                    {
                        itemCount *= number;

                        gridSolutions.Rows.Insert(++iRow);
                        rowHeader = new SourceGrid.Cells.RowHeader(
                            string.Format("{0} #", content.DetailedName));
                        rowHeader.View = viewRowHeader;
                        gridSolutions[iRow, 0] = rowHeader;
                        gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                    }
                    while (null != content && content.InnerContent(ref content, ref number));
                    // ***

                    // layer weight
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Weight");
                    rowHeader.View = viewRowHeader;
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerWeight(i)));
                    // layer space
                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Spaces");
                    rowHeader.View = viewRowHeader;
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerMaximumSpace(i)));
                }
                // ### layers : end

                gridSolutions.AutoSizeCells();
                gridSolutions.Columns.StretchToFit();
                gridSolutions.AutoStretchColumnsToFitWidth = true;
                gridSolutions.Invalidate();
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
        #region Toolbar
        private void onBack(object sender, EventArgs e)
        {
            // close this form
            Close();
            // call edit analysis
            
        }
        private void onGenerateReportMSWord(object sender, EventArgs e)
        {
            FormMain.GenerateReport(_analysis);
        }
        #endregion
        #endregion

        #region Layer controls
        private void FillLayerControls()
        {
            try
            {
                cbLayerType.BoxProperties = _analysis.Content;
                // build layers and fill CCtrl
                foreach (LayerDesc layerDesc in _solution.LayerDescriptors)
                {
                    LayerSolver solver = new LayerSolver();
                    Layer2D layer = solver.BuildLayer(_analysis.ContentDimensions, _analysis.ContainerDimensions, layerDesc);
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

                gbLayer.Text = index != -1 ? string.Format("Selected layer : {0}", index) : "Double-click a layer";

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

        #region Helpers
        private string BuildLayerCaption(List<int> layerIndexes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(layerIndexes.Count > 1 ? "Layers " : "Layer ");
            int iCountIndexes = layerIndexes.Count;
            for (int j = 0; j < iCountIndexes; ++j)
            {
                sb.AppendFormat("{0}", layerIndexes[j]);
                if (j != iCountIndexes - 1)
                {
                    sb.Append(",");
                    if (j != 0 && 0 == j % 10)
                        sb.Append("\n");
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
