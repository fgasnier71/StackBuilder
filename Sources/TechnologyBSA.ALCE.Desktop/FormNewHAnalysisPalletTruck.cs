#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
using System.Linq;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisPalletTruck : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewHAnalysisPalletTruck(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion

        #region Public properties
        public AnalysisHPalletTruck AnalysisCast
        {
            get => _item as AnalysisHPalletTruck;
            set => _item = value;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbPallets.Initialize(_document, this, null != AnalysisBase ? AnalysisCast.Content[0] : null);
            cbTrucks.Initialize(_document, this, null != AnalysisBase? AnalysisCast.Containers[0] : null);

            if (null == AnalysisBase)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlMinDistanceLoadWall.ValueX = Settings.Default.MinDistancePalletTruckWallX;
                uCtrlMinDistanceLoadWall.ValueY = Settings.Default.MinDistancePalletTruckWallY;
                uCtrlMinDistanceLoadRoof.Value = Settings.Default.MinDistancePalletTruckRoof;

                PalletStackingRules = new List<PalletStackingRule>();
                InitializeStackingRule();
            }
            else
            {
                    
            }

            FillContentGrid();
            FillStackingRuleGrid();
            FillResultGrid();
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbPallets)
                return itemBase is LoadedPallet;
            else if (ctrl == cbTrucks)
                return itemBase is TruckProperties;
            return false;
        }
        #endregion

        #region Initializing
        private void InitializeStackingRule()
        { 
        }
        private void BuildPalletStacks()
        { 
        }
        #endregion

        #region Fill grids
        private void FillContentGrid()
        {
            try
            {
                // remove existing rows
                gridContent.Rows.Clear();
                // *** views
                // viewColumnHeader
                var viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
                {
                    Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                    {
                        BackColor = Color.LightGray,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder
                    },
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                var viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***
                // set first row
                gridContent.BorderStyle = BorderStyle.FixedSingle;
                gridContent.ColumnsCount = 2;
                gridContent.FixedRows = 1;

                // header
                int iCol = 0;
                gridContent.Rows.Insert(0);
                gridContent[0, iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_NAME) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_NUMBER) { AutomaticSortEnabled = false, View = viewColumnHeader };

                // content
                int iIndex = 0;
                foreach (var lpi in LoadedPalletItems)
                {
                    // insert row
                    gridContent.Rows.Insert(++iIndex);
                    iCol = 0;
                    // name
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell(lpi.PalletAnalysis.Name) { View = viewNormal, Tag = lpi.PalletAnalysis };
                    // number
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.Cell((int)lpi.Number) { View = viewNormal };
                    SourceGrid.Cells.Editors.NumericUpDown l_NumericUpDownEditor = new SourceGrid.Cells.Editors.NumericUpDown(typeof(int), 10000, 0, 1);
                    l_NumericUpDownEditor.SetEditValue((int)lpi.Number);
                    gridContent[iIndex, iCol].Editor = l_NumericUpDownEditor;
                    gridContent[iIndex, iCol].AddController(_numUpDownEvent);
                }
                gridContent.AutoSizeCells();
                gridContent.Columns.StretchToFit();
                gridContent.AutoStretchColumnsToFitWidth = true;
                gridContent.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillStackingRuleGrid()
        {
            try
            {
                // clear rows
                gridRules.Rows.Clear();
                // *** views
                // viewColumnHeader
                var viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
                {
                    Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                    {
                        BackColor = Color.LightGray,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder
                    },
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                var viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***
                // set first row
                gridRules.BorderStyle = BorderStyle.FixedSingle;
                gridRules.ColumnsCount = 5;
                gridRules.FixedRows = 1;

                // header
                int iCol = 0;
                gridRules.Rows.Insert(0);
                gridRules[0, iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_PALLET) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridRules[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_PALLETSTACKON) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridRules[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_MOVEUP) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridRules[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_MOVEDOWN) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridRules[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_DELETE) { AutomaticSortEnabled = false, View = viewColumnHeader };

                // content
                int iIndex = 0;
                foreach (var psr in PalletStackingRules)
                {
                    gridRules.Rows.Insert(++iIndex);
                    iCol = 0;
                }
                gridRules.AutoSizeCells();
                gridRules.Columns.StretchToFit();
                gridRules.AutoStretchColumnsToFitWidth = true;
                gridRules.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillResultGrid()
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Event handlers
        private void OnSingleMultiplePalletTypeChanged(object sender, EventArgs e)
        {
            cbPallets.Enabled = HomogeneousLoad;
            gridContent.Enabled = HeterogeneousLoad;
        }
        #endregion

        #region Helpers
        private List<LoadedPalletItem> LoadedPalletItems
        {
            get
            {
                List<LoadedPalletItem> loadedPalletItems = new List<LoadedPalletItem>();
                uint iCount = (uint)_document.LoadedPallets.Count();
                foreach (var analysis in _document.LoadedPallets)
                    loadedPalletItems.Add(new LoadedPalletItem(analysis as AnalysisPackablePallet, iCount));
                return loadedPalletItems;
            }
        }
        private List<PalletStackingRule> PalletStackingRules { get; set; }

        private bool HeterogeneousLoad
        { get => rbMultiPalletType.Checked; set => rbMultiPalletType.Checked = value; }
        private bool HomogeneousLoad
        { get => rbSinglePalletType.Checked; set => rbSinglePalletType.Checked = value; }
        #endregion

        #region Data members
        protected SourceGrid.Cells.Controllers.CustomEvents _numUpDownEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisPalletTruck));
        #endregion


    }
}
