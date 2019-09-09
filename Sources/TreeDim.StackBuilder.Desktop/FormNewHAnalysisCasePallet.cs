#region Using directives
using System;
using System.Linq;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;

using treeDiM.StackBuilder.Desktop.Properties;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisCasePallet : FormNewHAnalysis, IItemBaseFilter
    {
        #region Constructors
        public FormNewHAnalysisCasePallet(): base() => InitializeComponent();
        public FormNewHAnalysisCasePallet(Document doc, AnalysisHetero analysis): base(doc, analysis) => InitializeComponent();
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var containers = AnalysisCast?.Containers;
            ItemBase curPallet = null;
            if (null != containers && containers.Count() > 0)
                curPallet = containers.First();
            cbPallets.Initialize(_document, this, curPallet);

            uCtrlPalletHeight.Value = Settings.Default.MaximumPalletHeight;
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

        #region FormHAnalysis override
        protected override HConstraintSet ConstraintSet => new HConstraintSetPallet() { MaximumHeight = uCtrlPalletHeight.Value, Overhang = Overhang };
        protected override Vector3D DimContainer
        {
            get
            {
                var pallet = SelectedPallet;
                if (null == pallet) return Vector3D.Zero;
                return new Vector3D(pallet.Length, pallet.Width, MaximumPalletHeight - pallet.Height);
            }
        }
        protected override void LoadContainer()
        {
            base.LoadContainer();
            AnalysisCast.Pallet = SelectedPallet;
        }
        protected override void CreateNewAnalysis()
        {
            HAnalysis = _document.CreateNewHAnalysisCasePallet(
                ItemName, ItemDescription,
                ListContentItems,
                SelectedPallet,
                ConstraintSet as HConstraintSetPallet,
                SelectedSolution);
        }
        protected override AnalysisHetero IntantiateTempAnalysis()
        {
            return new HAnalysisPallet(null);
        }
        #endregion

        #region Event handlers
        private void OnDataModifiedOverride(object sender, EventArgs e)
        {
            OnDataModified(sender, e);
        }
        #endregion

        #region Public properties
        public HAnalysisPallet AnalysisCast
        {
            get { return HAnalysis as HAnalysisPallet; }
            set { HAnalysis = value; }
        }
        #endregion

        #region Helpers
        private PalletProperties SelectedPallet => cbPallets.SelectedType as PalletProperties;
        private double MaximumPalletHeight
        {
            get => uCtrlPalletHeight.Value;
            set => uCtrlPalletHeight.Value = value;
        }
        private Vector2D Overhang
        {
            get => uCtrlOverhang.Value;
            set => uCtrlOverhang.Value = value;
        }
        #endregion

        #region Data members
        new static readonly ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysisCasePallet));
        #endregion
    }
}
