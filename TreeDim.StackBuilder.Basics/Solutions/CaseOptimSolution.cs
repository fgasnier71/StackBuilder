using System;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// Solution of CaseOptimAnalysis
    /// </summary>
    public class CaseOptimSolution : IComparable<CaseOptimSolution>
    {
        public CaseOptimSolution(CaseDefinition caseDefinition, CasePalletSolution palletSolution)
        {
            _caseDefinition = caseDefinition;
            _palletSolution = palletSolution;
        }

        public CasePalletSolution PalletSolution => _palletSolution;
        public CaseDefinition CaseDefinition => _caseDefinition;
        public int LayerCount => _palletSolution.Count;
        public int CaseCount => _palletSolution.CaseCount;

        // TODO - this is backwards to the CompareTo -> 1, 0, -1 convention.  Add comment if intentional.
        public int CompareTo(CaseOptimSolution other)
        {
            if (other == null)
                return -1;
            if (this.CaseCount > other.CaseCount)
                return -1;
            else if (this.CaseCount == other.CaseCount)
                return 0;
            else
                return 1;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("Case definition:");
            sb.Append(_caseDefinition);
            sb.Append(" - Pallet solution:");
            sb.Append(" Cases ");
            sb.Append(_palletSolution.CaseCount);
            sb.Append(" Layers ");
            sb.Append(_palletSolution.Count);
            return sb.ToString();
        }

        #region Non-Public Members

        private CaseDefinition _caseDefinition;
        private CasePalletSolution _palletSolution;

        #endregion
    }

}
