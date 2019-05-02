#region Using directives
using System;
using System.Windows.Forms;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion


namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisBoxCase : FormNewHAnalysis, IItemBaseFilter
    {
        public FormNewHAnalysisBoxCase()
            : base()
        {
            InitializeComponent();
        }
        public FormNewHAnalysisBoxCase(Document doc, AnalysisHetero analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var containers = AnalysisCast?.Containers;
        }
        #endregion

        #region ItemBaseFilter override
        public bool Accept(Control ctrl, ItemBase item)
        {
            return true;
        }
        #endregion

        #region FormHAnalysis override
        protected override HConstraintSet ConstraintSet => new HConstraintSetCase(SelectedCase) { };
        protected override Vector3D DimContainer
        {
            get
            {
                var caseProperties = SelectedCase;
                if (null == caseProperties) return Vector3D.Zero;
                return caseProperties.InsideDimensions;
            }
        }
        #endregion

        #region Public properties
        public HAnalysisCase AnalysisCast
        {
            get { return _analysis as HAnalysisCase; }
            set { _analysis = value; }
        }
        #endregion

        #region Helpers
        private BoxProperties SelectedCase => null;
        #endregion

        #region Data members
        new static readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisBoxCase));
        #endregion
    }
}
