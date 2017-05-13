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
using System.IO;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.ABYATExcelLoader.Properties;
#endregion

namespace treeDiM.StackBuilder.ABYATExcelLoader
{
    public partial class FormMain : Form, IDrawingContainer
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
            // initialize graph controls
            graphCtrlPallet.DrawingContainer = this;
            graphCtrlContainer.DrawingContainer = this;
            // initialize type combo
            cbPalletType.Items.AddRange(PalletData.TypeNames);

            PalletLength = Settings.Default.PalletLength;
            PalletWidth = Settings.Default.PalletWidth;
            PalletHeight = Settings.Default.PalletHeight;
            PalletWeight = Settings.Default.PalletWeight;
            PalletTypeName = Settings.Default.PalletTypeName;
            TruckLength = Settings.Default.ContainerLength;
            TruckWidth = Settings.Default.ContainerWidth;
            TruckHeight = Settings.Default.ContainerHeight;
            Mode = Settings.Default.Mode;
            chkbOpenFile.Checked = Settings.Default.OpenGeneratedFile;
            InputFilePath = Settings.Default.InputFilePath;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.PalletLength = PalletLength;
            Settings.Default.PalletWidth = PalletWidth;
            Settings.Default.PalletHeight = PalletHeight;
            Settings.Default.PalletWeight = PalletWeight;
            Settings.Default.PalletMaximumHeight = PalletMaximumHeight;
            Settings.Default.PalletTypeName = PalletTypeName;
            Settings.Default.ContainerLength = TruckLength;
            Settings.Default.ContainerWidth = TruckWidth;
            Settings.Default.ContainerHeight = TruckHeight;
            Settings.Default.Mode = Mode;
            Settings.Default.OpenGeneratedFile = chkbOpenFile.Checked;
            Settings.Default.InputFilePath = InputFilePath;
        }
        #endregion
        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (graphCtrlPallet == ctrl)
            {
                Pallet pallet = new Pallet(PalletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
                graphics.AddDimensions(new DimensionCube(PalletLength, PalletWidth, PalletHeight));
            }
            else if (graphCtrlContainer == ctrl)
            {
                Truck truck = new Truck(TruckProperties);
                truck.DrawBegin(graphics);
                truck.DrawEnd(graphics);
                graphics.AddDimensions(new DimensionCube(TruckLength, TruckWidth, TruckHeight));
            }
        }
        #endregion
        #region Build pallet / container properties
        private string InputFilePath
        {
            get { return fileSelectExcel.FileName; }
            set { fileSelectExcel.FileName = value; }
        }
        private int Mode
        {
            get { return rbPallet.Checked ? 0 : 1; }
            set { rbPallet.Checked = (0 == value); rbContainer.Checked = (1 == value); }
        }
        private double PalletLength { get { return uCtrlPalletDimensions.ValueX; } set { uCtrlPalletDimensions.ValueX = value; } }
        private double PalletWidth { get { return uCtrlPalletDimensions.ValueY; } set { uCtrlPalletDimensions.ValueY = value; } }
        private double PalletHeight { get { return uCtrlPalletDimensions.ValueZ;} set { uCtrlPalletDimensions.ValueZ = value; } }
        private double PalletWeight { get { return uCtrlPalletWeight.Value; } set { uCtrlPalletWeight.Value = value; } }
        private double PalletMaximumHeight { get { return uCtrlMaximumPalletHeight.Value; } set { uCtrlMaximumPalletHeight.Value = value; } }
        private string PalletTypeName
        {
            get { return cbPalletType.Items[cbPalletType.SelectedIndex].ToString(); }
            set
            {
                int index = 0;
                foreach (string item in cbPalletType.Items)
                {
                    if (string.Equals(item, value))
                        break;
                    ++index;
                }
                if (cbPalletType.Items.Count > index)
                    cbPalletType.SelectedIndex = index;
            }
        }
        private double TruckLength { get { return uCtrlTruckDimensions.ValueX; } set { uCtrlTruckDimensions.ValueX = value; } }
        private double TruckWidth { get { return uCtrlTruckDimensions.ValueY; } set { uCtrlTruckDimensions.ValueY = value; } }
        private double TruckHeight { get { return uCtrlTruckDimensions.ValueZ; } set { uCtrlTruckDimensions.ValueZ = value; } }
        private PalletProperties PalletProperties
        {
            get
            {
                PalletProperties palletProperties = new PalletProperties(null, PalletTypeName, PalletLength, PalletWidth, PalletHeight);
                palletProperties.Weight = PalletWeight;
                palletProperties.Color = Color.Gold;
                return palletProperties;
            }
        }
        private TruckProperties TruckProperties
        {
            get
            {
                TruckProperties truck = new TruckProperties(null, TruckLength, TruckWidth, TruckHeight);
                truck.Color = Color.LightBlue;
                return truck;
            }
        }

        #endregion
        #region Status
        private void UpdateStatus()
        {
            string message = string.Empty;
            if (!File.Exists(InputFilePath))
                message = Resources.IDS_NOVALIDFILELOADED;
            else if (_dataCases.Count < 1)
                message = Resources.IDS_NODATALOADED;

            // status label
            statusLabel.Text = string.IsNullOrEmpty(message) ? Resources.IDS_READY : message;
            // generate button
            bnGenerate.Enabled = _dataCases.Count > 0;
        }
        #endregion
        #region Menu event handlers
        private void onSettings(object sender, EventArgs e)
        {

        }
        private void onExit(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Control event handlers
        private void onInputFilePathChanged(object sender, EventArgs e)
        {
            string filePath = fileSelectExcel.FileName;
            _dataCases.Clear();
            if (File.Exists(InputFilePath))
                ExcelDataReader.LoadFile(InputFilePath, ref _dataCases);
            UpdateStatus();
        }
        private void onModeChanged(object sender, EventArgs e)
        {
            int iMode = Mode;
            uCtrlPalletDimensions.Enabled = (0 == iMode);
            uCtrlPalletWeight.Enabled = (0 == iMode);
            uCtrlMaximumPalletHeight.Enabled = (0 == iMode);
            lbPalletType.Enabled = (0 == iMode);
            cbPalletType.Enabled = (0 == iMode);
            graphCtrlPallet.Enabled  = (0 == iMode);

            uCtrlTruckDimensions.Enabled = (1 == iMode);
            graphCtrlContainer.Enabled = (1 == iMode);
        }
        private void onPalletChanged(object sender, EventArgs args)
        {
            graphCtrlPallet.Invalidate();
            UpdateStatus();
        }

        private void onContainerChanged(object sender, EventArgs args)
        {
            graphCtrlContainer.Invalidate();
            UpdateStatus();
        }
        private void onGenerate(object sender, EventArgs e)
        {

        }
        #endregion
        #region Excel file loading / writing
        #endregion
        #region Data members
        private List<DataCase> _dataCases = new List<DataCase>();
        #endregion
    }
}
