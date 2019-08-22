#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class FormPalletsDatabase : Form, IDrawingContainer
    {
        #region Using directives
        public FormPalletsDatabase()
        {
            InitializeComponent();
        }
        #endregion

        #region Implement IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == _selectedItem)
                return;
            // get unit system
            UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)_selectedItem.UnitSystem;
            // pallet
            if (_selectedItem is DCSBPallet dcsbPallet)
            {
                double palletLength = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M0, us);
                double palletWidth = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M1, us);
                double palletHeight = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M2, us);

                PalletProperties palletProperties = new PalletProperties(null, dcsbPallet.PalletType, palletLength, palletWidth, palletHeight)
                {
                    Color = Color.FromArgb(dcsbPallet.Color)
                };
                Pallet pallet = new Pallet(palletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
                graphics.AddDimensions(new DimensionCube(palletLength, palletWidth, palletHeight));
            }
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.DrawingContainer = this;

            gridPallets.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(OnSelChangeGrid);

            // update grid
            RangeIndex = 0;
            UpdateGrid();
        }
        #endregion

        #region Grid
        private void UpdateGrid()
        {
            try
            {
                _numberOfItems = 0;
                using (var wcfClient = new WCFClient())
                    FillGridPallets(wcfClient);
                UpdateButtons();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillGridPallets(WCFClient wcfClient)
        {
            // initialize grid
            List<string> captions = new List<string>
            {
                string.Format(Properties.Resources.ID_DIMENSIONS, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)),
                string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS))
            };
            GridInitialize(gridPallets, captions);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(OnDeleteItem);

            _pallets = wcfClient.Client.GetAllPalletsSearch(SearchString, SearchDescription, RangeIndex, ref _numberOfItems, false);
            int iIndex = 0;
            foreach (DCSBPallet p in _pallets)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)p.UnitSystem;

                gridPallets.Rows.Insert(++iIndex);
                int iCol = 0;
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(p.Name);
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(p.Description);
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M0, us),
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M1, us),
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M2, us))
                    );
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                       string.Format("{0:0.###}", UnitsManager.ConvertMassFrom(p.Weight, us))
                    );
                gridPallets[iIndex, iCol] = new SourceGrid.Cells.Button("") { Image = Properties.Resources.Delete };
                gridPallets[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridPallets);
        }

        private void GridInitialize(SourceGrid.Grid grid, List<string> captions)
        {
            // remove all existing rows
            grid.Rows.Clear();
            // *** IViews 
            // captionHeader
            SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.SteelBlue,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            captionHeader.Background = veHeaderCaption;
            captionHeader.ForeColor = Color.Black;
            captionHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // viewColumnHeader
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***
            // set first row
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 4 + captions.Count;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);
            // header
            int iCol = 0;
            SourceGrid.Cells.ColumnHeader columnHeader;
            // name
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
            // description
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DESCRIPTION)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
            // listed captions
            foreach (string s in captions)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(s)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                grid[0, iCol++] = columnHeader;
            }
            // delete
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DELETE)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
        }
        private void GridFinalize(SourceGrid.Grid grid)
        {
            grid.AutoStretchColumnsToFitWidth = true;
            grid.AutoSizeCells();
            grid.Columns.StretchToFit();

            // select first solution
            if (grid.RowsCount > 1)
                grid.Selection.SelectRow(1, true);
            else
            {
                // grid empty -> clear drawing
                _selectedItem = null;
                graphCtrl.Invalidate();
            }
        }
        private void OnSelChangeGrid(object sender, EventArgs e)
        {
            try
            {
                SourceGrid.Selection.RowSelection select = sender as SourceGrid.Selection.RowSelection;
                SourceGrid.Grid g = select.Grid as SourceGrid.Grid;

                SourceGrid.RangeRegion region = g.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                if (indexes.Length < 1 || indexes[0] < 1)
                    _selectedItem = null;
                else
                {
                    int iSel = indexes[0] - 1;
                    if (g == gridPallets) _selectedItem = _pallets[iSel];
                }
                graphCtrl.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Event handlers
        private void OnAddNewPallet(object sender, EventArgs e)
        {
            try
            {
                var pallets = new List<DCSBPallet>();
                pallets.AddRange(_pallets);
                FormNewPallet form = new FormNewPallet()
                {
                    PalletNames = pallets.Select(p => p.Name).ToList()
                };
                if (DialogResult.OK == form.ShowDialog())
                {
                    using (var wcfClient = new WCFClient())
                        FillGridPallets(wcfClient);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnDeleteItem(object sender, EventArgs e)
        {
            try
            {
                SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
                int iSel = context.Position.Row - 1;
                SourceGrid.Grid g = context.Grid as SourceGrid.Grid;

                using (WCFClient wcfClient = new WCFClient())
                {
                    if (g == gridPallets)
                    {
                        wcfClient.Client.RemoveItemById(DCSBTypeEnum.TPallet, _pallets[iSel].ID);
                        FillGridPallets(wcfClient);
                    }
                }
                UpdateButtons();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void UpdateButtons()
        {
            // update buttons
            bnPrev.Enabled = RangeIndex > 0;
            bnNext.Enabled = (RangeIndex + 1) * 20 < _numberOfItems;
            lbCount.Text = string.Format(Properties.Resources.ID_DATABASEITEMCOUNT
                , (RangeIndex * 20) + 1
                , Math.Min((RangeIndex + 1) * 20, _numberOfItems)
                , _numberOfItems);
        }
        #endregion

        #region Private properties
        private int RangeIndex { get; set; }
        private string SearchString => string.Empty;
        private bool SearchDescription => false;
        #endregion

        #region Data members
        private ILog _log = LogManager.GetLogger(typeof(FormPalletsDatabase));
        private DCSBItem _selectedItem;
        private int _numberOfItems = 0;

        private DCSBPallet[] _pallets = null;
        #endregion
    }
}
