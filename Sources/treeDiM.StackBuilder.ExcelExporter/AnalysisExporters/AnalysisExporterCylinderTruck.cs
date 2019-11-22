#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterCylinderTruck : AnalysisExporter
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
                    "Truck name",
                    "Solution cylinder count",
                    "Layers",
                    "Cylinder per layer",
                    "Load weight",
                    "Volume efficiency",
                    "Image"
                };
            }
        }

        protected override string SheetName => "Cylinders in truck";

        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisCylinderTruck = analysis as AnalysisCylinderTruck;
            // analysis name
            WSheet.Cells[RowIndex, 2] = analysisCylinderTruck.Name;
            // cylinder
            var cylinderProperties = analysisCylinderTruck.Content as CylinderProperties;
            WSheet.Cells[RowIndex, 2] = cylinderProperties.Name;
            WSheet.Cells[RowIndex, 3] = cylinderProperties.Description;
            WSheet.Cells[RowIndex, 4] = cylinderProperties.RadiusOuter * 2.0;
            WSheet.Cells[RowIndex, 5] = cylinderProperties.Height;
            // truck name
            var truckProperties = analysisCylinderTruck.Container as TruckProperties;
            WSheet.Cells[RowIndex, 6] = truckProperties.Name;
            // solution
            SolutionLayered sol = analysisCylinderTruck.SolutionLay;
            WSheet.Cells[RowIndex, 7] = sol.ItemCount;
            WSheet.Cells[RowIndex, 8] = sol.LayerCount;
            WSheet.Cells[RowIndex, 9] = sol.LayerBoxCount(0);
            WSheet.Cells[RowIndex, 10] = sol.LoadWeight;
            WSheet.Cells[RowIndex, 11] = sol.VolumeEfficiency;
            // image
            InsertImage(analysis, 12);
        }

        protected override bool MatchesAnalysisType(Analysis analysis)
        {
            return analysis is AnalysisCylinderTruck;
        }
    }
}
