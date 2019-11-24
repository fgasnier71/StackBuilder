#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;
using treeDiM.StackBuilder.GUIExtension.Properties;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class FormBrowseSolution : Form, IDrawingContainer
    {
        #region Data members
        private static ILog _log = LogManager.GetLogger(typeof(FormBrowseSolution));
        private Document _doc;
        private AnalysisLayered _analysis;
        #endregion

        #region Constructor
        public FormBrowseSolution(Document doc, AnalysisLayered analysis)
        {
            InitializeComponent();

            _doc = doc;
            _analysis = analysis;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GridFontSize = Settings.Default.GridFontSize;

            uCtrlMaxPalletHeight.Value = _analysis.ConstraintSet.OptMaxHeight.Value;
            uCtrlOptMaximumWeight.Value = _analysis.ConstraintSet.OptMaxWeight;

            graphCtrl.Viewer = new ViewerSolution(_analysis.Solution);
            graphCtrl.Invalidate();
            graphCtrl.VolumeSelected += OnLayerSelected;

            // --- initialize layer controls
            FillLayerControls();
            UpdateControls();


            uCtrlMaxPalletHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnCriterionChanged);
            uCtrlOptMaximumWeight.ValueChanged += new treeDiM.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnCriterionChanged);

            FillGrid();
            UpdateGrid();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        #endregion

        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (ctrl == graphCtrl)
            {
                ViewerSolution vs = new ViewerSolution(_analysis.Solution);
                vs.Draw(graphics, Transform3D.Identity);
            }
        }
        #endregion

        #region Grid
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
                captionHeader.Font = new Font("Arial", GridFontSize, FontStyle.Bold);
                captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                // viewRowHeader
                SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
                DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader();
                backHeader.BackColor = Color.LightGray;
                backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
                viewRowHeader.Background = backHeader;
                viewRowHeader.ForeColor = Color.Black;
                viewRowHeader.Font = new Font("Arial", GridFontSize, FontStyle.Regular);
                // viewNormal
                CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***

                SolutionLayered solution = _analysis.Solution;

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
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(solution.LayerCount);
                // interlayer #
                if (solution.InterlayerCount > 0)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_INTERLAYERNUMBER);
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(solution.InterlayerCount);
                }
                // *** Item # (Recursive count)
                Packable content = _analysis.Content;
                int itemCount = solution.ItemCount;
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
                BBox3D bboxGlobal = solution.BBoxGlobal;
                // ---
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_OUTERDIMENSIONS, Environment.NewLine, UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxGlobal.Length, bboxGlobal.Width, bboxGlobal.Height));
                // load dimensions
                BBox3D bboxLoad = solution.BBoxLoad;
                // ---
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADDIMENSIONS, Environment.NewLine, UnitsManager.LengthUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
                // net weight
                if (solution.HasNetWeight)
                {
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format(Resources.ID_NETWEIGHT_WU, UnitsManager.MassUnitString));
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.NetWeight));
                }
                // load weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_LOADWEIGHT_WU, UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.LoadWeight));
                // total weight
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(
                    string.Format(Resources.ID_TOTALWEIGHT_WU, UnitsManager.MassUnitString));
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.Weight));
                // volume efficiency
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_VOLUMEEFFICIENCY);
                rowHeader.View = viewRowHeader;
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.VolumeEfficiency));

                int noLayerTypesUsed = solution.NoLayerTypesUsed;

                // ### layers : begin
                for (int i = 0; i < solution.Layers.Count; ++i)
                {
                    List<int> layerIndexes = solution.LayerTypeUsed(i);
                    if (0 == layerIndexes.Count) continue;

                    // layer caption
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(solution.LayerCaption(i));
                    rowHeader.ColumnSpan = 2;
                    rowHeader.View = captionHeader;
                    gridSolution[iRow, 0] = rowHeader;

                    // *** Item # (recursive count)
                    content = _analysis.Content;
                    itemCount = solution.LayerBoxCount(i);
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
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.LayerWeight(i)));
                    // layer space
                    gridSolution.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader("Spaces");
                    rowHeader.View = viewRowHeader;
                    gridSolution[iRow, 0] = rowHeader;
                    gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", solution.LayerMaximumSpace(i)));
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
        #endregion

        #region Layer controls
        private void FillLayerControls()
        {
            try
            {
                // get solution
                SolutionLayered solution = _analysis.SolutionLay;
                // packable
                cbLayerType.Packable = _analysis.Content;
                // build layers and fill CCtrl
                foreach (var layerEncap in solution.LayerEncaps)
                {
                    if (null != layerEncap.Layer2D)
                    {
                        cbLayerType.Items.Add(layerEncap.Layer2D);
                    }
                    else if (null != layerEncap.LayerDesc)
                    {
                        LayerSolver solver = new LayerSolver();
                        Layer2DBrickImp layer = solver.BuildLayer(_analysis.ContentDimensions, _analysis.ContainerDimensions, layerEncap.LayerDesc as LayerDescBox, 0.0);
                        cbLayerType.Items.Add(layer);
                    }
                }
                if (cbLayerType.Items.Count > 0)
                    cbLayerType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void UpdateControls()
        {
            try
            {
                // get solution
                SolutionLayered solution = _analysis.SolutionLay;

                int index = solution.SelectedLayerIndex;
                bnSymmetryX.Enabled = (index != -1);
                bnSymetryY.Enabled = (index != -1);
                cbLayerType.Enabled = (index != -1);

                gbLayer.Text = index != -1
                    ? string.Format(Resources.ID_SELECTEDLAYER, index)
                    : Resources.ID_DOUBLECLICKALAYER;

                if (index != -1)
                {
                    tbClickLayer.Hide();
                    gbLayer.Show();

                    // get selected solution item
                    SolutionItem selItem = solution.SelectedSolutionItem;
                    if (null != selItem)
                    {
                        // set current layer
                        cbLayerType.SelectedIndex = selItem.IndexLayer;
                    }
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

        #region Toolbar event handler
        private void OnExport(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogExport.FileName = Path.ChangeExtension(_analysis.Name, "stb");
                if (DialogResult.OK == saveFileDialogExport.ShowDialog())
                {
                    Document doc = null;
                    doc.Write(saveFileDialogExport.FileName);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message); 
            }
        }
        private void OnGenerateReport(object sender, EventArgs e)
        {
            try
            {
                var form = new FormReportDesign(new ReportDataAnalysis(_analysis));
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message); 
            }
        }
        #endregion

        #region Event handlers
        private void OnLayerSelected(int id)
        {
            try
            {
                SolutionLayered solution = _analysis.Solution;
                solution.SelectLayer(id);
                UpdateControls();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnLayerTypeChanged(object sender, EventArgs e)
        {
            try
            {
                int iLayerType = cbLayerType.SelectedIndex;
                // get selected layer
                SolutionLayered solution = _analysis.Solution;
                solution.SetLayerTypeOnSelected(iLayerType);
                // redraw
                graphCtrl.Invalidate();
                UpdateGrid();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnReflectionX(object sender, EventArgs e)
        {
            SolutionLayered solution = _analysis.Solution;
            solution.ApplySymetryOnSelected(0);
            graphCtrl.Invalidate();
        }
        private void OnReflectionY(object sender, EventArgs e)
        {
            SolutionLayered solution = _analysis.Solution;
            solution.ApplySymetryOnSelected(1);
            graphCtrl.Invalidate();
        }
        private void OnCriterionChanged(object sender, EventArgs args)
        {
            try
            {
                SolutionLayered solution = _analysis.Solution;
                ConstraintSetCasePallet constraintSet = solution.Analysis.ConstraintSet as ConstraintSetCasePallet;
                constraintSet.SetMaxHeight(new OptDouble(true, uCtrlMaxPalletHeight.Value));
                constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
                solution.RebuildSolutionItemList();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            // update drawing & grid
            graphCtrl.Invalidate();
            UpdateGrid();
        }
        #endregion

        #region Private properties
        private int GridFontSize { get; set; }
        #endregion
    }
}
