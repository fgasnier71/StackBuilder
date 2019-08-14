#region using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelExporter
{
    internal class AnalysisExporterCasePallet : AnalysisExporter
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
                "Ext. length",
                "Ext. width",
                "Ext. height",
                "Max pallet height",
                "Solution case count",
                "Layers",
                "Cases per layer",
                "Load weight",
                "Weight",
                "Volume efficiency",
                "Image"
                };
            }
        }
        protected override string SheetName => "Cases On Pallet";
        protected override bool MatchesAnalysisType(Analysis analysis)
        {
            return analysis is AnalysisCasePallet;
        }
        protected override void ExportAnalysisSpecific(Analysis analysis)
        {
            var analysisCasePallet = analysis as AnalysisCasePallet;
            // analysis name
            WSheet.Cells[RowIndex, 1] = analysisCasePallet.Name;
            // case
            BoxProperties caseProperties = analysisCasePallet.Content as BoxProperties;
            WSheet.Cells[RowIndex, 2] = caseProperties.Name;
            WSheet.Cells[RowIndex, 3] = caseProperties.Description;
            WSheet.Cells[RowIndex, 4] = caseProperties.Length;
            WSheet.Cells[RowIndex, 5] = caseProperties.Width;
            WSheet.Cells[RowIndex, 6] = caseProperties.Height;
            // constraints
            ConstraintSetCasePallet constraintSet = analysisCasePallet.ConstraintSet as ConstraintSetCasePallet;
            WSheet.Cells[RowIndex, 7] = constraintSet.OptMaxHeight.Value;
            // solution
            Solution sol = analysisCasePallet.Solution;
            WSheet.Cells[RowIndex, 8] = sol.ItemCount;
            WSheet.Cells[RowIndex, 9] = sol.LayerCount;
            WSheet.Cells[RowIndex, 10] = sol.LayerBoxCount(0);
            WSheet.Cells[RowIndex, 11] = sol.LoadWeight;
            WSheet.Cells[RowIndex, 12] = sol.Weight;
            WSheet.Cells[RowIndex, 13] = sol.VolumeEfficiency;
            InsertImage(analysis, 14);
        }
    }
}
