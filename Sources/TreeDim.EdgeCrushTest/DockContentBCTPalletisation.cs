#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

using log4net;
using Sharp3D.Math.Core;
using WeifenLuo.WinFormsUI.Docking;

using treeDiM.Basics;
using treeDiM.EdgeCrushTest.Properties;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class DockContentBCTPalletisation : DockContent, IDrawingContainer
    {
        #region Constructor
        public DockContentBCTPalletisation()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            graphCtrl.DrawingContainer = this;

            try
            {
                // initialize dimensions load
                CaseDimensions = new Vector3D(Settings.Default.CaseDimX, Settings.Default.CaseDimY, Settings.Default.CaseDimZ);
                CaseWeight = Settings.Default.CaseWeight;
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
                
                // fill pallet combo
                FillPalletCombo();

                // fill material grid
                FillMaterialGrid();
                gridMat.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(OnMaterialChanged);
                OnMaterialChanged(this, null);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.CaseDimX = CaseDimensions.X;
            Settings.Default.CaseDimY = CaseDimensions.Y;
            Settings.Default.CaseDimZ = CaseDimensions.Z;
            Settings.Default.CaseWeight = CaseWeight;
        }
        #endregion
        #region Private properties
        private Vector3D CaseDimensions
        {
            get => uCtrlCaseDimensions.Value;
            set => uCtrlCaseDimensions.Value = value;
        }
        private double CaseWeight
        {
            get => uCtrlCaseWeight.Value;
            set => uCtrlCaseWeight.Value = value;
        }
        private bool IsDoubleWall
        {
            get => chkbDblWall.Checked;
            set => chkbDblWall.Checked = value;
        }
        private McKeeFormula.FormulaType McKeeFormulaType
        {
            get => tsCBMcKeeFormula.SelectedIndex == 0 ? McKeeFormula.FormulaType.MCKEE_CLASSIC : McKeeFormula.FormulaType.MCKEE_IMPROVED;
            set => tsCBMcKeeFormula.SelectedIndex = (value == McKeeFormula.FormulaType.MCKEE_CLASSIC ? 0 : 1);
        }
        private int ActualNoLayers
        {
            get => uCtrlNoLayers.Value;
            set => uCtrlNoLayers.Value = value;
        }
        private double ActualLoad => (ActualNoLayers - 1) * CaseWeight * 9.81;
        private string PrintSurface => McKeeFormula.PrintCoefDictionary.Keys.ToList()[cbPrintedArea.SelectedIndex];

        private int StackCount { set => lbStackCount.Text = $": {value}"; }
        private double StackWeight { set => lbStackWeight.Text = $": {value} kg"; }
        private int CountMax { set => lbCountMax.Text = $"(Max. = {value})"; }
        private double LoadBottomCase { set => lbWeightLowestCase.Text = $": {value} kg"; }
        private double PalletHeight
        {
            get
            {
                if ((cbPallets.SelectedItem is PalletItem palletItem))
                    return palletItem.PalletProp.Dimensions.M2;
                else
                    return 0.0;
            }
        }
        private double MaximumPalletHeight => PalletHeight + ActualNoLayers * CaseDimensions.Z;
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
        private double StaticBCT
        {
            get
            {
                QualityData qdata = SelectedMaterial;
                return qdata.ComputeStaticBCT(
                                CaseDimensions, Resources.CASETYPE_AMERICANCASE, IsDoubleWall,
                                McKeeFormulaType);
            }
        }
        #endregion
        #region Fill pallet combo
        private void FillPalletCombo()
        {
            var pallets = PalletAccessor.Instance.GetAllPallets();
            foreach (var p in pallets)
                cbPallets.Items.Add(new PalletItem(p));
            if (cbPallets.Items.Count > 0)
                cbPallets.SelectedIndex = 0;
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
            gridMat.ColumnsCount = 6;
            gridMat.FixedRows = 1;
            gridMat.Rows.Insert(0);
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
            // maximum number of layers
            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_MAXLAYERCOUNT)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            gridMat[0, iCol++] = columnHeader;

            // ROWS
            var viewNormal = CellBackColorAlternate.ViewAliceBlueWhite;
            Vector3D dim = CaseDimensions;
            int iIndex = 0;
            var listQuality = CardboardQualityAccessor.Instance.GetFilteredListCardboardQuality(Profile);
            foreach (var q in listQuality)
            {
                var quality = q;
                double staticBCT = McKeeFormula.ComputeStaticBCT(
                    dim.X, dim.Y, dim.Z, Resources.CASETYPE_AMERICANCASE, IsDoubleWall
                    , q, McKeeFormulaType);
                int layerCount = (int)Math.Floor(staticBCT / (9.81 * CaseWeight)) + 1;

                iCol = 0;
                gridMat.Rows.Insert(++iIndex);
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Name) { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell(quality.Profile) { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.Thickness:0.##}") { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{quality.ECT:0.##}") { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{staticBCT:0.##}") { View = viewNormal };
                gridMat[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{layerCount}") { View = viewNormal };
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
                return CardboardQualityAccessor.Instance.GetFilteredListCardboardQuality(Profile)[indexes[0] - 1];
            }
        }
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
        private void FillGridDynamicBCT(Dictionary<KeyValuePair<string, string>, double> dynamicBCTDictionary)
        {
            int indexCol = 1;

            // views
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
            CellColorFromValue viewNormal = new CellColorFromValue(ActualLoad * 9.81 / 10)
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
        private void OnEditMaterialList(object sender, EventArgs e)
        {
            ECT_Forms.EditMaterialList();
        }
        private void OnInputChanged(object sender, EventArgs args)
        {
            FillMaterialGrid();
        }
        private void OnMaterialChanged(object sender, EventArgs args)
        {
            // compute max layer count from static BCT
            QualityData qdata = SelectedMaterial;
            if (null == qdata) return;
            Vector3D caseDim = CaseDimensions;
            double staticBCT = qdata.ComputeStaticBCT(caseDim, Resources.CASETYPE_AMERICANCASE, IsDoubleWall, McKeeFormulaType);
            int layerCount = (int)Math.Floor(staticBCT / (9.81 * CaseWeight)) + 1;
            // display actual number of layers
            uCtrlNoLayers.Maximum = layerCount;
            CountMax = layerCount;
            ActualNoLayers = layerCount;
        }
        private void OnComputeDynamicBCT(object sender, EventArgs e)
        {
            FillGridDynamicBCT();
        }
        private void OnReport(object sender, EventArgs e)
        {
            try
            {
                // Analysis
                SolverCasePallet solver = new SolverCasePallet(CaseProperties, PalletProperties, ConstraintSet);
                List<AnalysisLayered> analyses = solver.BuildAnalyses(false);
                Analysis analysis = analyses.Count > 0 ? analyses[0] : null;

                // build list of BCT
                QualityData qdata = SelectedMaterial;
                Vector3D caseDim = CaseDimensions;
                var dynBCTmatrix = McKeeFormula.EvaluateEdgeCrushTestMatrix(
                        caseDim.X, caseDim.Y, caseDim.Z,
                        Resources.CASETYPE_AMERICANCASE, IsDoubleWall, PrintSurface,
                        qdata, McKeeFormulaType);
                List<DynamicBCTRow> listBCTRows = new List<DynamicBCTRow>();
                foreach (var keyStorage in McKeeFormula.StockCoefDictionary.Keys)
                {
                    List<double> values = new List<double>();
                    foreach (var keyHumidity in McKeeFormula.HumidityCoefDictionary.Keys)
                        values.Add(dynBCTmatrix[new KeyValuePair<string, string>(keyStorage, keyHumidity)]);
                    listBCTRows.Add(new DynamicBCTRow() { Name = keyStorage, Values = values });
                }
                // build report data 
                var reportData = new ReportDataPackStress()
                {
                    Author = CardboardQualityAccessor.Instance.UserName,
                    McKeeFormulaType = (int)McKeeFormulaType,
                    Box = CaseProperties,
                    Mat = new Material()
                    {
                        Name = qdata.Name,
                        Profile = qdata.Profile,
                        Thickness = qdata.Thickness,
                        ECT = qdata.ECT,
                        RigidityDX = qdata.RigidityDX,
                        RigidityDY = qdata.RigidityDY
                    },
                    StaticBCT = StaticBCT,
                    Analysis = analysis,
                    BCTRows = listBCTRows 
                };
                using (var form = new FormReportDesign(reportData))
                    form.ShowDialog();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion
        #region Palletisation computation
        private BoxProperties CaseProperties
        {
            get
            {
                // build BoxProperties
                Vector3D caseDim = CaseDimensions;
                var bProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
                {
                    TapeWidth = new OptDouble(true, 50.0),
                    TapeColor = Color.LightGray
                };
                bProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
                bProperties.SetWeight(CaseWeight);
                return bProperties;
            }
        }
        private PalletProperties PalletProperties
        {
            get
            {
                // build pallet properties
                if (!(cbPallets.SelectedItem is PalletItem palletItem)) return null;
                var dcsbPallet = palletItem.PalletProp;

                return new PalletProperties(null,
                    dcsbPallet.PalletType,
                    dcsbPallet.Dimensions.M0, dcsbPallet.Dimensions.M1, dcsbPallet.Dimensions.M2)
                {
                    Weight = dcsbPallet.Weight
                };
            }
        }
        private ConstraintSetCasePallet ConstraintSet
        {
            get
            {
                // build constraint set
                var constraintSet = new ConstraintSetCasePallet() { Overhang = uCtrlOverhang.Value };
                constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
                constraintSet.SetMaxHeight(new OptDouble(true, MaximumPalletHeight));
                return constraintSet;
            }
        }
        private void OnComputePalletization(object sender, EventArgs e)
        {
            // reinit solution
            Sol = null;
            try
            {
                // solve
                SolverCasePallet solver = new SolverCasePallet(CaseProperties, PalletProperties, ConstraintSet);
                List<AnalysisLayered> analyses = solver.BuildAnalyses(false);
                if (analyses.Count > 0)
                {
                    AnalysisLayered analysis = analyses[0];
                    Sol = analysis.SolutionLay;
                    StackCount = analysis.Solution.ItemCount;
                    StackWeight = analysis.Solution.Weight;
                    LoadBottomCase = analysis.SolutionLay.LoadOnLowestCase;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            // update graph control
            graphCtrl.Invalidate();
            // uodate dynamic BCT
            FillGridDynamicBCT();
        }
        #endregion
        #region Fill grid dynamic BCT

        private void FillGridDynamicBCT()
        {
            Vector3D caseDim = CaseDimensions;
            QualityData qdata = SelectedMaterial;
            if (null != qdata)
                FillGridDynamicBCT(
                    McKeeFormula.EvaluateEdgeCrushTestMatrix(
                        caseDim.X, caseDim.Y, caseDim.Z,
                        Resources.CASETYPE_AMERICANCASE, IsDoubleWall, PrintSurface,
                        qdata, McKeeFormulaType)
                    );
        }
        #endregion
        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == Sol) return;
            using (ViewerSolution sv = new ViewerSolution(Sol))
            { sv.Draw(graphics, Transform3D.Identity); }
        }
        #endregion
        #region Data members
        private SolutionLayered Sol { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(DockContentBCTPalletisation));
        #endregion
    }
}
