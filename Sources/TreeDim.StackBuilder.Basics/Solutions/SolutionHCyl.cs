#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region ILayoutSolver
    public interface ILayoutSolver
    {
        HCylLayout BuildLayoutNonStatic(Packable packable
            , Vector3D dimContainer
            , ConstraintSetAbstract constraintSet
            , string patternName
            , bool swapped);
    }
    #endregion

    #region SolutionHCyl
    public class SolutionHCyl : SolutionHomo
    {
        #region Constructor
        public SolutionHCyl(AnalysisHCyl analysis)
        {
            Analysis = analysis;
        }
        public SolutionHCyl(AnalysisHCyl analysis, string patternName, bool swapped)
        {
            Analysis = analysis;
            PatternName = patternName;
            Swapped = swapped;

            RebuildSolution();
        }
        #endregion

        #region Private methods
        public void RebuildSolution()
        {
            Layout = Solver.BuildLayoutNonStatic(
                Analysis.Content,
                AnalysisHCyl.ContainerDimensions3D,
                Analysis.ConstraintSet,
                PatternName,
                Swapped);
        }
        #endregion

        #region Public properties
        public AnalysisHCyl AnalysisHCyl => Analysis as AnalysisHCyl;
        #endregion

        #region Implementation SolutionHomo abstract methods 
        public override int ItemCount => Layout.Positions.Count;
        public override BBox3D BBoxLoad => Layout.BBox;
        #endregion

        #region Private properties
        public HCylLayout Layout { get; private set; }
        private string PatternName { get; set; }
        private bool Swapped { get; set; }
        public static ILayoutSolver Solver { get; set; }
        #endregion
    }
    #endregion
}
