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
using System.Diagnostics;

using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;

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
            StackCountMax = 1000;
            LargestDimMin = 10;

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
            if (0 == Mode)
            {
                Pallet pallet = new Pallet(PalletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
                graphics.AddDimensions(new DimensionCube(PalletLength, PalletWidth, PalletHeight));
            }
            else
            {
                Truck truck = new Truck(TruckProperties);
                truck.DrawBegin(graphics);
                truck.DrawEnd(graphics);
                graphics.AddDimensions(new DimensionCube(TruckLength, TruckWidth, TruckHeight));
            }
        }
        #endregion
        #region Private properties
        private string InputFilePath
        {
            get { return fileSelectExcel.FileName; }
            set { fileSelectExcel.FileName = value; }
        }
        private string OutputFilePath
        {
            get { return fileSelectOutput.FileName; }
            set { fileSelectOutput.FileName = value; }
        }
        private string OutputFilePathSuggested
        {
            get
            {
                string outputPath = Path.Combine(Path.GetDirectoryName(InputFilePath), Path.GetFileNameWithoutExtension(InputFilePath)+ "_output");
                return Path.ChangeExtension(outputPath, Path.GetExtension(InputFilePath));
            }
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
                palletProperties.Color = Color.Yellow;
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
            else if (!FitsIn(_dimensionsMax, StackingDims))
                message = Resources.IDS_NOTALLCASESWILLFIT;

            // status label
            statusLabel.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
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
            {
                bool quitTrying = false;
                while (!quitTrying)
                {
                    try
                    {
                        ExcelDataReader.LoadFile(InputFilePath, ref _dataCases);
                        quitTrying = _dataCases.Count > 0;

                        if (_dataCases.Count > 0)
                        {
                            lbCaseLoaded.Text = string.Format("{0} case(s) loaded!", _dataCases.Count);

                            foreach (DataCase dc in _dataCases)
                            {
                                _dimensionsMax[0] = Math.Max(_dimensionsMax[0], dc.OuterDimensions[0]);
                                _dimensionsMax[1] = Math.Max(_dimensionsMax[1], dc.OuterDimensions[1]);
                                _dimensionsMax[2] = Math.Max(_dimensionsMax[2], dc.OuterDimensions[2]);
                            }

                            uCtrlPalletDimensions.ValueX = Math.Max(_dimensionsMax[0]+1.0, uCtrlPalletDimensions.ValueX);
                            uCtrlPalletDimensions.ValueY = Math.Max(_dimensionsMax[1]+1.0, uCtrlPalletDimensions.ValueY);
                            PalletMaximumHeight = Math.Max(_dimensionsMax[2]+PalletHeight+1.0, PalletMaximumHeight);

                            uCtrlTruckDimensions.ValueX = Math.Max(uCtrlTruckDimensions.ValueX, _dimensionsMax[0]+1.0);
                            uCtrlTruckDimensions.ValueY = Math.Max(uCtrlTruckDimensions.ValueY, _dimensionsMax[1]+1.0);
                            uCtrlTruckDimensions.ValueZ = Math.Max(uCtrlTruckDimensions.ValueZ, _dimensionsMax[2]+1.0);
                        }
                    }
                    catch (System.IO.IOException /*ex*/)
                    {
                        if (DialogResult.No == MessageBox.Show(string.Format("File {0} is locked. Make sure it is not opened in Excel.\nTry again?", Path.GetFileName(InputFilePath)),
                            System.Windows.Forms.Application.ProductName,
                            MessageBoxButtons.YesNo))
                            quitTrying = true;
                    }
                    catch (Exception /*ex*/)
                    {
                        MessageBox.Show(string.Format("Failed to load file {0}.", InputFilePath));
                        quitTrying = true;
                    }
                }
            }
            if (_dataCases.Count > 0)
                OutputFilePath = OutputFilePathSuggested;
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

            uCtrlTruckDimensions.Enabled = (1 == iMode);
            onDataChanged(this, e);
        }
        private void onDataChanged(object sender, EventArgs args)
        {
            graphCtrlPallet.Invalidate();
            UpdateStatus();
        }
        private void onGenerate(object sender, EventArgs e)
        {
            try
            {
                string outputFilePath = OutputFilePath;
                // check for overwrite
                if (File.Exists(outputFilePath))
                {
                    if (DialogResult.Yes != MessageBox.Show(
                        string.Format(Resources.IDS_OVERWRITE, Path.GetFileName(outputFilePath)),
                        System.Windows.Forms.Application.ProductName,
                        MessageBoxButtons.YesNo))
                        return;
                    else
                    {
                        try
                        {
                            File.Delete(outputFilePath);
                        }
                        catch (IOException /* ex */)
                        {
                            MessageBox.Show(
                                string.Format("File {0} is locked.\nMake sure it is not opened in Excel.", outputFilePath)
                                );
                            return;
                        }
                    }
                }
                // copy input file path
                File.Copy(InputFilePath, outputFilePath);
                // Modify output file & open file
                if (InsertPalletisationData(outputFilePath) && chkbOpenFile.Checked) {}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region Computing result
        private void generateResult(double length, double width, double height, double? weight, ref int stackCount, ref double stackWeight, ref string stackImagePath)
        {
            stackCount = 0;
            stackWeight = 0.0;

            // generate case
            BoxProperties bProperties = new BoxProperties(null, length, width, height);
            if (weight.HasValue) bProperties.SetWeight(weight.Value);
            bProperties.SetColor(Color.Chocolate);
            bProperties.TapeWidth = new OptDouble(true, 5);
            bProperties.TapeColor = Color.Beige;


            // generate image path
            stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSize, ImageSize));
            graphics.CameraPosition = Graphics3D.Corner_0;

            // compute analysis
            if (0 == Mode)
            {
                ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
                constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
                constraintSet.SetMaxHeight( new OptDouble(true, PalletMaximumHeight) );

                SolverCasePallet solver = new SolverCasePallet(bProperties, PalletProperties);
                List<Analysis> analyses = solver.BuildAnalyses(constraintSet);
                if (analyses.Count > 0)
                {
                    Analysis analysis = analyses[0];
                    stackCount = analysis.Solution.ItemCount;
                    stackWeight = analysis.Solution.Weight;

                    if (stackCount <= StackCountMax)
                    {
                        ViewerSolution sv = new ViewerSolution(analysis.Solution);
                        sv.Draw(graphics, Transform3D.Identity);
                        graphics.Flush();
                    }
                }
            }
            else
            {
                BoxProperties container = new BoxProperties(null, TruckLength, TruckWidth, TruckHeight, TruckLength, TruckWidth, TruckHeight);
                Color lblue = Color.LightBlue;
                container.SetAllColors(new Color[] { lblue, lblue, lblue, lblue, lblue, lblue });
                container.SetWeight(0.0);
                ConstraintSetBoxCase constraintSet = new ConstraintSetBoxCase(container);
                constraintSet.SetAllowedOrientations(new bool[] { false, false, true });

                SolverBoxCase solver = new SolverBoxCase(bProperties, container);
                List<Analysis> analyses = solver.BuildAnalyses(constraintSet);
                if (analyses.Count > 0)
                {
                    Analysis analysis = analyses[0];
                    stackCount = analysis.Solution.ItemCount;
                    stackWeight = analysis.Solution.Weight;

                    if (stackCount <= StackCountMax)
                    {
                        ViewerSolution sv = new ViewerSolution(analysis.Solution);
                        sv.Draw(graphics, Transform3D.Identity);
                        graphics.Flush();
                    }
                }
            }
            Bitmap bmp = graphics.Bitmap;
            bmp.Save(stackImagePath, System.Drawing.Imaging.ImageFormat.Png);

        }
        private double LargestDimMin
        {
            get { return uCtrlLargestDimMin.Value; }
            set { uCtrlLargestDimMin.Value = value; }
        }
        private int StackCountMax
        {
            set { nudStackCountMax.Value = (decimal)value; }
            get { return (int)nudStackCountMax.Value; }
        }
        private int ImageSize
        {
            get { return 768; }
        }
        private int ImageSizeDetail
        {
            get { return 256; }
        }
        private double[] StackingDims
        {
            get
            {
                double[] dims = new double[3];
                if (0 == Mode)
                {
                    dims[0] = uCtrlPalletDimensions.ValueX;
                    dims[1] = uCtrlPalletDimensions.ValueY;
                    dims[2] = PalletMaximumHeight - uCtrlPalletDimensions.ValueZ;
                }
                else
                { 
                    dims[0] = uCtrlTruckDimensions.ValueX;
                    dims[1] = uCtrlTruckDimensions.ValueY;
                    dims[2] = uCtrlTruckDimensions.ValueZ;                
                }
                return dims; 
            }
        }
        #endregion
        #region Helpers
        bool FitsIn(double[] dim0, double[] dim1)
        {
            for (int i = 0; i < 3; ++i)
                if (dim0[i] > dim1[i])
                    return false;
            return true;
        }
        #endregion
        #region Excel file loading / writing
        private bool InsertPalletisationData(string filePath)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                Workbooks xlWorkBooks = xlApp.Workbooks;
                Workbook xlWorkBook = xlWorkBooks.Open(filePath, Type.Missing, false );
                Worksheet xlWorkSheet = xlWorkBook.Worksheets.get_Item("Sheet1");
                Range range = xlWorkSheet.UsedRange;
                int rowCount = range.Rows.Count;
                // modify header
                Range countHeaderCell = xlWorkSheet.get_Range("m" + 1, "m" + 1);
                countHeaderCell.Value = "Count";
                Range weightHeaderCell = xlWorkSheet.get_Range("n" + 1, "n" + 1);
                weightHeaderCell.Value = "Weight";
                Range imageHeaderCell = xlWorkSheet.get_Range("o" + 1, "o" + 1);
                imageHeaderCell.Value = "Image";
                Range headerRange = xlWorkSheet.get_Range("a" + 1, "o" + 1);
                headerRange.Font.Bold = true;
                // modify range for images
                Range dataRange = xlWorkSheet.get_Range("a"+ 2, "l" + rowCount);
                dataRange.RowHeight = 128;
                Range imageRange = xlWorkSheet.get_Range("o" + 2, "o" + rowCount);
                imageRange.ColumnWidth = 24;
                double largestDimensionMinimum = LargestDimMin;

                // loop throw
                for (int iRow = 2; iRow <= rowCount; ++iRow)
                {
                    try
                    {
                        // get length
                        double length = (xlWorkSheet.get_Range("f" + iRow, "f" + iRow).Value);
                        // get width
                        double width = (xlWorkSheet.get_Range("g" + iRow, "g" + iRow).Value);
                        // get height
                        double height = (xlWorkSheet.get_Range("h" + iRow, "h" + iRow).Value);
                        // get weight
                        double? weight = (xlWorkSheet.get_Range("j" + iRow, "j" + iRow).Value);
                        double maxDimension = Math.Max(Math.Max(length, width), height);
                        if (maxDimension < largestDimensionMinimum) continue;
                        // compute stacking
                        int stackCount = 0;
                        double stackWeight = 0.0;
                        string stackImagePath = string.Empty;
                        generateResult(length, width, height, weight,
                            ref stackCount, ref stackWeight, ref stackImagePath);
                        // insert count & weight
                        Range countCell = xlWorkSheet.get_Range("m" + iRow, "m" + iRow);
                        countCell.Value = stackCount;
                        Range weightCell = xlWorkSheet.get_Range("n" + iRow, "n" + iRow);
                        weightCell.Value = stackWeight;
                        // insert image in "o"+iRow
                        Range imageCell = xlWorkSheet.get_Range("o" + iRow, "o" + iRow);
                        xlWorkSheet.Shapes.AddPicture(stackImagePath, MsoTriState.msoFalse, MsoTriState.msoCTrue,
                            imageCell.Left + 1, imageCell.Top + 1, imageCell.Width - 2, imageCell.Height - 2);
                    }
                    catch (System.OutOfMemoryException)
                    { }
                    catch (treeDiM.StackBuilder.Engine.EngineException)
                    { }
                    catch (Exception ex)
                    {
                        throw ex; // rethrow
                    }
                }
                xlWorkBook.Save();
                if (!chkbOpenFile.Checked) xlWorkBook.Close();
                xlWorkSheet = null;
                xlWorkBook = null;
                if (!chkbOpenFile.Checked) xlApp.Quit();

                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;        
        }
        #endregion
        #region Data members
        private List<DataCase> _dataCases = new List<DataCase>();
        private double[] _dimensionsMax = new double[3];
        #endregion
    }
}
