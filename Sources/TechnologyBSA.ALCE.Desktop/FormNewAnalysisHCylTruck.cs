#region Using directives
using System;
using System.Windows.Forms;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Engine;

using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisHCylTruck
        : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructors
        public FormNewAnalysisHCylTruck() : base() => InitializeComponent();
        public FormNewAnalysisHCylTruck(Document doc, AnalysisHCylTruck analysis) : base(doc, analysis) => InitializeComponent();
        #endregion

        #region IItemBaseFilter
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCylinders)
                return itemBase is CylinderProperties;
            else if (ctrl == cbTrucks)
                return itemBase is TruckProperties;
            else
                return false;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, AnalysisCast?.Content);
            cbTrucks.Initialize(_document, this, AnalysisCast?.TruckProperties);

            // event handling
            if (null == AnalysisBase)
            {
                ItemName = _document.GetValidNewAnalysisName(ItemDefaultName);
                ItemDescription = ItemName;

                uCtrlOptMaximumNumber.Value = new treeDiM.Basics.OptInt(false, 1);
                uCtrlMinDistanceLoadWall.ValueX = Settings.Default.MinDistancePalletTruckWallX;
                uCtrlMinDistanceLoadWall.ValueY = Settings.Default.MinDistancePalletTruckWallY;
                uCtrlMinDistanceLoadRoof.Value = Settings.Default.MinDistancePalletTruckRoof;
            }
            else
            {
                tbName.Text = AnalysisBase.Name;
                tbDescription.Text = AnalysisBase.Description;

                ConstraintSetCylinderTruck constraintSet = AnalysisCast.ConstraintSet as ConstraintSetCylinderTruck;
                uCtrlMinDistanceLoadWall.ValueX = constraintSet.MinDistanceLoadWall.X;
                uCtrlMinDistanceLoadWall.ValueY = constraintSet.MinDistanceLoadWall.Y;
                uCtrlMinDistanceLoadRoof.Value = constraintSet.MinDistanceLoadRoof;
            }
            // event handling
            cbCylinders.SelectedIndexChanged += new EventHandler(OnCylinderChanged);
            cbTrucks.SelectedIndexChanged += new EventHandler(OnInputChanged);
            uCtrlMinDistanceLoadWall.ValueChanged += new UCtrlDualDouble.ValueChangedDelegate(OnInputChanged);
            uCtrlMinDistanceLoadRoof.ValueChanged += new UCtrlDouble.ValueChangedDelegate(OnInputChanged);
            uCtrlOptMaximumWeight.ValueChanged += new UCtrlOptDouble.ValueChangedDelegate(OnInputChanged);
            uCtrlOptMaximumNumber.ValueChanged += new UCtrlOptInt.ValueChangedDelegate(OnInputChanged);

            OnInputChanged(this, null);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Settings.Default.MinDistancePalletTruckWallX = uCtrlMinDistanceLoadWall.ValueX;
            Settings.Default.MinDistancePalletTruckWallY = uCtrlMinDistanceLoadWall.ValueY;
            Settings.Default.MinDistancePalletTruckRoof = uCtrlMinDistanceLoadRoof.Value;
            Settings.Default.Save();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion
        #region FormNewAnalysis override
        public override void UpdateStatus(string message)
        {
            if (null == SelectedLayout) message = Resources.ID_SELECTATLEASTONELAYOUT;
            base.UpdateStatus(message);
        }
        public override void OnNext()
        {
            base.OnNext();
            try
            {
                // sanity check
                if (null == SelectedLayout) return;

                if (null == AnalysisCast)
                    AnalysisBase = _document.CreateNewAnalysisHCylTruck(
                        ItemName, ItemDescription
                        , SelectedCylinder, SelectedTruck
                        , BuildConstraintSet()
                        , SelectedLayout
                        );
                else
                {
                    if (AnalysisCast is AnalysisHCylTruck analysisHCylPallet)
                    {
                        analysisHCylPallet.ID.SetNameDesc(ItemName, ItemDescription);
                        analysisHCylPallet.Content = SelectedCylinder;
                        analysisHCylPallet.TruckProperties = SelectedTruck;
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
                    && cbTrucks.SelectedType is TruckProperties truckProperties)
                {
                    var layouts = CylLayoutSolver.BuildLayouts(cylinder, truckProperties, BuildConstraintSet());
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
            uCtrlPackable.PackableProperties = SelectedCylinder;
            OnInputChanged(sender, e);
        }
        private void OnLayoutSelected(object sender, EventArgs e) => UpdateStatus(string.Empty);
        #endregion
        #region Helpers
        private ConstraintSetCylinderTruck BuildConstraintSet()
        {
            return new ConstraintSetCylinderTruck(SelectedTruck)
            {
                MinDistanceLoadWall = DistanceLoadWall,
                MinDistanceLoadRoof = uCtrlMinDistanceLoadRoof.Value,
                OptMaxNumber = uCtrlOptMaximumNumber.Value,
                OptMaxWeight = uCtrlOptMaximumWeight.Value
            };
        }
        #endregion
        #region Private properties
        private CylinderProperties SelectedCylinder => cbCylinders.SelectedType as CylinderProperties;
        private TruckProperties SelectedTruck => cbTrucks.SelectedType as TruckProperties;
        private AnalysisHCylTruck AnalysisCast => _item as AnalysisHCylTruck;
        private Vector2D DistanceLoadWall => uCtrlMinDistanceLoadWall.Value;
        private HCylLayout SelectedLayout => uCtrlHCylLayoutList.Selected;
        #endregion
        #region Data members
        protected ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisHCylTruck));
        #endregion
    }
}
