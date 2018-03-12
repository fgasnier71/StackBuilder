#region Using directives
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
        
        #region Data members
        protected Document _document;
        protected HAnalysis _analysis;
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysis));
        #endregion
    }
}
