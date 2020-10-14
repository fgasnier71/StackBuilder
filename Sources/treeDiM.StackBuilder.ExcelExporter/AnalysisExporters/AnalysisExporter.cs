#region Using directives
using System.Drawing;
using System.IO;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

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
            if (!(analysis is AnalysisLayered analysisHomo))
                return;
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
                LinkToFile: MsoTriState.msoFalse, SaveWithDocument: MsoTriState.msoCTrue,
                Left: (int)imageCell.Left + 1, Top: (int)imageCell.Top + 1, Width: (int)imageCell.Width - 2, Height: (int)imageCell.Height - 2);
        }
    }
}
