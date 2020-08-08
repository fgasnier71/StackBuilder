#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

using log4net;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
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
            }
            else
            {
                
            }
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

        #region FillGrid
        private void FillGrid()
        {
            // remove existing rows
            gridPallets.Rows.Clear();
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
            gridPallets.BorderStyle = BorderStyle.FixedSingle;
            gridPallets.ColumnsCount = 3;
            gridPallets.FixedRows = 1;

            // header
            int iCol = 0;
            gridPallets.Rows.Insert(0);
            gridPallets[0, iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_NAME) { AutomaticSortEnabled = false, View = viewColumnHeader };
            gridPallets[1, iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_NUMBER) { AutomaticSortEnabled = false, View = viewColumnHeader };
            gridPallets[2, iCol] = new SourceGrid.Cells.ColumnHeader(Resources.ID_MULTIPLELAYER) { AutomaticSortEnabled = false, View = viewColumnHeader };




        }
        #endregion

        #region Data members
        private static readonly ILog Log = LogManager.GetLogger(typeof(FormNewHAnalysisPalletTruck));
        #endregion
    }
}
