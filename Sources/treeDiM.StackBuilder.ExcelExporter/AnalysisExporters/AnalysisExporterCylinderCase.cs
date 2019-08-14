#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterCylinderCase : AnalysisExporter
    {
        protected override string[] Headers
        {
            get
            {
                return new string[]
                {
                "Analysis name",
                "Cylinder name",
                "Cylinder description",
                "Outer diameter",
                "Height",
                "Case name",
                "Cylinder count",
                "Layers",
                "Cylinders per layer",
                "Load weight",
                "Weight",
                "Volume efficiency",
                "Image"
                };
            }
        }
        protected override string SheetName => "Cylinders in case";
        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisCylinderCase = analysis as AnalysisCylinderCase;
            // analysis name
            WSheet.Cells[RowIndex, 1] = analysisCylinderCase.Name;
            // cylinder
            var cylinderProperties = analysisCylinderCase.Content as CylinderProperties;
            WSheet.Cells[RowIndex, 2] = cylinderProperties.Name;
            WSheet.Cells[RowIndex, 3] = cylinderProperties.Description;
            WSheet.Cells[RowIndex, 4] = cylinderProperties.RadiusOuter * 2.0;
            WSheet.Cells[RowIndex, 5] = cylinderProperties.Height;
            // case name
            var caseProperties = analysisCylinderCase.Container as BoxProperties;
            WSheet.Cells[RowIndex, 6] = caseProperties.Name;
            // solution
            Solution sol = analysisCylinderCase.Solution;
            WSheet.Cells[RowIndex, 7] = sol.ItemCount;
            WSheet.Cells[RowIndex, 8] = sol.LayerCount;
            WSheet.Cells[RowIndex, 9] = sol.LayerBoxCount(0);
            WSheet.Cells[RowIndex, 10] = sol.LoadWeight;
            WSheet.Cells[RowIndex, 11] = sol.Weight;
            WSheet.Cells[RowIndex, 12] = sol.VolumeEfficiency;

            InsertImage(analysis, 13);
        }
        protected override bool MatchesAnalysisType(Analysis analysis)
        {
            return analysis is AnalysisCylinderCase;
        }
    }
}
