#region Using directives
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Diagnostics;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.SampleCasePalletProj
{
    public partial class FormMain : Form
    {
        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CaseDimensions = new Vector3D(400.0, 300.0, 200.0);
            CaseWeight = 1.0;

            PalletDimensions = new Vector3D(1200.0, 1000.0, 150.0);
            PalletWeight = 25.0;

            MaxPalletHeight = new OptDouble(true, 1700.0);
        }
        #endregion

        #region Accessing control values
        private Vector3D CaseDimensions
        {
            get => uCtrlTriCaseDim.Value;
            set => uCtrlTriCaseDim.Value = value;
        }
        private double CaseWeight
        {
            get => uCtrlCaseWeight.Value;
            set => uCtrlCaseWeight.Value = value;
        }
        private Vector3D PalletDimensions
        {
            get => uCtrlPalletDim.Value;
            set => uCtrlPalletDim.Value = value;
        }
        private double PalletWeight
        {
            get => uCtrlPalletWeight.Value;
            set => uCtrlPalletWeight.Value = value;
        }
        private Vector2D PalletOverhang => uCtrlOverhang.Value;

        private OptDouble MaxPalletHeight
        {
            get => new OptDouble(true, uCtrlMaxHeight.Value);
            set => uCtrlMaxHeight.Value = value.Value;
        }
        private OptInt MaximumNumber
        {
            get => uCtrlMaxNumber.Value;
            set => uCtrlMaxNumber.Value = value;
        }
        private bool[] AllowedOrientations => new bool[] { chkbX.Checked, chkbY.Checked, chkbZ.Checked };
        private bool BestLayersOnly => chkbBestLayers.Checked;
        private bool UseAlternateLayers => chkbAlternateLayers.Checked;
        #endregion

        #region Event handler
        private void OnInputChanged(object sender, EventArgs args)
        {
            try
            {
                // ### define a BoxProperties object
                _caseProperties = new BoxProperties(null, CaseDimensions.X, CaseDimensions.Y, CaseDimensions.Z)
                {
                    TapeColor = Color.LightGray,
                    TapeWidth = new OptDouble(true, 50.0)
                };
                _caseProperties.SetWeight(CaseWeight);
                _caseProperties.SetColor(Color.Beige);
                // ###

                // ### define a PalletProperties object
                string[] typeNames = PalletData.TypeNames;
                _palletProperties = new PalletProperties(null, typeNames[6] /*EUR2*/, PalletDimensions.X, PalletDimensions[1], PalletDimensions[2]) { Weight = PalletWeight };

                // ### define a constraintset object
                _constraintSet = new ConstraintSetCasePallet()
                {
                    OptMaxNumber = new OptInt(false, 0),
                    OptMaxWeight = new OptDouble(true, 1000.0),
                    Overhang = PalletOverhang,
                };
                _constraintSet.SetAllowedOrientations(AllowedOrientations);
                _constraintSet.SetMaxHeight(MaxPalletHeight);
                _constraintSet.OptMaxNumber = MaximumNumber;
                Vector3D vPalletDim = _palletProperties.GetStackingDimensions(_constraintSet);
                // ###

                // get a list of all possible layers
                ILayerSolver solver = new LayerSolver();
                // build layers and fill CCtrl
                _layers = solver.BuildLayers(_caseProperties.OuterDimensions, new Vector2D(vPalletDim.X, vPalletDim.Y), 0.0, _constraintSet, BestLayersOnly);
                cbLayers.Packable = _caseProperties;
                // fill combo with layers
                cbLayers.Items.Clear();
                foreach (var l in _layers)
                    cbLayers.Items.Add(l);
                if (_layers.Count > 0)
                    cbLayers.SelectedIndex = 0;
                // --- To get an image of a single layer, you could use
                
                // ---

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OnSelectedLayerChanged(object sender, System.EventArgs e)
        {
            if (cbLayers.SelectedIndex == -1)
                return;

            // assign static member with default layer solver
            SolutionLayered.SetSolver(new LayerSolver());
            SolutionHCyl.SetSolver(new CylLayoutSolver());

            // build analysis
            var analysis = new AnalysisCasePallet(_caseProperties, _palletProperties, _constraintSet as ConstraintSetCasePallet);
            analysis.AddSolution(_layers[cbLayers.SelectedIndex].LayerDescriptor, UseAlternateLayers);

            // build image & assign to picture box
            Graphics3DImage graphics = new Graphics3DImage(pbPalletization.Size) { CameraPosition = Graphics3D.Corner_0, Target = Vector3D.Zero};
            using (ViewerSolution viewer = new ViewerSolution(analysis.SolutionLay))
                viewer.Draw(graphics, Transform3D.Identity);
            graphics.Flush();
            pbPalletization.Image = graphics.Bitmap;

            // results
            var sol = analysis.SolutionLay;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Case count : {sol.ItemCount}");
            sb.AppendLine($"Layer count : {sol.LayerCount}");
            sb.AppendLine($"Cases/layer : {sol.LayerBoxCount(0)}");
            sb.AppendLine($"Load weight : {sol.LoadWeight} kg");
            sb.AppendLine($"Total weight : {sol.Weight} kg");
            sb.AppendLine($"Dimensions load (mm x mm x mm) : {sol.BBoxLoad.Length} x {sol.BBoxLoad.Width} x {sol.BBoxLoad.Height}");
            sb.AppendLine($"Dimensions (mm x mm x mm) : {sol.BBoxGlobal.Length} x {sol.BBoxGlobal.Width} x {sol.BBoxGlobal.Height}");
            rtbResults.Text = sb.ToString();
        }
        private void OnGenerateLayerImage(object sender, EventArgs e)
        {
            Layer2DBrickImp layer = _layers[cbLayers.SelectedIndex];
            Bitmap bmp = LayerToImage.DrawEx(
                   layer, _caseProperties, _constraintSet.OptMaxHeight.Value, new Size(150,150), false
                   , true ? LayerToImage.EGraphMode.GRAPH_3D : LayerToImage.EGraphMode.GRAPH_2D, true);
            string filePath = Path.ChangeExtension(Path.GetTempFileName(), "png");
            bmp.Save(filePath);
            Process.Start(filePath);
        }
        #endregion

        #region Data members
        private BoxProperties _caseProperties;
        private PalletProperties _palletProperties;
        private ConstraintSetCasePallet _constraintSet;
        private List<Layer2DBrickImp> _layers;
        #endregion
    }
}
