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
        List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet);
        Layer2D BuildBestLayer(ConstraintSetAbstract constraintSet);
    }

    /// <summary>
    /// interface for hererogeneous solvers
    /// </summary>
    interface IHSolver
    {
        List<HSolution> BuildSolutions(Vector3D dimContainer, IEnumerable<ContentItem> contentItem, HConstraintSet constraintSet);
    }
}
