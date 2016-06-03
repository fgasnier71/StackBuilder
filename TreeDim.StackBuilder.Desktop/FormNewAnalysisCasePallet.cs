#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCasePallet : FormNewBase
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCasePallet));
        private AnalysisCasePallet _analysis;
        #endregion

        #region Constructor
        public FormNewAnalysisCasePallet(Document doc, ItemBase analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_ANALYSIS; } }
        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BoxProperties[] cases = _document.Cases.ToArray();
            PalletProperties[] pallets = _document.Pallets.ToArray();

            // fill combo boxes
            ComboBoxHelpers.FillCombo(cases, cbCases, (null != _analysis) ? _analysis.BProperties : cases[0]);
            ComboBoxHelpers.FillCombo(pallets, cbPallets, (null != _analysis) ? _analysis.PalletProperties : pallets[0]);

            // event handling
            uCtrlLayerList.LayerSelected += onLayerSelected;
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);

            if (null == _analysis)
            {                
                uCtrlCaseOrientation.AllowedOrientations = new bool[]
                { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };
                uCtrlOptMaximumHeight.Value = new OptDouble(true, Settings.Default.MaximumPalletHeight);
                uCtrlOptMaximumWeight.Value = new OptDouble(true, Settings.Default.MaximumPalletWeight);

                uCtrlOverhang.ValueX = Settings.Default.OverhangX;
                uCtrlOverhang.ValueY = Settings.Default.OverhangY;

                checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
             }
             bnNext.Enabled = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.AllowVerticalX = uCtrlCaseOrientation.AllowedOrientations[0];
            Settings.Default.AllowVerticalY = uCtrlCaseOrientation.AllowedOrientations[1];
            Settings.Default.AllowVerticalZ = uCtrlCaseOrientation.AllowedOrientations[2];

            if (uCtrlOptMaximumHeight.Value.Activated)
                Settings.Default.MaximumPalletHeight = uCtrlOptMaximumHeight.Value.Value;
            if (uCtrlOptMaximumWeight.Value.Activated)
                Settings.Default.MaximumPalletWeight = uCtrlOptMaximumWeight.Value.Value;

            Settings.Default.OverhangX = uCtrlOverhang.ValueX;
            Settings.Default.OverhangY = uCtrlOverhang.ValueY;

            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
        }
        #endregion

        #region Private properties
        private BProperties SelectedBoxProperties
        {
            get
            {
                ItemBaseCB itemBaseCase = cbCases.SelectedItem as ItemBaseCB;
                if (null == itemBaseCase) return null;
                return itemBaseCase.Item as BProperties;
            }
        }
        private PalletProperties SelectedPallet
        {
            get
            {
                ItemBaseCB itemBasePallet = cbPallets.SelectedItem as ItemBaseCB;
                if (null == itemBasePallet) return null;
                return itemBasePallet.Item as PalletProperties;
            }
        }
        #endregion

        #region Event handlers
        protected void onCaseChanged(object sender, EventArgs e)
        {
            ItemBaseCB itemBaseCase = cbCases.SelectedItem as ItemBaseCB;
            if (null == itemBaseCase) return;
            uCtrlCaseOrientation.BProperties = itemBaseCase.Item as BProperties;

            onLayerSelected(sender, e);
        }
        protected void onLayerSelected(object sender, EventArgs e)
        {
            Layer2D[] layers = uCtrlLayerList.Selected;
            bnNext.Enabled = layers.Length > 0;
            UpdateStatus(layers.Length > 0 ? string.Empty : Resources.ID_SELECTATLEASTONELAYOUT);
        }
        private void onInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get case /pallet
                ItemBaseCB itemBaseCase = cbCases.SelectedItem as ItemBaseCB;
                if (null == itemBaseCase) return;
                BProperties bProperties = itemBaseCase.Item as BProperties;

                ItemBaseCB itemBasePallet = cbPallets.SelectedItem as ItemBaseCB;
                if (null == itemBasePallet) return;
                PalletProperties palletProperties = itemBasePallet.Item as PalletProperties;
                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    bProperties.OuterDimensions
                    , new Vector2D(palletProperties.Length + 2.0 * uCtrlOverhang.ValueX, palletProperties.Width + 2.0 * uCtrlOverhang.ValueY)
                    , BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked);
                // update control
                uCtrlLayerList.BProperties = bProperties;
                uCtrlLayerList.ContainerHeight = uCtrlOptMaximumHeight.Value.Value;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = layers;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onBnNextClicked(object sender, EventArgs e)
        {
            List<LayerDesc> layerDescs = new List<LayerDesc>();
            foreach (Layer2D layer2D in uCtrlLayerList.Selected)
                layerDescs.Add(layer2D.LayerDescriptor);

            Solution.SetSolver(new LayerSolver());

            _analysis = _document.CreateNewAnalysisCasePallet(
                ItemName, ItemDescription
                , SelectedBoxProperties, SelectedPallet
                , new List<InterlayerProperties>()
                , null, null, null
                , BuildConstraintSet()
                , layerDescs
                );

            Close();
        }

        private void onBestCombinationClicked(object sender, EventArgs e)
        {

            
        }
        #endregion

        #region Helpers
        private ConstraintSetCasePallet BuildConstraintSet()
        {
            // constraint set
            ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
            // overhang
            constraintSet.Overhang = new Vector2D(uCtrlOverhang.ValueX, uCtrlOverhang.ValueY);
            // orientations
            constraintSet.SetAllowedOrientations(uCtrlCaseOrientation.AllowedOrientations);
            // conditions
            constraintSet.OptMaxHeight = uCtrlOptMaximumHeight.Value;
            constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;

            return constraintSet;
        }
        #endregion

    }
}
