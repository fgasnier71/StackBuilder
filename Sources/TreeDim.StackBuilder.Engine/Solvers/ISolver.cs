#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    /// <summary>
    /// interface for homogeneous solvers
    /// </summary>
    interface ISolver
    {
        List<AnalysisHomo> BuildAnalyses(ConstraintSetAbstract constraintSet, bool allowMultipleLayerOrientations);
        Layer2D BuildBestLayer(ConstraintSetAbstract constraintSet);
    }

    /// <summary>
    /// interface for hererogeneous solvers
    /// </summary>
    interface IHSolver
    {
        List<HSolution> BuildSolutions(AnalysisHetero analysis);
    }
}
