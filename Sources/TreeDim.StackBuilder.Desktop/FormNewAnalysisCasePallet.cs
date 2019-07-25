#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCasePallet : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisCasePallet(Document doc, AnalysisHomo analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCases.Initialize(_document, this, AnalysisCast?.Content);
            cbPallets.Initialize(_document, this, AnalysisCast?.PalletProperties);

            // event handling
            uCtrlLayerList.LayerSelected += OnLayerSelected;
            uCtrlLayerList.RefreshFinished += OnLayerSelected;

            if (null == AnalysisCast)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlCaseOrientation.AllowedOrientations = new bool[] { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };
                uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
                uCtrlOptMaximumWeight.Value = new OptDouble(false, Settings.Default.MaximumPalletWeight);
                uCtrlOptMaxNumber.Value = new OptInt(false, 1000);

                uCtrlOverhang.ValueX = Settings.Default.OverhangX;
                uCtrlOverhang.ValueY = Settings.Default.OverhangY;
            }
            else
            {
                tbName.Text = AnalysisBase.Name;
                tbDescription.Text = AnalysisBase.Description;

                ConstraintSetCasePallet constraintSet = AnalysisBase.ConstraintSet as ConstraintSetCasePallet;
                uCtrlCaseOrientation.AllowedOrientations = constraintSet.AllowedOrientations;
                uCtrlMaximumHeight.Value = constraintSet.OptMaxHeight.Value;
                uCtrlOptMaximumWeight.Value = constraintSet.OptMaxWeight;
                uCtrlOptMaxNumber.Value = constraintSet.OptMaxNumber;
                uCtrlOverhang.ValueX = constraintSet.Overhang.X;
                uCtrlOverhang.ValueY = constraintSet.Overhang.Y;
                uCtrlOptSpace.Value = constraintSet.MinimumSpace;
            }
            checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
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
            if (uCtrlOptMaxNumber.Value.Activated)
                Settings.Default.MaximumNumber = uCtrlOptMaxNumber.Value.Value;

            Settings.Default.OverhangX = uCtrlOverhang.ValueX;
            Settings.Default.OverhangY = uCtrlOverhang.ValueY;

            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            try
            {
                List<LayerDesc> layerDescs = new List<LayerDesc>();
                foreach (Layer2D layer2D in uCtrlLayerList.Selected)
                    layerDescs.Add(layer2D.LayerDescriptor);

                Solution.SetSolver(new LayerSolver());

                AnalysisCasePallet analysis = AnalysisCast;
                if (null == analysis)
                    _item = _document.CreateNewAnalysisCasePallet(
                        ItemName, ItemDescription
                        , SelectedPackable, SelectedPallet
                        , new List<InterlayerProperties>()
                        , null, null, null
                        , BuildConstraintSet()
                        , layerDescs
                        );
                else
                {
                    analysis.ID.SetNameDesc(ItemName, ItemDescription);
                    analysis.Content = SelectedPackable;
                    analysis.PalletProperties = SelectedPallet;
                    analysis.ConstraintSet = BuildConstraintSet();
                    analysis.AddSolution(layerDescs);

                    _document.UpdateAnalysis(analysis);
                }
                Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCases)
            { 
                Packable packable = itemBase as Packable;
                return null != packable
                    && (
                    (packable is BProperties) ||
                    (packable is PackProperties) ||
                    (packable is LoadedCase)
                    ); 
            }
            else if (ctrl == cbPallets)
            {
                PalletProperties palletProperties = itemBase as PalletProperties;
                return null != palletProperties;
            }
            return false;
        }
        #endregion

        #region Public properties
        public AnalysisCasePallet AnalysisCast
        {
            get { return _item as AnalysisCasePallet; }
            set { _item = value; }
        }
        #endregion

        #region Private properties
        private Packable SelectedPackable
        {
            get { return cbCases.SelectedType as Packable; }
        }
        private PalletProperties SelectedPallet
        {
            get { return cbPallets.SelectedType as PalletProperties; }
        }
        #endregion

        #region Event handlers
        protected void OnCaseChanged(object sender, EventArgs e)
        {
            try
            {
                uCtrlCaseOrientation.BProperties = cbCases.SelectedType as PackableBrick;
                OnInputChanged(sender, e);
                OnLayerSelected(sender, e);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected void OnLayerSelected(object sender, EventArgs e)
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
        private void OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get case /pallet
                PalletProperties palletProperties = cbPallets.SelectedType as PalletProperties;
                if (!(cbCases.SelectedType is Packable packable) || null == palletProperties)
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
                uCtrlLayerList.LayerList = layers.Cast<ILayer2D>().ToList();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnBestCombinationClicked(object sender, EventArgs e)
        {
            try
            {
                PalletProperties palletProperties = cbPallets.SelectedType as PalletProperties;
                if (!(cbCases.SelectedType is Packable packable) || null == palletProperties)
                    return;
                ConstraintSetAbstract constraintSet = BuildConstraintSet();
                // get best combination
                List<KeyValuePair<LayerDesc, int>> listLayer = new List<KeyValuePair<LayerDesc,int>>();
                LayerSolver.GetBestCombination(
                    packable.OuterDimensions,
                    palletProperties.GetStackingDimensions(constraintSet),
                    constraintSet,
                    ref listLayer);
                // select best layers
                List<LayerDesc> LayerDesc = new List<LayerDesc>();
                foreach (KeyValuePair<LayerDesc, int> kvp in listLayer)
                    LayerDesc.Add(kvp.Key);
                uCtrlLayerList.SelectLayers(LayerDesc);

                _item = _document.CreateNewAnalysisCasePallet(
                    ItemName, ItemDescription
                    , SelectedPackable, SelectedPallet
                    , new List<InterlayerProperties>()
                    , null, null, null
                    , BuildConstraintSet()
                    , listLayer
                    );
                Close();
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
            ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet()
            {
                // overhang
                Overhang = new Vector2D(uCtrlOverhang.ValueX, uCtrlOverhang.ValueY)
            };
            // orientations
            constraintSet.SetAllowedOrientations(uCtrlCaseOrientation.AllowedOrientations);
            // conditions
            constraintSet.SetMaxHeight( new OptDouble(true, uCtrlMaximumHeight.Value));
            constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
            constraintSet.MinimumSpace = new OptDouble(uCtrlOptSpace.Value);
            return constraintSet;
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCasePallet));
        #endregion
    }
}
