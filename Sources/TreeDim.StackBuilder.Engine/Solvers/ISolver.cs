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
        List<AnalysisLayered> BuildAnalyses(bool allowMultipleLayerOrientations);
        Layer2DBrickImp BuildBestLayer();
    }

    /// <summary>
    /// interface for hererogeneous solvers
    /// </summary>
    interface IHSolver
    {
        List<HSolution> BuildSolutions(AnalysisHetero analysis);
    }
}
