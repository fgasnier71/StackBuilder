using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisComparer : IComparer<AnalysisHomo>
    {
        public int Compare(AnalysisHomo x, AnalysisHomo y)
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
