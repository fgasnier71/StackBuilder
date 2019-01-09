#region Using directives
using System;
using System.Linq;
using System.Windows.Forms;

using log4net;
using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisCaseTruck : FormNewHAnalysis, IItemBaseFilter
    {
        public FormNewHAnalysisCaseTruck()
            : base()
        {
            InitializeComponent();
        }
        public FormNewHAnalysisCaseTruck(Document doc, AnalysisHetero analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var containers = AnalysisCast?.Containers;
            ItemBase curTruck = null;
            if (null != containers && containers.Count() > 0)
                curTruck = containers.First();
            cbTrucks.Initialize(_document, this, curTruck);
        }
        #endregion


        #region ItemBaseFilter override
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbTrucks)
                return itemBase is TruckProperties;
            return false;
        }
        #endregion

        #region FormHAnalysis override
        protected override HConstraintSet ConstraintSet => new HConstraintSetTruck();
        protected override Vector3D DimContainer
        {
            get
            {
                var truck = SelectedTruck;
                return null != truck ? truck.InsideDimensions : Vector3D.Zero;
            }
        }
        protected override void LoadContainer()
        {
            base.LoadContainer();
            AnalysisCast.Truck = SelectedTruck;
        }
        protected override void CreateNewAnalysis()
        {
            _analysis = _document.CreateNewHAnalysisCaseTruck(
                ItemName, ItemDescription,
                ListContentItems,
                SelectedTruck,
                ConstraintSet as HConstraintSetTruck,
                SelectedSolution);
        }
        protected override AnalysisHetero IntantiateTempAnalysis()
        {
            return new HAnalysisTruck(_document);
        }
        #endregion

        #region EventHandlers
        private void OnDataModifiedOverride(object sender, EventArgs e)
        {
            OnDataModified(sender, e);
        }
        #endregion

        #region Protected properties
        protected HAnalysisTruck AnalysisCast
        {
            get { return _analysis as HAnalysisTruck; }
            set { _analysis = value; }
        }
        #endregion

        #region Helpers
        private TruckProperties SelectedTruck => cbTrucks.SelectedType as TruckProperties;
        #endregion

        #region Data members
        new static readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisCaseTruck));
        #endregion
    }
}
