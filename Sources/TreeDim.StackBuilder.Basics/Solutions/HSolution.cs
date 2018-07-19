#region Using directives
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
        public IEnumerable<HSolItem> SolItems { get; set; }
        public IEnumerable<HUnloadedElt> UnloadedElts { get; set; }
    }
    /// <summary>
    /// Heterogeneous solution item
    /// </summary>
    public class HSolItem
    {
        public int ContainerType { get; set; }
        public IEnumerable<HSolElement> ContainedElements {get; set;}

        public Vector3D LoadDimensions { get; set; }
        public Vector3D TotalDimensions { get; set; }
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
