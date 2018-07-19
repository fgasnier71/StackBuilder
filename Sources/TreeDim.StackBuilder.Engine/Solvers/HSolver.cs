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
        public List<HSolution> BuildSolutions(Vector3D dimContainer, IEnumerable<ContentItem> contentItems, HConstraintSet constraintSet)
        {
            List<HSolution> solutions = new List<HSolution>();

            // *** Sharp3DBinPacking
            // create cuboid list
            List<Cuboid> listCuboids = new List<Cuboid>();
            foreach (ContentItem ci in contentItems)
            {
                for (int i = 0; i < ci.Number; ++i)
                {
                    if (ci.Pack is BoxProperties b)
                    {
                        Cuboid cb = new Cuboid()
                        {
                            Width = (decimal)b.Length,
                            Depth = (decimal)b.Width,
                            Height = (decimal)b.Height,
                            Weight = (decimal)b.Weight,
                            Tag = b
                        };
                        listCuboids.Add(cb);
                    }
                }
            }
            // define cuboids to pack
            var parameter = new BinPackParameter((decimal)dimContainer.X, (decimal)dimContainer.Z, (decimal)dimContainer.Y, listCuboids.ToArray());
            // Create a bin packer instance
            // The default bin packer will test all algorithms and try to find the best result
            // BinPackerVerifyOption is used to avoid bugs, it will check whether the result is correct
            var binPacker = BinPacker.GetDefault(BinPackerVerifyOption.BestOnly);
            // The result contains bins which contains packed cuboids whith their coordinates
            var result = binPacker.Pack(parameter);

            HSolution sol = new HSolution();
            List<HSolItem> solItems = new List<HSolItem>();
            foreach (var bins in result.BestResult)
            {
                foreach (var cuboid in bins)
                {
                    solItems.Add(CuboidToSolItem(cuboid));
                }
            }
            sol.SolItems = solItems;
            solutions.Add(new HSolution() { SolItems = solItems });
            return solutions;
        }
        private HSolItem CuboidToSolItem(Cuboid cuboid)
        {
            return new HSolItem() {};
        }
    }


}
