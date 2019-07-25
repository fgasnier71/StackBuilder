#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

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

            FillGrid();
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
            get => uCtrlLoad.Value;
            set => uCtrlLoad.Value = value;
        }
        #endregion

        #region FillGrid
        private void FillGrid()
        {
            // remove all existing rows
            gridMat.Rows.Clear();
            // caption header
            var captionHeader = new SourceGrid.Cells.Views.RowHeader()
            {
                Background = new DevAge.Drawing.VisualElements.RowHeader()
                {
                    BackColor = Color.SteelBlue,
                    Border = DevAge.Drawing.RectangleBorder.NoBorder
                },
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            };
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

            foreach (var q in dictQuality)
            {
                gridMat.Rows.Insert(++iIndex);
                iCol = 0;

                var quality = q.Value;
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Name);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Profile);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.Thickness:0.##}");

                double staticBCT = McKeeFormula.ComputeStaticBCT(dim.X, dim.Y, dim.Z, q.Key, Properties.Resources.CASETYPE_AMERICANCASE, McKeeFormula.FormulaType.MCKEE_IMPROVED);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{staticBCT:0.##}");
            }
            gridMat.AutoStretchColumnsToFitWidth = true;
            gridMat.AutoSizeCells();
            gridMat.Columns.StretchToFit();
        }
        #endregion
    }
}
