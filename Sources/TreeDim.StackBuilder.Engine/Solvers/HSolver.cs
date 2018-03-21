#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;

using Sharp3DBinPacking;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class HSolver : IHSolver
    {
        public List<HSolution> BuildSolutions(Vector3D dimContainer, IEnumerable<ContentItem> contentItem, HConstraintSet constraintSet)
        {
            List<HSolution> solutions = new List<HSolution>();

            Sharp3DBinPacking.BinPacker binPacker = new BinPacker();


            return solutions;
        }
    }
}
