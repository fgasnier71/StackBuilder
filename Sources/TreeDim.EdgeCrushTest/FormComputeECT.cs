#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class FormComputeECT : Form
    {
        #region Constructor
        public FormComputeECT()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // initialize dimensions load
            CaseDimensions = new Vector3D(400.0, 300.0, 200.0);
            TopLoad = 50.0;
            McKeeFormulaType = McKeeFormula.FormulaType.MCKEE_CLASSIC;

            // fill material grid
            FillMaterialGrid();

            // initialize dynamic BCT grid
            InitializeGridDynamicBCT();


            // fill printed combo
            cbPrintedArea.Items.AddRange(McKeeFormula.PrintCoefDictionary.Keys.ToArray());
            cbPrintedArea.SelectedIndex = 0;

            gridMat.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(OnMaterialChanged);
        }
        #endregion

        #region Private properties
        private Vector3D CaseDimensions
        {
            get => uCtrlCaseDimensions.Value;
            set => uCtrlCaseDimensions.Value = value;
        }
        private double TopLoad
        {
            get => (double)nudLoad.Value;
            set => nudLoad.Value = (decimal)value;
        }
        private McKeeFormula.FormulaType McKeeFormulaType
        {
            get => cbMcKeeFormulaType.SelectedIndex == 0 ? McKeeFormula.FormulaType.MCKEE_CLASSIC : McKeeFormula.FormulaType.MCKEE_IMPROVED;
            set => cbMcKeeFormulaType.SelectedIndex = (value == McKeeFormula.FormulaType.MCKEE_CLASSIC ? 0 : 1);
        }
        private string PrintSurface
        {
            get => McKeeFormula.PrintCoefDictionary.Keys.ToList()[cbPrintedArea.SelectedIndex];
        }
        #endregion

        #region FillGrid
        private void FillMaterialGrid()
        {
            // remove all existing rows
            gridMat.Rows.Clear();
            // view column header
            var viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
            {
                Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                {
                    BackColor = Color.LightGray,
                    Border = DevAge.Drawing.RectangleBorder.NoBorder
                },
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Regular),
            };
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // set first row
            gridMat.BorderStyle = BorderStyle.FixedSingle;
            gridMat.ColumnsCount = 4;
            gridMat.FixedRows = 1;
            gridMat.Rows.Insert(0);
            // header
            int iCol = 0;
            SourceGrid.Cells.ColumnHeader columnHeader;
            // name
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // profile
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_PROFILE)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // thickness
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_THICKNESS)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // ECT
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_STATICBCT)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;


            int iIndex = 0;
            var dictQuality = CardboardQualityAccessor.Instance.CardboardQualityDictionary;
            Vector3D dim = CaseDimensions;

            // views
            CellColorFromValue viewNormal = new CellColorFromValue(TopLoad * 9.81 / 10) {}; // convert mass in kg to load in daN

            // ROWS
            foreach (var q in dictQuality)
            {
                gridMat.Rows.Insert(++iIndex);
                iCol = 0;

                var quality = q.Value;
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Name);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Profile);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.Thickness:0.##}");

                double staticBCT = McKeeFormula.ComputeStaticBCT(dim.X, dim.Y, dim.Z, q.Key, Properties.Resources.CASETYPE_AMERICANCASE, McKeeFormulaType);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{staticBCT:0.##}") { View = viewNormal };
            }
            gridMat.AutoStretchColumnsToFitWidth = true;
            gridMat.AutoSizeCells();
            gridMat.Columns.StretchToFit();

            // select first solution
            if (gridMat.RowsCount > 1)
                gridMat.Selection.SelectRow(1, true);
            else
                gridMat.Invalidate();
        }
        private QualityData SelectedMaterial
        {
            get
            {
                SourceGrid.RangeRegion region = gridMat.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0)
                    return null;
                return CardboardQualityAccessor.Instance.CardboardQualityDictionary.Values.ToList()[indexes[0] - 1];
            }
        }
        private void InitializeGridDynamicBCT()
        {
            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            // views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White) { Border = cellBorder };
            //CheckboxBackColorAlternate viewNormalCheck = new CheckboxBackColorAlternate(Color.LightBlue, Color.White) { Border = cellBorder};

            // column header view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;

            // row header view
            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader backRowHeader = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewRowHeader.Background = backRowHeader;
            viewRowHeader.ForeColor = Color.Black;

            // create the grid
            gridDynamicBCT.BorderStyle = BorderStyle.FixedSingle;

            gridDynamicBCT.ColumnsCount = McKeeFormula.HumidityCoefDictionary.Count + 1;
            gridDynamicBCT.RowsCount = McKeeFormula.StockCoefDictionary.Count + 1;

            // column header
            SourceGrid.Cells.ColumnHeader columnHeader;
            int indexCol = 0;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Humidity (%)/Storage")
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridDynamicBCT[0, indexCol++] = columnHeader;

            foreach (string key in McKeeFormula.HumidityCoefDictionary.Keys)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(key)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                gridDynamicBCT[0, indexCol++] = columnHeader;
            }

            SourceGrid.Cells.RowHeader rowHeader;
            int indexRow = 1;

            foreach (string key in McKeeFormula.StockCoefDictionary.Keys)
            {
                rowHeader = new SourceGrid.Cells.RowHeader(key)
                {
                    View = viewRowHeader
                };
                gridDynamicBCT[indexRow++, 0] = rowHeader;
            }

            gridDynamicBCT.AutoStretchColumnsToFitWidth = true;
            gridDynamicBCT.AutoSizeCells();
            gridDynamicBCT.Columns.StretchToFit();
        }
        private void FillGridDynamicBCT(Dictionary<KeyValuePair<string, string>, double> dynamicBCTDictionary)
        {
            int indexCol = 1;

            // views
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
            CellColorFromValue viewNormal = new CellColorFromValue(TopLoad * 9.81 / 10)
            {
                Border = cellBorder
            }; // convert mass in kg to load in daN

            foreach (string keyHumidity in McKeeFormula.HumidityCoefDictionary.Keys)
            {
                int indexRow = 1;
                foreach (string keyStorage in McKeeFormula.StockCoefDictionary.Keys)
                {
                    gridDynamicBCT[indexRow, indexCol] = new SourceGrid.Cells.Cell(
                        string.Format("{0:0.00}", dynamicBCTDictionary[new KeyValuePair<string, string>(keyStorage, keyHumidity)]))
                    {
                        View = viewNormal
                    };
                    ++indexRow;
                }
                ++indexCol;
            }
            gridDynamicBCT.Invalidate();
        }
        #endregion

        #region Event handler
        private void OnInputChanged(object sender, EventArgs args)
        {
            FillMaterialGrid();
        }
        private void OnMaterialChanged(object sender, EventArgs args)
        {
            // fill dynamic grid
            Vector3D caseDimensions = CaseDimensions;
            QualityData qdata = SelectedMaterial;
            if (null != qdata)
                FillGridDynamicBCT(
                    McKeeFormula.EvaluateEdgeCrushTestMatrix(
                        caseDimensions.X, caseDimensions.Y, caseDimensions.Z,
                        qdata.Name, Properties.Resources.CASETYPE_AMERICANCASE, PrintSurface, McKeeFormulaType)
                    );
        }
        #endregion
    }
}
