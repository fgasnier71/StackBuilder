#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

using treeDiM.StackBuilder.ExcelAddIn.Properties;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class StackBuilderAddIn
    {
        #region Mode
        public enum Mode
        {
            AnalysisPerRow
            , AnalysisPerSheet
        }
        public Mode CurrentMode { get; set; }
        #endregion
        #region Handlers
        private void StackBuilderAddIn_Startup(object sender, EventArgs e)
        {
            UnitsManager.CurrentUnitSystem = (UnitsManager.UnitSystem)Settings.Default.UnitSystem;
        }
        private void StackBuilderAddIn_Shutdown(object sender, EventArgs e)
        {
            Settings.Default.UnitSystem = (int)UnitsManager.CurrentUnitSystem;
            Settings.Default.Mode = (int)CurrentMode;
        }
        #endregion

        #region Addin pane
        public void ShowPane()
        {
            RemovePane();
            UserControl userCtrl;
            string title;
            switch (CurrentMode)
            {
                case Mode.AnalysisPerSheet:
                    userCtrl = new UCtrlPerSheetAnalysis();
                    title = UCtrlPerSheetAnalysis.TaskPaneTitle;
                    break;
                case Mode.AnalysisPerRow:
                    userCtrl = new UCtrlPerRowAnalysis();
                    title = UCtrlPerRowAnalysis.TaskPaneTitle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var customPane = CustomTaskPanes.Add(userCtrl, title);
            customPane.Width = userCtrl.Width + 300;
            customPane.Visible = true;
        }
        public void RemovePane()
        {
            for (var i = 0; i < CustomTaskPanes.Count; ++i)
            {
                var ctp = CustomTaskPanes[i];
                if (ctp.Title == UCtrlPerRowAnalysis.TaskPaneTitle || ctp.Title == UCtrlPerSheetAnalysis.TaskPaneTitle)
                    CustomTaskPanes.RemoveAt(i);
            }
        }
        #endregion

        #region ChangeMode
        public void ChangeMode(Mode mode)
        {
            CurrentMode = mode;
            ShowPane();
            ModeChanged?.Invoke(mode);
        }
        #endregion

        #region Compute
        public void Compute()
        {
            if (!(Globals.StackBuilderAddIn.Application.ActiveSheet is Excel.Worksheet xlSheet)) return;
            Console.WriteLine($"Sheet name = {xlSheet.Name}");

            var caseLength = ReadDouble(xlSheet, Settings.Default.CellCaseLength, Resources.ID_CASE_LENGTH);
            var caseWidth = ReadDouble(xlSheet, Settings.Default.CellCaseWidth, Resources.ID_CASE_WIDTH);
            var caseHeight = ReadDouble(xlSheet, Settings.Default.CellCaseHeight, Resources.ID_CASE_HEIGHT);
            var caseWeight = ReadDouble(xlSheet, Settings.Default.CellCaseWeight, Resources.ID_CASE_WEIGHT);

            var palletLength = ReadDouble(xlSheet, Settings.Default.CellPalletLength, Resources.ID_PALLET_LENGTH);
            var palletWidth = ReadDouble(xlSheet, Settings.Default.CellPalletWidth, Resources.ID_PALLET_WIDTH);
            var palletHeight = ReadDouble(xlSheet, Settings.Default.CellPalletHeight, Resources.ID_PALLET_HEIGHT);
            var palletWeight = ReadDouble(xlSheet, Settings.Default.CellPalletWeight, Resources.ID_PALLET_WEIGHT);

            var palletMaximumHeight = ReadDouble(xlSheet, Settings.Default.CellMaxPalletHeight, Resources.ID_CONSTRAINTS_PALLETMAXIHEIGHT);
            var palletMaximumWeight = ReadDouble(xlSheet, Settings.Default.CellMaxPalletWeight, Resources.ID_CONSTRAINTS_PALLETMAXIWEIGHT);

            var imageLeft = UnitsManager.ConvertLengthTo(Settings.Default.ImageLeft, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035;
            var imageTop = UnitsManager.ConvertLengthTo(Settings.Default.ImageTop, UnitsManager.UnitSystem.UNIT_METRIC2) / 0.035;

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
            var bProperties = new BoxProperties(null, caseLength, caseWidth, caseHeight);
            bProperties.SetWeight(caseWeight);
            bProperties.SetColor(Color.Chocolate);
            bProperties.TapeWidth = new OptDouble(true, 5);
            bProperties.TapeColor = Color.Beige;

            // build a pallet
            var palletProperties = new PalletProperties(null, PalletTypeName, palletLength, palletWidth, palletHeight);
            palletProperties.Weight = palletWeight;
            palletProperties.Color = Color.Yellow;

            // build a constraint set
            var constraintSet = new ConstraintSetCasePallet();
            constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
            constraintSet.SetMaxHeight(new OptDouble(true, palletMaximumHeight));
            constraintSet.OptMaxWeight = new OptDouble(true, palletMaximumWeight);

            // use a solver and get a list of sorted analyses + select the best one
            var solver = new SolverCasePallet(bProperties, palletProperties, constraintSet);
            var analyses = solver.BuildAnalyses(true);
            if (analyses.Count > 0)
            {
                var analysis = analyses[0];
                var caseCount = analysis.Solution.ItemCount;      // <- your case count
                var loadWeight = analysis.Solution.LoadWeight;
                var totalWeight = analysis.Solution.Weight;   // <- your pallet weight

                // generate image
                Graphics3DImage graphics = null;
                // generate image path
                var stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
                graphics = new Graphics3DImage(new Size(Settings.Default.ImageSize, Settings.Default.ImageSize))
                {
                    FontSizeRatio = Settings.Default.FontSizeRatio,
                    CameraPosition = Graphics3D.Corner_0
                };
                var sv = new ViewerSolution(analysis.SolutionLay);
                sv.Draw(graphics, Transform3D.Identity);
                graphics.Flush();
                Bitmap bmp = graphics.Bitmap;
                bmp.Save(stackImagePath);

                // write values
                WriteInt(xlSheet, Settings.Default.CellNoCases, Resources.ID_RESULT_NOCASES, caseCount);
                WriteDouble(xlSheet, Settings.Default.CellLoadWeight, Resources.ID_RESULT_LOADWEIGHT, loadWeight);
                WriteDouble(xlSheet, Settings.Default.CellTotalPalletWeight, Resources.ID_RESULT_TOTALPALLETWEIGHT, totalWeight);

                // write picture
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
        public Excel.Worksheet GetActiveWorksheet() => (Excel.Worksheet)Application.ActiveSheet;
        private string PalletTypeName { get; } = "EUR2";
        private static double ReadDouble(Excel._Worksheet wSheet, string cellName, string vName)
        {
            try
            {
                var cell = wSheet.Range[cellName, Type.Missing];
                var content = cell.Value2;
                if (content is double dValue)
                    return dValue;
                throw new Exception("Not a double");
            }
            catch (Exception ex)
            {
                throw new ExceptionCellReading(vName, cellName, ex.Message);
            }
        }
        private static void WriteInt(Excel._Worksheet wSheet, string cellName, string vName, int v)
        {
            var cell = wSheet.Range[cellName, Type.Missing];
            cell.Value2 = v;
        }
        private static void WriteDouble(Excel._Worksheet wSheet, string cellName, string vName, double v)
        {
            var cell = wSheet.Range[cellName, Type.Missing];
            cell.Value2 = v;
        }
        #endregion

        #region Open sample file
        public void OpenSampleFile()
        {
            // Get the assembly information
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();
            // Location is where the assembly is run from 
            // CodeBase is the location of the ClickOnce deployment files
            var uriCodeBase = new Uri(assemblyInfo.CodeBase);
            var samplePath = Path.Combine(Path.GetDirectoryName(uriCodeBase.LocalPath) ?? string.Empty, Settings.Default.SampleExcelFile);
            var samplePathCopy = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(samplePath));
            // Copy sample file to temp directory
            File.Copy(samplePath, samplePathCopy);
            // Open file
            FileInfo f = new FileInfo(samplePathCopy);
            object missVal = System.Reflection.Missing.Value;
            var wb = Globals.StackBuilderAddIn.Application.Workbooks.Open(
                f.FullName, missVal, missVal, missVal, missVal,
                missVal, missVal, missVal, missVal, missVal, missVal, missVal,
                missVal, missVal, missVal);
        }
        #endregion

        #region VSTO generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += StackBuilderAddIn_Startup;
            Shutdown += StackBuilderAddIn_Shutdown;

            Application.WorkbookOpen += OnWorkbookOpen;
            ((Excel.AppEvents_Event)Application).NewWorkbook += OnNewWorkbook;
        }

        private void OnNewWorkbook(Excel.Workbook wb)
        {
            ChangeMode(CurrentMode);
        }
        private void OnWorkbookOpen(Excel.Workbook wb)
        {
            ChangeMode(CurrentMode);
        }
        #endregion

        public delegate void ModeChange(Mode mode);
        public event ModeChange ModeChanged;
    }
}
