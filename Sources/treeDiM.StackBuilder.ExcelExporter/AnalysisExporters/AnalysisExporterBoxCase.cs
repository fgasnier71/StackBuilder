#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterBoxCase : AnalysisExporter
    {
        protected override string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Analysis name",
                    "Box name",
                    "Box description",
                    "Length",
                    "Width",
                    "Height",
                    "Case name",
                    "Box count",
                    "Layers",
                    "Box per layer",
                    "Load weight",
                    "Weight",
                    "Volume efficiency",
                    "Image"
                };
            }
        }

        protected override string SheetName => "Boxes in case";

        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisBoxCase = analysis as AnalysisBoxCase;
            // analysis name
            WSheet.Cells[RowIndex, 1] = analysisBoxCase.Name;
            // box
            if (analysisBoxCase.Content is BoxProperties boxProperties)
            {
                WSheet.Cells[RowIndex, 2] = boxProperties.Name;
                WSheet.Cells[RowIndex, 3] = boxProperties.Description;
                WSheet.Cells[RowIndex, 4] = boxProperties.Length;
                WSheet.Cells[RowIndex, 5] = boxProperties.Width;
                WSheet.Cells[RowIndex, 6] = boxProperties.Height;
            }
            // case
            if (analysisBoxCase.Container is BoxProperties caseProperties)
                WSheet.Cells[RowIndex, 7] = caseProperties.Name;
            // solution
            Solution sol = analysisBoxCase.Solution;
            WSheet.Cells[RowIndex, 8] = sol.ItemCount;
            WSheet.Cells[RowIndex, 9] = sol.LayerCount;
            WSheet.Cells[RowIndex, 10] = sol.LayerBoxCount(0);
            WSheet.Cells[RowIndex, 11] = sol.LoadWeight;
            WSheet.Cells[RowIndex, 12] = sol.Weight;
            WSheet.Cells[RowIndex, 13] = sol.VolumeEfficiency;

            InsertImage(analysis, 14);
        }

        protected override bool MatchesAnalysisType(Analysis analysis)
        {
            return analysis is AnalysisBoxCase;
        }
    }
}
