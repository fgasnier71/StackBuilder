#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterCaseTruck : AnalysisExporter
    {
        protected override string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Analysis name",
                    "Case name",
                    "Case description",
                    "Length",
                    "Width",
                    "Height",
                    "TruckName",
                    "Case count",
                    "Layers",
                    "Case count",
                    "Case per layer",
                    "Load weight",
                    "Volume efficiency",
                    "Image"
                };
            }
        }

        protected override string SheetName => "Cases in truck";

        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisCaseTruck = analysis as AnalysisCaseTruck;
            // analysis name
            WSheet.Cells[RowIndex, 1] = analysisCaseTruck.Name;
            // case
            if (analysisCaseTruck.Content is BoxProperties boxProperties)
            {
                WSheet.Cells[RowIndex, 2] = boxProperties.Name;
                WSheet.Cells[RowIndex, 3] = boxProperties.Description;
                WSheet.Cells[RowIndex, 4] = boxProperties.Length;
                WSheet.Cells[RowIndex, 5] = boxProperties.Width;
                WSheet.Cells[RowIndex, 6] = boxProperties.Height;
            }
            // truck
            if (analysisCaseTruck.Container is TruckProperties truck)
                WSheet.Cells[RowIndex, 7] = truck.Name;
            // solution
            Solution sol = analysisCaseTruck.Solution;
            WSheet.Cells[RowIndex, 8] = sol.ItemCount;
            WSheet.Cells[RowIndex, 9] = sol.LayerCount;
            WSheet.Cells[RowIndex, 10] = sol.LayerBoxCount(0);
            WSheet.Cells[RowIndex, 11] = sol.LoadWeight;
            WSheet.Cells[RowIndex, 12] = sol.VolumeEfficiency;

            InsertImage(analysis, 13);
        }
        protected override bool MatchesAnalysisType(Analysis analysis)
        {
            return analysis is AnalysisCaseTruck; 
        }
    }
}
