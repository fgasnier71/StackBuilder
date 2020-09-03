#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class FormNewAnalysisCylinderPallet
        : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisCylinderPallet(Document doc, AnalysisLayered analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName
        { get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, null);
            cbPallets.Initialize(_document, this, null);

            // event handling
            uCtrlLayerList.LayerSelected += OnLayerSelected;
            uCtrlLayerList.RefreshFinished += OnLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);

            if (null == AnalysisBase)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
                uCtrlOptMaximumWeight.Value = new OptDouble(false, Settings.Default.MaximumPalletWeight);

                uCtrlOverhang.ValueX = Settings.Default.OverhangX;
                uCtrlOverhang.ValueY = Settings.Default.OverhangY;

                checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.MaximumPalletHeight = uCtrlMaximumHeight.Value;
            if (uCtrlOptMaximumWeight.Value.Activated)
                Settings.Default.MaximumPalletWeight = uCtrlOptMaximumWeight.Value.Value;

            Settings.Default.OverhangX = uCtrlOverhang.ValueX;
            Settings.Default.OverhangY = uCtrlOverhang.ValueY;

            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
        }
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            base.OnNext();
            try
            {
                var layerEncaps = new List<LayerEncap>();
                foreach (ILayer2D layer2D in uCtrlLayerList.Selected)
                    layerEncaps.Add(new LayerEncap(layer2D.LayerDescriptor));

                SolutionLayered.SetSolver(new LayerSolver());

                AnalysisCylinderPallet analysis = AnalysisCast;
                if (null == analysis)
                    _document.CreateNewAnalysisCylinderPallet(
                        ItemName, ItemDescription
                        , SelectedCylinderProperties, SelectedPallet
                        , new List<InterlayerProperties>()
                        , BuildConstraintSet()
                        , layerEncaps
                        );
                else
                {
                    analysis.ID.SetNameDesc(ItemName, ItemDescription);
                    analysis.Content = SelectedCylinderProperties;
                    analysis.PalletProperties = SelectedPallet;
                    analysis.ConstraintSet = BuildConstraintSet();
                    analysis.AddSolution(layerEncaps);
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
            if (ctrl == cbCylinders)
                return itemBase is RevSolidProperties;
            else if (ctrl == cbPallets)
                return itemBase is PalletProperties;
            else
                return false;
        }
        #endregion

        #region Event handlers
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
                // get cylinder / case
                if (cbCylinders.SelectedType is RevSolidProperties cylinder
                    && cbPallets.SelectedType is PalletProperties palletProperties)
                {
                    // compute
                    LayerSolver solver = new LayerSolver();
                    List<Layer2DCylImp> layers = solver.BuildLayers(
                        cylinder.RadiusOuter, cylinder.Height
                        , new Vector2D(palletProperties.Length + 2.0 * uCtrlOverhang.ValueX, palletProperties.Width + 2.0 * uCtrlOverhang.ValueY)
                        , palletProperties.Height
                        , BuildConstraintSet()
                        , checkBoxBestLayersOnly.Checked
                        );
                    //  update control
                    uCtrlLayerList.Packable = cylinder;
                    uCtrlLayerList.ContainerHeight = uCtrlMaximumHeight.Value - palletProperties.Height;
                    uCtrlLayerList.FirstLayerSelected = true;
                    uCtrlLayerList.LayerList = layers.Cast<ILayer2D>().ToList();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected void OnCylinderChanged(object sender, EventArgs e)
        {
            uCtrlPackable.PackableProperties = cbCylinders.SelectedType as Packable;
            OnInputChanged(sender, e);
            OnLayerSelected(sender, e);
        }
        #endregion

        #region Private properties
        private RevSolidProperties SelectedCylinderProperties=> cbCylinders.SelectedType as RevSolidProperties;
        private PalletProperties SelectedPallet => cbPallets.SelectedType as PalletProperties;
        private AnalysisCylinderPallet AnalysisCast => _item as AnalysisCylinderPallet;
        #endregion

        #region Helpers
        private ConstraintSetPackablePallet BuildConstraintSet()
        {
            var constraintSet = new ConstraintSetPackablePallet()
            {
                Overhang = new Vector2D(uCtrlOverhang.ValueX, uCtrlOverhang.ValueY),
                OptMaxWeight = uCtrlOptMaximumWeight.Value
            };
            constraintSet.SetMaxHeight(new OptDouble(true, uCtrlMaximumHeight.Value));
            return constraintSet;
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCylinderPallet));
        #endregion
    }
}
