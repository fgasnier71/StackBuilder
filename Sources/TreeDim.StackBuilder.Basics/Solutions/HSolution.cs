#region Using directives
using System.Linq;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    /// <summary>
    /// Heterogeneous solution
    /// </summary>
    public class HSolution
    {
        public HSolution(string algo) { Algorithm = algo; }
        public IEnumerable<HSolItem> SolItems { get => hSolItems; }
        public IEnumerable<HUnloadedElt> UnloadedElts { get; set; }
        public HAnalysis Analysis { get; set; }
        public HSolItem CreateSolItem() { hSolItems.Add(new HSolItem()); return hSolItems[hSolItems.Count - 1]; }
        public string Algorithm { get; private set; } = string.Empty;
        public int LoadedCasesCount
        {
            get
            {
                int iCount = 0;
                foreach (HSolItem solItem in SolItems)
                    iCount += solItem.Count;
                return iCount;
            }
        }
        public int UnloadedCasesCount => UnloadedElts.ToList().Count;
        public double LoadedVolumePercentage
        {
            get
            {
                return 100.0;
            }
        }

        private readonly List<HSolItem> hSolItems = new List<HSolItem>();
    }
    /// <summary>
    /// Heterogeneous solution item
    /// </summary>
    public class HSolItem
    {
        public int ContainerType { get; set; }
        public IEnumerable<HSolElement> ContainedElements { get => hSolElt; }

        public void InsertContainedElt(int contentType, BoxPosition bPosition)
        {
            hSolElt.Add(new HSolElement() { ContentType = contentType, Position = bPosition });
        }
        public int Count => hSolElt.Count;
        public Vector3D LoadDimensions { get; set; }
        public Vector3D TotalDimensions { get; set; }

        private readonly List<HSolElement> hSolElt = new List<HSolElement>();
    }
    /// <summary>
    /// Solution element
    /// </summary>
    public class HSolElement
    {
        public int ContentType { get; set; }
        public BoxPosition Position { get; set; }
    }
    /// <summary>
    /// Unloaded element
    /// </summary>
    public class HUnloadedElt
    {
        public int ContentType { get; set; }
        public int Number { get; set; }
    }
}
