#region Using directives
using System;
using System.Windows.Forms;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisHCylPallet
        : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisHCylPallet() : base() => InitializeComponent();
        public FormNewAnalysisHCylPallet(Document doc, AnalysisHCylPallet analysis) : base(doc, analysis) => InitializeComponent();
        #endregion

        #region IItemBaseFilter 
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCylinders)
                return itemBase is CylinderProperties;
            else if (ctrl == cbPallets)
                return itemBase is PalletProperties;
            else
                return false;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, AnalysisCast?.Content);
            cbPallets.Initialize(_document, this, AnalysisCast?.PalletProperties);

            if (null == AnalysisBase)
            {
                ItemName = _document.GetValidNewAnalysisName(ItemDefaultName);
                ItemDescription = ItemName;

                uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
                uCtrlOptMaximumWeight.Value = new OptDouble(false, Settings.Default.MaximumPalletWeight);
                uCtrlOptMaximumNumber.Value = new OptInt(false, 1);
                uCtrlOverhang.Value = new Vector2D(Settings.Default.OverhangX, Settings.Default.OverhangY);
            }
            else
            {
                ItemName = AnalysisCast.Name;
                ItemDescription = AnalysisCast.Description;

                var constraintSet = AnalysisCast.ConstraintSet as ConstraintSetCasePallet;
                uCtrlMaximumHeight.Value = constraintSet.OptMaxHeight.Value;
                uCtrlOptMaximumWeight.Value = constraintSet.OptMaxWeight;
                uCtrlOptMaximumNumber.Value = constraintSet.OptMaxNumber;
                uCtrlOverhang.Value = constraintSet.Overhang;
            }
            // event handling
            cbCylinders.SelectedIndexChanged += new EventHandler(OnCylinderChanged);
            cbPallets.SelectedIndexChanged += new EventHandler(OnInputChanged);
            uCtrlMaximumHeight.ValueChanged += new UCtrlDouble.ValueChangedDelegate(OnInputChanged);
            uCtrlOptMaximumWeight.ValueChanged += new UCtrlOptDouble.ValueChangedDelegate(OnInputChanged);
            uCtrlOptMaximumNumber.ValueChanged += new UCtrlOptInt.ValueChangedDelegate(OnInputChanged);
            uCtrlOverhang.ValueChanged += new UCtrlDualDouble.ValueChangedDelegate(OnInputChanged);

            OnInputChanged(this, null);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.MaximumPalletHeight = uCtrlMaximumHeight.Value;
            if (uCtrlOptMaximumWeight.Value.Activated)
                Settings.Default.MaximumPalletWeight = uCtrlOptMaximumWeight.Value.Value;

            Settings.Default.OverhangX = uCtrlOverhang.ValueX;
            Settings.Default.OverhangY = uCtrlOverhang.ValueY;
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion
        #region FormNewAnalysis override
        public override void UpdateStatus(string message)
        {            
            if (null == SelectedLayout) message = Resources.ID_SELECTATLEASTONELAYOUT;
            if (!Program.IsSubscribed) message = Resources.ID_PREMIUMFEATURE;
            base.UpdateStatus(message);
       }
        public override void OnNext()
        {
            try
            {
                // sanity check
                if (null == SelectedLayout)  return;

                if (null == AnalysisCast)
                    AnalysisBase = _document.CreateNewAnalysisHCylPallet(
                        ItemName, ItemDescription
                        , SelectedCylinder, SelectedPallet
                        , BuildConstraintSet()
                        , SelectedLayout
                        );
                else
                {
                    if (AnalysisCast is AnalysisHCylPallet analysisHCylPallet)
                    {
                        analysisHCylPallet.ID.SetNameDesc(ItemName, ItemDescription);
                        analysisHCylPallet.Content = SelectedCylinder;
                        analysisHCylPallet.PalletProperties = SelectedPallet;
                        analysisHCylPallet.ConstraintSet = BuildConstraintSet();
                        analysisHCylPallet.SetSolution(SelectedLayout);

                        _document.UpdateAnalysis(analysisHCylPallet);
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
        #region Event handlers
        private void OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get cylinder / case
                if (cbCylinders.SelectedType is CylinderProperties cylinder
                    && cbPallets.SelectedType is PalletProperties palletProperties)
                {
                    var layouts = CylLayoutSolver.BuildLayouts(cylinder, palletProperties, BuildConstraintSet());
                    uCtrlHCylLayoutList.Packable = cylinder;
                    uCtrlHCylLayoutList.HCylLayouts = layouts;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnCylinderChanged(object sender, EventArgs e)
        {
            uCtrlPackable.PackableProperties = cbCylinders.SelectedType as Packable;
            OnInputChanged(sender, e);
        }
        private void OnLayoutSelected(object sender, EventArgs e) => UpdateStatus(string.Empty);
        #endregion
        #region Helpers
        private ConstraintSetPackablePallet BuildConstraintSet()
        {
            var constraintSet = new ConstraintSetPackablePallet()
            {
                Overhang = Overhang,
                OptMaxWeight = MaxPalletWeight,
                OptMaxNumber = MaxNumber
            };
            constraintSet.SetMaxHeight(new OptDouble(true, MaxPalletHeight));
            constraintSet.Container = SelectedPallet;
            return constraintSet;
        }
        #endregion
        #region Private properties
        private AnalysisHCylPallet AnalysisCast
        {
            get { return _item as AnalysisHCylPallet; }
            set { _item = value; }
        }
        private CylinderProperties SelectedCylinder => cbCylinders.SelectedType as CylinderProperties;
        private PalletProperties SelectedPallet => cbPallets.SelectedType as PalletProperties;
        private HCylLayout SelectedLayout => uCtrlHCylLayoutList.Selected;
        private double MaxPalletHeight => uCtrlMaximumHeight.Value;
        private OptDouble MaxPalletWeight => uCtrlOptMaximumWeight.Value;
        private OptInt MaxNumber => uCtrlOptMaximumNumber.Value;
        private Vector2D Overhang => uCtrlOverhang.Value;
        #endregion
        #region Data members
        private ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisHCylPallet));
        #endregion
    }
}
