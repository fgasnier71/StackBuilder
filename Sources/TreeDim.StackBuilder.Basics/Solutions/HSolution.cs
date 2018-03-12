using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class HSolution
    {
        public IEnumerable<HSolItem> SolItems { get; set; }
        public IEnumerable<HUnloadedElt> UnloadedElts { get; set; }
    }
    public class HSolItem
    {
        public int ContainerType { get; set; }
        public IEnumerable<HSolElement> ContainedElements {get; set;}

        public Vector3D LoadDimensions { get; set; }
        public Vector3D TotalDimensions { get; set; }
    }
    public class HSolElement
    {
        public int ContentType { get; set; }
        public BoxPosition Position { get; set; }
    }
    public class HUnloadedElt
    {
        public int ContentType { get; set; }
        public int Number { get; set; }
    }
}
