#region Using directives
using System.Linq;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerHSolution : Viewer
    {
        #region Constructor
        public ViewerHSolution(HSolution solution)
        {
            Solution = solution;
        }
        #endregion

        #region Abstract methods
        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            // draw pallet
            PalletProperties palletProperties = Solution.Analysis.Containers.First() as PalletProperties;
            Pallet p = new Pallet(palletProperties);
            p.Draw(graphics, transform);

            // get list of boxes
            List<Box> boxes = new List<Box>();
            HSolItem solItem = Solution.SolItems.First();
            uint pickId = 0;
            foreach (HSolElement solElt in solItem.ContainedElements)
            {
                if (Analysis.ContentTypeByIndex(solElt.ContentType) is BoxProperties bProperties)
                {
                    Box b = new Box(pickId++, bProperties)
                    {
                        Position = solElt.Position.Position,
                        HLengthAxis = solElt.Position.DirectionLength,
                        HWidthAxis = solElt.Position.DirectionWidth
                    };
                    boxes.Add(b);
                }
            }
            // draw boxes as triangles using BSPTree
            BSPTree bspTree = new BSPTree();
            foreach (Box b in boxes)
                bspTree.InsertBox(b);
            bspTree.Draw(graphics);
        }
        public override void Draw(Graphics2D graphics)  {}
        #endregion

        #region Data
        public HSolution Solution { get; set; }
        public HAnalysis Analysis => Solution.Analysis;
        #endregion
    }
}
