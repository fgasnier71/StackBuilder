#region Using directives
using System;
using System.Windows.Forms;

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
        }
        #endregion

        #region Event handlers
        private void OnAddRow(object sender, System.EventArgs e)
        {
            _analysis.AddContent(GetNextPackable());
            UpdateGrid();
        }
        private Packable GetNextPackable()
        {
            Packable p = null;
            foreach (BoxProperties b in _document.Boxes)
            {
                p = b;
            }
            return p;
        }
        #endregion

        #region Data members
        protected Document _document;
        protected HAnalysis _analysis;
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
