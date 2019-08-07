#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    public class ExporterProjetSummary
    {
        public static void ExportProjectSummaryToExcel(Document document)
        {
            // open excel file
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = true,
                DisplayAlerts = false
            };
            Workbooks xlWorkBooks = xlApp.Workbooks;
            Workbook xlWorkBook = xlWorkBooks.Add(Type.Missing);
            Worksheet xlWorkSheetCasePallet = xlWorkBook.Worksheets.get_Item(1);

            // create header
            xlWorkSheetCasePallet.Cells[1, 1] = "Analysis name";
            xlWorkSheetCasePallet.Cells[1, 2] = "Case name";
            xlWorkSheetCasePallet.Cells[1, 3] = "Case description";
            xlWorkSheetCasePallet.Cells[1, 4] = "Ext. length";
            xlWorkSheetCasePallet.Cells[1, 5] = "Ext. width";
            xlWorkSheetCasePallet.Cells[1, 6] = "Ext. height";
            xlWorkSheetCasePallet.Cells[1, 7] = "Max pallet height";
            xlWorkSheetCasePallet.Cells[1, 8] = "Solution case count";
            xlWorkSheetCasePallet.Cells[1, 9] = "Layers";
            xlWorkSheetCasePallet.Cells[1, 10] = "Cases per layer";
            xlWorkSheetCasePallet.Cells[1, 11] = "Load weight";
            xlWorkSheetCasePallet.Cells[1, 12] = "Weight";
            xlWorkSheetCasePallet.Cells[1, 13] = "Volume efficiency";
            xlWorkSheetCasePallet.Cells[1, 14] = "Image";

            Range headerRange = xlWorkSheetCasePallet.get_Range("A1", "N1");
            headerRange.Font.Bold = true;
            xlWorkSheetCasePallet.Columns.AutoFit();


            // *** get all users from Azure database and write them down
            int iRowCasePallet = 2;

            foreach (var analysis in document.Analyses)
            {
                try
                {
                    if (analysis is AnalysisCasePallet analysisCasePallet)
                    {
                        // analysis name
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 1] = analysisCasePallet.Name;
                        // case
                        BoxProperties caseProperties = analysisCasePallet.Content as BoxProperties;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 2] = caseProperties.Name;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 3] = caseProperties.Description;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 4] = caseProperties.Length;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 5] = caseProperties.Width;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 6] = caseProperties.Height;
                        // constraints
                        ConstraintSetCasePallet constraintSet = analysisCasePallet.ConstraintSet as ConstraintSetCasePallet;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 7] = constraintSet.OptMaxHeight.Value;
                        // solution
                        Solution sol = analysisCasePallet.Solution;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 8] = sol.ItemCount;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 9] = sol.LayerCount;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 10] = sol.LayerBoxCount(0);
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 11] = sol.LoadWeight;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 12] = sol.Weight;
                        xlWorkSheetCasePallet.Cells[iRowCasePallet, 13] = sol.VolumeEfficiency;

                        var stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
                        var graphics = new Graphics3DImage(new Size(768, 768))
                        {
                            FontSizeRatio = 0.01f,
                            CameraPosition = Graphics3D.Corner_0
                        };
                        using (ViewerSolution sv = new ViewerSolution(analysis.Solution))
                            sv.Draw(graphics, Transform3D.Identity);
                        graphics.Flush();
                        Bitmap bmp = graphics.Bitmap;
                        bmp.Save(stackImagePath, System.Drawing.Imaging.ImageFormat.Png);
                        Range imageCell = (Range)xlWorkSheetCasePallet.Cells[iRowCasePallet, 14];
                        imageCell.RowHeight = 128;
                        imageCell.ColumnWidth = 24;
                        xlWorkSheetCasePallet.Shapes.AddPicture(stackImagePath,
                            LinkToFile: MsoTriState.msoFalse, SaveWithDocument: MsoTriState.msoCTrue,
                            Left: imageCell.Left + 1, Top: imageCell.Top + 1, Width: imageCell.Width - 2, Height: imageCell.Height - 2);

                        ++iRowCasePallet;
                    }
                    else if (analysis is AnalysisBoxCase analysisBoxCase)
                    {
                    }
                    else if (analysis is AnalysisCaseTruck analysisCaseTruck)
                    {
                    }
                    else if (analysis is AnalysisCylinderPallet analysisCylinderPallet)
                    {
                    }
                    else if (analysis is AnalysisCylinderCase analysisCylinderCase)
                    {
                    }
                    else if (analysis is AnalysisCylinderTruck analysisCylinderTruck)
                    {
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                }
            }
        }
        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(ExporterProjetSummary));
        #endregion
    }
}
