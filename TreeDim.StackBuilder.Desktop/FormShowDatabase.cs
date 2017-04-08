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

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormShowDatabase : Form
    {
        #region Constructor
        public FormShowDatabase()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);


            
            
        }
        #endregion

        #region Data grid
        void FillGridPallets()
        {
            DCSBPallet[] pallets = WCFClientSingleton.Instance.Client.GetAllPallets();
            foreach (DCSBPallet p in pallets)
            {

            }
        }
        void FillGridTrucks()
        { 
            // remove all existing rows
            gridTrucks.Rows.Clear();
            // *** IViews 
            // captionHeader
            SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader();
            veHeaderCaption.BackColor = Color.SteelBlue;
            veHeaderCaption.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            captionHeader.Background = veHeaderCaption;
            captionHeader.ForeColor = Color.Black;
            captionHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // viewRowHeader
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***

            // create the grid
            gridTrucks.BorderStyle = BorderStyle.FixedSingle;

            gridTrucks.ColumnsCount = 5;
            gridTrucks.FixedRows = 1;
            gridTrucks.Rows.Insert(0);

            // header
            SourceGrid.Cells.ColumnHeader columnHeader;
            // name
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridTrucks[0, 0] = columnHeader;
            // description
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DESCRIPTION);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridTrucks[0, 1] = columnHeader;
            // dimensions
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DIMENSIONS + string.Format("({0} x {0} x {0})", "mm"));
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridTrucks[0, 2] = columnHeader;
            // autoinsert
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_AUTOIMPORT);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridTrucks[0, 3] = columnHeader;
            // delete
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DELETE);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridTrucks[0, 4] = columnHeader;

            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImportTruck);
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDelete);

            // get all trucks
            DCSBTruck[] trucks = WCFClientSingleton.Instance.Client.GetAllTrucks();
            int iIndex = 0;
            foreach (DCSBTruck t in trucks)
            {
                gridTrucks.Rows.Insert(++iIndex);
                gridTrucks[iIndex, 0] = new SourceGrid.Cells.Cell(t.Name);
                gridTrucks[iIndex, 1] = new SourceGrid.Cells.Cell(t.Description);
                gridTrucks[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0} x {1} x {2}", t.DimensionsInner.M0, t.DimensionsInner.M1, t.DimensionsInner.M2));
                gridTrucks[iIndex, 3] = new SourceGrid.Cells.CheckBox(null, true /*t.AutoImport*/);
                gridTrucks[iIndex, 3].AddController(checkBoxEvent);
                gridTrucks[iIndex, 4] = new SourceGrid.Cells.Button("");
                gridTrucks[iIndex, 4].Image = Properties.Resources.Delete;
                gridTrucks[iIndex, 4].AddController(buttonDelete);

                gridTrucks.AutoStretchColumnsToFitWidth = true;
                gridTrucks.AutoSizeCells();
                gridTrucks.Columns.StretchToFit();

                // select first solution
                if (gridTrucks.RowsCount > 1)
                    gridTrucks.Selection.SelectRow(1, true);
            }
        }
        void FillGridCases()
        { 
        }
        void FillGridCylinders()
        { 
        }
        #endregion

        #region Event handlers
        private void onSelectedTabChanged(object sender, EventArgs e)
        {
            if (string.Equals(tabCtrlDBItems.SelectedTab.Name, "tabPagePallet", StringComparison.CurrentCultureIgnoreCase))
                FillGridPallets();
            else if (string.Equals(tabCtrlDBItems.SelectedTab.Name, "tabPageTruck"))
                FillGridTrucks();
            else if (string.Equals(tabCtrlDBItems.SelectedTab.Name, "tabPageCylinders"))
                FillGridCylinders();

            
        }
        private void onImportTruck(object sender, EventArgs e)
        {
        }
        private void onAutoImportTruck(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            int iSel = context.Position.Row - 1;
            MessageBox.Show(string.Format("Selected row {0}", iSel));
        }
        private void onDelete(object sender, EventArgs e)
        {        
            SourceGrid.CellContext context = (SourceGrid.CellContext) sender;
            int iSel = context.Position.Row - 1;
            MessageBox.Show(string.Format("Selected row {0}", iSel));
        }

        private void onImportCase(object sender, EventArgs e)
        { 
        }
        private void onImportInterlayer(object sender, EventArgs e)
        { 
        }
        private void onImportBundle(object sender, EventArgs e)
        {        
        }
        #endregion



        #region Data members
        #endregion
    }
}
