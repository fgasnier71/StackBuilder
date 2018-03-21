#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;

using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisCasePallet : FormNewHAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewHAnalysisCasePallet()
            : base()
        {
            InitializeComponent();
        }
        public FormNewHAnalysisCasePallet(Document doc, HAnalysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbPallets.Initialize(_document, this, AnalysisCast?.Containers.First());
            if (null == AnalysisCast)
                uCtrlPalletHeight.Value = Settings.Default.MaximumPalletHeight;
            else
                uCtrlPalletHeight.Value = AnalysisCast.ConstraintSet.MaximumPalletHeight;
        }
        #endregion

        #region ItemBaseFilter override
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbPallets)
                return itemBase is PalletProperties;
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
        public HAnalysisPallet AnalysisCast
        {
            get { return _analysis as HAnalysisPallet; }
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
        static new readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisCasePallet));
        #endregion
    }
}
