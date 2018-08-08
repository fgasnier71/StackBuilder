#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using Sharp3DBinPacking;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class HSolver : IHSolver
    {
        public List<HSolution> BuildSolutions(HAnalysis analysis)
        {
            var parameter = new BinPackParameter(1000, 1000, 1000, new[]
{
                new Cuboid(150, 100, 150),
                new Cuboid(500, 500, 500),
                new Cuboid(500, 550, 700),
                new Cuboid(350, 350, 350),
                new Cuboid(650, 750, 850),
            });

            List<HSolution> solutions = new List<HSolution>();

            // Create a bin packer instance
            // The default bin packer will test all algorithms and try to find the best result
            // BinPackerVerifyOption is used to avoid bugs, it will check whether the result is correct
            var binPacker = BinPacker.GetDefault(BinPackerVerifyOption.BestOnly);
            // The result contains bins which contains packed cuboids whith their coordinates
            var result = binPacker.Pack(parameter);

            HSolution sol = new HSolution("Sharp3DBinPacking") { Analysis = analysis };
            foreach (var bins in result.BestResult)
            {
                HSolItem hSolItem = sol.CreateSolItem();
                foreach (var cuboid in bins)
                {
                    CuboidToSolItem(cuboid, out int index, out BoxPosition pos);
                    hSolItem.InsertContainedElt(index, pos);
                }
            }
            solutions.Add(sol);
            return solutions;

        }
        public List<HSolution> BuildSolutions(Vector3D dimContainer, List<ContentItem> contentItems, HConstraintSet constraintSet)
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
            /*
            var parameter = new BinPackParameter((decimal)dimContainer.X, (decimal)dimContainer.Z, (decimal)dimContainer.Y, listCuboids.ToArray());
            */
            var parameter = new BinPackParameter(1000, 1000, 1000, new[]
            {
                new Cuboid(150, 100, 150),
                new Cuboid(500, 500, 500),
                new Cuboid(500, 550, 700),
                new Cuboid(350, 350, 350),
                new Cuboid(650, 750, 850),
            });



            // Create a bin packer instance
            // The default bin packer will test all algorithms and try to find the best result
            // BinPackerVerifyOption is used to avoid bugs, it will check whether the result is correct
            var binPacker = BinPacker.GetDefault(BinPackerVerifyOption.BestOnly);
            // The result contains bins which contains packed cuboids whith their coordinates
            var result = binPacker.Pack(parameter);

            HSolution sol = new HSolution("Sharp3DBinPacking");
            foreach (var bins in result.BestResult)
            {
                HSolItem hSolItem = sol.CreateSolItem();
                foreach (var cuboid in bins)
                {
                    CuboidToSolItem(cuboid, out int index, out BoxPosition pos);
                    hSolItem.InsertContainedElt(index, pos);
                }
            }
            solutions.Add(sol);
            return solutions;
        }
        private bool CuboidToSolItem(Cuboid cuboid, out int index, out BoxPosition pos)
        {
            index = 0;
            pos = BoxPosition.Zero;

            if (cuboid.Tag is BoxProperties bProperties)
            {
                pos = BoxPosition.FromPositionDimension(
                    new Vector3D((double)cuboid.X, (double)cuboid.Y, (double)cuboid.Z),
                    new Vector3D((double)cuboid.Width, (double)cuboid.Depth, (double)cuboid.Height),
                    new Vector3D(bProperties.Length, bProperties.Width, bProperties.Height));
                index = 0;
                return true;
            }
            return false;
        }
    }
}
