using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisComparer : IComparer<AnalysisLayered>
    {
        public int Compare(AnalysisLayered x, AnalysisLayered y)
        {
            if (x.Solution.ItemCount < y.Solution.ItemCount)
                return 1;
            else if (x.Solution.ItemCount == y.Solution.ItemCount)
            {
                if (x.Solution.VolumeEfficiency < y.Solution.VolumeEfficiency)
                    return 1;
                else if (x.Solution.VolumeEfficiency == y.Solution.VolumeEfficiency)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
    }
}
