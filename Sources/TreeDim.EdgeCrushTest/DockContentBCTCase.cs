#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using log4net;
using WeifenLuo.WinFormsUI.Docking;
using Sharp3D.Math.Core;
using SourceGrid;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.EdgeCrushTest.Properties;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class DockContentBCTCase : DockContent, IDrawingContainer
    {
        #region Constructor
        public DockContentBCTCase()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                // initialize dimensions load
                CaseDimensions = new Vector3D(Settings.Default.CaseDimX, Settings.Default.CaseDimY, Settings.Default.CaseDimZ);
                ForceApplied = Settings.Default.ForceApplied;
                McKeeFormulaType = McKeeFormula.FormulaType.MCKEE_CLASSIC;

                // fill profile combo
                tsCBProfile.Items.Add("All");
                tsCBProfile.Items.AddRange(CardboardQualityAccessor.Instance.GetProfileList().ToArray());
                tsCBProfile.SelectedIndex = 0;

                // initialize dynamic BCT grid
                InitializeGridDynamicBCT();

                // fill printed combo
                cbPrintedArea.Items.AddRange(McKeeFormula.PrintCoefDictionary.Keys.ToArray());
                cbPrintedArea.SelectedIndex = 0;

                // fill material grid
                FillMaterialGrid();
                gridMat.Selection.SelectionChanged += new RangeRegionChangedEventHandler(OnMaterialChanged);

                // initialize graphCtrl
                graphCtrl.DrawingContainer = this;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.CaseDimX = CaseDimensions.X;
            Settings.Default.CaseDimY = CaseDimensions.Y;
            Settings.Default.CaseDimZ = CaseDimensions.Z;
            Settings.Default.CaseWeight = ForceApplied;
        }
        #endregion
        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            try
            {
                BoxProperties bProperties = new BoxProperties(null, CaseDimensions.X, CaseDimensions.Y, CaseDimensions.Z)
                {
                    TapeColor = Color.LightGray,
                    TapeWidth = new OptDouble(true, 50.0)
                };
                bProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
                graphics.AddBox(new Box(0, bProperties));
                graphics.AddDimensions(new DimensionCube(CaseDimensions.X, CaseDimensions.Y, CaseDimensions.Z));
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion
        #region Fill material grid
        private void FillMaterialGrid()
        {
            // remove all existing rows
            gridMat.Rows.Clear();
            gridMat.Selection.EnableMultiSelection = false;
            // view column header
            var viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
            {
                Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                {
                    BackColor = Color.LightGray,
                    Border = DevAge.Drawing.RectangleBorder.NoBorder
                },
                ForeColor = Color.Black,
                Font = new Font("Arial", 9, FontStyle.Regular),
                TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            };
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // set first row
            gridMat.BorderStyle = BorderStyle.FixedSingle;
            gridMat.ColumnsCount = 5;
            gridMat.FixedRows = 1;
            gridMat.Rows.Insert(0);
            gridMat.Rows[0].Height = 20;
            // header
            int iCol = 0;
            SourceGrid.Cells.ColumnHeader columnHeader;
            // name
            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_NAME)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // profile
            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_PROFILE)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // thickness
            columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Resources.ID_THICKNESS_WU, UnitsManager.LengthUnitString))
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // ECT
            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_ECT)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
            // BCT
            columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Resources.ID_STATICBCT_WU, UnitsManager.ForceUnitString))
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;
                       
            int iIndex = 0;
            Vector3D dim = CaseDimensions;

            // ROWS
            var viewNormal = CellBackColorAlternate.ViewAliceBlueWhite;
            _materialQualities = CardboardQualityAccessor.Instance.GetSortedListCardboardQuality(
                dim, Resources.CASETYPE_AMERICANCASE, IsDoubleWall, McKeeFormulaType, Profile, true, ForceApplied);
            foreach (var q in _materialQualities)
            {
                gridMat.Rows.Insert(++iIndex);
                iCol = 0;

                var quality = q;
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Name) { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Profile) { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.Thickness:0.##}") { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.ECT}") { View = viewNormal };
                double staticBCT = quality.ComputeStaticBCT(
                    dim, Resources.CASETYPE_AMERICANCASE, IsDoubleWall
                    , McKeeFormulaType);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{staticBCT:0.##}");
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
        #endregion
        #region Fill grid dynamic BCT
        private void InitializeGridDynamicBCT()
        {
            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

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
        private void FillGridDynamicBCT()
        {
            Vector3D caseDim = CaseDimensions;
            QualityData qdata = SelectedMaterial;
            if (null != qdata)
                FillGridDynamicBCT(
                    McKeeFormula.EvaluateEdgeCrushTestMatrix(
                        caseDim.X, caseDim.Y, caseDim.Z, Resources.CASETYPE_AMERICANCASE, IsDoubleWall, PrintSurface,
                        qdata,
                        McKeeFormulaType)
                    );

        }
        private void FillGridDynamicBCT(Dictionary<KeyValuePair<string, string>, double> dynamicBCTDictionary)
        {
            int indexCol = 1;

            // views
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
            CellColorFromValue viewNormal = new CellColorFromValue(ForceApplied * 9.81 / 10)
            {
                Border = cellBorder
            };
            // convert mass in kg to load in daN

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
        #region Event handlers
        private void OnInputChanged(object sender, EventArgs args)
        {
            graphCtrl.Invalidate();
            FillMaterialGrid();
        }
        private void OnMaterialChanged(object sender, RangeRegionChangedEventArgs e)
        {
            // compute max layer count from static BCT
            QualityData qdata = SelectedMaterial;
            if (null == qdata) return;
            Vector3D caseDim = CaseDimensions;
            double staticBCT = qdata.ComputeStaticBCT(
                caseDim, Resources.CASETYPE_AMERICANCASE, IsDoubleWall,
                McKeeFormulaType);
            FillGridDynamicBCT();
        }
        private void OnComputeDynamicBCT(object sender, EventArgs e)
        {
            FillGridDynamicBCT();
        }
        private void OnReport(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Not implemented!");
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion
        #region Private properties
        private Vector3D CaseDimensions
        {
            get => uCtrlCaseDimensions.Value;
            set => uCtrlCaseDimensions.Value = value;
        }
        private bool IsDoubleWall
        {
            get => chkbDblWall.Checked;
            set => chkbDblWall.Checked = value;
        }
        private double ForceApplied
        {
            get => uCtrlForceApplied.Value;
            set => uCtrlForceApplied.Value = value;
        }
        private McKeeFormula.FormulaType McKeeFormulaType
        {
            get => tsCBMcKeeFormula.SelectedIndex == 0 ? McKeeFormula.FormulaType.MCKEE_CLASSIC : McKeeFormula.FormulaType.MCKEE_IMPROVED;
            set => tsCBMcKeeFormula.SelectedIndex = (value == McKeeFormula.FormulaType.MCKEE_CLASSIC ? 0 : 1);
        }
        private QualityData SelectedMaterial
        {
            get
            {
                RangeRegion region = gridMat.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0)
                    return null;
                return _materialQualities[indexes[0] - 1];
            }
        }
        private string PrintSurface => McKeeFormula.PrintCoefDictionary.Keys.ToList()[cbPrintedArea.SelectedIndex];
        private string Profile
        {
            get
            {
                int iSel = tsCBProfile.SelectedIndex;
                if (iSel < 1)
                    return string.Empty;
                else
                    return tsCBProfile.Items[iSel].ToString();
            }
        }
        #endregion
        #region Data members
        private List<QualityData> _materialQualities;
        protected ILog _log = LogManager.GetLogger(typeof(DockContentBCTCase));
        #endregion


    }
}
