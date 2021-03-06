﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
using Sharp3DBinPacking;
using Sharp3D.Boxologic;
using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class HSolver : IHSolver
    {
        public List<HSolution> BuildSolutions(AnalysisHetero analysis)
        {
            // dim container + offset
            Vector3D dimContainer = analysis.DimContainer(0), offset = analysis.Offset(0);
            // content items
            List<ContentItem> contentItems = new List<ContentItem>(analysis.Content);
            // solutions
            List<HSolution> solutions = new List<HSolution>();

            // *** Sharp3DBinPacking : begin
            // create cuboid list
            List<Cuboid> listCuboids = new List<Cuboid>();
            bool bAllowAllOrientations = true;
            foreach (ContentItem ci in contentItems)
            {
                for (int i = 0; i < ci.Number; ++i)
                {
                    if (!ci.AllowOrientX && !ci.AllowOrientY && !ci.AllowOrientZ)
                        continue;
                    if (ci.Pack is BoxProperties b)
                        listCuboids.Add(
                            new Cuboid((decimal)b.Length, (decimal)b.Width, (decimal)b.Height)
                            {
                                Tag = BoxToID(ci.Pack as BProperties)
                                , AllowOrientX = ci.AllowOrientX
                                , AllowOrientY = ci.AllowOrientY
                                , AllowOrientZ = ci.AllowOrientZ
                                , PriorityLevel = ci.PriorityLevel
                            }
                        );
                }
                if (!ci.AllowOrientX || !ci.AllowOrientY || !ci.AllowOrientZ)
                    bAllowAllOrientations = false;
            }

            // Create a bin packer instance
            // The default bin packer will test all algorithms and try to find the best result
            // BinPackerVerifyOption is used to avoid bugs, it will check whether the result is correct
            var binPacker = BinPacker.GetDefault(BinPackerVerifyOption.BestOnly, bAllowAllOrientations);
            // The result contains bins which contains packed cuboids whith their coordinates
            decimal containerHeight = (decimal)dimContainer.Z;
            var parameter = new BinPackParameter(
                (decimal)dimContainer.X, (decimal)dimContainer.Y, containerHeight,
                listCuboids.ToArray())
            { ShuffleCount = 10 };

            // add increment and compute one step up
            parameter = new BinPackParameter(
            (decimal)dimContainer.X, (decimal)dimContainer.Y, containerHeight,
            listCuboids.ToArray());

            var binPackResult = binPacker.Pack(parameter);
            HSolution sol = new HSolution("Sharp3DBinPacking") { Analysis = analysis };

            foreach (var bins in binPackResult.BestResult)
            {
                HSolItem hSolItem = sol.CreateSolItem();
                foreach (var cuboid in bins)
                {
                    CuboidToSolItem(contentItems, offset, cuboid, out int index, out BoxPosition pos);
                    hSolItem.InsertContainedElt(index, pos);
                }
                hSolItem.Recenter(sol, dimContainer);
            }
            solutions.Add(sol);
            // *** Sharp3DBinPacking : end
            try
            {
                // *** BoxoLogic : begin
                List<BoxItem> listItems = new List<BoxItem>();
                foreach (ContentItem ci in contentItems)
                {
                    for (int i = 0; i < ci.Number; ++i)
                    {
                        if (ci.Pack is BoxProperties b)
                            listItems.Add(
                                new BoxItem()
                                {
                                    ID = BoxToID(b),
                                    Boxx = (decimal)b.Length,
                                    Boxy = (decimal)b.Width,
                                    Boxz = (decimal)b.Height,
                                    AllowX = ci.AllowOrientX,
                                    AllowY = ci.AllowOrientY,
                                    AllowZ = ci.AllowOrientZ,
                                    N = 1
                                }
                            );
                    }
                }
                var bl = new Boxlogic() { OutputFilePath = string.Empty };
                var solArray = new SolutionArray();
                bl.Run(listItems.ToArray(), (decimal)dimContainer.X, (decimal)dimContainer.Y, (decimal)dimContainer.Z, ref solArray);
                foreach (var solution in solArray.Solutions)
                {
                    HSolution sol2 = new HSolution("Boxologic") { Analysis = analysis };
                    HSolItem hSolItem = sol2.CreateSolItem();

                    Transform3D transform = Transform3D.Identity;
                    switch (solution.Variant)
                    {
                        case 1: transform = Transform3D.Translation(new Vector3D(0.0, dimContainer.Y, 0.0)) * Transform3D.RotationX(90.0); break;
                        case 2: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationZ(90.0); break;
                        case 3: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationZ(90.0); break;
                        case 4: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationY(-90.0); break;
                        case 5: transform = Transform3D.Translation(new Vector3D(0.0, dimContainer.Y, 0.0)) * Transform3D.RotationX(90.0); break;
                        default: transform = Transform3D.Identity; break;
                    }
                    foreach (var item in solution.ItemsPacked)
                    {
                        BoxInfoToSolItem(offset, item, transform, out int index, out BoxPosition pos);
                        hSolItem.InsertContainedElt(index, pos);
                    }
                    solutions.Add(sol2);
                    /*
                    for (int variant =1; variant < 6; ++variant)
                    {
                        HSolution solB = new HSolution($"Boxologic - Variant {variant}") { Analysis = analysis };
                        RunBoxologic(variant, solB, dimContainer, offset, contentItems);
                        solutions.Add(solB);
                    } // for
                    */
                    // *** BoxoLogic : end
                }
            }
            catch (Exception ex)
            {
                _log.Info($"Boxologic failed with exception {ex.Message}");
            }
            return solutions;
        }

        private void RunBoxologic(int variant, HSolution hSol, Vector3D dimContainer, Vector3D offset, List<ContentItem> contentItems)
        {
            _dictionnary.Clear();
            // ContentItem -> BoxItem
            uint iCountBoxItems = 0;
            List<BoxItem> boxItems = new List<BoxItem>();
            foreach (ContentItem ci in contentItems)
            {
                if ((ci.Number > 0) && (ci.Pack is BProperties b))
                    boxItems.Add(
                        new BoxItem()
                        {
                            ID = BoxToID(b),
                            Boxx = (decimal)b.Length,
                            Boxy = (decimal)b.Width,
                            Boxz = (decimal)b.Height,
                            AllowX = ci.AllowOrientX,
                            AllowY = ci.AllowOrientY,
                            AllowZ = ci.AllowOrientZ,
                            N = (int)ci.Number,
                            Order = ci.PriorityLevel
                        }
                );
                iCountBoxItems += ci.Number;
            }
            // solve
            var bl = new Boxlogic() { OutputFilePath = string.Empty };
            var solArray = new SolutionArray();
            bl.Run(variant, boxItems.ToArray(), (decimal)dimContainer.X, (decimal)dimContainer.Y, (decimal)dimContainer.Z, ref solArray);
            if (solArray.Solutions.Count == 0)
                return;
            foreach (var solution in solArray.Solutions)
            {
                HSolItem hSolItem = hSol.CreateSolItem();
                Transform3D transform;
                switch (variant)
                {
                    case 1: transform = Transform3D.Translation(new Vector3D(0.0, dimContainer.Y, 0.0)) * Transform3D.RotationX(90.0); break;
                    case 2: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationZ(90.0); break;
                    case 3: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationZ(90.0); break;
                    case 4: transform = Transform3D.Translation(new Vector3D(dimContainer.X, 0.0, 0.0)) * Transform3D.RotationY(-90.0); break;
                    case 5: transform = Transform3D.Translation(new Vector3D(0.0, dimContainer.Y, 0.0)) * Transform3D.RotationX(90.0); break;
                    default: transform = Transform3D.Identity; break;
                }

                var contentItemsClone = new List<ContentItem>();
                foreach (var ci in contentItems)
                    contentItemsClone.Add(
                        new ContentItem(ci.Pack, ci.Number, new bool[] { ci.AllowOrientX, ci.AllowOrientY, ci.AllowOrientZ }) { PriorityLevel = ci.PriorityLevel }
                        );

                foreach (var item in solution.ItemsPacked)
                {
                    BoxInfoToSolItem(offset, item, transform, out int index, out BoxPosition pos);
                    hSolItem.InsertContainedElt(index, pos.Adjusted(new Vector3D((double)item.DimX, (double)item.DimY, (double)item.DimZ)));

                    var ci = contentItemsClone.Find(c => c.Pack == IDToBox(item.Id));
                    System.Diagnostics.Debug.Assert(null != ci);
                    ci.Number -= 1;
                }
                hSolItem.Recenter(hSol, dimContainer);

                // remaining number of items
                int iCount = contentItemsClone.Sum(c => (int)c.Number);

                if (iCount > 0)
                    RunBoxologic(variant, hSol, dimContainer, offset, contentItemsClone);
            }
        }

        private uint BoxToID(BProperties b)
        {
            if (!_dictionnary.ContainsKey(b))
                _dictionnary.Add(b, (uint)_dictionnary.Count);
            return _dictionnary[b];
        }
        private BProperties IDToBox(uint id)
        {
            if (!_dictionnary.ContainsValue(id))
                throw new Exception($"Failed to find content item box with Id= {id}");
            return _dictionnary.FirstOrDefault(x => x.Value == id).Key;
        }

        private bool BoxInfoToSolItem(Vector3D offset, SolItem solItem, Transform3D transform, out int index, out BoxPosition pos)
        {
            index = 0;
            pos = BoxPosition.Zero;

            BProperties b = IDToBox(solItem.Id);
            if (null != b)
            {
                try
                {
                    index = (int)solItem.Id;
                    pos = BoxPosition.FromPositionDimension(
                        new Vector3D((double)solItem.X, (double)solItem.Y, (double)solItem.Z),
                        new Vector3D((double)solItem.BX, (double)solItem.BY, (double)solItem.BZ),
                        new Vector3D((double)solItem.DimX, (double)solItem.DimY, (double)solItem.DimZ)
                        );
                    pos =  pos.Transform(Transform3D.Translation(offset) * transform);

                    return true;
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message);
                }
            }
            return false;
        }

        private bool CuboidToSolItem(List<ContentItem> contentItems, Vector3D offset, Cuboid cuboid, out int index, out BoxPosition pos)
        {
            index = 0;
            pos = BoxPosition.Zero;
            try
            {
                index = int.Parse(cuboid.Tag.ToString());
                BProperties bProperties = IDToBox((uint)index);

                pos = BoxPosition.FromPositionDimension(
                        new Vector3D((double)cuboid.X, (double)cuboid.Y, (double)cuboid.Z) + offset,
                        new Vector3D((double)cuboid.Width, (double)cuboid.Height, (double)cuboid.Depth),
                        new Vector3D(bProperties.Length, bProperties.Width, bProperties.Height)
                        );
                return true;
            }
            catch (Exception ex)
                {
                    _log.Error(ex.Message);
                }
            return false;
        }

        public static bool BoxologicSingleSol { get; set; } = false;

        private Dictionary<BProperties, uint> _dictionnary = new Dictionary<BProperties, uint>();
        private static ILog _log = LogManager.GetLogger(typeof(HSolver));
    }
}
