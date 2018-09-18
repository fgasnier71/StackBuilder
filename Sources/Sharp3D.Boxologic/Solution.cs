#region Using directives
using System.Collections.Generic;
using System.Text;
#endregion

namespace Sharp3D.Boxologic
{
    public class SolItem
    {
        public int Id { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public long BX { get; set; }
        public long BY { get; set; }
        public long BZ { get; set; }
        public long DimX { get; set; }
        public long DimY { get; set; }
        public long DimZ { get; set; }
        public override string ToString() { return $"ID={Id} X={X} Y={Y} Z={Z} BX={BX} BY={BY} BZ={BZ}"; }
    }

    public class Solution
    {
        public int Variant { get; set; }
        public int Iteration { get; set; }
        public List<SolItem> ItemsPacked = new List<SolItem>();
        public List<SolItem> ItemsUnpacked = new List<SolItem>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Variant={Variant} Iteration={Iteration}");
            if (ItemsPacked.Count > 0)
                sb.AppendLine("*** Packed items");
            foreach (var solItem in ItemsPacked)
                sb.AppendLine(solItem.ToString());
            if (ItemsUnpacked.Count > 0)
                sb.AppendLine("*** Unpacked items");
            foreach (var solItem in ItemsUnpacked)
                sb.AppendLine(solItem.ToString());
            return sb.ToString();
        }
    }

    public class SolutionArray
    {
        public List<Solution> Solutions = new List<Solution>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sol in Solutions)
                sb.AppendLine(sol.ToString());
            return sb.ToString();
        }
    }
}
