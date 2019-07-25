#region Using directives
using System.Collections.Generic;
#endregion
/*
using treeDiM.EdgeCrushTest;


namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// ECT analysis
    /// </summary>
    public class ECTAnalysis : AnalysisLegacy
    {
        #region Data members
        private McKeeFormula.FormulaType _mcKeeFormula;
        #endregion

        #region Constructor
        public ECTAnalysis(Document doc)
            : base(doc)
        {
        }
        #endregion

        #region Public properties
        public McKeeFormula.QualityData Cardboard { get; set; }
        /// <summary>
        /// Use improved mc kee formula ?
        /// </summary>
        public bool UseImprovedFormula
        {
            get { return _mcKeeFormula == McKeeFormula.FormulaType.MCKEE_IMPROVED; }
            set { _mcKeeFormula = value ? McKeeFormula.FormulaType.MCKEE_IMPROVED : McKeeFormula.FormulaType.MCKEE_CLASSIC; }
        }
        /// <summary>
        /// Use classic mc kee formula
        /// </summary>
        public bool UseClassicFormula
        {
            get { return _mcKeeFormula == McKeeFormula.FormulaType.MCKEE_CLASSIC; }
        }
        /// <summary>
        /// Mc Kee formula used
        /// </summary>
        public string McKeeFormulaText
        {
            get { return McKeeFormula.ModeText(_mcKeeFormula); }
            set { _mcKeeFormula = McKeeFormula.TextToMode(value); }
        }
        /// <summary>
        /// Case type
        /// </summary>
        public string CaseType { get; set; }

        public string PrintSurface { get; set; }

        public double LoadOnFirstLayerCase
        {
            get
            {
                return 0.0;
            }
        }
        #endregion

        #region Results
        public double StaticBCT
        {
            get
            {
                BoxProperties boxProperties = null;
                return McKeeFormula.ComputeStaticBCT(boxProperties.Length, boxProperties.Width, boxProperties.Height, Cardboard.Id, CaseType, _mcKeeFormula); 
            }
        }
        public Dictionary<KeyValuePair<string, string>, double> DynamicBCTDictionary
        {
            get
            {
                BoxProperties boxProperties = null;
                return McKeeFormula.EvaluateEdgeCrushTestMatrix(boxProperties.Length, boxProperties.Width, boxProperties.Height, Cardboard.Id, CaseType, PrintSurface, _mcKeeFormula);
            }
        }
        #endregion

        #region ItemBase overrides
        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
}
*/