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
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisEdit : DockContentView, IDrawingContainer, IItemBaseFilter
    {
        #region Data members
        /// <summary>
        /// analysis
        /// </summary>
        protected Analysis _analysis;
        /// <summary>
        /// solution
        /// </summary>
        protected Solution _solution;

        protected static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisEdit));
        #endregion

        #region Constructor
        public DockContentAnalysisEdit()
            : base(null)
        {
            _analysis = null;

            InitializeComponent();
        }
        public DockContentAnalysisEdit(IDocument document, Analysis analysis)
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

            // initialize drawing container
            graphCtrlSolution.DrawingContainer = this;
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();

            graphCtrlSolution.VolumeSelected += onLayerSelected;

            FillGrid();
            UpdateGrid();

            FillLayerControls();
            UpdateControls();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Document.RemoveView(this);
        }
        #endregion

        #region IItemListener implementation
        public override void Update(ItemBase item)
        {
            graphCtrlSolution.Invalidate();
        }
        public override void Kill(ItemBase item)
        {
            Close();
            _analysis.RemoveListener(this);
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            InterlayerProperties interlayer = itemBase as InterlayerProperties;
            if (ctrl == cbInterlayer && null != interlayer)
                return _analysis.AllowInterlayer(interlayer);
            return false;
        }
        #endregion

        #region Public properties
        public Analysis Analysis
        {
            get { return _analysis; }
        }
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            ViewerSolution sv = new ViewerSolution(Solution);
            sv.Draw(graphics, Transform3D.Identity);
        }
        #endregion

        #region Virtual functions
        public virtual void FillGrid()
        {
            // clear grid
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;
        }
        public virtual void UpdateGrid()
        {
            // remove all existing rows
            gridSolutions.Rows.Clear();
            // *** IViews
            // caption header
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
            int itemCount = _solution.ItemCount;
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
                // layer caption
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(_solution.LayerCaption(i));
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
        #endregion

        #region Event handlers
        private void onLayerSelected(int id)
        {
            try
            {
                _solution.SelectLayer(id);
                UpdateControls();
            }
            catch (Exception ex)
            {   _log.Error(ex.ToString()); }
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
            {   _log.Error(ex.ToString()); }
        }
        private void onInterlayerChanged(object sender, EventArgs e)
        {
            try
            {
                // get index of interlayer
                InterlayerProperties interlayer = null;
                if (chkbInterlayer.Checked)
                    interlayer = cbInterlayer.SelectedType as InterlayerProperties;
                _solution.SetInterlayerOnSelected(interlayer);
                graphCtrlSolution.Invalidate();
                UpdateGrid();
            }
            catch (Exception ex)
            {   _log.Error(ex.ToString()); }
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
                    ILayer2D layer = solver.BuildLayer(_analysis.Content, _analysis.ContainerDimensions, layerDesc);
                    cbLayerType.Items.Add(layer);
                }
                if (cbLayerType.Items.Count > 0)
                    cbLayerType.SelectedIndex = 0;

                // fill combo cbInterlayer
                Document document = _document as Document;
                cbInterlayer.Initialize(document, this, null);
            }
            catch (Exception /*ex*/)
            {
            }
        }
        protected void UpdateControls()
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
            catch (Exception /*ex*/)
            {
            }
        }
        #endregion
    }
}
