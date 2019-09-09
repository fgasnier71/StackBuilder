#region Using directives
using System.Collections.Generic;
using treeDiM.StackBuilder.Basics;

using treeDiM.StackBuilder.Reporting.Properties;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public class Material
    {
        public string Name { get; set; }
        public string Profile { get; set; }
        public double Thickness { get; set; }
        public double ECT { get; set; }
        public double RigidityDX { get; set; }
        public double RigidityDY { get; set; }
    };

    public class PalletisationResults
    {
        public int NoCasesPerLayer { get; set; }
        public int NoLayers { get; set; }
        public int NoCases { get; set; }
        public double LoadWeight { get; set; }
        public double PalletWeight { get; set; }
        public double LoadOnLowestCases { get; set; }
    }

    public class DynamicBCTRow
    {
        public string Name { get; set; }
        public List<double> Values { get; set; } = new List<double>();
    };

    public class ReportDataPackStress : ReportData
    {
        #region Override ReportData
        public override string Title => string.Format(Resources.ID_CASE_DIMENSIONS, Box.Length, Box.Width, Box.Height);
        public override string SuggestedFileName => string.Format(Resources.ID_CASE_DIMENSIONS, Box.Length, Box.Width, Box.Height);
        #endregion

        // Author
        public string Author { get; set; }
        // Case
        public BoxProperties Box { get; set; }
        // Material
        public Material Mat { get; set; }
        // Static BCT
        public double StaticBCT {get; set;}
        // Dynamic BCT
        public List<string> BCTColumnHeaders { get; set; } = new List<string>();
        public List<DynamicBCTRow> BCTRows { get; set; } = new List<DynamicBCTRow>(); 
        // Palletisation
        public Analysis Analysis { get; set; }
        // Formula type
        public int McKeeFormulaType { get; set; }
    }
}
