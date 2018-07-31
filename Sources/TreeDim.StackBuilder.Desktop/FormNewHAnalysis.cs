#region Using directives
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysis : Form
    {
        #region Constructor
        public FormNewHAnalysis()
        {
            InitializeComponent();
        }
        public FormNewHAnalysis(Document doc, HAnalysis analysis)
        {
            InitializeComponent();
            _document = doc;
            _analysis = analysis;

            if (null != _analysis)
                _contentItems = _analysis.Content as List<ContentItem>;
            else
                _contentItems = new List<ContentItem>();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateGrid();
        }
        #endregion

        #region Content grid
        private void UpdateGrid()
        {
            try
            {
                // remove existing rows
                gridContent.Rows.Clear();
                // caption header
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
                // viewRowHeader
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
                gridContent.BorderStyle = BorderStyle.FixedSingle;
                gridContent.ColumnsCount = 2;
                gridContent.FixedRows = 1;
                gridContent.Rows.Insert(0);
                // header
                int iCol = 0;
                SourceGrid.Cells.ColumnHeader columnHeader;
                columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                gridContent[0, iCol++] = columnHeader;
                columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NUMBER)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                gridContent[0, iCol++] = columnHeader;
                // content
                int iIndex = 0;
                foreach (ContentItem ci in _contentItems)
                {
                    // insert row
                    gridContent.Rows.Insert(++iIndex);
                    iCol = 0;
                    // name
                    gridContent[iIndex, iCol++] = new SourceGrid.Cells.Cell(ci.Pack.Name);
                    // number
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell("NumericUpDown")
                    {
                        View = viewNormal
                    };
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell(ci.Number);
                    SourceGrid.Cells.Editors.NumericUpDown l_NumericUpDownEditor = new SourceGrid.Cells.Editors.NumericUpDown(typeof(int), 50, -50, 1);
                    gridContent[iIndex, iCol].Editor = l_NumericUpDownEditor;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Event handlers
        private void OnAddRow(object sender, System.EventArgs e)
        {
            try
            {
                Packable p = GetNextPackable();
                if (null != p)
                    _contentItems.Add( new ContentItem( p, 1) );
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            UpdateGrid();
        }
        private Packable GetNextPackable()
        {
            Packable p = null;
            foreach (BoxProperties b in _document.Cases)
            {
                if (!ContentItemsContainsPackable(b))
                    p = b;
                break;
            }
            return p;
        }
        private bool ContentItemsContainsPackable(Packable p)
        {
            return (null != _contentItems.Find(ci => ci.Pack == p));
        }
        #endregion

        #region Data members
        protected Document _document;
        protected HAnalysis _analysis;
        protected List<ContentItem> _contentItems;
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysis));
        #endregion
    }
}

/*
    public partial class FormNewHAnalysisPalletisation : FormNewHAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewHAnalysisPalletisation(Document doc, HAnalysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //cbPallets.Initialize(_document, this, AnalysisCast?.Containers.FirstOrDefault());
        }
        #endregion

        #region ItemBaseFilter override
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            
            if (ctrl == cbPallets)
            {
            }
            
            return false;
        }
        #endregion

        #region Event handlers
        private void OnInputChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnCaseAdded(object sender, EventArgs e)
        {

        }
        #endregion

        #region Public properties
        public HAnalysis AnalysisCast
        {
            get { return _analysis as HAnalysis; }
            set { _analysis = value; }
        }
        #endregion

        #region Helpers
        private List<BoxProperties> BuildListOfCases()
        {
            List<BoxProperties> listCases = new List<BoxProperties>();
            return listCases;
        }
        #endregion

        #region Data members
        static new readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisPalletisation));
        #endregion
    }
*/ 
