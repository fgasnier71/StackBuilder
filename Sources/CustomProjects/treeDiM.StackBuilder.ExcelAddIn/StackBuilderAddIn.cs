#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

using treeDiM.StackBuilder.ExcelAddIn.Properties;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class StackBuilderAddIn
    {
        #region Mode
        public enum Mode {  ANALYSIS_PERROW, ANALYSIS_PERSHEET }
        public Mode CurrentMode { get; set; }
        #endregion
        #region Handlers
        private void StackBuilderAddIn_Startup(object sender, System.EventArgs e)
        {
            UnitsManager.CurrentUnitSystem = (UnitsManager.UnitSystem)Settings.Default.UnitSystem;
            ChangeMode( (Mode)Settings.Default.Mode );

        }
        private void StackBuilderAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Settings.Default.UnitSystem = (int)UnitsManager.CurrentUnitSystem;
            Settings.Default.Mode = (int)CurrentMode;
        }
        #endregion

        #region Addin pane
        public void ShowPane()
        {
            RemovePane();
            UserControl userCtrl = null;
            string title = string.Empty;
            switch (CurrentMode)
            {
                case Mode.ANALYSIS_PERSHEET:
                    userCtrl = new UCtrlPerSheetAnalysis();
                    title = UCtrlPerSheetAnalysis.TaskPaneTitle;
                    break;
                case Mode.ANALYSIS_PERROW:
                    userCtrl = new UCtrlPerRowAnalysis();
                    title = UCtrlPerRowAnalysis.TaskPaneTitle;
                    break;
                default: break;
            }
            var customPane = CustomTaskPanes.Add(userCtrl, title);
            customPane.Width = userCtrl.Width + 300;
            customPane.Visible = true;
        }
        public void RemovePane()
        {
            for (int i = 0; i < this.CustomTaskPanes.Count; ++i)
            {
                var ctp = this.CustomTaskPanes[i];
                if (ctp.Title == UCtrlPerRowAnalysis.TaskPaneTitle || ctp.Title == UCtrlPerSheetAnalysis.TaskPaneTitle)
                    this.CustomTaskPanes.RemoveAt(i);
            }
        }
        #endregion

        #region ChangeMode
        public void ChangeMode(Mode mode)
        {
            CurrentMode = mode;
            ShowPane();
            ModeChanged(mode);
        }
        #endregion

        #region Compute
        public void Compute()
        {
            Excel.Worksheet xlSheet = Globals.StackBuilderAddIn.Application.ActiveSheet as Excel.Worksheet;
            if (null != xlSheet)
            {
                Console.WriteLine(string.Format("Sheet name = {0}", xlSheet.Name));

                double caseLength = ReadDouble(xlSheet, Settings.Default.CellCaseLength, Resources.ID_CASE_LENGTH);
                double caseWidth = ReadDouble(xlSheet, Settings.Default.CellCaseWidth, Resources.ID_CASE_WIDTH);
                double caseHeight = ReadDouble(xlSheet, Settings.Default.CellCaseHeight, Resources.ID_CASE_HEIGHT);
                double caseWeight = ReadDouble(xlSheet, Settings.Default.CellCaseWeight, Resources.ID_CASE_WEIGHT);

                double palletLength = ReadDouble(xlSheet, Settings.Default.CellPalletLength, Resources.ID_PALLET_LENGTH);
                double palletWidth = ReadDouble(xlSheet, Settings.Default.CellPalletWidth, Resources.ID_PALLET_WIDTH);
                double palletHeight = ReadDouble(xlSheet, Settings.Default.CellPalletHeight, Resources.ID_PALLET_HEIGHT);
                double palletWeight = ReadDouble(xlSheet, Settings.Default.CellPalletWeight, Resources.ID_PALLET_WEIGHT);

                double palletMaximumHeight = ReadDouble(xlSheet, Settings.Default.CellMaxPalletHeight, Resources.ID_CONSTRAINTS_PALLETMAXIHEIGHT);
                double palletMaximumWeight = ReadDouble(xlSheet, Settings.Default.CellMaxPalletWeight, Resources.ID_CONSTRAINTS_PALLETMAXIWEIGHT);

                double imageLeft = UnitsManager.ConvertLengthTo(Settings.Default.ImageLeft, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035;
                double imageTop = UnitsManager.ConvertLengthTo(Settings.Default.ImageTop, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035;

                // delete any existing image with same position
                foreach (Excel.Shape s in xlSheet.Shapes)
                {
                    if (Math.Abs(s.Left - imageLeft) < 0.001
                        && Math.Abs(s.Top - imageTop) < 0.001)
                        s.Delete();
                }
                // initialize units
                UnitsManager.CurrentUnitSystem = (UnitsManager.UnitSystem)Properties.Settings.Default.UnitSystem;

                // ###
                // build a case
                BoxProperties bProperties = new BoxProperties(null, caseLength, caseWidth, caseHeight);
                bProperties.SetWeight(caseWeight);
                bProperties.SetColor(Color.Chocolate);
                bProperties.TapeWidth = new OptDouble(true, 5);
                bProperties.TapeColor = Color.Beige;

                // build a pallet
                PalletProperties palletProperties = new PalletProperties(null, PalletTypeName, palletLength, palletWidth, palletHeight);
                palletProperties.Weight = palletWeight;
                palletProperties.Color = Color.Yellow;

                // build a constraint set
                ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
                constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
                constraintSet.SetMaxHeight(new OptDouble(true, palletMaximumHeight));
                constraintSet.OptMaxWeight = new OptDouble(true, palletMaximumWeight);

                // use a solver and get a list of sorted analyses + select the best one
                SolverCasePallet solver = new SolverCasePallet(bProperties, palletProperties);
                List<AnalysisHomo> analyses = solver.BuildAnalyses(constraintSet, true);
                if (analyses.Count > 0)
                {
                    AnalysisHomo analysis = analyses[0];
                    int caseCount = analysis.Solution.ItemCount;      // <- your case count
                    double loadWeight = analysis.Solution.LoadWeight;
                    double totalWeight = analysis.Solution.Weight;   // <- your pallet weight

                    // generate image
                    Graphics3DImage graphics = null;
                    // generate image path
                    string stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
                    graphics = new Graphics3DImage(new Size(Settings.Default.ImageSize, Settings.Default.ImageSize))
                    {
                        FontSizeRatio = Settings.Default.FontSizeRatio,
                        CameraPosition = Graphics3D.Corner_0
                    };
                    ViewerSolution sv = new ViewerSolution(analysis.Solution);
                    sv.Draw(graphics, Transform3D.Identity);
                    graphics.Flush();
                    Bitmap bmp = graphics.Bitmap;
                    bmp.Save(stackImagePath);

                    // write values
                    WriteInt(xlSheet, Settings.Default.CellNoCases, Resources.ID_RESULT_NOCASES, caseCount);
                    WriteDouble(xlSheet, Settings.Default.CellLoadWeight, Resources.ID_RESULT_LOADWEIGHT, loadWeight);
                    WriteDouble(xlSheet, Settings.Default.CellTotalPalletWeight, Resources.ID_RESULT_TOTALPALLETWEIGHT, totalWeight);

                    // write picture
                    string filePath = string.Empty;
                    Globals.StackBuilderAddIn.Application.ActiveSheet.Shapes.AddPicture(
                        stackImagePath,
                        Microsoft.Office.Core.MsoTriState.msoFalse,
                        Microsoft.Office.Core.MsoTriState.msoCTrue,
                        imageLeft,
                        imageTop,
                        UnitsManager.ConvertLengthTo(Settings.Default.ImageWidth, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035,
                        UnitsManager.ConvertLengthTo(Settings.Default.ImageHeight, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035);
                }
                else
                    MessageBox.Show(Resources.ID_RESULT_NOSOLUTIONFOUND,
                        AppDomain.CurrentDomain.FriendlyName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                // ###
            }

        }
        public Excel.Worksheet GetActiveWorksheet() { return (Excel.Worksheet)Application.ActiveSheet; }
        private string PalletTypeName { get { return "EUR2"; } }
        private double ReadDouble(Excel.Worksheet wSheet, string cellName, string vName)
        {
            try
            {
                var cell = wSheet.Range[cellName, Type.Missing];
                var content = cell.Value2;
                if (content is double)
                    return (double)content;
                else
                    throw new Exception("Not a double");
            }
            catch (Exception ex)
            {
                throw new ExceptionCellReading(vName, cellName, ex.Message);
            }
        }
        private void WriteInt(Excel.Worksheet wSheet, string cellName, string vName, int v)
        {
            try
            {
                var cell = wSheet.Range[cellName, Type.Missing];
                cell.Value2 = v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void WriteDouble(Excel.Worksheet wSheet, string cellName, string vName, double v)
        {
            try
            {
                var cell = wSheet.Range[cellName, Type.Missing];
                cell.Value2 = v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Open sample file
        public void OpenSampleFile()
        {
            // Get the assembly information
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();
            // Location is where the assembly is run from 
            string assemblyLocation = assemblyInfo.Location;
            // CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
            string samplePath = Path.Combine(Path.GetDirectoryName(uriCodeBase.LocalPath.ToString()), Settings.Default.SampleExcelFile);
            string samplePathCopy = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(samplePath));
            // Copy sample file to temp directory
            File.Copy(samplePath, samplePathCopy);
            // Open file
            FileInfo f = new FileInfo(samplePathCopy);
            object misval = System.Reflection.Missing.Value;
            Excel.Workbook wb = Globals.StackBuilderAddIn.Application.Workbooks.Open(
                f.FullName, misval, misval, misval, misval,
                misval, misval, misval, misval, misval, misval, misval,
                misval, misval, misval);
        }
        #endregion

        #region VSTO generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new EventHandler(StackBuilderAddIn_Startup);
            this.Shutdown += new EventHandler(StackBuilderAddIn_Shutdown);
        }
        #endregion

        private const string TASKPANETITLE = "StackBuilder";

        public delegate void ModeChange(Mode mode);
        public event ModeChange ModeChanged;
    }
}
