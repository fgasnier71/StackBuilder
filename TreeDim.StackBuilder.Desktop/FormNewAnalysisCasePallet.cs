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
    public partial class FormNewAnalysisCasePallet : FormNewAnalysis, IItemBaseFilter
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCasePallet));
        #endregion

        #region Constructor
        public FormNewAnalysisCasePallet(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Public properties
        public AnalysisCasePallet AnalysisCast
        {
            get { return _item as AnalysisCasePallet; }
            set { _item = value; }
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCases.Initialize(_document, this, null != AnalysisCast ? AnalysisCast.Content : null);
            cbPallets.Initialize(_document, this, null != AnalysisCast ? AnalysisCast.PalletProperties : null);

            // event handling
            uCtrlLayerList.LayerSelected += onLayerSelected;
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);

            if (null == AnalysisCast)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlCaseOrientation.AllowedOrientations = new bool[] { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };
                uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
                uCtrlOptMaximumWeight.Value = new OptDouble(true, Settings.Default.MaximumPalletWeight);

                uCtrlOverhang.ValueX = Settings.Default.OverhangX;
                uCtrlOverhang.ValueY = Settings.Default.OverhangY;

                checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
             }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.AllowVerticalX = uCtrlCaseOrientation.AllowedOrientations[0];
            Settings.Default.AllowVerticalY = uCtrlCaseOrientation.AllowedOrientations[1];
            Settings.Default.AllowVerticalZ = uCtrlCaseOrientation.AllowedOrientations[2];
            Settings.Default.MaximumPalletHeight = uCtrlMaximumHeight.Value;
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
                return null != packable && packable.IsCase; 
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
            get { return cbCases.SelectedType as Packable; }
        }
        private PalletProperties SelectedPallet
        {
            get { return cbPallets.SelectedType as PalletProperties; }
        }
        #endregion

        #region Event handlers
        protected void onCaseChanged(object sender, EventArgs e)
        {
            try
            {
                uCtrlCaseOrientation.BProperties = cbCases.SelectedType as PackableBrick;
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
                ILayer2D[] layers = uCtrlLayerList.Selected;
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
                Packable packable = cbCases.SelectedType as Packable;
                PalletProperties palletProperties = cbPallets.SelectedType as PalletProperties;
                if (null == packable || null == palletProperties)
                    return;
                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(palletProperties.Length + 2.0*uCtrlOverhang.ValueX, palletProperties.Width + 2.0*uCtrlOverhang.ValueY)
                    , palletProperties.Height
                    , BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked);
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = uCtrlMaximumHeight.Value - palletProperties.Height;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = LayerSolver.ConvertList(layers);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        public override void OnNext()
        {
            try
            {
                List<LayerDesc> layerDescs = new List<LayerDesc>();
                foreach (Layer2D layer2D in uCtrlLayerList.Selected)
                    layerDescs.Add(layer2D.LayerDescriptor);

                Solution.SetSolver(new LayerSolver());

                _item = _document.CreateNewAnalysisCasePallet(
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
            {
                Packable packable = cbCases.SelectedType as Packable;
                PalletProperties palletProperties = cbPallets.SelectedType as PalletProperties;
                if (null == packable || null == palletProperties)
                    return;

                // get best combination
                List<KeyValuePair<LayerDesc, int>> listLayer = new List<KeyValuePair<LayerDesc,int>>();
                LayerSolver.GetBestCombination(
                    packable.OuterDimensions,
                    new Vector2D(palletProperties.Length + 2.0 * uCtrlOverhang.ValueX, palletProperties.Width + 2.0 * uCtrlOverhang.ValueY),
                    BuildConstraintSet(),
                    ref listLayer);

                // select best layers
                List<LayerDesc> listLayerDesc = new List<LayerDesc>();
                foreach (KeyValuePair<LayerDesc, int> kvp in listLayer)
                    listLayerDesc.Add(kvp.Key);
                uCtrlLayerList.SelectLayers(listLayerDesc);
            }
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
            constraintSet.SetMaxHeight( new OptDouble(true, uCtrlMaximumHeight.Value));
            constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
            return constraintSet;
        }
        #endregion
    }
}
