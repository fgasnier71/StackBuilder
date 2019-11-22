#region Using directives
using System;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterCylinderPallet : AnalysisExporter
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
                    "Pallet name",
                    "Max pallet height",
                    "Solution cylinder count",
                    "Layers",
                    "Cylinders per layer",
                    "Load weight",
                    "Weight",
                    "Volume efficiency",
                    "Image"
                };
            }
        }
        protected override string SheetName => "Cylinders on pallet";

        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisCylinderPallet = analysis as AnalysisCylinderPallet;
            // analysis name
            WSheet.Cells[RowIndex, 1] = analysisCylinderPallet.Name;
            // cylinder
            var cylinderProperties = analysisCylinderPallet.Content as CylinderProperties;
            WSheet.Cells[RowIndex, 2] = cylinderProperties.Name;
            WSheet.Cells[RowIndex, 3] = cylinderProperties.Description;
            WSheet.Cells[RowIndex, 4] = cylinderProperties.RadiusOuter * 2.0;
            WSheet.Cells[RowIndex, 5] = cylinderProperties.Height;
            // pallet name
            var palletProperties = analysisCylinderPallet.Container as PalletProperties;
            WSheet.Cells[RowIndex, 6] = palletProperties.Name;
            // constraint set
            ConstraintSetPackablePallet constraintSet = analysisCylinderPallet.ConstraintSet as ConstraintSetPackablePallet;
            WSheet.Cells[RowIndex, 7] = constraintSet.OptMaxHeight.Value;
            // solution
            SolutionLayered sol = analysisCylinderPallet.SolutionLay;
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
            return analysis is AnalysisCylinderPallet;
        }
    }
}
