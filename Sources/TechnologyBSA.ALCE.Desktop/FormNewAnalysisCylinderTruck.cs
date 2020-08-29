#region Using directives
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
using System;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCylinderTruck
        : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisCylinderTruck(Document doc, AnalysisLayered analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, AnalysisCast?.Content);
            cbTrucks.Initialize(_document, this, AnalysisCast?.TruckProperties);

            // event handling
            uCtrlLayerList.LayerSelected += OnSolutionSelected;
            uCtrlLayerList.ButtonSizes = new Size(250, 100);

            if (null == AnalysisCast)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

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
            checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Settings.Default.MinDistancePalletTruckWallX = uCtrlMinDistanceLoadWall.ValueX;
            Settings.Default.MinDistancePalletTruckWallY = uCtrlMinDistanceLoadWall.ValueY;
            Settings.Default.MinDistancePalletTruckRoof = uCtrlMinDistanceLoadRoof.Value;
            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
            Settings.Default.Save();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            base.OnNext();

            try
            {
                var layerEncaps = new List<LayerEncap>();
                foreach (ILayer2D layer in uCtrlLayerList.Selected)
                    layerEncaps.Add(new LayerEncap(layer.LayerDescriptor));

                SolutionLayered.SetSolver(new LayerSolver());

                if (!(_item is AnalysisCylinderTruck analysis))
                {
                    _item = _document.CreateNewAnalysisCylinderTruck(
                        ItemName, ItemDescription
                        , SelectedCylinder, SelectedTruck
                        , BuildConstraintSet()
                        , layerEncaps);
                }
                else
                {
                    analysis.ID.SetNameDesc(ItemName, ItemDescription);
                    analysis.Content = SelectedCylinder;
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

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCylinders)
            { return itemBase is CylinderProperties; }
            else if (ctrl == cbTrucks)
            { return itemBase is TruckProperties; }
            else return false;
        }
        #endregion

        #region Event handlers
        private void OnSolutionSelected(object sender, EventArgs e)
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
                // get cylinder & truck
                var truck = SelectedTruck;
                var cylinder = SelectedCylinder;
                if (null == cylinder || null == truck)
                    return;
                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2DCylImp> layers = solver.BuildLayers(
                    cylinder.RadiusOuter, cylinder.Height
                    , new Vector2D(truck.InsideLength, truck.InsideWidth)
                    , 0.0
                    ,  BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked
                    );
                // update control
                uCtrlLayerList.Packable = cylinder;
                uCtrlLayerList.ContainerHeight = truck.InsideHeight;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = layers.Cast<ILayer2D>().ToList();
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
            OnSolutionSelected(sender, e);
        }
        #endregion

        #region Helpers
        private ConstraintSetCylinderTruck BuildConstraintSet()
        {
            return new ConstraintSetCylinderTruck(SelectedTruck)
            {
                MinDistanceLoadWall = new Vector2D(uCtrlMinDistanceLoadWall.ValueX, uCtrlMinDistanceLoadWall.ValueY),
                MinDistanceLoadRoof = uCtrlMinDistanceLoadRoof.Value
            };
        }
        #endregion

        #region Private properties
        private CylinderProperties SelectedCylinder => cbCylinders.SelectedType as CylinderProperties;
        private TruckProperties SelectedTruck => cbTrucks.SelectedType as TruckProperties;
        private AnalysisCylinderTruck AnalysisCast => _item as AnalysisCylinderTruck;
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCylinderTruck));
        #endregion
    }
}
