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
        public FormNewAnalysisHCylPallet(Document doc, AnalysisLayered analysis) : base(doc, analysis) => InitializeComponent();
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
            cbCylinders.Initialize(_document, this, null);
            cbPallets.Initialize(_document, this, null);

            // event handling

            if (null == AnalysisBase)
            {
                ItemName = _document.GetValidNewAnalysisName(ItemDefaultName);
                ItemDescription = ItemName;

                uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
                uCtrlOptMaximumWeight.Value = new OptDouble(false, Settings.Default.MaximumPalletWeight);

                uCtrlOverhang.ValueX = Settings.Default.OverhangX;
                uCtrlOverhang.ValueY = Settings.Default.OverhangY;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.MaximumPalletWeight = uCtrlMaximumHeight.Value;
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
            base.UpdateStatus(message);
        }
        public override void OnNext()
        {
            try
            {
                SolutionHCyl.Solver = new CylLayoutSolver();

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
                    /*
                    analysis.Content = SelectedCylinder;
                    analysis.PalletProperties = SelectedPallet;
                    analysis.ConstraintSet = BuildConstraintSet();
                    analysis.Solution(SelectedLayout);
                    */

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
                    var dimContainer = new Vector3D(
                        palletProperties.Length + 2.0 * Overhang.Y,
                        palletProperties.Width + 2.0 * Overhang.Y,
                        MaxPalletHeight - palletProperties.Height);
                    // compute
                    var layouts = CylLayoutSolver.BuildLayout(cylinder, dimContainer, palletProperties.Height, BuildConstraintSet());
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
            OnHCylLayoutSelected(sender, e);
        }
        protected void OnHCylLayoutSelected(object sender, EventArgs e)
        {
            try
            {
                HCylLayout layout = uCtrlHCylLayoutList.Selected;
                UpdateStatus(null != layout ? string.Empty : Resources.ID_SELECTATLEASTONELAYOUT);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnLayoutSelected(object sender, EventArgs e)
        {
            UpdateStatus(string.Empty);
        }
        #endregion

        #region Helpers
        private AnalysisHCyl AnalysisCast
        {
            get { return _item as AnalysisHCyl; }
            set { _item = value; }
        }
        private CylinderProperties SelectedCylinder => cbCylinders.SelectedType as CylinderProperties;
        private PalletProperties SelectedPallet => cbPallets.SelectedType as PalletProperties;
        private HCylLayout SelectedLayout => uCtrlHCylLayoutList.Selected;
        private double MaxPalletHeight => uCtrlMaximumHeight.Value;
        private OptDouble MaxPalletWeight => uCtrlOptMaximumWeight.Value;
        private OptInt MaxNumber => uCtrlOptMaximumNumber.Value;
        private Vector2D Overhang => uCtrlOverhang.Value;
        private ConstraintSetPackablePallet BuildConstraintSet()
        {
            var constraintSet = new ConstraintSetPackablePallet()
            {
                Overhang = uCtrlOverhang.Value,
                OptMaxWeight = MaxPalletWeight,
                OptMaxNumber = MaxNumber
            };
            constraintSet.SetMaxHeight(new OptDouble(true, MaxPalletHeight));
            return constraintSet;
        }
        #endregion

        #region Data members
        private ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisHCylPallet));
        #endregion


    }
}
