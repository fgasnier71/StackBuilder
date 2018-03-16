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
