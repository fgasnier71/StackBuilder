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
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCasePallet : FormNewBase, IItemBaseFilter
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
            cbCases.Initialize(_document, this, null != _analysis ? _analysis.BProperties : null);
            cbPallets.Initialize(_document, this, null != _analysis ? _analysis.PalletProperties : null);

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

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCases)
            { 
                Packable packable = itemBase as Packable;
                return null != packable; 
            }
            else if (ctrl == cbPallets)
            {
                PalletProperties palletProperties = itemBase as PalletProperties;
                return null != palletProperties;
            }
            return false;
        }
        #endregion

        #region Private properties
        private Packable SelectedBoxProperties
        {
            get { return cbCases.SelectededType as Packable; }
        }
        private PalletProperties SelectedPallet
        {
            get { return cbPallets.SelectededType as PalletProperties; }
        }
        #endregion

        #region Event handlers
        protected void onCaseChanged(object sender, EventArgs e)
        {
            try
            {
                uCtrlCaseOrientation.BProperties = cbCases.SelectededType as Packable;
                onInputChanged(sender, e);
                onLayerSelected(sender, e);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected void onLayerSelected(object sender, EventArgs e)
        {
            try
            {
                Layer2D[] layers = uCtrlLayerList.Selected;
                bnNext.Enabled = layers.Length > 0;
                UpdateStatus(layers.Length > 0 ? string.Empty : Resources.ID_SELECTATLEASTONELAYOUT);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get case /pallet
                Packable packable = cbCases.SelectededType as Packable;
                PalletProperties palletProperties = cbPallets.SelectededType as PalletProperties;
                if (null == packable || null == palletProperties)
                    return;
                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(palletProperties.Length + 2.0*uCtrlOverhang.ValueX, palletProperties.Width + 2.0*uCtrlOverhang.ValueY)
                    , BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked);
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = uCtrlOptMaximumHeight.Value.Value;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = layers;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onBnNextClicked(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void onBestCombinationClicked(object sender, EventArgs e)
        {
            try
            { }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }            
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
