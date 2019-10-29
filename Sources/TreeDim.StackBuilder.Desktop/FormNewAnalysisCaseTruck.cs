#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
    public partial class FormNewAnalysisCaseTruck
        : FormNewAnalysis, IItemBaseFilter
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCaseTruck));
        #endregion

        #region Constructor
        public FormNewAnalysisCaseTruck(Document doc, AnalysisHomo analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCases.Initialize(_document, this, null != AnalysisCast ? AnalysisCast.Content : null);
            cbTrucks.Initialize(_document, this, null != AnalysisCast ? AnalysisCast.Container : null);

            // event handling
            uCtrlLayerList.LayerSelected += OnLayerSelected;
            uCtrlLayerList.RefreshFinished += OnLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(250, 100);

            if (null == AnalysisCast)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlMinDistanceLoadWall.ValueX = Settings.Default.MinDistancePalletTruckWallX;
                uCtrlMinDistanceLoadWall.ValueY = Settings.Default.MinDistancePalletTruckWallY;
                uCtrlMinDistanceLoadRoof.Value = Settings.Default.MinDistancePalletTruckRoof;
                uCtrlCaseOrientation.AllowedOrientations = new bool[]
                { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };
            }
            else
            {
                tbName.Text = AnalysisBase.Name;
                tbDescription.Text = AnalysisBase.Description;

                ConstraintSetCaseTruck constraintSet = AnalysisBase.ConstraintSet as ConstraintSetCaseTruck;
                uCtrlMinDistanceLoadWall.ValueX = constraintSet.MinDistanceLoadWall.X;
                uCtrlMinDistanceLoadWall.ValueY = constraintSet.MinDistanceLoadWall.Y;
                uCtrlMinDistanceLoadRoof.Value = constraintSet.MinDistanceLoadRoof;
                uCtrlCaseOrientation.AllowedOrientations = constraintSet.AllowedOrientations;
            }
            checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.MinDistancePalletTruckWallX = uCtrlMinDistanceLoadWall.ValueX;
            Settings.Default.MinDistancePalletTruckWallY = uCtrlMinDistanceLoadWall.ValueY;
            Settings.Default.MinDistancePalletTruckRoof = uCtrlMinDistanceLoadRoof.Value;
            Settings.Default.AllowVerticalX = uCtrlCaseOrientation.AllowedOrientations[0];
            Settings.Default.AllowVerticalY = uCtrlCaseOrientation.AllowedOrientations[1];
            Settings.Default.AllowVerticalZ = uCtrlCaseOrientation.AllowedOrientations[2];
            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
            Settings.Default.Save();
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

                Solution.SetSolver(new LayerSolver());

                AnalysisCaseTruck analysis = AnalysisCast;
                if (null == analysis)
                    AnalysisBase = _document.CreateNewAnalysisCaseTruck(
                        ItemName, ItemDescription
                        , SelectedPackable, SelectedTruck
                        , new List<InterlayerProperties>()
                        , BuildConstraintSet()
                        , layerEncaps
                        );
                else
                {
                    analysis.ID.SetNameDesc(ItemName, ItemDescription);
                    analysis.Content = SelectedPackable;
                    analysis.TruckProperties = SelectedTruck;
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

        #region Public properties
        public AnalysisCaseTruck AnalysisCast
        {
            get { return _item as AnalysisCaseTruck; }
            set { _item = value; }
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
            else if (ctrl == cbTrucks)
            {
                TruckProperties truckProperties = itemBase as TruckProperties;
                return null != truckProperties;
            }
            return false;
        }
        #endregion

        #region Private properties
        private PackableBrick SelectedPackable => cbCases.SelectedType as PackableBrick;
        private TruckProperties SelectedTruck => cbTrucks.SelectedType as TruckProperties;
        #endregion

        #region Event handlers
        protected void OnCaseChanged(object sender, EventArgs e)
        {
            try
            {
                uCtrlCaseOrientation.BProperties = SelectedPackable;
                OnInputChanged(sender, e);
                OnLayerSelected(sender, e);
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
                // get box / case
                PackableBrick packable = SelectedPackable;
                TruckProperties truck = SelectedTruck;
                if (null == packable || null == truck)
                    return;

                // update orientation control
                uCtrlCaseOrientation.BProperties = packable;

                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2DBrickImp> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(
                        truck.InsideLength - 2.0 * uCtrlMinDistanceLoadWall.ValueX
                        , truck.InsideWidth - 2.0 * uCtrlMinDistanceLoadWall.ValueY)
                    , 0.0 /* offsetZ */
                    , BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked
                    );
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = truck.InsideHeight - uCtrlMinDistanceLoadRoof.Value;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = layers.Cast<ILayer2D>().ToList();
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
        #endregion

        #region Helpers
        private ConstraintSetCaseTruck BuildConstraintSet()
        {
            ConstraintSetCaseTruck constraintSet = new ConstraintSetCaseTruck(SelectedTruck)
            {
                MinDistanceLoadWall = new Vector2D(uCtrlMinDistanceLoadWall.ValueX, uCtrlMinDistanceLoadWall.ValueY),
                MinDistanceLoadRoof = uCtrlMinDistanceLoadRoof.Value
            };
            constraintSet.SetAllowedOrientations(uCtrlCaseOrientation.AllowedOrientations);
            return constraintSet;
        }
        #endregion
    }
}
