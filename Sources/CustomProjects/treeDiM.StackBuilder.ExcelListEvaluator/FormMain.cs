#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;

using treeDiM.StackBuilder.ExcelListEvaluator.Properties;
#endregion

namespace treeDiM.StackBuilder.ExcelListEvaluator
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
            // logging
            log4net.Appender.RichTextBoxAppender.SetRichTextBox(richTextBoxLog, "RichTextBoxAppender");
            // initialize graph controls
            graphCtrlPallet.DrawingContainer = this;
            // initialize type combo
            cbPalletType.Items.AddRange(PalletData.TypeNames);

            PalletLength = Settings.Default.PalletLength;
            PalletWidth = Settings.Default.PalletWidth;
            PalletHeight = Settings.Default.PalletHeight;
            PalletMaximumHeight = Settings.Default.PalletMaximumHeight;
            PalletTypeName = Settings.Default.PalletTypeName;
            TruckLength = Settings.Default.ContainerLength;
            TruckWidth = Settings.Default.ContainerWidth;
            TruckHeight = Settings.Default.ContainerHeight;
            Mode = Settings.Default.Mode;
            chkbOpenFile.Checked = Settings.Default.OpenGeneratedFile;
            GenerateImage = Settings.Default.GenerateImage;
            InputFilePath = Settings.Default.InputFilePath;
            GenerateImageInFolder = Settings.Default.ImagesToFolder;
            DirectoryPathImages = Settings.Default.ImageFolder;
            AllowOnlyZOrientation = Settings.Default.AllowOnlyZOrientation;

            OnImageFolderChecked(this, null);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.PalletLength = PalletLength;
            Settings.Default.PalletWidth = PalletWidth;
            Settings.Default.PalletHeight = PalletHeight;
            Settings.Default.PalletMaximumHeight = PalletMaximumHeight;
            Settings.Default.PalletTypeName = PalletTypeName;
            Settings.Default.ContainerLength = TruckLength;
            Settings.Default.ContainerWidth = TruckWidth;
            Settings.Default.ContainerHeight = TruckHeight;
            Settings.Default.Mode = Mode;
            Settings.Default.OpenGeneratedFile = chkbOpenFile.Checked;
            Settings.Default.GenerateImage = GenerateImage;
            Settings.Default.InputFilePath = InputFilePath;
            Settings.Default.AllowOnlyZOrientation = AllowOnlyZOrientation;
            Settings.Default.ImagesToFolder = GenerateImageInFolder;
            Settings.Default.ImageFolder = DirectoryPathImages;
            Settings.Default.Save();
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
            get { return fsOutputExcelFile.FileName; }
            set { fsOutputExcelFile.FileName = value; }
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
            get { return tabCtrl.SelectedIndex; }
            set { tabCtrl.SelectedIndex = value; }
        }
        private bool GenerateImage { get { return chkbGenerateImage.Checked; } set { chkbGenerateImage.Checked = value; } }
        private bool GenerateImageInFolder { get { return chkbGenerateImageFolder.Checked; } set { chkbGenerateImageFolder.Checked = value; } }
        private bool GenerateReport => false;
        private string DirectoryPathImages { get { return tbDirectoryPath.Text; } set { tbDirectoryPath.Text = value; } }
        private double PalletLength { get { return uCtrlPalletDimensions.ValueX; } set { uCtrlPalletDimensions.ValueX = value; } }
        private double PalletWidth { get { return uCtrlPalletDimensions.ValueY; } set { uCtrlPalletDimensions.ValueY = value; } }
        private double PalletHeight { get { return uCtrlPalletDimensions.ValueZ;} set { uCtrlPalletDimensions.ValueZ = value; } }
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
                PalletProperties palletProperties = new PalletProperties(null, PalletTypeName, PalletLength, PalletWidth, PalletHeight)
                {
                    Weight = 20.0,
                    Color = Color.Yellow
                };
                return palletProperties;
            }
        }
        private TruckProperties TruckProperties
        {
            get
            {
                TruckProperties truck = new TruckProperties(null, TruckLength, TruckWidth, TruckHeight)
                {
                    Color = Color.LightBlue
                };
                return truck;
            }
        }
        private bool AllowOnlyZOrientation 
        {
            get { return chkbOnlyVerticalOrientation.Checked; }
            set { chkbOnlyVerticalOrientation.Checked = value; }
        }
        #endregion
        #region Status
        private void UpdateStatus()
        {
            bool bnGenerateEnabled = true;
            string message = string.Empty;
            if (!File.Exists(InputFilePath))
            {
                message = Resources.IDS_NOVALIDFILELOADED;
                bnGenerateEnabled = false;
            }
            else if (_dataCases.Count < 1)
            {
                message = Resources.IDS_NODATALOADED;
                bnGenerateEnabled = false;
            }
            else if (!FitsIn(_dimensionsMax, StackingDims))
                message = Resources.IDS_NOTALLCASESWILLFIT;
            else if (GenerateImageInFolder && !Directory.Exists(DirectoryPathImages))
            {
                message = Resources.IDS_IMAGEDIRECTORYDOESNOTEXISTS;
                bnGenerateEnabled = false;
            }

            // status label
            statusLabel.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            statusLabel.Text = string.IsNullOrEmpty(message) ? Resources.IDS_READY : message;
            // generate button
            bnGenerate.Enabled = bnGenerateEnabled;
        }
        #endregion
        #region Menu event handlers
        private void OnSettings(object sender, EventArgs e)
        {
            FormOptionsSettings form = new FormOptionsSettings();
            form.ShowDialog();
        }
        private void OnExit(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Control event handlers

        private void OnInputFilePathChanged(object sender, EventArgs e)
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
                        ExcelDataReader_ExcelListEvaluator.LoadFile(InputFilePath, ref _dataCases);
                        quitTrying = _dataCases.Count > 0;

                        _log.InfoFormat("{0} case(s) loaded!", _dataCases.Count);

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
                    catch (IOException ex)
                    {
                        _log.Info(ex.Message);
                        if (DialogResult.No == MessageBox.Show(string.Format("File {0} is locked. Make sure it is not opened in Excel.\nTry again?", Path.GetFileName(InputFilePath)),
                            System.Windows.Forms.Application.ProductName,
                            MessageBoxButtons.YesNo))
                            quitTrying = true;
                    }
                    catch (Exception ex)
                    {
                        _log.Info(ex.Message);
                        MessageBox.Show(string.Format("Failed to load file {0}.", InputFilePath));
                        quitTrying = true;
                    }
                }
            }
            if (_dataCases.Count > 0)
                OutputFilePath = OutputFilePathSuggested;
            UpdateStatus();
        }
        private void OnImageFolderChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        private void OnModeChanged(object sender, EventArgs e)
        {
            int iMode = Mode;
            uCtrlPalletDimensions.Enabled = (0 == iMode);
            uCtrlMaximumPalletHeight.Enabled = (0 == iMode);
            lbPalletType.Enabled = (0 == iMode);
            cbPalletType.Enabled = (0 == iMode);

            uCtrlTruckDimensions.Enabled = (1 == iMode);
            OnDataChanged(this, e);
        }
        private void OnDataChanged(object sender, EventArgs args)
        {
            graphCtrlPallet.Invalidate();
            UpdateStatus();
        }
        private void OnGenerate(object sender, EventArgs e)
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
        private void OnImageFolderChecked(object sender, EventArgs e)
        {
            tbDirectoryPath.Enabled = chkbGenerateImageFolder.Checked;
            bnDirectoryPath.Enabled = chkbGenerateImageFolder.Checked;
            UpdateStatus();
        }
        private void OnEditDirectory(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            if (DialogResult.OK == folderBrowserDlg.ShowDialog())
                tbDirectoryPath.Text = folderBrowserDlg.SelectedPath;
        }
        #endregion
        #region Computing result
        private void GenerateResult(
            string name
            , double length, double width, double height
            , double? weight
            , ref int stackCount, ref double stackWeight, ref double stackEfficiency
            , ref string stackImagePath)
        {
            stackCount = 0;
            stackWeight = 0.0;
            stackImagePath = string.Empty;

            // generate case
            BoxProperties bProperties = new BoxProperties(null, length, width, height);
            if (weight.HasValue) bProperties.SetWeight(weight.Value);
            bProperties.SetColor(Color.Chocolate);
            bProperties.TapeWidth = new OptDouble(true, Math.Min(50.0, 0.5 * width));
            bProperties.TapeColor = Color.Beige;

            Graphics3DImage graphics = null;
            if (GenerateImage || GenerateImageInFolder)
            {
                // generate image path
                stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));

                if (GenerateImageInFolder)
                    stackImagePath = Path.ChangeExtension(Path.Combine(Path.Combine(DirectoryPathImages, name)), "png");

                graphics = new Graphics3DImage(new Size(ImageSize, ImageSize))
                {
                    FontSizeRatio = 0.01f,
                    CameraPosition = Graphics3D.Corner_0
                };
            }

            // compute analysis
            if (0 == Mode)
            {
                ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
                constraintSet.SetAllowedOrientations(new bool[] { !AllowOnlyZOrientation, !AllowOnlyZOrientation, true });
                constraintSet.SetMaxHeight(new OptDouble(true, PalletMaximumHeight));

                SolverCasePallet solver = new SolverCasePallet(bProperties, PalletProperties);
                List<Analysis> analyses = solver.BuildAnalyses(constraintSet, false);
                if (analyses.Count > 0)
                {
                    Analysis analysis = analyses[0];
                    stackCount = analysis.Solution.ItemCount;
                    stackWeight = analysis.Solution.Weight;
                    stackEfficiency = analysis.Solution.VolumeEfficiency;

                    if (stackCount <= StackCountMax)
                    {
                        if (GenerateImage || GenerateImageInFolder)
                        {
                            ViewerSolution sv = new ViewerSolution(analysis.Solution);
                            sv.Draw(graphics, Transform3D.Identity);
                            graphics.Flush();
                        }
                        if (GenerateReport)
                        {
                            ReportData inputData = new ReportData(analysis);
                            string outputFilePath = Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(OutputFilePath), string.Format("Report_{0}_on_{1}", analysis.Content.Name, analysis.Container.Name)), "doc");

                            ReportNode rnRoot = null;
                            Margins margins = new Margins();
                            Reporting.Reporter reporter = new ReporterMSWord(inputData, ref rnRoot, Reporter.TemplatePath, outputFilePath, margins);
                        }
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
                constraintSet.SetAllowedOrientations(new bool[] { !AllowOnlyZOrientation, !AllowOnlyZOrientation, true });

                SolverBoxCase solver = new SolverBoxCase(bProperties, container);
                List<Analysis> analyses = solver.BuildAnalyses(constraintSet, false);
                if (analyses.Count > 0)
                {
                    Analysis analysis = analyses[0];
                    stackCount = analysis.Solution.ItemCount;
                    stackWeight = analysis.Solution.Weight;

                    if ((GenerateImage || GenerateImageInFolder) && stackCount <= StackCountMax)
                    {
                        ViewerSolution sv = new ViewerSolution(analysis.Solution);
                        sv.Draw(graphics, Transform3D.Identity);
                        graphics.Flush();
                    }
                }
            }
            if (GenerateImage)
            {
                Bitmap bmp = graphics.Bitmap;
                bmp.Save(stackImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        private double LargestDimMin
        {
            get { return Settings.Default.LargestDimMinimum; }
        }
        private int StackCountMax
        {
            get { return Settings.Default.StackCountMax; }
        }
        private int ImageSize
        {
            get { return Settings.Default.ImageSize; }
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
                Range countHeaderCell = xlWorkSheet.get_Range("g" + 1, "g" + 1);
                countHeaderCell.Value = "Count";
                Range weightHeaderCell = xlWorkSheet.get_Range("h" + 1, "h" + 1);
                weightHeaderCell.Value = "Efficiency (%)";
                if (GenerateImage)
                {
                    Range imageHeaderCell = xlWorkSheet.get_Range("i" + 1, "i" + 1);
                    imageHeaderCell.Value = "Image";
                }
                Range headerRange = xlWorkSheet.get_Range("a" + 1, "i" + 1);
                headerRange.Font.Bold = true;
                // modify range for images
                if (GenerateImage)
                {
                    Range dataRange = xlWorkSheet.get_Range("a" + 2, "i" + rowCount);
                    dataRange.RowHeight = 128;
                }
                Range imageRange = xlWorkSheet.get_Range("i" + 2, "i" + rowCount);
                imageRange.ColumnWidth = 24;
                double largestDimensionMinimum = LargestDimMin;

                // loop throw
                for (int iRow = 2; iRow <= rowCount; ++iRow)
                {
                    try
                    {
                        // get name
                        string name = (xlWorkSheet.get_Range("a" + iRow, "a" + iRow).Value).ToString();
                        // get length
                        double length = (xlWorkSheet.get_Range("c" + iRow, "c" + iRow).Value);
                        // get width
                        double width = (xlWorkSheet.get_Range("d" + iRow, "d" + iRow).Value);
                        // get height
                        double height = (xlWorkSheet.get_Range("e" + iRow, "e" + iRow).Value);
                        // get weight
                        double? weight = null; // (xlWorkSheet.get_Range("j" + iRow, "j" + iRow).Value);
                        double maxDimension = Math.Max(Math.Max(length, width), height);
                        if (maxDimension < largestDimensionMinimum) continue;
                        // compute stacking
                        int stackCount = 0;
                        double stackWeight = 0.0, stackEfficiency = 0.0;
                        string stackImagePath = string.Empty;
                        GenerateResult(name, length, width, height, weight,
                            ref stackCount, ref stackWeight, ref stackEfficiency, ref stackImagePath);
                        // insert count & weight
                        Range countCell = xlWorkSheet.get_Range("g" + iRow, "g" + iRow);
                        countCell.Value = stackCount;
                        Range efficiencyCell = xlWorkSheet.get_Range("h" + iRow, "h" + iRow);
                        efficiencyCell.Value = stackEfficiency;
                        // insert image in "i"+iRow
                        if (GenerateImage)
                        {
                            Range imageCell = xlWorkSheet.get_Range("i" + iRow, "i" + iRow);
                            xlWorkSheet.Shapes.AddPicture(stackImagePath, MsoTriState.msoFalse, MsoTriState.msoCTrue,
                                imageCell.Left + 1, imageCell.Top + 1, imageCell.Width - 2, imageCell.Height - 2);
                        }
                    }
                    catch (System.OutOfMemoryException ex)
                    {
                        _log.Error(ex.Message);
                    }
                    catch (treeDiM.StackBuilder.Engine.EngineException ex)
                    {
                        _log.Error(ex.Message);
                    }
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
                _log.Error(ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;        
        }
        #endregion
        #region Data members
        private List<DataCase> _dataCases = new List<DataCase>();
        private double[] _dimensionsMax = new double[3];
        protected static ILog _log = LogManager.GetLogger(typeof(FormMain));
        #endregion
    }
}
