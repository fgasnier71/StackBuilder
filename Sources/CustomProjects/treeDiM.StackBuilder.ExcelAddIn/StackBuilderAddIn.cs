#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;

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
        #region Handlers
        private void StackBuilderAddIn_Startup(object sender, System.EventArgs e)
        {
        }
        private void StackBuilderAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #endregion

        #region Addin pane
        public void ShowPane()
        {
            var userControlMain = new UserControlMain();
            var customPane = this.CustomTaskPanes.Add(userControlMain, TASKPANETITLE);
            customPane.Width = userControlMain.Width;
            customPane.Visible = true;
        }
        public void RemovePane()
        {
            for (int i = 0; i < this.CustomTaskPanes.Count; ++i)
            {
                var ctp = this.CustomTaskPanes[i];
                if (ctp.Title == TASKPANETITLE)
                    this.CustomTaskPanes.RemoveAt(i);
            }
        }
        #endregion

        #region Compute
        public void Compute()
        {
            try
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
                    List<Analysis> analyses = solver.BuildAnalyses(constraintSet);
                    if (analyses.Count > 0)
                    {
                        Analysis analysis = analyses[0];
                        int caseCount = analysis.Solution.ItemCount;      // <- your case count
                        double loadWeight = analysis.Solution.LoadWeight;
                        double totalWeight = analysis.Solution.Weight;   // <- your pallet weight

                        Graphics3DImage graphics = null;
                        // generate image path
                        string stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
                        graphics = new Graphics3DImage(new Size(Settings.Default.ImageSize, Settings.Default.ImageSize));
                        graphics.FontSizeRatio = 0.01f;
                        graphics.CameraPosition = Graphics3D.Corner_0;
                        ViewerSolution sv = new ViewerSolution(analysis.Solution);
                        sv.Draw(graphics, Transform3D.Identity);
                        graphics.Flush();
                        Bitmap bmp = graphics.Bitmap;
                        bmp.Save(stackImagePath);


                        WriteInt(xlSheet, Settings.Default.CellNoCases, Resources.ID_RESULT_NOCASES, caseCount);
                        WriteDouble(xlSheet, Settings.Default.CellLoadWeight, Resources.ID_RESULT_LOADWEIGHT, loadWeight);
                        WriteDouble(xlSheet, Settings.Default.CellTotalPalletWeight, Resources.ID_RESULT_TOTALPALLETWEIGHT, totalWeight);

                        string filePath = string.Empty;

                        Globals.StackBuilderAddIn.Application.ActiveSheet.Shapes.AddPicture(
                            stackImagePath,
                            Microsoft.Office.Core.MsoTriState.msoFalse,
                            Microsoft.Office.Core.MsoTriState.msoCTrue,
                            Settings.Default.ImageX / 0.035, Settings.Default.ImageY / 0.035,
                            Settings.Default.ImageWidth / 0.035, Settings.Default.ImageHeight / 0.035);
                    }
                    // ###
                }
            }
            catch (ExceptionCellReading ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        #region VSTO generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(StackBuilderAddIn_Startup);
            this.Shutdown += new System.EventHandler(StackBuilderAddIn_Shutdown);
        }
        #endregion

        internal class ExceptionCellReading : Exception
        {
            public ExceptionCellReading(string vName, string cellName, string sMessage)
                : base(sMessage)
            {
                VName = vName;
                CellName = cellName;
            }

            public string VName { get; set; }
            public string CellName { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} expected in cell {1}", VName, CellName);
                sb.Append(base.ToString());
                return sb.ToString();
            }
        }

        private const string TASKPANETITLE = "StackBuilder";
    }
}
