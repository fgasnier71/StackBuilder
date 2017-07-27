using System;

namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// ITruckSolver interface should be implemented by any solver used for truck analyses
    /// </summary>
    public interface ITruckSolver
    {
        void ProcessAnalysis(TruckAnalysis truckAnalysis);
    }
}
