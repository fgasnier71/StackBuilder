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
    public partial class DockContentAnalysisCasePallet : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
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
        {
            _document = document;

            _analysis = analysis;
            _analysis.AddListener(this);

            _solution = analysis.Solutions[0];

            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // initialize drawing container
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();

            graphCtrlSolution.VolumeSelected += onLayerSelected;

            FillLayerControls();
            UpdateControls();

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

            FillGrid();
            UpdateGrid();
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
        public void Update(ItemBase item)
        {
            graphCtrlSolution.Invalidate();
        }
        public void Kill(ItemBase item)
        {
            Close();
            _analysis.RemoveListener(this);
        }
        #endregion

        #region IView implementation
        public IDocument Document
        {
            get { return _document; }
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

        #region Event handlers
        private void FillGrid()
        { 
            // clear grid
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;

            // header
            SourceGrid.Cells.RowHeader rowHeader;

            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewRowHeader.Background = backHeader;
            viewRowHeader.ForeColor = Color.Black;
            viewRowHeader.Font = new Font("Arial", 10, FontStyle.Regular);

            int iRow = -1;
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Layer #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Interlayer #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Case #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(string.Format("Outer dimensions\n({0} x {0} x {0})", UnitsManager.LengthUnitString));
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(string.Format("Load dimensions\n({0} x {0} x {0})", UnitsManager.LengthUnitString));
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(string.Format("Load Weight ({0})", UnitsManager.MassUnitString));
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(string.Format("Total weight ({0})", UnitsManager.MassUnitString));
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Vol. efficiency (%)");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            // select first solution
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Invalidate();
        }

        private void UpdateGrid()
        {
            if (gridSolutions.ColumnsCount < 2 && gridSolutions.Rows.Count < 4)
                return;

            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);

            BBox3D bboxGlobal = _solution.BBoxGlobal;
            BBox3D bboxLoad = _solution.BBoxLoad;
            int iRow = 0;

            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.ItemCount);
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxGlobal.Length, bboxGlobal.Width, bboxGlobal.Height));
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LoadWeight));
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.Weight));
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.VolumeEfficiency));

            for (int i = 0; i < iRow; ++i)
            {
                gridSolutions[i, 1].View = viewNormal;
                gridSolutions[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            }
                
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Invalidate();
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
        #region Toolbar
        private void onBack(object sender, EventArgs e)
        { 
            
        }
        private void onGenerateReportMSWord(object sender, EventArgs e)
        {
            FormMain.GenerateReport(_solution);
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
    }
}
