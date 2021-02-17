#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisPalletsOnPallet : Analysis
    {


        public AnalysisPalletsOnPallet(Document doc) : base(doc) { }
        public override bool HasValidSolution => true;

        public PalletProperties PalletProperties { get; set; }
        public LoadedPallet[] PalletAnalyses { get; set; } = new LoadedPallet[4];
        #region Helpers

        #endregion

        public enum EMode { PALLET_HALF, PALLET_QUARTER }
        public EMode Mode { get; set; } = EMode.PALLET_HALF;
    }

    public class SolutionPalletsOnPallet
    { 
        public AnalysisPalletsOnPallet Analysis { get; set; }
    }
}
