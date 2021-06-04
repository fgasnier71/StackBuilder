#region Using directives
using System;
using System.Windows.Forms;
using System.Globalization;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinderCase : DockContentAnalysisEdit
    {
        #region Constructor
        public DockContentAnalysisCylinderCase(IDocument document, AnalysisCylinderCase analysis)
            : base(document, analysis)
        {
            InitializeComponent();
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
            try
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
                RecurInsertContent(ref iRow, _analysis.Content, _solution.ItemCount);
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
                        string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.NetWeight.Value));
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
                    RecurInsertContent(ref iRow, _analysis.Content, _solution.LayerBoxCount(i));
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
    }
}
