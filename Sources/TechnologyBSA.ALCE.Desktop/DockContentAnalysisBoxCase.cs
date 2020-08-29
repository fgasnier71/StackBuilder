#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisBoxCase : DockContentAnalysisEdit
    {
        #region Data members
        #endregion

        #region Constructor
        public DockContentAnalysisBoxCase(IDocument document, AnalysisLayered analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion
 
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            uCtrlOptMaximumWeight.Value = _analysis.ConstraintSet.OptMaxWeight;
            uCtrlOptMaxNumber.Value = _analysis.ConstraintSet.OptMaxNumber;

            uCtrlOptMaximumWeight.ValueChanged += new UCtrlOptDouble.ValueChangedDelegate(OnCriterionChanged);
            uCtrlOptMaxNumber.ValueChanged += new UCtrlOptInt.ValueChangedDelegate(OnCriterionChanged);

        }
        #endregion

        #region Override DockContentAnalysisEdit
        protected override string GridCaption => Resources.ID_CASE;
        public override void FillGrid()
        {
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;
            gridSolution.FixedColumns = 1;
        }
        public override void UpdateGrid()
        {
            // remove all existing rows
            gridSolution.Rows.Clear();

            // cell visual properties
            var vPropCaption = CellProperties.VisualPropHeader;
            var vPropValue = CellProperties.VisualPropValue;

            SourceGrid.Cells.RowHeader rowHeader;
            int iRow = -1;
            // case caption
            gridSolution.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_CASECOUNT)
            {
                ColumnSpan = 2,
                View = vPropCaption
            };
            gridSolution[iRow, 0] = rowHeader;
            // layer #
            gridSolution.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_LAYERCOUNT)
            {
                View = vPropValue
            };
            gridSolution[iRow, 0] = rowHeader;
            gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
            // interlayer #
            if (_solution.InterlayerCount > 0)
            {
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_INTERLAYERCOUNT)
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
            }
            // *** Item # (recursive count)
            Packable content = _analysis.Content;
            int itemCount = _solution.ItemCount;
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

            int noLayerTypesUsed = 0;
            for (int i = 0; i < _solution.Layers.Count; ++i)
                noLayerTypesUsed += _solution.Layers[i].BoxCount > 0 ? 1 : 0;

            // ### layers : begin
            for (int i = 0; i < _solution.NoLayerTypesUsed; ++i)
            {
                // layer caption
                gridSolution.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(_solution.LayerCaption(i))
                {
                    ColumnSpan = 2,
                    View = vPropCaption
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
                rowHeader = new SourceGrid.Cells.RowHeader(string.Format(Resources.ID_SPACES_WU, UnitsManager.LengthUnitString))
                {
                    View = vPropValue
                };
                gridSolution[iRow, 0] = rowHeader;
                gridSolution[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerMaximumSpace(i)));
            }

            gridSolution.AutoSizeCells();
            gridSolution.Columns.StretchToFit();
            gridSolution.AutoStretchColumnsToFitWidth = true;
            gridSolution.Invalidate();
        }
        #endregion

        #region Event handlers
        private void OnCriterionChanged(object sender, EventArgs args)
        {
            try
            {
                var constraintSet = _solution.Analysis.ConstraintSet as ConstraintSetBoxCase;
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
    }
}
