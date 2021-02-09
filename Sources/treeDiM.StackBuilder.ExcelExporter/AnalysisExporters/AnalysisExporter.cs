#region Using directives
using System;
using System.Drawing;
using System.IO;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal abstract class AnalysisExporter
    {
        protected void CreateSheet(Workbook xlWorkBook)
        {
            WSheet = (Worksheet)xlWorkBook.Worksheets.Add();
            // change sheet name
            WSheet.Name = SheetName;
            // create header
            int colIndex = 1;
            foreach (string s in Headers)
                WSheet.Cells[1, colIndex++] = s;
            Range headerRange = WSheet.get_Range((Range)WSheet.Cells[1, 1], (Range)WSheet.Cells[1, Headers.Length]);
            headerRange.Font.Bold = true;
            headerRange.Columns.AutoFit();

            RowIndex++;
        }
        public void ExportAnalysis(Workbook xlWorkBook, Analysis analysis)
        {
            if (!MatchesAnalysisType(analysis))
                return;
            if (null == WSheet)
                CreateSheet(xlWorkBook);
            ExportAnalysisSpecific(analysis);

            RowIndex++;
        }
        protected abstract bool MatchesAnalysisType(Analysis analysis);
        protected abstract void ExportAnalysisSpecific(Analysis analysis);
        protected abstract string[] Headers { get; }
        protected abstract string SheetName { get; }

        protected int RowIndex { get; set; } = 1;
        protected Worksheet WSheet { get; set; }

        protected void InsertImage(Analysis analysis, int colIndex)
        {
            try
            {
                if (analysis is AnalysisLayered analysisHomo)
                {
                    var stackImagePath = Path.Combine(Path.ChangeExtension(Path.GetTempFileName(), "png"));
                    var graphics = new Graphics3DImage(new Size(768, 768))
                    {
                        FontSizeRatio = 0.01f,
                        CameraPosition = Graphics3D.Corner_0
                    };
                    using (ViewerSolution sv = new ViewerSolution(analysisHomo.SolutionLay))
                        sv.Draw(graphics, Transform3D.Identity);
                    graphics.Flush();
                    Bitmap bmp = graphics.Bitmap;
                    bmp.Save(stackImagePath, System.Drawing.Imaging.ImageFormat.Png);
                    Range imageCell = (Range)WSheet.Cells[RowIndex, colIndex];
                    imageCell.RowHeight = 128;
                    imageCell.ColumnWidth = 24;
                    WSheet.Shapes.AddPicture(stackImagePath,
                        LinkToFile: MsoTriState.msoFalse,
                        SaveWithDocument: MsoTriState.msoCTrue,
                        Left: float.Parse(imageCell.Left.ToString()) + 1,
                        Top: float.Parse(imageCell.Top.ToString()) + 1,
                        Width: float.Parse(imageCell.Width.ToString()) - 2,
                        Height: float.Parse(imageCell.Height.ToString()) - 2
                        );
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Failed to insert image in Excel sheet with error:{ex.Message}");
            }
        }

        protected static ILog _log = LogManager.GetLogger(typeof(AnalysisExporter));
    }
}
