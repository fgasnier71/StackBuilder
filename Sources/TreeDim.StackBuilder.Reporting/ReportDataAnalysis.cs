#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public abstract class ReportData
    {
        public abstract string Title { get; }
        public virtual bool IsValid { get => true; }
        public abstract string SuggestedFileName { get; }
    }
    /// <summary>
    /// class used to encapsulate an analysis and a solution
    /// </summary>
    public class ReportDataAnalysis : ReportData
    {
        #region Constructors
        public ReportDataAnalysis(Analysis analysis) { Analysis = analysis; }
        #endregion
        #region Public accessors
        public Document Document => Analysis?.ParentDocument;
        public Analysis Analysis { get; set; }
        public Analysis MainAnalysis 
        {
            get
            {
                if (null == Analysis) throw new ReportExceptionInvalidAnalysis();
                return Analysis;
            }
        }
        #endregion
        #region ReportData
        public override string Title => Analysis != null ? Analysis.Name : string.Empty;
        public override string SuggestedFileName => Analysis?.Name;
        public override bool IsValid => null != Analysis && (Analysis.HasValidSolution);
        #endregion
        #region IItemListener related methods
        public void AddListener(IItemListener listener) => Analysis?.AddListener(listener);
        public void RemoveListener(IItemListener listener) => Analysis?.RemoveListener(listener);
        #endregion
        #region Object override
        public override bool Equals(object obj)
        {
            if (obj is ReportDataAnalysis)
            {
                ReportDataAnalysis reportObject = obj as ReportDataAnalysis;
                return Analysis == reportObject.Analysis;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Analysis.GetHashCode();
        }
        #endregion
    }
}