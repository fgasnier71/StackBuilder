#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormOptimizePack : Form, IItemBaseFilter, IDrawingContainer
    {
        #region Constructor
        public FormOptimizePack(DocumentSB document)
        {
            InitializeComponent();
            // set  unit labels
            UnitsManager.AdaptUnitLabels(this);
            // document 
            _doc = document;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // initialize combo boxes
            cbBoxes.Initialize(_doc, this, null);
            cbPallets.Initialize(_doc, this, null);
            // initialize graph containers
            graphCtrlPack.DrawingContainer = this;
            graphCtrlSolution.DrawingContainer = this;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // save settings
            Settings.Default.NumberWallsLength = uCtrlNoWalls.NoX;
            Settings.Default.NumberWallsWidth = uCtrlNoWalls.NoY;
            Settings.Default.NumberWallsHeight = uCtrlNoWalls.NoZ;
            Settings.Default.PalletHeight = MaximumPalletHeight;
            Settings.Default.WallThickness = uCtrlWallThickness.Value;
            Settings.Default.WallSurfaceMass = uCtrlSurfacicMass.Value;
            Settings.Default.NumberBoxesPerCase = (int)nudNumber.Value;
            // window position
            if (null == Settings.Default.FormOptimizeCasePosition)
                Settings.Default.FormOptimizeCasePosition = new WindowSettings();
            Settings.Default.FormOptimizeCasePosition.Record(this);

        }
        #endregion

        #region Status toolstrip updating
        public virtual void UpdateStatus(string message)
        {
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;

            bnCreateAnalysis.Enabled = (null != SelectedAnalysis);
        }
        #endregion

        #region IItemBaseFilter
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbBoxes)
            {
                BoxProperties bProperties = itemBase as BoxProperties;
                return null != bProperties;
            }
            if (ctrl == cbPallets)
            {
                PalletProperties palletProperties = itemBase as PalletProperties;
                return null != palletProperties;
            }
            return true; 
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            try
            {
                if (graphCtrlPack == ctrl)
                { 
                
                }
                else if (graphCtrlSolution == ctrl)
                { 
                
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
            try
            {
                // clear all existing rows
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Event handlers
        private void onCreateAnalysis(object sender, EventArgs e)
        {
            try
            {
                // selected analysis -> get pack
                AnalysisCasePallet analysisSel = SelectedAnalysis;
                PackProperties packSel = analysisSel.Content as PackProperties;
                // create pack
                PackProperties packProperties = _doc.CreateNewPack(packSel);
                // create analysis
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Private properties
        private BoxProperties SelectedBox
        { get { return cbBoxes.SelectedType as BoxProperties; } }
        private PalletProperties SelectedPallet
        { get { return cbPallets.SelectedType as PalletProperties; } }
        private AnalysisCasePallet SelectedAnalysis
        { get { return _selectedAnalysis as AnalysisCasePallet; } }

        private double OverhangX { get { return uCtrlOverhang.ValueX; } }
        private double OverhangY { get { return uCtrlOverhang.ValueY; } }
        private double MaxLength { get { return uCtrlPackDimensionsMax.ValueX; } }
        private double MaxWidth { get { return uCtrlPackDimensionsMax.ValueY; } }
        private double MaxHeight { get { return uCtrlPackDimensionsMax.ValueZ; } }
        private double MinLength
        {
            get { return uCtrlPackDimensionsMin.ValueX; }
            set { uCtrlPackDimensionsMin.ValueX = value; }
        }
        private double MinWidth
        {
            get { return uCtrlPackDimensionsMin.ValueY; }
            set { uCtrlPackDimensionsMin.ValueY = value; }
        }
        private double MinHeight
        {
            get { return uCtrlPackDimensionsMin.ValueZ; }
            set { uCtrlPackDimensionsMin.ValueZ = value; }
        }
        private int BoxPerCase { get { return (int)nudNumber.Value; } }
        private int[] NoWalls
        {
            get
            {
                int[] noWalls = new int[3];
                noWalls[0] = uCtrlNoWalls.NoX;
                noWalls[1] = uCtrlNoWalls.NoY;
                noWalls[2] = uCtrlNoWalls.NoZ;
                return noWalls;
            }
        }
        private double WallThickness { get { return uCtrlWallThickness.Value; } }
        private double WallSurfaceMass { get { return uCtrlSurfacicMass.Value; } }

        private bool ForceVerticalBoxOrientation
        {
            get { return chkVerticalOrientationOnly.Checked; }
            set { chkVerticalOrientationOnly.Checked = value; }
        }
        private double MaximumPalletHeight
        {
            get { return uCtrlPalletHeight.Value; }
            set { uCtrlPalletHeight.Value = value; }
        }
        #endregion

        #region Data members
        private DocumentSB _doc;
        private List<Analysis> _analyses = new List<Analysis>();
        private Analysis _selectedAnalysis;
        private static ILog _log = LogManager.GetLogger(typeof(FormOptimizePack));
        #endregion

    }
}
